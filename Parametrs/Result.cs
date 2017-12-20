using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Parametrs
{
    /// <summary>
    /// Результат работы метода
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Количество итераций
        /// </summary>
        public int K { get; set; } = 1;

        /// <summary>
        /// Список точек
        /// </summary>
        public List<Vector> ListX { get; set; } = new List<Vector>();

        /// <summary>
        /// Список направлений
        /// </summary>
        public List<Vector> ListP { get; set; } = new List<Vector>();

        /// <summary>
        /// Вектор значений коэффициентов альфа
        /// </summary>
        public Vector Alfas { get; set; } = new Vector();

        /// <summary>
        /// Коэффициент альфа до минимума
        /// </summary>
        public double AlfaMin { get; set; } = double.NaN;

        /// <summary>
        /// Аргумент минимума
        /// </summary>
        public Vector XMin { get; set; }

        /// <summary>
        /// Вектор ускоряющих шагов
        /// </summary>
        public Vector Betas { get; set; } = new Vector();

        public Result() { }

        /// <summary>
        /// Получить точку минимума
        /// </summary>
        /// <returns></returns>
        public Vector GetMinPoint()
        {
            return ListX?.Last();
        }

        public Vector GetLastX()
        {
            return ListX.Last();
        }

        public Vector GetLastP()
        {
            return ListP.Last();
        }
    }
}
