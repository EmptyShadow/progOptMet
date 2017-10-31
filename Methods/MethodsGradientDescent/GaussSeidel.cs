using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Methods.MultiDimensionalSearch
{
    class GaussSeidel: MultiDimSearch
    {
        public GaussSeidel()
        {
            Name = "Gauss-Seidel";
        }
        
        public override Params Run(Params p, EmptyMethod m = null)
        {
            // проверка переданных методов
            if (m == null) throw new System.Exception("Ошибка метода " + Name + ": не определены методы, которые будет использованны");
            // клонирование входных параметров в выходные
            Params cP = (Params)p.Clone();
            // создание проверяющего КОП
            CheckingCriterion checking = new CheckingCriterion(ref cP);
            // устанавливаем функцию
            f = p.Y;

            int n = cP.Y.Vars.Count; // количество переменных
            Vector[] system; // система параметров
            Params parMet = (Params)cP.Clone();
            system = new Vector[n + 1];
            do
            {
                if (cP.K == 1) system[0] = cP.X0;
                for (int i = 1; i <= n; i++)
                {
                    parMet.X0 = system[i - 1];
                    parMet.P = -Functions.Math.GF(f, system[i - 1])[i - 1] * Vector.GetZeroBeside(n, i - 1);
                    parMet.Alfa = new Vector();
                    parMet = m.Run(parMet);
                    system[i] = system[i - 1] + parMet.GetAlfa_() * parMet.P;
                }
                Vector d = system[n] - system[0];
                cP.X0 = system[n] + parMet.GetAlfa_() * d;
                if (checking.CheckX(system[0], system[n]) || checking.CheckF(system[0], system[n]) || checking.CheckNormaH(d.Norma))
                {
                    break;
                }
                system[0] = system[n];
                cP.K++;
            } while (!checking.CheckNumIterat());
            return cP;
        }
    }
}
