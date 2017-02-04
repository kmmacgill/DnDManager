using System.Windows.Forms;

namespace DnD_Character_Manager
{
    public partial class AddItemForm : Form
    {
        public AddItemForm()
        {
            InitializeComponent();
            addButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
        }

        public ListViewItem addItemToTable()
        {
            string[] row = { textBox1.Text, numericUpDown1.Text, textBox2.Text, numericUpDown2.Text, numericUpDown3.Text };
            return new ListViewItem(row);
        }
    }
}
