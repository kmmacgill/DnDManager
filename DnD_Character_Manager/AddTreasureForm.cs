using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD_Character_Manager
{
    public partial class AddTreasureForm : Form
    {
        public AddTreasureForm()
        {
            InitializeComponent();
            addButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
        }

        public ListViewItem addItemToTable()
        {
            string[] row = { textBox1.Text, numericUpDown1.Text, numericUpDown2.Text, numericUpDown3.Text };
            return new ListViewItem(row);
        }
    }
}
