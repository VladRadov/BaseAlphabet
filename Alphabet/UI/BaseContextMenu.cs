using System;
using System.Windows.Forms;

namespace Alphabet.UI
{
    internal class BaseContextMenu
    {
        private static ContextMenuStrip _contextMenu;

        public static ContextMenuStrip ShowContextMenu()
        {
            if (_contextMenu == null)
                CreateContextMenu();

            return _contextMenu;
        }

        private static void CreateContextMenu()
        {
            _contextMenu = new ContextMenuStrip();
            _contextMenu.Items.AddRange(new ToolStripItem[] { new AddUser() });
        }
    }

    class AddUser : ToolStripMenuItem
    {
        public AddUser()
        {
            Name = "Добавить пользователя";
            Text = "Добавить пользователя";
            Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            var formAddUser = new FormAddUser();
            formAddUser.Show();
        }
    }
}
