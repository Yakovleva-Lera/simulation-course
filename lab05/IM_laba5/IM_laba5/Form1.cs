using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimulationLab
{
    public partial class Form1 : Form
    {
        private MultiplicativeCongruentialGenerator rng;

        private readonly string[] characters = {
            "Гарри Поттер",
            "Гермиона Грейнджер",
            "Рон Уизли",
            "Драко Малфой",
            "Полумна Лавгуд",
            "Северус Снегг",
            "Альбус Дамблдор",
            "Невилл Долгопупс"
        };

        private readonly double[] cumulativeProbabilities = {
            0.20,
            0.38,
            0.55,
            0.67,
            0.77,
            0.86,
            0.94,
            1.00
        };

        public Form1()
        {
            InitializeComponent();
            rng = new MultiplicativeCongruentialGenerator(52);
        }
        //Приложение да/нет
        private void btnAnswer1_Click(object sender, EventArgs e)
        {
            double randomValue = rng.Next();
            lblResult1.Text = randomValue < 0.5 ? "✅ Ответ: ДА" : "❌ Ответ: НЕТ";
        }

        //Приложение Magic ball
        private void btnAnswer2_Click(object sender, EventArgs e)
        {
            double randomValue = rng.Next();

            for (int i = 0; i < cumulativeProbabilities.Length; i++)
            {
                if (randomValue < cumulativeProbabilities[i])
                {
                    lblResult2.Text = "✨ Вы: " + characters[i];
                    break;
                }
            }
        }
    }
}