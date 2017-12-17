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

namespace MethodsOptimization.src.Views
{
    public partial class ListCompositeControls : UserControl
    {
        public event CompositeControl.CallbackGetListFunctions EventGetListFunctions;
        public event Composite.CallBackNotifyOfResult EventNotyfiOfResult;
        public event Composite.CallBackNotifyError EventNotyfiError;

        public ListCompositeControls()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Add(CreateCompositeControlPanel());
        }

        private Panel CreateCompositeControlPanel()
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Top;
            Size size = panel.Size;
            size.Height = 200;
            panel.Size = size;

            Label label = new Label();
            label.Text = Controls.Count.ToString();
            label.Dock = DockStyle.Left;

            CompositeControl composite = new CompositeControl();
            composite.Dock = DockStyle.Fill;
            composite.EventGetUsedMethods += GetEmptyMethod;
            composite.EventGetListFunctions += EventGetListFunctions;
            composite.EventNotyfiOfResult += EventNotyfiOfResult;
            composite.EventNotyfiError += EventNotyfiError;
            /*composite.Composite.EventNotifyOfResult += EventNotyfiOfResult;
            composite.Composite.EventNotifyOfErrorRuning += EventNotyfiError;*/

            panel.Controls.AddRange(new Control[]{ composite, label });

            return panel;
        }

        private EmptyMethod GetEmptyMethod(int number)
        {
            if (Controls.Count > number)
            {
                CompositeControl composite = Controls[number].Controls[0] as CompositeControl;
                if (composite != null)
                {
                    return composite.Composite;
                }
            }
            return null;
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int number = toolStripTextBoxRemoveNumber.Text != "" ? Int32.Parse(toolStripTextBoxRemoveNumber.Text) : -1;
            if (number > 0 && number < Controls.Count)
            {
                Controls.RemoveAt(number);
                for (int i = number; i < Controls.Count; i++)
                {
                    Controls[i].Controls[1].Text = i.ToString();
                }
            }
        }
    }
}
