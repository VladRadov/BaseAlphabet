using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Alphabet.Model;
using Alphabet.Presenter;

using Alphabet.View.AdministratorViews;

namespace Alphabet
{
    partial class FormAddUser : Form, IAddUserView
    {
        public event Action AddUserEventHandler;

        public event Action<ISharedAdministratorView> SelectAllUserGroupEventHandler;

        public event Action ViewAllUsersFromadEventHandler;

        public string ViewLogin { get; set; }

        public string ViewUserGroup { get; set; }

        public FormAddUser()
        {
            InitializeComponent();

            new AdministratorPresenter(new Administrator(), this);
        }

        public void ViewAllUserGroup(string[] allUserGroup)
        {
            Invoke((MethodInvoker)(() =>
                {
                    cBoxUserGroup.Items.Clear();
                    cBoxUserGroup.Items.Remove(cBoxUserGroup.Text);
                    cBoxUserGroup.Items.AddRange(allUserGroup);
                }));
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ViewLogin = cBoxLogin.Text;
            ViewUserGroup = cBoxUserGroup.Text;
            
            AddUserEventHandler.Invoke();
        }

        public void ViewAllUsersFromAD(string[] allUser)
        {
            Invoke((MethodInvoker)(() =>
            {
                cBoxLogin.Items.Clear();
                cBoxLogin.Items.Remove(cBoxUserGroup.Text);
                cBoxLogin.Items.AddRange(allUser);
            }));
        }

        public void ShowMessageBox(string text, string title, MessageBoxButtons button, MessageBoxIcon icon)
        {
            Invoke((MethodInvoker)(() =>
            {
                MessageBox.Show(text, title, button, icon);
            }));
        }

        private void cBoxUserGroup_DropDown(object sender, EventArgs e)
        {
            SelectAllUserGroupEventHandler.Invoke(this);
        }

        private void FormAddUser_Load(object sender, EventArgs e)
        {
            ViewAllUsersFromadEventHandler.Invoke();
        }
    }
}
