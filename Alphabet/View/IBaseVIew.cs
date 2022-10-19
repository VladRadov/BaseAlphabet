using System.Windows.Forms;

namespace Alphabet.View
{
    internal interface IBaseVIew
    {
        void ShowMessageBox(string text, string title, MessageBoxButtons button, MessageBoxIcon icon);
    }
}
