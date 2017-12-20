using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Functions;

namespace MethodsOptimization.src.Methods.LinearSearch
{
    class Swenn: LinSearch
    {
        public Swenn()
        {
            Name = "Свенн";
        }
        
        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="parametrs"></param>
        /// <returns></returns>
        override public Result Run(Params p)
        {
            // Копирую входные данные
            Params cP = (Params)p.Clone();
            if (NormalizationDirections)
            {
                cP.P = cP.P.Rationing();
            }
            Result result = cP.ToResult();
            // устанавливаем функцию
            f = cP.Y;
            
            // производные по направлению
            double fd_k, fd_kp, fk, fkp;
            Vector x1 = result.ListX[0], x2, P = result.ListP[0];

            // вычисляем производную в начальной точке
            fd_k = Math.GF(f, x1, P);

            // Устанавливаем две точки интервала в ноль
            result.Alfas = new Vector();
            double q = 2 * f.Parse(x1) / Math.GF(f, x1, P);
            result.Alfas.Push((System.Math.Abs(q) < 1.0) ? q : 1.0);
            result.Alfas.Push(0.0);

            // меняем направление если функция возрастает
            if (fd_k > 0)
            {
                cP.H = -cP.H;
            }
            
            // Постепенно приближаемся к минимуму с заданной точностью
            while (result.K <= Lim.K)
            {
                // вычисляем новые данные
                result.Alfas[1] = result.Alfas[0] + cP.H;
                x2 = X(x1, result.Alfas[1], P);

                // находим производные в текущей и следующей точке
                fd_k = Math.GF(f, x1, P);
                fd_kp = Math.GF(f, x2, P);
                fk = f.Parse(x1);
                fkp = f.Parse(x2);
                // проверяем критерий окончания поиска
                if (fd_kp * fd_k < 0.0 || fkp > fk)
                {
                    // Если знаки разные, остановка
                    break;
                }
                // иначе ведем поиск дальше
                cP.H *= 2;
                result.Alfas[0] = result.Alfas[1];
                x1 = x2;
                result.K++;
            }
            // Если нужно поменять направление интервала
            if (result.Alfas[0] >= result.Alfas[1])
            {
                // то меняем
                double t = result.Alfas[0];
                result.Alfas[0] = result.Alfas[1];
                result.Alfas[1] = t;
            }
            return result;
        }
    }
}
