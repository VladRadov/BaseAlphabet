using System;
using System.Windows.Forms;

namespace Alphabet.View.AdministratorViews
{
    internal interface IAdministratorView : ISharedAdministratorView
    {
        event Action<ListView> ViewUsersEventHandler;

        event Action<string> SelectedUserEventHandler;

        event Action<ListView> EditUserEventHandler;

        event Action<ComboBox> ViewLogTypesEventHandler;

        event Action<ComboBox> ViewLoginsOfUsersActionsEventHandler;

        event Action<ComboBox> ViewUserActionTypesActionsEventHandler;

        event Action<ListView, DateTime, DateTime, string, string> ViewLogsEventHandler;

        event Action<ListView, DateTime, DateTime, string, string> ViewUserActionsEventHandler;

        string ViewFIO { get; set; }

        bool ViewIsDeleteed { get; set; }

        void ViewDataSelectedUser();

        void UpdateComboBox(ComboBox cBox, string[] rows);

        void UpdateListView(ListView listView, ColumnHeader[] columns, ListViewItem[] rows);
    }
}
