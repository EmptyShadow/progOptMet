using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOptimization.src.Parametrs
{
    /// <summary>
    /// Матрица
    /// </summary>
    class Matrix : ICloneable
    {
        /// <summary>
        /// Количество строк
        /// </summary>
        int n;

        /// <summary>
        /// количество столбцов
        /// </summary>
        int m;

        /// <summary>
        /// Массив векторов одиноковой длины, представляет собой матрицу
        /// </summary>
        List<Vector> matrix;

        /// <summary>
        /// Количество строк
        /// </summary>
        public int CountRows { get { return n; } }

        /// <summary>
        /// Количество столбцов
        /// </summary>
        public int CountColumns { get { return m; } }

        /// <summary>
        /// Количество элементов
        /// </summary>
        public int CountItems { get { return n * m; } }

        /// <summary>
        /// Создать матрицу
        /// </summary>
        /// <param name="countRows"></param>
        /// <param name="countColumns"></param>
        public Matrix(int countRows, int countColumns)
        {
            n = countRows;
            m = countColumns;

            matrix = new List<Vector>();
            for (int i = 0; i < n; i++)
            {
                Vector row = new Vector();
                matrix.Add(row);
                for (int j = 0; j < m; j++)
                {
                    row.Push(0);
                }
            }
        }

        /// <summary>
        /// Элемент матрицы
        /// </summary>
        /// <param name="indexRow"></param>
        /// <param name="indexCol"></param>
        /// <returns></returns>
        public double this[int indexRow, int indexCol]
        {
            get
            {
                return matrix[indexRow][indexCol];
            }
            set
            {
                matrix[indexRow][indexCol] = value;
            }
        }

        /// <summary>
        /// Строка матрицы
        /// </summary>
        /// <param name="indexRow"></param>
        /// <returns></returns>
        public Vector this[int indexRow]
        {
            get
            {
                return matrix[indexRow];
            }
            set
            {
                if (value.Size == m)
                {
                    matrix[indexRow] = value;
                }
            }
        }

        /// <summary>
        /// Получить столбец матрицы
        /// </summary>
        /// <param name="indexCol"></param>
        /// <returns></returns>
        public Vector GetColMatrix(int indexCol)
        {
            Vector col = new Vector();

            foreach (Vector row in matrix)
            {
                col.Push(row[indexCol]);
            }

            return col;
        }

        public object Clone()
        {
            Matrix clone = new Matrix(n, m);

            clone.matrix = new List<Vector>();

            foreach (Vector row in matrix)
            {
                clone.matrix.Add((Vector)row.Clone());
            }

            return clone;
        }

        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.CountItems == m2.CountItems)
            {
                Matrix summMatrix = new Matrix(m1.CountRows, m1.CountColumns);

                for (int i = 0; i < summMatrix.CountRows; i++)
                {
                    for (int j = 0; j < summMatrix.CountColumns; j++)
                    {
                        summMatrix[i, j] = m1[i, j] + m2[i, j];
                    }
                }

                return summMatrix;
            }
            return null;
        }

        /// <summary>
        /// Инвертирование
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Matrix operator -(Matrix m)
        {
            Matrix invMatrix = new Matrix(m.CountRows, m.CountColumns);
            for (int i = 0; i < invMatrix.CountRows; i++)
            {
                for (int j = 0; j < invMatrix.CountColumns; j++)
                {
                    invMatrix[i, j] = -m[i, j];
                }
            }
            return invMatrix;
        }

        /// <summary>
        /// Разность матриц
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return m1 + (-m2);
        }

        /// <summary>
        /// Произведение матриц
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.CountColumns == m2.CountRows)
            {
                Matrix matrix = new Matrix(m1.CountRows, m2.CountColumns);

                for (int i = 0; i < matrix.CountRows; i++)
                {
                    for (int j = 0; j < matrix.CountColumns; j++)
                    {
                        matrix[i, j] = m1[i] * m2.GetColMatrix(j);
                    }
                }

                return matrix;
            }
            return null;
        }

        /// <summary>
        /// Умножить на скаляр
        /// </summary>
        /// <param name="m"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix m, double scalar)
        {
            Matrix matrix = (Matrix)m.Clone();

            for (int i = 0; i < matrix.CountRows; i++)
            {
                for (int j = 0; j < matrix.CountColumns; j++)
                {
                    matrix[i, j] = m[i, j] * scalar;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Умножить на скаляр
        /// </summary>
        /// <param name="scalar"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Matrix operator *(double scalar, Matrix m)
        {
            return m * scalar;
        }

        /// <summary>
        /// деление на скаляр
        /// </summary>
        /// <param name="scalar"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Matrix operator /(double scalar, Matrix m)
        {
            return m * (1 / scalar);
        }

        /// <summary>
        /// Деление на скаляр
        /// </summary>
        /// <param name="m"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static Matrix operator /(Matrix m, double scalar)
        {
            return m * (1 / scalar);
        }

        /// <summary>
        /// Получить матрицу исключив строку
        /// </summary>
        /// <param name="indexRow"></param>
        /// <returns></returns>
        public Matrix GetMatrixExcludingRow(int indexRow)
        {
            Matrix matrix = (Matrix)Clone();

            matrix.RemoveRow(indexRow);

            return matrix;
        }

        /// <summary>
        /// Получить матрицу исключив столбец
        /// </summary>
        /// <param name="indexCol"></param>
        /// <returns></returns>
        public Matrix GetMatrixExcludingCol(int indexCol)
        {
            Matrix matrix = (Matrix)Clone();

            matrix.RemoveCol(indexCol);

            return matrix;
        }

        /// <summary>
        /// Получить матрицу исключив столбец и строку
        /// </summary>
        /// <param name="indexRow"></param>
        /// <param name="indexCol"></param>
        /// <returns></returns>
        public Matrix GetMatrixExcludingRowCol(int indexRow, int indexCol)
        {
            Matrix matrix = (Matrix)Clone();

            matrix.RemoveRow(indexRow);
            matrix.RemoveCol(indexCol);

            return matrix;
        }

        /// <summary>
        /// Удалить строку
        /// </summary>
        /// <param name="indexRow"></param>
        public void RemoveRow(int indexRow)
        {
            matrix.RemoveAt(indexRow);
            n--;
        }

        /// <summary>
        /// Удалить столбец
        /// </summary>
        /// <param name="indexCol"></param>
        /// <returns></returns>
        public void RemoveCol(int indexCol)
        {
            for (int i = 0; i < CountRows; i++)
            {
                matrix[i].Remove(indexCol);
            }
            m--;
        }

        /// <summary>
        /// Определитель матрицы
        /// </summary>
        /// <returns></returns>
        public double Det()
        {
            if (n != m)
            {
                throw new Exception("Матрица не квадратная");
            }
            if (n == 2)
            {
                return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
            }

            double summ = 0.0;
            Vector firstRow = matrix[0];
            for (int i = 0; i < firstRow.Size; i++)
            {
                Matrix submatrix = GetMatrixExcludingRowCol(0, i);
                summ += (((i + 2) % 2 == 0) ? 1 : -1) * firstRow[i] * submatrix.Det();
            }
            return summ;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < CountRows; i++)
            {
                for (int j = 0; j < CountColumns; j++)
                {
                    s += this[i, j].ToString();
                }
                s += "\n";
            }
            return s;
        }

        /// <summary>
        /// Умножение вектора на матрицу
        /// </summary>
        /// <param name="v"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Vector operator*(Vector v, Matrix m)
        {
            if (v.Size != m.CountColumns) { return null; }

            Vector vector = new Vector();
            for (int i = 0; i < m.CountColumns; i++)
            {
                vector.Push(v * m.GetColMatrix(i));
            }

            return vector;
        }

        /// <summary>
        /// Умножение матрицы на вектор
        /// </summary>
        /// <param name="m"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector operator*(Matrix m, Vector v)
        {
            if (v.Size != m.CountColumns) { return null; }

            Vector vector = new Vector();
            for (int i = 0; i < m.CountRows; i++)
            {
                vector.Push(m[i] * v);
            }

            return vector;
        }

        /// <summary>
        /// Замена строки
        /// </summary>
        /// <param name="newRow"></param>
        /// <param name="indexReplace"></param>
        /// <returns></returns>
        public Matrix ReplaceRowAt(Vector newRow, int indexReplace)
        {
            if (CountColumns != newRow.Size || indexReplace >= CountRows) { return null; }
            Matrix newMatrix = (Matrix)this.Clone();
            matrix[indexReplace] = (Vector)newRow.Clone();
            return newMatrix;
        }

        /// <summary>
        /// Замена столбца
        /// </summary>
        /// <param name="newColumn"></param>
        /// <param name="indexReplace"></param>
        /// <returns></returns>
        public Matrix ReplaceColumnAt(Vector newColumn, int indexReplace)
        {
            if (CountRows != newColumn.Size || indexReplace >= CountColumns) { return null; }
            Matrix newMatrix = (Matrix)Clone();
            for (int i = 0; i < CountRows; i++)
            {
                newMatrix[i][indexReplace] = newColumn[i];
            }
            return newMatrix;
        }
    }
}
