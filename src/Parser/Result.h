//
// Created by Дмитрий on 30.09.2017.
//

#ifndef PROGOPTMET_RESULT_H
#define PROGOPTMET_RESULT_H

#include "string"

/**
 * Результат текущего этапе парсинга
 */
class Result {
public:
    double acc; // значение функции на текущем этапе
    std::string rest; // остаток функции

    Result(double acc, std::string rest);
};


#endif //PROGOPTMET_RESULT_H
