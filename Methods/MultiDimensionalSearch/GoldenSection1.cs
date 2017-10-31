using System;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class GoldenSection1: MultiDimSearch
    {
        public GoldenSection1()
        {
            Name = "Golden section 1";
        }
        
        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override Params Run(Params p, EmptyMethod method = null)
        {
            if (p.Alfa.Size != 2) throw new Exception("Ошибка метода " + Name + ": интервал локализации не состоит из двух чисел во входных данных");

            Params cP = (Params)p.Clone();
            CheckingCriterion checking = new CheckingCriterion(ref cP);
            // устанавливаем функцию
            f = cP.Y;

            double lambda =  GoldenNumbers.LambdaGoldenSection(cP.Alfa[0], cP.Alfa[1]),
            mu = GoldenNumbers.MuGoldenSection(cP.Alfa[0], cP.Alfa[1]);
            while(!checking.CheckNumIterat())
            {
                Vector x1 = X(cP.X0, cP.Alfa[0], cP.P);
                Vector x2 = X(cP.X0, cP.Alfa[1], cP.P);
                if (f.Parse(x1) < f.Parse(x2))
                {
                    cP.Alfa[1] = mu;
                    mu = lambda;
                    lambda = GoldenNumbers.LambdaGoldenSection(cP.Alfa[0], cP.Alfa[1]);
                }
                else
                {
                    cP.Alfa[0] = lambda;
                    lambda = mu;
                    mu = GoldenNumbers.MuGoldenSection(cP.Alfa[0], cP.Alfa[1]);
                }
                if (checking.CheckX(x1, x2) && checking.CheckF(x1, x2) && checking.CheckAlfa())
                {
                    break;
                }
                cP.K++;
            }

            return cP;
        }
    }
}
