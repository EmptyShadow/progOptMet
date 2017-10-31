using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class Powell: MultiDimSearch
    {
        public Powell()
        {
            Name = "Powell";
        }

        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override Params Run(Params p, EmptyMethod method = null)
        {
            if (p.Alfa.Size != 2) throw new System.Exception("Error run method Powell: size alfa != 2");

            Params cP = (Params)p.Clone();
            CheckingCriterion checking = new CheckingCriterion(ref cP);
            // устанавливаем функцию
            f = cP.Y;
            
            double t = cP.Alfa[1];
            cP.Alfa[1] = (cP.Alfa[0] + cP.Alfa[1]) / 2.0;
            cP.Alfa.Push(t);

            double d = CalculatedRatios.First(f, cP.X0, cP.P, cP.Alfa);
            if (double.IsNaN(d) || double.IsInfinity(d))
                return p;
            double fb = F(cP.X0, cP.Alfa[1], cP.P), 
                fd = F(cP.X0, d, cP.P);
            while (System.Math.Abs(1 - d / cP.Alfa[1]) > cP.Lim.EpsF && 
                System.Math.Abs(1 - fd / fb) > cP.Lim.EpsF &&
                !checking.CheckNumIterat())
            {
                if (cP.Alfa[1] < d && fb < fd)
                {
                    cP.Alfa[2] = d;
                }
                else if (cP.Alfa[1] < d && fb > fd)
                {
                    cP.Alfa[0] = cP.Alfa[1];
                    cP.Alfa[1] = d;
                }
                else if (cP.Alfa[1] > d && fb < fd)
                {
                    cP.Alfa[0] = d;
                }
                else if (cP.Alfa[1] > d && fb > fd)
                {
                    cP.Alfa[2] = cP.Alfa[1];
                    cP.Alfa[1] = d;
                }
                d = CalculatedRatios.Second(f, cP.X0, cP.P, cP.Alfa);
                fb = F(cP.X0, cP.Alfa[1], cP.P); 
                fd = F(cP.X0, d, cP.P);
                if (checking.CheckX())
                {
                    break;
                }
                cP.K++;
            }
            if (cP.Alfa[1] < d)
            {
                cP.Alfa[0] = cP.Alfa[1];
                cP.Alfa[1] = d;
            }
            else
            {
                cP.Alfa[0] = d;
            }
            cP.Alfa.Remove(2);
            
            return cP;
        }
    }
}
