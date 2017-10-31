using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Functions
{
    class Math
    {
        /// <summary>
        /// Производная по направлению
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static double DFatXByP(Function f, Vector x, Vector p)
        {
            double eps = 1e-7;
            Vector x2 = x + p * eps;
            return (f.Parse(x2) - f.Parse(x)) / eps;
        }

        /// <summary>
        /// Значение градиента в точке по направлению
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static double GF(Function f, Vector x, Vector p)
        {
            double summ = 0.0;
            Vector g = GF(f, x);
            if (x.Size == p.Size)
            {
                // Берем частные производные по каждой переменной и умножаем на орту
                for (int i = 0; i < x.Size; ++i)
                {
                    summ += g[i] * p[i];
                }
            }
            return summ;
        }

        /// <summary>
        /// Вектор градиента в точке
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector GF(Function f, Vector x)
        {
            Vector g = new Vector();
            // Берем частные производные по каждой переменной
            for (int i = 0; i < x.Size; ++i)
            {
                g.Push(DFatXByIVar(f, x, i));
            }
            return g;
        }

        /// <summary>
        /// Частная производная по numVar-ой переменной
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="numVar"></param>
        /// <returns></returns>
        public static double DFatXByIVar(Function f, Vector x, int numVar)
        {
            double eps = 1e-7;
            Vector x2 = (Vector)x.Clone();
            x2[numVar] += eps;
            return (f.Parse(x2) - f.Parse(x)) / eps;
        }
    }
}
