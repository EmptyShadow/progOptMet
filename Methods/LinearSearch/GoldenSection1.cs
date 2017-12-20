using System;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Methods.LinearSearch.Utils;

namespace MethodsOptimization.src.Methods.LinearSearch
{
    class GoldenSection1: LinSearch
    {
        public GoldenSection1()
        {
            Name = "Золотое сечение 1";
        }
        
        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override Result Run(Params p)
        {
            if (p.Alfa.Size != 2) throw new Exception("Ошибка метода " + Name + ": интервал локализации не состоит из двух чисел во входных данных");

            Params cP = (Params)p.Clone();
            if (NormalizationDirections)
            {
                cP.P = cP.P.Rationing();
            }
            Result result = cP.ToResult();
            Vector x = result.ListX[0], P = result.ListP[0];
            // устанавливаем функцию
            f = cP.Y;

            double lambda =  GoldenNumbers.LambdaGoldenSection(result.Alfas[0], result.Alfas[1]),
            mu = GoldenNumbers.MuGoldenSection(result.Alfas[0], result.Alfas[1]);
            while(result.K <= Lim.K)
            {
                Vector x1 = X(x, result.Alfas[0], P);
                Vector x2 = X(x, result.Alfas[1], P);
                if (f.Parse(x1) < f.Parse(x2))
                {
                    result.Alfas[1] = mu;
                    mu = lambda;
                    lambda = GoldenNumbers.LambdaGoldenSection(result.Alfas[0], result.Alfas[1]);
                }
                else
                {
                    result.Alfas[0] = lambda;
                    lambda = mu;
                    mu = GoldenNumbers.MuGoldenSection(result.Alfas[0], result.Alfas[1]);
                }
                if (Lim.CheckMinEps(x1, x2) && 
                    Lim.CheckMinEps(f.Parse(x1), f.Parse(x2)) && 
                    Lim.CheckMinEps(result.Alfas[0], result.Alfas[1]))
                {
                    break;
                }
                result.K++;
            }

            result.AlfaMin = (result.Alfas[1] + result.Alfas[0]) / 2.0;
            result.XMin = X(x, result.AlfaMin, P);

            return result;
        }
    }
}
