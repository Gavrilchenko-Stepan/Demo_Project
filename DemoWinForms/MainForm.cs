using ClientCard;
using DemoLib;
using DemoLib.Models;
using DemoLib.Models.Clients;
using DemoLib.Presenters;
using DemoLib.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class MainForm : Form
    {
        private User currentUser_ = null;
        private ClientPresenter presenter_;
        public MainForm(User user)
        {
            currentUser_ = user;
            InitializeComponent();

            MySQLClientsModel model = new MySQLClientsModel();

            /// Д.З Сделать нормальный вид карточек - сделано
            List<IClientView> cards = new List<IClientView>();

            int countClients = 0;
            try
            {
                countClients = model.GetClientsCount();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Ошибка работы с БД",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < countClients; i++)
            {
                ClientView card = new ClientView(); /// наклепали пустую карточку
                card.SelectedClient += Card_SelectedClient;
                ClientsLayout.Controls.Add(card); /// добавляем карточку на главную форму в layout
                cards.Add(card); 
            }

            presenter_ = new ClientPresenter(model, cards);
        }

        private void Card_SelectedClient(Client obj)
        {
            if(obj == null)
            {
                return;
            }

            if (isLowRoleUser())
            {
                MessageBox.Show("У Вас не хватает прав, чтобы посмотреть заказы.\n" +
                                "Обратитесь, пожалуйста, к администратору",
                                "Сообщение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else
            {
                ClientOrdersForm ordersForm = new ClientOrdersForm(obj, presenter_);
                ordersForm.Text = "Заказы клиента " + obj.Name;
                ordersForm.SetOrder(obj.order);
                ordersForm.ShowDialog();
            }
        }

        private void SearchByClientNameTextBox_TextChanged(object sender, System.EventArgs e)
        {
            string searchingText = SearchByClientNameTextBox.Text;
            
            presenter_.SearchClientsByPartialName(searchingText);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private bool isLowRoleUser()
        {
            /// currentUser_ == null - это гость
            return currentUser_.Role == UserRole.Client || currentUser_ == null;
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            if(isLowRoleUser())
            {
                this.SearchByClientNameTextBox.Enabled = false;
                this.SearchByNameLabel.Text = "Поиск по клиенту Вам недоступен";
                this.SearchByNameLabel.ForeColor = System.Drawing.Color.Red;
            }

            if (currentUser_ != null)
            {
                Text = this.Text + " - " + currentUser_.Login;
            }
        }

        private void естьЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyOrderFilter(sender);
        }

        private void нетЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyOrderFilter(sender);
        }

        private void ApplyOrderFilter(object sender)
        {
            // Получаем текущее состояние галочек
            bool hasOrders = естьЗаказыToolStripMenuItem.Checked;
            bool noOrders = нетЗаказовToolStripMenuItem.Checked;

            // Защита от одновременного выбора обоих фильтров
            // Если пользователь выбрал оба варианта, снимаем предыдущую галочку
            if (hasOrders && noOrders)
            {
                var clickedItem = sender as ToolStripMenuItem;
                if (clickedItem == естьЗаказыToolStripMenuItem)
                {
                    // Если нажали "Есть заказы" - снимаем "Нет заказов"
                    нетЗаказовToolStripMenuItem.Checked = false;
                    noOrders = false;
                }
                else
                {
                    // Если нажали "Нет заказов" - снимаем "Есть заказы"
                    естьЗаказыToolStripMenuItem.Checked = false;
                    hasOrders = false;
                }
            }

            // Обновляем текст на кнопке фильтра для отображения текущего состояния
            if (hasOrders)
                toolStripFilterButton.Text = "Есть заказы ✓";
            else if (noOrders)
                toolStripFilterButton.Text = "Нет заказов ✓";
            else
                toolStripFilterButton.Text = "Фильтр по заказам";

            // Применяем или сбрасываем фильтр в зависимости от состояния галочек
            if (hasOrders || noOrders)
            {
                // Если хотя бы одна галочка установлена - применяем фильтр
                presenter_?.ApplyOrdersFilter(hasOrders, noOrders);
            }
            else
            {
                // Если все галочки сняты - сбрасываем фильтр (показываем всех клиентов)
                presenter_?.ResetFilter();
            }
        }
    }
}
