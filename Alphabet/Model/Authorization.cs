using System;
using System.DirectoryServices.AccountManagement;

namespace Alphabet.Model
{
    internal class Authorization
    {
        public string DomainName { get; set; }

        public bool IsEnterUserEqualWindowsUser(string userName)
        {
            return Environment.UserName == userName ? true : false;
        }

        public bool HasADEnterDataUser(string userName, string password)
        {
            var principalContext = new PrincipalContext(ContextType.Domain, DomainName);
            return principalContext.ValidateCredentials(userName, password);
        }

        public bool IsEnterLocalAdministrator(string userName, string password)
        {
            return userName == Admin.Login && password == Admin.Password ? true : false;
        }
    }
}
