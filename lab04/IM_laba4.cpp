#include <iostream>
#include <random>
#include <cmath>
#include <iomanip>

const long long M = 2147483647;
const long long BETA = 48271;

class MultiplicativeCongruentialGenerator {
private:
    long long x;

public:
    MultiplicativeCongruentialGenerator(long long seed = 52) : x(seed) {}

    double next() {
        // Формула: x_i = (a * x_{i-1}) mod m
        x = (x * BETA) % M;
        return static_cast<double>(x) / static_cast<double>(M);
    }
};

struct Statistics {
    double mean;
    double variance;
};

Statistics calculateStatistics(double* data, int size) {
    Statistics stats;

    double sum = 0.0;
    for (int i = 0; i < size; i++) {
        sum += data[i];
    }
    stats.mean = sum / size;

    double varianceSum = 0.0;
    for (int i = 0; i < size; i++) {
        double diff = data[i] - stats.mean;
        varianceSum += diff * diff;
    }
    stats.variance = varianceSum / size;

    return stats;
}

int main() {
    const int SAMPLE_SIZE = 100000;
    const double THEORETICAL_MEAN = 0.5;
    const double THEORETICAL_VARIANCE = 1.0 / 12.0;

    double* mcgData = new double[SAMPLE_SIZE];
    double* stdData = new double[SAMPLE_SIZE];

    MultiplicativeCongruentialGenerator mcg;
    for (int i = 0; i < SAMPLE_SIZE; i++) {
        mcgData[i] = mcg.next();
    }

    std::mt19937_64 stdGen(42);
    std::uniform_real_distribution<double> dist(0.0, 1.0);
    for (int i = 0; i < SAMPLE_SIZE; i++) {
        stdData[i] = dist(stdGen);
    }

    Statistics mcgStats = calculateStatistics(mcgData, SAMPLE_SIZE);
    Statistics stdStats = calculateStatistics(stdData, SAMPLE_SIZE);

    std::cout << "First 10 values:" << std::endl;
    std::cout << std::fixed << std::setprecision(10);

    std::cout << "\nMCG:" << std::endl;
    for (int i = 0; i < 10; i++) {
        std::cout << "  [" << i << "] = " << mcgData[i] << std::endl;
    }

    std::cout << "\nStandard (mt19937_64):" << std::endl;
    for (int i = 0; i < 10; i++) {
        std::cout << "  [" << i << "] = " << stdData[i] << std::endl;
    }

    std::cout << std::endl;
    std::cout << std::fixed << std::setprecision(10);

    std::cout << "Parameters:" << std::endl;
    std::cout << "M = " << M << " (2^31 - 1)" << std::endl;
    std::cout << "Beta = " << BETA << std::endl;
    std::cout << "Sample size = " << SAMPLE_SIZE << std::endl;
    std::cout << std::endl;

    std::cout << "Theoretical values:" << std::endl;
    std::cout << "Mean = " << THEORETICAL_MEAN << std::endl;
    std::cout << "Variance = " << THEORETICAL_VARIANCE << std::endl;
    std::cout << std::endl;

    std::cout << "Multiplicative Congruential Generator:" << std::endl;
    std::cout << "Mean = " << mcgStats.mean << std::endl;
    std::cout << "Variance = " << mcgStats.variance << std::endl;
    std::cout << "Mean deviation = " << std::abs(mcgStats.mean - THEORETICAL_MEAN) << std::endl;
    std::cout << "Variance deviation = " << std::abs(mcgStats.variance - THEORETICAL_VARIANCE) << std::endl;
    std::cout << std::endl;

    std::cout << "Standard Generator (mt19937_64):" << std::endl;
    std::cout << "Mean = " << stdStats.mean << std::endl;
    std::cout << "Variance = " << stdStats.variance << std::endl;
    std::cout << "Mean deviation = " << std::abs(stdStats.mean - THEORETICAL_MEAN) << std::endl;
    std::cout << "Variance deviation = " << std::abs(stdStats.variance - THEORETICAL_VARIANCE) << std::endl;

    delete[] mcgData;
    delete[] stdData;

    return 0;
}