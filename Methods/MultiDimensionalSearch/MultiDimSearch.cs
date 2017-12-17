using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    abstract class MultiDimSearch: LinearSearch.LinSearch
    {
        public MultiDimSearch()
        {
            Name = "Метод многомерного поиска";
        }
    }
}
