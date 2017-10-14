using System;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src.Functions;

namespace MethodsOptimization.src.Parametrs
{
    /// <summary>
    /// Входные данные
    /// </summary>
    class InputParams: ICloneable
    {
        public InputParams() {}
        
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
        /// Ограничения
        /// </summary>
        public LimitingParams Lim { get; set; }

        /// <summary>
        /// Привести к строке
        /// </summary>
        /// <returns></returns>
        new public string ToString()
        {
            string str = "Input:\n";
            if (X0 != null) str += "\tX0: " + X0.ToString().Replace("\t", "\t\t");
            if (P != null) str += "\tP: " + P.ToString().Replace("\t", "\t\t");
            if (Alfa != null) str += "\tAlfa: " + Alfa.ToString().Replace("\t", "\t\t");
            str += "\tAlfa_h: " + Alfa_h + ";\n";
            str += "\tB: " + B + ";\n";
            if (Y != null) str += "\tFunction: " + Y.ToString().Replace("\t", "\t\t");
            if (Lim != null) str += "\tLimiting params: " + Lim.ToString().Replace("\t", "\t\t");
            return str;
        }

        /// <summary>
        /// Получить дубликат
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            InputParams clone = new InputParams();
            clone.X0 = (Vector)X0.Clone();
            clone.P = (Vector)P.Clone();
            clone.Alfa = (Vector)Alfa.Clone();
            clone.Alfa_h = Alfa_h;
            clone.B = B;
            clone.Y = Y;
            clone.Lim = (LimitingParams)Lim.Clone();
            return clone;
        }
    }
}
