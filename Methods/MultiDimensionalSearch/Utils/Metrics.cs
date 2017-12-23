using MethodsOptimization.src.Parametrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch.Utils
{
    /// <summary>
    /// Метрики
    /// </summary>
    class Metrics
    {
        /// <summary>
        /// Делегат функций переменной метрики
        /// </summary>
        /// <param name="Akm"></param>
        /// <param name="gammak"></param>
        /// <param name="skm"></param>
        /// <param name="deltaXkm"></param>
        /// <returns></returns>
        public delegate Matrix CallbackMetric(Matrix Akm, Vector gammak, Vector skm, Vector deltaXkm);

        /// <summary>
        /// Запустить метрику
        /// </summary>
        public static CallbackMetric RunMetric = /*Broyden;*/DavidonFletcherPowell;

        public static Matrix DavidonFletcherPowell(Matrix Akm, Vector gammak, Vector skm, Vector deltaXkm)
        {
            Matrix A = Akm + (Matrix.ToMatrixColumn(deltaXkm) * Matrix.ToMatrixRow(deltaXkm)) / (deltaXkm * gammak) - (Matrix.ToMatrixColumn(skm) * Matrix.ToMatrixRow(skm)) / (skm * gammak);
            return A;
        }

        public static Matrix Broyden(Matrix Akm, Vector gammak, Vector skm, Vector deltaXkm)
        {
            Vector razn = deltaXkm - skm;
            Matrix A = Akm + (Matrix.ToMatrixColumn(razn) * Matrix.ToMatrixRow(razn)) / (razn * gammak);
            return A;
        }
    }
}
