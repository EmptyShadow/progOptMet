#include "String.h"

void String::replaceAll(std::string &s, char ch, char with) {
    // Если символы совпадают, то ничего не делаем
    if (ch == with) {
        return;
    }

    // проходим по строке и меняем символы
    unsigned int i = 0;
    while (i < s.length()) {
        if (s[i] == ch) {
            // Считаю сколько совпадений с этим символом
            unsigned int t = 1;
            while (s[i + t] == ch) {
                t++;
            }
            // меняю блок символов
            s.replace(i, t, (const char*)&with);
        } else {
            i++;
        }
    }
}

bool String::stringStartAt(std::string s, std::string at) {
    // если строка, в которой проверяется начало, короче
    // предпологаемого начала, то вернуть false
    if (s.length() < at.length()) {
        return false;
    }
    // Сопоставляем символы, если какие то символы не равно то вернуть false
    for (int i = 0; i < at.size(); ++i) {
        if (s[i] != at[i]) {
            return false;
        }
    }
    // если все символы совпали вернуть true
    return true;
}