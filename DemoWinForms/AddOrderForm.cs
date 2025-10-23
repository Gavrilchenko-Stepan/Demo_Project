using DemoLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class AddOrderForm : Form
    {
        private OrderRecord orderRecord_;
        public AddOrderForm()
        {
            InitializeComponent();
            orderRecord_ = new OrderRecord();
        }

        private void AddOrderForm_Load(object sender, EventArgs e)
        {
        }
        public AddOrderForm(OrderRecord existingRecord)
        {
            InitializeComponent();
            orderRecord_ = existingRecord;
            FillFormWithExistingData();
        }

        private void FillFormWithExistingData()
        {
            textBoxName.Text = orderRecord_.NameProduct;
            dateTimePickerDate.Value = orderRecord_.SaleDate;
            numericUpDownPrice.Value = (decimal)orderRecord_.Price;
            numericUpDownCount.Value = orderRecord_.Count;
        }

        public OrderRecord GetOrderRecord()
        {
            return orderRecord_;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                orderRecord_.NameProduct = textBoxName.Text.Trim();
                orderRecord_.SaleDate = dateTimePickerDate.Value;
                orderRecord_.Price = (double)numericUpDownPrice.Value;
                orderRecord_.Count = (int)numericUpDownCount.Value;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите наименование товара", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxName.Focus();
                return false;
            }

            if (numericUpDownPrice.Value <= 0)
            {
                MessageBox.Show("Цена должна быть больше 0", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDownPrice.Focus();
                return false;
            }

            return true;
        }
    }
}
