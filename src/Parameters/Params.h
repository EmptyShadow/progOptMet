//
// Created by Дмитрий on 24.09.2017.
//

#ifndef PROGOPTMET_PARAMS_H
#define PROGOPTMET_PARAMS_H

#include "string"
#include "Flags/LimitingFlags.h"
#include "Input/InputParams.h"
#include "Output/OutputParams.h"

class Params {
public:
    Params();
    ~Params();

    InputParams *input = nullptr; // входные параметры
    OutputParams *output = nullptr; // результат
    LimitingFlags *flags = nullptr; // флаги

    std::string *logs = new std::string("**************\n*****Logs*****\n**************\n"); // логи
    std::string *errs = new std::string("**************\n****Errors****\n**************\n"); // ошибки

    /**
     * Запись построчно в логи
     * @param log
     */
    void writelnInLogs(std::string *log);
    /**
     * Запись построчно в ошибки
     * @param err
     */
    void writelnInErrs(std::string *err);

    /**
     * Преобразование параметров к строке
     * @return
     */
    std::string *toString();
    /**
     * Создание копии объекта
     * @return
     */
    Params *clone();
};


#endif //PROGOPTMET_PARAMS_H
