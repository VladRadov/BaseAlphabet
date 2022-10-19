using System;
using System.Windows.Forms;
using System.Drawing;

namespace Alphabet.View
{
    internal interface IUserSessionsView : IBaseVIew
    {
        event Action CloseUserSessionEventHandler;

        Control ParentGroundOfARMs { get; set; }

        Color OldColor { get; set; }

        void ViewSessionStatus(Image image, string nameGroup, Color colorBackground);

        void ChangeStateBaseButton(Color color);
    }
}
