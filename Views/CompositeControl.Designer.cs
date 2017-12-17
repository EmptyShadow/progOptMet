namespace MethodsOptimization.src.Views
{
    partial class CompositeControl
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
            this.методыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveSelectMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimParams = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Normalization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberUsedMethods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.методыToolStripMenuItem,
            this.runToolStripMenuItem,
            this.typeRunToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 320);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(661, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // методыToolStripMenuItem
            // 
            this.методыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMethodToolStripMenuItem,
            this.RemoveSelectMethodToolStripMenuItem});
            this.методыToolStripMenuItem.Name = "методыToolStripMenuItem";
            this.методыToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.методыToolStripMenuItem.Text = "Методы";
            // 
            // addMethodToolStripMenuItem
            // 
            this.addMethodToolStripMenuItem.Name = "addMethodToolStripMenuItem";
            this.addMethodToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.addMethodToolStripMenuItem.Text = "Добавить";
            this.addMethodToolStripMenuItem.Click += new System.EventHandler(this.addMethodToolStripMenuItem_Click);
            // 
            // RemoveSelectMethodToolStripMenuItem
            // 
            this.RemoveSelectMethodToolStripMenuItem.Name = "RemoveSelectMethodToolStripMenuItem";
            this.RemoveSelectMethodToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.RemoveSelectMethodToolStripMenuItem.Text = "Удалить";
            this.RemoveSelectMethodToolStripMenuItem.Click += new System.EventHandler(this.RemoveSelectMethodToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.runToolStripMenuItem.Text = "Запустить";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Method,
            this.LimParams,
            this.Normalization,
            this.NumberUsedMethods});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(661, 320);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // Method
            // 
            this.Method.HeaderText = "Метод";
            this.Method.Name = "Method";
            this.Method.ReadOnly = true;
            this.Method.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Method.Width = 70;
            // 
            // LimParams
            // 
            this.LimParams.HeaderText = "Ограничения";
            this.LimParams.Name = "LimParams";
            this.LimParams.ReadOnly = true;
            this.LimParams.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LimParams.Width = 129;
            // 
            // Normalization
            // 
            this.Normalization.HeaderText = "Нормирование";
            this.Normalization.Name = "Normalization";
            this.Normalization.ReadOnly = true;
            this.Normalization.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Normalization.Width = 143;
            // 
            // NumberUsedMethods
            // 
            this.NumberUsedMethods.HeaderText = "№ группы использующихся методов";
            this.NumberUsedMethods.Name = "NumberUsedMethods";
            this.NumberUsedMethods.ReadOnly = true;
            this.NumberUsedMethods.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumberUsedMethods.Width = 292;
            // 
            // typeRunToolStripMenuItem
            // 
            this.typeRunToolStripMenuItem.Name = "typeRunToolStripMenuItem";
            this.typeRunToolStripMenuItem.Size = new System.Drawing.Size(273, 24);
            this.typeRunToolStripMenuItem.Text = "Тип исполнения последовательный";
            this.typeRunToolStripMenuItem.Click += new System.EventHandler(this.typeRunToolStripMenuItem_Click);
            // 
            // CompositeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CompositeControl";
            this.Size = new System.Drawing.Size(661, 350);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem методыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveSelectMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Method;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimParams;
        private System.Windows.Forms.DataGridViewTextBoxColumn Normalization;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberUsedMethods;
        private System.Windows.Forms.ToolStripMenuItem typeRunToolStripMenuItem;
    }
}
