namespace EditingRegistrationApp
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.tbName = new System.Windows.Forms.TextBox();
            this.dtDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.dtDateExpire = new System.Windows.Forms.DateTimePicker();
            this.cbIndex = new System.Windows.Forms.ComboBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.cbRoute = new System.Windows.Forms.ComboBox();
            this.tbTelegram = new System.Windows.Forms.TextBox();
            this.bProcess = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lNumber = new System.Windows.Forms.Label();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.cbActive = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cbUser = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 220);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(929, 200);
            this.dgvList.TabIndex = 7;
            // 
            // tbName
            // 
            this.tbName.Enabled = false;
            this.tbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(16, 61);
            this.tbName.MaxLength = 128;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(307, 26);
            this.tbName.TabIndex = 8;
            // 
            // dtDateOfBirth
            // 
            this.dtDateOfBirth.CustomFormat = "";
            this.dtDateOfBirth.Enabled = false;
            this.dtDateOfBirth.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfBirth.Location = new System.Drawing.Point(333, 61);
            this.dtDateOfBirth.Name = "dtDateOfBirth";
            this.dtDateOfBirth.Size = new System.Drawing.Size(175, 26);
            this.dtDateOfBirth.TabIndex = 13;
            // 
            // dtDateExpire
            // 
            this.dtDateExpire.CustomFormat = "";
            this.dtDateExpire.Enabled = false;
            this.dtDateExpire.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtDateExpire.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateExpire.Location = new System.Drawing.Point(333, 124);
            this.dtDateExpire.Name = "dtDateExpire";
            this.dtDateExpire.Size = new System.Drawing.Size(175, 26);
            this.dtDateExpire.TabIndex = 15;
            // 
            // cbIndex
            // 
            this.cbIndex.DisplayMember = "Name";
            this.cbIndex.Enabled = false;
            this.cbIndex.FormattingEnabled = true;
            this.cbIndex.Location = new System.Drawing.Point(521, 60);
            this.cbIndex.Name = "cbIndex";
            this.cbIndex.Size = new System.Drawing.Size(121, 27);
            this.cbIndex.TabIndex = 17;
            this.cbIndex.ValueMember = "Id";
            // 
            // cbCountry
            // 
            this.cbCountry.DisplayMember = "ShortName";
            this.cbCountry.Enabled = false;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(521, 123);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(121, 27);
            this.cbCountry.TabIndex = 19;
            this.cbCountry.ValueMember = "Id";
            // 
            // cbRoute
            // 
            this.cbRoute.Enabled = false;
            this.cbRoute.FormattingEnabled = true;
            this.cbRoute.Items.AddRange(new object[] {
            "Въезд",
            "Выезд"});
            this.cbRoute.Location = new System.Drawing.Point(659, 60);
            this.cbRoute.Name = "cbRoute";
            this.cbRoute.Size = new System.Drawing.Size(121, 27);
            this.cbRoute.TabIndex = 21;
            // 
            // tbTelegram
            // 
            this.tbTelegram.Enabled = false;
            this.tbTelegram.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTelegram.Location = new System.Drawing.Point(659, 124);
            this.tbTelegram.MaxLength = 6;
            this.tbTelegram.Name = "tbTelegram";
            this.tbTelegram.Size = new System.Drawing.Size(121, 26);
            this.tbTelegram.TabIndex = 22;
            // 
            // bProcess
            // 
            this.bProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bProcess.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bProcess.Location = new System.Drawing.Point(858, 177);
            this.bProcess.Name = "bProcess";
            this.bProcess.Size = new System.Drawing.Size(83, 37);
            this.bProcess.TabIndex = 24;
            this.bProcess.Text = "Поиск";
            this.bProcess.UseVisualStyleBackColor = true;
            this.bProcess.Click += new System.EventHandler(this.bProcess_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(772, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 37);
            this.button1.TabIndex = 25;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lNumber
            // 
            this.lNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lNumber.AutoSize = true;
            this.lNumber.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lNumber.Location = new System.Drawing.Point(9, 431);
            this.lNumber.Name = "lNumber";
            this.lNumber.Size = new System.Drawing.Size(100, 18);
            this.lNumber.TabIndex = 26;
            this.lNumber.Text = "Количество: ";
            // 
            // cbSex
            // 
            this.cbSex.Enabled = false;
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] {
            "Женский",
            "Мужской"});
            this.cbSex.Location = new System.Drawing.Point(797, 60);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(121, 27);
            this.cbSex.TabIndex = 28;
            // 
            // cbActive
            // 
            this.cbActive.Enabled = false;
            this.cbActive.FormattingEnabled = true;
            this.cbActive.Items.AddRange(new object[] {
            "Активные",
            "Неактивные"});
            this.cbActive.Location = new System.Drawing.Point(797, 123);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(121, 27);
            this.cbActive.TabIndex = 30;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 23);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Tag = "tbName";
            this.checkBox1.Text = "ФИО";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(797, 31);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(55, 23);
            this.checkBox3.TabIndex = 33;
            this.checkBox3.Tag = "cbSex";
            this.checkBox3.Text = "Пол";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(797, 100);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(101, 23);
            this.checkBox4.TabIndex = 34;
            this.checkBox4.Tag = "cbActive";
            this.checkBox4.Text = "Состояние";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(659, 100);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(128, 23);
            this.checkBox5.TabIndex = 35;
            this.checkBox5.Tag = "tbTelegram";
            this.checkBox5.Text = "№ телеграммы";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(659, 31);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(118, 23);
            this.checkBox6.TabIndex = 36;
            this.checkBox6.Tag = "cbRoute";
            this.checkBox6.Text = "Направление";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(521, 100);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(77, 23);
            this.checkBox7.TabIndex = 37;
            this.checkBox7.Tag = "cbCountry";
            this.checkBox7.Text = "Страна";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(521, 31);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(77, 23);
            this.checkBox8.TabIndex = 38;
            this.checkBox8.Tag = "cbIndex";
            this.checkBox8.Text = "Индекс";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(333, 100);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(175, 23);
            this.checkBox9.TabIndex = 39;
            this.checkBox9.Tag = "dtDateExpire";
            this.checkBox9.Text = "Дата истечения срока";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(333, 31);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(131, 23);
            this.checkBox10.TabIndex = 40;
            this.checkBox10.Tag = "dtDateOfBirth";
            this.checkBox10.Text = "Дата рождения";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(16, 94);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(120, 23);
            this.checkBox2.TabIndex = 42;
            this.checkBox2.Tag = "cbUser";
            this.checkBox2.Text = "Пользователь";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // cbUser
            // 
            this.cbUser.DisplayMember = "FIO";
            this.cbUser.Enabled = false;
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Items.AddRange(new object[] {
            "Активные",
            "Неактивные"});
            this.cbUser.Location = new System.Drawing.Point(16, 123);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(307, 27);
            this.cbUser.TabIndex = 43;
            this.cbUser.ValueMember = "Id";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 458);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox10);
            this.Controls.Add(this.checkBox9);
            this.Controls.Add(this.checkBox8);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.cbSex);
            this.Controls.Add(this.lNumber);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bProcess);
            this.Controls.Add(this.tbTelegram);
            this.Controls.Add(this.cbRoute);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.cbIndex);
            this.Controls.Add(this.dtDateExpire);
            this.Controls.Add(this.dtDateOfBirth);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dgvList);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "АРМ Поиск";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DateTimePicker dtDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtDateExpire;
        private System.Windows.Forms.ComboBox cbIndex;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.ComboBox cbRoute;
        private System.Windows.Forms.TextBox tbTelegram;
        private System.Windows.Forms.Button bProcess;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lNumber;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.ComboBox cbActive;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox cbUser;
    }
}