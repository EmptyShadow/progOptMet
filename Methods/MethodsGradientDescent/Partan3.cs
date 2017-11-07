using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.MethodsGradientDescent
{
    class Partan3 : MultiDimensionalSearch.MultiDimSearch
    {
        public Partan3()
        {
            Name = "Partan 3";
        }

        public override Params Run(Params p, EmptyMethod m = null)
        {
            // проверка переданных методов
            if (m == null) throw new System.Exception("Ошибка метода " + Name + ": не определены методы, которые будет использованны");
            // клонирование входных параметров в выходные
            Params cP = (Params)p.Clone();
            // создание проверяющего КОП
            CheckingCriterion checking = new CheckingCriterion(ref cP);
            // устанавливаем функцию
            f = p.Y;

            int n = cP.Y.Vars.Count; // количество переменных
            Params parMet = (Params)cP.Clone();
            Vector[] xs = new Vector[4];

            // получаем x1
            xs[0] = cP.X0;
            do
            {
                int i = 0;
                //Шаг 1 получаем x2
                parMet.X0 = xs[0];
                parMet.P = -Math.GF(f, xs[0]);
                parMet.Alfa_h = 1e-2;
                parMet = m.Run(parMet);
                xs[1] = X(xs[0], parMet.GetAlfa_(), parMet.P);
                //Шаг 2 получаем x3, x4
                do
                {
                    // x3
                    parMet.X0 = xs[1];
                    parMet.P = -Math.GF(f, xs[1]);
                    parMet.Alfa_h = 1e-2;
                    parMet = m.Run(parMet);
                    xs[2] = X(xs[1], parMet.GetAlfa_(), parMet.P);
                    // x4
                    Vector d1 = xs[2] - xs[0];
                    xs[3] = xs[2] + ConjugateDirection.MethodPolakRibiere(Math.GF(f, xs[1]), Math.GF(f, xs[0])) * d1;
                    i++;
                    // Шаг 3
                    if (i < n - 1)
                    {
                        xs[0] = xs[1];
                        xs[1] = xs[3];
                    }
                } while (i < n - 1);
                if (checking.CheckX(xs[3], cP.X0) || checking.CheckF(xs[3], cP.X0))
                {
                    break;
                }
                cP.X0 = xs[0] = xs[3];
                cP.K++;
            } while (!checking.CheckNumIterat());

            //cP.X0 = xs[3];
            return cP;
        }
    }
}
