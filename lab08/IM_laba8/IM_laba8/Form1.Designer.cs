namespace IM_laba8
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            numLambda = new NumericUpDown();
            numTime = new NumericUpDown();
            numN = new NumericUpDown();
            btnCalculate = new Button();
            dgvResults = new DataGridView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblMean = new Label();
            lblVar = new Label();
            ((System.ComponentModel.ISupportInitialize)numLambda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // numLambda
            // 
            numLambda.Location = new Point(130, 28);
            numLambda.Name = "numLambda";
            numLambda.Size = new Size(100, 27);
            numLambda.TabIndex = 0;
            numLambda.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // numTime
            // 
            numTime.Location = new Point(130, 68);
            numTime.Name = "numTime";
            numTime.Size = new Size(100, 27);
            numTime.TabIndex = 1;
            numTime.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // numN
            // 
            numN.Location = new Point(130, 108);
            numN.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numN.Name = "numN";
            numN.Size = new Size(100, 27);
            numN.TabIndex = 2;
            numN.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(15, 140);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(215, 30);
            btnCalculate.TabIndex = 3;
            btnCalculate.Text = "Запуск";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // dgvResults
            // 
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(20, 210);
            dgvResults.Name = "dgvResults";
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new Size(250, 250);
            dgvResults.TabIndex = 4;
            // 
            // chart1
            // 
            chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(300, 20);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(650, 560);
            chart1.TabIndex = 5;
            chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnCalculate);
            groupBox1.Controls.Add(numLambda);
            groupBox1.Controls.Add(numTime);
            groupBox1.Controls.Add(numN);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 180);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Параметры";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 110);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 5;
            label3.Text = "Опытов N";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 70);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 4;
            label2.Text = "Время Т";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 30);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 3;
            label1.Text = "Лямбда";
            // 
            // lblMean
            // 
            lblMean.AutoSize = true;
            lblMean.Location = new Point(20, 470);
            lblMean.Name = "lblMean";
            lblMean.Size = new Size(108, 20);
            lblMean.TabIndex = 7;
            lblMean.Text = "Среднее (М): -";
            // 
            // lblVar
            // 
            lblVar.AutoSize = true;
            lblVar.Location = new Point(20, 490);
            lblVar.Name = "lblVar";
            lblVar.Size = new Size(123, 20);
            lblVar.TabIndex = 8;
            lblVar.Text = "Дисперсия (D): -";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(lblVar);
            Controls.Add(lblMean);
            Controls.Add(groupBox1);
            Controls.Add(chart1);
            Controls.Add(dgvResults);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numLambda).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)numN).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numLambda;
        private NumericUpDown numTime;
        private NumericUpDown numN;
        private Button btnCalculate;
        private DataGridView dgvResults;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblMean;
        private Label lblVar;
    }
}
