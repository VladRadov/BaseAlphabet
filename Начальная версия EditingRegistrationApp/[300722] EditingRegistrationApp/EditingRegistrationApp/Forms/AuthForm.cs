using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditingRegistrationApp
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private async void bProcess_Click(object sender, EventArgs e)
        { 
            if (string.IsNullOrWhiteSpace(tbUserName.Text))
            {
                MessageBox.Show("Введите имя пользователя!");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Введите пароль!");
                return;
            }
            Properties.Settings.Default.User = tbUserName.Text;
            Properties.Settings.Default.Password = tbPassword.Text;
            if (!await DB.Open())
                MessageBox.Show(DB.ExceptionText);
            else
                DialogResult = DialogResult.OK;
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DBForm f = new DBForm())
            {
                f.ShowDialog();

            }
        }
    }
}
