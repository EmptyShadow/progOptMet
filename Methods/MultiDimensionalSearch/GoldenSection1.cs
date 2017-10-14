using System;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class GoldenSection1: MultiDimSearch
    {
        public GoldenSection1()
        {
            name = "Golden section 1";
        }
        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        override public double Run(ref Params p, EmptyMethod method = null)
        {
            p.InitOut();
            if (p.In.Alfa.Size != 2) return double.NaN;
            SearchEndingCriterion sec = new SearchEndingCriterion(p.In.Lim);

            // устанавливаем функцию
            f = p.In.Y;

            double lambda =  GoldenNumbers.LambdaGoldenSection(p.Out.Alfa[0], p.Out.Alfa[1]),
            mu = GoldenNumbers.MuGoldenSection(p.Out.Alfa[0], p.Out.Alfa[1]);
            while(!p.In.Lim.CheckNumIteration(p.Out.K))
            {
                Vector x1 = X(p.In.X0, p.Out.Alfa[0], p.In.P);
                Vector x2 = X(p.In.X0, p.Out.Alfa[1], p.In.P);
                if (f.Parse(x1) < f.Parse(x2))
                {
                    p.Out.Alfa[1] = mu;
                    mu = lambda;
                    lambda = GoldenNumbers.LambdaGoldenSection(p.Out.Alfa[0], p.Out.Alfa[1]);
                }
                else
                {
                    p.Out.Alfa[0] = lambda;
                    lambda = mu;
                    mu = GoldenNumbers.MuGoldenSection(p.Out.Alfa[0], p.Out.Alfa[1]);
                }
                if (sec.SEC(p.In, p.Out))
                {
                    break;
                }
                p.Out.K++;
            }

            return p.GetAlfa_ByOut();
        }
    }
}
