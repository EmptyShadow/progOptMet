//
// Created by Дмитрий on 27.09.2017.
//

#ifndef PROGOPTMET_VECTOR_H
#define PROGOPTMET_VECTOR_H

#include "vector"

class Vector {
public:
    Vector();

    /***
     * Если в методах перегруженных операций два вектора имеют разный размер,
     * то метод ничего не делает
     */

    /**
     * Сложение элементов векторов
     */
    void operator+(Vector&);

    /**
     * Разность элементов векторов
     */
    void operator-(Vector&);

    /**
     * Умножение вектора на скаляр
     */
    void operator*(double);

    /**
     * Умножение вектора на скаляр
     */
    void operator*=(double);

    /**
     * Деление вектора на скаляр
     */
    void operator/(double);

    /**
     * Деление вектора на скаляр
     */
    void operator/=(double);

    /**
     * Сложение элементов векторов
     */
    void operator+=(Vector&);

    /**
     * Разность элементов векторов
     */
    void operator-=(Vector&);

    /**
     * Скалярное произведение векторов
     */
    double operator*(Vector&);

    /**
     * Скалярное произведение векторов
     */
    double operator*=(Vector&);



    /**
     * Добавление var в конец
     * @param var
     */
    void push(double var);

    /**
     * Размер вектора
     * @return
     */
    int size();

    /**
     * Если выход за пределы вектора, то макс double
     * @param i
     * @return
     */
    double operator[](int i);



private:
    std::vector<double> vars; // карта переменных
};


#endif //PROGOPTMET_VECTOR_H
