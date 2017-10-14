using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;
using MethodsOptimization.src;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    /*
    class Koshi: MultiDimSearch
    {
        public Koshi()
        {
            name = "Koshi";
        }
        
        /// <summary>
        /// Запуск на исполнение метода
        /// </summary>
        /// <param name="parametrs"></param>
        /// <returns></returns>
        override public double Run(ref Params parametrs)
        {
            WriteStart(ref parametrs);
            // устанавливаем функцию
            f = parametrs.input.y;
            OutputParams q = Init(parametrs.input);
            // начальный вектор, следующий вектор, направление
            Vector p, xk;

            Core core = Core.Instance;
            Params parSerch = (Params)parametrs.Clone();
            parSerch.flags.HainComputing = true;
            parSerch.flags.EpsArg = true;
            parSerch.flags.EpsF = true;
            parSerch.input.m = 30;

            q.x_ = parametrs.input.x1;
            while(CheckK(parametrs, q.k))
            {
                p = -GdF(q.x_);
                parSerch.input.x1 = q.x_;
                parSerch.input.p = p;
                core.MDS.GetMethodByName("Swenn").Run(ref parSerch);
                core.MDS.GetMethodByName("Golden section 1").Run(ref parSerch);
                xk = q.x_ + parSerch.output.Alfa_ * p;
                if (CheckF(parametrs, q.x_, xk) || CheckArg(parametrs, q.x_, xk))
                {
                    break;
                }
                q.x_ = xk;
            }

            // записываем выходные параметры
            WRez(ref parametrs, q);

            WriteEnd(ref parametrs);

            return parametrs.output.f_x_;
        }
    }*/
}
