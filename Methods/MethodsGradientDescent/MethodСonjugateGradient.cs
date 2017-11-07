using MethodsOptimization.src.Methods.MultiDimensionalSearch;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.MethodsGradientDescent
{
    class MethodСonjugateGradient: MultiDimSearch
    {
        public MethodСonjugateGradient()
        {
            Name = "Method conjugate gradient";
        }

        public override Params Run(Params p, EmptyMethod m = null)
        {
            if (m == null) throw new System.Exception("Ошибка метода " + Name + ": не определены методы, которые будет использованны");
            Params cP = (Params)p.Clone();
            CheckingCriterion checking = new CheckingCriterion(ref cP);
            // устанавливаем функцию
            f = p.Y;
            cP.K = 1;
            int n = p.Y.Vars.Count;
            Vector g;
            double beta_km;
            Params searchP;
            cP.Alfa = new Vector();

            do
            {
                g = Functions.Math.GF(cP.Y, cP.X0);
                if (cP.K % n == 1)
                {
                    cP.P = -g;
                }
                else
                {
                    /// получаем сопряженный коэф направления
                    beta_km = ConjugateDirection.MethodPolakRibiere(g, -cP.P);
                    cP.P = -g + beta_km * cP.P;
                }
                searchP = m.Run(cP); /// поиск alfa_
                cP.Alfa.Push(searchP.GetAlfa_()); // сохранение коэф. для направления минимизации
                cP.X0 = X(cP.X0, cP.Alfa.Last, cP.P);
                cP.K++;
                /// проверяем критерий Пауэлла
            } while (/*!(g * cP.P <= 0.2 * g.Norma)*/!(g.Norma * g.Norma <= cP.Lim.EpsNormaGradienta) && cP.K < cP.Lim.K);

            return cP;
        }
    }
}
