//
// Created by Дмитрий on 25.09.2017.
//

#ifndef PROGOPTMET_FIBONACCINUMBERS_H
#define PROGOPTMET_FIBONACCINUMBERS_H


class FibonacciNumbers {
public:
    /**
    * Функция вычисления n-ого числа Фибоначчи
    * @param n - номер числа
    * @return n-ое число Фибоначи
    */
    double getNNumber(int n);

    /**
    * Получение первого большего fn числа Фибоначчи
    * @param fn
    * @param n номер числа Фибоначчи
    * @return ближайшее к fn число Фибоначчи
    */
    double getNextNumber(double fn, int &n);
};


#endif //PROGOPTMET_FIBONACCINUMBERS_H
