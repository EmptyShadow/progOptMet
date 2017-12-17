using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodsOptimization.src.Views
{
    public partial class FormAddFunction : Form
    {
        public delegate void CallbackNotifyFromAddFunction(DataFunctionForm data);

        public event CallbackNotifyFromAddFunction EventNotifyAddFunction;

        public FormAddFunction(DataFunctionForm data = null)
        {
            InitializeComponent();

            textBoxFunc.Text = data?.Function?.Function;
            textBoxX.Text = data?.X?.Vars();
            textBoxP.Text = data?.P?.Vars();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Function func = null;
            Vector x = null;
            Vector p = null;
            try
            {
                if (textBoxFunc.Text == "") { throw new Exception("Функция должна быть!!"); }
                func = new Function(textBoxFunc.Text);
                errorProvider.SetError(label1, "");
                if (textBoxX.Text != "")
                {
                    x = new Vector(textBoxX.Text);
                    if (func.Vars.Count != x.Size)
                    {
                        throw new Exception("Не совпадает количество переменных");
                    }
                }
                errorProvider.SetError(label2, "");
                if (textBoxP.Text != "")
                {
                    p = new Vector(textBoxP.Text);
                    if (func.Vars.Count != p.Size)
                    {
                        throw new Exception("Не совпадает количество переменных");
                    }
                }
                errorProvider.SetError(label3, "");

                DataFunctionForm data = new DataFunctionForm();
                data.Function = func;
                data.X = x;
                data.P = p;
                EventNotifyAddFunction?.Invoke(data);
                Close();
            } catch (Exception exc)
            {
                if (func == null)
                {
                    errorProvider.SetError(label1, exc.Message);
                } else if (x == null)
                {
                    errorProvider.SetError(label2, exc.Message);
                } else if (p == null)
                {
                    errorProvider.SetError(label3, exc.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
