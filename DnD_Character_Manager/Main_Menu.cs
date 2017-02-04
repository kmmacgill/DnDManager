using System;
using System.Windows.Forms;

namespace DnD_Character_Manager
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void create_new_character_Click_1(object sender, EventArgs e)
        {
            New_Character newChar = new New_Character();
            this.Close();
            newChar.Show();
        }

        private void Load_Character_Click_1(object sender, EventArgs e)
        {
            Load_Character_Menu lcm = new Load_Character_Menu();
            this.Close();
            lcm.Show();
        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
            Application.Exit();
        }
    }
}
