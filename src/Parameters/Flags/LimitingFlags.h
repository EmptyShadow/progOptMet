//
// Created by Дмитрий on 24.09.2017.
//

#ifndef PROGOPTMET_LIMITINGFLAGS_H
#define PROGOPTMET_LIMITINGFLAGS_H

#include "string"

class LimitingFlags {
public:
    LimitingFlags();
    ~LimitingFlags();

    bool hainComputing = false; // вычисление цепочкой, если false, то входные параметры изменяться не будут
    bool eps_arg = true; // ограничение по погрешности аргументов
    bool eps_f = true; // ограничение по погрешности значений функции
    bool m = false; // ограничение по количеству итераций
    std::string *toString();
    LimitingFlags *clone();
};


#endif //PROGOPTMET_LIMITINGFLAGS_H
