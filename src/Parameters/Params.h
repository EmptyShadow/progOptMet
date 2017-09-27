//
// Created by Дмитрий on 24.09.2017.
//

#ifndef PROGOPTMET_PARAMS_H
#define PROGOPTMET_PARAMS_H

#include "flags/LimitingFlags.h"
#include "input/InputParams.h"
#include "output/OutputParams.h"
#include "string"

class Params {
public:
    Params();
    ~Params();

    InputParams input; // входные параметры
    OutputParams output; // результат
    LimitingFlags flags; // флаги

    std::string logs = "**************\n*****Logs*****\n**************\n"; // логи
    std::string errs = "**************\n****Errors****\n**************\n"; // ошибки

    /**
     * Запись построчно в логи
     * @param log
     */
    void writelnInLogs(std::string log);
    /**
     * Запись построчно в ошибки
     * @param err
     */
    void writelnInErrs(std::string err);

    /**
     * Преобразование параметров к строке
     * @return
     */
    std::string toString();
    /**
     * Создание копии объекта
     * @return
     */
    Params clone();
};


#endif //PROGOPTMET_PARAMS_H
