using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class Bolzano: MultiDimSearch
    {
        public Bolzano()
        {
            Name = "Bolzano";
        }

        public override Params Run(Params p, EmptyMethod m = null)
        {
            if (p.Alfa.Size != 2) throw new Exception("Больцано ошибка: интервал минимизации состоит не из двух точек");
            f = p.Y;
            Params cP = (Params)p.Clone();
            CheckingCriterion checking = new CheckingCriterion(ref cP);

            double xk = (cP.Alfa[0] + cP.Alfa[1]) / 2.0, gf;

            while (!checking.CheckNumIterat())
            {
                gf = Functions.Math.GF(cP.Y, X(cP.X0, xk, cP.P), cP.P);
                if (gf > 0.0)
                {
                    cP.Alfa[1] = xk;
                }
                else
                {
                    cP.Alfa[0] = xk;
                }
                if (checking.CheckAlfa() && checking.CheckGF(gf))
                {
                    break;
                }
                xk = (cP.Alfa[1] + cP.Alfa[0]) / 2.0;
                cP.K++;
            }

            return cP;
        }
    }
}
