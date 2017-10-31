using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods
{
    /// <summary>
    /// Пустой метод для наследования и частичной реализации
    /// </summary>
    abstract class EmptyMethod
    {
        /// <summary>
        /// Имя метода
        /// </summary>
        public virtual string Name { get; set; } = "Empty method";

        /// <summary>
        /// Функция с которой работаем
        /// </summary>
        protected Function f;

        public EmptyMethod() { }

        /// <summary>
        /// Запуск на исполнение метода, который может вызывать один или несколько методов
        /// </summary>
        /// <param name="parametrs"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        abstract public Params Run(Params p, EmptyMethod m = null);

        /// <summary>
        /// Метод вычисления функции
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        abstract protected double F(Vector x, double Alfa = 0.0, Vector p = null);

        /// <summary>
        /// Получение следующего вектора
        /// </summary>
        /// <param name="x"></param>
        /// <param name="Alfa"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        abstract protected Vector X(Vector x, double Alfa = 0.0, Vector p = null);

        /// <summary>
        /// Получение метода по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        abstract public EmptyMethod GetMethodByName(string name);

        /// <summary>
        /// Добавление метода в компановщик
        /// </summary>
        /// <param name="m"></param>
        abstract public void Add(EmptyMethod m);

        new virtual public string ToString()
        {
            return "Method: " + Name + "\n";
        }
    }
}
