using System;
using System.Drawing;
using System.Windows.Forms;

using Alphabet.View.AdministratorViews;
using Alphabet.Presenter;
using Alphabet.Model;
using Alphabet.UI;
using Alphabet.Service;

namespace Alphabet
{
    partial class FormAdministrator : Form, IAdministratorView
    {
        public event Action<ListView> ViewUsersEventHandler;

        public event Action<string> SelectedUserEventHandler;

        public event Action<ISharedAdministratorView> SelectAllUserGroupEventHandler;

        public event Action<ListView> EditUserEventHandler;

        public event Action<ComboBox> ViewLogTypesEventHandler;

        public event Action<ComboBox> ViewLoginsOfUsersActionsEventHandler;

        public event Action<ComboBox> ViewUserActionTypesActionsEventHandler;

        public event Action<ListView, DateTime, DateTime, string, string> ViewLogsEventHandler;

        public event Action<ListView, DateTime, DateTime, string, string> ViewUserActionsEventHandler;

        public string ViewFIO { get; set; }

        public string ViewLogin { get; set; }

        public string ViewUserGroup { get; set; }

        public bool ViewIsDeleteed { get; set; }

        public FormAdministrator()
        {
            InitializeComponent();

            new AdministratorPresenter(new Administrator(), this);
        }

        public void ShowMessageBox(string text, string title, MessageBoxButtons button, MessageBoxIcon icon)
        {
            Invoke((MethodInvoker)(() =>
            {
                MessageBox.Show(text, title, button, icon);
            }));
        }

        private void panelUsers_MouseEnter(object sender, EventArgs e)
        {
            panelUsers.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void panelLogs_MouseEnter(object sender, EventArgs e)
        {
            panelLogs.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void panelUserAction_MouseEnter(object sender, EventArgs e)
        {
            panelUserAction.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void panelLogs_MouseLeave(object sender, EventArgs e)
        {
            panelLogs.BackColor = Color.Transparent;
        }

        private void panelUsers_MouseLeave(object sender, EventArgs e)
        {
            panelUsers.BackColor = Color.Transparent;
        }

        private void panelUserAction_MouseLeave(object sender, EventArgs e)
        {
            panelUserAction.BackColor = Color.Transparent;
        }

        private void ClickOnSelectUsers(object sender, EventArgs e)
        {
            ShowRunLogs.Visible = false;
            ShowRunUserAction.Visible = false;
            ShowRunUsers.Dock = DockStyle.Fill;
            ShowRunUsers.Visible = true;

            ViewUsersEventHandler.Invoke(ViewDataUsers);
        }

        private void ClickOnSelectLogs(object sender, EventArgs e)
        {
            ShowRunUsers.Visible = false;
            ShowRunUserAction.Visible = false;
            ShowRunLogs.Dock = DockStyle.Fill;
            ShowRunLogs.Visible = true;
        }

        private void ClickOnSelectUserActions(object sender, EventArgs e)
        {
            ViewLoginsOfUsersActionsEventHandler.Invoke(cBoxUserName);
            ViewUserActionTypesActionsEventHandler.Invoke(cBoxActionType);

            ShowRunUsers.Visible = false;
            ShowRunLogs.Visible = false;
            ShowRunUserAction.Dock = DockStyle.Fill;
            ShowRunUserAction.Visible = true;
        }

        public void UpdateListView(ListView listView, ColumnHeader[] columns, ListViewItem[] rows)
        {
            Invoke((MethodInvoker)(() =>
            {
                listView.Items.Clear();
                listView.Columns.Clear();

                listView.Columns.AddRange(columns);
                listView.Items.AddRange(rows);

                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }));
        }

        private void listVData_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ViewDataUsers.ContextMenuStrip = BaseContextMenu.ShowContextMenu();
        }

        private void listVData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewDataUsers.SelectedIndices.Count != 0)
                SelectedUserEventHandler.Invoke(ViewDataUsers.Items[ViewDataUsers.SelectedIndices[0]].Text);
            else
                ClearViewDataSelectedUser();
        }

        public void ViewDataSelectedUser()
        {
            Invoke((MethodInvoker)(() =>
            {
                tBoxFIO.Text = ViewFIO;
                tBoxLogin.Text = ViewLogin;
                cBoxUserGroup.Text = ViewUserGroup;
                chBoxIsDeleteUser.Checked = ViewIsDeleteed;
            }));
        }

        private void ClearViewDataSelectedUser()
        {
            tBoxFIO.Clear();
            tBoxLogin.Clear();
            cBoxUserGroup.Text = "";
            chBoxIsDeleteUser.Checked = false;
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

        public void UpdateComboBox(ComboBox cBox, string[] rows)
        {
            Invoke((MethodInvoker)(() =>
            {
                cBox.Items.Clear();
                cBox.Items.AddRange(rows);
                cBox.Items.Add("");
            }));
        }

        private void btnSaveEdetedUser_Click(object sender, EventArgs e)
        {
            if (tBoxLogin.Text.Length != 0 && cBoxUserGroup.Text.Length != 0)
            {
                ViewLogin = tBoxLogin.Text;
                ViewUserGroup = cBoxUserGroup.Text;
                ViewIsDeleteed = chBoxIsDeleteUser.Checked;
                EditUserEventHandler.Invoke(ViewDataUsers);
            }
            else
                ShowMessageBox("Выберите пользователя и группу прав для пользователя!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ViewDataUsers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorting(ViewDataUsers, e.Column);
        }

        private void ViewLogs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorting(ViewLogs, e.Column);
        }

        private void ViewUserActions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorting(ViewUserActions, e.Column);
        }

        private void Sorting(ListView listView, int countColumn)
        {
            if (listView.Sorting == SortOrder.Ascending)
                listView.Sorting = SortOrder.Descending;
            else
                listView.Sorting = SortOrder.Ascending;

            listView.Sort();
            listView.ListViewItemSorter = new BaseCompare(countColumn, listView.Sorting);
        }

        private void FormAdministrator_Load(object sender, EventArgs e)
        {
            ViewLogTypesEventHandler.Invoke(cBoxLogTypes);
            SelectAllUserGroupEventHandler.Invoke(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ViewLogsEventHandler.Invoke(ViewLogs, dtpStart.Value, dtpFinish.Value, cBoxLogTypes.Text, tBoxDescription.Text);
        }

        private void btnSearchActions_Click(object sender, EventArgs e)
        {
            ViewUserActionsEventHandler.Invoke(ViewUserActions, dtpStartAction.Value, dtpFinishAction.Value, cBoxUserName.Text, cBoxActionType.Text);
        }
    }
}
