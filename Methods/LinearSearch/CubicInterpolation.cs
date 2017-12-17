using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using System;

namespace MethodsOptimization.src.Methods.LinearSearch
{
    class CubicInterpolation : LinSearch
    {
        public CubicInterpolation ()
        {
            Name = "Cubic interpolation";
        }

        public override Result Run(Params p)
        {
            if (p.Alfa.Size != 2) throw new Exception(Name + " вектор альф не имеет 2 элемента");
            // Скопирвоать входные параметры для изменения
            Params cP = (Params)p.Clone();
            if (NormalizationDirections)
            {
                cP.P = cP.P.Rationing();
            }
            Result result = cP.ToResult();
            // утановить функцию
            f = p.Y;
            // основной этап
            do
            {
                // шаг 1 вычислить gamma
                double alfa_;
                Vector xalfa1 = X(cP.X0, result.Alfas[0], cP.P);
                Vector xalfa2 = X(cP.X0, result.Alfas[1], cP.P);
                double dfalfa1 = Functions.Math.GF(f, xalfa1, cP.P);
                double dfalfa2 = Functions.Math.GF(f, xalfa2, cP.P);
                double z = dfalfa1 + dfalfa2 + 3.0 * (f.Parse(xalfa1) - f.Parse(xalfa2)) / (result.Alfas[1] - result.Alfas[0]);
                double omega = System.Math.Sqrt(z * z - dfalfa1 * dfalfa2);
                double gamma = (z + omega - dfalfa1) / (dfalfa2 - dfalfa1 + 2.0 * omega);
                if (gamma < 0.0)
                {
                    alfa_ = result.Alfas[0];
                } else if (gamma > 1.0)
                {
                    alfa_ = result.Alfas[1];
                } else
                {
                    alfa_ = result.Alfas[0] + gamma * (result.Alfas[1] - result.Alfas[0]);
                }
                // шаг 2 проверить коп
                Vector gfalfa_V = Functions.Math.GF(f, X(cP.X0, alfa_, cP.P));
                if (Lim.CheckMinEps(Functions.Math.GF(f, X(cP.X0, alfa_, cP.P), cP.P)) || 
                    Lim.CheckNorma(gfalfa_V) || 
                    alfa_ == result.Alfas[0] || 
                    alfa_ == result.Alfas[1])
                {
                    result.AlfaMin = alfa_;
                    break;
                }
                double gfalfa_ = Functions.Math.GF(f, X(cP.X0, alfa_, cP.P), cP.P);
                if (gfalfa_ > 0.0)
                {
                    result.Alfas[1] = alfa_;
                } else
                {
                    result.Alfas[0] = alfa_;
                }
                result.K++;
            } while (result.K < Lim.K);

            if (!double.IsNaN(result.AlfaMin)) { result.XMin = X(cP.X0, result.AlfaMin, cP.P); }

            return result;
        }
    }
}
