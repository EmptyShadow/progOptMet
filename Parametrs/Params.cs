using System;
using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Methods;

namespace MethodsOptimization.src.Parametrs
{
    /// <summary>
    /// Класс хранит в себе входные и выходные данные метода,
    /// так же класс может вычислять дополнительные данные
    /// </summary>
    public class Params : ICloneable
    {
        public Params() { }

        /// <summary>
        /// Стартовая точка
        /// </summary>
        public Vector X0 { get; set; }

        /// <summary>
        /// Направление
        /// </summary>
        public Vector P { get; set; }

        /// <summary>
        /// Вектор значений коэффициентов альфа
        /// </summary>
        public Vector Alfa { get; set; } = new Vector();

        /// <summary>
        /// Шаг изменения величин
        /// </summary>
        public double H { get; set; } = 1e-3;

        /// <summary>
        /// Исследуемая функция
        /// </summary>
        public Function Y { get; set; }

        public void UpdateByResult(Result result)
        {
            if (result.ListX != null && result.ListX.Count != 0)
            {
                X0 = (Vector)result.ListX[result.ListX.Count - 1]?.Clone();
            }
            if (result.ListP != null && result.ListP.Count != 0)
            {
                P = (Vector)result.ListP[result.ListP.Count - 1]?.Clone();
            }
            Alfa = (Vector)result.Alfas.Clone();
        }

        /// <summary>
        /// Получить экземпляр результат по параметрам
        /// </summary>
        /// <returns></returns>
        public Result ToResult()
        {
            Result result = new Result();
            result.ListX.Add((Vector)X0.Clone());
            if (P != null) result.ListP.Add((Vector)P.Clone());
            result.Alfas = (Vector)Alfa.Clone();
            return result;
        }

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
            str += "\tH: " + H + ";\n";
            if (Y != null) str += "\tFunction: " + Y.ToString().Replace("\t", "\t\t") + ";\n";
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
            clone.H = H;
            clone.Y = Y;
            return clone;
        }
    }
}
