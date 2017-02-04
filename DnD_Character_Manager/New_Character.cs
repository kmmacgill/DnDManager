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
    public partial class New_Character : Form
    {
        int skillSelectionLimit = 2;
        int skillsSelected = 0;
        public New_Character()
        {
            InitializeComponent();
        }

        private void Random_Name_Button_Click(object sender, EventArgs e)
        {
            character_Name.Text = new Name_Generator().generateName();
        }

        private void New_Character_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dnD_Character_ManagerDBDataSet.Backgrounds' table. You can move, or remove it, as needed.
            this.backgroundsTableAdapter.Fill(this.dnD_Character_ManagerDBDataSet.Backgrounds);
            // TODO: This line of code loads data into the 'dnD_Character_ManagerDBDataSet.Classes' table. You can move, or remove it, as needed.
            this.classesTableAdapter.Fill(this.dnD_Character_ManagerDBDataSet.Classes);
            // TODO: This line of code loads data into the 'dnD_Character_ManagerDBDataSet.Races' table. You can move, or remove it, as needed.
            this.racesTableAdapter.Fill(this.dnD_Character_ManagerDBDataSet.Races);

        }

        private void autoGenerateAbilityScoresButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<int> abScores = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                List<int> fourRands = new List<int>();
                //Generate 4 random numbers 1-6
                fourRands.Add(rnd.Next(1, 7));
                fourRands.Add(rnd.Next(1, 7));
                fourRands.Add(rnd.Next(1, 7));
                fourRands.Add(rnd.Next(1, 7));

                //remove the lowest like you would with dice
                int lowest = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (fourRands[lowest] > fourRands[j])
                    {
                        lowest = j;
                    }
                }
                fourRands.RemoveAt(lowest);

                //now add the rest up
                int total = 0;
                foreach (int item in fourRands)
                {
                    total += item;
                }
                abScores.Add(total);
            }
            //now add these values to the ability score windows in the form.
            Str_Score.Text = abScores[0].ToString();
            Con_Score.Text = abScores[1].ToString();
            Wis_Score.Text = abScores[2].ToString();
            Dex_Score.Text = abScores[3].ToString();
            Int_Score.Text = abScores[4].ToString();
            Cha_Score.Text = abScores[5].ToString();
        }
        public class Name_Generator
        {
            string[,] NAME_PARTS = new string[101, 3]
            {
            { "A", "bb", "a" },{"Ada","bl","ab"},{"Aki","bold","ac"},{"Al","br","ace"},
            {"Ali","bran","ach"},{"Alo","can","ad"},{"Ana","carr","adle"},{"Ani","ch","af"},
            {"Ba","cinn","ag"},{"Be","ck","ah"},{"Bo","ckl","ai"},{"Bra","ckr","ak"},
            {"Bro","cks","aker"},{"Cha","dd","al"},{"Chi","dell","ale"},{"Da","dr","am"},
            {"De","ds","an"},{"Do","fadd","and"},{"Dra","fall","ane"},{"Dro","farr","ar"},
            {"Eki","ff","ard"},{"Eko","fill","ark"},{"Ele","fl","art"},{"Eli","fr","ash"},
            {"Elo","genn","at"},{"Er","gg","ath"},{"Ere","gl","ave"},{"Eri","gord","ea"},
            {"Ero","gr","eb"},{"Fa","gs","ec"},{"Fe","h","ech"},{"Fi","hall","ed"},
            {"Fo","hark","ef"},{"Fra","hill","eh"},{"Gla","hork","ek"},{"Gro","jenn","el"},
            {"Ha","kell","elle"},{"He","kill","elton"},{"Hi","kk","em"},{"Illia","kl","en"},
            {"Ira","klip","end"},{"Ja","kr","ent"},{"Jo","krack","enton"},{"Ka","ladd","ep"},
            {"Kel","lah","eq"},
            {"Ki","land","er"},{"Kra","lark","esh"},{"La","ld","ess"},{"Le","ldr","ett"},
            {"Lo","lind","ic"},{"Ma","ll","ich"},{"Me","ln","id"},{"Mi","lord","if"},
            {"Mo","ls","ik"},{"Na","matt","il"},{"Ne","mend","im"},{"No","mm","in"},
            {"O","ms","ion"},{"Ol","nd","ir"},{"Or","nett","is"},{"Pa","ng","ish"},
            {"Pe","nk","it"},{"Pi","nn","ith"},{"Po","nodd","ive"},{"Pra","ns","ob"},
            {"Qua","nt","och"},{"Qui","part","od"},{"Quo","pelt","odin"},{"Ra","pl","oe"},
            {"Re","pp","of"},{"Ro","ppr","oh"},{"Sa","pps","ol"},{"Sca","rand","olen"},
            {"Sco","rd","omir"},{"Se","resh","or"},{"Sha","rn","orb"},{"She","rp","org"},
            {"Sho","rr","ort"},{"So","rush","os"},{"Sta","salk","osh"},{"Ste","sass","ot"},
            {"Sti","sc","oth"},{"Stu","sh","ottle"},{"Ta","sp","ove"},{"Tha","ss","ow"},
            {"The","st","ox"},{"Tho","tall","ud"},{"Ti","tend","ule"},{"To","told","umber"},
            {"Tra","v","un"},{"Tri","vall","under"},{"Tru","w","undle"},{"Ul","wall","unt"},
            {"Ur","wild","ur"},{"Va","will","us"},{"Vo","x","ust"},{"Wra","y","ut"},
            {"Xa","yang",""},{"Xi","yell",""},{"Zha","z",""},{"Zho","zenn",""},
            };
            public string generateName()
            {
                string theName = "";
                Random rand = new Random();
                int num1 = rand.Next(0, 100);
                int num2 = rand.Next(0, 100);
                int num3 = rand.Next(0, 100);
                theName =
                    NAME_PARTS[num1, 0] + NAME_PARTS[num2, 1] + NAME_PARTS[num3, 2];
                return theName;
            }
        }
    
        
        private void character_Race_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (character_Race.Text)
            {
                case "Hill Dwarf":
                    character_Age.Maximum = 400;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "Mountain Dwarf":
                    character_Age.Maximum = 400;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "High Elf":
                    character_Age.Maximum = 800;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "Wood Elf":
                    character_Age.Maximum = 800;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "Dark Elf":
                    character_Age.Maximum = 800;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "Lightfoot Halfling":
                    character_Age.Maximum = 250;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "Stout Halfling":
                    character_Age.Maximum = 250;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "Human":
                    character_Age.Maximum = 80;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "DragonBorn":
                    character_Age.Maximum = 95;
                    DragonHeritageSelect.Enabled = true;
                    DragonHeritageSelect.Visible = true;
                    DragonHeritageLabel.Visible = true;
                    break;
                case "Forest Gnome":
                    character_Age.Maximum = 450;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "Rock Gnome":
                    character_Age.Maximum = 450;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "Half Orc":
                    character_Age.Maximum = 75;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "Tiefling":
                    character_Age.Maximum = 100;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                case "Half Elf":
                    character_Age.Maximum = 200;
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    DragonHeritageLabel.Visible = false;
                    break;
                default:
                    DragonHeritageSelect.Enabled = false;
                    DragonHeritageSelect.Visible = false;
                    break;
            }
        }

        private void classSelectionTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (character_Class.Text)
            {
                case "Barbarian":
                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = false;
                    Options3.Visible = false;
                    Options4.Enabled = false;
                    Options4.Visible = false;
                    //add class specific options
                    Options1.Items.Add("GreatAxe");
                    Options1.Items.Add("Any martial melee weapon");
                    Options2.Items.Add("Two handaxes");
                    Options2.Items.Add("Any simple weapon");
                    
                    MandatoryItems.Text = "An explorer's pack and four javelins";

                    skillSelectionLimit = 2;

                    //Only show what's needed for the class
                    checkBoxAcrobatics.Enabled = false;
                    checkBoxAnimalHandling.Enabled = true;
                    checkBoxArcana.Enabled = false;
                    checkBoxAthletics.Enabled = true;
                    checkBoxDeception.Enabled = false;
                    checkBoxHistory.Enabled = false;
                    checkBoxInsight.Enabled = false;
                    checkBoxIntimidation.Enabled = true;
                    checkBoxInvestigation.Enabled = false;
                    checkBoxMedicine.Enabled = false;
                    checkBoxNature.Enabled = true;
                    checkBoxPerception.Enabled = true;
                    checkBoxPerformance.Enabled = false;
                    checkBoxPersuasion.Enabled = false;
                    checkBoxReligion.Enabled = false;
                    checkBoxSleightHand.Enabled = false;
                    checkBoxStealth.Enabled = false;
                    checkBoxSurvival.Enabled = true;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                case "Bard":

                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = true;
                    Options3.Visible = true;
                    Options4.Enabled = false;
                    Options4.Visible = false;
                    //add class specific options
                    Options1.Items.Add("Rapier");
                    Options1.Items.Add("Longsword");
                    Options1.Items.Add("Any simple weapon");
                    Options2.Items.Add("Diplomat's pack");
                    Options2.Items.Add("Entertainer's pack");
                    Options3.Items.Add("Lute");
                    Options3.Items.Add("Any other musical instrument");
                    
                    MandatoryItems.Text = "Leather armor and a dagger";

                    skillSelectionLimit = 3;

                    checkBoxAcrobatics.Enabled = true;
                    checkBoxAnimalHandling.Enabled = true;
                    checkBoxArcana.Enabled = true;
                    checkBoxAthletics.Enabled = true;
                    checkBoxDeception.Enabled = true;
                    checkBoxHistory.Enabled = true;
                    checkBoxInsight.Enabled = true;
                    checkBoxIntimidation.Enabled = true;
                    checkBoxInvestigation.Enabled = true;
                    checkBoxMedicine.Enabled = true;
                    checkBoxNature.Enabled = true;
                    checkBoxPerception.Enabled = true;
                    checkBoxPerformance.Enabled = true;
                    checkBoxPersuasion.Enabled = true;
                    checkBoxReligion.Enabled = true;
                    checkBoxSleightHand.Enabled = true;
                    checkBoxStealth.Enabled = true;
                    checkBoxSurvival.Enabled = true;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                case "Cleric":

                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = true;
                    Options3.Visible = true;
                    Options4.Enabled = true;
                    Options4.Visible = true;
                    //add class specific options
                    Options1.Items.Add("Mace");
                    Options1.Items.Add("Warmhammer(if proficient)");
                    Options2.Items.Add("Scale mail");
                    Options2.Items.Add("Leather armor");
                    Options2.Items.Add("Chain mail (if proficient)");
                    Options3.Items.Add("Light crossbow & 20 bolts");
                    Options3.Items.Add("Any simple weapon");
                    Options4.Items.Add("Priest's pack");
                    Options4.Items.Add("Explorer's pack");
                    
                    MandatoryItems.Text = "Shield and a holy symbol";

                    skillSelectionLimit = 2;

                    checkBoxAcrobatics.Enabled = false;
                    checkBoxAnimalHandling.Enabled = false;
                    checkBoxArcana.Enabled = false;
                    checkBoxAthletics.Enabled = false;
                    checkBoxDeception.Enabled = false;
                    checkBoxHistory.Enabled = true;
                    checkBoxInsight.Enabled = true;
                    checkBoxIntimidation.Enabled = false;
                    checkBoxInvestigation.Enabled = false;
                    checkBoxMedicine.Enabled = true;
                    checkBoxNature.Enabled = false;
                    checkBoxPerception.Enabled = false;
                    checkBoxPerformance.Enabled = false;
                    checkBoxPersuasion.Enabled = true;
                    checkBoxReligion.Enabled = true;
                    checkBoxSleightHand.Enabled = false;
                    checkBoxStealth.Enabled = false;
                    checkBoxSurvival.Enabled = false;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                case "Druid":

                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = false;
                    Options3.Visible = false;
                    Options4.Enabled = false;
                    Options4.Visible = false;
                    //add class specific options
                    Options1.Items.Add("Wooden shield");
                    Options1.Items.Add("Any simple weapon");
                    Options2.Items.Add("Scimitar");
                    Options2.Items.Add("Any simple melee weapon");

                    MandatoryItems.Text = "Leather armor, explorer's pack, a druidic focus";

                    skillSelectionLimit = 2;

                    checkBoxAcrobatics.Enabled = false;
                    checkBoxAnimalHandling.Enabled = true;
                    checkBoxArcana.Enabled = true;
                    checkBoxAthletics.Enabled = false;
                    checkBoxDeception.Enabled = false;
                    checkBoxHistory.Enabled = false;
                    checkBoxInsight.Enabled = true;
                    checkBoxIntimidation.Enabled = false;
                    checkBoxInvestigation.Enabled = false;
                    checkBoxMedicine.Enabled = true;
                    checkBoxNature.Enabled = true;
                    checkBoxPerception.Enabled = true;
                    checkBoxPerformance.Enabled = false;
                    checkBoxPersuasion.Enabled = false;
                    checkBoxReligion.Enabled = true;
                    checkBoxSleightHand.Enabled = false;
                    checkBoxStealth.Enabled = false;
                    checkBoxSurvival.Enabled = true;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                case "Fighter":

                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = true;
                    Options3.Visible = true;
                    Options4.Enabled = true;
                    Options4.Visible = true;
                    //add class specific options
                    Options1.Items.Add("Chain mail");
                    Options1.Items.Add("Leather armor, longbow, and 20 arrows");
                    Options2.Items.Add("Martial weapon and a shield");
                    Options2.Items.Add("Two martial weapons");
                    Options3.Items.Add("Light crossbow & 20 bolts");
                    Options3.Items.Add("Two handaxes");
                    Options4.Items.Add("Dungeoneer's pack");
                    Options4.Items.Add("Explorer's pack");

                    MandatoryItems.Text = "";

                    skillSelectionLimit = 2;

                    checkBoxAcrobatics.Enabled = true;
                    checkBoxAnimalHandling.Enabled = true;
                    checkBoxArcana.Enabled = false;
                    checkBoxAthletics.Enabled = true;
                    checkBoxDeception.Enabled = false;
                    checkBoxHistory.Enabled = true;
                    checkBoxInsight.Enabled = true;
                    checkBoxIntimidation.Enabled = true;
                    checkBoxInvestigation.Enabled = false;
                    checkBoxMedicine.Enabled = false;
                    checkBoxNature.Enabled = false;
                    checkBoxPerception.Enabled = true;
                    checkBoxPerformance.Enabled = false;
                    checkBoxPersuasion.Enabled = false;
                    checkBoxReligion.Enabled = false;
                    checkBoxSleightHand.Enabled = false;
                    checkBoxStealth.Enabled = false;
                    checkBoxSurvival.Enabled = true;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                case "Monk":

                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = false;
                    Options3.Visible = false;
                    Options4.Enabled = false;
                    Options4.Visible = false;
                    //add class specific options
                    Options1.Items.Add("Shortsword");
                    Options1.Items.Add("Any simple weapon");
                    Options2.Items.Add("Dungeoneer's pack");
                    Options2.Items.Add("Explorer's pack");

                    MandatoryItems.Text = "10 Darts";

                    skillSelectionLimit = 2;

                    checkBoxAcrobatics.Enabled = true;
                    checkBoxAnimalHandling.Enabled = false;
                    checkBoxArcana.Enabled = false;
                    checkBoxAthletics.Enabled = true;
                    checkBoxDeception.Enabled = false;
                    checkBoxHistory.Enabled = true;
                    checkBoxInsight.Enabled = true;
                    checkBoxIntimidation.Enabled = false;
                    checkBoxInvestigation.Enabled = false;
                    checkBoxMedicine.Enabled = false;
                    checkBoxNature.Enabled = false;
                    checkBoxPerception.Enabled = false;
                    checkBoxPerformance.Enabled = false;
                    checkBoxPersuasion.Enabled = false;
                    checkBoxReligion.Enabled = true;
                    checkBoxSleightHand.Enabled = false;
                    checkBoxStealth.Enabled = true;
                    checkBoxSurvival.Enabled = false;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                case "Paladin":

                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = true;
                    Options3.Visible = true;
                    Options4.Enabled = false;
                    Options4.Visible = false;
                    //add class specific options
                    Options1.Items.Add("Martial weapon and shield");
                    Options1.Items.Add("Two martial weapons");
                    Options2.Items.Add("Five javelins");
                    Options2.Items.Add("any simple melee weapon");
                    Options3.Items.Add("Priest's pack");
                    Options3.Items.Add("Explorer's pack");

                    MandatoryItems.Text = "Chain mail and a holy symbol";

                    skillSelectionLimit = 2;

                    checkBoxAcrobatics.Enabled = false;
                    checkBoxAnimalHandling.Enabled = false;
                    checkBoxArcana.Enabled = false;
                    checkBoxAthletics.Enabled = true;
                    checkBoxDeception.Enabled = false;
                    checkBoxHistory.Enabled = false;
                    checkBoxInsight.Enabled = true;
                    checkBoxIntimidation.Enabled = true;
                    checkBoxInvestigation.Enabled = false;
                    checkBoxMedicine.Enabled = true;
                    checkBoxNature.Enabled = false;
                    checkBoxPerception.Enabled = false;
                    checkBoxPerformance.Enabled = false;
                    checkBoxPersuasion.Enabled = true;
                    checkBoxReligion.Enabled = true;
                    checkBoxSleightHand.Enabled = false;
                    checkBoxStealth.Enabled = false;
                    checkBoxSurvival.Enabled = false;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                case "Ranger":

                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = true;
                    Options3.Visible = true;
                    Options4.Enabled = false;
                    Options4.Visible = false;
                    //add class specific options
                    Options1.Items.Add("Scale mail");
                    Options1.Items.Add("Leather armor");
                    Options2.Items.Add("Two shortswords");
                    Options2.Items.Add("Two simple melee weapons");
                    Options3.Items.Add("Dungeoneer's pack");
                    Options3.Items.Add("Explorer's pack");

                    MandatoryItems.Text = "Longbow and quiver of 20 arrows";

                    skillSelectionLimit = 3;

                    checkBoxAcrobatics.Enabled = false;
                    checkBoxAnimalHandling.Enabled = true;
                    checkBoxArcana.Enabled = false;
                    checkBoxAthletics.Enabled = true;
                    checkBoxDeception.Enabled = false;
                    checkBoxHistory.Enabled = false;
                    checkBoxInsight.Enabled = true;
                    checkBoxIntimidation.Enabled = false;
                    checkBoxInvestigation.Enabled = true;
                    checkBoxMedicine.Enabled = false;
                    checkBoxNature.Enabled = true;
                    checkBoxPerception.Enabled = true;
                    checkBoxPerformance.Enabled = false;
                    checkBoxPersuasion.Enabled = false;
                    checkBoxReligion.Enabled = false;
                    checkBoxSleightHand.Enabled = false;
                    checkBoxStealth.Enabled = true;
                    checkBoxSurvival.Enabled = true;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                case "Rogue":

                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = true;
                    Options3.Visible = true;
                    Options4.Enabled = false;
                    Options4.Visible = false;
                    //add class specific options
                    Options1.Items.Add("Rapier");
                    Options1.Items.Add("Shortsword");
                    Options2.Items.Add("Shortbow and 20 arrows");
                    Options2.Items.Add("Shortsword");
                    Options3.Items.Add("Burglar's pack");
                    Options3.Items.Add("Dungeoneer's pack");
                    Options3.Items.Add("Explorer's pack");

                    MandatoryItems.Text = "Leather armor, two daggers, thieves' tools";

                    skillSelectionLimit = 4;

                    checkBoxAcrobatics.Enabled = true;
                    checkBoxAnimalHandling.Enabled = false;
                    checkBoxArcana.Enabled = false;
                    checkBoxAthletics.Enabled = true;
                    checkBoxDeception.Enabled = true;
                    checkBoxHistory.Enabled = false;
                    checkBoxInsight.Enabled = true;
                    checkBoxIntimidation.Enabled = true;
                    checkBoxInvestigation.Enabled = true;
                    checkBoxMedicine.Enabled = false;
                    checkBoxNature.Enabled = false;
                    checkBoxPerception.Enabled = true;
                    checkBoxPerformance.Enabled = true;
                    checkBoxPersuasion.Enabled = true;
                    checkBoxReligion.Enabled = false;
                    checkBoxSleightHand.Enabled = true;
                    checkBoxStealth.Enabled = true;
                    checkBoxSurvival.Enabled = false;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                case "Sorcerer":

                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = true;
                    Options3.Visible = true;
                    Options4.Enabled = false;
                    Options4.Visible = false;
                    //add class specific options
                    Options1.Items.Add("Light crossbow and 20 bolts");
                    Options1.Items.Add("Any simple weapon");
                    Options2.Items.Add("Component pouch");
                    Options2.Items.Add("Arcane focus");
                    Options3.Items.Add("Dungeoneer's pack");
                    Options3.Items.Add("Explorer's pack");

                    MandatoryItems.Text = "Two daggers";

                    skillSelectionLimit = 2;

                    checkBoxAcrobatics.Enabled = false;
                    checkBoxAnimalHandling.Enabled = false;
                    checkBoxArcana.Enabled = true;
                    checkBoxAthletics.Enabled = false;
                    checkBoxDeception.Enabled = true;
                    checkBoxHistory.Enabled = false;
                    checkBoxInsight.Enabled = true;
                    checkBoxIntimidation.Enabled = true;
                    checkBoxInvestigation.Enabled = false;
                    checkBoxMedicine.Enabled = false;
                    checkBoxNature.Enabled = false;
                    checkBoxPerception.Enabled = false;
                    checkBoxPerformance.Enabled = false;
                    checkBoxPersuasion.Enabled = true;
                    checkBoxReligion.Enabled = true;
                    checkBoxSleightHand.Enabled = false;
                    checkBoxStealth.Enabled = false;
                    checkBoxSurvival.Enabled = false;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                case "Warlock":

                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = true;
                    Options3.Visible = true;
                    Options4.Enabled = false;
                    Options4.Visible = false;
                    //add class specific options
                    Options1.Items.Add("Light crossbow and 20 bolts");
                    Options1.Items.Add("Any simple weapon");
                    Options2.Items.Add("Component pouch");
                    Options2.Items.Add("Arcane focus");
                    Options3.Items.Add("Dungeoneer's pack");
                    Options3.Items.Add("Scholar's pack");

                    MandatoryItems.Text = "Leather armor, any simple weapon, two daggers";

                    skillSelectionLimit = 2;

                    checkBoxAcrobatics.Enabled = false;
                    checkBoxAnimalHandling.Enabled = false;
                    checkBoxArcana.Enabled = true;
                    checkBoxAthletics.Enabled = false;
                    checkBoxDeception.Enabled = true;
                    checkBoxHistory.Enabled = true;
                    checkBoxInsight.Enabled = false;
                    checkBoxIntimidation.Enabled = true;
                    checkBoxInvestigation.Enabled = true;
                    checkBoxMedicine.Enabled = false;
                    checkBoxNature.Enabled = true;
                    checkBoxPerception.Enabled = false;
                    checkBoxPerformance.Enabled = false;
                    checkBoxPersuasion.Enabled = false;
                    checkBoxReligion.Enabled = true;
                    checkBoxSleightHand.Enabled = false;
                    checkBoxStealth.Enabled = false;
                    checkBoxSurvival.Enabled = false;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                case "Wizard":

                    //clear old entries of equipment
                    Options1.Text = "";
                    Options2.Text = "";
                    Options3.Text = "";
                    Options4.Text = "";
                    Options1.Items.Clear();
                    Options2.Items.Clear();
                    Options3.Items.Clear();
                    Options4.Items.Clear();
                    Options1.Enabled = true;
                    Options1.Visible = true;
                    Options2.Enabled = true;
                    Options2.Visible = true;
                    Options3.Enabled = true;
                    Options3.Visible = true;
                    Options4.Enabled = false;
                    Options4.Visible = false;
                    //add class specific options
                    Options1.Items.Add("Quarterstaff");
                    Options1.Items.Add("Dagger");
                    Options2.Items.Add("Component pouch");
                    Options2.Items.Add("Arcane focus");
                    Options3.Items.Add("Scholar's pack");
                    Options3.Items.Add("Explorer's pack");

                    MandatoryItems.Text = "Spellbook";

                    skillSelectionLimit = 2;

                    checkBoxAcrobatics.Enabled = false;
                    checkBoxAnimalHandling.Enabled = false;
                    checkBoxArcana.Enabled = true;
                    checkBoxAthletics.Enabled = false;
                    checkBoxDeception.Enabled = false;
                    checkBoxHistory.Enabled = true;
                    checkBoxInsight.Enabled = true;
                    checkBoxIntimidation.Enabled = false;
                    checkBoxInvestigation.Enabled = true;
                    checkBoxMedicine.Enabled = true;
                    checkBoxNature.Enabled = false;
                    checkBoxPerception.Enabled = false;
                    checkBoxPerformance.Enabled = false;
                    checkBoxPersuasion.Enabled = false;
                    checkBoxReligion.Enabled = true;
                    checkBoxSleightHand.Enabled = false;
                    checkBoxStealth.Enabled = false;
                    checkBoxSurvival.Enabled = false;

                    //uncheck all the boxes from before
                    checkBoxAcrobatics.Checked = false;
                    checkBoxAnimalHandling.Checked = false;
                    checkBoxArcana.Checked = false;
                    checkBoxAthletics.Checked = false;
                    checkBoxDeception.Checked = false;
                    checkBoxHistory.Checked = false;
                    checkBoxInsight.Checked = false;
                    checkBoxIntimidation.Checked = false;
                    checkBoxInvestigation.Checked = false;
                    checkBoxMedicine.Checked = false;
                    checkBoxNature.Checked = false;
                    checkBoxPerception.Checked = false;
                    checkBoxPerformance.Checked = false;
                    checkBoxPersuasion.Checked = false;
                    checkBoxReligion.Checked = false;
                    checkBoxSleightHand.Checked = false;
                    checkBoxStealth.Checked = false;
                    checkBoxSurvival.Checked = false;
                    break;
                default:
                    break;
            }
        }

        private void checkBoxAcrobatics_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAcrobatics.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                { 
                    checkBoxAcrobatics.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxAthletics_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAthletics.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxAthletics.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxInvestigation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInvestigation.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxInvestigation.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxMedicine_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMedicine.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxMedicine.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxPersuasion_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPersuasion.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxPersuasion.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxStealth_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStealth.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxStealth.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxAnimalHandling_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAnimalHandling.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxAnimalHandling.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxDeception_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDeception.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxDeception.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxInsight_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInsight.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxInsight.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxNature_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNature.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxNature.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxPerception_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPerception.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxPerception.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxSleightHand_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSleightHand.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxSleightHand.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxArcana_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxArcana.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxArcana.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHistory.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxHistory.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxIntimidation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIntimidation.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxIntimidation.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxPerformance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPerformance.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxPerformance.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxReligion_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReligion.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxReligion.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void checkBoxSurvival_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSurvival.Checked == true)
            {
                skillsSelected++;
                if (skillsSelected > skillSelectionLimit)
                {
                    checkBoxSurvival.Checked = false;
                }
            }
            else
            {
                skillsSelected--;
            }
        }

        private void submitNewCharButton_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                buildCharacterNShoveitInDB();
                Character_Manager charman = new Character_Manager(character_Name.Text);
                charman.Show();
                Close();
            }
            else
            {
                var popupWarning = new incompleteFormPopup();
                popupWarning.Show(this);
            }
        }

        private void buildCharacterNShoveitInDB()
        {
            //do the ugly business of programmatically creating a character with all this information...
            racesBindingSource.EndEdit();
            classesBindingSource.EndEdit();
            backgroundsBindingSource.EndEdit();

            DnD_Character_ManagerDBDataSetTableAdapters.CharactersTableAdapter characterTableAdapter =
                new DnD_Character_ManagerDBDataSetTableAdapters.CharactersTableAdapter();
            DnD_Character_ManagerDBDataSetTableAdapters.Class_ProficienciesTableAdapter classProfsAdapter = 
                new DnD_Character_ManagerDBDataSetTableAdapters.Class_ProficienciesTableAdapter();
            DnD_Character_ManagerDBDataSetTableAdapters.RacesTableAdapter raceTableAdapter = 
                new DnD_Character_ManagerDBDataSetTableAdapters.RacesTableAdapter();

            //get some ability scores
            int strScore = Int32.Parse(Str_Score.Text);
            int dexScore = Int32.Parse(Dex_Score.Text);
            int conScore = Int32.Parse(Con_Score.Text);
            int intScore = Int32.Parse(Int_Score.Text);
            int wisScore = Int32.Parse(Wis_Score.Text);
            int chaScore = Int32.Parse(Cha_Score.Text);
            //get some ability modifiers
            int strMod = getModifier(strScore);
            int dexMod = getModifier(dexScore);
            int intMod = getModifier(intScore);
            int conMod = getModifier(conScore);
            int wisMod = getModifier(wisScore);
            int chaMod = getModifier(chaScore);
            //get some skill proficiencies
            string skillprofs = "";
            if (checkBoxAcrobatics.Checked)
                skillprofs += "Acrobatics, ";
            if (checkBoxAnimalHandling.Checked)
                skillprofs += "Animal handling, ";
            if (checkBoxArcana.Checked)
                skillprofs += "Arcana, ";
            if (checkBoxAthletics.Checked)
                skillprofs += "Athletics, ";
            if (checkBoxDeception.Checked)
                skillprofs += "Deception, ";
            if (checkBoxHistory.Checked)
                skillprofs += "History, ";
            if (checkBoxInsight.Checked)
                skillprofs += "Insight, ";
            if (checkBoxIntimidation.Checked)
                skillprofs += "Intimidation, ";
            if (checkBoxInvestigation.Checked)
                skillprofs += "Investigation, ";
            if (checkBoxMedicine.Checked)
                skillprofs += "Medicine, ";
            if (checkBoxNature.Checked)
                skillprofs += "Nature, ";
            if (checkBoxPerception.Checked)
                skillprofs += "Perception, ";
            if (checkBoxPerformance.Checked)
                skillprofs += "Performance, ";
            if (checkBoxPersuasion.Checked)
                skillprofs += "Persuasion, ";
            if (checkBoxReligion.Checked)
                skillprofs += "Religion, ";
            if (checkBoxSleightHand.Checked)
                skillprofs += "Sleight of Hand, ";
            if (checkBoxStealth.Checked)
                skillprofs += "Stealth, ";
            if (checkBoxSurvival.Checked)
                skillprofs += "Survival, ";

            //generate unique ID's for equipment and other things using Guid
            Guid g = Guid.NewGuid();
            string uniqueID = Convert.ToBase64String(g.ToByteArray());
            uniqueID = uniqueID.Replace("=", "");
            uniqueID = uniqueID.Replace("+", "");
            

            //get some proficiencies
            string classProfs = "";
            var rowsFromClassProfTable = classProfsAdapter.GetData().Rows;
            foreach (DataRow row in rowsFromClassProfTable)
            {
                var rowItems = row.ItemArray;
                if (rowItems[1].ToString() == character_Class.Text)
                {
                    classProfs = classProfs + rowItems[2].ToString() + ", ";
                }
            }

            string raceProfs = "";
            var rowsfromRaceTable = raceTableAdapter.GetData().Rows;
            foreach (DataRow row in rowsfromRaceTable)
            {
                var rowItems = row.ItemArray;
                if (rowItems[1].ToString() == character_Race.Text)
                {
                    raceProfs = raceProfs + rowItems[6].ToString() + ", ";
                }
            }

            // if they're dragonborn, grab the breath attack
            if (character_Race.Text == "DragonBorn")
            {
                switch (DragonHeritageSelect.Text)
                {
                    case "Black Dragon":
                        raceProfs = raceProfs + "Breath Weapon: Acid, Acid Resistance, ";
                        break;
                    case "Blue Dragon":
                        raceProfs = raceProfs + "Breath Weapon: Lightning, Lightning Resistance, ";
                        break;
                    case "Brass Dragon":
                        raceProfs = raceProfs + "Breath Weapon: Fire, Fire Resistance, ";
                        break;
                    case "Bronze Dragon":
                        raceProfs = raceProfs + "Breath Weapon: Lightning, Lightning Resistance, ";
                        break;
                    case "Copper Dragon":
                        raceProfs = raceProfs + "Breath Weapon: Acid, Acid Resistance, ";
                        break;
                    case "Gold Dragon":
                        raceProfs = raceProfs + "Breath Weapon: Fire, Fire Resistance, ";
                        break;
                    case "Green Dragon":
                        raceProfs = raceProfs + "Breath Weapon: Poison, Poison Resistance, ";
                        break;
                    case "Red Dragon":
                        raceProfs = raceProfs + "Breath Weapon: Fire, Fire Resistance, ";
                        break;
                    case "Silver Dragon":
                        raceProfs = raceProfs + "Breath Weapon: Cold, Cold Resistance, ";
                        break;
                    case "White Dragon":
                        raceProfs = raceProfs + "Breath Weapon: Cold, Cold Resistance, ";
                        break;
                    default:
                        break;
                }
            }

            //finally, update the table with the character.
            characterTableAdapter.Insert(character_Name.Text,
                character_Race.Text, character_Class.Text, 1, 0,
                Int32.Parse(classHitDieValue.Text) + conMod,
                Int32.Parse(classHitDieValue.Text) + conMod,
                1, 1, strScore, dexScore, intScore, conScore,
                chaScore, wisScore, classSavingThrow1.Text +
                ", " + classSavingThrow2.Text, skillprofs + 
                backgroundSkillProf1.Text + ", " +
                backgroundSkillProf2.Text + ", ",
                backgroundToolProfsValue.Text + raceProfs + classProfs,
                raceLanguageValue.Text + ", " +
                backgroundLanguageValue.Text, "", "", "", "",
                uniqueID, 0, 0, 0, 0, 0,
                character_Background.Text, "", "", "", "", "",
                "", int.Parse(raceSpeedValue.Text), 0);
        }

        private int getModifier(int value)
        {
            int modifier = 0;
            switch (value)
            {
                case 1:
                    modifier = -5;
                    break;
                case 2:
                    modifier = -4;
                    break;
                case 3:
                    modifier = -4;
                    break;
                case 4:
                    modifier = -3;
                    break;
                case 5:
                    modifier = -3;
                    break;
                case 6:
                    modifier = -2;
                    break;
                case 7:
                    modifier = -2;
                    break;
                case 8:
                    modifier = -1;
                    break;
                case 9:
                    modifier = -1;
                    break;
                case 10:
                    modifier = 0;
                    break;
                case 11:
                    modifier = 0;
                    break;
                case 12:
                    modifier = 1;
                    break;
                case 13:
                    modifier = 1;
                    break;
                case 14:
                    modifier = 2;
                    break;
                case 15:
                    modifier = 2;
                    break;
                case 16:
                    modifier = 3;
                    break;
                case 17:
                    modifier = 3;
                    break;
                case 18:
                    modifier = 4;
                    break;
                case 19:
                    modifier = 4;
                    break;
                case 20:
                    modifier = 5;
                    break;
                case 21:
                    modifier = 5;
                    break;
                case 22:
                    modifier = 6;
                    break;
                case 23:
                    modifier = 6;
                    break;
                case 24:
                    modifier = 7;
                    break;
                case 25:
                    modifier = 7;
                    break;
                case 26:
                    modifier = 7;
                    break;
                case 27:
                    modifier = 8;
                    break;
                case 28:
                    modifier = 8;
                    break;
                case 29:
                    modifier = 9;
                    break;
                case 30:
                    modifier = 10;
                    break;
                default:
                    break;
            }
            return modifier;
        }

        private bool ValidateInputs()
        {
            bool allInputRecieved = false;
            //first check if the main 4 things have been chosen.
            if (character_Name.Text != "" && character_Race.Text != "" &&
                character_Class.Text != "" && character_Background.Text != "")
            {
                //now make sure the skills have been chosen
                int skillsChosen = 0;
                if (checkBoxAcrobatics.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxAnimalHandling.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxArcana.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxAthletics.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxDeception.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxHistory.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxInsight.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxIntimidation.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxInvestigation.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxMedicine.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxNature.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxPerception.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxPerformance.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxPersuasion.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxReligion.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxSleightHand.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxStealth.Checked)
                {
                    skillsChosen++;
                }
                if (checkBoxSurvival.Checked)
                {
                    skillsChosen++;
                }
                if (skillsChosen == skillSelectionLimit)
                {
                    //now time to check ability scores were changed
                    if (Str_Score.Value == 8 && Dex_Score.Value == 8 && 
                        Int_Score.Value == 8 && Con_Score.Value == 8 && 
                        Wis_Score.Value == 8 && Cha_Score.Value == 8)
                    {
                        //won't change allinputrecieved to true...
                    }
                    else
                    {
                        //now lets check the equipment was chosen
                        if (Options1.Text != "")//first level
                        {
                            if (Options2.Enabled == true && Options2.Text != "")//second level
                            {
                                if (Options3.Enabled == true && Options3.Text != "")
                                {
                                    if (Options4.Enabled == true && Options4.Text != "")
                                    {
                                        allInputRecieved = true;
                                    }
                                    else if (Options4.Enabled == false)
                                    {
                                        allInputRecieved = true;
                                    }
                                }
                                else if (Options3.Enabled == false)
                                {
                                    allInputRecieved = true;
                                }
                            }
                            else if (Options2.Enabled == false)
                            {
                                allInputRecieved = true;
                            }
                        }
                    }
                }
            }
            return allInputRecieved;
        }

        private void Main_Menu_Button_Click_1(object sender, EventArgs e)
        {
            WarningForm form = new WarningForm();
            if (form.ShowDialog(this) == DialogResult.Yes)
            {
                Main_Menu mm = new Main_Menu();
                this.Close();
                mm.Show();
            }
            form.Close();
            form.Dispose();
        }
    }
}
