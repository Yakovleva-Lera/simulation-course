#include <iostream>
#include <iomanip>
#include <vector>
#include <string>

using namespace std;

const double c = 130.0;
const double rho = 19300.0;
const double lambda = 317.0;

double run_simulation(double L, double tau, double h, double T_left, double T_right, double T_initial, double time_final) {
    int N = static_cast<int>(L / h);
    if (abs(N * h - L) > 1e-9) {
        N = static_cast<int>(L / h + 0.5);
    }

    int time_steps_total = static_cast<int>(time_final / tau + 0.5);

    // Инициализация: все внутренние точки = T_initial
    vector<double> T(N + 1, T_initial);
    // Граничные условия
    T[0] = T_left;
    T[N] = T_right;

    double val_AC = lambda / (h * h);
    double val_B_const = 2.0 * val_AC + (rho * c) / tau;
    double coeff_F = -(rho * c) / tau;

    vector<double> alpha(N + 1, 0.0);
    vector<double> beta(N + 1, 0.0);
    vector<double> T_new(N + 1, 0.0);

    for (int step = 0; step < time_steps_total; ++step) {
        // Прямая прогонка: alpha[1] и beta[1] из левого граничного условия
        alpha[1] = val_AC / val_B_const;
        beta[1] = (coeff_F * T[1] + val_AC * T_left) / val_B_const;

        // Прямая прогонка: i = 2 ... N-1
        for (int i = 2; i < N; ++i) {
            double F_i = coeff_F * T[i];
            double denom = val_B_const - val_AC * alpha[i - 1];
            alpha[i] = val_AC / denom;
            beta[i] = (val_AC * beta[i - 1] - F_i) / denom;
        }

        // Обратная прогонка
        T_new[N] = T_right;

        for (int i = N - 1; i >= 1; --i) {
            T_new[i] = alpha[i] * T_new[i + 1] + beta[i];
        }

        // Фиксированные граничные условия
        T_new[0] = T_left;
        T_new[N] = T_right;

        T = T_new;
    }

    return T[N / 2];
}

int main() {

    setlocale(LC_ALL, "Russian");

    double L, T_left, T_right, T_initial, time;

    cout << "Введите толщину пластины (м): ";
    cin >> L;

    cout << "Введите температуру слева (°C): ";
    cin >> T_left;

    cout << "Введите температуру справа (°C): ";
    cin >> T_right;

    cout << "Введите начальную температуру внутри пластины (°C): ";
    cin >> T_initial;

    cout << "Введите время моделирования (с): ";
    cin >> time;

    double tau_values[] = { 0.1, 0.01, 0.001, 0.0001 };
    double h_values[] = { 0.1, 0.01, 0.001, 0.0001 };

    cout << endl;
    cout << fixed << setprecision(6);

    cout << setw(12) << "Tau \\ H";
    for (double h : h_values) {
        cout << setw(14) << h;
    }
    cout << endl;

    cout << string(68, '-') << endl;

    for (double tau : tau_values) {
        cout << setw(12) << tau;
        for (double h : h_values) {
            double temp = run_simulation(L, tau, h, T_left, T_right, T_initial, time);
            cout << setw(14) << temp;
        }
        cout << endl;
    }

    return 0;
}