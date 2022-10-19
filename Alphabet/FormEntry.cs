using System;
using System.Drawing;
using System.Windows.Forms;

using Alphabet.View;
using Alphabet.Presenter;
using Alphabet.Model;
using Alphabet.Service;

namespace Alphabet
{
    public partial class FormEntry : Form, IAuthorizationView, IUserSessionsView
    {
        public event Action CloseUserSessionEventHandler;

        private AuthorizationPresenter _authorizationPresenter;

        public FormEntry()
        {
            InitializeComponent();

            ParentGroundOfARMs = panelArms;
            _authorizationPresenter = new AuthorizationPresenter(new Authorization(), this);
        }

        public event Action AuthorizationEventHandler;

        public event Action LoadEventHandler;

        public string Login { get; set; }

        public string Server { get; set; }

        public string Password { get; set; }

        public string DomainNameView { get; set; }

        public Color OldColor { get; set; }

        public Control ParentGroundOfARMs { get; set; }

        public void ShowMessageBox(string text, string title, MessageBoxButtons button, MessageBoxIcon icon)
        {
            Invoke((MethodInvoker)(() =>
            {
                MessageBox.Show(text, title, button, icon);
            }));
        }

        public void ViewSessionStatus(Image image, string nameGroup, Color colorBackground)
        {
            Invoke((MethodInvoker)(() =>
            {
                pBoxIconUsers.Image = image;
                labelNameUsersGroup.Text = nameGroup;
                pBoxIconUsers.BackColor = colorBackground;
            }));
        }

        public void ChangeStateBaseButton(Color color)
        {
            Invoke((MethodInvoker)(() =>
            {
                OldColor = pBoxIconUsers.BackColor;
                pBoxIconUsers.BackColor = color;
            }));
        }

        public void SetColorChekingConnection(Color backColor)
        {
            Invoke((MethodInvoker)(() =>
            {
                btnConnect.BackColor = backColor;
            }));
        }

        public void UpdateComBoxDomains(string[] items)
        {
            Invoke((MethodInvoker)(() =>
            {
                comBoxDomains.Items.AddRange(items);
                comBoxDomains.Text = comBoxDomains.Items[0].ToString();
            }));
        }

        private void btnAuthorization_Click(object sender, EventArgs e)
        {
            panelArms.Controls.Clear();
            labelNameUsersGroup.Text = string.Empty;
            pBoxIconUsers.BackColor = Color.Transparent;

            DomainNameView = comBoxDomains.Text;
            Login = tBoxLogin.Text;
            Password = tBoxPassword.Text;
            AuthorizationEventHandler.Invoke();
        }

        private void FormEntry_Load(object sender, EventArgs e)
        {
            StringConnection.Server = @"SRV-1";
            StringConnection.ConnectionTimeout = 3;
            LoadEventHandler.Invoke();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var formConnection = new FormConnection(_authorizationPresenter);
            formConnection.ShowDialog();
        }

        private void FormEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseUserSessionEventHandler != null)
                CloseUserSessionEventHandler.Invoke();
        }
    }
}
