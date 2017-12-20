using MethodsOptimization.src.Parametrs;
using System;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class GaussSeidel: MultiDimSearch
    {
        public GaussSeidel()
        {
            Name = "Гаусс-Зейдель";
            usesOthersMethods = true;
        }
        
        public override Result Run(Params p)
        {
            // проверка переданных методов
            if (MethodsUsed == null) throw new Exception("Ошибка метода " + Name + ": не определены методы, которые будет использованны");
            // клонирование входных параметров в выходные
            Params cP = (Params)p.Clone();
            Result result = cP.ToResult();
            result.ListP.Clear();
            // устанавливаем функцию
            f = p.Y;
            int n = cP.Y.Vars.Count; // количество переменных
            Params parMet = (Params)cP.Clone();
            do
            {
                for (int i = 1; i <= n; i++)
                {
                    if (result.ListX.Count != n + 1)
                    {
                        result.ListP.Add(-Functions.Math.GF(f, result.ListX[i - 1])[i - 1] * Vector.GetZeroBeside(n, i - 1));
                    } else
                    {
                        result.ListP[i - 1] = -Functions.Math.GF(f, result.ListX[i - 1])[i - 1] * Vector.GetZeroBeside(n, i - 1);
                    }
                    if (NormalizationDirections)
                    {
                        result.ListP[i - 1] = result.ListP[i - 1].Rationing();
                    }
                    parMet.X0 = result.ListX[i - 1];
                    parMet.P = result.ListP[i - 1];
                    parMet.H = cP.H;
                    Result resultMethods = MethodsUsed?.Run(parMet);
                    result.Alfas.Push(resultMethods.AlfaMin);
                    if (result.ListX.Count != n + 1)
                    {
                        result.ListX.Add(parMet.X0 + resultMethods.AlfaMin * parMet.P);
                    }
                    else
                    {
                        result.ListX[i] = parMet.X0 + resultMethods.AlfaMin * parMet.P;
                    }
                }
                Vector d = result.ListX[n] - result.ListX[0];
                if (Lim.CheckMinEps(f.Parse(result.ListX[0]), f.Parse(result.ListX[n])) ||
                    Lim.CheckMinEps(result.ListX[0], result.ListX[n]) ||
                    Lim.CheckNorma(d))
                {
                    break;
                }
                result.ListX[0] = result.ListX[n];
                result.K++;
            } while (result.K < Lim.K);

            result.XMin = result.ListX[result.ListX.Count - 1];

            return result;
        }
    }
}