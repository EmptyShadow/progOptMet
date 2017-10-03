#include "String.h"
#include "algorithm"

void String::removeAll(std::string *s, char &&ch) {
    // проходим по строке и меняем символы
    unsigned int i = 0;
    while (i < s->length()) {
        if (s->at(i) == ch) {
            // Считаю сколько совпадений с этим символом
            unsigned int t = 1;
            while (s->at(i + t) == ch) {
                t++;
            }
            // меняю блок символов
            s->erase(i, t);
        } else {
            i++;
        }
    }
}

bool String::stringStartAt(std::string *s, std::string &&at) {
    // если строка, в которой проверяется начало, короче
    // предпологаемого начала, то вернуть false
    if (s->length() < at.length()) {
        return false;
    }
    // Сопоставляем символы, если какие то символы не равно то вернуть false
    for (int i = 0; i < at.size(); ++i) {
        if (s->at(i) != at.at(i)) {
            return false;
        }
    }
    // если все символы совпали вернуть true
    return true;
}