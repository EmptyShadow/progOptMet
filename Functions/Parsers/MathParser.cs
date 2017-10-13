using System;
using MethodsOptimization.src.Parametrs.Vars;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MethodsOptimization.src.Functions.Parsers
{
    class MathParser
    {
        /// <summary>
        /// Функция
        /// </summary>
        protected string function = "";
        /// <summary>
        /// Сортированный по названиям переменных список переменных со значениями
        /// </summary>
        SortedDictionary<string, double> varsAndValues = new SortedDictionary<string, double>();
        readonly SortedSet<string> vars = new SortedSet<string>();

        public MathParser(string function)
        {
            // сохраняю функцию без пробелов
            this.function = function.Replace(" ", "");
            // получаю и сохранию множество переменных
            vars = getSetVars(this.function);
        }

        /// <summary>
        /// Получение на чтение списка переменных
        /// </summary>
        public SortedSet<string> Vars
        {
            get
            {
                return vars;
            }
        }

        /// <summary>
        /// Получение сортированного множества переменных функции
        /// </summary>
        /// <param name="func">функция</param>
        /// <returns>Сортированное множество</returns>
        public SortedSet<string> getSetVars(string func)
        {
            // пустое множество для записи
            SortedSet<string> set = new SortedSet<string>();
            string s = func.Substring(0);
            while (s != "")
            {
                string f = "";
                int i = 0;
                // ищем название функции или переменной
                // имя обязательно должна начинаться с буквы
                while (i < s.Length && (Char.IsLetter(s[i]) || (Char.IsDigit(s[i]) && i > 0)))
                {
                    f += s[i];
                    i++;
                }
                if (f != "")
                { // если что-нибудь нашли
                    if (i == s.Length || (s.Length > i && isOperator(s[i])))
                    { // если не скобка, то функция
                        set.Add(f);
                    }
                } else
                {
                    i++;
                }
                if (i != s.Length)
                {
                    s = s.Substring(i);
                } else
                {
                    s = "";
                }
            }
            return set;
        }

        /// <summary>
        /// Символ оператор?
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        bool isOperator(char ch)
        {
            if (ch == '/' || ch == '*' ||
                ch == '-' || ch == '+' || ch == '^')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Разбор функции и вычисление ее значения
        /// </summary>
        /// <param name="values"></param>
        /// <returns>Значение функции или NaN если не 
        /// совместимы переменные и значения</returns>
        public double Parse(Vector values)
        {
            // Проверка совместимости
            if (vars.Count != values.Size)
            {
                return double.NaN;
            }
            // Присвоение значени переменным
            int i = 0;
            varsAndValues.Clear();
            foreach(string key in vars)
            {
                varsAndValues.Add(key, values[i]);
                i++;
            }
            // Запуск разбора
            Result rez = PlusMinus(function);
            // Если остаток функции остался не пустым
            if (rez.rest.Length != 0)
            {
                // то ошибка разбора
                throw new Exception("Error: it is not possible to parse a function;\n" + rez.rest);
            }
            return rez.acc;
        }

        /// <summary>
        /// Разбор ситуации с операциями сложения и вычитания
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        Result PlusMinus(string s)
        {
            // переход на более преоритетные операции умножения и деления
            Result current = MulDiv(s);
            // получаем результат преоритетных операций
            double acc = current.acc;

            // если осталось что парсить
            while (current.rest != "")
            {
                // , то проверяем операции
                // Если сложение или деление
                if (!(current.rest[0] == '+' || current.rest[0] == '-')) break;

                // То сохранием знак операции
                char sign = current.rest[0];
                // получаем подстраку функции справа от операции
                string next = current.rest.Substring(1);

                // получение значения функции правее от операции
                current = MulDiv(next);
                // Если сложение
                if (sign == '+')
                {
                    // ,то складываем
                    acc += current.acc;
                }
                else
                {
                    // , иначе вычитаем
                    acc -= current.acc;
                }
            }
            // возвращаем результат
            return new Result(acc, current.rest);
        }

        /// <summary>
        /// Разбор ситуации с умножение и деленем
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        Result MulDiv(string s)
        {
            // переход к более преоритетным операциям скобкам
            Result current = Degree(s);
            // получение результата в скобках, если они были
            double acc = current.acc;

            // если есть что парсить
            while (current.rest != "")
            {
                // проверяем что это операции деления или умножения
                if (!(current.rest[0] == '*' || current.rest[0] == '/')) break;

                // запоминаем операцию
                char sign = current.rest[0];
                // получаем подстраку функции справа от операции
                string next = current.rest.Substring(1);

                // получение значения функции правее от операции
                current = Degree(next);
                // если опреация деления
                if (sign == '/')
                {
                    //, то делим левое на правое
                    acc /= current.acc;
                }
                else
                {
                    //, иначе перемножаем левое и правое
                    acc *= current.acc;
                }
            }
            // возвращаем результат операции
            return new Result(acc, current.rest);
        }

        /// <summary>
        /// Разбор ситуации с степенью
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        Result Degree(string s)
        {
            // переход к более преоритетным операциям скобкам
            Result current = Bracket(s);
            // получение результата в скобках, если они были
            double acc = current.acc;

            // если есть что парсить
            while (current.rest != "" && current.rest[0] == '^')
            {
                // получаем подстраку функции справа от операции
                string next = current.rest.Substring(1);

                // получение значения функции правее от операции
                if (next[0] == '(')
                {
                    current = Bracket(next);
                } else
                {
                    current = FunctionVariable(next);
                }
                // если опреация степени
                acc = System.Math.Pow(acc, current.acc);
            }
            // возвращаем результат операции
            return new Result(acc, current.rest);
        }

        /// <summary>
        /// Разбор ситуации со скобками
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        Result Bracket(string s)
        {
            // Если встретили скобку
            if (s[0] == '(')
            {
                // то заходим в нее начиная с меньших по преоритету операций
                Result current = PlusMinus(s.Substring(1));
                // Если есть что парсить и есть закрывающая скобка
                if (current.rest != "" && current.rest[0] == ')')
                {
                    // то все хорошо и уменьшаем строку парсинга избавляясь от этой скобки
                    current = new Result(current.acc, current.rest.Substring(1));
                }
                else
                {
                    // иначе ошибка
                    throw new Exception("Error: not close bracket\n" + current.rest);
                }
                // вернуть результат
                return current;
            }
            // иначе мы встретили функцию или переменную
            return FunctionVariable(s);
        }

        /// <summary>
        /// Разбор ситуации с функцией и переменной
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        Result FunctionVariable(string s)
        {
            string f = "";
            int i = 0;
            // ищем название функции или переменной
            // имя обязательно должна начинаться с буквы
            while (i < s.Length && (Char.IsLetter(s[i]) || (Char.IsDigit(s[i]) && i > 0)))
            {
                f += s[i];
                i++;
            }
            if (f != "")
            { // если что-нибудь нашли
                if (s.Length > i && s[i] == '(')
                { // и следующий символ скобка значит - это функция
                    Result r = Bracket(s.Substring(f.Length));
                    return processFunction(f, r);
                }
                else
                { // иначе - это переменная
                    return new Result(getVariable(f), s.Substring(f.Length));
                }
            }
            return Num(s);
        }

        /// <summary>
        /// Получение значения переменной по имени переменной
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        double getVariable(string varName)
        {
            return varsAndValues[varName];
        }

        /// <summary>
        /// Разбор ситуации с числом
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        Result Num(string s)
        {
            int i = 0;
            int dot_cnt = 0;
            bool negative = false;
            // число также может начинаться с минуса
            if (s[0] == '-')
            {
                negative = true;
                s = s.Substring(1);
            }
            // разрешаем только цифры и точку
            while (i < s.Length && (Char.IsDigit(s[i]) || s[i] == '.'))
            {
                // но также проверям, что в числе может быть только одна точка!
                if (s[i] == '.' && ++dot_cnt > 1)
                {
                    throw new Exception("not valid number '" + s.Substring(0, i + 1) + "'");
                }
                i++;
            }
            if (i == 0)
            { // что-либо похожее на число мы не нашли
                throw new Exception("can't get valid number in '" + s + "'");
            }

            // конвертируем строку в число
            double dPart = double.Parse(s.Substring(0, i));
            // учитываем возможноть знака
            if (negative) dPart = -dPart;
            // обрезаем строку парсинга
            string restPart = s.Substring(i);

            return new Result(dPart, restPart);
        }

        /// <summary>
        /// Запуск на исполнение функции
        /// </summary>
        /// <param name="func"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        Result processFunction(string func, Result r)
        {
            // в r учтено, что название функции в нем не присудствует

            const double pi = 3.1415926535897932384626;
            if (func == "sin")
            {
                return new Result(System.Math.Sin(r.acc * pi / 180), r.rest);
            }
            else if (func == "cos")
            {
                return new Result(System.Math.Cos(r.acc * pi / 180), r.rest);
            }
            else if (func == "tg")
            {
                return new Result(System.Math.Tan(r.acc * pi / 180), r.rest);
            }
            else if (func == "ctg")
            {
                return new Result(1.0 / processFunction("tg", r).acc, r.rest);
            }
            else if (func == "exp")
            {
                return new Result(System.Math.Exp(r.acc), r.rest);
            }
            throw new Exception("Error: there is no such function " + func + ";");
        }
    }
}
