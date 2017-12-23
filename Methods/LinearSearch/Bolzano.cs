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
            if (NormalizationDirections && cP.P.Norma > 1.0)
            {
                cP.P = cP.P.Rationing();
            }
            Result result = cP.ToResult();
            Vector x = result.ListX[0], P = result.ListP[0];

            double alfaK, gf;

            while (result.K <= Lim.K)
            {
                alfaK = (result.Alfas[0] + result.Alfas[1]) / 2.0;
                gf = Functions.Math.GF(f, X(x, alfaK, P), P);
                if (Lim.CheckMinEps(result.Alfas[0], result.Alfas[1]) ||
                    Lim.CheckMinEps(gf))
                {
                    break;
                }
                if (gf > 0.0)
                {
                    result.Alfas[1] = alfaK;
                }
                else
                {
                    result.Alfas[0] = alfaK;
                }
                result.K++;
            }
            result.AlfaMin = (result.Alfas[1] + result.Alfas[0]) / 2.0;
            result.XMin = X(x, result.AlfaMin, P);
            return result;
        }
    }
}
