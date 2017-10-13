
using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src.Parametrs.Output;

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

            q.alfa.Push((q.alfa[0] + q.alfa[1]) / 2.0);
            double t = q.alfa[1];
            q.alfa[1] = q.alfa[2];
            q.alfa[2] = t;

            double d = CalculatedRatios.First(f, x0, p, q), fb = F(x0, q.alfa[1], p), fd = F(x0, d, p);
            while (q.alfa[1] != 0.0 && CheckK(parametrs, q.k))
            {
                if (q.alfa[1] < d && fb < fd)
                {
                    q.alfa[2] = d;
                }
                else if (q.alfa[1] < d && fb > fd)
                {
                    q.alfa[0] = q.alfa[1];
                    q.alfa[1] = d;
                }
                else if (q.alfa[1] > d && fb < fd)
                {
                    q.alfa[0] = d;
                }
                else if (q.alfa[1] > d && fb > fd)
                {
                    q.alfa[2] = q.alfa[1];
                    q.alfa[1] = d;
                }
                d = CalculatedRatios.Second(f, x0, p, q);
                fb = F(x0, q.alfa[1], p);
                fd = F(x0, d, p);
                if (CheckArg(parametrs, fb, fd) ||
                CheckF(parametrs, X(x0, q.alfa[1], p), X(x0, q.alfa[2], p)))
                {
                    break;
                }
                q.k++;
            }
            if (q.alfa[1] < d)
            {
                q.alfa[0] = q.alfa[1];
                q.alfa[1] = d;
            }
            else
            {
                q.alfa[0] = d;
            }
            q.alfa.Remove(2);

            q.AB[0] = X(x0, q.alfa[0], p);
            q.AB[1] = X(x0, q.alfa[1], p);
            // записываем выходные параметры
            WRez(ref parametrs, q);

            WriteEnd(ref parametrs);

            return parametrs.output.f_x_;
        }
    }
}
