using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class MultiDimSearch: EmptyMethod
    {
        public MultiDimSearch()
        {
            name = "MultiDimensionalSearch";
        }
        
        /// <summary>
        /// Метод вычисления функции
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        override protected double F(Vector x, double Alfa, Vector p)
        {
            if (f != null && x != null && p != null)
            {
                return f.Parse(X(x, Alfa, p));
            }
            return double.NaN;
        }

        /// <summary>
        /// Вычисление следующего вектора
        /// </summary>
        /// <param name="x"></param>
        /// <param name="Alfa"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        override protected Vector X(Vector x, double Alfa, Vector p)
        {
            return x + Alfa * p;
        }
    }
}
