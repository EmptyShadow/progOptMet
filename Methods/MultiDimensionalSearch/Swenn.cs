using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Functions;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class Swenn: MultiDimSearch
    {
        public Swenn()
        {
            Name = "Swenn";
        }
        
        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="parametrs"></param>
        /// <returns></returns>
        override public Params Run(Params p, EmptyMethod method = null)
        {
            // Копирую входные данные
            Params cP = (Params)p.Clone();
            // Инициализирую проверяющего критерии окончания поиска
            CheckingCriterion checking = new CheckingCriterion(ref cP);

            // устанавливаем функцию
            f = cP.Y;

            // производные по направлению
            double fd_k, fd_kp;
            Vector x1 = cP.X0, x2;

            // вычисляем производную в начальной точке
            fd_k = Math.GF(f, cP.X0, cP.P);

            // Устанавливаем две точки интервала в ноль
            cP.Alfa = new Vector();
            double q = 2 * cP.Y.Parse(x1) / Math.GF(f, x1, cP.P);
            cP.Alfa.Push((System.Math.Abs(q) < 1.0) ? q : 1.0);
            cP.Alfa.Push(0.0);

            // меняем направление если функция возрастает
            if (fd_k > 0)
            {
                cP.Alfa_h = -cP.Alfa_h;
            }
            
            // Постепенно приближаемся к минимуму с заданной точностью
            while (!checking.CheckNumIterat())
            {
                // вычисляем новые данные
                cP.Alfa[1] = cP.Alfa[0] + cP.Alfa_h;
                x2 = X(cP.X0, cP.Alfa[1], cP.P);

                // находим производные в текущей и следующей точке
                fd_k = Math.GF(f, x1, cP.P);
                fd_kp = Math.GF(f, x2, cP.P);
                // проверяем критерий окончания поиска
                if (fd_kp * fd_k < 0.0)
                {
                    // если точность достигнута
                    break;
                }
                // иначе ведем поиск дальше
                cP.Alfa_h *= 2;
                cP.Alfa[0] = cP.Alfa[1];
                x1 = x2;
                cP.K++;
            }
            // Если нужно поменять направление интервала
            if (cP.Alfa[0] >= cP.Alfa[1])
            {
                // то меняем
                double t = cP.Alfa[0];
                cP.Alfa[0] = cP.Alfa[1];
                cP.Alfa[1] = t;
            }
            return cP;
        }
    }
}
