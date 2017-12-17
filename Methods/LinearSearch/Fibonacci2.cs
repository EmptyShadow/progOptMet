using System;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Methods.LinearSearch.Utils;

namespace MethodsOptimization.src.Methods.LinearSearch
{
    class Fibonacci2: LinSearch
    {
        public Fibonacci2()
        {
            Name = "Фибоначчи 2";
        }

        public override Result Run(Params p)
        {
            if (p.Alfa.Size != 2) throw new Exception(Name + " ошибка: интервал локализации минимума не состоит из двух точек");
            // устанавливаем функцию
            f = p.Y;
            Params cP = (Params)p.Clone();
            if (NormalizationDirections)
            {
                cP.P = cP.P.Rationing();
            }
            Result result = cP.ToResult();

            int n = 0; // номер числа фибоначчи
            double Fn = FibonacciNumbers.getPrevNumberFibonacci(System.Math.Abs(result.Alfas[0] - result.Alfas[1]) / Lim.Eps, ref n), 
                Fnm = FibonacciNumbers.getNNumberFibonacci(n - 1);
            int chet = n % 2 == 1 ? -1 : 1;
            
            double lambda = result.Alfas[0] + Fnm * System.Math.Abs(result.Alfas[0] - result.Alfas[1]) / Fn + chet * Lim.Eps / Fn, mu,
                    f1, f2;
            while (result.K <= Lim.K)
            {
                mu = result.Alfas[0] + result.Alfas[1] - lambda;
                f1 = f.Parse(X(cP.X0, lambda, cP.P));
                f2 = f.Parse(X(cP.X0, mu, cP.P));
                if (lambda < mu && f1 < f2)
                {
                    result.Alfas[1] = mu;
                }
                else if (lambda < mu && f1 > f2)
                {
                    result.Alfas[0] = lambda;
                    lambda = mu;
                }
                else if (lambda > mu && f1 < f2)
                {
                    result.Alfas[0] = mu;
                }
                else if (lambda > mu && f1 > f2)
                {
                    result.Alfas[1] = lambda;
                    lambda = mu;
                }
                if (result.K == n)
                {
                    break;
                }
                result.K++;
            }
            
            result.AlfaMin = (result.Alfas[1] + result.Alfas[0]) / 2.0;
            result.XMin = X(cP.X0, result.AlfaMin, cP.P);

            return result;
        }
    }
}
