using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class CubicInterpolation : MultiDimSearch
    {
        public CubicInterpolation ()
        {
            Name = "Cubic interpolation";
        }

        public override Params Run(Params p, EmptyMethod m = null)
        {
            // утановить функцию
            f = p.Y;
            // Скопирвоать входные параметры для изменения
            Params cP = (Params)p.Clone();
            CheckingCriterion checking = new CheckingCriterion(ref cP);
            // основной этап
            do
            {
                // шаг 1 вычислить gamma
                double alfa_;
                Vector xalfa1 = X(cP.X0, cP.Alfa.First, cP.P);
                Vector xalfa2 = X(cP.X0, cP.Alfa.Last, cP.P);
                double dfalfa1 = Math.GF(f, xalfa1, cP.P);
                double dfalfa2 = Math.GF(f, xalfa2, cP.P);
                double z = dfalfa1 + dfalfa2 + 3.0 * (f.Parse(xalfa1) - f.Parse(xalfa2)) / (cP.Alfa.Last - cP.Alfa.First);
                double omega = System.Math.Sqrt(z * z - dfalfa1 * dfalfa2);
                double gamma = (z + omega - dfalfa1) / (dfalfa2 - dfalfa1 + 2.0 * omega);
                if (gamma < 0.0)
                {
                    alfa_ = cP.Alfa.First;
                } else if (gamma > 1.0)
                {
                    alfa_ = cP.Alfa.Last;
                } else
                {
                    alfa_ = cP.Alfa.First + gamma * (cP.Alfa.Last - cP.Alfa.First);
                }
                // шаг 2 проверить коп
                Vector gfalfa_V = Math.GF(f, X(cP.X0, alfa_, cP.P));
                if (checking.CheckGF(X(cP.X0, alfa_, cP.P), cP.P) || checking.CheckNormaGF(gfalfa_V) || alfa_ == cP.Alfa.First || alfa_ == cP.Alfa.Last)
                {
                    for (int i = 0; i < cP.Alfa.Size; i++)
                    {
                        cP.Alfa[i] = alfa_;
                    }
                    break;
                }
                double gfalfa_ = Math.GF(f, X(cP.X0, alfa_, cP.P), cP.P);
                if (gfalfa_ > 0.0)
                {
                    cP.Alfa[cP.Alfa.Size - 1] = alfa_;
                } else
                {
                    cP.Alfa[0] = alfa_;
                }
                cP.K++;
            } while (!checking.CheckNumIterat());
            return cP;
        }
    }
}
