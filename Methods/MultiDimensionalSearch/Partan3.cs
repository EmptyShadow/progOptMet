using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Methods.MultiDimensionalSearch.Utils;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class Partan3 : MultiDimSearch
    {
        public Partan3()
        {
            Name = "Партан 3";
            usesOthersMethods = true;
        }

        public override Result Run(Params p)
        {
            // проверка переданных методов
            if (MethodsUsed == null) throw new System.Exception("Ошибка метода " + Name + ": не определены методы, которые будет использованны");
            // клонирование входных параметров в выходные
            Params cP = (Params)p.Clone();
            Result result = cP.ToResult();
            result.ListP.Clear();
            // устанавливаем функцию
            f = p.Y;

            int n = cP.Y.Vars.Count; // количество переменных
            Params parMet = (Params)cP.Clone();
            result.ListX = new System.Collections.Generic.List<Vector>() { null, null, null, null };
            result.ListP = new System.Collections.Generic.List<Vector>() { null, null, null, null };
            result.Alfas = new Vector(new double[4]);

            // получаем x1
            result.ListX[0] = cP.X0;
            do
            {
                int i = 0;
                //Шаг 1 получаем x2
                parMet.X0 = result.ListX[0];

                result.ListP[0] = -Math.GF(f, result.ListX[0]);
                if (NormalizationDirections)
                {
                    result.ListP[0] = result.ListP[0].Rationing();
                }
                parMet.P = result.ListP[0];
                parMet.H = p.H;

                Result resultMethods = MethodsUsed.Run(parMet);
                result.Alfas[0] = resultMethods.AlfaMin;

                result.ListX[1] = X(result.ListX[0], result.Alfas[0], parMet.P);
                //Шаг 2 получаем x3, x4
                do
                {
                    // x3
                    parMet.X0 = result.ListX[1];

                    result.ListP[1] = -Math.GF(f, result.ListX[1]);
                    if (NormalizationDirections)
                    {
                        result.ListP[1] = result.ListP[1].Rationing();
                    }
                    parMet.P = result.ListP[1];
                    parMet.H = p.H;

                    resultMethods = MethodsUsed.Run(parMet);
                    result.Alfas[1] = resultMethods.AlfaMin;

                    result.ListX[2] = X(result.ListX[1], result.Alfas[1], parMet.P);
                    // x4
                    Vector d1 = result.ListX[2] - result.ListX[0];
                    result.Betas.Push(ConjugateDirection.MethodPolakRibiere(Math.GF(f, result.ListX[1]), Math.GF(f, result.ListX[0])));
                    result.ListX[3] = result.ListX[2] + result.Betas.Last * d1;
                    i++;
                    // Шаг 3
                    if (i < n - 1)
                    {
                        result.ListX[0] = result.ListX[1];
                        result.ListX[1] = result.ListX[3];
                    }
                } while (i < n - 1);
                if (Lim.CheckMinEps(result.ListX[3], cP.X0) || Lim.CheckMinEps(f.Parse(result.ListX[3]), f.Parse(cP.X0)))
                {
                    break;
                }
                cP.X0 = result.ListX[0] = result.ListX[3];
                result.K++;
            } while (result.K < Lim.K);

            result.XMin = cP.X0;

            //cP.X0 = xs[3];
            return result;
        }
    }
}
