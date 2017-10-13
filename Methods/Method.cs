using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;

namespace MethodsOptimization.src.Methods
{
    /// <summary>
    /// Метод оптимизации
    /// </summary>
    class Method
    {
        /// <summary>
        /// Имя метода
        /// </summary>
        protected string name = "";
        /// <summary>
        /// Функция с которой работаем
        /// </summary>
        protected Function f = null;

        protected Method() {}

        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="parametrs"></param>
        /// <returns></returns>
        virtual public double Run(ref Params parametrs) { return double.NaN; }

        /// <summary>
        /// Метод вычисления функции
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        virtual protected double F(Vector x, double Alfa = 0.0, Vector p = null) { return double.NaN; }

        /// <summary>
        /// Получение следующего вектора
        /// </summary>
        /// <param name="x"></param>
        /// <param name="Alfa"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        virtual protected Vector X(Vector x, double Alfa = 0.0, Vector p = null) { return null; }

        /// <summary>
        /// Получение имени метода
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Получение метода по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        virtual public Method GetMethodByName(string name) { return null; }

        /// <summary>
        /// Добавление метода в компановщик
        /// </summary>
        /// <param name="m"></param>
        virtual public void Add(Method m) { }

        new virtual public string ToString()
        {
            return "Method " + name;
        }
    }
}
