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
        /// погрешность по шагу приближения
        /// </summary>
        public double EpsAlfa { get; set; }  = 1e-3;
        /// <summary>
        /// погрешность по аргументу функции
        /// </summary>
        public double EpsX { get; set; } = 1e-3;
        /// <summary>
        /// погрешность по значению функции
        /// </summary>
        public double EpsF { get; set; } = 1e-3;
        /// <summary>
        /// погрешность по норме шага
        /// </summary>
        public double EpsNormaH { get; set; } = 1e-3;
        /// <summary>
        /// погрешность но норме градента
        /// </summary>
        public double EpsNormaGradienta { get; set; } = 1e-3;
        /// <summary>
        /// погрешность по значению градиента
        /// </summary>
        public double EpsGradient { get; set; } = 1e-3;

        public override string ToString()
        {
            String str = "Limiting params:\n" +
                "\tK: " + K + "\n" +
                "\tEpsAlfa: " + EpsAlfa.ToString("G8") + "\n" +
                "\tEpsX: " + EpsX.ToString("G8") + "\n" +
                "\tEpsF: " + EpsF.ToString("G8") + "\n" +
                "\tEpsNormaH: " + EpsNormaH.ToString("G8") + "\n" +
                "\tEpsGradient: " + EpsGradient.ToString("G8") + "\n" +
                "\tEpsNormaGradienta: " + EpsNormaGradienta.ToString("G8") + "\n";
            return str;
        }

        public object Clone()
        {
            LimitingParams clone = new LimitingParams();
            clone.K = K;
            clone.EpsAlfa = EpsAlfa;
            clone.EpsX = EpsX;
            clone.EpsF = EpsF;
            clone.EpsNormaH = EpsNormaH;
            clone.EpsNormaGradienta = EpsNormaGradienta;
            clone.EpsGradient = EpsGradient;
            return clone;
        }
    }
}
