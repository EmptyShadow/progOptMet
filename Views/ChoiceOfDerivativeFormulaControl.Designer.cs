namespace MethodsOptimization.src.Views
{
    partial class ChoiceOfDerivativeFormulaControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageFirst = new System.Windows.Forms.TabPage();
            this.tabPageSecond = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageFirst);
            this.tabControl.Controls.Add(this.tabPageSecond);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 18);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(247, 186);
            this.tabControl.TabIndex = 3;
            // 
            // tabPageFirst
            // 
            this.tabPageFirst.Location = new System.Drawing.Point(4, 25);
            this.tabPageFirst.Name = "tabPageFirst";
            this.tabPageFirst.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFirst.Size = new System.Drawing.Size(239, 157);
            this.tabPageFirst.TabIndex = 0;
            this.tabPageFirst.Text = "Первая производная";
            this.tabPageFirst.UseVisualStyleBackColor = true;
            // 
            // tabPageSecond
            // 
            this.tabPageSecond.Location = new System.Drawing.Point(4, 25);
            this.tabPageSecond.Name = "tabPageSecond";
            this.tabPageSecond.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSecond.Size = new System.Drawing.Size(245, 161);
            this.tabPageSecond.TabIndex = 1;
            this.tabPageSecond.Text = "Вторая производная";
            this.tabPageSecond.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 207);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор формул производных";
            // 
            // ChoiceOfDerivativeFormulaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Name = "ChoiceOfDerivativeFormulaControl";
            this.Size = new System.Drawing.Size(253, 207);
            this.tabControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFirst;
        private System.Windows.Forms.TabPage tabPageSecond;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
