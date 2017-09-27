#include "ComposerMethods.h"

ComposerMethods::~ComposerMethods() {
    /**
     * Проходим все пары и удаляем указатели на методы
     */
    for (Method *method : listMs) {
        delete method;
    }
}

void ComposerMethods::addMethod(Method *method) {
    /**
     * Если метод определен то вносим его в список с ключем соотв. имени метода
     */
    if (method != nullptr) {
        listMs.push_back(method);
    }
}

Method *ComposerMethods::getMethodByName(std::string name) {
    /**
     * Проходим весь список и ищим ключ с именем поиска
     */
    for (Method *method : listMs) {
        if (!method->name.compare(name)) {
            return method;
        }
    }
    return nullptr;
}

int ComposerMethods::run(Params &params) {
    /**
     * Вызываем все методы из списка в порядке добавления
     */
    int is;
    for (Method *method : listMs) {
        if ((is = method->run(params)) == 1) {
            return 1;
        }
    }
    return 0;
}

std::list<std::string> ComposerMethods::getNamesMethods() {
    std::list<std::string> list;
    for (Method *method : listMs) {
        list.push_back(method->name);
    }
    return list;
}