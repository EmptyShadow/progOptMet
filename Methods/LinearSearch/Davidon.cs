using MethodsOptimization.src.Parametrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Methods.LinearSearch
{
    class Davidon : LinSearch
    {
        public Davidon()
        {
            Name = "Дэвидон";
        }

        public override Result Run(Params p)
        {
            if (p.Alfa.Size != 2) throw new Exception("Дэвидон ошибка: интервал минимизации состоит не из двух точек");
            f = p.Y;
            Params cP = (Params)p.Clone();
            if (NormalizationDirections && cP.P.Norma > 1.0)
            {
                cP.P = cP.P.Rationing();
            }
            Result result = cP.ToResult();
            Vector x = result.ListX[0], P = result.ListP[0];
            double AlfaD, gf;

            do
            {
                Vector xalfa1 = X(x, result.Alfas[0], P);
                Vector xalfa2 = X(x, result.Alfas[1], P);
                double dfalfa1 = Functions.Math.GF(f, xalfa1, P);
                double dfalfa2 = Functions.Math.GF(f, xalfa2, P);
                double z = dfalfa1 + dfalfa2 + 3.0 * (f.Parse(xalfa1) - f.Parse(xalfa2)) / (result.Alfas[1] - result.Alfas[0]);
                double sqeareOmega = z * z - dfalfa1 * dfalfa2;
                //double omega = System.Math.Sqrt(/*System.Math.Abs(*/z * z - dfalfa1 * dfalfa2/*)*/);
                double omega = sqeareOmega > 0.0 ? System.Math.Sqrt(sqeareOmega) : Lim.Eps;
                double gamma = (z + omega - dfalfa1) / (dfalfa2 - dfalfa1 + 2.0 * omega);
                AlfaD = result.Alfas[0] + gamma * (result.Alfas[1] - result.Alfas[0]);
                gf = Functions.Math.GF(f, X(x, AlfaD, P), P);

                if (Lim.CheckMinEps(gf) || Lim.CheckMinEps(result.Alfas[0], result.Alfas[1]))
                {
                    break;
                }

                if (gf > 0)
                {
                    result.Alfas[1] = AlfaD;
                }
                else
                {
                    result.Alfas[0] = AlfaD;
                }

                result.K++;
            } while (result.K < Lim.K);

            result.AlfaMin = (result.Alfas[1] + result.Alfas[0]) / 2.0;
            result.XMin = X(x, result.AlfaMin, P);
            return result;
        }
    }
}
