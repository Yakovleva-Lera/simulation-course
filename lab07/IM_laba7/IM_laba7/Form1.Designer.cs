namespace MarkovWeatherLab
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.DataGridView gridQ;
        private System.Windows.Forms.Button btnStart, btnStop, btnReset;
        private System.Windows.Forms.NumericUpDown numEvents, numDays;
        private System.Windows.Forms.Label lblEvents, lblDays;
        private System.Windows.Forms.TrackBar trackSpeed;
        private System.Windows.Forms.Label lblSpeedValue;
        private System.Windows.Forms.Panel panelPieChart;
        private System.Windows.Forms.Label[] lblEmp = new System.Windows.Forms.Label[3];
        private System.Windows.Forms.Label[] lblTheor = new System.Windows.Forms.Label[3];
        private System.Windows.Forms.Label[] lblDiff = new System.Windows.Forms.Label[3];
        private System.Windows.Forms.Label lblState, lblTime, lblProgress, lblHeaderEmp, lblHeaderTheor, lblHeaderDiff;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.RadioButton radioByEvents, radioByDays;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.gridQ = new System.Windows.Forms.DataGridView();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.numEvents = new System.Windows.Forms.NumericUpDown();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.trackSpeed = new System.Windows.Forms.TrackBar();
            this.lblSpeedValue = new System.Windows.Forms.Label();
            this.panelPieChart = new System.Windows.Forms.Panel();
            this.lblState = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblHeaderEmp = new System.Windows.Forms.Label();
            this.lblHeaderTheor = new System.Windows.Forms.Label();
            this.lblHeaderDiff = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.radioByEvents = new System.Windows.Forms.RadioButton();
            this.radioByDays = new System.Windows.Forms.RadioButton();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();

            // === ЛЕВАЯ ПАНЕЛЬ ===
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Width = 440; // Чуть шире
            this.panelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft.BackColor = System.Drawing.Color.WhiteSmoke;

            // === МАТРИЦА Q ===
            var lblMatrix = new System.Windows.Forms.Label
            {
                Text = "Матрица интенсивностей Q",
                Location = new System.Drawing.Point(10, 10),
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                AutoSize = true
            };

            this.gridQ = new System.Windows.Forms.DataGridView
            {
                Location = new System.Drawing.Point(10, 40),
                Width = 400,
                Height = 130,
                AllowUserToAddRows = false,
                RowHeadersVisible = true,
                RowHeadersWidth = 120,
                BackgroundColor = System.Drawing.Color.White,
                AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill,
                ScrollBars = System.Windows.Forms.ScrollBars.None
            };
            this.gridQ.ColumnCount = 3;
            this.gridQ.Columns[0].Name = "→ Ясно";
            this.gridQ.Columns[1].Name = "→ Облачно";
            this.gridQ.Columns[2].Name = "→ Пасмурно";
            this.gridQ.Rows.Add(3);
            this.gridQ.Rows[0].HeaderCell.Value = "Из Ясно";
            this.gridQ.Rows[1].HeaderCell.Value = "Из Облачно";
            this.gridQ.Rows[2].HeaderCell.Value = "Из Пасмурно";

            // === РЕЖИМ ===
            var lblMode = new System.Windows.Forms.Label
            {
                Text = "Режим остановки:",
                Location = new System.Drawing.Point(10, 180),
                AutoSize = true
            };

            this.radioByEvents = new System.Windows.Forms.RadioButton
            {
                Text = "По событиям (N)",
                Location = new System.Drawing.Point(10, 200),
                AutoSize = true,
                Checked = true
            };
            this.radioByDays = new System.Windows.Forms.RadioButton
            {
                Text = "По дням (T)",
                Location = new System.Drawing.Point(160, 200),
                AutoSize = true
            };

            // === ПОЛЯ ВВОДА ===
            this.lblEvents = new System.Windows.Forms.Label
            {
                Text = "N (событий):",
                Location = new System.Drawing.Point(10, 230),
                AutoSize = true
            };
            this.numEvents = new System.Windows.Forms.NumericUpDown
            {
                Location = new System.Drawing.Point(110, 227),
                Width = 80,
                Minimum = 100,
                Maximum = 100000,
                Value = 1000,
            };

            this.lblDays = new System.Windows.Forms.Label
            {
                Text = "T (дней):",
                Location = new System.Drawing.Point(10, 230),
                AutoSize = true,
                Visible = false
            };
            this.numDays = new System.Windows.Forms.NumericUpDown
            {
                Location = new System.Drawing.Point(110, 227),
                Width = 80,
                Value = 30,
                Minimum = 1,
                Maximum = 10000,
                Visible = false
            };

            // === СКОРОСТЬ (Подняли чуть выше) ===
            var lblSpeed = new System.Windows.Forms.Label
            {
                Text = "Задержка (мс):",
                Location = new System.Drawing.Point(10, 260),
                AutoSize = true
            };
            this.trackSpeed = new System.Windows.Forms.TrackBar
            {
                Location = new System.Drawing.Point(110, 255),
                Width = 200,
                Minimum = 0,
                Maximum = 500,
                Value = 200,
                TickFrequency = 50
            };
            this.lblSpeedValue = new System.Windows.Forms.Label
            {
                Text = "200 мс",
                Location = new System.Drawing.Point(320, 260),
                AutoSize = true,
                Width = 50
            };

            // === КНОПКИ (Опустили ниже) ===
            this.btnStart = new System.Windows.Forms.Button
            {
                Text = "СТАРТ",
                Location = new System.Drawing.Point(10, 300),
                Size = new System.Drawing.Size(120, 40),
                BackColor = System.Drawing.Color.LightGreen,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            };
            this.btnStop = new System.Windows.Forms.Button
            {
                Text = "СТОП",
                Location = new System.Drawing.Point(140, 300),
                Size = new System.Drawing.Size(120, 40),
                BackColor = System.Drawing.Color.LightCoral,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Enabled = false
            };
            this.btnReset = new System.Windows.Forms.Button
            {
                Text = "СБРОС",
                Location = new System.Drawing.Point(270, 300),
                Size = new System.Drawing.Size(120, 40),
                BackColor = System.Drawing.Color.LightGray
            };

            // === ЛОГ (Опустили ниже) ===
            this.txtLog = new System.Windows.Forms.RichTextBox
            {
                Location = new System.Drawing.Point(10, 355),
                Width = 400,
                Height = 150,
                ReadOnly = true,
                Font = new System.Drawing.Font("Consolas", 8),
                BackColor = System.Drawing.Color.White,
                ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
            };

            // === ПРАВАЯ ЧАСТЬ ===
            this.panelPieChart = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(460, 20),
                Size = new System.Drawing.Size(300, 300),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.White
            };

            // === СТАТИСТИКА (Сдвинули ниже, чтобы влезло 3 строки) ===
            this.lblState = new System.Windows.Forms.Label
            {
                Location = new System.Drawing.Point(460, 330),
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                AutoSize = true
            };
            this.lblTime = new System.Windows.Forms.Label
            {
                Location = new System.Drawing.Point(460, 355),
                AutoSize = true
            };
            this.lblProgress = new System.Windows.Forms.Label
            {
                Location = new System.Drawing.Point(460, 380),
                AutoSize = true
            };
            this.pbProgress = new System.Windows.Forms.ProgressBar
            {
                Location = new System.Drawing.Point(460, 405),
                Size = new System.Drawing.Size(200, 20),
                Minimum = 0,
                Maximum = 100
            };

            this.lblHeaderEmp = new System.Windows.Forms.Label { Text = "Эмп.", Location = new System.Drawing.Point(540, 440), AutoSize = true };
            this.lblHeaderTheor = new System.Windows.Forms.Label { Text = "Теор.", Location = new System.Drawing.Point(590, 440), AutoSize = true };
            this.lblHeaderDiff = new System.Windows.Forms.Label { Text = "Разн.", Location = new System.Drawing.Point(640, 440), AutoSize = true };

            string[] names = { "1 — Ясно", "2 — Облачно", "3 — Пасмурно" };
            for (int i = 0; i < 3; i++)
            {
                var lblName = new System.Windows.Forms.Label
                {
                    Text = names[i],
                    Location = new System.Drawing.Point(460, 465 + i * 30), // Увеличил отступ между строками
                    AutoSize = true
                };
                this.lblEmp[i] = new System.Windows.Forms.Label
                {
                    Location = new System.Drawing.Point(540, 465 + i * 30),
                    Size = new System.Drawing.Size(45, 20),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                };
                this.lblTheor[i] = new System.Windows.Forms.Label
                {
                    Location = new System.Drawing.Point(590, 465 + i * 30),
                    Size = new System.Drawing.Size(45, 20),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                };
                this.lblDiff[i] = new System.Windows.Forms.Label
                {
                    Location = new System.Drawing.Point(640, 465 + i * 30),
                    Size = new System.Drawing.Size(50, 20),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                };
            }

            // === СБОРКА ===
            this.panelLeft.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblMatrix, gridQ, lblMode, radioByEvents, radioByDays,
                lblEvents, numEvents, lblDays, numDays,
                lblSpeed, trackSpeed, lblSpeedValue,
                btnStart, btnStop, btnReset, txtLog
            });

            this.Controls.Add(panelLeft);
            this.Controls.Add(panelPieChart);
            this.Controls.Add(lblState);
            this.Controls.Add(lblTime);
            this.Controls.Add(lblProgress);
            this.Controls.Add(pbProgress);
            this.Controls.Add(lblHeaderEmp);
            this.Controls.Add(lblHeaderTheor);
            this.Controls.Add(lblHeaderDiff);
            for (int i = 0; i < 3; i++)
            {
                this.Controls.Add(new System.Windows.Forms.Label
                {
                    Text = names[i],
                    Location = new System.Drawing.Point(460, 465 + i * 30),
                    AutoSize = true
                });
                this.Controls.Add(lblEmp[i]);
                this.Controls.Add(lblTheor[i]);
                this.Controls.Add(lblDiff[i]);
            }

            // УВЕЛИЧИЛ ВЫСОТУ ОКНА ДО 620
            this.Text = "Марковская модель погоды (CTMC)";
            this.Size = new System.Drawing.Size(800, 620);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
    }
}