using System;

namespace Alphabet.View.AdministratorViews
{
    internal interface IAddUserView : ISharedAdministratorView
    {
        event Action AddUserEventHandler;

        event Action ViewAllUsersFromadEventHandler;

        void ViewAllUsersFromAD(string[] allUser);
    }
}
