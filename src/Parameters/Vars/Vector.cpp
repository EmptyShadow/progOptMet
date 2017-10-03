#include <limits>
#include "Vector.h"
#include "math.h"

Vector::Vector() {}

Vector::~Vector() {}

int Vector::size() {
    return vars.size();
}

double Vector::operator[](int i) {
    if (size() <= i) return std::numeric_limits<double>::max();
    return vars[i];
}

Vector Vector::operator+(Vector &&v) {
    int count = size();
    Vector summ = *(this->clone());
    if (count == v.size()) {
        for (int i = 0; i < count; i++) {
            summ.setAt(i, summ[i] + v[i]);
        }
    }
    return summ;
}

Vector Vector::operator+=(Vector &&v) {
    return this->operator+(std::move(v));
}

Vector Vector::operator-(Vector &&v) {
    int count = size();
    Vector razn = *(this->clone());
    if (count == v.size()) {
        for (int i = 0; i < count; i++) {
            razn.setAt(i, razn[i] - v[i]);
        }
    }
    return razn;
}

Vector Vector::operator-=(Vector &&v) {
    this->operator-(std::move(v));
}

Vector Vector::operator*(double a) {
    Vector proz = *(this->clone());
    for (int i = 0; i < size(); ++i) {
        proz.setAt(i, proz[i] * a);
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

double Vector::operator*(Vector &&v) {
    int coutn = size();
    double summ = 0.0;
    if (coutn == v.size()) {
        for (int i = 0; i < coutn; ++i) {
            summ += vars[i] * v[i];
        }
    } else {
        summ = std::numeric_limits<double>::max();
    }
    return summ;
}

Vector *Vector::clone() {
    Vector *v = new Vector();
    for (int i = 0; i < size(); ++i) {
        v->push(vars[i]);
    }
    return v;
}

void Vector::push(double var) {
    vars.push_back(var);
}

void Vector::operator=(double var) {
    vars.clear();
    vars.push_back(var);
}

std::string *Vector::toString() {
    std::string *str = new std::string("Vector:");
    char number[15];

    for (int i = 0; i < size(); ++i) {
        sprintf(number, " %0.10f", vars[i]);
        (*str) += number;
    }
    return str;
}

double Vector::norma() {
    if (vars.size() == 0) return 0.0;
    if (vars.size() == 1) return vars[0];

    double norm = 0.0;
    for (int i = 0; i < size(); ++i) {
        norm += vars[0] * vars[0];
    }

    return sqrt(norm);
}

Vector *Vector::random(int n, int absMax) {
    Vector *v = new Vector();
    for (int i = 0; i < n; ++i) {
        v->push(rand() % ((absMax + 1) * 2) - absMax);
    }
    return v;
}

Vector *Vector::getZeroBeside(int n, int i) {
    Vector *v = new Vector();
    for (int j = 0; j < n; ++j) {
        if (j != i) {
            v->push(0);
        } else {
            v->push(1);
        }
    }
    return v;
}

void Vector::setAt(int i, double val) {
    if (i < size()) {
        vars[i] = val;
    }
}