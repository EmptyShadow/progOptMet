using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src.Parametrs.Output;
using MethodsOptimization.src.Functions;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class CalculatedRatios
    {
        public static double First(Function f, Vector x0, Vector p, OutputParams param)
        {
            if (param.alfa != null && param.alfa.Size == 3)
            {
                double a = param.alfa[0], b = param.alfa[1], c = param.alfa[2],
                    aa = a * a, bb = b * b, cc = c * c;
                double Fa = f.Parse(x0 + p * a),
                    Fb = f.Parse(x0 + p * b),
                    Fc = f.Parse(x0 + p * c);

                return 0.5 * (Fa * (bb - cc) + Fb * (cc - aa) + Fc * (aa - bb)) /
                    (Fa * (b - c) + Fb * (c - a) + Fc * (a - b));
            }
            return double.NaN;
        }

        public static double Second(Function f, Vector x0, Vector p, OutputParams param)
        {
            if (param.alfa != null && param.alfa.Size == 3)
            {
                double a = param.alfa[0], b = param.alfa[1], c = param.alfa[2],
                    aa = a * a, bb = b * b, cc = c * c;
                double Fa = f.Parse(x0 + p * a),
                    Fb = f.Parse(x0 + p * b),
                    Fc = f.Parse(x0 + p * c);

                return 0.5 * (a + b) + 0.5 * (Fa - Fb) * (b - c) * (c - a) /
                    (Fa * (b - c) + Fb * (c - a) + Fc * (a - b));
            }
            return double.NaN;
        }

        public static double Third(Function f, Vector x0, Vector p, OutputParams param)
        {
            if (param.alfa != null && param.alfa.Size == 3)
            {
                double a = param.alfa[0], b = param.alfa[1], c = param.alfa[2],
                    aa = a * a, bb = b * b, cc = c * c;
                double Fa = f.Parse(x0 + p * a),
                    Fb = f.Parse(x0 + p * b),
                    Fc = f.Parse(x0 + p * c);

                return b + 0.5 * ((b - a) * (b - a) * (Fb - Fc) - (b - c) * (b - c) * (Fb - Fa)) / 
                    ((b - a) * (Fb - Fc) - (b - c) * (Fb - Fa));
            }
            return double.NaN;
        }

        public static double Fourth(Function f, Vector x0, Vector p, OutputParams param)
        {
            if (param.alfa != null && param.alfa.Size == 3)
            {
                double a = param.alfa[0], b = param.alfa[1], c = param.alfa[2],
                    aa = a * a, bb = b * b, cc = c * c;
                double Fa = f.Parse(x0 + p * a),
                    Fb = f.Parse(x0 + p * b),
                    Fc = f.Parse(x0 + p * c);

                return b + 0.5 * (b - a) * (Fa - Fc) / (Fa - 2 * Fb + Fc);
            }
            return double.NaN;
        }

        public static double Fifth(Function f, Vector x0, Vector p, OutputParams param)
        {
            if (param.alfa != null && param.alfa.Size == 3)
            {
                double a = param.alfa[0], b = param.alfa[1], c = param.alfa[2],
                    aa = a * a, bb = b * b, cc = c * c;
                Vector xa = x0 + p * a, xb = x0 + p * b, xc = x0 + p * c;
                double Fa = f.Parse(xa),
                    Fb = f.Parse(xb + p * b),
                    Fc = f.Parse(xc),
                    dFa = Math.DirectionalDerivative(f, xa, p),
                    dFb = Math.DirectionalDerivative(f, xb, p),
                    dFc = Math.DirectionalDerivative(f, xc, p);

                double z = dFa + dFb + 3 * (Fa - Fb) / (b - a), 
                    w = System.Math.Sqrt(z * z - dFa * dFb),
                    g = (z + w - dFa) / (dFb - dFa + 2 * w);

                if (0.0 <= g && g <= 1.0)
                {
                    return a + g * (b - a);
                }
                if (g > 0)
                {
                    return a;
                }
                if (g > 1)
                {
                    return b;
                }
                    
            }
            return double.NaN;
        }
    }
}
