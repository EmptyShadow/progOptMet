namespace MethodsOptimization.src.Views
{
    partial class ChoiceOfTypeRunComposite
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
            this.buttonLineRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUnLineRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLineRun
            // 
            this.buttonLineRun.AutoSize = true;
            this.buttonLineRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLineRun.Location = new System.Drawing.Point(0, 22);
            this.buttonLineRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLineRun.Name = "buttonLineRun";
            this.buttonLineRun.Size = new System.Drawing.Size(300, 37);
            this.buttonLineRun.TabIndex = 0;
            this.buttonLineRun.Text = "Последовательно";
            this.buttonLineRun.UseVisualStyleBackColor = true;
            this.buttonLineRun.Click += new System.EventHandler(this.buttonLineRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Как исполнять методы?";
            // 
            // buttonUnLineRun
            // 
            this.buttonUnLineRun.AutoSize = true;
            this.buttonUnLineRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUnLineRun.Location = new System.Drawing.Point(0, 59);
            this.buttonUnLineRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUnLineRun.Name = "buttonUnLineRun";
            this.buttonUnLineRun.Size = new System.Drawing.Size(300, 37);
            this.buttonUnLineRun.TabIndex = 2;
            this.buttonUnLineRun.Text = "Независимо";
            this.buttonUnLineRun.UseVisualStyleBackColor = true;
            this.buttonUnLineRun.Click += new System.EventHandler(this.buttonUnLineRun_Click);
            // 
            // ChoiceOfTypeRunComposite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 96);
            this.Controls.Add(this.buttonUnLineRun);
            this.Controls.Add(this.buttonLineRun);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChoiceOfTypeRunComposite";
            this.Text = "Выбор исполнения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLineRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUnLineRun;
    }
}