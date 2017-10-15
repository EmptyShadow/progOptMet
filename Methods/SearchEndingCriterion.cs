using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src.Functions;

namespace MethodsOptimization.src.Methods
{
    /// <summary>
    /// Критерии окончания поиска
    /// </summary>
    class SearchEndingCriterion
    {
        LimitingParams Lim { get; set; }

        public SearchEndingCriterion(LimitingParams lim)
        {
            Lim = lim;
        }

        /// <summary>
        /// Проверка критерия окончания поиска
        /// </summary>
        /// <param name="In">Входные данные</param>
        /// <param name="Out">Результаты вычисления</param>
        /// <returns>Если все критерии вернут true, то критерий выполнен true, иначе false</returns>
        public bool FullSEC(InputParams In, OutputParams Out)
        {
            Vector x1 = In.X0 + Out.Alfa.First * In.P,
                x2 = In.X0 + Out.Alfa.Last * In.P;
            return CheckArg(x1, x2) &&
                CheckLengthH(Out.Alfa, In.P) &&
                CheckF(In.Y, x1, x2) &&
                CheckGF(In.Y, x1, In.P) &&
                CheckGF(In.Y, x2, In.P);
        }

        /// <summary>
        /// Проверка критерия по ключу
        /// </summary>
        /// <param name="fm"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CheckK(int k)
        {
            return Lim.CheckNumIteration(k);
        }

        /// <summary>
        /// Проверка критерия по аргументу
        /// </summary>
        /// <param name="p"></param>
        /// <param name="norma"></param>
        /// <returns></returns>
        public bool CheckArg(Vector a, Vector b)
        {
            return Lim.CheckEPS((a - b).Norma);
        }
        /// <summary>
        /// Проверка критерия по длине шага до следующей точки
        /// </summary>
        /// <param name="alfa"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool CheckLengthH(Vector alfa, Vector p)
        {
            bool rez = false;
            for (int i = 0; i < alfa.Size && !rez; i++)
            {
                rez |= Lim.CheckEPS((alfa[i] * p).Norma);
            }
            return rez;
        }
        /// <summary>
        /// Проверка критерия по значению функции
        /// </summary>
        /// <param name="p"></param>
        /// <param name="norma"></param>
        /// <returns></returns>
        public bool CheckF(Function f, Vector x1, Vector x2)
        {
            double f1 = f.Parse(x1), f2 = f.Parse(x2);
            return Lim.CheckEPS(f1 - f2);
        }
        /// <summary>
        /// Проверка погрешности градиента
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool CheckGF(Function f, Vector x, Vector p)
        {
            return Lim.CheckEPS(Math.GF(f, x, p));
        }
    }
}
