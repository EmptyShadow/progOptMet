using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodsOptimization.src.Views
{
    public partial class DataGridFunctions : UserControl
    {
        Dictionary<int, DataFunctionForm> dictionary = new Dictionary<int, DataFunctionForm>();

        int indexUpdateFunction = -1;

        public DataGridFunctions()
        {
            InitializeComponent();
            LoadDefaultFunction();
        }

        private void addNewFunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddFunction addFunction = new FormAddFunction();
            addFunction.EventNotifyAddFunction += GetNewFunction;
            addFunction.Show();
        }

        void GetNewFunction(DataFunctionForm data)
        {
            if (indexUpdateFunction == -1)
            {
                dictionary.Add(dataGridViewFunctions.Rows.Count, data);
                dataGridViewFunctions.Rows.Add(data.Function.Function, data.X?.Vars(), data.P?.Vars());
                dataGridViewFunctions.Rows[dataGridViewFunctions.RowCount - 1].HeaderCell.Value = (dataGridViewFunctions.Rows.Count - 1).ToString();
            } else
            {
                dictionary[indexUpdateFunction] = data;
                dataGridViewFunctions.Rows[indexUpdateFunction].SetValues(data.Function.Function, data.X?.Vars(), data.P?.Vars());
                indexUpdateFunction = -1;
            }
            dataGridViewFunctions.Refresh();
        }

        private void RemoveFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selRows = dataGridViewFunctions.SelectedRows;
            
            foreach(DataGridViewRow row in selRows)
            {
                int id = Int32.Parse(row.HeaderCell.Value.ToString());
                dictionary.Remove(id);
                dataGridViewFunctions.Rows.Remove(row);
            }

            UpdateHeaderRows();
        }

        private void UpdateHeaderRows()
        {
            foreach (DataGridViewRow row in dataGridViewFunctions.Rows)
            {
                row.HeaderCell.Value = row.Index.ToString();
            }
        }

        public List<DataFunctionForm> GetSelectedFunctions()
        {
            DataGridViewSelectedRowCollection selRows = dataGridViewFunctions.SelectedRows;
            List<DataFunctionForm> list = new List<DataFunctionForm>();
            foreach (DataGridViewRow row in selRows)
            {
                list.Add(dictionary[row.Index]);
            }
            return list;
        }

        public void AddFunction(DataFunctionForm[] datas)
        {
            foreach(DataFunctionForm data in datas)
            {
                GetNewFunction(data);
            }
        }

        public void LoadDefaultFunction()
        {
            List<DataFunctionForm> list = new List<DataFunctionForm>() {
                new DataFunctionForm() {
                    Function = new Functions.Function("x1^2 + 3 * x2^2 + 2 * x1 * x2"),
                    X = new Parametrs.Vector("1;1"),
                    P = new Parametrs.Vector("2;3")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("100 * (x2 - x1^2)^2 + (1 - x1)^2"),
                    X = new Parametrs.Vector("-1;0"),
                    P = new Parametrs.Vector("5;1")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("-12 * x2 + 4 * x1^2 + 4 * x2^2 - 4 * x1 * x2"),
                    X = new Parametrs.Vector("-0,5;1"),
                    P = new Parametrs.Vector("1;0")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x1 - 2)^4 + (x1 - 2 * x2)^2"),
                    X = new Parametrs.Vector("0;3"),
                    P = new Parametrs.Vector("1;0")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("4 * (x1 - 5)^2 + (x2 - 6)^2"),
                    X = new Parametrs.Vector("8;9"),
                    P = new Parametrs.Vector("1;0")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x1 - 2)^4 + (x1 - 2 * x2)^2"),
                    X = new Parametrs.Vector("0;3"),
                    P = new Parametrs.Vector("44;-24,1")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("2 * x1^3 + 4 * x1 * x2^3 - 10 * x1 * x2 + x2^2"),
                    X = new Parametrs.Vector("5;2"),
                    P = new Parametrs.Vector("0;-1")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("100 * (x2 - x1^2)^2 + (1 - x1)^2"),
                    X = new Parametrs.Vector("-1,2;1")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("100 * (x2 - x1^2)^2 + (1 - x1)^2"),
                    X = new Parametrs.Vector("1,5;2")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("100 * (x2 - x1^2)^2 + (1 - x1)^2"),
                    X = new Parametrs.Vector("-2;-2")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x1 - 1)^2 + (x2 - 3)^2 + 4 * (x3 + 5)^2"),
                    X = new Parametrs.Vector("4;-1;2")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("8 * x1^2 + 4 * x1 * x2 + 5 * x2^2"),
                    X = new Parametrs.Vector("10;10")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("4 * (x1 - 5)^2 + (x2 - 6)^2"),
                    X = new Parametrs.Vector("8;9")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("4 * (x1 - 5)^2 + (x2 - 6)^2"),
                    X = new Parametrs.Vector("0;0")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x2 - x1^2)^2 + (1 - x1)^2"),
                    X = new Parametrs.Vector("1,5;2")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x2 - x1^2)^2 + (1 - x1)^2"),
                    X = new Parametrs.Vector("0;0")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x2 - x1^2)^2 + (1 - x1)^2"),
                    X = new Parametrs.Vector("-1,2;1")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x2 - x1^2)^2 + 100 * (1 - x1^2)^2"),
                    X = new Parametrs.Vector("1,5;2")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x2 - x1^2)^2 + 100 * (1 - x1^2)^2"),
                    X = new Parametrs.Vector("1;2")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("3 * (x1 - 4)^2 + 5 * (x2 + 3)^2 + 7 * (2 * x3 + 1)^2"),
                    X = new Parametrs.Vector("2;-2;-2")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("3 * (x1 - 4)^2 + 5 * (x2 + 3)^2 + 7 * (2 * x3 + 1)^2"),
                    X = new Parametrs.Vector("0;0;0")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("x1^3 + x2^2 - 3 * x1 - 2 * x2 + 2"),
                    X = new Parametrs.Vector("0;0")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("x1^3 + x2^2 - 3 * x1 - 2 * x2 + 2"),
                    X = new Parametrs.Vector("-1;-1")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("-12 * x2 + 4 * x1^2 + 4 * x2^2 - 4 * x1 * x2"),
                    X = new Parametrs.Vector("1;0")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x1 - 2)^4 + (x1 - 2 * x2)^2"),
                    X = new Parametrs.Vector("0;3")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x1 * x2 * x3 - 1)^2 + 5 * (x3 * (x1 + x2) - 2)^2 + 2 * (x1 + x2 + x3 - 3)^2"),
                    X = new Parametrs.Vector("-5;4;2")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("4 * x1^2 + 3 * x2^2 - 4 * x1 * x2^2 + x1"),
                    X = new Parametrs.Vector("0;0")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x1^2 + x2 - 11)^2 + (x1 + x2^2 - 7)^2"),
                    X = new Parametrs.Vector("0;0")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("100 * (x2 - x1^3)^2 + (1 - x1)^2"),
                    X = new Parametrs.Vector("-1,2;1")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(1.5 - x1 * (1 - x2))^2 + (2.25 - x1 * (1 - x2^2))^2 + (2.625 - x1 * (1 - x2^3))^2"),
                    X = new Parametrs.Vector("0;0")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(x1 + 10 * x2)^2 + 5 * (x3 - x4)^2 + (x2 - 2 * x3)^4 + 10 * (x1 - x4)^4"),
                    X = new Parametrs.Vector("-3;-1;0;1")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("100 * (x2 - x1^2)^2 + (1 - x1)^2 + 90 * (x4 - x3^2)^2 + (1 - x3)^3 + 10.1 * ((x2 - 1)^2 + (x4 - 1)^2) + 19.8 * (x2 - 1) * (x4 - 1)"),
                    X = new Parametrs.Vector("-3;-1;-3;-1")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("(2 * x1^2 + 3 * x2^2) * exp(x1^2 - x2^2)"),
                    X = new Parametrs.Vector("1;0,5")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("0.1 * (12 + x1^2 + (1 + x2^2) / x1^2 + (x1^2 * x2^2 + 100) / (x1^4 * x2^4))"),
                    X = new Parametrs.Vector("0,5;0,5")
                },
                new DataFunctionForm() {
                    Function = new Functions.Function("100 * (x3 - 0.25 * (x1 + x2)^2)^2 + (1 - x1)^2 + (1 - x2)^2"),
                    X = new Parametrs.Vector("-1,5;2;0")
                }
            };
            AddFunction(list.ToArray());
        }

        private void dataGridViewFunctions_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView data = sender as DataGridView;
            DataGridViewRow row = data.SelectedRows?[0];
            if (row != null)
            {
                FormAddFunction form = new FormAddFunction(dictionary[row.Index]);
                indexUpdateFunction = row.Index;
                form.EventNotifyAddFunction += GetNewFunction;
                form.Show();
            }
        }
    }
}
