#include <limits>
#include "Vector.h"

Vector::Vector() {}

int Vector::size() {
    return vars.size();
}

double Vector::operator[](int i) {
    if (size() <= i) return std::numeric_limits<double>::max();
    return vars[i];
}

void Vector::operator+(Vector &v) {
    int size = size();
    if (size == v.size()) {
        for (int i = 0; i < size; i++) {
            vars[i] += v[i];
        }
    }
}

void Vector::operator+=(Vector &v) {
    this->operator+(v);
}

void Vector::operator-(Vector &v) {
    int size = size();
    if (size == v.size()) {
        for (int i = 0; i < size; i++) {
            vars[i] -= v[i];
        }
    }
}

void Vector::operator-=(Vector &v) {
    this->operator-(v);
}

void Vector::operator*(double a) {
    for (int i = 0; i < size(); ++i) {
        vars[i] *= a;
    }
}

void Vector::operator*=(double a) {
    this->operator*(a);
}

void Vector::operator/(double a) {
    this->operator*(1 / a);
}

void Vector::operator/=(double a) {
    this->operator*(1 / a);
}

double Vector::operator*(Vector &v) {
    int size = size();
    double summ = 0.0;
    if (size == v.size()) {
        for (int i = 0; i < size; ++i) {
            summ += vars[i] * v[i];
        }
    } else {
        summ = std::numeric_limits<double>::max();
    }
    return summ;
}

double Vector::operator*=(Vector &v) {
    return this->operator*(v);
}

void Vector::push(double var) {
    vars.push_back(var);
}