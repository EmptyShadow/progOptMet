using MethodsOptimization.src.Methods;
using MethodsOptimization.src.Methods.MultiDimensionalSearch;
using MethodsOptimization.src.Methods.LinearSearch;

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
        /// Методы
        /// </summary>
        public readonly Composite Methods;

        private Core()
        {

            // Инициализация скомпанованого списка методов многомерного линейного поиска
            Composite MDS = new Composite("Методы линейного поиска");
            MDS.Add(new Swenn());
            MDS.Add(new GoldenSection1());
            MDS.Add(new Powell());
            MDS.Add(new Fibonacci2());
            MDS.Add(new Bolzano());
            MDS.Add(new CubicInterpolation());
            MDS.Add(new Dichotomy());
            MDS.Add(new Davidon());

            // Инициализация скомпанованого списка методов многомерного градиентного поиска
            Composite MGD = new Composite("Методы многомерного поиска");
            MGD.Add(new Koshi());
            MGD.Add(new GaussSeidel());
            MGD.Add(new MethodСonjugateGradient());
            MGD.Add(new Partan3());
            MGD.Add(new NewtonGeneralizedMethod());

            Methods = new Composite("Методы");
            Methods.Add(MDS);
            Methods.Add(MGD);
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
