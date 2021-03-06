﻿using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.LinearSearch
{
    abstract class LinSearch: EmptyMethod
    {
        public LinSearch()
        {
            Name = "Метод линейного поиска";
        }

        public override void Add(EmptyMethod m)
        {
            throw new System.NotImplementedException();
        }

        public override EmptyMethod GetMethodByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public override Result Run(Params p)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Метод вычисления функции
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        override protected double F(Vector x, double Alfa, Vector p)
        {
            if (f != null && x != null && p != null)
            {
                return f.Parse(X(x, Alfa, p));
            }
            throw new System.Exception("Ошибка получения значения функции: переданны не установленные данные");
        }

        /// <summary>
        /// Вычисление следующего вектора
        /// </summary>
        /// <param name="x"></param>
        /// <param name="Alfa"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        override protected Vector X(Vector x, double Alfa, Vector p)
        {
            return x + Alfa * p;
        }
    }
}
