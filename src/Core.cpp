#include "Core.h"

// первичная инициализация статичных переменных
ComposerMethods Core::oneDimSearch = ComposerMethods();
ComposerMethods Core::multiDimSearch = ComposerMethods();

void Core::load() {
    // При каждом новом старте поля ядра отчищаются
    oneDimSearch = ComposerMethods();
    multiDimSearch = ComposerMethods();
    // Заполнение ядра данными
    // Заполнение методов одномерного поиска
    oneDimSearch.addMethod(new Swenn());
    oneDimSearch.addMethod(new Dichotomy());
    oneDimSearch.addMethod(new GoldenSection1());
    oneDimSearch.addMethod(new GoldenSection2());
    oneDimSearch.addMethod(new Fibonacci1());
    oneDimSearch.addMethod(new Fibonacci2());
}

std::list<std::string> Core::getNamesListMethodsMultiDimSearch() {
    return multiDimSearch.getNamesMethods();
}

std::list<std::string> Core::getNamesListMethodsOneDimSearch() {
    return oneDimSearch.getNamesMethods();
}

Method* Core::getMMDSByName(std::string name) {
    return multiDimSearch.getMethodByName(name);
}

Method* Core::getMODSByName(std::string name) {
    return oneDimSearch.getMethodByName(name);
}

int Core::runMODS(std::string name, Params &params) {
    return getMODSByName(name)->run(params);
}

int Core::runMMDS(std::string name, Params &params) {
    return getMMDSByName(name)->run(params);
}