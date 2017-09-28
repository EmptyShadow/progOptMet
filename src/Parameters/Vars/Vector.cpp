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

Vector Vector::operator+(Vector v) {
    int size = size();
    Vector summ = this->clone();
    if (size == v.size()) {
        for (int i = 0; i < size; i++) {
            summ[i] += v[i];
        }
    }
    return summ;
}

Vector Vector::operator+=(Vector v) {
    this->operator+(v);
}

Vector Vector::operator-(Vector v) {
    int size = size();
    Vector razn = this->clone();
    if (size == v.size()) {
        for (int i = 0; i < size; i++) {
            razn[i] -= v[i];
        }
    }
    return razn;
}

Vector Vector::operator-=(Vector v) {
    this->operator-(v);
}

Vector Vector::operator*(double a) {
    Vector proz = this->clone();
    for (int i = 0; i < size(); ++i) {
        proz[i] *= a;
    }
    return proz;
}

Vector Vector::operator*=(double a) {
    return this->operator*(a);
}

Vector Vector::operator/(double a) {
    return this->operator*(1 / a);
}

Vector Vector::operator/=(double a) {
    return this->operator*(1 / a);
}

double Vector::operator*(Vector v) {
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

Vector Vector::clone() {
    Vector v;
    for (int i = 0; i < size(); ++i) {
        v.push(vars[i]);
    }
    return v;
}

void Vector::push(double var) {
    vars.push_back(var);
}

void Vector::operator=(std::vector v) {
    for (int i = 0; i < v.size(); ++i) {
        vars.push_back(v[i]);
    }
}

void Vector::operator=(double var) {
    vars.clear();
    vars.push_back(var);
}