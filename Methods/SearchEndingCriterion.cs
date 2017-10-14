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
        public bool SEC(InputParams In, OutputParams Out)
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
        protected bool CheckK(int k)
        {
            if (!Lim.Flags.K) return true;
            return Lim.CheckNumIteration(k);
        }

        /// <summary>
        /// Проверка критерия по аргументу
        /// </summary>
        /// <param name="p"></param>
        /// <param name="norma"></param>
        /// <returns></returns>
        protected bool CheckArg(Vector a, Vector b)
        {
            if (!Lim.Flags.NormaArg) return true;
            return Lim.CheckEPS(Lim.Flags.NormaArg, (a - b).Norma);
        }
        /// <summary>
        /// Проверка критерия по длине шага до следующей точки
        /// </summary>
        /// <param name="alfa"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        protected bool CheckLengthH(Vector alfa, Vector p)
        {
            if (!Lim.Flags.NormaLengthH) return true;
            bool rez = false;
            for (int i = 0; i < alfa.Size && !rez; i++)
            {
                rez |= Lim.CheckEPS(Lim.Flags.NormaLengthH, (alfa[i] * p).Norma);
            }
            return rez;
        }
        /// <summary>
        /// Проверка критерия по значению функции
        /// </summary>
        /// <param name="p"></param>
        /// <param name="norma"></param>
        /// <returns></returns>
        protected bool CheckF(Function f, Vector x1, Vector x2)
        {
            if (!Lim.Flags.NormaValue) return true;
            double f1 = f.Parse(x1), f2 = f.Parse(x2);
            return Lim.CheckEPS(Lim.Flags.NormaValue, f1 - f2);
        }
        /// <summary>
        /// Проверка погрешности градиента
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        protected bool CheckGF(Function f, Vector x, Vector p)
        {
            if (!Lim.Flags.NormaGradienta) return true;
            return Lim.CheckEPS(Lim.Flags.NormaGradienta, Math.GF(f, x, p));
        }
    }
}
