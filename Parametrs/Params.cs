using System;
using MethodsOptimization.src.Parametrs.Flags;
using MethodsOptimization.src.Parametrs.Input;
using MethodsOptimization.src.Parametrs.Output;
using MethodsOptimization.src.Parametrs.Vars;

namespace MethodsOptimization.src.Parametrs
{
    class Params: ICloneable
    {
        public Params() { }

        public InputParams input = new InputParams(); // входные параметры
        public OutputParams output = new OutputParams(); // результат
        public LimitingFlags flags = new LimitingFlags(); // флаги

        string logs = "**************\n*****Logs*****\n**************\n"; // логи

        /// <summary>
        /// Запись построчно в логи
        /// </summary>
        /// <param name="log">Строка которую записывают</param>
        public void writelnInLogs(string log)
        {
            logs += log;
        }

        /// <summary>
        /// Преобразование параметров к строке
        /// </summary>
        /// <returns></returns>
        new public string ToString()
        {
            string str = "Parametrs:\n";
            str += input.ToString().Replace("\t", "\t\t");
            str += output.ToString().Replace("\t", "\t\t");
            str += flags.ToString().Replace("\t", "\t\t");
            return str;
        }
        /// <summary>
        /// Создание копии объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Params clone = new Params();
            clone.input = (InputParams)input.Clone();
            clone.output = (OutputParams)output.Clone();
            clone.flags = (LimitingFlags)flags.Clone();
            return clone;
        }

        public string Logs
        {
            get
            {
                return (string)logs.Clone();
            }
        }
    }
}
