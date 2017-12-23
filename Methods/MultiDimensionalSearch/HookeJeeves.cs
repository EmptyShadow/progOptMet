using MethodsOptimization.src.Parametrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class HookeJeeves: MultiDimSearch
    {
        /// <summary>
        /// Коэффициент уменьшения шага
        /// </summary>
        const double B = 10;

        public HookeJeeves()
        {
            Name = "Хука-Дживса";
        }

        public override Result Run(Params p)
        {
            Params cP = (Params)p.Clone();
            Result result = cP.ToResult();
            result.ListP.Clear();
            // устанавливаем функцию
            f = p.Y;

            double H = cP.H;
            bool searchBest = false;
            Vector xkp;
            do
            {
                do
                {
                    // выполняем исследующий поиск
                    xkp = IP(result.GetLastX(), cP.H);
                    // если не улучшили
                    if (xkp.Equals(result.GetLastX()))
                    {
                        // то проверяем коп
                        if (Lim.CheckMinEps(cP.H)) { break; }
                        // иначе уменьшаем шаг
                        cP.H /= B;
                    } else
                    {
                        // иначе говорим что нашли
                        searchBest = true;
                        result.ListX.Add(xkp);
                    }
                } while (!searchBest);

                // Если коп выполнился, то стоп
                if (!searchBest) { break; }

                do
                {
                    // получаем образец
                    Vector xkpO = 2 * result.GetLastX() - result.ListX[result.ListX.Count - 2];
                    xkp = IP(xkpO, cP.H);

                    // Если нашли лучше
                    if (f.Parse(xkp) < f.Parse(result.GetLastX()))
                    {
                        // добавляем
                        result.ListX.Add(xkp);
                    } else
                    {
                        break;
                    }
                } while (true);

                searchBest = false;
                result.K++;
            } while (result.K < Lim.K);

            result.XMin = result.GetLastX();

            return result;
        }

        /// <summary>
        /// Исследующий поиск
        /// </summary>
        /// <param name="x">В окрестности какой точки смотрим</param>
        /// <param name="H">Окрестность</param>
        /// <returns></returns>
        private Vector IP(Vector x, double H)
        {
            Vector x1 = x, x1hp, x1hm;
            double fx1 = f.Parse(x1), fx1hp, fx1hm;
            int n = f.Vars.Count;
            // Выявление лучшей точки
            for (int i = 0; i < n; i++)
            {
                // получаем i-й орт
                Vector ei = Vector.GetZeroBeside(n, i);
                // идем вправо
                x1hp = x1 + H * ei;
                fx1hp = f.Parse(x1hp);
                // Если лучше
                if (fx1hp < fx1)
                {
                    // то улучшаем точку x1
                    fx1 = fx1hp;
                    x1 = x1hp;
                }
                else
                {
                    // наче идем влево
                    x1hm = x1 - H * ei;
                    fx1hm = f.Parse(x1hm);
                    // Если лучше
                    if (fx1hm < fx1)
                    {
                        // то улучшаем x1
                        fx1 = fx1hm;
                        x1 = x1hm;
                    }
                }
            }
            // возращаем лучшую точку
            return x1;
        }
    }
}
