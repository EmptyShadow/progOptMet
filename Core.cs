using MethodsOptimization.src.Methods;
using MethodsOptimization.src.Methods.MultiDimensionalSearch;

namespace MethodsOptimization.src
{
    /// <summary>
    /// Core Singleton ядро приложения, в котором содержатся список методов, 
    /// список функций
    /// </summary>
    class Core
    {
        /// <summary>
        /// Ядро только одно
        /// </summary>
        protected static Core instance;

        /// <summary>
        /// Методы многомерного поиска
        /// </summary>
        public readonly Composite MDS;

        private Core()
        {
            // Инициализация скомпанованого списка методов
            MDS = new Composite();
            MDS.Add(new Swenn());
            MDS.Add(new GoldenSection1());
            MDS.Add(new Powell());
            MDS.Add(new Fibonacci2());
            MDS.Add(new Bolzano());

            MDS.Add(new Koshi());
            MDS.Add(new GaussSeidel());
            MDS.Add(new MethodСonjugateGradient());
        }

        /// <summary>
        /// Получение установленного ядра
        /// </summary>
        public static Core Instance
        {
            get
            {
                // если ядро не было инициализировано
                if (instance == null)
                {
                    // то устанавливаем его
                    instance = new Core();
                }
                // иначе возвращаем его
                return instance;
            }
        }
    }
}
