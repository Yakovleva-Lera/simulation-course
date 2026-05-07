using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkovWeatherLab
{
    public partial class Form1 : Form
    {
        #region [ Генератор случайных чисел ]

        public class MultiplicativeCongruentialGenerator
        {
            private long x;
            private const long BETA = 16807;
            private const long M = 2147483647;

            public MultiplicativeCongruentialGenerator(long seed = 52) => x = seed;

            public double Next()
            {
                x = (x * BETA) % M;
                return (double)x / M;
            }
        }

        #endregion

        #region [ Поля и константы ]

        // Модель
        private double[,] Q = new double[3, 3];
        private double[] timeInState = new double[3];
        private double[] piTheoretical = new double[3];

        // Состояние симуляции
        private double currentTime = 0;
        private int currentState = 1;
        private int eventCount = 0;
        private bool isRunning = false;

        // Параметры
        private bool stopByEvents = true;
        private int statsEvents = 1000;
        private double maxDays = 30;
        private int updateDelay = 200;
        private bool isUpdatingTable = false;

        // Генератор
        private MultiplicativeCongruentialGenerator myRnd = null!;

        // Данные и визуализация
        private readonly List<string[]> csvData = new();
        private readonly Color[] stateColors = { Color.Gold, Color.Gray, Color.DarkGray };
        private readonly string[] stateNames = { "Ясно", "Облачно", "Пасмурно" };
        private readonly Color[] logColors = { Color.DarkOrange, Color.SteelBlue, Color.DimGray };

        #endregion

        #region [ Конструктор и инициализация ]

        public Form1()
        {
            InitializeComponent();
            BindEvents();
            SetupDefaultMatrix();
            ComputeTheoretical();

            myRnd = new MultiplicativeCongruentialGenerator((long)DateTime.Now.Ticks);
            InitializeRandomState();
            UpdateUI();
        }

        private void BindEvents()
        {
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;
            btnReset.Click += BtnReset_Click;
            gridQ.CellValueChanged += (s, e) => UpdateDiagonals();
            trackSpeed.ValueChanged += (s, e) => lblSpeedValue.Text = $"{trackSpeed.Value} мс";
            panelPieChart.Paint += PanelPieChart_Paint;

            radioByEvents.CheckedChanged += ToggleMode;
            radioByDays.CheckedChanged += ToggleMode;
        }

        private void ToggleMode(object? s, EventArgs e)
        {
            bool byEvents = radioByEvents.Checked;
            lblEvents.Visible = byEvents; numEvents.Visible = byEvents;
            lblDays.Visible = !byEvents; numDays.Visible = !byEvents;
        }

        #endregion

        #region [ Работа с матрицей Q ]

        private void SetupDefaultMatrix()
        {
            isUpdatingTable = true;
            gridQ.Rows[0].Cells[1].Value = "0.3"; gridQ.Rows[0].Cells[2].Value = "0.2";
            gridQ.Rows[1].Cells[0].Value = "0.1"; gridQ.Rows[1].Cells[2].Value = "0.3";
            gridQ.Rows[2].Cells[0].Value = "0.2"; gridQ.Rows[2].Cells[1].Value = "0.1";
            isUpdatingTable = false;
            UpdateDiagonals();
        }

        private void UpdateDiagonals()
        {
            if (isUpdatingTable) return;
            isUpdatingTable = true;

            for (int i = 0; i < 3; i++)
            {
                double sum = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (i != j && double.TryParse(
                        gridQ.Rows[i].Cells[j].Value?.ToString()?.Replace(',', '.'),
                        NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                        sum += val;
                }
                gridQ.Rows[i].Cells[i].Value = (-sum).ToString("F2", CultureInfo.InvariantCulture);
                gridQ.Rows[i].Cells[i].Style.BackColor = Color.MistyRose;
                gridQ.Rows[i].Cells[i].ReadOnly = true;
                gridQ.Rows[i].Cells[i].Style.ForeColor = Color.DarkRed;
            }
            isUpdatingTable = false;
        }

        private void ReadQ()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Q[i, j] = double.Parse(
                        gridQ.Rows[i].Cells[j].Value?.ToString()?.Replace(',', '.') ?? "0",
                        CultureInfo.InvariantCulture);
        }

        #endregion

        #region [ Теоретическое распределение (π·Q = 0) ]

        private double[] ComputeTheoretical()
        {
            ReadQ();
            double[,] A = { { Q[0, 0], Q[1, 0], Q[2, 0] }, { Q[0, 1], Q[1, 1], Q[2, 1] }, { 1, 1, 1 } };
            double[] B = { 0, 0, 1 };

            double det = Det3(A);
            if (Math.Abs(det) < 1e-9) return new[] { 1.0 / 3, 1.0 / 3, 1.0 / 3 };

            double[] res = new double[3];
            for (int i = 0; i < 3; i++)
            {
                double[,] Ai = (double[,])A.Clone();
                Ai[0, i] = B[0]; Ai[1, i] = B[1]; Ai[2, i] = B[2];
                res[i] = Det3(Ai) / det;
            }
            piTheoretical = res;
            return res;
        }

        private double Det3(double[,] m) =>
            m[0, 0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1]) -
            m[0, 1] * (m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0]) +
            m[0, 2] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);

        #endregion

        #region [ Генерация случайных величин ]

        private void InitializeRandomState()
        {
            double r = myRnd.Next();
            double cum = 0;
            for (int i = 0; i < 3; i++)
            {
                cum += piTheoretical[i];
                if (r <= cum) { currentState = i + 1; return; }
            }
            currentState = 3;
        }

        private int GetNextState(int currentStateIndex, out double tau)
        {
            double qExit = -Q[currentStateIndex, currentStateIndex];

            // Время пребывания: экспоненциальное распределение
            double u = myRnd.Next();
            tau = -Math.Log(1.0 - u) / qExit;

            // Выбор следующего состояния
            double r = myRnd.Next() * qExit;
            double cum = 0;
            for (int j = 0; j < 3; j++)
            {
                if (j == currentStateIndex) continue;
                cum += Q[currentStateIndex, j];
                if (r <= cum) return j;
            }
            return currentStateIndex;
        }

        #endregion

        #region [ Основной цикл моделирования ]

        private void StepSimulation()
        {
            if (!isRunning) return;

            int idx = currentState - 1;
            int nextIdx = GetNextState(idx, out double tau);

            // Ограничение по времени (режим по дням)
            if (!stopByEvents && currentTime + tau > maxDays)
                tau = maxDays - currentTime;

            currentTime += tau;
            timeInState[idx] += tau;
            currentState = nextIdx + 1;
            eventCount++;

            LogWeather(currentTime - tau, tau, idx);
            RecordSnapshot();
            UpdateUI();

            // Проверка условия остановки
            if ((stopByEvents && eventCount >= statsEvents) ||
                (!stopByEvents && currentTime >= maxDays))
                isRunning = false;
        }

        #endregion

        #region [ Логирование и экспорт ]

        private void LogWeather(double tStart, double dur, int idx)
        {
            var s = TimeSpan.FromDays(tStart);
            var e = TimeSpan.FromDays(tStart + dur);
            var d = TimeSpan.FromDays(dur);
            string msg = $"[{s.Days}д {s.Hours:D2}:{s.Minutes:D2}–{e.Days}д {e.Hours:D2}:{e.Minutes:D2}] " +
                        $"{stateNames[idx],-9} | {d.Days}д {d.Hours:D2}ч";
            LogMessage(msg, logColors[idx]);
        }

        private void LogMessage(string text, Color color)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => LogMessage(text, color)));
                return;
            }
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.SelectionColor = color;
            txtLog.AppendText(text + Environment.NewLine);
            txtLog.ScrollToCaret();
        }

        private void RecordSnapshot()
        {
            double total = currentTime > 0 ? currentTime : 1;
            double[] emp = timeInState.Select(t => t / total).ToArray();
            csvData.Add(new[] {
                eventCount.ToString(),
                currentTime.ToString("F4", CultureInfo.InvariantCulture),
                currentState.ToString(),
                stateNames[currentState - 1],
                emp[0].ToString("F6", CultureInfo.InvariantCulture),
                emp[1].ToString("F6", CultureInfo.InvariantCulture),
                emp[2].ToString("F6", CultureInfo.InvariantCulture),
                piTheoretical[0].ToString("F6", CultureInfo.InvariantCulture),
                piTheoretical[1].ToString("F6", CultureInfo.InvariantCulture),
                piTheoretical[2].ToString("F6", CultureInfo.InvariantCulture)
            });
        }

        private void SaveToCSV()
        {
            using var sfd = new SaveFileDialog { Filter = "CSV|*.csv", FileName = "weather_markov.csv" };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            using var sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8);
            sw.WriteLine("Event_k,Time_days,State_ID,State_Name,Empirical_1,2,3,Theoretical_1,2,3");
            foreach (var row in csvData) sw.WriteLine(string.Join(",", row));

            MessageBox.Show("Данные сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region [ Обработчики кнопок ]

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (isRunning) return;

            // Чтение параметров
            ReadQ();
            ComputeTheoretical();
            stopByEvents = radioByEvents.Checked;
            statsEvents = (int)numEvents.Value;
            maxDays = (double)numDays.Value;
            updateDelay = trackSpeed.Value;

            // Блокировка интерфейса
            SetControlsEnabled(false);

            // Инициализация
            myRnd = new MultiplicativeCongruentialGenerator((long)DateTime.Now.Ticks);
            InitializeRandomState();
            currentTime = 0; eventCount = 0;
            Array.Clear(timeInState, 0, timeInState.Length);
            csvData.Clear(); txtLog.Clear();

            isRunning = true;

            LogMessage($"СТАРТ. Режим: {(stopByEvents ? "событий: " + statsEvents : "дней: " + maxDays)}. Старт: {stateNames[currentState - 1]}", Color.Black);

            // Запуск в фоновом потоке
            await Task.Run(() => {
                while (isRunning)
                {
                    Invoke(new Action(StepSimulation));
                    if (updateDelay > 0) Thread.Sleep(updateDelay);
                }
            });

            // Завершение
            SaveToCSV();
            LogMessage($"ЗАВЕРШЕНО. Событий: {eventCount}, Время: {currentTime:F2} дней", Color.Green);
            SetControlsEnabled(true);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            isRunning = false;
            SetControlsEnabled(true);
            btnStop.Enabled = false;
            LogMessage("ОСТАНОВЛЕНО ПОЛЬЗОВАТЕЛЕМ", Color.Red);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            isRunning = false;
            currentTime = 0; currentState = 1; eventCount = 0;
            Array.Clear(timeInState, 0, timeInState.Length);
            csvData.Clear();

            myRnd = new MultiplicativeCongruentialGenerator((long)DateTime.Now.Ticks);
            ComputeTheoretical();
            InitializeRandomState();

            UpdateUI();
            panelPieChart.Invalidate();
            txtLog.Clear();
            SetControlsEnabled(true);
            btnStop.Enabled = false;
        }

        private void SetControlsEnabled(bool enabled)
        {
            btnStart.Enabled = enabled;
            btnReset.Enabled = enabled;
            gridQ.Enabled = enabled;
            numEvents.Enabled = enabled;
            numDays.Enabled = enabled;
            trackSpeed.Enabled = enabled;
            radioByEvents.Enabled = enabled;
            radioByDays.Enabled = enabled;
            btnStop.Enabled = !enabled;
        }

        #endregion

        #region [ Обновление интерфейса ]

        private void UpdateUI()
        {
            // Статус и прогресс
            if (stopByEvents)
            {
                lblState.Text = $"Событие {eventCount}/{statsEvents}: {stateNames[currentState - 1]}";
                pbProgress.Value = (int)Math.Min(100, statsEvents > 0 ? eventCount * 100.0 / statsEvents : 0);
            }
            else
            {
                lblState.Text = $"Время {currentTime:F2}/{maxDays} дней: {stateNames[currentState - 1]}";
                pbProgress.Value = (int)Math.Min(100, maxDays > 0 ? currentTime * 100.0 / maxDays : 0);
            }
            lblProgress.Text = $"Выполнено: {pbProgress.Value}%";
            lblTime.Text = stopByEvents ? $"Время: {currentTime:F2} дней" : $"Событий: {eventCount}";

            // Сравнение распределений
            double total = currentTime > 0 ? currentTime : 1;
            for (int i = 0; i < 3; i++)
            {
                double emp = timeInState[i] / total;
                lblEmp[i].Text = $"{emp:F3}";
                lblTheor[i].Text = $"{piTheoretical[i]:F3}";
                lblDiff[i].Text = $"{Math.Abs(emp - piTheoretical[i]):F3}";
            }
            panelPieChart.Invalidate();
        }

        #endregion

        #region [ Отрисовка круговой диаграммы ]

        private void PanelPieChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = new(10, 10, panelPieChart.Width - 20, panelPieChart.Height - 20);
            double total = currentTime > 0 ? currentTime : 1;
            float startAngle = 0;

            // Отрисовка секторов
            for (int i = 0; i < 3; i++)
            {
                double f = timeInState[i] / total;
                float sweep = (float)(f * 360);
                if (sweep > 0.1f)
                {
                    using var brush = new SolidBrush(stateColors[i]);
                    using var pen = new Pen(Color.Black, 1);
                    g.FillPie(brush, rect, startAngle, sweep);
                    g.DrawPie(pen, rect, startAngle, sweep);
                }
                startAngle += sweep;
            }

            // Подписи секторов
            float angle = 0;
            for (int i = 0; i < 3; i++)
            {
                double f = timeInState[i] / total;
                if (f > 0.05)
                {
                    float mid = angle + (float)(f * 180);
                    float rad = mid * (float)Math.PI / 180f;
                    float r = rect.Width / 4f;
                    PointF center = new(
                        rect.X + rect.Width / 2f + r * (float)Math.Cos(rad),
                        rect.Y + rect.Height / 2f + r * (float)Math.Sin(rad)
                    );
                    g.DrawString($"{i + 1}", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.White, center);
                }
                angle += (float)(f * 360);
            }
        }

        #endregion
    }
}