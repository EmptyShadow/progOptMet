#include "library.h"
#include "math.h"
#include <iostream>

/**
 * Метод Свенна, локализующий интервал поиска минимума унимодальной функции,
 * в которой выполняются условия
 * Если x1 < x2 < x*, то f1 > f2 > f*
 * Если x* < x1 < x2, то f* < f1 < f2
 *
 * @param x1 - начальная точка
 * @param a1 - левый конец локализованого интервала
 * @param b1 - правый конец локализованого интервала
 * @param f  - функция от одной переменной
 * @return возвращается номер: 1 - функция отработала без проблем, 0 - возникли проблеммы
 */
int swenn(double x1, double &a1, double &b1, double (*f)(double)) {
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
        h = 2.0 * h;
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
    b1 = x_k;
    a1 = x_kprev - h / 2.0;

    intervalNormalization(a1, b1);

    return 1;
}
/**
 * Дихотомический метод одномерного поиска на заданном интервале
 *
 * @param a1 - левый конец локализованого интервала
 * @param b1 - правый конец локализованого интервала
 * @param f  - функция от одной переменной
 * @param eps - окресность центральной точки
 * @return аппроксимированый минимум
 */
double dichotomy(double a1, double b1, double (*f)(double), double eps) {
    double delta = 0.1 * eps, a_k = a1, b_k = b1;
    double lambda_k, mu_k;
    do {
        lambda_k = (b_k + a_k - delta) / 2.0;
        mu_k = (b_k + a_k + delta) / 2.0;
        if (f(lambda_k) < f(mu_k)) {
            b_k = mu_k;
        } else {
            a_k = lambda_k;
        }
        std::cout << "lambda_k: " << lambda_k
                  << " mu_k: " << mu_k << std::endl;
    } while (abs(b_k - a_k) > eps);

    return (b_k + a_k) / 2.0;
}

/**
 * Функция нормализации интервала
 * @param *a - левый конец локализованого интервала
 * @param *b - правый конец локализованого интервала
 */
void intervalNormalization(double &a, double &b) {
    if (a > b) {
        std::swap(a, b);
    }
}

/**
 * Функция получения апроксимированного минимума функции одной переменной
 * @param a1 - левый конец локализованого интервала
 * @param b1 - правый конец локализованого интервала
 * @param f  - функция от одной переменной
 * @param m - количество итераций
 * @param eps - точность
 * @return - аппроксмированный минимум
 */
double goldenSectionNum1(double a1, double b1, double (*f)(double), double m, double eps) {
    // начальный этап
    double lambda = lambdaGoldenSection(a1, b1),
            mu = muGoldenSection(a1, b1);
    int k = 1;
    // основной этап
    // Сокращение текущего интервала локализации
    do {
        std::cout << "k: " << k
                  << "a1: " << a1
                  << " b1: " << b1
                  << " lambda: " << lambda
                  << " mu: " << mu << std::endl;
        if (f(a1) < f(b1)) {
            b1 = mu;
            mu = lambda;
            lambda = lambdaGoldenSection(a1, b1);
        } else {
            a1 = lambda;
            lambda = mu;
            mu = muGoldenSection(a1, b1);
        }
        k++;
    } while(k <= m && abs(b1 - a1) > eps);

    return (a1 + b1) / 2.0;
}
/**
 * Функция получения левого золотого числа
 * @param a1 - левый конец локализованого интервала
 * @param b1 - правый конец локализованого интервала
 * @return левое золотое число
 */
double lambdaGoldenSection(double a1, double b1) {
    double t = (3.0 - sqrt(5.0)) / 2.0;
    return a1 + t * abs(b1 - a1);
}
/**
 * Функция получения правого золотого числа
 * @param a1 - левый конец локализованого интервала
 * @param b1 - правый конец локализованого интервала
 * @return правое золотое число
 */
double muGoldenSection(double a1, double b1) {
    double t = (sqrt(5.0) - 1.0) / 2.0;
    return a1 + t * abs(b1 - a1);
}
/**
 * Функция получения апроксимированного минимума функции одной переменной
 * Основан на симметрии золотого сечения
 * @param a1 - левый конец локализованого интервала
 * @param b1 - правый конец локализованого интервала
 * @param f  - функция от одной переменной
 * @param m - количество итераций
 * @param eps - точность
 * @return - аппроксмированный минимум
 */
double goldenSectionNum2(double a1, double b1, double (*f)(double), double m, double eps) {
    // начальный этап
    double x1 = lambdaGoldenSection(a1, b1), x2, f1, f2;
    int k = 1;
    // основной этап
    // Сокращение текущего интервала локализации
    do {
        x2 = b1 + a1 - x1;
        f1 = f(x1);
        f2 = f(x2);
        std::cout << "k: " << k
                  << " a1: " << a1
                  << " b1: " << b1
                  << " x1: " << x1
                  << " x2: " << x2
                  << " f1: " << f1
                  << " f2: " << f2
                  << std::endl;
        if (x1 < x2 && f1 < f2) {
            b1 = x2;
        } else if (x1 < x2 && f1 > f2) {
            a1 = x1;
            x1 = x2;
        } else if (x1 > x2 && f1 < f2) {
            a1 = x2;
        } else if (x1 > x2 && f1 > f2) {
            b1 = x1;
            x1 = x2;
        }
        k++;
    } while(k <= m && abs(b1 - a1) > eps);

    return (a1 + b1) / 2.0;
}

/**
 * Функция вычисления n-ого числа Фибоначи
 * @param n - номер числа
 * @return n-ое число Фибоначи
 */
double getNNumberFibonacci(int n) {
    if (n == 0) {
        return 0.0;
    } else if (n == 1 || n == 2) {
        return 1.0;
    }
    double fkmm = 1.0, fkm = 1.0, k = 2, fk;
    do {
        fk = fkm + fkmm;
        fkmm = fkm;
        fkm = fk;
        k++;
    } while (k < n);
    return fk;
}
/**
 * Получение ближайшего к fn числа Фибоначчи
 * @param fn
 * @return ближайшее к fn число Фибоначчи
 */
double getPrevNumberFibonacci(double fn, int &n) {
    n = 2;
    if (fn < 1.0) {
        return 1.0;
    }
    double fkmm = 1.0, fkm = 1.0, fk;
    do {
        fk = fkm + fkmm;
        fkmm = fkm;
        fkm = fk;
        n++;
    } while (fk <= fn);
    return fk;
}
/**
 * Функция для получения аппроксимированого минимума методом Фибоначчи
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param f  - функция от одной переменной
 * @param eps - последний интервал, определяющий точность приближения
 * @return аппроксимированный минимум
 */
double methodFibonacci1(double a1, double b1, double (*f)(double), double Ln) {
    int n;
    double Fn = getPrevNumberFibonacci(abs(a1 - b1) / Ln, n), Fnm = getNNumberFibonacci(n - 1), Fnmm = Fn - Fnm, Fnp = Fn + Fnm;
    double delta = abs(b1 - a1) / Fnp;
    std::cout << "delta: " << delta <<std::endl;
    double x1 = a1 + abs(b1 - a1) * Fnmm / Fn,
            x2 = a1 + abs(b1 - a1) * Fnm / Fn,
            f1, f2;
    int k = 1;
    do {
        f1 = f(x1);
        f2 = f(x2);
        std::cout << k << "  Fn: " << Fn << " Fnm: " << Fnm << " Fnmm: " << Fnmm << std::endl
                  << "a1: " << a1 << " x1: " << x1 << " x2: " << x2 << " b1: " << b1 << std::endl
                  << "f1: " << f1 << " f2: " << f2 << std::endl;
        Fn = Fnm;
        Fnm = Fnmm;
        Fnmm = Fn - Fnm;
        if (f1 < f2) {
            b1 = x2;
            x2 = x1;
            x1 = a1 + abs(b1 - a1) * Fnmm / Fn;
        } else {
            a1 = x1;
            x1 = x2;
            x2 = a1 + abs(b1 - a1) * Fnm / Fn;
        }
        k++;
    } while (k < (n - 1));
    x2 = x1 + delta;
    if (f(x1) < f(x2)) {
        return (a1 + x1) / 2;
    }
    return (x2 + b1) / 2;
}

/**
 * Функция для получения аппроксимированого минимума методом Фибоначчи
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param f  - функция от одной переменной
 * @param eps - последний интервал, определяющий точность приближения
 * @return аппроксимированный минимум
 */
double methodFibonacci2(double a1, double b1, double (*f)(double), double Ln, double eps) {
    int n;
    double Fn = getPrevNumberFibonacci(abs(a1 - b1) / Ln, n), Fnm = getNNumberFibonacci(n - 1);
    std::cout << "n: " << n << "  Fn: " << Fn << " Fnm: " << Fnm << std::endl;
    int chet = n % 2 ? -1 : 1;
    double x1 = a1 + Fnm * abs(b1 - a1) / Fn + chet * eps / Fn, x2,
            f1, f2;
    int k = 1;
    do {
        x2 = a1 + b1 - x1;
        f1 = f(x1);
        f2 = f(x2);
        std::cout << k << " a1: " << a1 << " x1: " << x1 << " x2: " << x2 << " b1: " << b1 << std::endl
                  << "f1: " << f1 << " f2: " << f2 << std::endl;
        if (x1 < x2 && f1 < f2) {
            b1 = x2;
        } else if (x1 < x2 && f1 > f2) {
            a1 = x1;
            x1 = x2;
        } else if (x1 > x2 && f1 < f2) {
            a1 = x2;
        } else if (x1 > x2 && f1 > f2) {
            b1 = x1;
            x1 = x2;
        }
        k++;
    } while (k < n);
    return x1;
}