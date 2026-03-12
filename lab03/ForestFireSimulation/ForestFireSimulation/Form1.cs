using System;
using System.Drawing;
using System.Windows.Forms;

namespace ForestFireSimulation
{
    // Состояния клетки
    public enum CellType { Empty, Tree, Burning, Water }

    // Структура клетки с данными о возрасте
    public struct Cell
    {
        public CellType Type;
        public int Age;
    }

    public partial class Form1 : Form
    {
        // Настройки модели
        private const int Rows = 100;
        private const int Cols = 150;
        private const int CellSize = 6;

        private Cell[,] grid = new Cell[Cols, Rows];
        private Random rnd;

        // Вероятности роста и возгорания
        private double probGrowth = 0.05;
        private double probFire = 0.0005;
        private int oldAgeThreshold = 20; // Порог "старости"

        // Направление ветра
        private Point windDir = new Point(1, 0);

        public Form1()
        {
            InitializeComponent();

            // Настройка PictureBox для плавной графики
            pbCanvas.Width = Cols * CellSize;
            pbCanvas.Height = Rows * CellSize;

            // Инициализация с фиксированным зерном (Seed) для одинаковой карты
            rnd = new Random(42);
            InitializeMap();

            timerStep.Tick += (s, e) => { UpdateSimulation(); pbCanvas.Invalidate(); };
        }

        private void InitializeMap()
        {
            int centerX = Cols / 2;
            int centerY = Rows / 2;

            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    // 1. Озеро 
                    if (x > centerX - 15 && x < centerX + 15 && y > centerY - 10 && y < centerY + 10)
                    {
                        grid[x, y] = new Cell { Type = CellType.Water };
                    }
                    else if (rnd.NextDouble() < 0.5) // "Плотность" леса
                    {
                        grid[x, y] = new Cell { Type = CellType.Tree, Age = rnd.Next(0, oldAgeThreshold + 5) };
                    }
                    else
                    {
                        grid[x, y] = new Cell { Type = CellType.Empty };
                    }
                }
            }
        }

        private void UpdateSimulation()
        {
            Cell[,] nextGrid = (Cell[,])grid.Clone(); // Копируем текущее состояние

            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Cell current = grid[x, y];

                    if (current.Type == CellType.Water) continue;

                    // ПРАВИЛО 1: Горящая клетка становится пустой
                    if (current.Type == CellType.Burning)
                    {
                        nextGrid[x, y].Type = CellType.Empty;
                        nextGrid[x, y].Age = 0;
                    }
                    // ПРАВИЛО 4: Рост дерева на пустоте
                    else if (current.Type == CellType.Empty)
                    {
                        if (rnd.NextDouble() < probGrowth)
                            nextGrid[x, y].Type = CellType.Tree;
                    }
                    // ПРАВИЛО 2 и 3: Дерево и Огонь
                    else if (current.Type == CellType.Tree)
                    {
                        nextGrid[x, y].Age++;

                        bool willBurn = false;

                        // Проверяем соседей
                        if (CheckBurningNeighbors(x, y))
                        {
                            willBurn = true;
                        }
                        // Случайное возгорание + старение
                        else
                        {
                            double f = probFire;
                            if (current.Age > oldAgeThreshold) f *= 10; // Старые горят чаще

                            if (rnd.NextDouble() < f) willBurn = true;
                        }

                        if (willBurn) nextGrid[x, y].Type = CellType.Burning;
                    }
                }
            }
            grid = nextGrid; // Применяем изменения ко всей сетке сразу
        }

        private bool CheckBurningNeighbors(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    int nx = x + i;
                    int ny = y + j;

                    if (nx >= 0 && nx < Cols && ny >= 0 && ny < Rows)
                    {
                        if (grid[nx, ny].Type == CellType.Burning)
                        {
                            // По направлению ветра — безусловное возгорание
                            if (i == -windDir.X && j == -windDir.Y)
                                return true;

                            // 3. Не по ветру (боковое или встречное) — вероятность 0.3
                            if (rnd.NextDouble() < 0.3)
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Brush color = Brushes.Black;
                    switch (grid[x, y].Type)
                    {
                        case CellType.Empty: color = Brushes.BurlyWood; break;
                        case CellType.Water: color = Brushes.Blue; break;
                        case CellType.Burning: color = Brushes.Red; break;
                        case CellType.Tree:
                            // Старые деревья темно-зеленые
                            color = grid[x, y].Age > oldAgeThreshold ? Brushes.DarkGreen : Brushes.LimeGreen;
                            break;
                    }
                    g.FillRectangle(color, x * CellSize, y * CellSize, CellSize - 1, CellSize - 1);
                }
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            timerStep.Enabled = !timerStep.Enabled;
            btnStartStop.Text = timerStep.Enabled ? "Stop" : "Start";
        }
    }
}