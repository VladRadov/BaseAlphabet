namespace Alphabet
{
    partial class FormAdministrator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdministrator));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.panelUserAction = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panelLogs = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ViewDataUsers = new System.Windows.Forms.ListView();
            this.panelDataSelectedUser = new System.Windows.Forms.Panel();
            this.btnSaveEdetedUser = new System.Windows.Forms.Button();
            this.tBoxFIO = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.chBoxIsDeleteUser = new System.Windows.Forms.CheckBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxLogin = new System.Windows.Forms.TextBox();
            this.cBoxUserGroup = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.ShowRunUsers = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ShowRunLogs = new System.Windows.Forms.Panel();
            this.ViewLogs = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.tBoxDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFinish = new System.Windows.Forms.DateTimePicker();
            this.cBoxLogTypes = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ShowRunUserAction = new System.Windows.Forms.Panel();
            this.ViewUserActions = new System.Windows.Forms.ListView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSearchActions = new System.Windows.Forms.Button();
            this.dtpStartAction = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpFinishAction = new System.Windows.Forms.DateTimePicker();
            this.cBoxUserName = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cBoxActionType = new System.Windows.Forms.ComboBox();
            this.leftPanel.SuspendLayout();
            this.panelUserAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panelLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDataSelectedUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.ShowRunUsers.SuspendLayout();
            this.ShowRunLogs.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ShowRunUserAction.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftPanel.Controls.Add(this.panelUserAction);
            this.leftPanel.Controls.Add(this.panelLogs);
            this.leftPanel.Controls.Add(this.panelUsers);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(206, 446);
            this.leftPanel.TabIndex = 0;
            // 
            // panelUserAction
            // 
            this.panelUserAction.BackColor = System.Drawing.Color.Transparent;
            this.panelUserAction.Controls.Add(this.label10);
            this.panelUserAction.Controls.Add(this.pictureBox5);
            this.panelUserAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelUserAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUserAction.Location = new System.Drawing.Point(0, 100);
            this.panelUserAction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelUserAction.Name = "panelUserAction";
            this.panelUserAction.Size = new System.Drawing.Size(204, 50);
            this.panelUserAction.TabIndex = 3;
            this.panelUserAction.Click += new System.EventHandler(this.ClickOnSelectUserActions);
            this.panelUserAction.MouseEnter += new System.EventHandler(this.panelUserAction_MouseEnter);
            this.panelUserAction.MouseLeave += new System.EventHandler(this.panelUserAction_MouseLeave);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.Location = new System.Drawing.Point(57, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 32);
            this.label10.TabIndex = 1;
            this.label10.Text = "Журнал операций\r\nпользователей";
            this.label10.Click += new System.EventHandler(this.ClickOnSelectUserActions);
            this.label10.MouseEnter += new System.EventHandler(this.panelUserAction_MouseEnter);
            this.label10.MouseLeave += new System.EventHandler(this.panelUserAction_MouseLeave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(52, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.ClickOnSelectUserActions);
            this.pictureBox5.MouseEnter += new System.EventHandler(this.panelUserAction_MouseEnter);
            this.pictureBox5.MouseLeave += new System.EventHandler(this.panelUserAction_MouseLeave);
            // 
            // panelLogs
            // 
            this.panelLogs.BackColor = System.Drawing.Color.Transparent;
            this.panelLogs.Controls.Add(this.label2);
            this.panelLogs.Controls.Add(this.pictureBox2);
            this.panelLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogs.Location = new System.Drawing.Point(0, 50);
            this.panelLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLogs.Name = "panelLogs";
            this.panelLogs.Size = new System.Drawing.Size(204, 50);
            this.panelLogs.TabIndex = 2;
            this.panelLogs.Click += new System.EventHandler(this.ClickOnSelectLogs);
            this.panelLogs.MouseEnter += new System.EventHandler(this.panelLogs_MouseEnter);
            this.panelLogs.MouseLeave += new System.EventHandler(this.panelLogs_MouseLeave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Location = new System.Drawing.Point(57, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Журнал системных\r\nопераций";
            this.label2.Click += new System.EventHandler(this.ClickOnSelectLogs);
            this.label2.MouseEnter += new System.EventHandler(this.panelLogs_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.panelLogs_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.ClickOnSelectLogs);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.panelLogs_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.panelLogs_MouseLeave);
            // 
            // panelUsers
            // 
            this.panelUsers.BackColor = System.Drawing.Color.Transparent;
            this.panelUsers.Controls.Add(this.label1);
            this.panelUsers.Controls.Add(this.pictureBox1);
            this.panelUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUsers.Location = new System.Drawing.Point(0, 0);
            this.panelUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(204, 50);
            this.panelUsers.TabIndex = 1;
            this.panelUsers.Click += new System.EventHandler(this.ClickOnSelectUsers);
            this.panelUsers.MouseEnter += new System.EventHandler(this.panelUsers_MouseEnter);
            this.panelUsers.MouseLeave += new System.EventHandler(this.panelUsers_MouseLeave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пользователи";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.ClickOnSelectUsers);
            this.label1.MouseEnter += new System.EventHandler(this.panelUsers_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.panelUsers_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ClickOnSelectUsers);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.panelUsers_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.panelUsers_MouseLeave);
            // 
            // ViewDataUsers
            // 
            this.ViewDataUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewDataUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewDataUsers.FullRowSelect = true;
            this.ViewDataUsers.GridLines = true;
            this.ViewDataUsers.HideSelection = false;
            this.ViewDataUsers.Location = new System.Drawing.Point(0, 0);
            this.ViewDataUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ViewDataUsers.MultiSelect = false;
            this.ViewDataUsers.Name = "ViewDataUsers";
            this.ViewDataUsers.Size = new System.Drawing.Size(354, 311);
            this.ViewDataUsers.TabIndex = 0;
            this.ViewDataUsers.UseCompatibleStateImageBehavior = false;
            this.ViewDataUsers.View = System.Windows.Forms.View.Details;
            this.ViewDataUsers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ViewDataUsers_ColumnClick);
            this.ViewDataUsers.SelectedIndexChanged += new System.EventHandler(this.listVData_SelectedIndexChanged);
            this.ViewDataUsers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listVData_MouseDown);
            // 
            // panelDataSelectedUser
            // 
            this.panelDataSelectedUser.BackColor = System.Drawing.Color.Transparent;
            this.panelDataSelectedUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDataSelectedUser.Controls.Add(this.btnSaveEdetedUser);
            this.panelDataSelectedUser.Controls.Add(this.tBoxFIO);
            this.panelDataSelectedUser.Controls.Add(this.pictureBox3);
            this.panelDataSelectedUser.Controls.Add(this.chBoxIsDeleteUser);
            this.panelDataSelectedUser.Controls.Add(this.pictureBox4);
            this.panelDataSelectedUser.Controls.Add(this.label3);
            this.panelDataSelectedUser.Controls.Add(this.tBoxLogin);
            this.panelDataSelectedUser.Controls.Add(this.cBoxUserGroup);
            this.panelDataSelectedUser.Controls.Add(this.label6);
            this.panelDataSelectedUser.Controls.Add(this.label4);
            this.panelDataSelectedUser.Controls.Add(this.pictureBox6);
            this.panelDataSelectedUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDataSelectedUser.Location = new System.Drawing.Point(354, 0);
            this.panelDataSelectedUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDataSelectedUser.Name = "panelDataSelectedUser";
            this.panelDataSelectedUser.Size = new System.Drawing.Size(311, 311);
            this.panelDataSelectedUser.TabIndex = 1;
            // 
            // btnSaveEdetedUser
            // 
            this.btnSaveEdetedUser.Location = new System.Drawing.Point(145, 170);
            this.btnSaveEdetedUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveEdetedUser.Name = "btnSaveEdetedUser";
            this.btnSaveEdetedUser.Size = new System.Drawing.Size(149, 25);
            this.btnSaveEdetedUser.TabIndex = 15;
            this.btnSaveEdetedUser.Text = "Сохранить";
            this.btnSaveEdetedUser.UseVisualStyleBackColor = true;
            this.btnSaveEdetedUser.Click += new System.EventHandler(this.btnSaveEdetedUser_Click);
            // 
            // tBoxFIO
            // 
            this.tBoxFIO.Location = new System.Drawing.Point(145, 20);
            this.tBoxFIO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxFIO.Name = "tBoxFIO";
            this.tBoxFIO.ReadOnly = true;
            this.tBoxFIO.Size = new System.Drawing.Size(151, 22);
            this.tBoxFIO.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(105, 7);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // chBoxIsDeleteUser
            // 
            this.chBoxIsDeleteUser.AutoSize = true;
            this.chBoxIsDeleteUser.Location = new System.Drawing.Point(145, 128);
            this.chBoxIsDeleteUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chBoxIsDeleteUser.Name = "chBoxIsDeleteUser";
            this.chBoxIsDeleteUser.Size = new System.Drawing.Size(127, 36);
            this.chBoxIsDeleteUser.TabIndex = 14;
            this.chBoxIsDeleteUser.Text = "Пользователь \r\nудален";
            this.chBoxIsDeleteUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chBoxIsDeleteUser.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(105, 48);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 34);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "ФИО:";
            // 
            // tBoxLogin
            // 
            this.tBoxLogin.Location = new System.Drawing.Point(145, 60);
            this.tBoxLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxLogin.Name = "tBoxLogin";
            this.tBoxLogin.ReadOnly = true;
            this.tBoxLogin.Size = new System.Drawing.Size(151, 22);
            this.tBoxLogin.TabIndex = 4;
            // 
            // cBoxUserGroup
            // 
            this.cBoxUserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUserGroup.DropDownWidth = 150;
            this.cBoxUserGroup.FormattingEnabled = true;
            this.cBoxUserGroup.Location = new System.Drawing.Point(145, 98);
            this.cBoxUserGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxUserGroup.Name = "cBoxUserGroup";
            this.cBoxUserGroup.Size = new System.Drawing.Size(151, 24);
            this.cBoxUserGroup.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Группа прав:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Логин:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(105, 89);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(33, 34);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            // 
            // ShowRunUsers
            // 
            this.ShowRunUsers.Controls.Add(this.splitter1);
            this.ShowRunUsers.Controls.Add(this.ViewDataUsers);
            this.ShowRunUsers.Controls.Add(this.panelDataSelectedUser);
            this.ShowRunUsers.Location = new System.Drawing.Point(224, 12);
            this.ShowRunUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowRunUsers.Name = "ShowRunUsers";
            this.ShowRunUsers.Size = new System.Drawing.Size(665, 311);
            this.ShowRunUsers.TabIndex = 3;
            this.ShowRunUsers.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(344, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 311);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // ShowRunLogs
            // 
            this.ShowRunLogs.Controls.Add(this.ViewLogs);
            this.ShowRunLogs.Controls.Add(this.tableLayoutPanel1);
            this.ShowRunLogs.Location = new System.Drawing.Point(911, 12);
            this.ShowRunLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowRunLogs.Name = "ShowRunLogs";
            this.ShowRunLogs.Size = new System.Drawing.Size(544, 311);
            this.ShowRunLogs.TabIndex = 4;
            this.ShowRunLogs.Visible = false;
            // 
            // ViewLogs
            // 
            this.ViewLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewLogs.FullRowSelect = true;
            this.ViewLogs.GridLines = true;
            this.ViewLogs.HideSelection = false;
            this.ViewLogs.Location = new System.Drawing.Point(0, 52);
            this.ViewLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ViewLogs.MultiSelect = false;
            this.ViewLogs.Name = "ViewLogs";
            this.ViewLogs.Size = new System.Drawing.Size(544, 259);
            this.ViewLogs.TabIndex = 0;
            this.ViewLogs.UseCompatibleStateImageBehavior = false;
            this.ViewLogs.View = System.Windows.Forms.View.Details;
            this.ViewLogs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ViewLogs_ColumnClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpStart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tBoxDescription, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpFinish, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cBoxLogTypes, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 52);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "С";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(1115, 13);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(161, 25);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStart.CustomFormat = "yyyy.MM.dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(38, 15);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(181, 22);
            this.dtpStart.TabIndex = 2;
            // 
            // tBoxDescription
            // 
            this.tBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxDescription.Location = new System.Drawing.Point(948, 15);
            this.tBoxDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxDescription.Name = "tBoxDescription";
            this.tBoxDescription.Size = new System.Drawing.Size(161, 22);
            this.tBoxDescription.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "по";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(781, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Сообщение:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFinish
            // 
            this.dtpFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFinish.CustomFormat = "yyyy.MM.dd HH:mm:ss";
            this.dtpFinish.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinish.Location = new System.Drawing.Point(260, 15);
            this.dtpFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFinish.Name = "dtpFinish";
            this.dtpFinish.Size = new System.Drawing.Size(181, 22);
            this.dtpFinish.TabIndex = 4;
            // 
            // cBoxLogTypes
            // 
            this.cBoxLogTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxLogTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxLogTypes.FormattingEnabled = true;
            this.cBoxLogTypes.Location = new System.Drawing.Point(614, 14);
            this.cBoxLogTypes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxLogTypes.Name = "cBoxLogTypes";
            this.cBoxLogTypes.Size = new System.Drawing.Size(161, 24);
            this.cBoxLogTypes.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Уровень события:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShowRunUserAction
            // 
            this.ShowRunUserAction.Controls.Add(this.ViewUserActions);
            this.ShowRunUserAction.Controls.Add(this.tableLayoutPanel2);
            this.ShowRunUserAction.Location = new System.Drawing.Point(568, 327);
            this.ShowRunUserAction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowRunUserAction.Name = "ShowRunUserAction";
            this.ShowRunUserAction.Size = new System.Drawing.Size(524, 167);
            this.ShowRunUserAction.TabIndex = 5;
            this.ShowRunUserAction.Visible = false;
            // 
            // ViewUserActions
            // 
            this.ViewUserActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewUserActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewUserActions.FullRowSelect = true;
            this.ViewUserActions.GridLines = true;
            this.ViewUserActions.HideSelection = false;
            this.ViewUserActions.Location = new System.Drawing.Point(0, 52);
            this.ViewUserActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ViewUserActions.MultiSelect = false;
            this.ViewUserActions.Name = "ViewUserActions";
            this.ViewUserActions.Size = new System.Drawing.Size(524, 115);
            this.ViewUserActions.TabIndex = 0;
            this.ViewUserActions.UseCompatibleStateImageBehavior = false;
            this.ViewUserActions.View = System.Windows.Forms.View.Details;
            this.ViewUserActions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ViewUserActions_ColumnClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearchActions, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpStartAction, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label13, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpFinishAction, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cBoxUserName, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label14, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.cBoxActionType, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(524, 52);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "С";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearchActions
            // 
            this.btnSearchActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchActions.Location = new System.Drawing.Point(1115, 13);
            this.btnSearchActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchActions.Name = "btnSearchActions";
            this.btnSearchActions.Size = new System.Drawing.Size(161, 25);
            this.btnSearchActions.TabIndex = 9;
            this.btnSearchActions.Text = "Поиск";
            this.btnSearchActions.UseVisualStyleBackColor = true;
            this.btnSearchActions.Click += new System.EventHandler(this.btnSearchActions_Click);
            // 
            // dtpStartAction
            // 
            this.dtpStartAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartAction.CustomFormat = "yyyy.MM.dd HH:mm:ss";
            this.dtpStartAction.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartAction.Location = new System.Drawing.Point(38, 15);
            this.dtpStartAction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartAction.Name = "dtpStartAction";
            this.dtpStartAction.Size = new System.Drawing.Size(181, 22);
            this.dtpStartAction.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(225, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "по";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(781, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(161, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "Тип операции:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFinishAction
            // 
            this.dtpFinishAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFinishAction.CustomFormat = "yyyy.MM.dd HH:mm:ss";
            this.dtpFinishAction.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinishAction.Location = new System.Drawing.Point(260, 15);
            this.dtpFinishAction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFinishAction.Name = "dtpFinishAction";
            this.dtpFinishAction.Size = new System.Drawing.Size(181, 22);
            this.dtpFinishAction.TabIndex = 4;
            // 
            // cBoxUserName
            // 
            this.cBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUserName.FormattingEnabled = true;
            this.cBoxUserName.Location = new System.Drawing.Point(614, 14);
            this.cBoxUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxUserName.Name = "cBoxUserName";
            this.cBoxUserName.Size = new System.Drawing.Size(161, 24);
            this.cBoxUserName.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(447, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(161, 16);
            this.label14.TabIndex = 5;
            this.label14.Text = "Пользователь:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cBoxActionType
            // 
            this.cBoxActionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxActionType.FormattingEnabled = true;
            this.cBoxActionType.Location = new System.Drawing.Point(948, 14);
            this.cBoxActionType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxActionType.Name = "cBoxActionType";
            this.cBoxActionType.Size = new System.Drawing.Size(161, 24);
            this.cBoxActionType.TabIndex = 6;
            // 
            // FormAdministrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 446);
            this.Controls.Add(this.ShowRunUserAction);
            this.Controls.Add(this.ShowRunLogs);
            this.Controls.Add(this.ShowRunUsers);
            this.Controls.Add(this.leftPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAdministrator";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администратор";
            this.Load += new System.EventHandler(this.FormAdministrator_Load);
            this.leftPanel.ResumeLayout(false);
            this.panelUserAction.ResumeLayout(false);
            this.panelUserAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panelLogs.ResumeLayout(false);
            this.panelLogs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDataSelectedUser.ResumeLayout(false);
            this.panelDataSelectedUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ShowRunUsers.ResumeLayout(false);
            this.ShowRunLogs.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ShowRunUserAction.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel panelLogs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView ViewDataUsers;
        private System.Windows.Forms.Panel panelDataSelectedUser;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox tBoxLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tBoxFIO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxUserGroup;
        private System.Windows.Forms.Button btnSaveEdetedUser;
        private System.Windows.Forms.CheckBox chBoxIsDeleteUser;
        private System.Windows.Forms.Panel ShowRunUsers;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel ShowRunLogs;
        private System.Windows.Forms.ListView ViewLogs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tBoxDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cBoxLogTypes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFinish;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelUserAction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel ShowRunUserAction;
        private System.Windows.Forms.ListView ViewUserActions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSearchActions;
        private System.Windows.Forms.DateTimePicker dtpStartAction;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpFinishAction;
        private System.Windows.Forms.ComboBox cBoxUserName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cBoxActionType;
    }
}