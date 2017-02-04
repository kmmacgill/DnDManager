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
    public partial class incompleteFormPopup : Form
    {
        public incompleteFormPopup()
        {
            InitializeComponent();
        }

        private void understoodButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
