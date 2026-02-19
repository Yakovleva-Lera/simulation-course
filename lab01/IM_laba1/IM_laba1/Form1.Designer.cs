namespace IM_laba1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox1 = new GroupBox();
            step = new TextBox();
            mass = new TextBox();
            square = new TextBox();
            alph = new TextBox();
            height = new TextBox();
            speed = new TextBox();
            label6 = new Label();
            label7 = new Label();
            maxHeight = new Label();
            label8 = new Label();
            maxLenght = new Label();
            label10 = new Label();
            vLast = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 30);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 0;
            label1.Text = "Нач. скорость";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 78);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 1;
            label2.Text = "Нач. высота";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 82);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 5;
            label3.Text = "Площадь п.с.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(342, 30);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 4;
            label4.Text = "Угол";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(647, 30);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 9;
            label5.Text = "Масса";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(915, 11);
            button1.Name = "button1";
            button1.Size = new Size(94, 114);
            button1.TabIndex = 12;
            button1.Text = "Пуск";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // chart1
            // 
            chart1.BorderlineWidth = 7;
            chartArea1.AxisX.Maximum = 15D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(0, 131);
            chart1.Name = "chart1";
            chart1.Size = new Size(1059, 366);
            chart1.TabIndex = 13;
            chart1.Text = "chart1";
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(step);
            groupBox1.Controls.Add(mass);
            groupBox1.Controls.Add(square);
            groupBox1.Controls.Add(alph);
            groupBox1.Controls.Add(height);
            groupBox1.Controls.Add(speed);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1059, 125);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // step
            // 
            step.Location = new Point(740, 79);
            step.Name = "step";
            step.Size = new Size(125, 27);
            step.TabIndex = 18;
            step.Text = "0,1";
            // 
            // mass
            // 
            mass.Location = new Point(740, 27);
            mass.Name = "mass";
            mass.Size = new Size(125, 27);
            mass.TabIndex = 17;
            mass.Text = "2";
            // 
            // square
            // 
            square.Location = new Point(479, 79);
            square.Name = "square";
            square.Size = new Size(125, 27);
            square.TabIndex = 16;
            square.Text = "1";
            // 
            // alph
            // 
            alph.Location = new Point(479, 27);
            alph.Name = "alph";
            alph.Size = new Size(125, 27);
            alph.TabIndex = 15;
            alph.Text = "45";
            // 
            // height
            // 
            height.Location = new Point(156, 75);
            height.Name = "height";
            height.Size = new Size(125, 27);
            height.TabIndex = 14;
            height.Text = "2";
            // 
            // speed
            // 
            speed.Location = new Point(156, 27);
            speed.Name = "speed";
            speed.Size = new Size(125, 27);
            speed.TabIndex = 13;
            speed.Text = "15";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(647, 85);
            label6.Name = "label6";
            label6.Size = new Size(37, 20);
            label6.TabIndex = 12;
            label6.Text = "Шаг";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 520);
            label7.Name = "label7";
            label7.Size = new Size(100, 20);
            label7.TabIndex = 15;
            label7.Text = "Макс. высота";
            // 
            // maxHeight
            // 
            maxHeight.AutoSize = true;
            maxHeight.Location = new Point(171, 520);
            maxHeight.Name = "maxHeight";
            maxHeight.Size = new Size(17, 20);
            maxHeight.TabIndex = 16;
            maxHeight.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(370, 520);
            label8.Name = "label8";
            label8.Size = new Size(82, 20);
            label8.TabIndex = 17;
            label8.Text = "Дальность";
            // 
            // maxLenght
            // 
            maxLenght.AutoSize = true;
            maxLenght.Location = new Point(516, 520);
            maxLenght.Name = "maxLenght";
            maxLenght.Size = new Size(17, 20);
            maxLenght.TabIndex = 18;
            maxLenght.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(740, 520);
            label10.Name = "label10";
            label10.Size = new Size(126, 20);
            label10.TabIndex = 19;
            label10.Text = "Скорость в кон.т.";
            // 
            // vLast
            // 
            vLast.AutoSize = true;
            vLast.Location = new Point(890, 520);
            vLast.Name = "vLast";
            vLast.Size = new Size(17, 20);
            vLast.TabIndex = 20;
            vLast.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 557);
            Controls.Add(vLast);
            Controls.Add(label10);
            Controls.Add(maxLenght);
            Controls.Add(label8);
            Controls.Add(maxHeight);
            Controls.Add(label7);
            Controls.Add(groupBox1);
            Controls.Add(chart1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox square;
        private TextBox alph;
        private TextBox height;
        private TextBox speed;
        private TextBox step;
        private TextBox mass;
        private Label label7;
        private Label maxHeight;
        private Label label8;
        private Label maxLenght;
        private Label label10;
        private Label vLast;
    }
}
