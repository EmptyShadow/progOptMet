using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Methods.LinearSearch.Utils;

namespace MethodsOptimization.src.Methods.LinearSearch
{
    class Powell: LinSearch
    {
        public Powell()
        {
            Name = "Пауэлл";
        }

        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override Result Run(Params p)
        {
            if (p.Alfa.Size != 2) throw new System.Exception("Error run method Powell: size alfa != 2");

            Params cP = (Params)p.Clone();
            if (NormalizationDirections && cP.P.Norma > 1.0)
            {
                cP.P = cP.P.Rationing();
            }
            Result result = cP.ToResult();
            // устанавливаем функцию
            f = cP.Y;
            
            double t = result.Alfas[1];
            result.Alfas[1] = (result.Alfas[0] + result.Alfas[1]) / 2.0;
            result.Alfas.Push(t);
            Vector x = result.ListX[0], P = result.ListP[0];

            double d = CalculatedRatios.First(f, x, P, result.Alfas);
            if (double.IsNaN(d) || double.IsInfinity(d))
                return result;
            double fb = F(x, result.Alfas[1], P), 
                fd = F(x, d, P);
            while (result.K <= Lim.K)
            {
                if (result.Alfas[1] < d && fb < fd)
                {
                    result.Alfas[2] = d;
                }
                else if (result.Alfas[1] < d && fb > fd)
                {
                    result.Alfas[0] = result.Alfas[1];
                    result.Alfas[1] = d;
                }
                else if (result.Alfas[1] > d && fb < fd)
                {
                    result.Alfas[0] = d;
                }
                else if (result.Alfas[1] > d && fb > fd)
                {
                    result.Alfas[2] = result.Alfas[1];
                    result.Alfas[1] = d;
                }
                d = CalculatedRatios.Second(f, x, P, result.Alfas);
                Vector x1 = X(x, result.Alfas[1], P), x2 = X(x, d, P);
                fb = f.Parse(x1); 
                fd = f.Parse(x2);
                if(Lim.CheckMinEps(result.Alfas[0], result.Alfas[1]) ||
                    Lim.CheckMinEps(x1, x2) ||
                    Lim.CheckMinEps(fb, fd))
                /*if (System.Math.Abs(1 - d / result.Alfas[1]) > Lim.Eps ||
                    System.Math.Abs(1 - fd / fb) > Lim.Eps)*/
                {
                    break;
                }
                result.K++;
            }
            if (result.Alfas[1] < d)
            {
                result.Alfas[0] = result.Alfas[1];
                result.Alfas[1] = d;
            }
            else
            {
                result.Alfas[0] = d;
            }
            result.Alfas.Remove(2);

            result.AlfaMin = (result.Alfas[1] + result.Alfas[0]) / 2.0;
            result.XMin = X(x, result.AlfaMin, P);

            return result;
        }
    }
}
