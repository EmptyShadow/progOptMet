using System;

namespace MethodsOptimization.src.Parametrs
{
    /// <summary>
    /// Пораметры ограничений на метод
    /// </summary>
    public class LimParams : ICloneable
    {
        public LimParams() { }

        /// <summary>
        /// ограничение по количеству итераций
        /// </summary>
        public int K { get; set; } = 50;
        /// <summary>
        /// погрешность по шагу приближения
        /// </summary>
        public double Eps { get; set; } = 1e-5;

        /// <summary>
        /// Число меньше Eps
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool CheckMinEps(double a)
        {
            return System.Math.Abs(a) <= Eps;
        }

        /// <summary>
        /// Разность меньше Eps
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool CheckMinEps(double a, double b)
        {
            return System.Math.Abs(a - b) <= Eps;
        }

        /// <summary>
        /// Длна вектора меньше Eps
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool CheckNorma(Vector v)
        {
            return v.Norma <= Eps;
        }

        /// <summary>
        /// Разность меньше Eps
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool CheckMinEps(Vector a, Vector b)
        {
            return CheckNorma(a - b);
        }

        public override string ToString()
        {
            String str = "K: " + K + ";" +
                "Eps: " + Eps.ToString("G8") + ";";
            return str;
        }

        public object Clone()
        {
            LimParams clone = new LimParams();
            clone.K = K;
            clone.Eps = Eps;
            return clone;
        }
    }
}