using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimulationLab
{
    public partial class Form1 : Form
    {
        private MultiplicativeCongruentialGenerator rng;

        // Персонажи Гарри Поттера и их кумулятивные вероятности
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

        // Кумулятивные вероятности (должны возрастать до 1.0)
        private readonly double[] cumulativeProbabilities = {
            0.20,  // Гарри: 20%
            0.38,  // Гермиона: 18%
            0.55,  // Рон: 17%
            0.67,  // Драко: 12%
            0.77,  // Луна: 10%
            0.86,  // Снегг: 9%
            0.94,  // Дамблдор: 8%
            1.00   // Невилл: 6%
        };

        public Form1()
        {
            InitializeComponent();
            rng = new MultiplicativeCongruentialGenerator(52);
        }

        /// <summary>
        /// Обработчик для Части 1: генерация "Да" или "Нет"
        /// </summary>
        private void btnAnswer1_Click(object sender, EventArgs e)
        {
            double randomValue = rng.Next();
            lblResult1.Text = randomValue < 0.5 ? "✅ Ответ: ДА" : "❌ Ответ: НЕТ";
        }

        /// <summary>
        /// Обработчик для Части 2: выбор персонажа с учётом весовых вероятностей
        /// </summary>
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