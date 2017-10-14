using System;

namespace MethodsOptimization.src.Parametrs.Flags
{
    /// <summary>
    /// Флаги ограничений
    /// </summary>
    class LimitingFlags : ICloneable
    {
        public LimitingFlags() { }

        /// <summary>
        /// ограничение по количеству итераций
        /// </summary>
        public bool K { get; set; } = true;
        /// <summary>
        /// ограничение по погрешности производной
        /// </summary>
        public bool NormaGradienta { get; set; } = true;
        /// <summary>
        /// Ограничение по погрешности аргументов
        /// </summary>
        public bool NormaArg { get; set; } = true;
        /// <summary>
        /// Ограничение по погрешности аргументов
        /// </summary>
        public bool NormaLengthH { get; set; } = true;
        /// <summary>
        /// Огранчение по погрешности значения функции
        /// </summary>
        public bool NormaValue { get; set; } = false;

        /// <summary>
        /// Преобразование к строке
        /// </summary>
        /// <returns>Строка флагов</returns>
        new public string ToString()
        {
            string str = "Limiting flags:\n";
            str += "\tK: " + K + ";\n";
            str += "\tNorma gradienta: " + NormaGradienta + ";\n";
            str += "\tNorma arg: " + NormaArg + ";\n";
            str += "\tNorma length H: " + NormaLengthH + ";\n";
            str += "\tNorma value: " + NormaValue + ";\n";
            return str;
        }
        
        /// <summary>
        /// Копирование экземпляра
        /// </summary>
        /// <returns>Копия экземпляра</returns>
        public object Clone()
        {
            LimitingFlags clone = new LimitingFlags();
            clone.K = K;
            clone.NormaArg = NormaArg;
            clone.NormaGradienta = NormaGradienta;
            clone.NormaLengthH = NormaLengthH;
            clone.NormaValue = NormaValue;
            return clone;
        }
    }
}
