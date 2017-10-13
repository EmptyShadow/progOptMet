using System;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src.Parametrs.Output;

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
        /// <param name="parametrs"></param>
        /// <returns></returns>
        override public double Run(ref Params parametrs)
        {
            WriteStart(ref parametrs);
            // устанавливаем функцию
            f = parametrs.input.y;
            OutputParams q = Init(parametrs.input);
            // начальный вектор, следующий вектор, направление
            Vector p = parametrs.input.p, x0 = parametrs.input.x1;

            double lambda =  GoldenNumbers.LambdaGoldenSection(q.alfa[0], q.alfa[1]),
            mu = GoldenNumbers.MuGoldenSection(q.alfa[0], q.alfa[1]);
            do
            {
                q.AB[0] = X(x0, q.alfa[0], p);
                q.AB[1] = X(x0, q.alfa[1], p);
                if (f.Parse(q.AB[0]) < f.Parse(q.AB[1]))
                {
                    q.alfa[1] = mu;
                    mu = lambda;
                    lambda = GoldenNumbers.LambdaGoldenSection(q.alfa[0], q.alfa[1]);
                }
                else
                {
                    q.alfa[0] = lambda;
                    lambda = mu;
                    mu = GoldenNumbers.MuGoldenSection(q.alfa[0], q.alfa[1]);
                }
                if (CheckArg(parametrs, q.alfa[0], q.alfa[1]) || CheckF(parametrs, q.AB[0], q.AB[1]))
                {
                    break;
                }
                q.k++;
            } while (CheckK(parametrs, q.k));

            // записываем выходные параметры
            WRez(ref parametrs, q);

            WriteEnd(ref parametrs);

            return parametrs.output.f_x_;
        }
    }
}
