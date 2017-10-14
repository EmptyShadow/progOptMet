using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsOptimization.src.Methods;
using MethodsOptimization.src.Methods.MultiDimensionalSearch;
using MethodsOptimization.src.Functions;

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
            //MDS.Add(new Koshi());
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
