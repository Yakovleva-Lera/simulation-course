using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IM_laba8
{
    public class MultiplicativeCongruentialGenerator
    {
        private const long M = 2147483647;
        private const long BETA = 48271;
        private long x;

        public MultiplicativeCongruentialGenerator(long seed = 10)
        {
            x = seed;
        }

        public double Next()
        {
            x = (x * BETA) % M;
            return (double)x / (double)M;
        }
    }

    public partial class Form1 : Form
    {
        MultiplicativeCongruentialGenerator mcGen = new MultiplicativeCongruentialGenerator();

        public Form1()
        {
            InitializeComponent();
            SetupChart();
        }

        private void SetupChart()
        {
            chart1.Series.Clear();
            chart1.Legends[0].Enabled = false;

            var series = chart1.Series.Add("Эмпирическое распределение");
            series.ChartType = SeriesChartType.Column;
            chart1.ChartAreas[0].AxisX.Title = "Число событий (i)";
            chart1.ChartAreas[0].AxisY.Title = "Вероятность (частота)";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Параметры
            double lambda = (double)numLambda.Value;
            double T = (double)numTime.Value;
            int N = (int)numN.Value;

            //Ключ - число событий, значение - сколько раз встретилось
            Dictionary<int, int> frequencies = new Dictionary<int, int>();

            //Моделирование потока
            for (int k = 0; k < N; k++)
            {
                int eventsCount = SimulatePoisson(lambda, T);

                if (frequencies.ContainsKey(eventsCount))
                    frequencies[eventsCount]++;
                else
                    frequencies[eventsCount] = 1;
            }

            //Обработка и вывод результатов
            UpdateUI(frequencies, N, lambda, T);
        }

        //Моделирование одного интервала T
        private int SimulatePoisson(double lambda, double T)
        {
            double currentTime = 0;
            int count = 0;
            while (true)
            {
                double u = mcGen.Next();

                if (u <= 0) u = 0.0000000001;

                double dt = -Math.Log(u) / lambda;
                currentTime += dt;

                if (currentTime <= T) count++;
                else break;
            }
            return count;
        }

        private void UpdateUI(Dictionary<int, int> freq, int N, double lambda, double T)
        {
            //Очистка старых данных
            chart1.Series[0].Points.Clear();
            dgvResults.Rows.Clear();
            if (dgvResults.Columns.Count == 0)
            {
                dgvResults.Columns.Add("i", "Число событий (i)");
                dgvResults.Columns.Add("p", "Частота (Freq/N)");
            }

            double mean = 0;
            double variance = 0;

            //Максимальное число заявок
            int maxEvents = freq.Keys.Count > 0 ? freq.Keys.Max() : 0;

            for (int i = 0; i <= maxEvents; i++)
            {
                int count = freq.ContainsKey(i) ? freq[i] : 0;
                double probability = (double)count / N;

                dgvResults.Rows.Add(i, probability.ToString("F4"));

                chart1.Series[0].Points.AddXY(i, probability);

                mean += i * probability;
            }

            //Расчет дисперсии
            for (int i = 0; i <= maxEvents; i++)
            {
                int count = freq.ContainsKey(i) ? freq[i] : 0;
                double probability = (double)count / N;
                variance += Math.Pow(i, 2) * probability;
            }
            variance -= Math.Pow(mean, 2);

            //Вывод результатов
            lblMean.Text = $"Среднее (M): {mean:F3}";
            lblVar.Text = $"Дисперсия (D): {variance:F3}";
        }
    }
}