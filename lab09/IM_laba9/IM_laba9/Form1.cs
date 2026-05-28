using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IM_laba9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawChart(double p0T, double p0E, double p1T, double p1E)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea());

            Series sTheory = new Series("Теория") { ChartType = SeriesChartType.Column };
            sTheory.Points.AddXY("P0", p0T);
            sTheory.Points.AddXY("P1", p1T);

            Series sEmp = new Series("Модель") { ChartType = SeriesChartType.Column };
            sEmp.Points.AddXY("P0", p0E);
            sEmp.Points.AddXY("P1", p1E);

            chart1.Series.Add(sTheory);
            chart1.Series.Add(sEmp);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Считывание параметров
            double lambda = double.Parse(textBox1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            double mu = double.Parse(textBox2.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            int totalRequests = int.Parse(textBox3.Text);

            // Инициализация генератора и переменных
            var rng = new MultRandom(DateTime.Now.Ticks & 0x7FFFFFFF);

            // Локальная функция для экспоненциального распределения
            double GenExp(double rate) => -Math.Log(1 - Math.Max(rng.Next(), 1e-10)) / rate;

            double currentTime = 0;
            int busyChannels = 0;
            int maxChannels = 1;

            int accepted = 0;
            int rejected = 0;
            int processed = 0;
            double totalBusyTime = 0;

            double timeToNextArrival = GenExp(lambda);
            double timeToServiceEnd = double.PositiveInfinity;

            // Основной цикл имитационного моделирования
            while (processed < totalRequests)
            {
                if (timeToNextArrival < timeToServiceEnd) // Событие: Приход заявки
                {
                    if (busyChannels > 0) totalBusyTime += timeToNextArrival;
                    currentTime += timeToNextArrival;

                    if (busyChannels < maxChannels)
                    {
                        busyChannels++;
                        accepted++;
                        timeToServiceEnd = GenExp(mu); // Запуск обслуживания
                    }
                    else
                    {
                        rejected++; // Канал занят -> Отказ
                        timeToServiceEnd -= timeToNextArrival;
                    }

                    processed++;
                    timeToNextArrival = GenExp(lambda);
                }
                else // Событие: Завершение обслуживания
                {
                    if (busyChannels > 0) totalBusyTime += timeToServiceEnd;
                    currentTime += timeToServiceEnd;

                    timeToNextArrival -= timeToServiceEnd;
                    busyChannels--;

                    // Так как N=1, канал становится свободным
                    timeToServiceEnd = double.PositiveInfinity;
                }
            }

            // РАСЧЕТЫ
            double rho = lambda / mu;
            double p0Theory = 1.0 / (1.0 + rho);
            double p1Theory = rho / (1.0 + rho);

            double p1Emp = totalBusyTime / currentTime;
            double p0Emp = 1.0 - p1Emp;

            // ВЫВОД РЕЗУЛЬТАТОВ
            label4.Text = $"--- РЕЗУЛЬТАТЫ (M/M/1/0) ---\n\n" +
              $"Принято: {accepted}\n" +
              $"Отказано: {rejected}\n" +
              $"Время моделир.: {currentTime:F2}\n" +
              $"Вероятн. отказа: {(double)rejected / totalRequests:F4}\n\n" +
              $"P0 (теория): {p0Theory:F4}\n" +
              $"P0 (модель): {p0Emp:F4}\n\n" +
              $"P1 (теория): {p1Theory:F4}\n" +
              $"P1 (модель): {p1Emp:F4}";

            DrawChart(p0Theory, p0Emp, p1Theory, p1Emp);
        }
    }

    public class MultRandom
    {
        private long x_mult;
        private const long c = 132149;
        private const long m = (long)int.MaxValue;

        public MultRandom(long seed) { x_mult = seed; }

        public double Next()
        {
            x_mult = (c * x_mult) % m;
            return (double)x_mult / m;
        }
    }
}