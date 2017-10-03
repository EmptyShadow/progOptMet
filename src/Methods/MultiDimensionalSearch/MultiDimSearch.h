//
// Created by Дмитрий on 01.10.2017.
//

#ifndef PROGOPTMET_MULTIDIMSEARCH_H
#define PROGOPTMET_MULTIDIMSEARCH_H

#include "../Method.h"

class MultiDimSearch : public Method {
public:
    /**
     * запуск метода на исполнение
     * @param params
     * @return
     */
    virtual int run(Params *params) = 0;

    /**
     * Функция x(alfa) получение точки в пространстве, по alfa и направлению p
     * @param x - исходная точка
     * @param alfa - коэфициент удаления
     * @param p - направление удаления
     * @return
     */
    Vector *x(Vector *x, double alfa, Vector *p);
};


#endif //PROGOPTMET_MULTIDIMSEARCH_H
