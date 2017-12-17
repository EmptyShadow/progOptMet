using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.LinearSearch
{
    class Bolzano: LinSearch
    {
        public Bolzano()
        {
            Name = "Больцано";
        }

        public override Result Run(Params p)
        {
            if (p.Alfa.Size != 2) throw new Exception("Больцано ошибка: интервал минимизации состоит не из двух точек");
            f = p.Y;
            Params cP = (Params)p.Clone();
            if (NormalizationDirections)
            {
                cP.P = cP.P.Rationing();
            }
            Result result = cP.ToResult();

            double xk = (result.Alfas[0] + result.Alfas[1]) / 2.0, gf;

            while (result.K <= Lim.K)
            {
                gf = Functions.Math.GF(cP.Y, X(cP.X0, xk, cP.P), cP.P);
                if (gf > 0.0)
                {
                    result.Alfas[1] = xk;
                }
                else
                {
                    result.Alfas[0] = xk;
                }
                if (Lim.CheckMinEps(result.Alfas[0], result.Alfas[1]) || Lim.CheckMinEps(gf))
                {
                    break;
                }
                xk = (result.Alfas[1] + result.Alfas[0]) / 2.0;
                result.K++;
            }
            result.AlfaMin = (result.Alfas[1] + result.Alfas[0]) / 2.0;
            result.XMin = X(cP.X0, result.AlfaMin, cP.P);
            return result;
        }
    }
}
