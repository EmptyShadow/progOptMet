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

        protected override bool SEC(InputParams In, OutputParams Out)
        {
            SearchEndingCriterion sec = new SearchEndingCriterion(In.Lim);
            Vector x1 = X(In.X0, Out.Alfa[0], In.P);
            Vector x2 = X(In.X0, Out.Alfa[1], In.P);
            Vector x3 = X(In.X0, Out.Alfa[2], In.P);
            if ((x1 - x2).Norma > (x3 - x2).Norma)
            {
                return sec.CheckArg(x3, x2) && sec.CheckF(In.Y, x3, x2);
            }
            return sec.CheckArg(x1, x2) && sec.CheckF(In.Y, x1, x2);
        }
        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        override public double Run(ref Params p, EmptyMethod method = null)
        {
            p.InitOut();
            if (p.Out.Alfa.Size != 2) throw new System.Exception("Error run method Powell: size alfa != 2");
            // устанавливаем функцию
            f = p.In.Y;
            
            double t = p.Out.Alfa[1];
            p.Out.Alfa[1] = (p.Out.Alfa[0] + p.Out.Alfa[1]) / 2.0;
            p.Out.Alfa.Push(t);

            double d = CalculatedRatios.First(f, p.In.X0, p.In.P, p.Out.Alfa), 
                fb = F(p.In.X0, p.Out.Alfa[1], p.In.P), 
                fd = F(p.In.X0, d, p.In.P);
            while (System.Math.Abs(fb - fd) > p.In.Lim.Eps && !p.In.Lim.CheckNumIteration(p.Out.K))
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
                if (SEC(p.In, p.Out))
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
