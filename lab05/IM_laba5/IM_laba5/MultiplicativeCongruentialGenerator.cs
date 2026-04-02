using System;

namespace SimulationLab
{
    /// <summary>
    /// Мультипликативный конгруэнтный генератор псевдослучайных чисел
    /// Параметры: M = 2^31 - 1, BETA = 48271
    /// </summary>
    public class MultiplicativeCongruentialGenerator
    {
        private const long M = 2147483647;   // 2^31 - 1
        private const long BETA = 48271;
        private long x;

        public MultiplicativeCongruentialGenerator(long seed = 52)
        {
            x = seed;
        }

        /// <summary>
        /// Возвращает следующее случайное число в диапазоне [0, 1)
        /// </summary>
        public double Next()
        {
            x = (x * BETA) % M;
            return (double)x / (double)M;
        }
    }
}