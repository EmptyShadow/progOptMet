#ifndef PROGOPTMET_STRING_H
#define PROGOPTMET_STRING_H

#include "string"

class String {
public:
    /**
     * Замена всех ch в строке s на with
     * @param s
     * @param ch
     * @param with
     */
    static void removeAll(std::string *s, char &&ch);

    /**
     * Сравнение проверка совпадения начала строки s со строкой at
     * @param s
     * @param at
     * @return
     */
    static bool stringStartAt(std::string *s, std::string &&at);
};


#endif //PROGOPTMET_STRING_H
