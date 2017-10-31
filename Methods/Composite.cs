using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using System.Collections.Generic;

namespace MethodsOptimization.src.Methods
{
    /// <summary>
    /// Компановщик методов
    /// </summary>
    class Composite : EmptyMethod
    {
        /// <summary>
        /// скомпонованные методы
        /// </summary>
        private List<EmptyMethod> listMs = null;

        public Composite()
        {
            Name = "Composer methods";
            listMs = new List<EmptyMethod>();
        }

        override public Params Run(Params p, EmptyMethod m = null)
        {
            Params cP = (Params)p.Clone();
            foreach(EmptyMethod Ms in listMs)
            {
                cP = Ms.Run(cP, m);
                cP.K = 1;
            }

            return cP;
        }

        /// <summary>
        /// Получение метода по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        override public EmptyMethod GetMethodByName(string name)
        {
            if (listMs != null)
            {
                foreach (EmptyMethod Ms in listMs)
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
        override public void Add(EmptyMethod m)
        {
            if (listMs != null) listMs.Add(m);
        }

        protected override double F(Vector x, double Alfa = 0, Vector p = null)
        {
            throw new System.NotImplementedException();
        }

        protected override Vector X(Vector x, double Alfa = 0, Vector p = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
