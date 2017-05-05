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
    public partial class QuickReferences : Form
    {
        const String movement = "MOVEMENT (limited by movement speed) You can move at any time during your turn(before, after, or during actions)." +
            "\nMove Cost: 5ft per 5ft \nClimb Cost: 10ft per 5ft \nSwim Cost: 10ft per 5ft \nDrop prone Cost: 0ft \nCrawl Cost: 10ft per 5ft " +
            "\nStand up Cost: half movement speed \nHigh jump Cost: 5ft per 5ft \nLong jump Cost: 5ft per 5ft \nImprovise Any stunt not on this list " +
            "\nGrapple move Modifier: speed halved";
        const String actions = "ACTION (1/turn) You can also interact with one object or feature of the environment for free." +
            "\nAttack - Melee or ranged attack with your weapon or bare hands. \nCast a spell - Cast time of 1 action." +
            "\nDash - Double movement speed. \nDisengage - Prevent opportunity attacks (actively avoid them). \nDodge - Increase defenses(actively avoid attacks but stand your ground)." +
            "\nHelp - Grant an ally advantage on completing a task(must be done prior to their turn). \nHide - make a stealth check to attempt to hide." +
            "\nReady - Choose trigger and action, example: 'if enemy comes through doorway, i will shoot it with my shortbow'. " +
            "\nSearch - devote attention to finding something DM will provide details on any ability checks if necessary. \nUse Object - " +
            " Interact, use special abilities. \nUse class feature - Some features use actions see class description for more details." +
            "\nGrapple - Special melee attack, contest your strength against the targets to determine success. \nShove - Special melee attack, contest your strength against their dexterity to determine success." +
            "\nImprovise -Any action not on this list (be creative!)";
        const String bonusActs = "BONUS ACTION max. 1/turn \nYou can take a bonus action only when a special ability, spell, or feature states " +
            "that you can do something as a bonus action. \nOffhand Attack - Use with the Attack action \nCast a spell - Cast time of 1 bonus action " +
            "\nUse class feature - Some features use bonus actions";
        public QuickReferences()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            References referen = new References(movement);
            if (referen.ShowDialog(this) == DialogResult.OK)
            {
                //closes by itself when you click away
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            References referen = new References(actions);
            if (referen.ShowDialog(this) == DialogResult.OK)
            {
                //closes by itself when you click away
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            References referen = new References(bonusActs);
            if (referen.ShowDialog(this) == DialogResult.OK)
            {
                //closes by itself when you click away
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            References referen = new References(Reaction);
            if (referen.ShowDialog(this) == DialogResult.OK)
            {
                //closes by itself when you click away
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            References referen = new References(Conditions);
            if (referen.ShowDialog(this) == DialogResult.OK)
            {
                //closes by itself when you click away
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            References referen = new References(envEff);
            if (referen.ShowDialog(this) == DialogResult.OK)
            {
                //closes by itself when you click away
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            References referen = new References(Senses);
            if (referen.ShowDialog(this) == DialogResult.OK)
            {
                //closes by itself when you click away
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            References referen = new References(Illumination);
            if (referen.ShowDialog(this) == DialogResult.OK)
            {
                //closes by itself when you click away
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            References referen = new References(Obstacles);
            if (referen.ShowDialog(this) == DialogResult.OK)
            {
                //closes by itself when you click away
            }
        }
    }
}
