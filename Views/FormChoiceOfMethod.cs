using MethodsOptimization.src.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodsOptimization.src.Views
{
    public partial class FormChoiceOfMethod : Form
    {
        public delegate void CallBackEventSelectedMethod(EmptyMethod method);

        public event CallBackEventSelectedMethod EventSelectedMethod;

        EmptyMethod selectedMethod = null;

        public FormChoiceOfMethod()
        {
            InitializeComponent();

            Core core = Core.Instance;

            ComboBox comboBox = CreatedComboBox(core.Methods);
            comboBox.Dock = DockStyle.Top;
            comboBox.SelectedValueChanged += comboBox_SelectedValueChanged;
            panelListsMethods.Controls.Add(comboBox);
        }

        ComboBox CreatedComboBox(EmptyMethod method)
        {
            ComboBox comboBox = new ComboBox();

            Composite composite = method as Composite;
            if (composite != null)
            {
                comboBox.DataSource = composite.GetList();
                comboBox.DisplayMember = "Name";
            } else { return null; }

            return comboBox;
        }

        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                EmptyMethod method = comboBox.SelectedItem as EmptyMethod;
                if (method != null)
                {
                    ComboBox newComboBox = CreatedComboBox(method);
                    if (newComboBox != null)
                    {
                        newComboBox.Dock = DockStyle.Top;
                        newComboBox.SelectedValueChanged += comboBox_SelectedValueChanged;
                        RemoveComboBoxes(panelListsMethods.Controls.IndexOf(comboBox) + 1, panelListsMethods.Controls.Count - 1);
                        panelListsMethods.Controls.Add(newComboBox);
                    } else
                    {
                        selectedMethod = method;
                    }
                }
            }
        }

        private void RemoveComboBoxes(int indexStart, int indexStop)
        {
            if (indexStart == -1 || indexStop == -1) { return; }
            for (int i = indexStop; i >= indexStart; i--)
            {
                panelListsMethods.Controls.RemoveAt(i);
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedMethod != null)
            {
                if (EventSelectedMethod != null)
                {
                    ConstructorInfo constructor = selectedMethod.GetType().GetConstructor(new Type[] { });
                    object method = constructor.Invoke(new object[]{ });
                    if (method == null) { return; }
                    EventSelectedMethod(method as EmptyMethod);
                    Close();
                }
            }
        }

        private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
