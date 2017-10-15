using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    
    class Koshi: MultiDimSearch
    {
        public Koshi()
        {
            name = "Koshi";
        }

        protected override bool SEC(InputParams In, OutputParams Out)
        {
            SearchEndingCriterion sec = new SearchEndingCriterion(In.Lim);
            Vector x1 = X(In.X0, Out.Alfa[0], In.P);
            Vector x2 = X(In.X0, Out.Alfa[1], In.P);
            return sec.CheckArg(x1, x2) && sec.CheckF(In.Y, x1, x2) && sec.CheckGF(In.Y, x2, In.P);
        }

        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        override public double Run(ref Params p, EmptyMethod methods)
        {
            if (methods == null) throw new System.Exception("Ошибка метода " + name + ": не определены методы, которые будет использованны");
            p.InitOut();
            // устанавливаем функцию
            f = p.In.Y;
            
            Vector xk = p.In.X0, xk_p;

            // параметры для поиска минимума на k-ом шаге
            Params pSerch = (Params)p.Clone();

            while(!p.In.Lim.CheckNumIteration(p.Out.K))
            {
                // получаю направление
                pSerch.In.P = -GdF(xk);
                pSerch.In.X0 = xk;
                // получаю шаг до минимума
                p.Out.Alfa.Push(methods.Run(ref pSerch));
                // получаю следующий вектор
                xk_p = xk + p.Out.Alfa.Last * pSerch.In.P;
                System.Console.WriteLine(xk_p.ToString());
                // проверяю коп
                if ((xk_p - xk).Norma <= p.In.Lim.Eps &&
                    pSerch.In.P.Norma <= p.In.Lim.Eps &&
                    System.Math.Abs(f.Parse(xk_p) - f.Parse(xk)) <= p.In.Lim.Eps)
                {
                    break;
                }
                xk= xk_p;
                p.Out.K++;
            }

            return p.GetAlfa_ByOut();
        }
    }
}
