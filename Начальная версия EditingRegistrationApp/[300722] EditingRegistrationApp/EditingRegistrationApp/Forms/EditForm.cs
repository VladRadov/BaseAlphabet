using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Principal;

namespace EditingRegistrationApp
{
    public partial class EditForm : Form
    {
        public static EditForm Instance { get; set; }
        private int _idTelegram;
        private int _idRoute;
        private DateTime _date;
        public static string usr = string.Format("Пользователь - {0}.", WindowsIdentity.GetCurrent().Name.ToString());

        public EditForm()
        {
            InitializeComponent();
            Instance = this;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _date = DateTime.Now;

            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Архив | *.zip" })
            {
                dgvList.DataSource = string.Empty;
                dgvAdd.DataSource = string.Empty;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var folder = ofd.SafeFileName.Split('.')[0];
                    Directory.CreateDirectory(folder);
                    Block(false);
                    System.IO.Compression.ZipFile.ExtractToDirectory(ofd.FileName, folder, Encoding.GetEncoding(System.Globalization.CultureInfo.CurrentCulture.TextInfo.OEMCodePage));
                    Person.List = new List<Person>();
                    foreach (var file in Directory.GetFiles(folder, "*.txt"))
                    {
                        var t = file.Split(new char[] { '\\', '_' }, StringSplitOptions.RemoveEmptyEntries);
                        dtDate.Value = DateTime.Parse(t.Last().Replace(".txt", "").Trim());
                        await FileOperations.Read(file, t[5] == "1" ? 1 : 2, t[7].ToLower() == "въезд" ? 0 : 1);
                    }
                    Directory.Delete(folder, true);
                    CreateTable();
                    Block(true);
                    tbNumber.Text = folder.Remove(folder.Length -1);
                    lNumber.Text = string.Format("Количество - {0}", dgvList.RowCount);
                }
            }

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await Log.Init();
        }

        private void Block(bool state)
        {
            if (!state)
                timer1.Start();
            else
                timer1.Stop();
            menuStrip1.Enabled = state;
            bProcess.Enabled = state;
            groupBox1.Enabled = state;
            groupBox2.Enabled = state;
            groupBox3.Enabled = state;
            groupBox4.Enabled = state;
        }
        private void Block2()
        {
            int cdgvl = dgvList.Rows.Count;
            if (cdgvl > 0)
            {
                menuStrip1.Enabled = false;
                bProcess.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
            }
            else
            {
                menuStrip1.Enabled = true;
                bProcess.Enabled = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (tbNumber.Text.Length == 0)
            {
                MessageBox.Show("Введите номер телеграммы!");
            }
            else if (Person.List.Count == 0)
            {
                MessageBox.Show("Загрузите список ОУ!");
            }
            else
            {
                var warn = string.Format("№ телеграммы - {0}. \nНаправление - {1}. \nДата подписания - {2}.", tbNumber.Text, rbIn.Checked ? rbIn.Text : rbOut.Text, dtDate.Value.ToShortDateString());
                Log.Write(Log.Type.WARNING, warn);
                if (MessageBox.Show(this, warn, "Проверка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Block(false);
                    _date = DateTime.Now;
                    _idTelegram = await DB.InsertTelegram(tbNumber.Text, dtDate.Value);
                    /* if (_idTelegram == -1)
                      {
                          Block(true);
                          MessageBox.Show("Такая телеграмма уже была добавлена!");
                          return;
                      }*/
                    _idRoute = rbIn.Checked ? 0 : 1;
                    progressBar1.Value = 0;

                    if (rbAdd.Checked)
                        await Registration();
                    else
                        await DeRegistration();

                }
            }
        }

        public Task DeRegistration()
        {
            return Task.Run(async () =>
            {
                Log.Write(Log.Type.INFO, "Начало операции снятия с учёта. ");
                try
                {
                    var list = Person.List.Where(x => x.Route == (rbIn.Checked ? 0 : 1) && x.Type == (rbAdd.Checked ? 2 : 1));
                    Invoke(new MethodInvoker(() => { progressBar1.Maximum = list.Count(); }));
                    foreach (Person item in list)
                    {
                        Invoke(new MethodInvoker(() => { progressBar1.Value++; }));
                         
                        /*if (Person.List.FirstOrDefault(x => x.IsDeleted && x.FIO == item.FIO && x.DateOfBirth == item.DateOfBirth
                 && x.DateExpire == item.DateExpire && x.Type == 1) != null)
                        {
                            item.IsDeleted = true;
                            continue;
                        }*/
                        item.DT = await DB.Compare(item);
                        if (item.DT.Rows.Count == 0)
                        {
                            item.IsDeleted = false;
                        }
                        else if (item.DT.Rows.Count > 1)
                        {
                            item.IsMulty = true;
                        }
                        else
                        {
                            item.IsDeleted = true;
                            await DB.Change(Convert.ToInt64(item.DT.Rows[0].ItemArray[0]), _idTelegram);
                        }

                    }
                    Invoke(new MethodInvoker(() =>
                    {
                        Person.List.RemoveAll(x => x.IsDeleted && x.Route == (rbIn.Checked ? 0 : 1) && x.Type == (rbAdd.Checked ? 2 : 1));
                        CreateTable();
                        var count = Person.List.Where(x => !x.IsDeleted && x.Route == (rbIn.Checked ? 0 : 1) && x.Type == (rbAdd.Checked ? 2 : 1)).Count();
                        var res = string.Format("Количество снятых записей - {0}. Ожидают принятия решения - {1}.", progressBar1.Maximum - count, count);
                        Log.Write(Log.Type.INFO, "Завершение операции снятия с учёта. " + res + "\n");
                        Block(true);
                        MessageBox.Show(this, res, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
                catch (Exception ex)
                {
                    Log.Write(Log.Type.ERROR, "Ошибка операции снятия с учёта.\n" + ex.Message);
                }
            });
        }

        public Task Registration()
        {
            return Task.Run(async () =>
             {
                 Log.Write(Log.Type.INFO, "Начало операции постановки на учёт.");
                 try
                 {
                     var list = Person.List.Where(x => x.Route == (rbIn.Checked ? 0 : 1) && x.Type == (rbAdd.Checked ? 2 : 1)).ToList();
                     Invoke(new MethodInvoker(() => { progressBar1.Maximum = list.Count(); }));
                     int sum = 0;
                     foreach (Person item in list)
                     {
                         var res = await DB.InsertPerson(item, _idTelegram);
                         sum += res;
                         if (res == 1)
                             Person.List.Remove(item);
                         
                         Invoke(new MethodInvoker(() => { progressBar1.Value++; }));
                     }
                     Invoke(new MethodInvoker(() =>
                     {
                         var res = string.Format("Количество обработанных записей - {0}", sum);
                         Log.Write(Log.Type.INFO, "Завершение операции постановки на учёт. " + res);
                         CreateTable();
                         Block(true);
                         MessageBox.Show(this, res, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }));
                 }
                 catch (Exception ex)
                 {
                     Log.Write(Log.Type.ERROR, "Ошибка операции постановки на учёт.\n" + ex.Message);
                 }
             });
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                dgvAdd.DataSource = Person.List.First(x => x.Id == (int)dgvList.CurrentRow.Cells[0].Value).DT;
                if (dgvAdd.ColumnCount > 0)
                    dgvAdd.Columns[0].Visible = false;
            }
        }

        private async void снятьСУчётаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAdd.SelectedRows.Count != 0)
            {
                await DB.Change(Convert.ToInt64(dgvAdd.CurrentRow.Cells[0].Value), _idTelegram);
                dgvAdd.DataSource = null;
                Person.List.Remove(Person.List.First(x => x.Id == (int)dgvList.CurrentRow.Cells[0].Value));
                UpdateTable();
                Log.Write(Log.Type.INFO, "Принятие решения по дублированным записям. " + usr);

            }
        }

        private void CreateTable()
        {
            dgvList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dgvList.RowHeadersVisible = false;
            dgvList.DataSource = Person.List.Where(x => x.Route == (rbIn.Checked ? 0 : 1) && x.Type == (rbAdd.Checked ? 2 : 1)).ToList();
            dgvList.Columns[1].HeaderText = "ФИО";
            dgvList.Columns[2].HeaderText = "Дата рождения";
            dgvList.Columns[3].HeaderText = "Отметка";
            dgvList.Columns[4].HeaderText = "Срок контроля";
            dgvList.Columns[5].HeaderText = "Пол";
            dgvList.Columns[6].HeaderText = "Страна";
            dgvList.Columns[7].HeaderText = "Место рождения";
            dgvList.Columns[8].HeaderText = "Дополнительные сведения";
            dgvList.Columns[9].HeaderText = "Задание";
            dgvList.Columns[10].HeaderText = "Ключ";
            dgvList.Columns[0].Visible = false;
            dgvList.Columns[11].Visible = false;
            dgvList.Columns[12].Visible = false;
            dgvList.Columns[13].Visible = false;
            dgvList.Columns[14].Visible = false;
            dgvList.Columns[15].Visible = false;
            lNumber.Text = string.Format("Количество - {0}", dgvList.RowCount);
            UpdateTable();
        }

        private void UpdateTable()
        {
            foreach (DataGridViewRow item in dgvList.Rows)
            {
                //item.DefaultCellStyle.BackColor = (bool)item.Cells[10].Value ? Color.Red : (bool)item.Cells[9].Value ? Color.Orange : Color.White;
                item.DefaultCellStyle.BackColor = (bool)item.Cells[13].Value ? Color.Red : (bool)item.Cells[12].Value ? Color.Orange : !(bool)item.Cells[12].Value ? Color.Orange : Color.White;
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                dgvAdd.DataSource = null;
                Person.List.Remove(Person.List.First(x => x.Id == (int)dgvList.CurrentRow.Cells[0].Value));
                UpdateTable();
                Log.Write(Log.Type.INFO, "Ручное редактирование списка не найденных в БД. " + usr);
                Block2();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var date = DateTime.Now.Subtract(_date);
            lTime.Text = string.Format("Время выполнения: {0}:{1}", (date.Minutes > 9 ? "" + date.Minutes : "0" + date.Minutes), (date.Seconds > 9 ? "" + date.Seconds : "0" + date.Seconds));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string razd = "\n-------------------------------------------------------------------------";
            Log.Write(Log.Type.DEBUG, "Завершение работы." + razd);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private DialogResult OpenForm(Form f)
        {
            using (f)
            {
                return f.ShowDialog();
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rbIn_CheckedChanged(object sender, EventArgs e)
        {
            CreateTable();
            bProcess.Text = rbAdd.Checked ? "Поставить на учёт" : "Снять с учёта";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DB.Start();
        }
    }
}
