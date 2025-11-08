using DemoLib;
using DemoLib.Presenters;
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
        private Client currentClient_;
        private ClientPresenter presenter_;
        private BindingList<OrderRecord> ordersBindingList_;

        public ClientOrdersForm(Client client, ClientPresenter presenter)
        {
            InitializeComponent();
            presenter_ = presenter;
            currentClient_ = client;
        }

        public void SetOrder(Order order)
        {
            RefreshOrdersTable();

            /// Д.З. Сделать масштабирование колонок таблицы по размеру окна
            /// Добавить строку Итого
            /// По цене: средняя цена, по стоимости - общая сумма, остальные - прочерки
            currentOrder_ = order;
            OrdersTable.DataSource = null;
            OrdersTable.DataSource = order.GetRecords();
        }

        private void RefreshOrdersTable()
        {
            if (currentClient_ != null && currentClient_.order != null)
            {
                ordersBindingList_ = new BindingList<OrderRecord>(currentClient_.order.GetRecords());
                OrdersTable.DataSource = ordersBindingList_;
            }
        }

        private void AddtoolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrderForm addForm = new AddOrderForm();

                // ВАЖНО: Проверяем результат диалога и валидность данных
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    OrderRecord newRecord = addForm.GetOrderRecord();

                    // Дополнительная проверка на случай, если форма прошла валидацию, но данные все равно пустые
                    if (string.IsNullOrWhiteSpace(newRecord.NameProduct) || newRecord.Price <= 0 || newRecord.Count <= 0)
                    {
                        MessageBox.Show("Некорректные данные заказа", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Добавляем в БД через презентер
                    presenter_.AddOrderRecord(currentClient_.ID, newRecord);

                    // Локально добавляем в текущий заказ для немедленного отображения
                    currentClient_.order.AddRecord(newRecord);
                    RefreshOrdersTable();

                    MessageBox.Show("Заказ успешно добавлен", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletetoolStripButton_Click(object sender, EventArgs e)
        {
            if (OrdersTable.SelectedRows.Count > 0)
            {
                var selectedRecord = OrdersTable.SelectedRows[0].DataBoundItem as OrderRecord;
                if (selectedRecord != null)
                {
                    var result = MessageBox.Show("Вы уверены, что хотите удалить этот заказ?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Удаляем из БД через презентер
                        bool success = presenter_.RemoveOrderRecord(currentClient_.ID, selectedRecord);

                        if (success)
                        {
                            // Локально удаляем из текущего заказа
                            currentClient_.order.RemoveRecord(selectedRecord);
                            RefreshOrdersTable();

                            MessageBox.Show("Заказ успешно удален", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
