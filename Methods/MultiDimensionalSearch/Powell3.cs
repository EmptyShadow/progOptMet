using MethodsOptimization.src.Parametrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class Powell3: MultiDimSearch
    {
        public Powell3()
        {
            Name = "Пауэлл модификация 3";
            usesOthersMethods = true;
        }

        public override Result Run(Params p)
        {
            if (MethodsUsed == null) throw new System.Exception("Ошибка метода " + Name + ": не определены методы, которые будет использованны");
            Params cP = (Params)p.Clone();
            Result result = cP.ToResult();
            result.ListP.Clear();
            // устанавливаем функцию
            f = p.Y;

            int n = p.Y.Vars.Count;

            Vector mu = new Vector();
            // множество направлений пи и мю
            for (int i = 0; i < n; i++)
            {
                result.ListP.Add(Vector.GetZeroBeside(n, i));
                mu.Push(0);
                result.Alfas.Push(0);
                result.ListX.Add(null);
            }

            Params usesParam = (Params)cP.Clone();

            while (result.K <= Lim.K)
            {
                // формируем массив альфа, мю, иксов
                for (int i = 0; i < n; i++)
                {
                    usesParam.P = result.ListP[i];
                    usesParam.X0 = result.ListX[i];
                    usesParam.H = cP.H;
                    result.Alfas[i] = (MethodsUsed.Run(usesParam).AlfaMin);
                    result.ListX[i + 1] = X(usesParam.X0, result.Alfas[i], usesParam.P);
                    mu[i] = f.Parse(result.ListX[i]) - f.Parse(result.ListX[i + 1]);
                }
                // получаем направляющий вектор
                Vector dk = result.ListX[n] - result.ListX[0];
                // нормируем
                dk = dk.Rationing();

                usesParam.P = dk;
                usesParam.X0 = result.ListX[n];
                usesParam.H = cP.H;
                // вычисляю следующую точку
                double alfa = MethodsUsed.Run(usesParam).AlfaMin;
                Vector xnpp = result.GetLastX() + alfa * dk;

                double y1 = f.Parse(result.ListX[0]), ynp = f.Parse(result.ListX[n]), ynpp = f.Parse(xnpp);
                if (Lim.CheckNorma(dk) || Lim.CheckMinEps(alfa) || Lim.CheckNorma(Functions.Math.GF(f, xnpp)) || Lim.CheckMinEps((ynp - ynpp) / ynp))
                {
                    result.ListX.Add(xnpp);
                    break;
                }
                // получаем индекс максимального мю
                int indexMax = mu.GetIndexMaxElem();
                // Меняем систему направлений
                if (4 * mu[indexMax] * (ynp - ynpp) >= (y1 - ynp - mu[indexMax]) * (y1 - ynp - mu[indexMax]))
                {
                    // если условие перспективности выполнелось, то сдвигаем начиная с i-ого
                    for (int i = indexMax; i < n - 1; i++)
                    {
                        result.ListP[i] = result.ListP[i + 1];
                    }
                    result.ListP[indexMax] = dk;
                } else
                {
                    for (int i = 0; i < n - 1; i++)
                    {
                        result.ListP[i] = result.ListP[i + 1];
                    }
                    result.ListP[n - 1] = dk;
                }

                result.K++;
            }

            result.XMin = result.GetLastX();

            return result;
        }
    }
}
