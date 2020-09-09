using System.Windows.Forms;

namespace TurnoJueces
{
    internal class RowComparer : DataGridViewColumn
    {
        private SortOrder ascending;

        public RowComparer(SortOrder ascending)
        {
            this.ascending = ascending;
        }
    }
}