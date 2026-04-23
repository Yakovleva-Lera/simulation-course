using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace IM_laba6
{
    public class HistogramPanel : Panel
    {
        private double[] theoreticalProbs = new double[5];
        private double[] empiricalProbs = new double[5];

        public void UpdateHistogram(double[] theoretical, double[] empirical)
        {
            theoreticalProbs = (double[])theoretical.Clone();
            empiricalProbs = (double[])empirical.Clone();
            this.Invalidate(); // Перерисовать панель
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawHistogram(e.Graphics);
        }

        private void DrawHistogram(Graphics g)
        {
            g.Clear(Color.White);

            Rectangle rect = this.ClientRectangle;

            int barWidth = 50;
            int spacing = 50;
            int startX = 60;
            int maxY = rect.Height - 40;
            int minY = 20;
            int chartHeight = maxY - minY;

            Pen axisPen = new Pen(Color.Black, 2);
            g.DrawLine(axisPen, 40, minY, 40, maxY);
            g.DrawLine(axisPen, 40, maxY, rect.Width - 10, maxY);

            g.DrawString("freq.", new Font("Arial", 8), Brushes.Black, 45, 5);

            g.DrawString("0.3", new Font("Arial", 7), Brushes.Gray, 5, minY);
            g.DrawString("0.2", new Font("Arial", 7), Brushes.Gray, 5, minY + chartHeight / 3);
            g.DrawString("0.1", new Font("Arial", 7), Brushes.Gray, 5, minY + 2 * chartHeight / 3);
            g.DrawString("0", new Font("Arial", 7), Brushes.Gray, 20, maxY);

            for (int i = 0; i < 5; i++)
            {
                int x = startX + i * (barWidth + spacing);

                int theoHeight = (int)(theoreticalProbs[i] * chartHeight);
                Rectangle theoRect = new Rectangle(x, maxY - theoHeight, barWidth / 2 - 5, theoHeight);
                g.DrawRectangle(Pens.Blue, theoRect);

                int empHeight = (int)(empiricalProbs[i] * chartHeight);
                Rectangle empRect = new Rectangle(x + barWidth / 2 - 5, maxY - empHeight, barWidth / 2 - 5, empHeight);
                g.FillRectangle(Brushes.LightBlue, empRect);
                g.DrawRectangle(Pens.DarkBlue, empRect);

                string empValue = empiricalProbs[i].ToString("F3", CultureInfo.InvariantCulture);
                SizeF textSize = g.MeasureString(empValue, new Font("Arial", 7));
                g.DrawString(empValue, new Font("Arial", 7), Brushes.Black, x + barWidth / 4 - textSize.Width / 2, maxY - empHeight - 15);

                g.DrawString((i + 1).ToString(), new Font("Arial", 8), Brushes.Black, x + barWidth / 4 - 3, maxY + 5);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }
    }
}