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
 * @return аппроксимированный минимум
 */
double swenn(double x1, double &a1, double &b1, double (*f)(double)) {
    printf("Start method Swenn;\n");
    // Выбираем начальный шаг
    double h = (x1 == 0) ? 0.01 : 0.01 * abs(x1);
    // Шаг 1: Устанавливаем направлнение
    double f1 = f(x1), x2 = x1 + h;
    int k = 1;
    printf("k: %d; x1: %0.7f; x2: %0.7f; h: %0.7f; f1: %0.7f; f2: %0.7f;\n", k, x1, x2, h, f1, f(x2));
    // Если
    if (f(x2) > f1) {
        //, то меняем направление
        h = -h;
        x2 = x1 + h;
    }

    printf("k: %d; x1: %0.7f; x2: %0.7f; h: %0.7f; f1: %0.7f; f2: %0.7f;\n", k, x1, x2, h, f1, f(x2));

    // Шаг 2: вычисляем точку fk
    double f_k = f(x2), f_kprev = f1, x_k = x2, x_kprev = x1;
    while (f_k <= f_kprev) {
        h = 2.0 * h;
        f_kprev = f_k;
        x_kprev = x_k;
        x_k = x_kprev + h;
        f_k = f(x_k);
        k++;

        printf("k: %d; x_kprev: %0.7f; x_k: %0.7f; h: %0.7f; f_prev: %0.7f; f_k: %0.7f;\n", k, x_kprev, x_k, h, f_kprev, f_k);
    }

    // Шаг 3
    b1 = x_k;
    a1 = x_kprev - h / 2.0;

    intervalNormalization(a1, b1);
    printf("a1: %0.7f; b1: %0.7f;\n", a1, b1);
    printf("x_: %0.7f; f(x_): %0.7f;\n", (a1 + b1) / 2.0, f((a1 + b1) / 2.0));
    printf("End method Swenn\n\n\n");

    return (a1 + b1) / 2.0;
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
double dichotomy(double &a1, double &b1, double (*f)(double), double eps) {
    printf("Start method Dichotomy\n");
    double delta = 0.1 * eps, a_k = a1, b_k = b1;
    double lambda_k, mu_k;
    int k = 0;
    do {
        k++;
        lambda_k = (b_k + a_k - delta) / 2.0;
        mu_k = (b_k + a_k + delta) / 2.0;
        if (f(lambda_k) < f(mu_k)) {
            b_k = mu_k;
        } else {
            a_k = lambda_k;
        }
        printf("k: %d; lambda_k: %0.7f; mu_k: %0.7f;\n", k, lambda_k, mu_k);
    } while (abs(b_k - a_k) > eps);
    a1 = a_k;
    b1 = b_k;
    printf("a1: %0.7f; b1: %0.7f;\n", a1, b1);
    double x_ = (b_k + a_k) / 2.0, f_ = f(x_);
    printf("x_: %0.7f; fx_: %0.7f;\n", x_, f_);
    printf("End method Dichotomy\n\n\n");
    return x_;
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
double goldenSectionNum1(double &a1, double &b1, double (*f)(double), double m, double eps) {
    printf("Start method golden section 1\n");
    // начальный этап
    double lambda = lambdaGoldenSection(a1, b1),
            mu = muGoldenSection(a1, b1);
    int k = 1;
    // основной этап
    // Сокращение текущего интервала локализации
    do {
        printf("k: %d; a1: %0.7f; b1: %0.7f; lambda_k: %0.7f; mu_k: %0.7f;\n", k, a1, b1, lambda, mu);
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
    double x_ = (a1 + b1) / 2.0, f_ = f(x_);
    printf("a1: %0.7f; b1: %0.7f;\n", a1, b1);
    printf("x_: %0.7f; fx_: %0.7f;\n", x_, f_);
    printf("End method golden section 1\n\n\n");

    return x_;
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
double goldenSectionNum2(double &a1, double &b1, double (*f)(double), double m, double eps) {
    printf("Start method golden section 2\n");
    // начальный этап
    double x1 = lambdaGoldenSection(a1, b1), x2, f1, f2;
    int k = 1;
    // основной этап
    // Сокращение текущего интервала локализации
    do {
        x2 = b1 + a1 - x1;
        f1 = f(x1);
        f2 = f(x2);
        printf("k: %d; a1: %0.7f; b1: %0.7f; x1: %0.7f; x2: %0.7f; f1: %0.7f; f2: %0.7f;\n", k, a1, b1, x1, x2, f1, f(x2));
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

    double x_ = (a1 + b1) / 2.0, f_ = f(x_);
    printf("a1: %0.7f; b1: %0.7f;\n", a1, b1);
    printf("x_: %0.7f; fx_: %0.7f;\n", x_, f_);
    printf("End method golden section 1\n\n\n");

    return x_;
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
double methodFibonacci1(double &a1, double &b1, double (*f)(double), double Ln) {
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
        return (a1 + x1) / 2.0;
    }
    a1 = x2;
    return (x2 + b1) / 2.0;
}

/**
 * Функция для получения аппроксимированого минимума методом Фибоначчи
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param f  - функция от одной переменной
 * @param eps - последний интервал, определяющий точность приближения
 * @return аппроксимированный минимум
 */
double methodFibonacci2(double &a1, double &b1, double (*f)(double), double Ln, double eps) {
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

/**
 * Рассчетное соотношение использующееся в методах полиномиальной интерполяции
 * Позволяет найти аппроксимирующий минимум при любом расстоянии между точками, но из за
 * разности кв. точность храмает
 * @param a
 * @param b
 * @param c
 * @param f
 * @return аппроксимирующий минимум
 */
double calculatedRatios1EI(double a, double b, double c, double (*f)(double)) {
    double fa = f(a), fb = f(b), fc = f(c);
    double aa = a * a, bb = b * b, cc = c * c;
    return 0.5 * (fa * (bb - cc) + fb * (cc - aa) + fc * (aa - bb)) / (fa * (b - c) + fb * (c - a) + fc * (a - b));
}

/**
 * Рассчетное соотношение использующееся в методах полиномиальной интерполяции
 * Более приближенное, чем calculatedRatios1EI.
 * @param a
 * @param b
 * @param c
 * @param f
 * @return аппроксимирующий минимум
 */
double calculatedRatios2EI(double a, double b, double c, double (*f)(double)) {
    double fa = f(a), fb = f(b), fc = f(c);
    return (a + b) / 2.0 + 0.5 * (fa - fb) * (b - c) * (c - a) / (fa * (b - c) + fb * (c - a) + fc * (a - b));
}

/**
 * Рассчетное соотношение использующееся в методах полиномиальной интерполяции
 * Формула Брента построенная в предположении, что выполняется требование,
 * Fa >= Fb <= Fc, b принадлежит [a, c]
 * @param a
 * @param b
 * @param c
 * @param f
 * @return аппроксимирующий минимум
 */
double calculatedRatios3EI(double a, double b, double c, double (*f)(double)) {
    double fa = f(a), fb = f(b), fc = f(c);
    return b + 0.5 * ((b - a) * (b - a) * (fb - fc) - (b - c) * (b - c) * (fb - fa)) / ((b - a) * (fb - fc) - (b - c) * (fb - fa));
}

/**
 * Рассчетное соотношение использующееся в методах полиномиальной интерполяции
 * Вытекает из calculatedRatios3EI, при |b - a| = |c - b|
 * @param a
 * @param b
 * @param c
 * @param f
 * @return аппроксимирующий минимум
 */
double calculatedRatios4EI(double a, double b, double c, double (*f)(double)) {
    double fa = f(a), fb = f(b), fc = f(c);
    return b + 0.5 * (b - a) * (fa - fc) / (fa - 2.0 * fb + fc);
}

/**
 * Алгоритм Экстрополяции - интерполяции.
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param eps - точность приближения
 * @return аппроксимированный минимум
 */
double a1ei(double &a1, double &b1, double (*f)(double), double eps1, double eps2) {
    double x1 = (a1 + b1) / 2.0, d;
    double h = 0.01 * abs(x1);
    int k = 1;
    while (true) {
        d = calculatedRatios2EI(a1, x1, b1, f);
        if (abs(1.0 - d / x1) <= eps1 && abs(1.0 - f(d) / f(x1)) <= eps2) {
            if (x1 < d) {
                a1 = x1;
                b1 = d;
            } else {
                a1= d;
                b1 = x1;
            }
            return (x1 + d) / 2.0;
        }
        x1 = d;
    }
}

/**
 * Метод Пауэлла, полиномная интерполяция, квадратичным интерполяционным многочленом
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param f - функция
 * @param eps1 - оценка близости двух точек по опликате
 * @param eps2 - оценка близости двух точек по ординате
 * @return аппроксимированный минимум
 */
double methodPowellA2PI(double &a1, double &b1, double (*f)(double), double eps1, double eps2){
    printf("Start method Powell\n");
    double a = a1, c = b1, b = (a + c) / 2.0;
    int k = 1;
    double d = calculatedRatios1EI(a, b, c, f), fb = f(b), fd = f(d);
    printf("k: %d; a: %0.9f; b: %0.9f; c: %0.9f; d: %0.9f; fb: %0.9f; fd: %0.9f;\n", k, a, b, c, d, fb, fd);
    while (b != 0.0 && (abs(1.0 - d / b) > eps1 || abs(1.0 - fd / fb) > eps2)) {
        if (b < d && fb < fd) {
            c = d;
        } else if (b < d && fb > fd) {
            a = b;
            b = d;
        } else if (b > d && fb < fd) {
            a = d;
        } else if (b > d && fb > fd) {
            c = b;
            b = d;
        }
        d = calculatedRatios2EI(a, b, c, f);
        fb = f(b);
        fd = f(d);
        k++;
        printf("k: %d; a: %0.9f; b: %0.9f; c: %0.9f; d: %0.9f; fb: %0.9f; fd: %0.9f;\n", k, a, b, c, d, fb, fd);
    }
    if (b < d) {
        a1 = b;
        b1 = d;
    } else {
        a1 = d;
        b1 = b;
    }
    double x_ = (a1 + b1) / 2.0, f_ = f(x_);
    printf("a1: %0.7f; b1: %0.7f;\n", a1, b1);
    printf("x_: %0.7f; fx_: %0.7f;\n", x_, f_);
    printf("End method Powell\n\n\n");

    return x_;
}
/**
 * Алгоритм ДСК(Девис, Свенн, Кемпи)
 * @param x1 - начальная точка
 * @param f - функция для вычислений
 * @param eps1 - оценка близости двух точек по опликате
 * @param eps2 - оценка близости двух точек по ординате
 * @return аппроксиированный минимум
 */
double a3DSC(double x1, double (*f)(double), double eps1, double eps2) {
    double a, b, c, d, x_k, h, x_kp, x_km, x_kpm;
    int k = 1;
    do {
        // Шаг 1 Свенн 2
        swenn(x1, a, c, f);
        goldenSectionNum1(a, c, f, 20, eps1);
        x_k = (a + c) / 2.0;
        h = 0.01 * x_k;
        if (f(x_k) < f(x_k + h)) {
            h = -h;
        }
        x_kp = x_k + h;
        while (f(x_kp) <= f(x_k)) {
            h *= 2.0;
            x_k = x_kp;
            x_kp = x_k + h;
            k++;
        }
        x_kpm = (x_kp + x_k) / 2.0;
        x_km = x_k - (x_kp - x_kpm);
        if (f(x_kpm) < f(x_k)) {
            a = x_k;
            b = x_kpm;
            c = x_kp;
        } else {
            a = x_km;
            b = x_k;
            c = x_kpm;
        }
        // Шаг 2 вычисление d
        d = calculatedRatios3EI(a, b, c, f);
        // Шаг 3 проверить критерий окончания поиска
        x1 = b;
        h /= 2.0;
        k++;
    } while (abs(1 - d / b) >= eps1 || abs(1 - f(d) / f(b)) >= eps2);
    return b;
}

/**
 * Значение производной в точке
 * @param x - точка
 * @param delta_x - скольугодно малое преращение аргумента
 * @param f - функция
 * @return значение производной в точке
 */
double valueOfTheDerivativeAtThePoint(double x, double delta_x, double (*f)(double)) {
    return (f(x + delta_x) - f(x)) / delta_x;
}

/**
 * Значение второй производной в точке
 * @param x - точка
 * @param delta_x - скольугодно малое преращение аргумента
 * @param f - функция
 * @return значение производной в точке
 */
double valueOfTheSecondDerivativeAtThePoint(double x, double delta_x, double (*f)(double)) {
    return (f(x + delta_x) - 2 * f(x) + f(x - delta_x)) / (delta_x * delta_x);
}

/**
 * Метод средней точки (Больцано) является вариантом метода деления интервала по-полам.
 * Последовательные сокращения интервала неопределенности произво-дятся на
 * основе оценки производной минимизируемой функции в центре те-кущего интервала.
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param f - функция
 * @param eps - погрешность
 * @return
 */
double midpointMethod(double &a1, double &b1, double (*f)(double), double eps) {
    printf("Start method Bolzano\n");
    double xk = (a1 + b1) / 2.0;
    int k = 1;
    while(abs(valueOfTheDerivativeAtThePoint(xk, eps, f)) > eps || abs(b1 - a1) > eps) {
        printf("k: %d; a1: %0.9f; b1: %0.9f; xk: %0.9f; abs(b1 - a1): %0.9f; f'(xk): %0.9f;\n", k, a1, b1, xk, abs(b1 - a1), valueOfTheDerivativeAtThePoint(xk, eps, f));
        if (valueOfTheDerivativeAtThePoint(xk, eps, f) > 0.0) {
            b1 = xk;
        } else {
            a1 = xk;
        }
        xk = (b1 + a1) / 2.0;
        k++;
    }
    printf("a1: %0.7f; b1: %0.7f;\n", a1, b1);
    printf("x_: %0.7f; fx_: %0.7f;\n", xk, f(xk));
    printf("End method Bolzano\n\n\n");
    return xk;
}

/**
 * Метод трехточечного поиска на равных интервалах
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param f - функция
 * @param eps - погрешность
 * @return
 */
double methodOfThreePointSearchAtEqualIntervals(double &a1, double &b1, double (*f)(double), double eps) {
    printf("Start method of three point search at equal intervals\n");
    double x_m = (a1 + b1) / 2.0, x1, x2, L, f1, f2, fm;
    int k = 1;
    do {
        L = abs(b1 - a1);
        x1 = a1 + L / 4.0;
        x2 = b1 - L / 4.0;
        f1 = f(x1);
        f2 = f(x2);
        fm = f(x_m);
        printf("k: %d; x1: %0.7f; f1: %0.7f; xm: %0.7f; fm: %0.7f; x2: %0.7f; f2: %0.7f; a1: %0.7f; b1: %0.7f;\n", k, x1, f1, x_m, fm, x2, f2, a1, b1);
        if (f1 < fm) {
            b1 = x_m;
            x_m = x1;
        } else if (f1 >= fm && f2 >= fm) {
            a1 = x1;
            b1 = x2;
        } else {
            a1 = x_m;
            x_m = x2;
        }
        printf("k: %d; x1: %0.7f; f1: %0.7f; xm: %0.7f; fm: %0.7f; x2: %0.7f; f2: %0.7f; a1: %0.7f; b1: %0.7f;\n", k, x1, f1, x_m, fm, x2, f2, a1, b1);
        k++;
    } while(abs(b1 - a1) >= eps);
    double x_ = (a1 + b1) / 2.0, f_ = f(x_);
    printf("a1: %0.7f; b1: %0.7f;\n", a1, b1);
    printf("x_: %0.7f; fx_: %0.7f;\n", x_, f_);
    printf("End method of three point search at equal intervals\n\n\n");

    return x_;
}

/**
 * Метод секущих (линейная интерполяция)
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param f - функция
 * @param eps - погрешность
 * @return
 */
double methodSecants(double &a1, double &b1, double (*f)(double), double eps) {
    printf("Start method Secants\n");
    int k = 1;
    double x_kp, fd_kp;
    while(true) {
        x_kp = b1 - valueOfTheDerivativeAtThePoint(b1, eps, f)*(b1 - a1) /
                            (valueOfTheDerivativeAtThePoint(b1, eps, f) - valueOfTheDerivativeAtThePoint(a1, eps, f));
        fd_kp = f(x_kp);
        printf("k: %d; a1: %0.7f; x_kp: %0.7f; b1: %0.7f; fx_kp: %0.7f;\n", k, a1, x_kp, b1, fd_kp);
        if (abs(fd_kp < eps)) {
            break;
        }
        if (fd_kp > 0) {
            b1 = x_kp;
        } else {
            a1 = x_kp;
        }
        k++;
    }
    double x_ = (a1 + b1) / 2.0, f_ = f(x_);
    printf("a1: %0.7f; b1: %0.7f;\n", a1, b1);
    printf("x_: %0.7f; fx_: %0.7f;\n", x_, f_);
    printf("End method Secants\n\n\n");

    return x_;
}