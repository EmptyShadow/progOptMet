#include "MathParser.h"
#include "../Func/Func.h"
#include "../String/String.h"
#include "../Parameters/Vars/Vector.h"
#include "math.h"

MathParser::MathParser(Func *func, Vector *params) {
    // Проверка на совпадение размеров
    if (func->vars.size() != params->size()) {
        throw "Error: size variable function != size params";
    }
    // соединение переменных функции и соотв им элементам вектора
    int i = 0;
    for (std::string var: func->vars) {
        vars.insert(std::pair<std::string, double>(var, (*params)[i]));
        i++;
    }
    // сохранение функции в строковом виде
    this->func = func->func.substr(0);
}

std::set<std::string> *MathParser::getSetVars(std::string *func) {
    std::string f = func->substr(0);
    String::removeAll(&f, ' ');
    std::set<std::string> *set = new std::set<std::string>();
    unsigned int i = 0, len = f.length();
    // Проходим функцию в поиске переменных
    while (i < len) {
        // то это может быть переменная или функция
        unsigned int t = i + 1;
        // если нам попался символ
        if (isLetter(f[i])) {
            // идем до конца названия
            while (t < len && (isLetter(f[t] || isDigit(f[t])))) {
                t++;
            }
            // после имени переменной должен идти оператор или ) или конец функции
            if (t < len && (isOperator(f[t]) || f[t] == '(' || t == (len - 1))) {
                // вставляю подстроку - имя переменной в множество
                set->insert(func->substr(i, t - i));
            }
        }
        i = t;
    }
    return set;
}

bool MathParser::isLetter(char ch) {
    if (('a' <= ch && ch <= 'z') || ('A' <= ch && ch <= 'Z')) {
        return true;
    }
    return false;
}

bool MathParser::isDigit(char ch) {
    if ('0' <= ch && ch <= '9') {
        return true;
    }
    return false;
}

bool MathParser::isOperator(char ch) {
    if (ch == '/' || ch == '*' ||
        ch == '-' || ch == '+' || ch == '^') {
        return true;
    }
    return false;
}

double MathParser::parse() throw(std::string*) {
    Result rez = PlusMinus(func);
    // Если остаток функции остался не пустым
    if (!rez.rest.empty()) {
        // то ошибка разбора
        throw "Error: it is not possible to parse a function;";
    }
    return rez.acc;
}

Result MathParser::PlusMinus(std::string s) throw(std::string*) {
    // переход на более преоритетные операции умножения и деления
    Result current = MulDiv(s);
    // получаем результат преоритетных операций
    double acc = current.acc;

    // если осталось что парсить
    while (current.rest.length() > 0) {
        // , то проверяем операции
        // Если сложение или деление
        if (!(current.rest[0] == '+' || current.rest[0] == '-')) break;

        // То сохранием знак операции
        char sign = current.rest[0];
        // получаем подстраку функции справа от операции
        std::string next = current.rest.substr(1);

        // получение значения функции правее от операции
        current = MulDiv(next);
        // Если сложение
        if (sign == '+') {
            // ,то складываем
            acc += current.acc;
        } else {
            // , иначе вычитаем
            acc -= current.acc;
        }
    }
    // возвращаем результат
    return Result(acc, current.rest);
}

Result MathParser::MulDiv(std::string s) throw(std::string*) {
    // переход к более преоритетным операциям скобкам
    Result current = Degree(s);
    // получение результата в скобках, если они были
    double acc = current.acc;

    // если есть что парсить
    while (current.rest.length() > 0) {
        // проверяем что это операции деления или умножения
        if (!(current.rest[0] == '*' || current.rest[0] == '/')) break;

        // запоминаем операцию
        char sign = current.rest[0];
        // получаем подстраку функции справа от операции
        std::string next = current.rest.substr(1);

        // получение значения функции правее от операции
        current = Degree(next);
        // если опреация деления
        if (sign == '/') {
            //, то делим левое на правое
            acc /= current.acc;
        } else {
            //, иначе перемножаем левое и правое
            acc *= current.acc;
        }
    }
    // возвращаем результат операции
    return Result(acc, current.rest);
}

Result MathParser::Bracket(std::string s) throw(std::string*) {
    // Если встретили скобку
    if (s[0] == '(') {
        // то заходим в нее начиная с меньших по преоритету операций
        Result current = PlusMinus(s);
        // Если есть что парсить и есть закрывающая скобка
        if (!current.rest.empty() && current.rest[0] == ')') {
            // то все хорошо и уменьшаем строку парсинга избавляясь от этой скобки
            current.rest = current.rest.substr(1);
        } else {
            // иначе ошибка
            throw "Error: not close bracket";
        }
        // вернуть результат
        return current;
    }
    // иначе мы встретили функцию или переменную
    return FunctionVariable(s);
}

Result MathParser::FunctionVariable(std::string s) throw(std::string*) {
    std::string f = "";
    int i = 0;
    // ищем название функции или переменной
    // имя обязательно должна начинаться с буквы
    while (i < s.length() && (isLetter(s[i]) || (isDigit(s[i]) && i > 0))) {
        f += s[i];
        i++;
    }
    if (!f.empty()) { // если что-нибудь нашли
        if (s.length() > i && s[i] == '(') { // и следующий символ скобка значит - это функция
            Result r = Bracket(s.substr(f.length()));
            return processFunction(f, r);
        } else { // иначе - это переменная
            return Result(getVariable(f), s.substr(f.length()));
        }
    }
    return Num(s);
}

double MathParser::getVariable(std::string varName) throw(std::string*) {
    std::map<std::string, double>::iterator var = vars.find(varName);
    // проверяю существование переменной
    if (var == vars.end()) {
        // если нет то ошибка
        throw "Error: there is no such variable " + varName + ";";
    }
    return var->second;
}

Result MathParser::Num(std::string s) throw(std::string*) {
    unsigned int i = 0;
    int dot_cnt = 0;
    bool negative = false;
    // число также может начинаться с минуса
    if (s[0] == '-') {
        negative = true;
        s = s.substr(1);
    }
    // разрешаем только цифры и точку
    while (i < s.length() && (isDigit(s[i]) || s[i] == '.')) {
        // но также проверям, что в числе может быть только одна точка!
        if (s[i] == '.' && ++dot_cnt > 1) {
            throw new std::string("not valid number '" + s.substr(0, i + 1) + "'");
        }
        i++;
    }
    if (i == 0) { // что-либо похожее на число мы не нашли
        throw new std::string("can't get valid number in '" + s + "'");
    }

    // конвертируем строку в число
    double dPart = std::stod(s.substr(0, i));
    // учитываем возможноть знака
    if (negative) dPart = -dPart;
    // обрезаем строку парсинга
    std::string restPart = s.substr(i);

    return Result(dPart, restPart);
}

Result MathParser::processFunction(std::string func, Result r) {
    // в r учтено, что название функции в нем не присудствует

    const double pi = 3.1415926535897932384626;
    if (String::stringStartAt(&func, "sin")) {
        return Result(sin(r.acc * pi / 180), r.rest);
    } else if (String::stringStartAt(&func, "cos")) {
        return Result(cos(r.acc * pi / 180), r.rest);
    } else if (String::stringStartAt(&func, "tg")) {
        return Result(tan(r.acc * pi / 180), r.rest);
    }else if (String::stringStartAt(&func, "ctg")) {
        return Result(1.0 / processFunction("tg", r).acc, r.rest);
    } else if (String::stringStartAt(&func, "exp")) {
        return Result(exp(r.acc), r.rest);
    }
    throw "Error: there is no such function " + func + ";";
}

Result MathParser::Degree(std::string s) throw(std::string*) {
    // переход к более преоритетным операциям скобкам
    Result current = Bracket(s);
    // получение результата в скобках, если они были
    double acc = current.acc;

    // если есть что парсить
    while (current.rest.length() > 0 && current.rest[0] == '^') {
        // получаем подстраку функции справа от операции
        std::string next = current.rest.substr(1);

        // получение значения функции правее от операции
        current = Bracket(next);
        // если опреация деления
        acc = pow(acc, current.acc);
    }
    // возвращаем результат операции
    return Result(acc, current.rest);
}