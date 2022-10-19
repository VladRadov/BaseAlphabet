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
    public partial class ARMSelectForm : Form
    {
        public ARMSelectForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (EditForm f = new EditForm())
            {
                Hide();
                f.ShowDialog();
                Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SearchForm f = new SearchForm())
            {
                Hide();
                f.ShowDialog();
                Show();
            }
        }
    }
}
