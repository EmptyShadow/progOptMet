﻿using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;

namespace MethodsOptimization.src.Methods
{
    /// <summary>
    /// Пустой метод для наследования и частичной реализации
    /// </summary>
    abstract class EmptyMethod
    {
        /// <summary>
        /// Имя метода
        /// </summary>
        protected string name = "Empty method";

        /// <summary>
        /// Функция с которой работаем
        /// </summary>
        protected Function f;

        public EmptyMethod() { }

        /// <summary>
        /// Запуск на исполнение метода, который может вызывать один или несколько методов
        /// </summary>
        /// <param name="parametrs"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        abstract public double Run(ref Params parametrs, EmptyMethod m = null);

        /// <summary>
        /// Метод вычисления функции
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        abstract protected double F(Vector x, double Alfa = 0.0, Vector p = null);

        /// <summary>
        /// Получение следующего вектора
        /// </summary>
        /// <param name="x"></param>
        /// <param name="Alfa"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        abstract protected Vector X(Vector x, double Alfa = 0.0, Vector p = null);

        virtual public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Получение метода по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        abstract public EmptyMethod GetMethodByName(string name);

        /// <summary>
        /// Добавление метода в компановщик
        /// </summary>
        /// <param name="m"></param>
        abstract public void Add(EmptyMethod m);

        new virtual public string ToString()
        {
            return "Method: " + name + "\n";
        }

        /// <summary>
        /// Производная в отчке по направлению
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        virtual protected double dF(Vector x, Vector p)
        {
            return Math.DFatXByP(f, x, p);
        }

        virtual protected double DFatXByIVar(Vector x, int num)
        {
            return Math.DFatXByIVar(f, x, num);
        }

        virtual protected double GdF(Vector x, Vector p)
        {
            return Math.GF(f, x, p);
        }

        virtual protected Vector GdF(Vector x)
        {
            return Math.GF(f, x);
        }

        /// <summary>
        /// Критерий окончания поиска для метода
        /// </summary>
        /// <param name="In"></param>
        /// <param name="Out"></param>
        /// <returns></returns>
        abstract protected bool SEC(InputParams In, OutputParams Out);
    }
}
