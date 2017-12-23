using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    
    class Koshi: MultiDimSearch
    {
        public Koshi()
        {
            Name = "Коши";
            usesOthersMethods = true;
        }

        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        override public Result Run(Params p)
        {
            if (MethodsUsed == null) throw new System.Exception("Ошибка метода " + Name + ": не определены методы, которые будет использованны");
            Params cP = (Params)p.Clone();
            Result result = cP.ToResult();
            result.ListP.Clear();
            // устанавливаем функцию
            f = p.Y;

            // параметры для поиска минимума на k-ом шаге
            Params pSerch = (Params)p.Clone();

            while(result.K <= Lim.K)
            {
                pSerch.X0 = result.ListX[result.ListX.Count - 1];
                pSerch.H = cP.H;
                // получаю направление
                pSerch.P = -Functions.Math.GF(cP.Y, pSerch.X0);
                if (NormalizationDirections && pSerch.P.Norma > 1.0)
                {
                    pSerch.P = pSerch.P.Rationing();
                }
                result.ListP.Add(pSerch.P);
                // получаю шаг до минимума
                Result resultMethods = MethodsUsed?.Run(pSerch);
                result.Alfas.Push(resultMethods.AlfaMin);
                // получаю следующий вектор
                result.ListX.Add(pSerch.X0 + result.Alfas.Last * pSerch.P);
                // проверяю коп
                if (Lim.CheckMinEps(result.ListX[result.ListX.Count - 1], result.ListX[result.ListX.Count - 2]) &&
                    Lim.CheckNorma(pSerch.P) &&
                    Lim.CheckMinEps(f.Parse(result.ListX[result.ListX.Count - 1]), f.Parse(result.ListX[result.ListX.Count - 2])))
                {
                    break;
                }
                result.K++;
            }

            result.XMin = result.ListX[result.ListX.Count - 1];

            return result;
        }
    }
}
