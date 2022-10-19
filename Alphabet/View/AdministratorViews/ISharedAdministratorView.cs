using System;

namespace Alphabet.View.AdministratorViews
{
    internal interface ISharedAdministratorView : IBaseVIew
    {
        event Action<ISharedAdministratorView> SelectAllUserGroupEventHandler;

        string ViewLogin { get; set; }

        string ViewUserGroup { get; set; }

        void ViewAllUserGroup(string[] allUserGroup);
    }
}
