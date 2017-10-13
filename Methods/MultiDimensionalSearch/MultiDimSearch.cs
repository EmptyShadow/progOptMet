using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Output;
using MethodsOptimization.src.Parametrs.Input;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class MultiDimSearch: Method
    {
        public MultiDimSearch()
        {
            name = "MultiDimensionalSearch";
        }
        
        /// <summary>
        /// Метод вычисления функции
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        override protected double F(Vector x, double Alfa, Vector p)
        {
            if (f != null && x != null && p != null)
            {
                return f.Parse(X(x, Alfa, p));
            }
            return double.NaN;
        }

        /// <summary>
        /// Вычисление следующего вектора
        /// </summary>
        /// <param name="x"></param>
        /// <param name="Alfa"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        override protected Vector X(Vector x, double Alfa, Vector p)
        {
            return x + Alfa * p;
        }

        /// <summary>
        /// Производная в отчке по направлению
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        virtual protected double dF(Vector x, Vector p)
        {
            return Math.DirectionalDerivative(f, x, p);
        }

        virtual protected double GdF(Vector x, Vector p)
        {
            return Math.Gradient(f, x, p);
        }

        virtual protected Vector GdF(Vector x)
        {
            return Math.Gradient(f, x);
        }

        /// <summary>
        /// Проверка критерия по ключу
        /// </summary>
        /// <param name="fm"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        virtual protected bool CheckK(Params p, int k)
        {
            if (!p.flags.M) return true;
            return (k <= p.input.m);
        }

        /// <summary>
        /// Проверка критерия по аргументу
        /// </summary>
        /// <param name="p"></param>
        /// <param name="norma"></param>
        /// <returns></returns>
        virtual protected bool CheckArg(Params p, double a, double b)
        {
            if (!p.flags.EpsArg) return false;
            return (System.Math.Abs(a - b) <= p.input.eps_arg);
        }

        /// <summary>
        /// Проверка критерия по аргументу
        /// </summary>
        /// <param name="p"></param>
        /// <param name="norma"></param>
        /// <returns></returns>
        virtual protected bool CheckArg(Params p, Vector a, Vector b)
        {
            if (!p.flags.EpsArg) return false;
            return ((a - b).Norma <= p.input.eps_arg);
        }

        /// <summary>
        /// Проверка критерия по значению функции
        /// </summary>
        /// <param name="p"></param>
        /// <param name="norma"></param>
        /// <returns></returns>
        virtual protected bool CheckF(Params p, Vector x1, Vector x2)
        {
            if (!p.flags.EpsF) return false;
            double f1 = f.Parse(x1), f2 = f.Parse(x2);
            return (System.Math.Abs(f1 - f2) <= p.input.eps_f);
        }
        
        /// <summary>
        /// Запись начала метода
        /// </summary>
        /// <param name="p"></param>
        virtual protected void WriteStart(ref Params p)
        {
            p.writelnInLogs("Start " + Name + "\n" +
                p.input.ToString() + p.flags.ToString());
        }

        /// <summary>
        /// Запись окончания метода
        /// </summary>
        /// <param name="p"></param>
        virtual protected void WriteEnd(ref Params p)
        {
            p.writelnInLogs(p.output.ToString() + "End " + Name + "\n");
        }

        /// <summary>
        /// Инициализация начальных данных
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        virtual protected OutputParams Init(InputParams input)
        {
            OutputParams output = new OutputParams();
            output.k = 1;
            if (input.alfa.Size == 2)
            {
                output.alfa.Push(input.alfa[0]);
                output.alfa.Push(input.alfa[1]);
            }
            else
            {
                output.alfa.Push(1);
                output.alfa.Push(1);
            }
            output.alfa_h = input.alfa_h;
            output.AB.Add(input.x1);
            output.AB.Add(input.x1);
            output.x_ = input.x1;
            output.f_x_ = 0.0;
            return output;
        }

        virtual protected void WRez(ref Params p, OutputParams r)
        {
            // записываем выходные параметры
            p.output = r;
            p.output.x_ = X(p.input.x1, p.output.Alfa_, p.input.p);
            p.output.f_x_ = f.Parse(p.output.x_);
            if (p.flags.HainComputing)
            {
                InputParams input = (InputParams)r;
                input.p = p.input.p;
                input.x1 = p.input.x1;
                input.eps_arg = p.input.eps_arg;
                input.eps_f = p.input.eps_f;
                input.m = p.input.m;
                input.y = p.input.y;
                p.input = input;
            }
        }
    }
}
