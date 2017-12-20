using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MethodsOptimization.src.Parametrs;
using MethodsOptimization.src.Methods;
using System.IO;
using System.Reflection;
using MethodsOptimization.src.Methods.LinearSearch;

namespace MethodsOptimization.src.Views
{
    public partial class Logs : UserControl
    {
        public Logs()
        {
            InitializeComponent();
        }

        public void WriteInLog(Result result, Params param, EmptyMethod method)
        {
            bool composite = false;
            if (method as Composite != null) { composite = true; }
            richTextBoxLogs.Text += "Метод " + method.Name + "\t";
            richTextBoxLogs.Text += "Параметры " + "y = " + param.Y.Function + "\t" + (param.X0 != null ? "X0 " + param.X0.Vars(): "") + "\t" + (param.P != null ? "P " + param.P.Vars(): "") + "\t";
            richTextBoxLogs.Text += "Результат " + (!composite ? "K = " + result.K.ToString(): "") + "\t" + (result.XMin != null ? result.XMin.Vars() : "") + "\n";
            if (composite) { richTextBoxLogs.Text += "\n"; }
        }

        public void WriteInLogError(Params param, EmptyMethod method, string messageErr)
        {
            richTextBoxLogs.Text += "Метод " + method.Name + "\t";
            richTextBoxLogs.Text += "Параметры " + "y = " + param.Y.Function + "\t" + (param.X0 != null ? "X0 " + param.X0.Vars() + " " : "") + (param.P != null ? "P " + param.P.Vars() + " " : "") + "\t";
            richTextBoxLogs.Text += "Сообщение " + messageErr + "\t";
            richTextBoxLogs.Text += "\n";
        }

        private void сохранитьВФайлToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                StreamWriter stream = new StreamWriter(saveFileDialog.FileName);
                stream.WriteLine(richTextBoxLogs.Text);
                stream.Close();
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxLogs.Text = "";
        }

        private void CreateWordDocument(string FileName)
        {

        }
    }
}
