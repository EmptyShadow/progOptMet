using System;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class GoldenNumbers
    {
        public static double LambdaGoldenSection(double a1, double b1)
        {
            double t = (3.0 - Math.Sqrt(5.0)) / 2.0;
            return a1 + t * Math.Abs(b1 - a1);
        }

        public static double MuGoldenSection(double a1, double b1)
        {
            double t = (Math.Sqrt(5.0) - 1.0) / 2.0;
            return a1 + t * Math.Abs(b1 - a1);
        }
    }
}
