//
// Created by Дмитрий on 25.09.2017.
//

#ifndef PROGOPTMET_COMPOSERMETHODS_H
#define PROGOPTMET_COMPOSERMETHODS_H

#include "../Method.h"
#include "string"
#include "list"

/**
 * Компановщик методов
 */

class ComposerMethods : public Method {
public:
    /**
     * Добавить метод в компановщик
     * @param method
     */
    void addMethod(Method *method);

    /**
     * Получить метод по имени
     * @param name
     * @return
     */
    Method *getMethodByName(std::string name);

    /**
     * Запустить все методы на исполнение
     * @param params
     * @return
     */
    int run(Params &params);

    /**
     * Отчистить методы
     */
    ~ComposerMethods();

    std::list<std::string> getNamesMethods();

private:
    std::list<Method *> listMs; // скомпонованные методы
};


#endif //PROGOPTMET_COMPOSERMETHODS_H
