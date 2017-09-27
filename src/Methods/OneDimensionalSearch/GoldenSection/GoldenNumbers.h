//
// Created by Дмитрий on 25.09.2017.
//

#ifndef PROGOPTMET_GOLDENNUMBERS_H
#define PROGOPTMET_GOLDENNUMBERS_H

#include "math.h"

/**
 * Вычисление чисел золотого сечения
 */

class GoldenNumbers {
public:
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
};


#endif //PROGOPTMET_GOLDENNUMBERS_H
