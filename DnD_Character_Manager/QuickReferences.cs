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
        const string Obstacles = "Obstacles can provide cover during combat, making a target more difficult to harm.\nHalf cover\nLow wall, furniture\n\nThree-quarters cover\nPortcullis, arrow slin\n\nFull cover\nCompletely concealed\n\nDifficult terrain\nCost modifier: +5ft per 5ft";
        const string Senses = "Some creatures have extraordinary senses that allow them to perceive their environment.\nBlindsight\nPerceive without sight\n\nDarkvision\nLimited vision in darkness\n\nTruesight\nSee in darkness";
        const string Illumination = "The presence or absence of light in an environment creates three categories of illumination.\nBright light\nNormal vision\n\nDim light\nLightly obscured\n\nDarkness\nHeavily obscured\n";
        const string envEff = "Effects that obscure vision can prove a significant hindrance to most adventuring tasks.\n\nLightly obscured\nDisadvantage on Perception\n\nHeavily obscured\nEffectively blind";
        const string Conditions = "Conditions alter your capabilities in a variety of ways, and can arise as a result of a spell, a class feature, a monster's attack, or other effect.\n\nBlinded\nYou can't see, disadvantage on anything that needs sight.\n\nCharmed\nYou are charmed, susceptible to influence.\n\nDeafened\nYou can't hear, disadvantage on anything that requires hearing.\n\nExhaustion\nYou are exhausted in one or more levels and will suffer the consequences accordingly (ask your DM).\n\nFrightened\nYou are frightened, must use your movement to move away from the one you are frightened of.\n\nGrappled\nYou are grappled and must try to free yourself prior to movement.\n\nIncapacitated\nYou can't take actions or reactions.\nInvisible\nYou can't be seen, have advantage on those who don't see you.\n\nParalyzed\nYou are paralyzed\n\nPetrified\nYou are transformed into stone, don't break!\n\nPoisoned\nYou are poisoned and must keep track of poison counters.\nProne\nYou are prone, disadvantage against those who aren't.\n\nRestrained\nYou are restrained.\n\nStunned\nYou are stunned.\n\nUnconscious\nYou are unconscious, damage against you leads to death.";
        const string Reaction = "A reaction is an instant response to a trigger of some kind, which can occur on your turn or on someone else's.\n\nOpportunity attack\nEnemy leaves your reach\n\nReadied action\nPart of your Ready action\n\nCast a spell\nCast time of 1 reaction";
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
