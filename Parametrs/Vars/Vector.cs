using System.Collections;
using System;

namespace MethodsOptimization.src.Parametrs.Vars
{
    class Vector: ICloneable
    {
        /// <summary>
        /// переменные в векторе
        /// </summary>
        ArrayList vars = new ArrayList();

        public Vector() { }

        public Vector(double[] vs)
        {
            foreach(double v in vs)
            {
                vars.Add(v);
            }
        }

        /// <summary>
        /// Сложение элементов векторов
        /// </summary>
        /// <param name="v1">Первый вектор</param>
        /// <param name="v2">Второй вектор</param>
        /// <returns>Новый вектор суммы</returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector sum = new Vector();
            if (v1.Size != v2.Size)
            {
                return new Vars.Vector();
            }
            for (int i = 0; i < v1.Size; i++)
            {
                sum.Push(v1[i] + v2[i]);
            }
            return sum;
        }

        /// <summary>
        /// Разность элементов векторов
        /// </summary>
        /// <param name="v1">Первый вектор</param>
        /// <param name="v2">Второй вектор</param>
        /// <returns>Новый вектор разности</returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector raz = new Vector();
            if (v1.Size != v2.Size)
            {
                return new Vars.Vector();
            }
            for (int i = 0; i < v1.Size; i++)
            {
                raz.Push(v1[i] - v2[i]);
            }
            return raz;
        }

        /// <summary>
        /// Умножение вектора на скаляр
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <param name="a">Скаляр</param>
        /// <returns>Новый вектор произведения вектора на скаляр</returns>
        public static Vector operator *(Vector v, double a)
        {
            Vector proz = new Vector();
            for (int i = 0; i < v.Size; i++)
            {
                proz.Push(v[i] * a);
            }
            return proz;
        }

        /// <summary>
        /// Умножение вектора на скаляр
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <param name="a">Скаляр</param>
        /// <returns>Новый вектор произведения вектора на скаляр</returns>
        public static Vector operator *(double a, Vector v)
        {
            return v * a;
        }

        /// <summary>
        /// Деление вектора на скаляр
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <param name="a">Скаляр</param>
        /// <returns>Новый вектор произведения вектора на скаляр</returns>
        public static Vector operator /(Vector v, double a)
        {
            return v * (1 / a);
        }

        /// <summary>
        /// Скалярное произведение векторов
        /// </summary>
        /// <param name="v1">Первый вектор</param>
        /// <param name="v2">Второй вектор</param>
        /// <returns>Скалярное произведение</returns>
        public static double operator *(Vector v1, Vector v2)
        {
            if (v1.Size != v2.Size)
            {
                return 0.0;
            }
            double sum = 0.0;
            for (int i = 0; i < v1.Size; i++)
            {
                sum += v1[i] * v2[i];
            }
            return sum;
        }

        /// <summary>
        /// Добавление в конец вектора одного элемента
        /// </summary>
        /// <param name="var"></param>
        public void Push(double var)
        {
            vars.Add(var);
        }

        /// <summary>
        /// Добавление в конец вектора несколько элементов
        /// </summary>
        /// <param name="vars"></param>
        public void Push(double[] vars)
        {
            foreach (double var in vars)
            {
                this.vars.Add(var);
            }
        }

        /// <summary>
        /// удалить i-й элемент
        /// </summary>
        /// <param name="number"></param>
        public void Remove(int number)
        {
            vars.RemoveAt(number);
        }

        /// <summary>
        /// Размер вектора
        /// </summary>
        /// <returns>Размер вектора</returns>
        public int Size
        {
            get
            {
                return vars.Count;
            }
        }

        /// <summary>
        /// Получение элемента вектора
        /// </summary>
        /// <param name="number">Номер элемента</param>
        /// <returns>Если выход за пределы вектора, то макс NaN, иначе элемент вектора</returns>
        public double this [int number]
        {
            get
            {
                if (!checkIndex(number))
                {
                    return double.NaN;
                }
                return (double)vars[number];
            }
            set
            {
                if (checkIndex(number))
                {
                    vars[number] = value;
                }
            }
        }

        /// <summary>
        /// Клонирование вектора
        /// </summary>
        /// <returns>Новый копированый вектор</returns>
        public object Clone()
        {
            Vector clone = new Vector();
            foreach(double var in vars) {
                clone.Push(var);
            }
            return clone;
        }

        public void Clear()
        {
            vars.Clear();
        }

        /// <summary>
        /// К виду строки
        /// </summary>
        /// <returns>Строка</returns>
        new public string ToString()
        {
            string str = "Vector:\n";
            int i = 0;
            foreach(double v in vars)
            {
                str += "\tvector[" + i.ToString() + "] = " + v.ToString("G8") + ";\n";
                i++;
            }
            return str;
        }

        /// <summary>
        /// Норма веектора
        /// </summary>
        public double Norma
        {
            get
            {
                if (Size == 0) return 0.0;
                if (Size == 1) return (double)vars[0];

                return Math.Sqrt(this * this);
            }
        }

        /// <summary>
        /// Получение случайного вектора
        /// </summary>
        /// <param name="n">Размер</param>
        /// <param name="absMax">максимально по модулю значение</param>
        /// <returns>Случайный вектор</returns>
        public static Vector random(int n, int absMax)
        {
            Vector random = new Vector();
            if (n < 0) return random;
            Random gen = new Random();
            for (int i = 0; i < n; i++)
            {
                random.Push(gen.Next(-absMax, absMax));
            }
            return random;
        }

        /// <summary>
        /// Получение нулевого вектора кроме i-ого
        /// </summary>
        /// <param name="n">Размер</param>
        /// <param name="i">Номер не нулевого элемента</param>
        /// <returns>Новый вектор</returns>
        public static Vector GetZeroBeside(int n, int i)
        {
            Vector zero = new Vector();
            if (n < 0 || i >= n) return zero;
            for (int j = 0; j < n; j++)
            {
                if (j == i)
                {
                    zero.Push(1.0);
                } else
                {
                    zero.Push(0.0);
                }

            }
            return zero;
        }

        /// <summary>
        /// Инвертирование элементов
        /// </summary>
        /// <param name="v">Инвертируемый вектор</param>
        /// <returns>Инвертированый вектор</returns>
        public static Vector operator-(Vector v)
        {
            Vector v2 = new Vector();
            for (int i = 0; i < v.Size; i++)
            {
                v2.Push(-v[i]);
            }
            return v2;
        }

        /// <summary>
        /// Проверка номера элемента на соответствие интервалу вектора
        /// </summary>
        /// <param name="number">номер элемента</param>
        /// <returns></returns>
        public bool checkIndex(int number)
        {
            return (number >= 0 && number < Size);
        }

        /// <summary>
        /// первая переменная из вектора
        /// </summary>
        public double First
        {
            get
            {
                return this[0];
            }
        }

        /// <summary>
        /// последняя переменная из вектора
        /// </summary>
        public double Last
        {
            get
            {
                return this[Size - 1];
            }
        }
    }
}
