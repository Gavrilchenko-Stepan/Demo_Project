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

namespace SimpleDemoWin
{
    public partial class AddEditClientForm : Form
    {

        private Client client_;
        private bool isEditMode_;

        public Client Client => client_;

        public AddEditClientForm(Client client = null)
        {
            InitializeComponent();

            if (client != null)
            {
                client_ = client;
                isEditMode_ = true;
                Text = "Редактирование клиента";
                FillForm();
            }
            else
            {
                client_ = new Client();
                isEditMode_ = false;
                Text = "Добавление клиента";
            }
        }

        private void FillForm()
        {
            NameTextBox.Text = client_.Name;
            PhoneTextBox.Text = client_.Phone;
            MailTextBox.Text = client_.Mail;
            DescriptionTextBox.Text = client_.Description;
            ImagePathTextBox.Text = client_.ImagePath;
        }

        private void AddEditClientForm_Load(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите имя клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            client_.Name = NameTextBox.Text;
            client_.Phone = PhoneTextBox.Text;
            client_.Mail = MailTextBox.Text;
            client_.Description = DescriptionTextBox.Text;
            client_.ImagePath = ImagePathTextBox.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
