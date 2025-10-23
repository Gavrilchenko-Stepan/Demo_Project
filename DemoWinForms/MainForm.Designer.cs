namespace DemoProject
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ClientsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SearchByNameLabel = new System.Windows.Forms.ToolStripLabel();
            this.SearchByClientNameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripFilterButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.естьЗаказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нетЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientsLayout
            // 
            this.ClientsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientsLayout.Location = new System.Drawing.Point(0, 0);
            this.ClientsLayout.Margin = new System.Windows.Forms.Padding(30);
            this.ClientsLayout.Name = "ClientsLayout";
            this.ClientsLayout.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.ClientsLayout.Size = new System.Drawing.Size(800, 450);
            this.ClientsLayout.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchByNameLabel,
            this.SearchByClientNameTextBox,
            this.toolStripSeparator1,
            this.toolStripFilterButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SearchByNameLabel
            // 
            this.SearchByNameLabel.Name = "SearchByNameLabel";
            this.SearchByNameLabel.Size = new System.Drawing.Size(148, 22);
            this.SearchByNameLabel.Text = "Поиск по имени клиента:";
            // 
            // SearchByClientNameTextBox
            // 
            this.SearchByClientNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchByClientNameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SearchByClientNameTextBox.Name = "SearchByClientNameTextBox";
            this.SearchByClientNameTextBox.Size = new System.Drawing.Size(100, 25);
            this.SearchByClientNameTextBox.TextChanged += new System.EventHandler(this.SearchByClientNameTextBox_TextChanged);
            // 
            // toolStripFilterButton
            // 
            this.toolStripFilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripFilterButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.естьЗаказыToolStripMenuItem,
            this.нетЗаказовToolStripMenuItem});
            this.toolStripFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripFilterButton.Image")));
            this.toolStripFilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFilterButton.Name = "toolStripFilterButton";
            this.toolStripFilterButton.Size = new System.Drawing.Size(124, 22);
            this.toolStripFilterButton.Text = "Фильтр по заказам";
            // 
            // естьЗаказыToolStripMenuItem
            // 
            this.естьЗаказыToolStripMenuItem.CheckOnClick = true;
            this.естьЗаказыToolStripMenuItem.Name = "естьЗаказыToolStripMenuItem";
            this.естьЗаказыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.естьЗаказыToolStripMenuItem.Text = "Есть заказы";
            this.естьЗаказыToolStripMenuItem.Click += new System.EventHandler(this.естьЗаказыToolStripMenuItem_Click);
            // 
            // нетЗаказовToolStripMenuItem
            // 
            this.нетЗаказовToolStripMenuItem.CheckOnClick = true;
            this.нетЗаказовToolStripMenuItem.Name = "нетЗаказовToolStripMenuItem";
            this.нетЗаказовToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.нетЗаказовToolStripMenuItem.Text = "Нет заказов";
            this.нетЗаказовToolStripMenuItem.Click += new System.EventHandler(this.нетЗаказовToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ClientsLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Управление клиентами ОАО \"Цемент-Строй\"";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel ClientsLayout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel SearchByNameLabel;
        private System.Windows.Forms.ToolStripTextBox SearchByClientNameTextBox;
        private System.Windows.Forms.ToolStripDropDownButton toolStripFilterButton;
        private System.Windows.Forms.ToolStripMenuItem естьЗаказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нетЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

