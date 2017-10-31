namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class FibonacciNumbers
    {
        /// <summary>
        /// Получение n-ого числа Фибоначчи
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double getNNumberFibonacci(int n)
        {
            if (n == 0)
            {
                return 0.0;
            }
            else if (n == 1 || n == 2)
            {
                return 1.0;
            }
            double fkmm = 1.0, fkm = 1.0, k = 2, fk;
            do
            {
                fk = fkm + fkmm;
                fkmm = fkm;
                fkm = fk;
                k++;
            } while (k < n);
            return fk;
        }
        /// <summary>
        /// Получение числа Фибоначчи, которое больше fn
        /// </summary>
        /// <param name="fn"></param>
        /// <param name="n"> номер найденного числа</param>
        /// <returns>Число Фибоначчи</returns>
        public static double getPrevNumberFibonacci(double fn, ref int n)
        {
            n = 2;
            if (fn < 1.0)
            {
                return 1.0;
            }
            double fkmm = 1.0, fkm = 1.0, fk;
            do
            {
                fk = fkm + fkmm;
                fkmm = fkm;
                fkm = fk;
                n++;
            } while (fk <= fn);
            return fk;
        }
    }
}
