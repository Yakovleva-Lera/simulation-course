using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace IM_laba62
{
    public class HistogramPanel : Panel
    {
        private double[] values;
        private double mean, stdDev;

        public void UpdateHistogram(double[] values, double mean, double stdDev)
        {
            this.values = values;
            this.mean = mean;
            this.stdDev = stdDev;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (values == null || values.Length == 0) return;
            DrawHistogram(e.Graphics);
        }

        // === ОСНОВНОЙ МЕТОД ОТРИСОВКИ ГИСТОГРАММЫ ===
        private void DrawHistogram(Graphics g)
        {
            g.Clear(Color.White);
            Rectangle rect = this.ClientRectangle;

            // === БЛОК 1: НАСТРОЙКА ИНТЕРВАЛОВ (7 интервалов по заданию) ===
            int k = 7;

            // === БЛОК 2: ДИНАМИЧЕСКИЕ ГРАНИЦЫ (на основе μ и σ) ===
            // Интервал [μ-3.5σ, μ+3.5σ] охватывает ~99.9% значений
            double min = mean - 3.5 * stdDev;
            double max = mean + 3.5 * stdDev;
            double binWidth = (max - min) / k;

            // Подсчёт частот по интервалам
            int[] freq = new int[k];
            foreach (double v in values)
            {
                if (v >= min && v < max)
                {
                    int bin = (int)((v - min) / binWidth);
                    if (bin >= k) bin = k - 1;
                    if (bin >= 0) freq[bin]++;
                }
            }

            // === БЛОК 3: НАСТРОЙКА ОБЛАСТИ ОТРИСОВКИ ===
            int leftMargin = 60;
            int rightMargin = 30;
            int topMargin = 40;
            int bottomMargin = 50;

            int minX = leftMargin;
            int maxX = rect.Width - rightMargin;
            int minY = topMargin;
            int maxY = rect.Height - bottomMargin;
            int chartW = maxX - minX;
            int chartH = maxY - minY;

            // === БЛОК 4: ОТРИСОВКА ОСЕЙ КООРДИНАТ ===
            Pen axisPen = new Pen(Color.Black, 2);
            g.DrawLine(axisPen, minX, minY, minX, maxY); // Вертикальная ось Y
            g.DrawLine(axisPen, minX, maxY, maxX, maxY); // Горизонтальная ось X

            // === БЛОК 5: ОТРИСОВКА ЗАГОЛОВКА И ПОДПИСЕЙ ===

            // 5.1. Заголовок с параметрами (по центру)
            string title = $"μ={mean:F1}, σ={stdDev:F1}, N={values.Length}";
            SizeF titleSize = g.MeasureString(title, new Font("Arial", 10, FontStyle.Bold));
            float titleX = minX + (chartW - titleSize.Width) / 2;
            g.DrawString(title, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, titleX, minY - 25);

            // 5.2. Подпись оси Y
            g.DrawString("Frequency", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5, minY - 15);

            // 5.3. Деления и значения на оси Y
            int maxFreq = 1;
            foreach (int f in freq) if (f > maxFreq) maxFreq = f;
            maxFreq = (int)(maxFreq * 1.1);

            for (int i = 0; i <= 4; i++)
            {
                int val = maxFreq * i / 4;
                int y = maxY - (i * chartH / 4);
                string label = val.ToString();
                SizeF labelSize = g.MeasureString(label, new Font("Arial", 7));
                g.DrawString(label, new Font("Arial", 7), Brushes.Gray, minX - labelSize.Width - 5, y - 6);
                g.DrawLine(Pens.LightGray, minX - 5, y, minX, y);
            }

            // 5.4. Деления и значения на оси X (динамические границы интервалов)
            for (int i = 0; i <= k; i++)
            {
                double val = min + i * binWidth;
                int x = minX + i * chartW / k;
                string label = val.ToString("F1", CultureInfo.InvariantCulture);
                SizeF labelSize = g.MeasureString(label, new Font("Arial", 7));
                g.DrawString(label, new Font("Arial", 7), Brushes.Gray, x - labelSize.Width / 2, maxY + 5);
                g.DrawLine(Pens.LightGray, x, maxY, x, maxY + 5);
            }
            g.DrawString("Value", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, maxX - 40, maxY + 25);

            // === БЛОК 6: ОТРИСОВКА СТОЛБЦОВ ГИСТОГРАММЫ ===
            int barW = chartW / k;
            for (int i = 0; i < k; i++)
            {
                int h = freq[i] * chartH / maxFreq;
                int x = minX + i * barW;
                int y = maxY - h;
                Rectangle bar = new Rectangle(x + 2, y, barW - 4, h);
                g.FillRectangle(Brushes.LightBlue, bar);
                g.DrawRectangle(Pens.Blue, bar);

                // Частота над столбцом
                if (freq[i] > 0)
                {
                    string freqLabel = freq[i].ToString();
                    SizeF textSize = g.MeasureString(freqLabel, new Font("Arial", 7));
                    g.DrawString(freqLabel, new Font("Arial", 7), Brushes.DarkBlue,
                        x + barW / 2 - textSize.Width / 2, y - 15);
                }
            }

            // === БЛОК 7: ОТРИСОВКА ТЕОРЕТИЧЕСКОЙ КРИВОЙ (нормальное распределение) ===
            Pen curvePen = new Pen(Color.Red, 2);
            int pointsCount = 200;
            PointF[] pts = new PointF[pointsCount];
            double scale = values.Length * binWidth;

            for (int i = 0; i < pointsCount; i++)
            {
                double xv = min + i * (max - min) / (pointsCount - 1);
                double pdf = NormalPDF(xv, mean, stdDev);
                float xp = minX + i * chartW / (pointsCount - 1f);
                float yp = maxY - (float)(pdf * scale * chartH / maxFreq);

                if (yp < minY + 5) yp = minY + 5;
                if (yp > maxY) yp = maxY;

                pts[i] = new PointF(xp, yp);
            }
            g.DrawCurve(curvePen, pts);
        }

        // === ВСПОМОГАТЕЛЬНЫЙ МЕТОД: Функция плотности нормального распределения ===
        private double NormalPDF(double x, double mean, double stdDev)
        {
            double coef = 1.0 / (stdDev * Math.Sqrt(2 * Math.PI));
            return coef * Math.Exp(-Math.Pow(x - mean, 2) / (2 * stdDev * stdDev));
        }
    }
}