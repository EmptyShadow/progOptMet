using System.Linq;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Parametrs.Vars;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class GaussSeidel: MultiDimSearch
    {
        public GaussSeidel()
        {
            name = "Gauss-Seidel";
        }

        protected override bool SEC(InputParams In, OutputParams Out)
        {
            SearchEndingCriterion sec = new SearchEndingCriterion(In.Lim);
            Vector x1 = X(In.X0, Out.Alfa[0], In.P);
            Vector x2 = X(In.X0, Out.Alfa[1], In.P);
            return sec.CheckArg(x1, x2) && sec.CheckF(In.Y, x1, x2) && sec.CheckGF(In.Y, x2, In.P);
        }

        public override double Run(ref Params p, EmptyMethod m = null)
        {
            if (m == null) throw new System.Exception("Ошибка метода " + name + ": не определены методы, которые будет использованны");
            p.InitOut();
            // устанавливаем функцию
            f = p.In.Y;
            
            Params pSearch = (Params)p.Clone();
            Vector x0;
            int n = p.In.X0.Size;
            pSearch.Out.Alfa = new Vector();

            while (!p.In.Lim.CheckNumIteration(p.Out.K))
            {
                pSearch.Out.Alfa.Clear();
                // точка x0
                x0 = pSearch.In.X0;
                // n раз ищем alfa и находим x_n точку
                for (int i = 0; i < n; i++)
                {
                    // вектор направления
                    pSearch.In.P = -Vector.GetZeroBeside(n, i) * DFatXByIVar(pSearch.In.X0, i);
                    pSearch.Out.Alfa.Push(m.Run(ref pSearch));
                    pSearch.In.X0 = pSearch.In.X0 + pSearch.Out.Alfa.Last * pSearch.In.P; 
                }
                if (p.In.Lim.CheckEPS((x0 - pSearch.In.X0).Norma) && 
                    p.In.Lim.CheckEPS(f.Parse(x0) - f.Parse(pSearch.In.X0)))
                {
                    break;
                }
                p.Out.K++;
            }
            pSearch.WriteOutputInInput();
            p.In = pSearch.In;
            p.Out.Alfa = pSearch.Out.Alfa;
            p.Out.Alfa_h = pSearch.Out.Alfa_h;
            return p.GetAlfa_ByOut();
        }
    }
}
