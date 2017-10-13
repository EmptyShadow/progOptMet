using System;
using System.Collections.Generic;
using MethodsOptimization.src.Functions.Parsers;

namespace MethodsOptimization.src.Functions
{
    class Function: MathParser
    {
        public Function(string s): base(s) {}

        new public string ToString()
        {
            string str = "Function: " + function + ";\n\tVariables:";
            foreach(string key in this.Vars)
            {
                str += " " + key + ",";
            }
            str = str.Substring(0, str.Length - 1);
            str += ";";
            return str;
        }
    }
}
