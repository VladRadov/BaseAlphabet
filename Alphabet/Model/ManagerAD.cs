using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.Collections;

namespace Alphabet.Model
{
    class ManagerAD
    {
        private int _countDomains;

        private int _countUsers;

        public IEnumerable GetAllDomain()
        {
            try
            {
                Domain domain = Domain.GetDomain(new DirectoryContext(DirectoryContextType.Domain));
                Forest forest = domain.Forest;
                var domains = forest.Domains;
                _countDomains = domains.Count;
                return domains;
            }
            catch (Exception exception)
            {
                return new List<string>();
            }
        }

        public int CountDomains()
        {
            return _countDomains;
        }

        public IEnumerable GetAllUSersFromAD()
        {
            _countUsers = 0;
            List<User> usersAD = new List<User>();
            try
            {
                using (var contex = new PrincipalContext(ContextType.Domain))
                {
                    using (var searcher = new PrincipalSearcher(new UserPrincipal(contex)))
                    {
                        foreach (var result in searcher.FindAll())
                        {
                            DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                            usersAD.Add(new User()
                            {
                                FIO = de.Properties["name"].Value.ToString(),
                                Login = de.Properties["sAMAccountName"].Value.ToString()
                            });
                            ++_countUsers;
                        }
                    }
                }
            }
            catch(Exception exception)
            {

            }

            return usersAD;
        }

        public int CountUsersFromAD()
        {
            return _countUsers;
        }
    }
}
