namespace Alphabet
{
    partial class FormAddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddUser));
            this.panelAddUser = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.cBoxUserGroup = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cBoxLogin = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelAddUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAddUser
            // 
            this.panelAddUser.Controls.Add(this.button1);
            this.panelAddUser.Controls.Add(this.btnAddUser);
            this.panelAddUser.Controls.Add(this.cBoxUserGroup);
            this.panelAddUser.Controls.Add(this.label7);
            this.panelAddUser.Controls.Add(this.cBoxLogin);
            this.panelAddUser.Controls.Add(this.label5);
            this.panelAddUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAddUser.Location = new System.Drawing.Point(0, 0);
            this.panelAddUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelAddUser.Name = "panelAddUser";
            this.panelAddUser.Size = new System.Drawing.Size(304, 185);
            this.panelAddUser.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 57);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 25);
            this.button1.TabIndex = 18;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(133, 145);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(149, 25);
            this.btnAddUser.TabIndex = 17;
            this.btnAddUser.Text = "Добавить";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // cBoxUserGroup
            // 
            this.cBoxUserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUserGroup.DropDownWidth = 150;
            this.cBoxUserGroup.FormattingEnabled = true;
            this.cBoxUserGroup.Location = new System.Drawing.Point(133, 101);
            this.cBoxUserGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxUserGroup.Name = "cBoxUserGroup";
            this.cBoxUserGroup.Size = new System.Drawing.Size(151, 24);
            this.cBoxUserGroup.TabIndex = 16;
            this.cBoxUserGroup.DropDown += new System.EventHandler(this.cBoxUserGroup_DropDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Группа прав:";
            // 
            // cBoxLogin
            // 
            this.cBoxLogin.DropDownWidth = 150;
            this.cBoxLogin.FormattingEnabled = true;
            this.cBoxLogin.Location = new System.Drawing.Point(133, 12);
            this.cBoxLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxLogin.Name = "cBoxLogin";
            this.cBoxLogin.Size = new System.Drawing.Size(151, 24);
            this.cBoxLogin.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Учетная запись:";
            // 
            // FormAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 185);
            this.Controls.Add(this.panelAddUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(322, 232);
            this.MinimumSize = new System.Drawing.Size(322, 232);
            this.Name = "FormAddUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление пользователя";
            this.Load += new System.EventHandler(this.FormAddUser_Load);
            this.panelAddUser.ResumeLayout(false);
            this.panelAddUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAddUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ComboBox cBoxUserGroup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cBoxLogin;
        private System.Windows.Forms.Label label5;
    }
}