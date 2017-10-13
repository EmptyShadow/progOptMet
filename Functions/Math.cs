using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs.Vars;

namespace MethodsOptimization.src.Functions
{
    class Math
    {
        public static double DirectionalDerivative(Function f, Vector x, Vector p)
        {
            double eps = 1e-7;
            Vector x2 = x + p * eps;
            return (f.Parse(x2) - f.Parse(x)) / eps;
        }

        public static double Gradient(Function f, Vector x, Vector p)
        {
            double summ = 0.0;
            Vector g = Gradient(f, x);
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

        public static Vector Gradient(Function f, Vector x)
        {
            Vector g = new Vector();
            // Берем частные производные по каждой переменной и умножаем на орту
            for (int i = 0; i < x.Size; ++i)
            {
                g.Push(PartialDerivative(f, x, i));
            }
            return g;
        }

        public static double PartialDerivative(Function f, Vector x, int numVar)
        {
            double eps = 1e-7;
            Vector x2 = x;
            x2[numVar] += eps;
            return (f.Parse(x2) - f.Parse(x)) / eps;
        }

        public static void Swap(ref object a, ref object b)
        {
            object t = a;
            a = b;
            b = t;
        }
    }
}
