using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Functions.Parsers
{
    /// <summary>
    /// Класс резльтата вычислений парсера
    /// </summary>
    class Result
    {
        public readonly double acc; // значение функции на текущем этапе
        public readonly string rest; // остаток функции

        public Result(double acc, string rest)
        {
            this.acc = acc;
            this.rest = rest;
        }
    }
}
