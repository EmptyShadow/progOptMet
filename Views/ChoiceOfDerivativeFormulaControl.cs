using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MethodsOptimization.src.Functions;

namespace MethodsOptimization.src.Views
{
    public partial class ChoiceOfDerivativeFormulaControl : UserControl
    {
        Dictionary<RadioButton, Functions.Math.PartialDerivative> dictionaryFirst = new Dictionary<RadioButton, Functions.Math.PartialDerivative>();
        Dictionary<RadioButton, Functions.Math.SecondPartialDerivative> dictionarySecond = new Dictionary<RadioButton, Functions.Math.SecondPartialDerivative>();

        public ChoiceOfDerivativeFormulaControl()
        {
            InitializeComponent();
            
            TextBox textBox = new TextBox();
            textBox.Dock = DockStyle.Top;
            textBox.Text = Functions.Math.H.ToString();
            textBox.Leave += TextBox_VisibleChanged;
            Controls.Add(textBox);

            Label label = new Label();
            label.Dock = DockStyle.Top;
            label.Text = "Бесконечно малое число";
            Controls.Add(label);

            InitializeFirstDerivative();
            InitializeSecondDerivative();
        }

        private void InitializeFirstDerivative()
        {
            ToolTip toolTip = new ToolTip();
            RadioButton radioButton = new RadioButton();
            radioButton.Checked = true;
            radioButton.CheckedChanged += radioButton_CheckedChangedFirstDerivative;
            radioButton.Dock = DockStyle.Top;
            radioButton.Text = "Правая конечно-разностная аппроксимация";
            toolTip.SetToolTip(radioButton, "(f(x + H) - f(x)) / H");
            dictionaryFirst.Add(radioButton, Functions.Math.RightFiniteDifferenceApproximation);
            tabPageFirst.Controls.Add(radioButton);

            radioButton = new RadioButton();
            radioButton.Checked = false;
            radioButton.CheckedChanged += radioButton_CheckedChangedFirstDerivative;
            radioButton.Dock = DockStyle.Top;
            radioButton.Text = "Центральная конечно-разностная аппроксимация 1";
            toolTip.SetToolTip(radioButton, "(f(x + H) - f(x - H)) / H");
            dictionaryFirst.Add(radioButton, Functions.Math.СentralFiniteDifferenceApproximation1);
            tabPageFirst.Controls.Add(radioButton);

            radioButton = new RadioButton();
            radioButton.Checked = false;
            radioButton.CheckedChanged += radioButton_CheckedChangedFirstDerivative;
            radioButton.Dock = DockStyle.Top;
            radioButton.Text = "Центральная конечно-разностная аппроксимация 2";
            toolTip.SetToolTip(radioButton, "(f(x + 2H) - 4f(x) + 3f(x + 2H)) / 2H");
            dictionaryFirst.Add(radioButton, Functions.Math.СentralFiniteDifferenceApproximation2);
            tabPageFirst.Controls.Add(radioButton);

            radioButton = new RadioButton();
            radioButton.Checked = false;
            radioButton.CheckedChanged += radioButton_CheckedChangedFirstDerivative;
            radioButton.Dock = DockStyle.Top;
            radioButton.Text = "Центральная конечно-разностная аппроксимация 3";
            toolTip.SetToolTip(radioButton, "(-f(x + 2H) + 8f(x + H) - 8f(x - H) + f(x - 2H)) / 12H");
            dictionaryFirst.Add(radioButton, Functions.Math.СentralFiniteDifferenceApproximation3);
            tabPageFirst.Controls.Add(radioButton);
        }

        private void InitializeSecondDerivative()
        {
            ToolTip toolTip = new ToolTip();
            RadioButton radioButton = new RadioButton();
            radioButton.Checked = true;
            radioButton.CheckedChanged += radioButton_CheckedChangedSecondDerivative;
            radioButton.Dock = DockStyle.Top;
            radioButton.Text = "Вторая производная 1";
            toolTip.SetToolTip(radioButton, "(f(xi + H, xj + H) - f(xi + H) - f(xj + H) + f(x)) / H^2");
            dictionarySecond.Add(radioButton, Functions.Math.DDFByVars1);
            tabPageSecond.Controls.Add(radioButton);

            radioButton = new RadioButton();
            radioButton.Checked = false;
            radioButton.CheckedChanged += radioButton_CheckedChangedSecondDerivative;
            radioButton.Dock = DockStyle.Top;
            radioButton.Text = "Вторая производная 2";
            toolTip.SetToolTip(radioButton, "(f(xi + H, xj + H) - f(xi + H, xj - H) - f(xi - H, xj + H) + f(xi - H, xj - H)) / (4 * H^2)");
            dictionarySecond.Add(radioButton, Functions.Math.DDFByVars2);
            tabPageSecond.Controls.Add(radioButton);
        }

        private void TextBox_VisibleChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                try
                {
                    double H = Double.Parse(textBox.Text);
                    Functions.Math.H = H;
                }
                catch (Exception exc)
                {
                    textBox.Text = Functions.Math.H.ToString();
                }
            }
        }

        private void radioButton_CheckedChangedFirstDerivative(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio != null)
            {
                if (radio.Checked == true)
                {
                    Functions.Math.DFByIVar = dictionaryFirst[radio];
                }
            }
        }

        private void radioButton_CheckedChangedSecondDerivative(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio != null)
            {
                if (radio.Checked == true)
                {
                    Functions.Math.DDFByVars = dictionarySecond[radio];
                }
            }
        }
    }
}
