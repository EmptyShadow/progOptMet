#include "library.h"
#include "math.h"
#include <iostream>

/*
 * Метод Свенна, локализующий интервал поиска минимума унимодальной функции,
 * в которой выполняются условия
 * Если x1 < x2 < x*, то f1 > f2 > f*
 * Если x* < x1 < x2, то f* < f1 < f2
 */
int swenn(double x1, double *a1, double *b1, double (*f)(double)) {
    if (a1 == nullptr || b1 == nullptr) {
        return 0;
    }

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

    std::cout << "x1: " << x1
              << " x2: " << x2
              << " h: " << h
              << "f1: " << f1
              << "f2: " << f(x2) << std::endl;

    // Шаг 2: вычисляем точку fk
    double f_k = f(x2), f_kprev = f1, x_k = x2, x_kprev = x1;
    while (f_k <= f_kprev) {
        h = 2 * h;
        f_kprev = f_k;
        x_kprev = x_k;
        x_k = x_kprev + h;
        f_k = f(x_k);

        std::cout << "x_kprev: " << x_kprev
                  << " x_k: " << x_k
                  << " h: " << h
                  << " f_kprev: " << f_kprev
                  << " f_k: " << f_k << std::endl;
    }

    // Шаг 3
    *b1 = x_k;
    *a1 = x_kprev - h / 2;

    return 1;
}

/*
 * Метод одномерного поиска на заданном интервале
 */
double dichotomy(double a1, double b1, double (*f)(double), double eps) {
    double delta = 0.1 * eps, a_k = a1, b_k = b1;
    double lambda_k, mu_k;
    do {
        lambda_k = (b_k + a_k - delta) / 2;
        mu_k = (b_k + a_k + delta) / 2;
        if (f(lambda_k) < f(mu_k)) {
            b_k = mu_k;
        } else {
            a_k = lambda_k;
        }
        std::cout << "lambda_k: " << lambda_k
                  << " mu_k: " << mu_k << std::endl;
    } while (abs(b_k - a_k) > eps);

    return (b_k + a_k) / 2;
}

void intervalNormalization(double *a, double *b) {
    if ((*a) > (*b)) {
        std::swap(*a, *b);
    }
}