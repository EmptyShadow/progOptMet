using MethodsOptimization.src.Methods;
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
    public partial class FormCreateMethod : Form
    {
        public delegate void Callback(object sender);

        public event Callback EventCreateMethod;

        EmptyMethod method;
        LimParams limParams;

        public EmptyMethod Method
        {
            get
            {
                return method;
            }
            set
            {
                method = value;
                labelMethod.Text = "Метод " + method.Name;
            }
        }

        public LimParams LimParams
        {
            get
            {
                return limParams;
            }
            set
            {
                limParams = value;
                labelLimParams.Text = "Ограничения " + limParams.ToString();
            }
        }

        public bool Norma { get; set; } = false;

        public int NumberUsedComposite { get; set; } = -1;

        public FormCreateMethod(EmptyMethod method = null)
        {
            InitializeComponent();

            if (method != null)
            {
                this.method = method;
                labelMethod.Text = "Метод " + method?.Name;
                limParams = method?.Lim;
                labelLimParams.Text = limParams?.ToString();
                checkBoxNorma.Checked = method.NormalizationDirections;
            }
        }

        private void labelMethod_Click(object sender, EventArgs e)
        {
            FormChoiceOfMethod form = new FormChoiceOfMethod();
            form.EventSelectedMethod += HandlerEventCreateMethod;
            form.Show();
        }

        private void HandlerEventCreateMethod(EmptyMethod method)
        {
            Method = method;
        }

        private void labelLimParams_Click(object sender, EventArgs e)
        {
            FormAddLimParams form = new FormAddLimParams(LimParams);
            form.EventNotifyAddLimParams += HandlerAddLimParams;
            form.Show();
        }

        private void HandlerAddLimParams(LimParams limParams)
        {
            LimParams = limParams;
        }

        private void checkBoxNorma_CheckedChanged(object sender, EventArgs e)
        {
            Norma = ((CheckBox)sender).Checked;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (Method != null && LimParams != null)
            {
                NumberUsedComposite = textBoxNumberGroup.Text != "" ? Int32.Parse(textBoxNumberGroup.Text) : -1;
                EventCreateMethod.Invoke(this);
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
