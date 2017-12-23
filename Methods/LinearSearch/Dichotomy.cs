using MethodsOptimization.src.Parametrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Methods.LinearSearch
{
    class Dichotomy : LinSearch
    {
        public Dichotomy()
        {
            Name = "Дихотомия";
        }

        public override Result Run(Params p)
        {
            if (p.Alfa.Size != 2) throw new Exception("Дихотомия ошибка: интервал минимизации состоит не из двух точек");
            f = p.Y;
            Params cP = (Params)p.Clone();
            if (NormalizationDirections && cP.P.Norma > 1.0)
            {
                cP.P = cP.P.Rationing();
            }
            Result result = cP.ToResult();
            Vector x = result.ListX[0], P = result.ListP[0];

            double lambda_k, mu_k;
            double delta = 0.1 * Lim.Eps;
            while (result.K <= Lim.K || !Lim.CheckMinEps(result.Alfas[1], result.Alfas[0]))
            {
                lambda_k = (result.Alfas[1] + result.Alfas[0] - delta) / 2.0;
                mu_k = (result.Alfas[1] + result.Alfas[0] + delta) / 2.0;
                if (f.Parse(X(x, lambda_k, P)) < f.Parse(X(x, mu_k, P)))
                {
                    result.Alfas[1] = mu_k;
                }
                else
                {
                    result.Alfas[0] = lambda_k;
                }
                result.K++;
            }

            result.AlfaMin = (result.Alfas[1] + result.Alfas[0]) / 2.0;
            result.XMin = X(x, result.AlfaMin, P);
            return result;
        }
    }
}
