//
// Created by Дмитрий on 24.09.2017.
//

#ifndef PROGOPTMET_INPUTPARAMS_H
#define PROGOPTMET_INPUTPARAMS_H

#include "string"

class Vector;
class Func;

class InputParams {
public:
    InputParams();

    ~InputParams();

    int m = 40; // ограничение по количеству итераций
    Vector *x1 = nullptr; // стартовая точка
    Vector *p = nullptr; // начальное направление
    Vector *alfa = nullptr; // интервал шага локализации
    double alfa_h = 0.01; // шаг изменения приближения
    Func *y; // функция
    double eps_arg = 0.0; // погрешность по аргументам
    double eps_f = 0.0; // погрешнасть по значениям функции

    /**
     * Привести к строке
     * @return
     */
    std::string *toString();

    /**
     * Получить дубликат
     * @return
     */
    InputParams *clone();
};


#endif //PROGOPTMET_INPUTPARAMS_H
