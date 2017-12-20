using MethodsOptimization.src.Parametrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class NewtonGeneralizedMethod : MultiDimSearch
    {
        protected double alfa = 1;

        public NewtonGeneralizedMethod()
        {
            Name = "Обобщенный метод Ньютона";
        }

        public override Result Run(Params p)
        {
            Params cP = (Params)p.Clone();
            Result result = cP.ToResult();
            result.ListP.Clear();
            // устанавливаем функцию
            f = p.Y;

            Vector gfk = Functions.Math.GF(f, result.GetLastX());
            do
            {
                // Шаг 1
                Matrix hessian = Functions.Math.GetMatrixHessianInPoint(f, result.GetLastX());
                Vector P = Functions.Math.GetTheSolutionOfTheSystem(hessian, -gfk);
                if (NormalizationDirections)
                {
                    P = P.Rationing();
                }
                result.ListP.Add(P);
                //Шаг 2
                result.ListX.Add(X(result.GetLastX(), alfa, result.GetLastP()));
                // Шаг 3
                gfk = Functions.Math.GF(f, result.GetLastX());
                if (Lim.CheckNorma(result.GetLastP()) || Lim.CheckNorma(gfk))
                {
                    break;
                }
                result.K++;
            } while (result.K < Lim.K);

            result.XMin = result.GetLastX();

            return result;
        }
    }
}
