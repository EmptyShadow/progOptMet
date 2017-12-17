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
    public partial class ChoiceOfTypeRunComposite : Form
    {
        public delegate void CallbackEventChoiceOfTypeRun(bool line);

        public event CallbackEventChoiceOfTypeRun EventChoice;

        public ChoiceOfTypeRunComposite()
        {
            InitializeComponent();
        }

        private void buttonLineRun_Click(object sender, EventArgs e)
        {
            EventChoice?.Invoke(true);
            Close();
        }

        private void buttonUnLineRun_Click(object sender, EventArgs e)
        {
            EventChoice?.Invoke(false);
            Close();
        }
    }
}
