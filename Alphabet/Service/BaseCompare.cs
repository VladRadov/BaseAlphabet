using System.Collections;
using System.Windows.Forms;

namespace Alphabet.Service
{
    internal class BaseCompare : IComparer
    {
        private int _countColumn;

        private SortOrder _sortOrder;

        public BaseCompare(int countColumn, SortOrder sortOrder)
        {
            _countColumn = countColumn;
            _sortOrder = sortOrder;
        }

        public int Compare(object x, object y)
        {
            int result = -1;
            result = string.Compare(((ListViewItem)x).SubItems[_countColumn].Text, ((ListViewItem)y).SubItems[_countColumn].Text);

            if (_sortOrder == SortOrder.Descending)
                result *= -1;

            return result;
        }
    }
}
