using System;
using MethodsOptimization.src.Parametrs.Vars;
using System.Collections.Generic;

namespace MethodsOptimization.src.Parametrs
{
    class OutputParams: ICloneable
    {
        public OutputParams() { }

        /// <summary>
        /// Количество итераций
        /// </summary>
        public int K { get; set; } = 0;

        /// <summary>
        /// Интервал минимизации шага
        /// </summary>
        public Vector Alfa { get; set; }

        /// <summary>
        /// Шаг изменения
        /// </summary>
        public double Alfa_h { get; set; }

        /// <summary>
        /// К строке
        /// </summary>
        /// <returns></returns>
        new public string ToString()
        {
            string str = "Output:\n";
            str += "\tK: " + K + ";\n";
            str += "\tAlfa:\n\t" + Alfa.ToString().Replace("\t", "\t\t");
            str += "\tAlfa_h: " + Alfa_h + "\n";
            return str;
        }

        /// <summary>
        /// Клонировать
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            OutputParams clone = new OutputParams();
            clone.K = K;
            clone.Alfa = (Vector)Alfa.Clone();
            clone.Alfa_h = Alfa_h;
            return clone;
        }
    }
}
