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
    public partial class ClientOrdersForm: Form
    {
        private Order currentOrder_;
        private BindingList<OrderRecord> ordersBindingList_;
        public ClientOrdersForm()
        {
            InitializeComponent();
        }

        public void SetOrder(Order order)
        {
            /// Д.З. Сделать масштабирование колонок таблицы по размеру окна
            /// Добавить строку Итого
            /// По цене: средняя цена, по стоимости - общая сумма, остальные - прочерки
            currentOrder_ = order;
            OrdersTable.DataSource = null;
            OrdersTable.DataSource = order.GetRecords();
        }

        private void AddtoolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void DeletetoolStripButton_Click(object sender, EventArgs e)
        {

        }
    }
}
