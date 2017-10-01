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
    static void replaceAll(std::string &s, char ch, char with);

    static bool stringStartAt(std::string s, std::string at);
};


#endif //PROGOPTMET_STRING_H
