using System.Globalization;

using System;
using System.Windows.Forms;
using System.Globalization;

namespace IM_laba62
{
    public partial class Form1 : Form
    {
        private readonly MultiplicativeCongruentialGenerator generator;

        public Form1()
        {
            InitializeComponent();
            generator = new MultiplicativeCongruentialGenerator(52);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // === ЧТЕНИЕ ВХОДНЫХ ДАННЫХ ===
                double mean = double.Parse(txtMean.Text, CultureInfo.InvariantCulture);
                double stdDev = double.Parse(txtStdDev.Text, CultureInfo.InvariantCulture);
                int n = int.Parse(txtNumber.Text, CultureInfo.InvariantCulture);

                // === БЛОК 1: ГЕНЕРАЦИЯ НОРМАЛЬНОЙ СЛУЧАЙНОЙ ВЕЛИЧИНЫ ===
                // Метод: преобразование Бокса-Мюллера
                double[] values = new double[n];
                for (int i = 0; i < n; i++)
                    values[i] = GenerateNormal(mean, stdDev);

                // === БЛОК 2: ВЫЧИСЛЕНИЕ ВЫБОРОРОЧНЫХ ХАРАКТЕРИСТИК ===
                // 2.1. Выборочное среднее (математическое ожидание)
                double sampleMean = 0, sampleVar = 0;
                foreach (double v in values) sampleMean += v;
                sampleMean /= n;

                // 2.2. Выборочная дисперсия (несмещённая оценка, n-1)
                foreach (double v in values) sampleVar += Math.Pow(v - sampleMean, 2);
                sampleVar /= (n - 1);

                double theoreticalVar = stdDev * stdDev;

                // === БЛОК 3: ОЦЕНКА ТОЧНОСТИ (ОТНОСИТЕЛЬНЫЕ ПОГРЕШНОСТИ) ===
                // 3.1. Погрешность математического ожидания
                double meanError = mean != 0 ? Math.Abs(sampleMean - mean) / Math.Abs(mean) * 100 : 0;

                // 3.2. Погрешность дисперсии
                double varError = theoreticalVar != 0 ? Math.Abs(sampleVar - theoreticalVar) / theoreticalVar * 100 : 0;

                // === БЛОК 4: КРИТЕРИЙ СОГЛАСИЯ ХИ-КВАДРАТ ===
                // Проверка гипотезы о нормальности распределения
                double chiSquared = CalculateChiSquared(values, mean, stdDev, n);
                double chiCritical = 14.067; // Критическое значение (7 степеней свободы, α=0.05)

                // === ВЫВОД РЕЗУЛЬТАТОВ ===
                lblAverage.Text = $"Mean: {sampleMean:F3} (error = {meanError:F1}%)";
                lblVariance.Text = $"Variance: {sampleVar:F3} (error = {varError:F1}%)";
                lblChiSquared.Text = $"Chi-squared: {chiSquared:F2} < {chiCritical:F2} ? {(chiSquared <= chiCritical ? "accept" : "reject")}";

                // Обновление гистограммы
                histogramPanel.UpdateHistogram(values, mean, stdDev);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // === МЕТОД: Генерация нормального распределения (Бокс-Мюллер) ===
        private double GenerateNormal(double mean, double stdDev)
        {
            double u1 = generator.Next();
            double u2 = generator.Next();
            double z = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
            return mean + stdDev * z;
        }

        // === МЕТОД: Расчёт статистики хи-квадрат ===
        private double CalculateChiSquared(double[] values, double mean, double stdDev, int n)
        {
            int k = 10; // Число интервалов для χ²-теста
            double min = mean - 4 * stdDev;
            double max = mean + 4 * stdDev;
            double binWidth = (max - min) / k;
            int[] observed = new int[k];

            // Подсчёт наблюдаемых частот
            foreach (double v in values)
            {
                if (v >= min && v < max)
                {
                    int bin = (int)((v - min) / binWidth);
                    if (bin >= k) bin = k - 1;
                    if (bin >= 0) observed[bin]++;
                }
            }

            // Расчёт статистики χ²
            double chiSquared = 0;
            for (int i = 0; i < k; i++)
            {
                double left = min + i * binWidth;
                double right = left + binWidth;
                double p = NormalCDF(right, mean, stdDev) - NormalCDF(left, mean, stdDev);
                double expected = n * p;
                if (expected > 0)
                    chiSquared += Math.Pow(observed[i] - expected, 2) / expected;
            }
            return chiSquared;
        }

        // === ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ (функция распределения и ошибка) ===
        private double NormalCDF(double x, double mean, double stdDev)
        {
            return 0.5 * (1 + Erf((x - mean) / (stdDev * Math.Sqrt(2))));
        }

        private double Erf(double x)
        {
            double a1 = 0.254829592, a2 = -0.284496736, a3 = 1.421413741;
            double a4 = -1.453152027, a5 = 1.061405429, p = 0.3275911;
            int sign = x < 0 ? -1 : 1;
            x = Math.Abs(x);
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return sign * y;
        }
    }

    // === ГЕНЕРАТОР ПСЕВДОСЛУЧАЙНЫХ ЧИСЕЛ (мультипликативный конгруэнтный) ===
    public class MultiplicativeCongruentialGenerator
    {
        private long x;
        private const long BETA = 16807, M = 2147483647;

        public MultiplicativeCongruentialGenerator(long seed = 52) { x = seed; }

        public double Next()
        {
            x = (x * BETA) % M;
            return (double)x / M;
        }
    }
}