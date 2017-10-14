using MethodsOptimization.src.Parametrs.Flags;
using System;

namespace MethodsOptimization.src.Parametrs
{
    /// <summary>
    /// Пораметры ограничений на метод
    /// </summary>
    class LimitingParams: ICloneable
    {
        public LimitingParams() { }

        /// <summary>
        /// ограничение по количеству итераций
        /// </summary>
        public int K { get; set; } = 40;
        /// <summary>
        /// погрешность
        /// </summary>
        public double Eps { get; set; }  = 1e-3;

        /// <summary>
        /// Флаги, обозначающие учитывания тех или иных ограничений
        /// </summary>
        public LimitingFlags Flags { get; set; }

        /// <summary>
        /// Проверка ограничения по количетву итераций,
        /// Если флаги ограничений не установленны, то false
        /// Если флаг ограничения по количеству итераций не установлен, то false
        /// Если ограничение выполняется, то true, иначе false
        /// </summary>
        /// <param name="numIteration"></param>
        /// <returns></returns>
        public bool CheckNumIteration(int numIteration)
        {
            if (Flags == null) return false;
            if (Flags.K == false) return false;
            return numIteration >= K;
        }

        /// <summary>
        /// Проверка числа на погрешность,
        /// Если флаги ограничений не установленны, то false
        /// Если флаг ограничения по количеству итераций не установлен, то false
        /// Если ограничение выполняется, то true, иначе false
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="norma"></param>
        /// <returns></returns>
        public bool CheckEPS(bool flag, double eps)
        {
            if (Flags == null) return false;
            if (flag == false) return false;
            return System.Math.Abs(eps) <= Eps;
        }

        public override string ToString()
        {
            String str = "Limiting params:\n" +
                "\tK: " + K + "\n" +
                "\tEps: " + Eps.ToString("G8") + "\n" +
                "\tFlags\n\t" + Flags.ToString().Replace("\t", "\t\t");
            return str;
        }

        public object Clone()
        {
            LimitingParams clone = new LimitingParams();
            clone.K = K;
            clone.Eps = Eps;
            clone.Flags = (LimitingFlags)Flags.Clone();
            return clone;
        }
    }
}
