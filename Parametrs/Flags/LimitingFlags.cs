using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Parametrs.Flags
{
    class LimitingFlags : ICloneable
    {
        public LimitingFlags() { }

        /// <summary>
        /// вычисление цепочкой, если false, то входные параметры изменяться не будут
        /// </summary>
        bool hainComputing = false;
        /// <summary>
        /// ограничение по погрешности аргументов
        /// </summary>
        bool eps_arg = true;
        /// <summary>
        /// ограничение по погрешности значений функции
        /// </summary>
        bool eps_f = true;
        /// <summary>
        /// ограничение по количеству итераций
        /// </summary>
        bool m = false;

        /// <summary>
        /// Преобразование к строке
        /// </summary>
        /// <returns>Строка флагов</returns>
        new public string ToString()
        {
            string str = "Limiting Flags:\n";
            str += "\thainComputing: " + hainComputing + ";\n";
            str += "\teps_arg: " + eps_arg + ";\n";
            str += "\teps_f: " + eps_f + ";\n";
            str += "\tm: " + m + ";\n";
            return str;
        }
        /// <summary>
        /// вычисление цепочкой, если false, то входные параметры изменяться не будут
        /// </summary>
        public bool HainComputing
        {
            get
            {
                return hainComputing;
            }
            set
            {
                hainComputing = value;
            }
        }
        /// <summary>
        /// ограничение по погрешности аргументов
        /// </summary>
        public bool EpsArg
        {
            get
            {
                return eps_arg;
            }
            set
            {
                eps_arg = value;
            }
        }
        /// <summary>
        /// ограничение по погрешности значений функции
        /// </summary>
        public bool EpsF
        {
            get
            {
                return eps_f;
            }
            set
            {
                eps_f = value;
            }
        }
        /// <summary>
        /// ограничение по количеству итераций
        /// </summary>
        public bool M
        {
            get
            {
                return m;
            }
            set
            {
                m = value;
            }
        }

        /// <summary>
        /// Копирование экземпляра
        /// </summary>
        /// <returns>Копия экземпляра</returns>
        public object Clone()
        {
            LimitingFlags clone = new LimitingFlags();
            clone.HainComputing = hainComputing;
            clone.M = m;
            clone.EpsArg = eps_arg;
            clone.eps_f = eps_f;
            return clone;
        }
    }
}
