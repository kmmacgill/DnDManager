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
    public partial class MoneyManagerForm : Form
    {
        public MoneyManagerForm()
        {
            InitializeComponent();
            addButton.DialogResult = DialogResult.OK;
            removeButton.DialogResult = DialogResult.No;
            cancelButton.DialogResult = DialogResult.Cancel;
        }

        public int[] getAmounts()
        {
            int[] amounts = { decimal.ToInt32(numericUpDown1.Value), decimal.ToInt32(numericUpDown2.Value), decimal.ToInt32(numericUpDown3.Value), decimal.ToInt32(numericUpDown4.Value), decimal.ToInt32(numericUpDown5.Value) };
            return amounts;
        }
    }
}
