using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Views
{
    public class DataFunctionForm
    {
        public Function Function { get; set; }
        public Vector X { get; set; }
        public Vector P { get; set; }

        public DataFunctionForm() {}
    }
}
