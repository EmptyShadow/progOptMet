using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Functions
{
    class Math
    {
        /// <summary>
        /// Частная производная
        /// </summary>
        /// <returns></returns>
        public delegate double PartialDerivative(Function f, Vector x, int numVar);

        /// <summary>
        /// Частная вторая производная
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="numVar1"></param>
        /// <param name="numVar2"></param>
        /// <returns></returns>
        public delegate double SecondPartialDerivative(Function f, Vector x, int numVar1, int numVar2);

        /// <summary>
        /// Функция частной прозводной
        /// </summary>
        public static PartialDerivative DFByIVar = RightFiniteDifferenceApproximation;

        /// <summary>
        /// Функция второй производной
        /// </summary>
        public static SecondPartialDerivative DDFByVars = DDFByVars1;

        /// <summary>
        /// Бесконечно малое преращение функции
        /// </summary>
        public static double H { get; set; } = 1e-7;

        /// <summary>
        /// Значение градиента в точке по направлению
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static double GF(Function f, Vector x, Vector p)
        {
            double summ = 0.0;
            Vector g = GF(f, x);
            if (x.Size == p.Size)
            {
                // Берем частные производные по каждой переменной и умножаем на орту
                for (int i = 0; i < x.Size; ++i)
                {
                    summ += g[i] * p[i];
                }
            }
            return summ;
        }

        /// <summary>
        /// Вектор градиента в точке
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector GF(Function f, Vector x)
        {
            if (DFByIVar == null) return null;
            Vector g = new Vector();
            // Берем частные производные по каждой переменной
            for (int i = 0; i < x.Size; ++i)
            {
                g.Push(DFByIVar(f, x, i));
            }
            return g;
        }

        /// <summary>
        /// Правая конечно-разностная аппроксимация
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="numVar"></param>
        /// <returns></returns>
        public static double RightFiniteDifferenceApproximation(Function f, Vector x, int numVar)
        {
            Vector x2 = (Vector)x.Clone();
            x2[numVar] += H;
            return (f.Parse(x2) - f.Parse(x)) / H;
        }

        /// <summary>
        /// Центральная конечно-разностная аппроксимация 1
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="numVar"></param>
        /// <returns></returns>
        public static double СentralFiniteDifferenceApproximation1(Function f, Vector x, int numVar)
        {
            Vector x2R = (Vector)x.Clone();
            Vector x2L = (Vector)x.Clone();
            x2R[numVar] += H;
            x2L[numVar] -= H;
            return (f.Parse(x2R) - f.Parse(x2L)) / H;
        }

        /// <summary>
        /// Центральная конечно-разностная аппроксимация 2
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="numVar"></param>
        /// <returns></returns>
        public static double СentralFiniteDifferenceApproximation2(Function f, Vector x, int numVar)
        {
            Vector x2R = (Vector)x.Clone();
            Vector x2L = (Vector)x.Clone();
            x2R[numVar] += H;
            x2L[numVar] -= H;
            return (f.Parse(x2L) - 4 * f.Parse(x) + 3 *f.Parse(x2R)) / (2 * H);
        }

        /// <summary>
        /// Центральная конечно-разностная аппроксимация 3
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="numVar"></param>
        /// <returns></returns>
        public static double СentralFiniteDifferenceApproximation3(Function f, Vector x, int numVar)
        {
            Vector x2 = (Vector)x.Clone();
            x2[numVar] += 2 * H;
            double f2R = f.Parse(x2);
            x2[numVar] -= H;
            double fR = f.Parse(x2);
            x2[numVar] -= 2 * H;
            double fL = f.Parse(x2);
            x2[numVar] -= H;
            double f2L = f.Parse(x2);
            return (-f2R + 8 * fR - 8 * fL + f2L) / (12 * H);
        }

        /// <summary>
        /// Вторая частная производная формула 1
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="numVar1"></param>
        /// <param name="numVar2"></param>
        /// <returns></returns>
        public static double DDFByVars1(Function f, Vector x, int numVar1, int numVar2)
        {
            Vector x2i = (Vector)x.Clone();
            Vector x2j = (Vector)x.Clone();
            Vector x2ij = (Vector)x.Clone();
            x2i[numVar1] += H;
            x2j[numVar2] += H;
            x2ij[numVar1] += H;
            x2ij[numVar2] += H;
            return (f.Parse(x2ij) - f.Parse(x2i) - f.Parse(x2j) + f.Parse(x)) / H / H;
        }

        /// <summary>
        /// Вторая частная производная формула 2
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="numVar1"></param>
        /// <param name="numVar2"></param>
        /// <returns></returns>
        public static double DDFByVars2(Function f, Vector x, int numVar1, int numVar2)
        {
            Vector x2PP = (Vector)x.Clone();
            Vector x2PM = (Vector)x.Clone();
            Vector x2MP = (Vector)x.Clone();
            Vector x2MM = (Vector)x.Clone();
            x2PP[numVar1] += H;
            x2PP[numVar2] += H;
            x2PM[numVar1] += H;
            x2PM[numVar2] -= H;
            x2MP[numVar1] -= H;
            x2MP[numVar2] += H;
            x2MM[numVar1] -= H;
            x2MM[numVar2] -= H;
            return (f.Parse(x2PP) - f.Parse(x2PM) - f.Parse(x2MP) + f.Parse(x2MM)) / (4 * H * H);
        }

        public static Vector GetTheSolutionOfTheSystem(Matrix system, Vector vector)
        {
            if (system.CountRows != vector.Size) { return null; }
            return CramerMethod(system, vector);
        }

        /// <summary>
        /// Метод Крамера дл решения систем линейных уравнений
        /// </summary>
        /// <param name="system"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector CramerMethod(Matrix system, Vector vector)
        {
            double det = system.Det();
            Vector solutionOfSystem = new Vector();
            for (int i = 0; i < system.CountColumns; i++)
            {
                Matrix matrixReplaseIColumn = system.ReplaceColumnAt(vector, i);
                double detI = matrixReplaseIColumn.Det();
                solutionOfSystem.Push(detI / det);
            }
            return solutionOfSystem;
        }

        /// <summary>
        /// Получить Гессиан в точке
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Matrix GetMatrixHessianInPoint(Function f, Vector x)
        {
            Matrix matrix = new Matrix(x.Size, x.Size);

            for (int i = 0; i < matrix.CountRows; i++)
            {
                for (int j = 0; j < matrix.CountColumns; j++)
                {
                    matrix[i, j] = DDFByVars(f, x, i, j);
                }
            }

            return matrix;
        }
    }
}
