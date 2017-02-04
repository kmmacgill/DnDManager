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
    public partial class ShortRestForm : Form
    {
        public ShortRestForm(int currentHealth, int maxHealth, int hitdice, string classType)
        {
            InitializeComponent();
            closeButton.DialogResult = DialogResult.OK;
            hitPointsMeter.Value = currentHealth;
            hitPointsMeter.Maximum = maxHealth;
            hitDiceScore.Text = hitdice.ToString();
            if (hitDiceScore.Text == "0")
            {
                spendHitDiceButton.Enabled = false;
                spendHitDiceButton.BackColor = Color.Gray;
            }
           
            switch (classType)
            {
                case "barbarian":
                    hitDieType.Text = "13";
                    break;
                case "fighter":
                case "paladin":
                case "Ranger":
                    hitDieType.Text = "11";
                    break;
                case "bard":
                case "cleric":
                case "druid":
                case "monk":
                case "rogue":
                case "warlock":
                    hitDieType.Text = "9";
                    break;
                default:
                    hitDieType.Text = "7";
                    break;
            }
        }

        public int[] getResults()
        {
            int[] results = { hitPointsMeter.Value, int.Parse(hitDiceScore.Text) };
            return results;
        }

        private void spendHitDiceButton_Click(object sender, EventArgs e)
        {
            if (hitDiceScore.Text != "0")
            {
                Random randy = new Random();
                int num = randy.Next(1, int.Parse(hitDieType.Text));
                if (hitPointsMeter.Value + num > hitPointsMeter.Maximum)
                {
                    hitPointsMeter.Value = hitPointsMeter.Maximum;
                }
                else
                {
                    hitPointsMeter.Value = hitPointsMeter.Value + num;
                }
                hitDiceScore.Text = (int.Parse(hitDiceScore.Text) - 1).ToString();
                if (hitDiceScore.Text == "0")
                {
                    spendHitDiceButton.Enabled = false;
                    spendHitDiceButton.BackColor = Color.Gray;
                }
            }
        }
    }
}
