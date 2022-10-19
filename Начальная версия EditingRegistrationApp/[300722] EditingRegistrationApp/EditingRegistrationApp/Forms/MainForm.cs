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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (AuthForm f = new AuthForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                    Close();
            }
            using (ARMSelectForm f = new ARMSelectForm())
            {
                f.ShowDialog();
                 
            }
        }
    }
}
