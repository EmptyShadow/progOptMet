using MethodsOptimization.src.Methods;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            listCompositeControls.EventGetListFunctions += dataGridFunctions.GetSelectedFunctions;
            listCompositeControls.EventNotyfiOfResult += logs.WriteInLog;
            listCompositeControls.EventNotyfiError += logs.WriteInLogError;
        }
    }
}
