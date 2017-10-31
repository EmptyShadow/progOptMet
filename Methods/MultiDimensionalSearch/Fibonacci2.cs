using System;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class Fibonacci2: MultiDimSearch
    {
        public Fibonacci2()
        {
            Name = "Fibonacci 2";
        }

        public override Params Run(Params p, EmptyMethod m = null)
        {
            if (p.Alfa.Size != 2) throw new Exception("Фибоначчи 1 ошибка: интервал локализации минимума не состоит из двух точек");
            // устанавливаем функцию
            f = p.Y;
            Params cP = (Params)p.Clone();

            int n = 0; // номер числа фибоначчи
            double Fn = FibonacciNumbers.getPrevNumberFibonacci(System.Math.Abs(cP.Alfa[0] - cP.Alfa[1]) / cP.Lim.EpsAlfa, ref n), Fnm = FibonacciNumbers.getNNumberFibonacci(n - 1);
            int chet = n % 2 == 1 ? -1 : 1;
            
            double lambda = cP.Alfa[0] + Fnm * System.Math.Abs(cP.Alfa[0] - cP.Alfa[1]) / Fn + chet * cP.Lim.EpsAlfa / Fn, mu,
                    f1, f2;
            while (true)
            {
                mu = cP.Alfa[0] + cP.Alfa[1] - lambda;
                f1 = f.Parse(X(cP.X0, lambda, cP.P));
                f2 = f.Parse(X(cP.X0, mu, cP.P));
                if (lambda < mu && f1 < f2)
                {
                    cP.Alfa[1] = mu;
                }
                else if (lambda < mu && f1 > f2)
                {
                    cP.Alfa[0] = lambda;
                    lambda = mu;
                }
                else if (lambda > mu && f1 < f2)
                {
                    cP.Alfa[0] = mu;
                }
                else if (lambda > mu && f1 > f2)
                {
                    cP.Alfa[1] = lambda;
                    lambda = mu;
                }
                if (cP.K == n)
                {
                    break;
                }
                cP.K++;
            }
            
            return cP;
        }
    }
}
