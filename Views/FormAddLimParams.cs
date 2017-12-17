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
    public partial class FormAddLimParams : Form
    {
        public delegate void CallbackNotifyFromAddLimParams(LimParams data);

        public event CallbackNotifyFromAddLimParams EventNotifyAddLimParams;

        public FormAddLimParams(LimParams data = null)
        {
            InitializeComponent();
            if (data == null) { data = new LimParams(); }
            
            textBoxK.Text = data?.K.ToString();
            textBoxEps.Text = data?.Eps.ToString();
        }
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            LimParams limParams = new LimParams();
            try
            {
                int k = Int32.Parse(textBoxK.Text);
                if (k < 0)
                {
                    errorProvider.SetError(textBoxK, "Количество итераций положительное число");
                }
                errorProvider.SetError(textBoxK, "");
                double eps = Double.Parse(textBoxEps.Text);
                limParams.K = k;
                limParams.Eps = eps;
                EventNotifyAddLimParams?.Invoke(limParams);
                Close();
            }
            catch (Exception exc) {}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
