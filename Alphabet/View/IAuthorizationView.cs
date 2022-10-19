using System;
using System.Drawing;

namespace Alphabet.View
{
    internal interface IAuthorizationView : IBaseVIew
    {
        event Action AuthorizationEventHandler;

        event Action LoadEventHandler;

        string Server { get; set; }

        string Login { get; set; }

        string Password { get; set; }

        string DomainNameView { get; set; }

        void UpdateComBoxDomains(string[] items);

        void SetColorChekingConnection(Color backColor);
    }
}
