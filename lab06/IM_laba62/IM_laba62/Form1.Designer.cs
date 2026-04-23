using IM_laba62;

namespace IM_laba62
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMean = new System.Windows.Forms.Label();
            this.txtMean = new System.Windows.Forms.TextBox();
            this.lblStdDev = new System.Windows.Forms.Label();
            this.txtStdDev = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblVariance = new System.Windows.Forms.Label();
            this.lblChiSquared = new System.Windows.Forms.Label();
            this.histogramPanel = new HistogramPanel();
            this.SuspendLayout();

            // lblMean
            this.lblMean.AutoSize = true;
            this.lblMean.Location = new System.Drawing.Point(20, 20);
            this.lblMean.Name = "lblMean";
            this.lblMean.Size = new System.Drawing.Size(34, 15);
            this.lblMean.Text = "Mean";
            // txtMean
            this.txtMean.Location = new System.Drawing.Point(100, 17);
            this.txtMean.Name = "txtMean";
            this.txtMean.Size = new System.Drawing.Size(60, 23);
            this.txtMean.Text = "0";

            // lblStdDev
            this.lblStdDev.AutoSize = true;
            this.lblStdDev.Location = new System.Drawing.Point(20, 50);
            this.lblStdDev.Name = "lblStdDev";
            this.lblStdDev.Size = new System.Drawing.Size(53, 15);
            this.lblStdDev.Text = "Std Dev";
            // txtStdDev
            this.txtStdDev.Location = new System.Drawing.Point(100, 47);
            this.txtStdDev.Name = "txtStdDev";
            this.txtStdDev.Size = new System.Drawing.Size(60, 23);
            this.txtStdDev.Text = "1";

            // lblNumber
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(20, 80);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(16, 15);
            this.lblNumber.Text = "N";
            // txtNumber
            this.txtNumber.Location = new System.Drawing.Point(100, 77);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(60, 23);
            this.txtNumber.Text = "1000";

            // btnStart
            this.btnStart.Location = new System.Drawing.Point(80, 120);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 30);
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);

            // Results labels
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(300, 20);
            this.lblAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblVariance.AutoSize = true;
            this.lblVariance.Location = new System.Drawing.Point(300, 50);
            this.lblVariance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblChiSquared.AutoSize = true;
            this.lblChiSquared.Location = new System.Drawing.Point(300, 80);
            this.lblChiSquared.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);

            // Histogram panel
            this.histogramPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramPanel.Location = new System.Drawing.Point(300, 120);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(500, 250);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 400);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMean, this.txtMean, this.lblStdDev, this.txtStdDev,
                this.lblNumber, this.txtNumber, this.btnStart,
                this.lblAverage, this.lblVariance, this.lblChiSquared,
                this.histogramPanel});
            this.Name = "Form1";
            this.Text = "Normal Random Variable Simulation";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMean, lblStdDev, lblNumber;
        private System.Windows.Forms.TextBox txtMean, txtStdDev, txtNumber;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblAverage, lblVariance, lblChiSquared;
        private HistogramPanel histogramPanel;
    }
}