﻿using System;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src.Functions;

namespace MethodsOptimization.src.Parametrs
{
    /// <summary>
    /// Класс хранит в себе входные и выходные данные метода,
    /// так же класс может вычислять дополнительные данные
    /// </summary>
    class Params : ICloneable
    {
        public Params() { }

        public Params(InputParams In)
        {
            this.In = In;
        }

        public Params(InputParams In, OutputParams Out) : this(In)
        {
            this.Out = Out;
        }

        /// <summary>
        /// Входные параметры
        /// </summary>
        public InputParams In { get; set; }
        /// <summary>
        /// Выходные параметры - результат
        /// </summary>
        public OutputParams Out { get; set; }

        /// <summary>
        /// Записать выходные параметры метода во входные, если позволяет флаг
        /// </summary>
        public void WriteOutputInInput()
        {
            if (Out == null) throw new Exception("Ошибка записи выходных параметров во входные параметры: не установленны выходные параметры");
            if (In == null) In = new InputParams();
            In.Alfa = Out.Alfa;
            In.Alfa_h = Out.Alfa_h;
        }
        /// <summary>
        /// Инициализация выходных данных на основе входных данных
        /// </summary>
        /// <returns></returns>
        public void InitOut()
        {
            Out = new OutputParams();
            Out.K = 0;
            Out.Alfa_h = In.Alfa_h;
            if (In.Alfa == null)
            {
                Out.Alfa = new Vector();
            }
            else
            {
                Out.Alfa = (Vector)In.Alfa.Clone();
            }
        }

        /// <summary>
        /// Получить шаг локализации минимума
        /// </summary>
        /// <returns></returns>
        public double GetAlfa_ByOut()
        {
            if (Out == null || Out.Alfa.Size == 0) throw new Exception("Ошибка в получении шага локализации минимума по выходным параметрам: не установленны выходные параметры или не установлен интервал локализации");
            double summ = 0.0;
            for (int i = 0; i < Out.Alfa.Size; i++)
            {
                summ += Out.Alfa[i];
            }
            return summ / Out.Alfa.Size;
        }

        /// <summary>
        /// Получить шаг локализации минимума
        /// </summary>
        /// <returns></returns>
        public double GetAlfa_ByIn()
        {
            if (In == null || In.Alfa.Size == 0) throw new Exception("Ошибка в получении шага локализации минимума по входным параметрам: не установленны входные параметры или не установлен интервал локализации");
            double summ = 0.0;
            for (int i = 0; i < In.Alfa.Size; i++)
            {
                summ += In.Alfa[i];
            }
            return summ / In.Alfa.Size;
        }

        /// <summary>
        /// Получить аргумент минимума по элементу интервала локализации
        /// </summary>
        /// <param name="i">номер элемента из интервала локализации</param>
        /// <returns></returns>
        public Vector GetX_atAlfaI(int i)
        {
            if (In == null || Out == null || In.X0 == null || In.P == null || Out.Alfa.Size <= i)
                throw new Exception("Ошибка получения переменной минимума по точке из интервала локализации выходных параметров:" +
                    " не установленны входные или выходные параметры");
            return In.X0 + Out.Alfa[i] * In.P;
        }

        /// <summary>
        /// Получить аргумент минимума
        /// </summary>
        /// <returns></returns>
        public Vector GetX_ByIn()
        {
            if (In == null || Out == null || In.X0 == null || In.P == null || Out.Alfa.Size == 0)
                throw new Exception("Ошибка получения переменной минимума по входным параметрам:" +
                    " не установленны входные или выходные параметры");
            double a_ = GetAlfa_ByIn();
            return In.X0 + a_ * In.P;
        }
        /// <summary>
        /// Получить аргумент минимума
        /// </summary>
        /// <returns></returns>
        public Vector GetX_ByOut()
        {
            if (In == null || Out == null || In.X0 == null || In.P == null || Out.Alfa.Size == 0)
                throw new Exception("Ошибка получения переменной минимума по выходным параметрам:" +
                    " не установленны входные или выходные параметры");
            double a_ = GetAlfa_ByOut();
            return In.X0 + a_ * In.P;
        }

        public Vector GetX_ByChainAlfaOut()
        {
            Vector x_ = In.X0, agp;
            for (int i = 0; i < Out.Alfa.Size; i++)
            {
                agp = -Functions.Math.GF(In.Y, x_);
                x_ = x_ + Out.Alfa[i] * agp;
            }
            return x_;
        }
        /// <summary>
        /// Получить минимум функции по 
        /// </summary>
        /// <returns></returns>
        public double F_ByIn()
        {
            Vector x_ = GetX_ByIn();
            return In.Y.Parse(x_);
        }
        /// <summary>
        /// Получить минимум функции по 
        /// </summary>
        /// <returns></returns>
        public double F_ByOut()
        {
            Vector x_ = GetX_ByOut();
            return In.Y.Parse(x_);
        }

        /// <summary>
        /// Преобразование параметров к строке
        /// </summary>
        /// <returns></returns>
        new public string ToString()
        {
            string str = "Parametrs:\n";
            if (In != null) str += "\t" + In.ToString().Replace("\t", "\t\t");
            if (Out != null) str += "\t" + Out.ToString().Replace("\t", "\t\t");
            return str;
        }
        /// <summary>
        /// Создание копии объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Params clone = new Params();
            clone.In = (InputParams)In.Clone();
            clone.Out = (OutputParams)Out.Clone();
            return clone;
        }
    }
}
