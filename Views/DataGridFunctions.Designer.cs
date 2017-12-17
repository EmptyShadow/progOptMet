namespace MethodsOptimization.src.Views
{
    partial class DataGridFunctions
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.функцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewFunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewFunctions = new System.Windows.Forms.DataGridView();
            this.FunctionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunctions)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.функцииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(302, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // функцииToolStripMenuItem
            // 
            this.функцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewFunctionToolStripMenuItem,
            this.RemoveFunctionsToolStripMenuItem});
            this.функцииToolStripMenuItem.Name = "функцииToolStripMenuItem";
            this.функцииToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.функцииToolStripMenuItem.Text = "Функции";
            // 
            // addNewFunctionToolStripMenuItem
            // 
            this.addNewFunctionToolStripMenuItem.Name = "addNewFunctionToolStripMenuItem";
            this.addNewFunctionToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.addNewFunctionToolStripMenuItem.Text = "Добавить новую функцию";
            this.addNewFunctionToolStripMenuItem.Click += new System.EventHandler(this.addNewFunctionToolStripMenuItem_Click);
            // 
            // RemoveFunctionsToolStripMenuItem
            // 
            this.RemoveFunctionsToolStripMenuItem.Name = "RemoveFunctionsToolStripMenuItem";
            this.RemoveFunctionsToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.RemoveFunctionsToolStripMenuItem.Text = "Удалить выделенные функции";
            this.RemoveFunctionsToolStripMenuItem.Click += new System.EventHandler(this.RemoveFunctionsToolStripMenuItem_Click);
            // 
            // dataGridViewFunctions
            // 
            this.dataGridViewFunctions.AllowUserToAddRows = false;
            this.dataGridViewFunctions.AllowUserToDeleteRows = false;
            this.dataGridViewFunctions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewFunctions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewFunctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFunctions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FunctionColumn,
            this.XColumn,
            this.PColumn});
            this.dataGridViewFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFunctions.Location = new System.Drawing.Point(0, 28);
            this.dataGridViewFunctions.Name = "dataGridViewFunctions";
            this.dataGridViewFunctions.ReadOnly = true;
            this.dataGridViewFunctions.RowTemplate.Height = 24;
            this.dataGridViewFunctions.Size = new System.Drawing.Size(302, 242);
            this.dataGridViewFunctions.TabIndex = 1;
            this.dataGridViewFunctions.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewFunctions_RowHeaderMouseDoubleClick);
            // 
            // FunctionColumn
            // 
            this.FunctionColumn.HeaderText = "Функция";
            this.FunctionColumn.Name = "FunctionColumn";
            this.FunctionColumn.ReadOnly = true;
            this.FunctionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FunctionColumn.Width = 73;
            // 
            // XColumn
            // 
            this.XColumn.HeaderText = "X";
            this.XColumn.Name = "XColumn";
            this.XColumn.ReadOnly = true;
            this.XColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XColumn.Width = 23;
            // 
            // PColumn
            // 
            this.PColumn.HeaderText = "P";
            this.PColumn.Name = "PColumn";
            this.PColumn.ReadOnly = true;
            this.PColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PColumn.Width = 23;
            // 
            // DataGridFunctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewFunctions);
            this.Controls.Add(this.menuStrip1);
            this.Name = "DataGridFunctions";
            this.Size = new System.Drawing.Size(302, 270);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunctions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem функцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewFunctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveFunctionsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewFunctions;
        private System.Windows.Forms.DataGridViewTextBoxColumn FunctionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn XColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PColumn;
    }
}
