using System.Collections.Generic;
using System.Drawing;

using Alphabet.Service;

namespace Alphabet.Model
{
    class ManagerUsersGroup
    {
        public static BaseUsersGroup FindUsersGroup(string nameGroup, List<ARM> arms)
        {
            switch (nameGroup)
            {
                case "Администраторы":
                    return new AdministratorsGroup() { Name = nameGroup, PermissionARMs = arms };
                case "Пользователи":
                    return new UsersGroup() { Name = nameGroup, PermissionARMs = arms };
                default:
                    return new BaseUsersGroup() { Name = nameGroup, PermissionARMs = arms };
            }
        }
    }

    class BaseUsersGroup
    {
        public BaseUsersGroup()
        {
            Icon = Alphabet.Properties.Resources.User;
        }

        public string Name { get; set; }

        public Image Icon { get; set; }

        public List<ARM> PermissionARMs { get; set; }
    }

    class AdministratorsGroup : BaseUsersGroup
    {
        public AdministratorsGroup()
        {
            Icon = Alphabet.Properties.Resources.Administrator;
        }
    }

    class UsersGroup : BaseUsersGroup
    {
        public UsersGroup()
        {
            Icon = Alphabet.Properties.Resources.User;
        }
    }
}
