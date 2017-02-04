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
    public partial class WarningForm : Form
    {
        public WarningForm()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.No;
            button2.DialogResult = DialogResult.Yes;
        }
    }
}
