using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Functions;
using System;

namespace MethodsOptimization.src.Methods
{
    /// <summary>
    /// Критерии окончания поиска
    /// </summary>
    class CheckingCriterion
    {
        /// <summary>
        /// Параметры с которыми работает проверяющий критерии
        /// </summary>
        private Params P{ get; set; }
        
        public CheckingCriterion(ref Params p)
        {
            if (p == null) throw new Exception("SearchEndingCriterion Ошибка: переданны не установленные данные");
            if (p.Lim == null) throw new Exception("SearchEndingCriterion Ошибка: не установенны параметры ограничения");
            P = p;
        }

        /// <summary>
        /// Проверка критерия по номеру итерации
        /// </summary>
        /// <returns>currentK >= limK return true</returns>
        public bool CheckNumIterat()
        {
            return P.K >= P.Lim.K;
        }

        /// <summary>
        /// Проверка критерия по шагу приближения
        /// </summary>
        /// <returns>Arg1 - Arg2 <= EpsArg return true</returns>
        public bool CheckAlfa()
        {
            return System.Math.Abs(P.Alfa.First - P.Alfa.Last) <= P.Lim.EpsAlfa;
        }
        /// <summary>
        /// Проверка критерия по шагу приближения
        /// </summary>
        /// <param name="alfa1"></param>
        /// <param name="alfa2"></param>
        /// <returns></returns>
        public bool CheckAlfa(double alfa1, double alfa2)
        {
            return System.Math.Abs(alfa1 - alfa2) <= P.Lim.EpsAlfa;
        }
        /// <summary>
        /// Проверка критерия по длине шага до следующей точки
        /// </summary>
        /// <returns></returns>
        public bool CheckNormaH()
        {
            bool rez = false;
            for (int i = 0; i < P.Alfa.Size && !rez; i++)
            {
                rez |= (P.Alfa[i] * P.P).Norma <= P.Lim.EpsNormaH;
            }
            return rez;
        }

        /// <summary>
        /// Проверка критерия по длине шага до следующей точки
        /// </summary>
        /// <param name="alfas"></param>
        /// <returns></returns>
        public bool CheckNormaH(Vector alfas)
        {
            bool rez = false;
            for (int i = 0; i < alfas.Size && !rez; i++)
            {
                rez |= (alfas[i] * P.P).Norma <= P.Lim.EpsNormaH;
            }
            return rez;
        }

        /// <summary>
        /// Проверка критерия по длине шага до следующей точки
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool CheckNormaH(double value)
        {
            return value <= P.Lim.EpsNormaH;
        }
        /// <summary>
        /// Проверка критерия по значению функции
        /// </summary>
        /// <returns></returns>
        public bool CheckF()
        {
            Vector a = P.X0 + P.Alfa.First * P.P;
            Vector b = P.X0 + P.Alfa.Last * P.P;
            double f1 = P.Y.Parse(a), f2 = P.Y.Parse(b);
            return System.Math.Abs(f1 - f2) <= P.Lim.EpsF;
        }
        /// <summary>
        /// Проверка критерия по значению функции
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool CheckF(Vector a, Vector b)
        {
            double f1 = P.Y.Parse(a), f2 = P.Y.Parse(b);
            return System.Math.Abs(f1 - f2) <= P.Lim.EpsF;
        }
        /// <summary>
        /// Проверка критерия по аргументам функции
        /// </summary>
        /// <returns></returns>
        public bool CheckX()
        {
            Vector a = P.X0 + P.Alfa.First * P.P;
            Vector b = P.X0 + P.Alfa.Last * P.P;
            return (a - b).Norma <= P.Lim.EpsX;
        }
        /// <summary>
        /// Проверка критерия по аргементам функции
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool CheckX(Vector a, Vector b)
        {
            return (a - b).Norma <= P.Lim.EpsX;
        }

        /// <summary>
        /// Проверка погрешности градиента
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool CheckGF()
        {
            return Functions.Math.GF(P.Y, P.X0, P.P) <= P.Lim.EpsGradient;
        }
        /// <summary>
        /// Проверка погрешности градиента
        /// </summary>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool CheckGF(Vector x, Vector p)
        {
            return Functions.Math.GF(P.Y, x, p) <= P.Lim.EpsGradient;
        }
        /// <summary>
        /// Проверка погрешности градиента
        /// </summary>
        /// <param name="gf"></param>
        /// <returns></returns>
        public bool CheckGF(double gf)
        {
            return System.Math.Abs(gf) <= P.Lim.EpsGradient;
        }

        /// <summary>
        /// Проверка погрешности по норме градиента
        /// </summary>
        /// <returns></returns>
        public bool CheckNormaGF()
        {
            return Functions.Math.GF(P.Y, P.X0).Norma <= P.Lim.EpsNormaGradienta;
        }
        /// <summary>
        /// Проверка погрешности по норме градиента
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool CheckNormaGF(Vector x)
        {
            return Functions.Math.GF(P.Y, x).Norma <= P.Lim.EpsNormaGradienta;
        }
    }
}
