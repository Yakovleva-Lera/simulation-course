using System;

namespace SimulationLab
{
    
    public class MultiplicativeCongruentialGenerator
    {
        private const long M = 2147483647;
        private const long BETA = 48271;
        private long x;

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