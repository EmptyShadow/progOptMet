using System;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.MethodsGradientDescent
{
    /// <summary>
    /// Класс для работы с сопряженным направлением
    /// </summary>
    class ConjugateDirection
    {
        /// <summary>
        /// метод Даниела
        /// </summary>
        /// <param name="gy_k">градиент на k-ой итерации</param>
        /// <param name="gy_km">градиент на k - 1 -ой итерации</param>
        /// <param name="p_km">направление на k - 1 -ой итерации</param>
        /// <returns></returns>
        public static double MethodDaniel(Vector gy_k, Vector gy_km, Vector p_km)
        {
            return gy_k.Norma * gy_k.Norma / (p_km * gy_km);
        }
        /// <summary>
        /// метод Диксона
        /// </summary>
        /// <param name="gy_k">градиент на k-ой итерации</param>
        /// <param name="gy_km">градиент на k - 1 -ой итерации</param>
        /// <param name="p_km">направление на k - 1 -ой итерации</param>
        /// <returns></returns>
        public static double MethodDicson(Vector gy_k, Vector gy_km, Vector p_km)
        {
            Vector gamma = gy_k - gy_km;
            return (gy_k * gamma) / (p_km * gamma);
        }
        /// <summary>
        /// метод Флетчера Ривса
        /// </summary>
        /// <param name="gy_k"></param>
        /// <param name="gy_km"></param>
        /// <returns></returns>
        public static double MethodFletcherReeves(Vector gy_k, Vector gy_km)
        {
            return (gy_k.Norma * gy_k.Norma) / (gy_km.Norma * gy_km.Norma);
        }
        /// <summary>
        /// метод Полака–Райбера
        /// </summary>
        /// <param name="gy_k"></param>
        /// <param name="gy_km"></param>
        /// <returns></returns>
        public static double MethodPolakRibiere(Vector gy_k, Vector gy_km)
        {
            Vector gamma = gy_k - gy_km;
            return (gy_k * gamma) / gy_km.Norma;
        }
    }
}
