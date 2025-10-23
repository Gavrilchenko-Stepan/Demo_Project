namespace DemoProject
{
    partial class ClientOrdersForm
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
            this.ManagementPanel = new System.Windows.Forms.ToolStrip();
            this.AddtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.DeletetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.OrdersTable = new System.Windows.Forms.DataGridView();
            this.ManagementPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // ManagementPanel
            // 
            this.ManagementPanel.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ManagementPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddtoolStripButton,
            this.DeletetoolStripButton});
            this.ManagementPanel.Location = new System.Drawing.Point(0, 0);
            this.ManagementPanel.Name = "ManagementPanel";
            this.ManagementPanel.Size = new System.Drawing.Size(800, 35);
            this.ManagementPanel.TabIndex = 0;
            this.ManagementPanel.Text = "toolStrip1";
            // 
            // AddtoolStripButton
            // 
            this.AddtoolStripButton.AutoSize = false;
            this.AddtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddtoolStripButton.Image = global::DemoProject.Properties.Resources.AddIcon;
            this.AddtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddtoolStripButton.Name = "AddtoolStripButton";
            this.AddtoolStripButton.Size = new System.Drawing.Size(32, 32);
            this.AddtoolStripButton.Text = "toolStripButton1";
            this.AddtoolStripButton.ToolTipText = "Позволит добавить новый заказ";
            // 
            // DeletetoolStripButton
            // 
            this.DeletetoolStripButton.AutoSize = false;
            this.DeletetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeletetoolStripButton.Image = global::DemoProject.Properties.Resources.RemoveIcon;
            this.DeletetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeletetoolStripButton.Name = "DeletetoolStripButton";
            this.DeletetoolStripButton.Size = new System.Drawing.Size(32, 32);
            this.DeletetoolStripButton.Text = "toolStripButton2";
            // 
            // OrdersTable
            // 
            this.OrdersTable.AllowUserToAddRows = false;
            this.OrdersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersTable.Location = new System.Drawing.Point(0, 35);
            this.OrdersTable.Name = "OrdersTable";
            this.OrdersTable.ReadOnly = true;
            this.OrdersTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrdersTable.Size = new System.Drawing.Size(800, 415);
            this.OrdersTable.TabIndex = 1;
            // 
            // ClientOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OrdersTable);
            this.Controls.Add(this.ManagementPanel);
            this.Name = "ClientOrdersForm";
            this.ManagementPanel.ResumeLayout(false);
            this.ManagementPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ManagementPanel;
        private System.Windows.Forms.ToolStripButton AddtoolStripButton;
        private System.Windows.Forms.ToolStripButton DeletetoolStripButton;
        private System.Windows.Forms.DataGridView OrdersTable;
    }
}