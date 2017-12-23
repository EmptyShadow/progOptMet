using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Methods.MultiDimensionalSearch.Utils;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class MethodWithVariableMetric : MultiDimSearch
    {
        public MethodWithVariableMetric()
        {
            Name = "Метод переменой метрики";
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

            Params usesParams = (Params)cP.Clone();

            Matrix A = null;
            int n = f.Vars.Count;
            Vector gk = null, gkm = null;
            do
            {
                // Шаг 1 найти матрицу переменной метрики
                gk = Functions.Math.GF(f, result.GetLastX());
                if (result.K % n == 1)
                {
                    // единичная матрица
                    A = Matrix.GetIdentity(n);
                }
                else
                {
                    Vector gammak = gk - gkm;
                    Vector skm = A * gammak;
                    Vector deltaxkm = result.GetLastX() - result.ListX[result.ListX.Count - 2];
                    A = Metrics.RunMetric?.Invoke(A, gammak, skm, deltaxkm);
                }
                // Шаг 2 поиск направления поиска
                Vector P = -A * gk;
                if (NormalizationDirections && P.Norma > 1.0)
                {
                    P = P.Rationing();
                }
                result.ListP.Add(P);

                usesParams.X0 = result.GetLastX();
                usesParams.P = result.GetLastP();
                usesParams.H = cP.H;
                //Шаг 3 получение альфа
                result.Alfas.Push(MethodsUsed.Run(usesParams).AlfaMin);
                // Шаг 4 получение новой точки
                result.ListX.Add(X(result.GetLastX(), result.Alfas.Last, result.GetLastP()));
                // Шаг 3
                Vector gkmprev = gkm;
                gkm = Functions.Math.GF(f, result.GetLastX());
                if (Lim.CheckNorma(result.GetLastP()) || 
                    Lim.CheckNorma(gkm) ||
                    Lim.CheckNorma(gkm) ||
                    Lim.CheckMinEps(result.GetLastX(), result.ListX[result.ListX.Count - 2]) ||
                    Lim.CheckMinEps(result.GetLastX(), result.ListX[0]))
                {
                    break;
                }
                gkm = gk;
                result.K++;
            } while (result.K < Lim.K);

            result.XMin = result.GetLastX();

            return result;
        }
    }
}
