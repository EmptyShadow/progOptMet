using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;
using System.Collections.Generic;

namespace MethodsOptimization.src.Methods
{
    /// <summary>
    /// Компановщик методов
    /// </summary>
    class Composite: EmptyMethod
    {
        /// <summary>
        /// скомпонованные методы
        /// </summary>
        private List<EmptyMethod> listMs = null;

        public Composite()
        {
            name = "Composer methods";
            listMs = new List<EmptyMethod>();
        }

        override public double Run(ref Params parametrs, EmptyMethod m = null)
        {
            foreach(EmptyMethod Ms in listMs)
            {
                Ms.Run(ref parametrs, m);
                parametrs.WriteOutputInInput();
            }

            return parametrs.GetAlfa_ByOut();
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
                    if (Ms.GetName() == name)
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

        protected override bool SEC(InputParams In, OutputParams Out)
        {
            throw new System.NotImplementedException();
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
