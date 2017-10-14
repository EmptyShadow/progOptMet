using System;
using MethodsOptimization.src.Parametrs.Vars;

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
            if (In == null || Out == null) return;
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
            if (Out == null || Out.Alfa.Size == 0) return double.NaN;
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
            if (In == null || In.Alfa.Size == 0) return double.NaN;
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
            if (In == null || Out == null || In.X0 == null || In.P == null || Out.Alfa.Size <= i) return null;
            return In.X0 + Out.Alfa[i] * In.P;
        }

        /// <summary>
        /// Получить аргумент минимума
        /// </summary>
        /// <returns></returns>
        public Vector GetX_ByIn()
        {
            if (In == null || Out == null || In.X0 == null || In.P == null || Out.Alfa.Size == 0) return null;
            double a_ = GetAlfa_ByIn();
            if (a_ == double.NaN) return null;
            return In.X0 + a_ * In.P;
        }
        /// <summary>
        /// Получить аргумент минимума
        /// </summary>
        /// <returns></returns>
        public Vector GetX_ByOut()
        {
            if (In == null || Out == null || In.X0 == null || In.P == null || Out.Alfa.Size == 0) return null;
            double a_ = GetAlfa_ByOut();
            if (a_ == double.NaN) return null;
            return In.X0 + a_ * In.P;
        }
        /// <summary>
        /// Получить минимум функции по 
        /// </summary>
        /// <returns></returns>
        public double F_ByIn()
        {
            Vector x_ = GetX_ByIn();
            if (x_ == null) return double.NaN;
            return In.Y.Parse(x_);
        }
        /// <summary>
        /// Получить минимум функции по 
        /// </summary>
        /// <returns></returns>
        public double F_ByOut()
        {
            Vector x_ = GetX_ByOut();
            if (x_ == null) return double.NaN;
            return In.Y.Parse(x_);
        }

        /// <summary>
        /// Преобразование параметров к строке
        /// </summary>
        /// <returns></returns>
        new public string ToString()
        {
            string str = "Parametrs:\n";
            str += "\t" + In.ToString().Replace("\t", "\t\t");
            str += "\t" + Out.ToString().Replace("\t", "\t\t");
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
