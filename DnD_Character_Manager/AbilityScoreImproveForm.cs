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
    public partial class AbilityScoreImproveForm : Form
    {
        public AbilityScoreImproveForm(string strength, string dex, string intel, string con, string wis, string charisma)
        {
            InitializeComponent();
            doneButton.DialogResult = DialogResult.OK;
            label1.Text = strength;
            label2.Text = dex;
            label3.Text = intel;
            label4.Text = con;
            label5.Text = wis;
            label6.Text = charisma;

            //for checking stuff
            label7.Text = strength;
            label8.Text = dex;
            label9.Text = intel;
            label10.Text = con;
            label11.Text = wis;
            label12.Text = charisma;
        }

        public string[] getResults()
        {
            string[] scores = { label1.Text, label2.Text, label3.Text, label4.Text, label5.Text, label6.Text };
            return scores;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) > 0 && label1.Text != "20")
            {
                label1.Text = (int.Parse(label1.Text) + 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) - 1).ToString();
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) < 2 && label1.Text != label7.Text)
            {
                label1.Text = (int.Parse(label1.Text) - 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) + 1).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) > 0 && label2.Text != "20")
            {
                label2.Text = (int.Parse(label2.Text) + 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) - 1).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) < 2 && label2.Text != label8.Text)
            {
                label2.Text = (int.Parse(label2.Text) - 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) + 1).ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) > 0 && label3.Text != "20")
            {
                label3.Text = (int.Parse(label3.Text) + 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) - 1).ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) < 2 && label3.Text != label9.Text)
            {
                label3.Text = (int.Parse(label3.Text) - 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) + 1).ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) > 0 && label4.Text != "20")
            {
                label4.Text = (int.Parse(label4.Text) + 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) - 1).ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) < 2 && label4.Text != label10.Text)
            {
                label4.Text = (int.Parse(label4.Text) - 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) + 1).ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) > 0 && label5.Text != "20")
            {
                label5.Text = (int.Parse(label5.Text) + 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) - 1).ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) < 2 && label5.Text != label11.Text)
            {
                label5.Text = (int.Parse(label5.Text) - 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) + 1).ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) > 0 && label6.Text != "20")
            {
                label6.Text = (int.Parse(label6.Text) + 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) - 1).ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (int.Parse(pointsLeft.Text) < 2 && label6.Text != label12.Text)
            {
                label6.Text = (int.Parse(label6.Text) - 1).ToString();
                pointsLeft.Text = (int.Parse(pointsLeft.Text) + 1).ToString();
            }
        }
    }
}
