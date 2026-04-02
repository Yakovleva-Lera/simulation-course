namespace SimulationLab
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.txtQuestion1 = new System.Windows.Forms.TextBox();
            this.btnAnswer1 = new System.Windows.Forms.Button();
            this.lblResult1 = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblQuestion2 = new System.Windows.Forms.Label();
            this.btnAnswer2 = new System.Windows.Forms.Button();
            this.lblResult2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle1.Location = new System.Drawing.Point(22, 20);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(340, 19);
            this.lblTitle1.TabIndex = 0;
            this.lblTitle1.Text = "🔮 Приложение 1: Скажи \"да\" или \"нет\"";
            // 
            // txtQuestion1
            // 
            this.txtQuestion1.Location = new System.Drawing.Point(25, 50);
            this.txtQuestion1.Name = "txtQuestion1";
            this.txtQuestion1.PlaceholderText = "Введите ваш вопрос...";
            this.txtQuestion1.Size = new System.Drawing.Size(450, 23);
            this.txtQuestion1.TabIndex = 1;
            // 
            // btnAnswer1
            // 
            this.btnAnswer1.BackColor = System.Drawing.Color.LightBlue;
            this.btnAnswer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer1.Location = new System.Drawing.Point(25, 85);
            this.btnAnswer1.Name = "btnAnswer1";
            this.btnAnswer1.Size = new System.Drawing.Size(130, 32);
            this.btnAnswer1.TabIndex = 2;
            this.btnAnswer1.Text = "Получить ответ";
            this.btnAnswer1.UseVisualStyleBackColor = false;
            this.btnAnswer1.Click += new System.EventHandler(this.btnAnswer1_Click);
            // 
            // lblResult1
            // 
            this.lblResult1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResult1.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblResult1.Location = new System.Drawing.Point(162, 92);
            this.lblResult1.Name = "lblResult1";
            this.lblResult1.Size = new System.Drawing.Size(300, 25);
            this.lblResult1.TabIndex = 3;
            this.lblResult1.Text = "";
            // 
            // separator
            // 
            this.separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator.Location = new System.Drawing.Point(25, 130);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(450, 2);
            this.separator.TabIndex = 4;
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle2.Location = new System.Drawing.Point(22, 150);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(275, 19);
            this.lblTitle2.TabIndex = 5;
            this.lblTitle2.Text = "🎱 Приложение 2: Шар предсказаний";
            // 
            // lblQuestion2
            // 
            this.lblQuestion2.AutoSize = true;
            this.lblQuestion2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuestion2.Location = new System.Drawing.Point(24, 180);
            this.lblQuestion2.Name = "lblQuestion2";
            this.lblQuestion2.Size = new System.Drawing.Size(245, 15);
            this.lblQuestion2.TabIndex = 6;
            this.lblQuestion2.Text = "Кто ты из Гарри Поттера сегодня?";
            // 
            // btnAnswer2
            // 
            this.btnAnswer2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnAnswer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer2.Location = new System.Drawing.Point(25, 210);
            this.btnAnswer2.Name = "btnAnswer2";
            this.btnAnswer2.Size = new System.Drawing.Size(140, 32);
            this.btnAnswer2.TabIndex = 7;
            this.btnAnswer2.Text = "Узнать персонажа";
            this.btnAnswer2.UseVisualStyleBackColor = false;
            this.btnAnswer2.Click += new System.EventHandler(this.btnAnswer2_Click);
            // 
            // lblResult2
            // 
            this.lblResult2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResult2.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblResult2.Location = new System.Drawing.Point(172, 217);
            this.lblResult2.Name = "lblResult2";
            this.lblResult2.Size = new System.Drawing.Size(300, 25);
            this.lblResult2.TabIndex = 8;
            this.lblResult2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 280);
            this.Controls.Add(this.lblResult2);
            this.Controls.Add(this.btnAnswer2);
            this.Controls.Add(this.lblQuestion2);
            this.Controls.Add(this.lblTitle2);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.lblResult1);
            this.Controls.Add(this.btnAnswer1);
            this.Controls.Add(this.txtQuestion1);
            this.Controls.Add(this.lblTitle1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Имитационное моделирование: Случайные события";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.TextBox txtQuestion1;
        private System.Windows.Forms.Button btnAnswer1;
        private System.Windows.Forms.Label lblResult1;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblQuestion2;
        private System.Windows.Forms.Button btnAnswer2;
        private System.Windows.Forms.Label lblResult2;
    }
}