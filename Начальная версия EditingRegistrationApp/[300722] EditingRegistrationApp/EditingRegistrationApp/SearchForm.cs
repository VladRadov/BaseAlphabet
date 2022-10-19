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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();

            cbUser.DataSource = DB.GetTable("select Id, FIO from [User]").GetAwaiter().GetResult();
            cbIndex.DataSource = DB.GetTable("select Id, Name from [Mark]").GetAwaiter().GetResult();
            cbCountry.DataSource = DB.GetTable("select Id, ShortName from [Country]").GetAwaiter().GetResult();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            var control = Controls.Find(cb.Tag.ToString(), true)[0];
            control.Enabled = cb.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                if (!(item is CheckBox) && !(item is Button))
                    item.ResetText();
            }
        }

        private async void bProcess_Click(object sender, EventArgs e)
        {
            bProcess.Enabled = false;
            dgvList.DataSource = await DB.Find(string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                checkBox1.Checked ? "and p.FIO like '%" + tbName.Text + "%'" : "", 
                  checkBox4.Checked ? "and p.IsDeleted = " + cbActive.SelectedIndex : "",
                   checkBox3.Checked ? "and p.Sex = " + cbSex.SelectedIndex : "",
                    checkBox5.Checked ? "and t.Number = '" + tbTelegram.Text + "'" : "",
                     checkBox6.Checked ? "and p.Route = " + cbRoute.SelectedIndex : "",
                      checkBox7.Checked ? "and p.IdCountry = " + cbCountry.SelectedValue : "",
                       checkBox8.Checked ? "and p.IdMark = " + cbIndex.SelectedValue : "",
                        checkBox9.Checked ? "and p.DateExpire = '" + dtDateExpire.Value.ToString("yyyyMMdd") + "'" : "",
                         checkBox10.Checked ? "and p.DateOfBirth = '" + dtDateOfBirth.Value.ToString("yyyyMMdd") + "'" : "",
                         checkBox2.Checked ? "and u.IdUser = " + cbUser.SelectedValue : ""
                ));
            bProcess.Enabled = true;
            lNumber.Text = "Количество: " + dgvList.RowCount;
        }
    }
}
