using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MethodsOptimization.src.Methods;
using System.Collections;
using MethodsOptimization.src.Parametrs;

namespace MethodsOptimization.src.Views
{
    public partial class CompositeControl : UserControl
    {
        public delegate EmptyMethod CallbackGetUsedMethods(int numberComposite);
        public delegate List<DataFunctionForm> CallbackGetListFunctions();

        public event CallbackGetUsedMethods EventGetUsedMethods;
        public event CallbackGetListFunctions EventGetListFunctions;
        public event Composite.CallBackNotifyOfResult EventNotyfiOfResult;
        public event Composite.CallBackNotifyError EventNotyfiError;

        Composite composite = new Composite();

        public Composite Composite { get { return composite; } }

        int indexUpdateMethod = -1;

        public CompositeControl()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            DataGridViewRow row = grid.SelectedRows[0];
            if (row != null)
            {
                EmptyMethod method = composite.GetList()?[row.Index];
                if (method != null)
                {
                    indexUpdateMethod = row.Index;
                    FormCreateMethod form = new FormCreateMethod(method);
                    form.EventCreateMethod += HandlerEventUpdateMethod;
                    form.Show();
                }
            }
        }

        private void addMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateMethod form = new FormCreateMethod();
            form.EventCreateMethod += HandlerEventCreateMethod;
            form.Show();
        }

        private void HandlerEventUpdateMethod(object sender)
        {
            FormCreateMethod form = sender as FormCreateMethod;
            if (form != null && form.Method != null)
            {
                form.Method.Lim = form.LimParams;
                form.Method.NormalizationDirections = form.Norma;

                if (form.NumberUsedComposite != -1)
                {
                    EmptyMethod usedMethods = EventGetUsedMethods?.Invoke(form.NumberUsedComposite);
                    if (usedMethods != null)
                    {
                        form.Method.MethodsUsed = usedMethods;
                    }
                }

                composite.GetList()[indexUpdateMethod] = form.Method;
                dataGridView.Rows[indexUpdateMethod].SetValues(new object[] { form.Method.Name,
                    form.LimParams?.ToString(),
                    form.Norma,
                    form.NumberUsedComposite != -1 ? form.NumberUsedComposite.ToString() : ""
                });
                indexUpdateMethod = -1;
            }
        }

        private void HandlerEventCreateMethod(object sender)
        {
            FormCreateMethod form = sender as FormCreateMethod;
            if (form != null && form.Method != null)
            {
                form.Method.Lim = form.LimParams;
                form.Method.NormalizationDirections = form.Norma;

                if (form.NumberUsedComposite != -1)
                {
                    EmptyMethod usedMethods = EventGetUsedMethods?.Invoke(form.NumberUsedComposite);
                    if (usedMethods != null)
                    {
                        form.Method.MethodsUsed = usedMethods;
                    }
                }

                composite.Add(form.Method);
                dataGridView.Rows.Add(new object[] { form.Method.Name,
                    form.LimParams?.ToString(),
                    form.Norma,
                    form.NumberUsedComposite != -1 ? form.NumberUsedComposite.ToString() : ""
                });
            }
        }

        private void RemoveSelectMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView.SelectedRows;
            if (rows != null)
            {
                ArrayList array = new ArrayList();
                foreach (DataGridViewRow row in rows)
                {
                    array.Add(row.Index);
                }
                array.Sort();
                for(int i = array.Count - 1; i >= 0; i--)
                {
                    dataGridView.Rows.RemoveAt((int)array[i]);
                }
                dataGridView.Refresh();
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<DataFunctionForm> list = EventGetListFunctions?.Invoke();
            composite.EventNotifyOfResult += EventNotyfiOfResult;
            composite.EventNotifyOfErrorRuning += EventNotyfiError;
            if (list != null)
            {
                foreach (DataFunctionForm data in list)
                {
                    Params param = new Params();
                    param.Y = data.Function;
                    if (data.X != null)
                    {
                        param.X0 = data.X;
                    } else
                    {
                        param.X0 = Vector.random(data.Function.Vars.Count, 10);
                    }
                    if (data.P != null)
                    {
                        param.P = data.P;
                    }
                    Result result = composite.Run(param);
                    /*if (result != null)
                    {
                        EventNotyfiOfResult?.Invoke(result, param, composite);
                    }*/
                }
            }
            composite.EventNotifyOfResult -= EventNotyfiOfResult;
            composite.EventNotifyOfErrorRuning -= EventNotyfiError;
        }

        public void RemoveUsesMethods(int numberRemoveMethods)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var obj = row.Cells["NumberUsedMethods"];
                int number = obj != null ? Int32.Parse(obj.ToString()) : -1;
                if (number != -1 && number == numberRemoveMethods)
                {
                    composite[row.Index].MethodsUsed = null;
                    row.Cells["NumberUsedMethods"].Value = "";
                }
            }
        }

        private void typeRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChoiceOfTypeRunComposite form = new ChoiceOfTypeRunComposite();
            form.EventChoice += SetTypeRunComposite;
            form.Show();
        }

        private void SetTypeRunComposite(bool line)
        {
            composite.RunMethodsSeparately = !line;
            typeRunToolStripMenuItem.Text = "Тип исполнения" + (line ? " последовательный" : " независимый");
        }
    }
}
