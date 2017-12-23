using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using System;

namespace MethodsOptimization.src.Methods.LinearSearch
{
    class CubicInterpolation : LinSearch
    {
        public CubicInterpolation ()
        {
            Name = "Кубическая интерполяция";
        }

        public override Result Run(Params p)
        {
            if (p.Alfa.Size != 2) throw new Exception(Name + " вектор альф не имеет 2 элемента");
            // Скопирвоать входные параметры для изменения
            Params cP = (Params)p.Clone();
            if (NormalizationDirections && cP.P.Norma > 1.0)
            {
                cP.P = cP.P.Rationing();
            }
            Result result = cP.ToResult();
            Vector x = result.ListX[0], P = result.ListP[0];
            // утановить функцию
            f = p.Y;
            // основной этап
            do
            {
                // шаг 1 вычислить gamma
                double alfa_;
                Vector xalfa1 = X(x, result.Alfas[0], P);
                Vector xalfa2 = X(x, result.Alfas[1], P);
                double dfalfa1 = Functions.Math.GF(f, xalfa1, P);
                double dfalfa2 = Functions.Math.GF(f, xalfa2, P);
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
                Vector gfalfa_V = Functions.Math.GF(f, X(x, alfa_, P));
                if (Lim.CheckMinEps(Functions.Math.GF(f, X(x, alfa_, P), P)) || 
                    Lim.CheckNorma(gfalfa_V) || 
                    alfa_ == result.Alfas[0] || 
                    alfa_ == result.Alfas[1])
                {
                    result.AlfaMin = alfa_;
                    break;
                }
                double gfalfa_ = Functions.Math.GF(f, X(x, alfa_, P), P);
                if (gfalfa_ > 0.0)
                {
                    result.Alfas[1] = alfa_;
                } else
                {
                    result.Alfas[0] = alfa_;
                }
                result.K++;
            } while (result.K < Lim.K);

            if (!double.IsNaN(result.AlfaMin)) { result.XMin = X(x, result.AlfaMin, P); }

            return result;
        }
    }
}
