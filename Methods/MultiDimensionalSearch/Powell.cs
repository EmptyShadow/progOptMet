using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class Powell: MultiDimSearch
    {
        public Powell()
        {
            name = "Powell";
        }
        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        override public double Run(ref Params p, EmptyMethod method = null)
        {
            p.InitOut();
            if (p.Out.Alfa.Size != 2) return double.NaN;
            // устанавливаем функцию
            f = p.In.Y;
            SearchEndingCriterion sec = new SearchEndingCriterion(p.In.Lim);
            
            double t = p.Out.Alfa[1];
            p.Out.Alfa[1] = (p.Out.Alfa[0] + p.Out.Alfa[1]) / 2.0;
            p.Out.Alfa.Push(t);

            double d = CalculatedRatios.First(f, p.In.X0, p.In.P, p.Out.Alfa), 
                fb = F(p.In.X0, p.Out.Alfa[1], p.In.P), 
                fd = F(p.In.X0, d, p.In.P);
            while (p.Out.Alfa[1] != 0.0 && !p.In.Lim.CheckNumIteration(p.Out.K))
            {
                if (p.Out.Alfa[1] < d && fb < fd)
                {
                    p.Out.Alfa[2] = d;
                }
                else if (p.Out.Alfa[1] < d && fb > fd)
                {
                    p.Out.Alfa[0] = p.Out.Alfa[1];
                    p.Out.Alfa[1] = d;
                }
                else if (p.Out.Alfa[1] > d && fb < fd)
                {
                    p.Out.Alfa[0] = d;
                }
                else if (p.Out.Alfa[1] > d && fb > fd)
                {
                    p.Out.Alfa[2] = p.Out.Alfa[1];
                    p.Out.Alfa[1] = d;
                }
                d = CalculatedRatios.Second(f, p.In.X0, p.In.P, p.Out.Alfa);
                fb = F(p.In.X0, p.Out.Alfa[1], p.In.P); 
                fd = F(p.In.X0, d, p.In.P);
                if (sec.SEC(p.In, p.Out))
                {
                    break;
                }
                p.Out.K++;
            }
            if (p.Out.Alfa[1] < d)
            {
                p.Out.Alfa[0] = p.Out.Alfa[1];
                p.Out.Alfa[1] = d;
            }
            else
            {
                p.Out.Alfa[0] = d;
            }
            p.Out.Alfa.Remove(2);
            
            return p.GetAlfa_ByOut();
        }
    }
}
