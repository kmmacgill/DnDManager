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
    public partial class References : Form
    {
        public References()
        {
            InitializeComponent();
        }

        private void References_Deactivate(object sender, EventArgs e)
        {
            Close();
        }
    }
}
