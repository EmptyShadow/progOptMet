#ifndef UNTITLED_LIBRARY_H
#define UNTITLED_LIBRARY_H

/**
 * Метод Свенна, локализующий интервал поиска минимума унимодальной функции,
 * в которой выполняются условия
 * Если x1 < x2 < x*, то f1 > f2 > f*
 * Если x* < x1 < x2, то f* < f1 < f2
 *
 * @param x1 - начальная точка
 * @param &a1 - левый конец локализованого интервала
 * @param &b1 - правый конец локализованого интервала
 * @param f  - функция от одной переменной
 * @return возвращается номер: 1 - функция отработала без проблем, 0 - возникли проблеммы
 */
int swenn(double x1, double &a1, double &b1, double (*f)(double));
/**
 * Функция нормализации интервала
 * @param &a - левый конец локализованого интервала
 * @param &b - правый конец локализованого интервала
 */
void intervalNormalization(double &a, double &b);

/**
 * Дихотомический метод одномерного поиска на заданном интервале
 *
 * @param a1 - левый конец локализованого интервала
 * @param b1 - правый конец локализованого интервала
 * @param f  - функция от одной переменной
 * @param eps - окресность центральной точки
 * @return аппроксимированый минимум
 */
double dichotomy(double &a1, double &b1, double (*f)(double), double eps = 1e-7);

/**
 * Функция получения апроксимированного минимума функции одной переменной
 * @param a1 - левый конец локализованого интервала
 * @param b1 - правый конец локализованого интервала
 * @param f  - функция от одной переменной
 * @param m - количество итераций
 * @param eps - точность
 * @return - аппроксмированный минимум
 */
double goldenSectionNum1(double &a1, double &b1, double (*f)(double), double m = 20, double eps = 1e-7);
/**
 * Функция получения левого золотого числа
 * @param a1 - левый конец локализованого интервала
 * @param b1 - правый конец локализованого интервала
 * @return левое золотое число
 */
double lambdaGoldenSection(double a1, double b1);
/**
 * Функция получения правого золотого числа
 * @param a1 - левый конец локализованого интервала
 * @param b1 - правый конец локализованого интервала
 * @return правое золотое число
 */
double muGoldenSection(double a1, double b1);
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
double goldenSectionNum2(double &a1, double &b1, double (*f)(double), double m = 20, double eps = 1e-7);

/**
 * Функция вычисления n-ого числа Фибоначчи
 * @param n - номер числа
 * @return n-ое число Фибоначи
 */
double getNNumberFibonacci(int n);
/**
 * Получение ближайшего к fn числа Фибоначчи
 * @param fn
 * @param n номер числа Фибоначчи
 * @return ближайшее к fn число Фибоначчи
 */
double getPrevNumberFibonacci(double fn, int &n);
/**
 * Функция для получения аппроксимированого минимума методом Фибоначчи
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param f  - функция от одной переменной
 * @param eps - последний интервал, определяющий точность приближения
 * @return аппроксимированный минимум
 */
double methodFibonacci1(double &a1, double &b1, double (*f)(double), double Ln);
/**
 * Функция для получения аппроксимированого минимума методом Фибоначчи
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param f  - функция от одной переменной
 * @param eps - последний интервал, определяющий точность приближения
 * @return аппроксимированный минимум
 */
double methodFibonacci2(double &a1, double &b1, double (*f)(double), double Ln, double eps);

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
double calculatedRatios1EI(double a, double b, double c, double (*f)(double));

/**
 * Рассчетное соотношение использующееся в методах полиномиальной интерполяции
 * Более приближенное, чем calculatedRatios1EI.
 * @param a
 * @param b
 * @param c
 * @param f
 * @return аппроксимирующий минимум
 */
double calculatedRatios2EI(double a, double b, double c, double (*f)(double));

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
double calculatedRatios3EI(double a, double b, double c, double (*f)(double));

/**
 * Рассчетное соотношение использующееся в методах полиномиальной интерполяции
 * Вытекает из calculatedRatios3EI, при |b - a| = |c - b|
 * @param a
 * @param b
 * @param c
 * @param f
 * @return аппроксимирующий минимум
 */
double calculatedRatios4EI(double a, double b, double c, double (*f)(double));

/**
 * Алгоритм Экстрополяции - интерполяции.
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param f - функция
 * @param eps1 - оценка близости двух точек по опликате
 * @param eps2 - оценка близости двух точек по ординате
 * @return аппроксимированный минимум
 */
double a1ei(double &a1, double &b1, double (*f)(double), double eps1, double eps2);

/**
 * Метод Пауэлла, полиномная интерполяция, квадратичным интерполяционным многочленом
 * @param a1 - левое число интервала
 * @param b1 - правое число интервала
 * @param f - функция
 * @param eps1 - оценка близости двух точек по опликате
 * @param eps2 - оценка близости двух точек по ординате
 * @return аппроксимированный минимум
 */
double methodPowellA2PI(double &a1, double &b1, double (*f)(double), double eps1, double eps2);
/**
 * Алгоритм ДСК(Девис, Свенн, Кемпи)
 * @param x1 - начальная точка
 * @param f - функция для вычислений
 * @param eps1 - оценка близости двух точек по опликате
 * @param eps2 - оценка близости двух точек по ординате
 * @return аппроксиированный минимум
 */
double a3DSC(double x1, double (*f)(double), double eps1, double eps2);

#endif