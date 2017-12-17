using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods
{
    /// <summary>
    /// Пустой метод для наследования и частичной реализации
    /// </summary>
    public abstract class EmptyMethod
    {
        /// <summary>
        /// Имя метода
        /// </summary>
        public virtual string Name { get; set; } = "Empty method";

        /// <summary>
        /// Нормированные вектора направлений
        /// </summary>
        public bool NormalizationDirections { get; set; } = false;
        
        /// <summary>
        /// Функция с которой работаем
        /// </summary>
        protected Function f;

        /// <summary>
        /// Используемые методы
        /// </summary>
        public EmptyMethod MethodsUsed { get; set; }

        /// <summary>
        /// Метод использует другие методы
        /// Если установленно true, то MethodsUsed не должны быть null
        /// </summary>
        protected bool usesOthersMethods = false;

        /// <summary>
        /// Метод использует другие методы
        /// </summary>
        public bool UsesOthersMethods { get; }

        /// <summary>
        /// Параметры ограничения
        /// </summary>
        public LimParams Lim { get; set; } = new LimParams();

        public EmptyMethod() { }

        /// <summary>
        /// Запуск на исполнение метода, который может вызывать один или несколько методов
        /// </summary>
        /// <param name="parametrs"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        abstract public Result Run(Params p);

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
