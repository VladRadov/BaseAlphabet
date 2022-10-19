using Alphabet.Service;

namespace Alphabet.Model
{
    internal class UserSessions
    {
        private static UserSessions _instance;

        private UserSessions()
        { }

        public User User { get; set; }

        public bool IsOpen { get; set; }

        public ARM CurrentArm { get; set; }

        public static UserSessions Instance { get { if (_instance == null) _instance = new UserSessions(); return _instance; } private set { _instance = value; } }
    }
}
