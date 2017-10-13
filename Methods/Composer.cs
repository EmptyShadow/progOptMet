using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;
using System.Collections.Generic;

namespace MethodsOptimization.src.Methods
{
    /// <summary>
    /// Компановщик методов
    /// </summary>
    class Composer: Method
    {
        public Composer()
        {
            name = "Composer";
            listMs = new List<Method>();
        }

        override public double Run(ref Params parametrs)
        {
            foreach(Method m in listMs)
            {
                m.Run(ref parametrs);
            }
            return parametrs.output.f_x_;
        }

        /// <summary>
        /// Получение метода по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        override public Method GetMethodByName(string name)
        {
            if (listMs != null)
            {
                foreach (Method Ms in listMs)
                {
                    if (Ms.Name == name)
                    {
                        return Ms;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Добавление метода в компановщик
        /// </summary>
        /// <param name="m"></param>
        override public void Add(Method m)
        {
            if (listMs != null) listMs.Add(m);
        }

        /// <summary>
        /// скомпонованные методы
        /// </summary>
        private List<Method> listMs = null;
    }
}
