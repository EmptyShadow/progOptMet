namespace MethodsOptimization.src.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listCompositeControls = new MethodsOptimization.src.Views.ListCompositeControls();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGridFunctions = new MethodsOptimization.src.Views.DataGridFunctions();
            this.choiceOfDerivativeFormulaControl = new MethodsOptimization.src.Views.ChoiceOfDerivativeFormulaControl();
            this.logs = new MethodsOptimization.src.Views.Logs();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.logs);
            this.splitContainer1.Size = new System.Drawing.Size(1627, 874);
            this.splitContainer1.SplitterDistance = 578;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listCompositeControls);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1627, 578);
            this.splitContainer2.SplitterDistance = 898;
            this.splitContainer2.TabIndex = 0;
            // 
            // listCompositeControls
            // 
            this.listCompositeControls.AutoScroll = true;
            this.listCompositeControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCompositeControls.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listCompositeControls.Location = new System.Drawing.Point(0, 0);
            this.listCompositeControls.Margin = new System.Windows.Forms.Padding(5);
            this.listCompositeControls.Name = "listCompositeControls";
            this.listCompositeControls.Size = new System.Drawing.Size(898, 578);
            this.listCompositeControls.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dataGridFunctions);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.choiceOfDerivativeFormulaControl);
            this.splitContainer3.Size = new System.Drawing.Size(725, 578);
            this.splitContainer3.SplitterDistance = 207;
            this.splitContainer3.TabIndex = 0;
            // 
            // dataGridFunctions
            // 
            this.dataGridFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridFunctions.Location = new System.Drawing.Point(0, 0);
            this.dataGridFunctions.Name = "dataGridFunctions";
            this.dataGridFunctions.Size = new System.Drawing.Size(725, 207);
            this.dataGridFunctions.TabIndex = 0;
            // 
            // choiceOfDerivativeFormulaControl
            // 
            this.choiceOfDerivativeFormulaControl.AutoScroll = true;
            this.choiceOfDerivativeFormulaControl.AutoSize = true;
            this.choiceOfDerivativeFormulaControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.choiceOfDerivativeFormulaControl.Location = new System.Drawing.Point(0, 0);
            this.choiceOfDerivativeFormulaControl.Name = "choiceOfDerivativeFormulaControl";
            this.choiceOfDerivativeFormulaControl.Size = new System.Drawing.Size(725, 367);
            this.choiceOfDerivativeFormulaControl.TabIndex = 0;
            // 
            // logs
            // 
            this.logs.AutoSize = true;
            this.logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logs.Location = new System.Drawing.Point(0, 0);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(1627, 292);
            this.logs.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1627, 874);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Численные методы";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ListCompositeControls listCompositeControls;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private DataGridFunctions dataGridFunctions;
        private ChoiceOfDerivativeFormulaControl choiceOfDerivativeFormulaControl;
        private Logs logs;
    }
}