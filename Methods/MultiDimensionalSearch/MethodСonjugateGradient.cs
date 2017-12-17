using MethodsOptimization.src.Methods.MultiDimensionalSearch;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Methods.MultiDimensionalSearch.Utils;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class MethodСonjugateGradient: MultiDimSearch
    {
        public MethodСonjugateGradient()
        {
            Name = "Метод сопряженных градиентов";
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
            Vector g;

            do
            {
                g = Functions.Math.GF(f, cP.X0);
                if (NormalizationDirections)
                {
                    g = g.Rationing();
                }
                if (result.K % n == 1)
                {
                    cP.P = -g;
                }
                else
                {
                    /// получаем сопряженный коэф направления
                    result.Betas.Push(ConjugateDirection.MethodPolakRibiere(g, -cP.P));
                    cP.P = -g + result.Betas.Last * cP.P;
                }
                result.ListP.Add(cP.P);

                Result resultMethods = MethodsUsed.Run(cP); /// поиск alfa_

                result.Alfas.Push(resultMethods.AlfaMin); // сохранение коэф. для направления минимизации
                cP.X0 = X(cP.X0, result.Alfas.Last, cP.P);
                result.ListX.Add(cP.X0);
                result.K++;
                /// проверяем критерий Пауэлла
                if (/*!(g * cP.P <= 0.2 * g.Norma)*/g.Norma * g.Norma <= Lim.Eps)
                {
                    break;
                }
            } while (result.K < Lim.K);

            return result;
        }
    }
}
