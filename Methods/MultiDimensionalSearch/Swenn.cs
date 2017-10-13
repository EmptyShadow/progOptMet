using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src.Parametrs.Output;

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
        override public double Run(ref Params parametrs)
        {
            WriteStart(ref parametrs);
            // устанавливаем функцию
            f = parametrs.input.y;
            OutputParams q = Init(parametrs.input);
            // начальный вектор, следующий вектор, направление
            Vector p = parametrs.input.p, x0 = parametrs.input.x1;
            // производные по направлению
            double fd_k, fd_kp;

            // вычисляем производную в начальной точке
            fd_k = GdF(q.AB[0], p);

            // меняем направление если функция возрастает
            if (fd_k > 0)
            {
                q.alfa_h = -q.alfa_h;
            }
            
            // Постепенно приближаемся к минимуму с заданной точностью
            while (CheckK(parametrs, q.k))
            {
                // вычисляем новые данные
                q.alfa[1] = q.alfa[0] + q.alfa_h;
                q.AB[1] = X(x0, q.alfa[1], p);

                // находим производные в текущей и следующей точке
                fd_k = GdF(q.AB[0], p);
                fd_kp = GdF(q.AB[1], p);
                // проверяем критерий окончания поиска
                if (fd_kp * fd_k < 0.0 || CheckArg(parametrs, q.alfa[0], q.alfa[1]) || CheckF(parametrs, q.AB[0], q.AB[1]))
                {
                    // если точность достигнута
                    if (q.alfa[0] >= q.alfa[1])
                    {
                        double t = q.alfa[0];
                        q.alfa[0] = q.alfa[1];
                        q.alfa[1] = t;
                        
                    }
                    break;
                }
                // иначе ведем поиск дальше
                q.alfa_h *= 2;
                q.alfa[0] = q.alfa[1];
                q.AB[0] = q.AB[1];
                q.k++;
            }

            // записываем выходные параметры
            WRez(ref parametrs, q);

            WriteEnd(ref parametrs);

            return parametrs.output.f_x_;
        }
    }
}
