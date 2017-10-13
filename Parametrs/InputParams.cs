using System;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src.Functions;

namespace MethodsOptimization.src.Parametrs.Input
{
    class InputParams: ICloneable
    {
        public InputParams() {}

        /// <summary>
        /// ограничение по количеству итераций
        /// </summary>
        public int m = 40;
        /// <summary>
        /// стартовая точка
        /// </summary>
        public Vector x1 = new Vector();
        /// <summary>
        /// начальное направление
        /// </summary>
        public Vector p = new Vector();
        /// <summary>
        /// интервал минимизации шага локализации
        /// </summary>
        public Vector alfa = new Vector();
        /// <summary>
        /// шаг изменения шага приближения к локальному минимуму
        /// </summary>
        public double alfa_h = 0.01;
        /// <summary>
        /// Иследуемая функция
        /// </summary>
        public Function y = null;
        /// <summary>
        /// погрешность по аргументам
        /// </summary>
        public double eps_arg = 1e-3;
        /// <summary>
        /// погрешнасть по значениям функции
        /// </summary>
        public double eps_f = 1e-3;

        /// <summary>
        /// Привести к строке
        /// </summary>
        /// <returns></returns>
        new public string ToString()
        {
            string str = "Input:\n";
            str += "\tm: " + m + ";\n";
            str += "\tx1: " + x1.ToString().Replace("\t", "\t\t");
            str += "\tp: " + p.ToString().Replace("\t", "\t\t");
            str += "\talfa_: " + Alfa_ + "\n";
            str += "\talfa: " + alfa.ToString().Replace("\t", "\t\t");
            str += "\talfa_h: " + alfa_h + ";\n";
            str += "\teps_arg: " + eps_arg + ";\n";
            str += "\teps_f: " + eps_f + ";\n";
            str += "\tFunction: " + y.ToString().Replace("\t", "\t\t") + "\n";

            return str;
        }

        /// <summary>
        /// Получить дубликат
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            InputParams clone = new InputParams();
            clone.alfa = (Vector)alfa.Clone();
            clone.alfa_h = alfa_h;
            clone.eps_arg = eps_arg;
            clone.eps_f = eps_f;
            clone.m = m;
            clone.p = (Vector)p.Clone();
            clone.x1 = (Vector)x1.Clone();
            clone.y = y;
            return clone;
        }

        public double Alfa_
        {
            get
            {
                if (alfa.Size == 0) return double.NaN;
                double summ = 0.0;
                for(int i = 0; i < alfa.Size; i++)
                {
                    summ += alfa[i];
                }
                return summ / alfa.Size;
            }
        }
    }
}
