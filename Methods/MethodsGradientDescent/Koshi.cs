using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    
    class Koshi: MultiDimSearch
    {
        public Koshi()
        {
            Name = "Koshi";
        }

        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        override public Params Run(Params p, EmptyMethod methods)
        {
            if (methods == null) throw new System.Exception("Ошибка метода " + Name + ": не определены методы, которые будет использованны");
            Params cP = (Params)p.Clone();
            CheckingCriterion checking = new CheckingCriterion(ref cP);
            // устанавливаем функцию
            f = p.Y;
            
            Vector xk = cP.X0, xk_p;

            // параметры для поиска минимума на k-ом шаге
            Params pSerch = (Params)p.Clone();

            while(!checking.CheckNumIterat())
            {
                // получаю направление
                pSerch.P = -Functions.Math.GF(cP.Y, xk);
                pSerch.X0 = xk;
                // получаю шаг до минимума
                pSerch = methods.Run(pSerch);
                cP.Alfa.Push(pSerch.GetAlfa_());
                // получаю следующий вектор
                xk_p = xk + cP.Alfa.Last * pSerch.P;
                System.Console.WriteLine(xk_p.ToString());
                // проверяю коп
                if (checking.CheckX(xk_p, xk) &&
                    checking.CheckNormaGF(pSerch.P) &&
                    checking.CheckF(xk, xk_p))
                {
                    break;
                }
                xk= xk_p;
                cP.K++;
            }

            return cP;
        }
    }
}
