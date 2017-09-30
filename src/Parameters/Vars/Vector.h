//
// Created by Дмитрий on 27.09.2017.
//

#ifndef PROGOPTMET_VECTOR_H
#define PROGOPTMET_VECTOR_H

#include "vector"
#include "string"
#include "math.h"

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
    Vector operator+(Vector);

    /**
     * Разность элементов векторов
     */
    Vector operator-(Vector);

    /**
     * Умножение вектора на скаляр
     */
    Vector operator*(double);

    /**
     * Умножение вектора на скаляр
     */
    Vector operator*=(double);

    /**
     * Деление вектора на скаляр
     */
    Vector operator/(double);

    /**
     * Деление вектора на скаляр
     */
    Vector operator/=(double);

    /**
     * Сложение элементов векторов
     */
    Vector operator+=(Vector);

    /**
     * Разность элементов векторов
     */
    Vector operator-=(Vector);

    /**
     * Скалярное произведение векторов
     */
    double operator*(Vector);

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

    /**
     * Присваивание вектора
     */
    void operator=(std::vector);

    /**
     * присваивание одного элемента
     */
    void operator=(double);

    /**
     * Клонирование вектора
     * @return
     */
    Vector clone();

    /**
     * К виду строки
     * @return
     */
    std::string toString();

    /**
     * Норма веектора
     * @return
     */
    double norma();

    static Vector random(int n, int absMax);

private:
    std::vector<double> vars; // карта переменных
};


#endif //PROGOPTMET_VECTOR_H
