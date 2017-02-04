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
    public partial class AddXpForm : Form
    {
        public AddXpForm()
        {
            InitializeComponent();
            addButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
        }

        public int getAmount()
        {
            return decimal.ToInt32(amountBox.Value);
        }
    }
}
