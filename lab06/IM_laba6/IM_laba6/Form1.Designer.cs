namespace IM_laba6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblProb1 = new System.Windows.Forms.Label();
            this.txtProb1 = new System.Windows.Forms.TextBox();
            this.lblProb2 = new System.Windows.Forms.Label();
            this.txtProb2 = new System.Windows.Forms.TextBox();
            this.lblProb3 = new System.Windows.Forms.Label();
            this.txtProb3 = new System.Windows.Forms.TextBox();
            this.lblProb4 = new System.Windows.Forms.Label();
            this.txtProb4 = new System.Windows.Forms.TextBox();
            this.lblProb5 = new System.Windows.Forms.Label();
            this.txtProb5 = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblVariance = new System.Windows.Forms.Label();
            this.lblChiSquared = new System.Windows.Forms.Label();
            this.histogramPanel = new HistogramPanel();
            this.SuspendLayout();

            // lblProb1
            this.lblProb1.AutoSize = true;
            this.lblProb1.Location = new System.Drawing.Point(20, 20);
            this.lblProb1.Name = "lblProb1";
            this.lblProb1.Size = new System.Drawing.Size(47, 15);
            this.lblProb1.Text = "Prob 1";

            // txtProb1
            this.txtProb1.Location = new System.Drawing.Point(100, 17);
            this.txtProb1.Name = "txtProb1";
            this.txtProb1.Size = new System.Drawing.Size(60, 23);
            this.txtProb1.Text = "0.1";

            // lblProb2
            this.lblProb2.AutoSize = true;
            this.lblProb2.Location = new System.Drawing.Point(20, 50);
            this.lblProb2.Name = "lblProb2";
            this.lblProb2.Size = new System.Drawing.Size(47, 15);
            this.lblProb2.Text = "Prob 2";

            // txtProb2
            this.txtProb2.Location = new System.Drawing.Point(100, 47);
            this.txtProb2.Name = "txtProb2";
            this.txtProb2.Size = new System.Drawing.Size(60, 23);
            this.txtProb2.Text = "0.2";

            // lblProb3
            this.lblProb3.AutoSize = true;
            this.lblProb3.Location = new System.Drawing.Point(20, 80);
            this.lblProb3.Name = "lblProb3";
            this.lblProb3.Size = new System.Drawing.Size(47, 15);
            this.lblProb3.Text = "Prob 3";

            // txtProb3
            this.txtProb3.Location = new System.Drawing.Point(100, 77);
            this.txtProb3.Name = "txtProb3";
            this.txtProb3.Size = new System.Drawing.Size(60, 23);
            this.txtProb3.Text = "0.3";

            // lblProb4
            this.lblProb4.AutoSize = true;
            this.lblProb4.Location = new System.Drawing.Point(20, 110);
            this.lblProb4.Name = "lblProb4";
            this.lblProb4.Size = new System.Drawing.Size(47, 15);
            this.lblProb4.Text = "Prob 4";

            // txtProb4
            this.txtProb4.Location = new System.Drawing.Point(100, 107);
            this.txtProb4.Name = "txtProb4";
            this.txtProb4.Size = new System.Drawing.Size(60, 23);
            this.txtProb4.Text = "0.25";

            // lblProb5
            this.lblProb5.AutoSize = true;
            this.lblProb5.Location = new System.Drawing.Point(20, 140);
            this.lblProb5.Name = "lblProb5";
            this.lblProb5.Size = new System.Drawing.Size(47, 15);
            this.lblProb5.Text = "Prob 5";

            // txtProb5
            this.txtProb5.Location = new System.Drawing.Point(100, 137);
            this.txtProb5.Name = "txtProb5";
            this.txtProb5.Size = new System.Drawing.Size(60, 23);
            this.txtProb5.Text = "auto";

            // lblNumber
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(20, 180);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(134, 15);
            this.lblNumber.Text = "Number of experiments";

            // txtNumber
            this.txtNumber.Location = new System.Drawing.Point(160, 177);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(60, 23);
            this.txtNumber.Text = "1000";

            // btnStart
            this.btnStart.Location = new System.Drawing.Point(80, 220);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 30);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);

            // lblAverage
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(300, 20);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAverage.Size = new System.Drawing.Size(0, 17);

            // lblVariance
            this.lblVariance.AutoSize = true;
            this.lblVariance.Location = new System.Drawing.Point(300, 50);
            this.lblVariance.Name = "lblVariance";
            this.lblVariance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblVariance.Size = new System.Drawing.Size(0, 17);

            // lblChiSquared
            this.lblChiSquared.AutoSize = true;
            this.lblChiSquared.Location = new System.Drawing.Point(300, 80);
            this.lblChiSquared.Name = "lblChiSquared";
            this.lblChiSquared.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblChiSquared.Size = new System.Drawing.Size(0, 17);

            // histogramPanel
            this.histogramPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramPanel.Location = new System.Drawing.Point(300, 120);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(500, 250);
            this.histogramPanel.TabIndex = 11;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 400);
            this.Controls.Add(this.lblProb1);
            this.Controls.Add(this.txtProb1);
            this.Controls.Add(this.lblProb2);
            this.Controls.Add(this.txtProb2);
            this.Controls.Add(this.lblProb3);
            this.Controls.Add(this.txtProb3);
            this.Controls.Add(this.lblProb4);
            this.Controls.Add(this.txtProb4);
            this.Controls.Add(this.lblProb5);
            this.Controls.Add(this.txtProb5);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.lblVariance);
            this.Controls.Add(this.lblChiSquared);
            this.Controls.Add(this.histogramPanel);
            this.Name = "Form1";
            this.Text = "Discrete Random Variable Experiment";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblProb1;
        private System.Windows.Forms.TextBox txtProb1;
        private System.Windows.Forms.Label lblProb2;
        private System.Windows.Forms.TextBox txtProb2;
        private System.Windows.Forms.Label lblProb3;
        private System.Windows.Forms.TextBox txtProb3;
        private System.Windows.Forms.Label lblProb4;
        private System.Windows.Forms.TextBox txtProb4;
        private System.Windows.Forms.Label lblProb5;
        private System.Windows.Forms.TextBox txtProb5;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label lblVariance;
        private System.Windows.Forms.Label lblChiSquared;
        private HistogramPanel histogramPanel;
    }
}