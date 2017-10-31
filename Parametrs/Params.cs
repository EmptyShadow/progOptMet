using System;
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
        /// <summary>
        /// стартовая точка
        /// </summary>
        public Vector X0 { get; set; }
        /// <summary>
        /// начальное направление
        /// </summary>
        public Vector P { get; set; }
        /// <summary>
        /// начальный интервал локализации минимума
        /// </summary>
        public Vector Alfa { get; set; }
        /// <summary>
        /// шаг изменения интервала локализации
        /// </summary>
        public double Alfa_h { get; set; } = 1e-2;
        /// <summary>
        /// Коэффициент ускорения
        /// </summary>
        public double B { get; set; } = 10;
        /// <summary>
        /// Иследуемая функция
        /// </summary>
        public Function Y { get; set; }
        /// <summary>
        /// Количество итераций
        /// </summary>
        public int K { get; set; } = 1;
        /// <summary>
        /// Ограничения
        /// </summary>
        public LimitingParams Lim { get; set; }

        /// <summary>
        /// Привести к строке
        /// </summary>
        /// <returns></returns>
        new public string ToString()
        {
            string str = "";
            if (X0 != null) str += "\tX0: " + X0.ToString().Replace("\t", "\t\t");
            if (P != null) str += "\tP: " + P.ToString().Replace("\t", "\t\t");
            if (Alfa != null) str += "\tAlfa: " + Alfa.ToString().Replace("\t", "\t\t");
            str += "\tAlfa_h: " + Alfa_h + ";\n";
            str += "\tB: " + B + ";\n";
            if (Y != null) str += "\tFunction: " + Y.ToString().Replace("\t", "\t\t");
            if (Y != null) str += "\tK: " + K + ";\n";
            if (Lim != null) str += "\tLimiting params: " + Lim.ToString().Replace("\t", "\t\t");
            return str;
        }

        /// <summary>
        /// Получить дубликат
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Params clone = new Params();
            if (X0 != null) clone.X0 = (Vector)X0.Clone();
            if (P != null) clone.P = (Vector)P.Clone();
            if (Alfa != null) clone.Alfa = (Vector)Alfa.Clone();
            clone.Alfa_h = Alfa_h;
            clone.B = B;
            clone.Y = Y;
            if (Lim != null) clone.Lim = (LimitingParams)Lim.Clone();
            return clone;
        }

        /// <summary>
        /// Получить шаг локализации минимума
        /// </summary>
        /// <returns></returns>
        public double GetAlfa_()
        {
            if (Alfa == null || Alfa.Size == 0) throw new Exception("Ошибка в получении шага локализации минимума по входным параметрам: не установлен интервал локализации");
            double summ = 0.0;
            for (int i = 0; i < Alfa.Size; i++)
            {
                summ += Alfa[i];
            }
            return summ / Alfa.Size;
        }

        /// <summary>
        /// Получить аргумент минимума по элементу интервала локализации
        /// </summary>
        /// <param name="i">номер элемента из интервала локализации</param>
        /// <returns></returns>
        public Vector GetX_ByAlfaI(int i)
        {
            if (Alfa == null || Alfa.Size <= i)
                throw new Exception("Ошибка получения переменной минимума по точке из интервала локализации выходных параметров:" +
                    " не установленн интервал локализации или выход за пределы интервала");
            return X0 + Alfa[i] * P;
        }

        /// <summary>
        /// Получить аргумент минимума
        /// </summary>
        /// <returns></returns>
        public Vector GetX_()
        {
            if (Alfa == null || Alfa.Size == 0)
                throw new Exception("Ошибка получения переменной минимума по точке из интервала локализации выходных параметров:" +
                    " не установленн интервал локализации");
            double a_ = GetAlfa_();
            return X0 + a_ * P;
        }

        public Vector GetX_ByAlfas()
        {
            if (Alfa == null || Alfa.Size == 0)
                throw new Exception("Ошибка получения переменной минимума по точке из интервала локализации выходных параметров:" +
                    " не установленн интервал локализации");
            Vector x_ = X0, agp;
            for (int i = 0; i < Alfa.Size; i++)
            {
                agp = -Functions.Math.GF(Y, x_);
                x_ = x_ + Alfa[i] * agp;
            }
            return x_;
        }
        /// <summary>
        /// Получить минимум функции по 
        /// </summary>
        /// <returns></returns>
        public double F_()
        {
            Vector x_ = GetX_();
            return Y.Parse(x_);
        }
    }
}
