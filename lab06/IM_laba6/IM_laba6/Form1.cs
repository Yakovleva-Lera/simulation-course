using System;
using System.Windows.Forms;
using System.Globalization;

namespace IM_laba6
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
                double[] probs = new double[5];
                TextBox[] probInputs = { txtProb1, txtProb2, txtProb3, txtProb4 };

                for (int i = 0; i < 4; i++)
                {
                    probs[i] = double.Parse(probInputs[i].Text, CultureInfo.InvariantCulture);
                }

                if (txtProb5.Text.ToLower() == "auto")
                {
                    double sum = 0;
                    for (int i = 0; i < 4; i++) sum += probs[i];
                    probs[4] = 1.0 - sum;
                }
                else
                {
                    probs[4] = double.Parse(txtProb5.Text, CultureInfo.InvariantCulture);
                }

                int n = int.Parse(txtNumber.Text, CultureInfo.InvariantCulture);

                int[] values = new int[n];
                int[] frequencies = new int[5];

                for (int i = 0; i < n; i++)
                {
                    values[i] = GenerateDiscreteValue(probs);
                    frequencies[values[i] - 1]++;
                }

                double[] empiricalProbs = new double[5];
                for (int i = 0; i < 5; i++)
                {
                    empiricalProbs[i] = (double)frequencies[i] / n;
                }

                double theoreticalMean = 0;
                double theoreticalVar = 0;
                for (int i = 0; i < 5; i++)
                {
                    theoreticalMean += (i + 1) * probs[i];
                    theoreticalVar += Math.Pow(i + 1, 2) * probs[i];
                }
                theoreticalVar -= Math.Pow(theoreticalMean, 2);

                double sampleMean = 0;
                for (int i = 0; i < n; i++)
                {
                    sampleMean += values[i];
                }
                sampleMean /= n;

                double sampleVar = 0;
                for (int i = 0; i < n; i++)
                {
                    sampleVar += Math.Pow(values[i] - sampleMean, 2);
                }
                sampleVar /= (n - 1);

                double meanError = Math.Abs(sampleMean - theoreticalMean) / theoreticalMean * 100;
                double varError = Math.Abs(sampleVar - theoreticalVar) / theoreticalVar * 100;

                double chiSquared = 0;
                for (int i = 0; i < 5; i++)
                {
                    double expected = n * probs[i];
                    double observed = frequencies[i];
                    chiSquared += Math.Pow(observed - expected, 2) / expected;
                }

                double chiCritical = 9.488;

                lblAverage.Text = $"Average: {sampleMean.ToString("F3", CultureInfo.InvariantCulture)} (error = {meanError.ToString("F0", CultureInfo.InvariantCulture)}%)";
                lblVariance.Text = $"Variance: {sampleVar.ToString("F3", CultureInfo.InvariantCulture)} (error = {varError.ToString("F0", CultureInfo.InvariantCulture)}%)";
                lblChiSquared.Text = $"Chi-squared: {chiSquared.ToString("F2", CultureInfo.InvariantCulture)} < {chiCritical.ToString("F3", CultureInfo.InvariantCulture)} ? {(chiSquared <= chiCritical ? "accept" : "reject")}";

                histogramPanel.UpdateHistogram(probs, empiricalProbs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private int GenerateDiscreteValue(double[] probs)
        {
            double r = generator.Next();
            double cumulative = 0;

            for (int i = 0; i < 5; i++)
            {
                cumulative += probs[i];
                if (r < cumulative)
                    return i + 1;
            }
            return 5;
        }
    }

    public class MultiplicativeCongruentialGenerator
    {
        private long x;
        private const long BETA = 16807;
        private const long M = 2147483647;

        public MultiplicativeCongruentialGenerator(long seed = 52)
        {
            x = seed;
        }

        public double Next()
        {
            x = (x * BETA) % M;
            return (double)x / (double)M;
        }
    }
}