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
    public partial class HealthForm : Form
    {
        public HealthForm()
        {
            InitializeComponent();
            addButton.DialogResult = DialogResult.Yes;
            removeButton.DialogResult = DialogResult.No;
            cancelButton.DialogResult = DialogResult.Abort;
        }

        public int getAmount()
        {
            int amount = Decimal.ToInt32(amountValue.Value);
            return amount;
        }
    }
}
