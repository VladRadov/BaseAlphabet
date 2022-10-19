using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Alphabet.Service;
using Alphabet.Presenter;

namespace Alphabet
{
    partial class FormConnection : Form
    {
        private AuthorizationPresenter _authorizationPresenter;

        private event Action CheckingConnectionEventHandler;

        public FormConnection(AuthorizationPresenter authorizationPresenter)
        {
            InitializeComponent();

            _authorizationPresenter = authorizationPresenter;
        }

        private void FormConnection_Load(object sender, EventArgs e)
        {
            tBoxServer.Text = StringConnection.Server;
        }

        private void btnCheckConnection_Click(object sender, EventArgs e)
        {
            StringConnection.Server = tBoxServer.Text;
            CheckingConnectionEventHandler += _authorizationPresenter.CheckingConnectionToDB;
            CheckingConnectionEventHandler.Invoke();
            CheckingConnectionEventHandler -= _authorizationPresenter.CheckingConnectionToDB;
        }
    }
}
