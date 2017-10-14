using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;
using System;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class Swenn: MultiDimSearch
    {
        public Swenn()
        {
            name = "Swenn";
        }
        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="parametrs"></param>
        /// <returns></returns>
        override public double Run(ref Params p, EmptyMethod method = null)
        {
            p.InitOut();
            SearchEndingCriterion sec = new SearchEndingCriterion(p.In.Lim);
            // устанавливаем функцию
            f = p.In.Y;

            // производные по направлению
            double fd_k, fd_kp;
            Vector x1 = p.In.X0, x2;

            // вычисляем производную в начальной точке
            fd_k = GdF(p.In.X0, p.In.P);

            // Устанавливаем две точки интервала в ноль
            p.Out.Alfa.Clear();
            p.Out.Alfa.Push(1.0);
            p.Out.Alfa.Push(0.0);

            // меняем направление если функция возрастает
            if (fd_k > 0)
            {
                p.Out.Alfa_h = -p.Out.Alfa_h;
            }
            
            // Постепенно приближаемся к минимуму с заданной точностью
            while (!p.In.Lim.CheckNumIteration(p.Out.K))
            {
                // вычисляем новые данные
                p.Out.Alfa[1] = p.Out.Alfa[0] + p.Out.Alfa_h;
                x2 = X(p.In.X0, p.Out.Alfa[1], p.In.P);

                // находим производные в текущей и следующей точке
                fd_k = GdF(x1, p.In.P);
                fd_kp = GdF(x2, p.In.P);
                // проверяем критерий окончания поиска
                if (fd_kp * fd_k < 0.0)
                {
                    // если точность достигнута
                    if (p.Out.Alfa[0] >= p.Out.Alfa[1])
                    {
                        double t = p.Out.Alfa[0];
                        p.Out.Alfa[0] = p.Out.Alfa[1];
                        p.Out.Alfa[1] = t;
                    }
                    break;
                }
                // иначе ведем поиск дальше
                p.Out.Alfa_h *= 2;
                p.Out.Alfa[0] = p.Out.Alfa[1];
                x1 = x2;
                p.Out.K++;
            }

            return p.GetAlfa_ByOut();
        }
    }
}
