using System;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src.Parametrs.Input;
using System.Collections.Generic;

namespace MethodsOptimization.src.Parametrs.Output
{
    class OutputParams: ICloneable
    {
        public OutputParams() { }

        /// <summary>
        /// Количество итераций
        /// </summary>
        public int k = 0;

        /// <summary>
        /// Аргумент локального минимума функции
        /// </summary>
        public Vector x_ = new Vector();

        /// <summary>
        /// Минимизированый интервал аргументов
        /// </summary>
        public List<Vector> AB = new List<Vector>();

        /// <summary>
        /// Локальный минимум функции
        /// </summary>
        public double f_x_; // минимум функции

        /// <summary>
        /// Интервал минимизации шага
        /// </summary>
        public Vector alfa = new Vector();

        /// <summary>
        /// Шаг изменения
        /// </summary>
        public double alfa_h;

        /// <summary>
        /// К строке
        /// </summary>
        /// <returns></returns>
        new public string ToString()
        {
            string str = "Output:\n";
            str += "\tk: " + k + ";\n";
            str += "\tx_: " + x_.ToString().Replace("\t", "\t\t");
            str += "\talfa_: " + Alfa_ + "\n";
            str += "\tAB:\n";
            foreach (Vector v in AB)
            {
                str += "\t\t" + v.ToString().Replace("\t", "\t\t\t") + "\n";
            }
            str += "\tf_x_: " + f_x_ + ";\n";
            str += "\talfa: " + alfa.ToString().Replace("\t", "\t\t");
            str += "\talfa_h: " + alfa_h + ";\n";
            return str;
        }

        /// <summary>
        /// Клонировать
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            OutputParams clone = new OutputParams();
            clone.k = k;
            clone.alfa = (Vector)alfa.Clone();
            clone.alfa_h = alfa_h;
            clone.x_ = (Vector)x_.Clone();
            clone.f_x_ = f_x_;
            foreach (Vector ab in AB)
            {
                clone.AB.Add((Vector)ab.Clone());
            }
            return clone;
        }

        public static explicit operator InputParams(OutputParams o)
        {
            InputParams i = new InputParams();
            i.x1 = o.x_;
            i.alfa = o.alfa;
            i.alfa_h = o.alfa_h;
            return i;
        }
        
        public double Alfa_
        {
            get
            {
                if (alfa.Size == 0) return double.NaN;
                double summ = 0.0;
                for (int i = 0; i < alfa.Size; i++)
                {
                    summ += alfa[i];
                }
                return summ / alfa.Size;
            }
        }
    }
}
