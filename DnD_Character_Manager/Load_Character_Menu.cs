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
    public partial class Load_Character_Menu : Form
    {
        public Load_Character_Menu()
        {
            InitializeComponent();
            DnD_Character_ManagerDBDataSetTableAdapters.CharactersTableAdapter characterTableAdapter =
                new DnD_Character_ManagerDBDataSetTableAdapters.CharactersTableAdapter();
            var rowsFromCharTable = characterTableAdapter.GetData().Rows;
            foreach (DataRow row in rowsFromCharTable)
            {
                var rowItems = row.ItemArray;
                string[] entry = { rowItems[1].ToString(), rowItems[4].ToString() };
                ListViewItem entryItem = new ListViewItem(entry);
                charactersList.Items.Add(entryItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (charactersList.SelectedItems.Count == 1)
            {
                string characterName = charactersList.SelectedItems[0].Text;
                Character_Manager charman = new Character_Manager(characterName);
                charman.Show();
                Close();
                Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main_Menu mm = new Main_Menu();
            this.Close();
            mm.Show();
        }
    }
}
