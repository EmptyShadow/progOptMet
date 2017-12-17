namespace MethodsOptimization.src.Views
{
    partial class FormCreateMethod
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
            this.labelMethod = new System.Windows.Forms.Label();
            this.labelLimParams = new System.Windows.Forms.Label();
            this.checkBoxNorma = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumberGroup = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMethod.Location = new System.Drawing.Point(0, 0);
            this.labelMethod.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(77, 27);
            this.labelMethod.TabIndex = 0;
            this.labelMethod.Text = "Метод";
            this.labelMethod.Click += new System.EventHandler(this.labelMethod_Click);
            // 
            // labelLimParams
            // 
            this.labelLimParams.AutoSize = true;
            this.labelLimParams.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLimParams.Location = new System.Drawing.Point(0, 27);
            this.labelLimParams.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelLimParams.Name = "labelLimParams";
            this.labelLimParams.Size = new System.Drawing.Size(148, 27);
            this.labelLimParams.TabIndex = 1;
            this.labelLimParams.Text = "Ограничения";
            this.labelLimParams.Click += new System.EventHandler(this.labelLimParams_Click);
            // 
            // checkBoxNorma
            // 
            this.checkBoxNorma.AutoSize = true;
            this.checkBoxNorma.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxNorma.Location = new System.Drawing.Point(0, 54);
            this.checkBoxNorma.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxNorma.Name = "checkBoxNorma";
            this.checkBoxNorma.Size = new System.Drawing.Size(399, 31);
            this.checkBoxNorma.TabIndex = 2;
            this.checkBoxNorma.Text = "Нормирование";
            this.checkBoxNorma.UseVisualStyleBackColor = true;
            this.checkBoxNorma.CheckedChanged += new System.EventHandler(this.checkBoxNorma_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Номер группы используемых методов";
            // 
            // textBoxNumberGroup
            // 
            this.textBoxNumberGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxNumberGroup.Location = new System.Drawing.Point(0, 112);
            this.textBoxNumberGroup.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNumberGroup.Name = "textBoxNumberGroup";
            this.textBoxNumberGroup.Size = new System.Drawing.Size(399, 34);
            this.textBoxNumberGroup.TabIndex = 4;
            // 
            // buttonCreate
            // 
            this.buttonCreate.AutoSize = true;
            this.buttonCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCreate.Location = new System.Drawing.Point(0, 146);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(399, 44);
            this.buttonCreate.TabIndex = 5;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCancel.Location = new System.Drawing.Point(0, 190);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(399, 44);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormCreateMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 236);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxNumberGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxNorma);
            this.Controls.Add(this.labelLimParams);
            this.Controls.Add(this.labelMethod);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormCreateMethod";
            this.Text = "Форма для создания метода";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMethod;
        private System.Windows.Forms.Label labelLimParams;
        private System.Windows.Forms.CheckBox checkBoxNorma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumberGroup;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCancel;
    }
}