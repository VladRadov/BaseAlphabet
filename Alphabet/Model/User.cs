namespace Alphabet.Model
{
    internal class User
    {
        public int UserID { get; set; }

        public string FIO { get; set; }

        public string Login { get; set; }

        public bool IsDeleted { get; set; }

        public BaseUsersGroup UserGroup { get; set; }
    }

    class NotFoundUser : User
    {
        public NotFoundUser()
        {
            UserGroup = new BaseUsersGroup() 
            { 
                Name = "", 
                Icon = Alphabet.Properties.Resources.User
            };
        }
    }

    class Admin
    {
        public static string Login = "1";

        public static string Password = "1";
    }
}
