//
// Created by Дмитрий on 26.09.2017.
//

#ifndef PROGOPTMET_CORE_H
#define PROGOPTMET_CORE_H

#include "list"

class Params;
class Method;

class Core {
public:
    /**
     * Загрузка ядра
     */
    static void load();

    /**
     * Получить метод одномерного поиска по его имени
     * @param name
     * @return
     */
    static Method *getMODSByName(std::string name);

    /**
     * Получить метод многомерного поиска по его имени
     * @param name
     * @return
     */
    static Method *getMMDSByName(std::string name);

    /**
     * Получить список имен одномерных методов
     * @return
     */
    static std::list<std::string> getNamesListMethodsOneDimSearch();

    /**
     * Получить список имен многомерных методов
     * @return
     */
    static std::list<std::string> getNamesListMethodsMultiDimSearch();

    /**
     * Запустить метод одномерного поиска по имени
     * @param name
     * @param params
     * @return
     */
    static int runMODS(std::string name, Params &params);

    /**
     * Запустить метод многомерного поиска по имени
     * @param name
     * @param params
     * @return
     */
    static int runMMDS(std::string name, Params &params);

private:

    static ComposerMethods oneDimSearch; // одномерные методы
    static ComposerMethods multiDimSearch; // многомерные методы
};


#endif //PROGOPTMET_CORE_H
