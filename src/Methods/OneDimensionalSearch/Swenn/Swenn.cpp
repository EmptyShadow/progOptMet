#include "Swenn.h"

Swenn::Swenn() {
    name = "Swenn";
}

Swenn::~Swenn() {}

int Swenn::run(Params &params) {
    params.writelnInLogs("Start method Swenn\n");
    params.writelnInLogs(params.input.toString());
    int k = 1;
    // Задаем стартовые переменные по входным данным
    double (*f)(double) = params.input.f;
    double x1 = params.input.x1;

    // Выбираем начальный шаг
    double h = (x1 == 0) ? 0.01 : 0.01 * abs(x1);
    // Шаг 1: Устанавливаем направлнение
    double f1 = f(x1), x2 = x1 + h;
    // Если
    if (f(x2) > f1) {
        //, то меняем направление
        h = -h;
        x2 = x1 + h;
    }

    // Шаг 2: вычисляем точку fk
    double f_k = f(x2), f_kprev = f1, x_k = x2, x_kprev = x1;
    while (f_k <= f_kprev) {
        h = 2.0 * h;
        f_kprev = f_k;
        x_kprev = x_k;
        x_k = x_kprev + h;
        f_k = f(x_k);
        k++;
    }

    // Шаг 3
    double a1, b1;
    b1 = x_k;
    a1 = x_kprev - h / 2.0;
    intervalNormalization(a1, b1);

    // запись выходных параметров
    params.output.k = k;
    params.output.x_ = (a1 + b1) / 2.0;
    params.output.f_x_ = f(params.output.x_);
    params.output.intervalPoints.push_back(a1);
    params.output.intervalPoints.push_back(b1);
    params.input.intervalPoints.push_back(a1);
    params.input.intervalPoints.push_back(b1);
    params.writelnInLogs(params.output.toString());
    params.writelnInLogs("End method Swenn\n\n");

    return 0;
}

void Swenn::intervalNormalization(double &a, double &b) {
    if (a > b) {
        double t = a;
        a = b;
        b = t;
    }
}