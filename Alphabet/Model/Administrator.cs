using System.Collections;
using System.Collections.Generic;

namespace Alphabet.Model
{
    internal class Administrator
    {
        private List<User> _users;

        public Administrator()
        {
            _users = new List<User>();
        }

        public void ClearAllUsers()
        {
            _users.Clear();
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public IEnumerable GetUsers()
        {
            return _users;
        }

        public User FindUser(string login)
        {
            return _users.Find(e => e.Login == login);
        }
    }
}
