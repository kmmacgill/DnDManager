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
    public partial class Character_Manager : Form
    {
        public Character_Manager(string charName)
        {
            InitializeComponent();
            DnD_Character_ManagerDBDataSetTableAdapters.CharactersTableAdapter characterTableAdapter =
                new DnD_Character_ManagerDBDataSetTableAdapters.CharactersTableAdapter();
            var rowsFromCharTable = characterTableAdapter.GetData().Rows;
            foreach (DataRow row in rowsFromCharTable)
            {
                var rowItems = row.ItemArray;
                if (charName == rowItems[1].ToString())
                {
                    //1st panel
                    char_Name.Text = charName;
                    char_Race.Text = rowItems[2].ToString();
                    char_Class.Text = rowItems[3].ToString();
                    currentLevelValue.Text = rowItems[4].ToString();
                    profBonusScore.Text = getProfBonus(currentLevelValue.Text);
                    int profBon = int.Parse(profBonusScore.Text.Replace("+", ""));
                    nowXpValue.Text = rowItems[5].ToString();
                    nextXpValue.Text = determineNextLevelXp(currentLevelValue.Text);
                    hitPointsMeter.Maximum = int.Parse(rowItems[6].ToString());
                    hitPointsMeter.Value = int.Parse(rowItems[7].ToString());
                    hitDiceScore.Text = rowItems[9].ToString();
                    unchangingHitDice.Text = currentLevelValue.Text;
                    StrengthScore.Text = rowItems[10].ToString();
                    DexterityScore.Text = rowItems[11].ToString();
                    IntelligenceScore.Text = rowItems[12].ToString();
                    ConstitutionScore.Text = rowItems[13].ToString();
                    CharismaScore.Text = rowItems[14].ToString();
                    WisdomScore.Text = rowItems[15].ToString();
                    permanentAbilitySaves.Text = rowItems[16].ToString();
                    string abilitySaves = rowItems[16].ToString();
                    string skillprofs = rowItems[17].ToString();
                    HiddenskillProficiencies.Text = rowItems[17].ToString();
                    calculateModsSavesSkills(abilitySaves, skillprofs, profBon);
                    proficienciesTextBox.Text = rowItems[18].ToString();
                    languagesTextBox.Text = rowItems[19].ToString();
                    gatherRacialTraitsNAbilities();

                    //2nd panel
                    LHandEquip.Text = rowItems[20].ToString();
                    RHandEquip.Text = rowItems[21].ToString();
                    armorEquip.Text = rowItems[22].ToString();
                    otherEquippedTextBox.Text = rowItems[23].ToString();
                    speedScore.Text = rowItems[37].ToString();
                    unchangingSpeedScore.Text = speedScore.Text;
                    kiPointsValue.Text = rowItems[38].ToString();
                    unchangingKiPoints.Text = kiPointsValue.Text;
                    armorClassValue.Text = determineArmorClass();
                    remainingActionsScore.Text = determineActions();
                    remainingBonusScore.Text = determineBonusActions();
                    //3rd panel
                    determineSpellInfo(profBon);
                    determineSpells(rowItems[24].ToString());
                    determineSpellSlots();

                    //4th panel
                    characterUniqueID.Text = rowItems[24].ToString();
                    determineInventory(rowItems[24].ToString());
                    copperValue.Text = rowItems[25].ToString();
                    silverValue.Text = rowItems[26].ToString();
                    electrumValue.Text = rowItems[27].ToString();
                    goldValue.Text = rowItems[28].ToString();
                    platinumValue.Text = rowItems[29].ToString();
                    totalMoneyValue.Text = getMoneyTotal(int.Parse(copperValue.Text) + int.Parse(silverValue.Text) + int.Parse(electrumValue.Text) + int.Parse(goldValue.Text) + int.Parse(platinumValue.Text));

                    //5th panel
                    backgroundValue.Text = rowItems[30].ToString();
                    backgroundFeatureValue.Text = determineBackgroundFeature(backgroundValue.Text);
                    backstoryBox.Text = rowItems[31].ToString();
                    alliesNOrgBox.Text = rowItems[32].ToString();
                    traitsBox.Text = rowItems[33].ToString();
                    idealsBox.Text = rowItems[34].ToString();
                    bondsBox.Text = rowItems[35].ToString();
                    flawsBox.Text = rowItems[36].ToString();
                    determineClassTraits();
                }
            }
        }

        private string determineActions()
        {
            int actions = 1;
            if (ClassTraits.Text.ToLower().Contains("action surge"))
            {
                actions++;
            }

            return actions.ToString();
        }

        private string determineBonusActions()
        {
            int bonusActions = 1;
            if (ClassTraits.Text.ToLower().Contains("rage"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("frenzy"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("bardic inspiration"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("master of nature"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("war priest"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("channel divinity: invoke duplicity"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("improved duplicity"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("combat wild shape"))
            {
                bonusActions++;
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("second wind"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("action surge"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("Maneuvers"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("eldritch knight"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("martial arts"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("vanish"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("exceptional training"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("cunning action"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("versatile trickster"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("flexible casting"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("dragon wings"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("illusory reality"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("charger"))
            {
                bonusActions++;
            }
            if (ClassTraits.Text.ToLower().Contains("crossbow expert"))
            {
                bonusActions++;
            }

            return bonusActions.ToString();
        }

        private string determineBackgroundFeature(string text)
        {
            switch (text)
            {
                case "Acolyte":
                    return "Shelfter of the Faithful";
                case "Charlatan":
                    return "False Identity";
                case "Criminal":
                    return "Criminal Contact";
                case "Entertainer":
                    return "By Popular Demand";
                case "Folk Hero":
                    return "Rustic Hospitality";
                case "Guild Artisan":
                    return "Guild Membership";
                case "Hermit":
                    return "Discovery";
                case "Noble":
                    return "Position of Privilege";
                case "Outlander":
                    return "Wanderer";
                case "Sage":
                    return "Researcher";
                case "Sailor":
                    return "Ship's Passage";
                case "Soldier":
                    return "Military Rank";
                case "Urchin":
                    return "City Secrets";
                case "":
                    return "";
                default:
                    return "ERROR";
            }
        }

        private void determineInventory(string uniqueID)
        {
            DnD_Character_ManagerDBDataSetTableAdapters.weaponsNArmorTableTableAdapter weaponsTableAdapter =
                new DnD_Character_ManagerDBDataSetTableAdapters.weaponsNArmorTableTableAdapter();
            DnD_Character_ManagerDBDataSetTableAdapters.equipmentTableTableAdapter equipAdapter =
                new DnD_Character_ManagerDBDataSetTableAdapters.equipmentTableTableAdapter();
            DnD_Character_ManagerDBDataSetTableAdapters.TreasureTableTableAdapter treasureAdapter =
                new DnD_Character_ManagerDBDataSetTableAdapters.TreasureTableTableAdapter();

            var weapons = weaponsTableAdapter.GetData().Rows;
            foreach (DataRow row in weapons)
            {
                var rowItems = row.ItemArray;
                if (rowItems[1].ToString() == uniqueID)
                {
                    //add it to their spells table 2 = name 3 = level 4 = description
                    string[] weaponEntry = { rowItems[2].ToString(), rowItems[3].ToString(), rowItems[4].ToString(), rowItems[5].ToString(), rowItems[6].ToString() };
                    var weaponToAdd = new ListViewItem(weaponEntry);
                    weaponsNArmorListview.Items.Add(weaponToAdd);
                }
            }

            var equipment = equipAdapter.GetData().Rows;
            foreach (DataRow row in equipment)
            {
                var rowItems = row.ItemArray;
                if (rowItems[1].ToString() == uniqueID)
                {
                    //add it to their spells table 2 = name 3 = level 4 = description
                    string[] itemEntry = { rowItems[2].ToString(), rowItems[3].ToString(), rowItems[4].ToString(), rowItems[5].ToString(), rowItems[6].ToString() };
                    var itemToAdd = new ListViewItem(itemEntry);
                    equipmentNGearList.Items.Add(itemToAdd);
                }
            }

            var treasure = treasureAdapter.GetData().Rows;
            foreach (DataRow row in treasure)
            {
                var rowItems = row.ItemArray;
                if (rowItems[1].ToString() == uniqueID)
                {
                    //add it to their spells table 2 = name 3 = level 4 = description
                    string[] itemEntry = { rowItems[2].ToString(), rowItems[3].ToString(), rowItems[4].ToString(), rowItems[5].ToString() };
                    var itemToAdd = new ListViewItem(itemEntry);
                    treasureList.Items.Add(itemToAdd);
                }
            }
        }

        private void determineSpellSlots()
        {
            switch (char_Class.Text)
            {
                case "Barbarian":
                    spellList.Enabled = false;
                    addSpellButton.Enabled = false;
                    removeSpellButton.Enabled = false;
                    level1Choose.Enabled = false;
                    level2Choose.Enabled = false;
                    level3Choose.Enabled = false;
                    level4Choose.Enabled = false;
                    level5Choose.Enabled = false;
                    level6Choose.Enabled = false;
                    level7Choose.Enabled = false;
                    level8Choose.Enabled = false;
                    level9Choose.Enabled = false;
                    break;
                case "Bard":
                    switch (currentLevelValue.Text)
                    {
                        case "1":
                            cantripsValue.Text = "2";
                            level1LeftScore.Text = "2";
                            break;
                        case "2":
                            cantripsValue.Text = "2";
                            level1LeftScore.Text = "3";
                            break;
                        case "3":
                            cantripsValue.Text = "2";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "2";
                            break;
                        case "4":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            break;
                        case "5":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "2";
                            break;
                        case "6":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            break;
                        case "7":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "1";
                            break;
                        case "8":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "2";
                            break;
                        case "9":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "1";
                            break;
                        case "10":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            break;
                        case "11":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            break;
                        case "12":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            break;
                        case "13":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "14":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "15":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "16":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "17":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "18":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "19":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "2";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "20":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "2";
                            level7LeftScore.Text = "2";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        default:
                            break;
                    }
                    break;
                case "Cleric":
                    switch (currentLevelValue.Text)
                    {
                        case "1":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "2";
                            break;
                        case "2":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "3";
                            break;
                        case "3":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "2";
                            break;
                        case "4":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            break;
                        case "5":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "2";
                            break;
                        case "6":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            break;
                        case "7":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "1";
                            break;
                        case "8":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "2";
                            break;
                        case "9":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "1";
                            break;
                        case "10":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            break;
                        case "11":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            break;
                        case "12":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            break;
                        case "13":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "14":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "15":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "16":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "17":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "18":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "19":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "2";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "20":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "2";
                            level7LeftScore.Text = "2";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        default:
                            break;
                    }
                    break;
                case "Druid":
                    switch (currentLevelValue.Text)
                    {
                        case "1":
                            cantripsValue.Text = "2";
                            level1LeftScore.Text = "2";
                            break;
                        case "2":
                            cantripsValue.Text = "2";
                            level1LeftScore.Text = "3";
                            break;
                        case "3":
                            cantripsValue.Text = "2";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "2";
                            break;
                        case "4":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            break;
                        case "5":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "2";
                            break;
                        case "6":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            break;
                        case "7":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "1";
                            break;
                        case "8":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "2";
                            break;
                        case "9":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "1";
                            break;
                        case "10":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            break;
                        case "11":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            break;
                        case "12":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            break;
                        case "13":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "14":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "15":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "16":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "17":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "18":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "19":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "2";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "20":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "2";
                            level7LeftScore.Text = "2";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        default:
                            break;
                    }
                    break;
                case "Fighter":
                    if (ClassTraits.Text.Contains("Eldritch Knight"))
                    {
                        switch (currentLevelValue.Text)
                        {
                            case "1":
                                spellList.Enabled = false;
                                addSpellButton.Enabled = false;
                                removeSpellButton.Enabled = false;
                                level1Choose.Enabled = false;
                                level2Choose.Enabled = false;
                                level3Choose.Enabled = false;
                                level4Choose.Enabled = false;
                                level5Choose.Enabled = false;
                                level6Choose.Enabled = false;
                                level7Choose.Enabled = false;
                                level8Choose.Enabled = false;
                                level9Choose.Enabled = false;
                                break;
                            case "2":
                                spellList.Enabled = false;
                                addSpellButton.Enabled = false;
                                removeSpellButton.Enabled = false;
                                level1Choose.Enabled = false;
                                level2Choose.Enabled = false;
                                level3Choose.Enabled = false;
                                level4Choose.Enabled = false;
                                level5Choose.Enabled = false;
                                level6Choose.Enabled = false;
                                level7Choose.Enabled = false;
                                level8Choose.Enabled = false;
                                level9Choose.Enabled = false;
                                break;
                            case "3":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "2";
                                level1LeftScore.Text = "2";
                                break;
                            case "4":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "2";
                                level1LeftScore.Text = "3";
                                break;
                            case "5":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "2";
                                level1LeftScore.Text = "3";
                                break;
                            case "6":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "2";
                                level1LeftScore.Text = "3";
                                break;
                            case "7":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "2";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "2";
                                break;
                            case "8":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "2";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "2";
                                break;
                            case "9":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "2";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "2";
                                break;
                            case "10":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                break;
                            case "11":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                break;
                            case "12":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                break;
                            case "13":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "2";
                                break;
                            case "14":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "2";
                                break;
                            case "15":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "2";
                                break;
                            case "16":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "3";
                                break;
                            case "17":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "3";
                                break;
                            case "18":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "3";
                                break;
                            case "19":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "3";
                                level4LeftScore.Text = "1";
                                break;
                            case "20":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "3";
                                level4LeftScore.Text = "1";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        spellAbilityValue.Text = "N/A";
                        spellSaveDCValue.Text = "N/A";
                        spellAttackBonusValue.Text = "N/A";
                        spellList.Enabled = false;
                        addSpellButton.Enabled = false;
                        removeSpellButton.Enabled = false;
                        level1Choose.Enabled = false;
                        level2Choose.Enabled = false;
                        level3Choose.Enabled = false;
                        level4Choose.Enabled = false;
                        level5Choose.Enabled = false;
                        level6Choose.Enabled = false;
                        level7Choose.Enabled = false;
                        level8Choose.Enabled = false;
                        level9Choose.Enabled = false;
                    }
                    break;
                case "Monk":
                    spellSlotsRemaining.Text = "Ki Points Remaining:";
                    kiPointsValue.Visible = true;
                    kiPointsValue.Text = unchangingKiPoints.Text;
                    usePointsButton.Visible = true;
                    usePointsButton.Enabled = true;
                    usePointsButton.BackColor = Color.DodgerBlue;
                    cantripsValue.Visible = false;
                    cantripLabel.Visible = false;
                    level1Choose.Enabled = false;
                    level2Choose.Enabled = false;
                    level3Choose.Enabled = false;
                    level4Choose.Enabled = false;
                    level5Choose.Enabled = false;
                    level6Choose.Enabled = false;
                    level7Choose.Enabled = false;
                    level8Choose.Enabled = false;
                    level9Choose.Enabled = false;
                    level1Choose.Visible = false;
                    level2Choose.Visible = false;
                    level3Choose.Visible = false;
                    level4Choose.Visible = false;
                    level5Choose.Visible = false;
                    level6Choose.Visible = false;
                    level7Choose.Visible = false;
                    level8Choose.Visible = false;
                    level9Choose.Visible = false;
                    spellLevel1Label.Visible = false;
                    spellLevel2Label.Visible = false;
                    spellLevel3Label.Visible = false;
                    spellLevel4Label.Visible = false;
                    spellLevel5Label.Visible = false;
                    spellLevel6Label.Visible = false;
                    spellLevel7Label.Visible = false;
                    spellLevel8Label.Visible = false;
                    spellLevel9Label.Visible = false;
                    level1LeftScore.Visible = false;
                    level2LeftScore.Visible = false;
                    level3LeftScore.Visible = false;
                    level4LeftScore.Visible = false;
                    level5LeftScore.Visible = false;
                    level6LeftScore.Visible = false;
                    level7LeftScore.Visible = false;
                    level8LeftScore.Visible = false;
                    level9LeftScore.Visible = false;

                    switch (currentLevelValue.Text)
                    {
                        case "1":
                            spellList.Enabled = false;
                            addSpellButton.Enabled = false;
                            removeSpellButton.Enabled = false;
                            break;
                        case "2":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "2";
                            break;
                        case "3":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "3";
                            break;
                        case "4":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "4";
                            break;
                        case "5":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "5";
                            break;
                        case "6":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "6";
                            break;
                        case "7":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "7";
                            break;
                        case "8":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "8";
                            break;
                        case "9":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "9";
                            break;
                        case "10":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "10";
                            break;
                        case "11":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "11";
                            break;
                        case "12":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "12";
                            break;
                        case "13":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "13";
                            break;
                        case "14":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "14";
                            break;
                        case "15":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "15";
                            break;
                        case "16":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "16";
                            break;
                        case "17":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "17";
                            break;
                        case "18":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "18";
                            break;
                        case "19":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "19";
                            break;
                        case "20":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            kiPointsValue.Text = "20";
                            break;
                        default:
                            break;
                    }

                    break;
                case "Paladin":
                    switch (currentLevelValue.Text)
                    {
                        case "1":
                            spellList.Enabled = false;
                            addSpellButton.Enabled = false;
                            removeSpellButton.Enabled = false;
                            level1Choose.Enabled = false;
                            level2Choose.Enabled = false;
                            level3Choose.Enabled = false;
                            level4Choose.Enabled = false;
                            level5Choose.Enabled = false;
                            level6Choose.Enabled = false;
                            level7Choose.Enabled = false;
                            level8Choose.Enabled = false;
                            level9Choose.Enabled = false;
                            break;
                        case "2":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "2";
                            break;
                        case "3":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "3";
                            break;
                        case "4":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "3";
                            break;
                        case "5":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "2";
                            break;
                        case "6":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "2";
                            break;
                        case "7":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            break;
                        case "8":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            break;
                        case "9":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "2";
                            break;
                        case "10":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "2";
                            break;
                        case "11":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            break;
                        case "12":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            break;
                        case "13":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "1";
                            break;
                        case "14":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "1";
                            break;
                        case "15":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "2";
                            break;
                        case "16":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "2";
                            break;
                        case "17":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "1";
                            break;
                        case "18":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "1";
                            break;
                        case "19":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            break;
                        case "20":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            break;
                        default:
                            break;
                    }
                    break;
                case "Ranger":
                    switch (currentLevelValue.Text)
                    {
                        case "1":
                            spellList.Enabled = false;
                            addSpellButton.Enabled = false;
                            removeSpellButton.Enabled = false;
                            level1Choose.Enabled = false;
                            level2Choose.Enabled = false;
                            level3Choose.Enabled = false;
                            level4Choose.Enabled = false;
                            level5Choose.Enabled = false;
                            level6Choose.Enabled = false;
                            level7Choose.Enabled = false;
                            level8Choose.Enabled = false;
                            level9Choose.Enabled = false;
                            break;
                        case "2":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "2";
                            break;
                        case "3":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "3";
                            break;
                        case "4":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "3";
                            break;
                        case "5":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "2";
                            break;
                        case "6":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "2";
                            break;
                        case "7":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            break;
                        case "8":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            break;
                        case "9":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "2";
                            break;
                        case "10":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "2";
                            break;
                        case "11":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            break;
                        case "12":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            break;
                        case "13":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "1";
                            break;
                        case "14":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "1";
                            break;
                        case "15":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "2";
                            break;
                        case "16":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "2";
                            break;
                        case "17":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "1";
                            break;
                        case "18":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "1";
                            break;
                        case "19":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            break;
                        case "20":
                            spellList.Enabled = true;
                            addSpellButton.Enabled = true;
                            removeSpellButton.Enabled = true;
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            break;
                        default:
                            break;
                    }
                    break;
                case "Rogue":
                    if (ClassTraits.Text.Contains("Arcane Trickster"))
                    {
                        switch (currentLevelValue.Text)
                        {
                            case "1":
                                spellList.Enabled = false;
                                addSpellButton.Enabled = false;
                                removeSpellButton.Enabled = false;
                                level1Choose.Enabled = false;
                                level2Choose.Enabled = false;
                                level3Choose.Enabled = false;
                                level4Choose.Enabled = false;
                                level5Choose.Enabled = false;
                                level6Choose.Enabled = false;
                                level7Choose.Enabled = false;
                                level8Choose.Enabled = false;
                                level9Choose.Enabled = false;
                                break;
                            case "2":
                                spellList.Enabled = false;
                                addSpellButton.Enabled = false;
                                removeSpellButton.Enabled = false;
                                level1Choose.Enabled = false;
                                level2Choose.Enabled = false;
                                level3Choose.Enabled = false;
                                level4Choose.Enabled = false;
                                level5Choose.Enabled = false;
                                level6Choose.Enabled = false;
                                level7Choose.Enabled = false;
                                level8Choose.Enabled = false;
                                level9Choose.Enabled = false;
                                break;
                            case "3":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "2";
                                break;
                            case "4":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "3";
                                break;
                            case "5":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "3";
                                break;
                            case "6":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "3";
                                break;
                            case "7":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "2";
                                break;
                            case "8":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "2";
                                break;
                            case "9":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "3";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "2";
                                break;
                            case "10":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "4";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                break;
                            case "11":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "4";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                break;
                            case "12":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "4";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                break;
                            case "13":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "4";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "2";
                                break;
                            case "14":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "4";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "2";
                                break;
                            case "15":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "4";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "2";
                                break;
                            case "16":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "4";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "3";
                                break;
                            case "17":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "4";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "3";
                                break;
                            case "18":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "4";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "3";
                                break;
                            case "19":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "4";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "3";
                                level4LeftScore.Text = "1";
                                break;
                            case "20":
                                spellList.Enabled = true;
                                addSpellButton.Enabled = true;
                                removeSpellButton.Enabled = true;
                                cantripsValue.Text = "4";
                                level1LeftScore.Text = "4";
                                level2LeftScore.Text = "3";
                                level3LeftScore.Text = "3";
                                level4LeftScore.Text = "1";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        spellAbilityValue.Text = "N/A";
                        spellSaveDCValue.Text = "N/A";
                        spellAttackBonusValue.Text = "N/A";
                        spellList.Enabled = false;
                        addSpellButton.Enabled = false;
                        removeSpellButton.Enabled = false;
                        level1Choose.Enabled = false;
                        level2Choose.Enabled = false;
                        level3Choose.Enabled = false;
                        level4Choose.Enabled = false;
                        level5Choose.Enabled = false;
                        level6Choose.Enabled = false;
                        level7Choose.Enabled = false;
                        level8Choose.Enabled = false;
                        level9Choose.Enabled = false;
                    }
                    break;
                case "Sorcerer":
                    switch (currentLevelValue.Text)
                    {
                        case "1":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "2";
                            break;
                        case "2":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "3";
                            break;
                        case "3":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "2";
                            break;
                        case "4":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            break;
                        case "5":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "2";
                            break;
                        case "6":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            break;
                        case "7":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "1";
                            break;
                        case "8":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "2";
                            break;
                        case "9":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "1";
                            break;
                        case "10":
                            cantripsValue.Text = "6";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            break;
                        case "11":
                            cantripsValue.Text = "6";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            break;
                        case "12":
                            cantripsValue.Text = "6";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            break;
                        case "13":
                            cantripsValue.Text = "6";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "14":
                            cantripsValue.Text = "6";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "15":
                            cantripsValue.Text = "6";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "16":
                            cantripsValue.Text = "6";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "17":
                            cantripsValue.Text = "6";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "18":
                            cantripsValue.Text = "6";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "19":
                            cantripsValue.Text = "6";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "2";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "20":
                            cantripsValue.Text = "6";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "2";
                            level7LeftScore.Text = "2";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        default:
                            break;
                    }
                    break;
                case "Warlock":
                    WarlockSlotLevelValue.Visible = true;
                    WarlockSpellSlots.Visible = true;
                    WarlockSlotLevel.Visible = true;
                    warlockInvocations.Visible = true;
                    WarlockInvocationsLabel.Visible = true;
                    useSlotButton.Enabled = true;
                    useSlotButton.Visible = true;
                    useSlotButton.BackColor = Color.DodgerBlue;

                    level1Choose.Enabled = false;
                    level2Choose.Enabled = false;
                    level3Choose.Enabled = false;
                    level4Choose.Enabled = false;
                    level5Choose.Enabled = false;
                    level1Choose.Visible = false;
                    level2Choose.Visible = false;
                    level3Choose.Visible = false;
                    level4Choose.Visible = false;
                    level5Choose.Visible = false;
                    spellLevel1Label.Visible = false;
                    spellLevel2Label.Visible = false;
                    spellLevel3Label.Visible = false;
                    spellLevel4Label.Visible = false;
                    spellLevel5Label.Visible = false;
                    level1LeftScore.Visible = false;
                    level2LeftScore.Visible = false;
                    level3LeftScore.Visible = false;
                    level4LeftScore.Visible = false;
                    level5LeftScore.Visible = false;

                    switch (currentLevelValue.Text)
                    {
                        case "1":
                            cantripsValue.Text = "2";
                            WarlockSpellSlots.Text = "1";
                            WarlockSlotLevelValue.Text = "1st";
                            warlockInvocations.Text = "0";
                            break;
                        case "2":
                            cantripsValue.Text = "2";
                            WarlockSpellSlots.Text = "2";
                            WarlockSlotLevelValue.Text = "1st";
                            warlockInvocations.Text = "2";
                            break;
                        case "3":
                            cantripsValue.Text = "2";
                            WarlockSpellSlots.Text = "2";
                            WarlockSlotLevelValue.Text = "2nd";
                            warlockInvocations.Text = "2";
                            break;
                        case "4":
                            cantripsValue.Text = "3";
                            WarlockSpellSlots.Text = "2";
                            WarlockSlotLevelValue.Text = "2nd";
                            warlockInvocations.Text = "2";
                            break;
                        case "5":
                            cantripsValue.Text = "3";
                            WarlockSpellSlots.Text = "2";
                            WarlockSlotLevelValue.Text = "2nd";
                            warlockInvocations.Text = "3";
                            break;
                        case "6":
                            cantripsValue.Text = "3";
                            WarlockSpellSlots.Text = "2";
                            WarlockSlotLevelValue.Text = "3rd";
                            warlockInvocations.Text = "3";
                            break;
                        case "7":
                            cantripsValue.Text = "3";
                            WarlockSpellSlots.Text = "2";
                            WarlockSlotLevelValue.Text = "4th";
                            warlockInvocations.Text = "4";
                            break;
                        case "8":
                            cantripsValue.Text = "3";
                            WarlockSpellSlots.Text = "2";
                            WarlockSlotLevelValue.Text = "4th";
                            warlockInvocations.Text = "4";
                            break;
                        case "9":
                            cantripsValue.Text = "3";
                            WarlockSpellSlots.Text = "2";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "5";
                            break;
                        case "10":
                            cantripsValue.Text = "4";
                            WarlockSpellSlots.Text = "2";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "5";
                            break;
                        case "11":
                            cantripsValue.Text = "4";
                            WarlockSpellSlots.Text = "3";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "5";
                            level6LeftScore.Text = "1";
                            break;
                        case "12":
                            cantripsValue.Text = "4";
                            WarlockSpellSlots.Text = "3";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "6";
                            level6LeftScore.Text = "1";
                            break;
                        case "13":
                            cantripsValue.Text = "4";
                            WarlockSpellSlots.Text = "3";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "6";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "14":
                            cantripsValue.Text = "4";
                            WarlockSpellSlots.Text = "3";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "6";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "15":
                            cantripsValue.Text = "4";
                            WarlockSpellSlots.Text = "3";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "7";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "16":
                            cantripsValue.Text = "4";
                            WarlockSpellSlots.Text = "3";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "7";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "17":
                            cantripsValue.Text = "4";
                            WarlockSpellSlots.Text = "4";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "7";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "18":
                            cantripsValue.Text = "4";
                            WarlockSpellSlots.Text = "4";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "8";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "19":
                            cantripsValue.Text = "4";
                            WarlockSpellSlots.Text = "4";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "8";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "20":
                            cantripsValue.Text = "4";
                            WarlockSpellSlots.Text = "4";
                            WarlockSlotLevelValue.Text = "5th";
                            warlockInvocations.Text = "8";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        default:
                            break;
                    }
                    break;
                case "Wizard":
                    switch (currentLevelValue.Text)
                    {
                        case "1":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "2";
                            break;
                        case "2":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "3";
                            break;
                        case "3":
                            cantripsValue.Text = "3";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "2";
                            break;
                        case "4":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            break;
                        case "5":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "2";
                            break;
                        case "6":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            break;
                        case "7":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "1";
                            break;
                        case "8":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "2";
                            break;
                        case "9":
                            cantripsValue.Text = "4";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "1";
                            break;
                        case "10":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            break;
                        case "11":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            break;
                        case "12":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            break;
                        case "13":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "14":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            break;
                        case "15":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "16":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            break;
                        case "17":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "2";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "18":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "1";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "19":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "2";
                            level7LeftScore.Text = "1";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        case "20":
                            cantripsValue.Text = "5";
                            level1LeftScore.Text = "4";
                            level2LeftScore.Text = "3";
                            level3LeftScore.Text = "3";
                            level4LeftScore.Text = "3";
                            level5LeftScore.Text = "3";
                            level6LeftScore.Text = "2";
                            level7LeftScore.Text = "2";
                            level8LeftScore.Text = "1";
                            level9LeftScore.Text = "1";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            enableTheSpellSlots();
        }

        private void enableTheSpellSlots()
        {
            //start by enabling them all
            level1Choose.BackColor = Color.DodgerBlue;
            level1Choose.Enabled = true;
            level2Choose.BackColor = Color.DodgerBlue;
            level2Choose.Enabled = true;
            level3Choose.BackColor = Color.DodgerBlue;
            level3Choose.Enabled = true;
            level4Choose.BackColor = Color.DodgerBlue;
            level4Choose.Enabled = true;
            level5Choose.BackColor = Color.DodgerBlue;
            level5Choose.Enabled = true;
            level6Choose.BackColor = Color.DodgerBlue;
            level6Choose.Enabled = true;
            level7Choose.BackColor = Color.DodgerBlue;
            level7Choose.Enabled = true;
            level8Choose.BackColor = Color.DodgerBlue;
            level8Choose.Enabled = true;
            level9Choose.BackColor = Color.DodgerBlue;
            level9Choose.Enabled = true;
            if (level1LeftScore.Text == "" || level1LeftScore.Text == "0")
            {
                level1Choose.BackColor = Color.Gray;
                level1Choose.Enabled = false;
            }
            if (level2LeftScore.Text == "" || level2LeftScore.Text == "0")
            {
                level2Choose.BackColor = Color.Gray;
                level2Choose.Enabled = false;
            }
            if (level3LeftScore.Text == "" || level3LeftScore.Text == "0")
            {
                level3Choose.BackColor = Color.Gray;
                level3Choose.Enabled = false;
            }
            if (level4LeftScore.Text == "" || level4LeftScore.Text == "0")
            {
                level4Choose.BackColor = Color.Gray;
                level4Choose.Enabled = false;
            }
            if (level5LeftScore.Text == "" || level5LeftScore.Text == "0")
            {
                level5Choose.BackColor = Color.Gray;
                level5Choose.Enabled = false;
            }
            if (level6LeftScore.Text == "" || level6LeftScore.Text == "0")
            {
                level6Choose.BackColor = Color.Gray;
                level6Choose.Enabled = false;
            }
            if (level7LeftScore.Text == "" || level7LeftScore.Text == "0")
            {
                level7Choose.BackColor = Color.Gray;
                level7Choose.Enabled = false;
            }
            if (level8LeftScore.Text == "" || level8LeftScore.Text == "0")
            {
                level8Choose.BackColor = Color.Gray;
                level8Choose.Enabled = false;
            }
            if (level9LeftScore.Text == "" || level9LeftScore.Text == "0")
            {
                level9Choose.BackColor = Color.Gray;
                level9Choose.Enabled = false;
            }
        }

        private void determineSpells(string spellId)
        {
            DnD_Character_ManagerDBDataSetTableAdapters.spellsTableTableAdapter spellTableAdapt =
                new DnD_Character_ManagerDBDataSetTableAdapters.spellsTableTableAdapter();

            var rowsFromTable = spellTableAdapt.GetData().Rows;
            foreach (DataRow row in rowsFromTable)
            {
                var rowItems = row.ItemArray;
                if (rowItems[1].ToString() == spellId)
                {
                    //add it to their spells table 2 = name 3 = level 4 = description
                    string[] spellEntry = { rowItems[2].ToString(), rowItems[3].ToString(), rowItems[4].ToString() };
                    var spellToAdd = new ListViewItem(spellEntry);
                    spellList.Items.Add(spellToAdd);
                }
            }
        }

        private void determineSpellInfo(int profBonus)
        {
            string spellcastingAbility = "";
            string saveDC = "";
            string attackBon = "";

            switch (char_Class.Text)
            {
                case "Barbarian":
                    spellcastingAbility = "N/A";
                    saveDC = "N/A";
                    attackBon = "N/A";
                    break;
                case "Bard":
                    spellcastingAbility = "Charisma";
                    saveDC = (int.Parse(CharismaMod.Text.Replace("+", "")) + profBonus + 8).ToString();
                    attackBon = (int.Parse(CharismaMod.Text.Replace("+", "")) + profBonus).ToString();
                    break;
                case "Cleric":
                    spellcastingAbility = "Wisdom";
                    saveDC = (int.Parse(WisdomMod.Text.Replace("+", "")) + profBonus + 8).ToString();
                    attackBon = (int.Parse(WisdomMod.Text.Replace("+", "")) + profBonus).ToString();
                    break;
                case "Druid":
                    spellcastingAbility = "Wisdom";
                    saveDC = (int.Parse(WisdomMod.Text.Replace("+", "")) + profBonus + 8).ToString();
                    attackBon = (int.Parse(WisdomMod.Text.Replace("+", "")) + profBonus).ToString();
                    break;
                case "Fighter":
                    spellcastingAbility = "Intelligence";
                    saveDC = (int.Parse(IntelligenceMod.Text.Replace("+", "")) + profBonus + 8).ToString();
                    attackBon = (int.Parse(IntelligenceMod.Text.Replace("+", "")) + profBonus).ToString();
                    break;
                case "Monk":
                    spellcastingAbility = "Ki";
                    saveDC = saveDC = (int.Parse(WisdomMod.Text.Replace("+", "")) + profBonus + 8).ToString();
                    attackBon = "N/A";
                    break;
                case "Paladin":
                    spellcastingAbility = "Charisma";
                    saveDC = (int.Parse(CharismaMod.Text.Replace("+", "")) + profBonus + 8).ToString();
                    attackBon = (int.Parse(CharismaMod.Text.Replace("+", "")) + profBonus).ToString();
                    break;
                case "Ranger":
                    spellcastingAbility = "Wisdom";
                    saveDC = (int.Parse(WisdomMod.Text.Replace("+", "")) + profBonus + 8).ToString();
                    attackBon = (int.Parse(WisdomMod.Text.Replace("+", "")) + profBonus).ToString();
                    break;
                case "Rogue":
                    spellcastingAbility = "Intelligence";
                    saveDC = (int.Parse(IntelligenceMod.Text.Replace("+", "")) + profBonus + 8).ToString();
                    attackBon = (int.Parse(IntelligenceMod.Text.Replace("+", "")) + profBonus).ToString();
                    break;
                case "Sorcerer":
                    spellcastingAbility = "Charisma";
                    saveDC = (int.Parse(CharismaMod.Text.Replace("+", "")) + profBonus + 8).ToString();
                    attackBon = (int.Parse(CharismaMod.Text.Replace("+", "")) + profBonus).ToString();
                    break;
                case "Warlock":
                    spellcastingAbility = "Charisma";
                    saveDC = (int.Parse(CharismaMod.Text.Replace("+", "")) + profBonus + 8).ToString();
                    attackBon = (int.Parse(CharismaMod.Text.Replace("+", "")) + profBonus).ToString();
                    break;
                case "Wizard":
                    spellcastingAbility = "Intelligence";
                    saveDC = (int.Parse(IntelligenceMod.Text.Replace("+", "")) + profBonus + 8).ToString();
                    attackBon = (int.Parse(IntelligenceMod.Text.Replace("+", "")) + profBonus).ToString();
                    break;
                default:
                    break;
            }
            spellAbilityValue.Text = spellcastingAbility;
            spellSaveDCValue.Text = saveDC;
            spellAttackBonusValue.Text = attackBon;
        }

        private void gatherRacialTraitsNAbilities()
        {
            DnD_Character_ManagerDBDataSetTableAdapters.RacesTableAdapter raceTableAdapter =
                new DnD_Character_ManagerDBDataSetTableAdapters.RacesTableAdapter();

            string racetraits = "";
            var rowsfromRaceTable = raceTableAdapter.GetData().Rows;
            foreach (DataRow row in rowsfromRaceTable)
            {
                var rowItems = row.ItemArray;
                if (rowItems[1].ToString() == char_Race.Text)
                {
                    racetraits = racetraits + rowItems[7].ToString() + ", ";
                }
            }
            RacialTraits.Text = RacialTraits.Text + racetraits;
        }

        private string determineNextLevelXp(string text)
        {
            switch (text)
            {
                case "1":
                    return "300";
                case "2":
                    return "900";
                case "3":
                    return "2700";
                case "4":
                    return "6500";
                case "5":
                    return "14000";
                case "6":
                    return "23000";
                case "7":
                    return "34000";
                case "8":
                    return "48000";
                case "9":
                    return "64000";
                case "10":
                    return "85000";
                case "11":
                    return "100000";
                case "12":
                    return "120000";
                case "13":
                    return "140000";
                case "14":
                    return "165000";
                case "15":
                    return "195000";
                case "16":
                    return "225000";
                case "17":
                    return "265000";
                case "18":
                    return "305000";
                case "19":
                    return "355000";
                case "20":
                    return "N/A";

                default:
                    return "ERROR";
            }
        }

        private void calculateModsSavesSkills(string saves, string skills, int profbonu)
        {
            //calculate the ability modifiers
            CharismaMod.Text = getModifier(CharismaScore.Text);
            WisdomMod.Text = getModifier(WisdomScore.Text);
            ConstitutionMod.Text = getModifier(ConstitutionScore.Text);
            IntelligenceMod.Text = getModifier(IntelligenceScore.Text);
            DexterityMod.Text = getModifier(DexterityScore.Text);
            StrengthMod.Text = getModifier(StrengthScore.Text);

            //split up the strings into arrays for easy usage
            string[] seperator = { ", " };
            string[] abilitySaves = saves.Split(seperator, StringSplitOptions.None);
            assignAbilitySaves(abilitySaves, profbonu);
            string[] skillProfs = skills.Split(seperator, StringSplitOptions.None);
            assignSkills(skillProfs, profbonu);
        }

        private void assignSkills(string[] skillProfs, int profbonu)
        {
            //assign all values to defaults first
            acrobaticsScore.Text = DexterityMod.Text;
            animalHandlingScore.Text = WisdomMod.Text;
            arcanaScore.Text = IntelligenceMod.Text;
            athleticsScore.Text = StrengthMod.Text;
            deceptionScore.Text = CharismaMod.Text;
            historyScore.Text = IntelligenceMod.Text;
            insightScore.Text = WisdomMod.Text;
            intimidationScore.Text = CharismaMod.Text;
            investigationScore.Text = IntelligenceMod.Text;
            medicineScore.Text = WisdomMod.Text;
            natureScore.Text = IntelligenceMod.Text;
            perceptionScore.Text = WisdomMod.Text;
            performanceScore.Text = CharismaMod.Text;
            persuasionScore.Text = CharismaMod.Text;
            religionScore.Text = IntelligenceMod.Text;
            sleightOfHandScore.Text = DexterityMod.Text;
            stealthScore.Text = DexterityMod.Text;
            survivalScore.Text = WisdomMod.Text;
            //now add proficiencies to applicable skills
            foreach (string skill in skillProfs)
            {
                switch (skill)
                {
                    case "Acrobatics":
                        acrobaticsScore.Text = "+" + (int.Parse(DexterityMod.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Animal Handling":
                        animalHandlingScore.Text = "+" + (int.Parse(animalHandlingScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Arcana":
                        arcanaScore.Text = "+" + (int.Parse(arcanaScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Athletics":
                        athleticsScore.Text = "+" + (int.Parse(athleticsScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Deception":
                        deceptionScore.Text = "+" + (int.Parse(deceptionScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "History":
                        historyScore.Text = "+" + (int.Parse(historyScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Insight":
                        insightScore.Text = "+" + (int.Parse(insightScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Intimidation":
                        intimidationScore.Text = "+" + (int.Parse(intimidationScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Investigation":
                        investigationScore.Text = "+" + (int.Parse(investigationScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Medicine":
                        medicineScore.Text = "+" + (int.Parse(medicineScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Nature":
                        natureScore.Text = "+" + (int.Parse(natureScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Perception":
                        perceptionScore.Text = "+" + (int.Parse(perceptionScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Performance":
                        performanceScore.Text = "+" + (int.Parse(performanceScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Persuasion":
                        persuasionScore.Text = "+" + (int.Parse(persuasionScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Religion":
                        religionScore.Text = "+" + (int.Parse(religionScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Sleight of Hand":
                        sleightOfHandScore.Text = "+" + (int.Parse(sleightOfHandScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Stealth":
                        stealthScore.Text = "+" + (int.Parse(stealthScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    case "Survival":
                        survivalScore.Text = "+" + (int.Parse(survivalScore.Text.Replace("+", "")) + profbonu).ToString();
                        break;
                    default://??
                        break;
                }
            }
        }

        private void assignAbilitySaves(string[] abilitySaves, int profbonu)
        {
            //calculate saving throws
            if (abilitySaves.Contains("Strength"))
            {
                int moder = int.Parse(StrengthMod.Text.Replace("+", ""));
                int save = moder + profbonu;
                StrengthSave.Text = "+" + save.ToString();
                StrengthSave.Visible = true;

            }
            if (abilitySaves.Contains("Dexterity"))
            {
                int moder = int.Parse(DexterityMod.Text.Replace("+", ""));
                int save = moder + profbonu;
                DexteritySave.Text = "+" + save.ToString();
                DexteritySave.Visible = true;
            }
            if (abilitySaves.Contains("Intelligence"))
            {
                int moder = int.Parse(IntelligenceMod.Text.Replace("+", ""));
                int save = moder + profbonu;
                IntelligenceSave.Text = "+" + save.ToString();
                IntelligenceSave.Visible = true;
            }
            if (abilitySaves.Contains("Constitution"))
            {
                int moder = int.Parse(ConstitutionMod.Text.Replace("+", ""));
                int save = moder + profbonu;
                ConstitutionSave.Text = "+" + save.ToString();
                ConstitutionSave.Visible = true;
            }
            if (abilitySaves.Contains("Wisdom"))
            {
                int moder = int.Parse(WisdomMod.Text.Replace("+", ""));
                int save = moder + profbonu;
                WisdomSave.Text = "+" + save.ToString();
                WisdomSave.Visible = true;
            }
            if (abilitySaves.Contains("Charisma"))
            {
                int moder = int.Parse(CharismaMod.Text.Replace("+", ""));
                int save = moder + profbonu;
                CharismaSave.Text = "+" + save.ToString();
                CharismaSave.Visible = true;
            }
        }

        private string getModifier(string score)
        {
            string modi = "";
            switch (score)
            {
                case "8":
                    modi = "-1";
                    break;
                case "9":
                    modi = "-1";
                    break;
                case "10":
                    modi = "0";
                    break;
                case "11":
                    modi = "0";
                    break;
                case "12":
                    modi = "+1";
                    break;
                case "13":
                    modi = "+1";
                    break;
                case "14":
                    modi = "+2";
                    break;
                case "15":
                    modi = "+2";
                    break;
                case "16":
                    modi = "+3";
                    break;
                case "17":
                    modi = "+3";
                    break;
                case "18":
                    modi = "+4";
                    break;
                case "19":
                    modi = "+4";
                    break;
                case "20":
                    modi = "+5";
                    break;
                default:
                    modi = "error";
                    break;
            }
            return modi;
        }

        private string getMoneyTotal(double value)
        {
            string Total = (double.Parse(totalMoneyValue.Text) + value).ToString();
            return Total;
        }

        private string minusMoneyTotal(double value)
        {
            string Total = "";
            if (double.Parse(totalMoneyValue.Text) - value <= 0)
            {
                Total = "0";
            }
            else
            {
                Total = (double.Parse(totalMoneyValue.Text) - value).ToString();
            }
            return Total;
        }

        private string getProfBonus(string value)
        {
            string returnValue = "";
            switch (value)
            {
                case "1":
                    returnValue = "+2";
                    break;
                case "2":
                    returnValue = "+2";
                    break;
                case "3":
                    returnValue = "+2";
                    break;
                case "4":
                    returnValue = "+2";
                    break;
                case "5":
                    returnValue = "+3";
                    break;
                case "6":
                    returnValue = "+3";
                    break;
                case "7":
                    returnValue = "+3";
                    break;
                case "8":
                    returnValue = "+3";
                    break;
                case "9":
                    returnValue = "+4";
                    break;
                case "10":
                    returnValue = "+4";
                    break;
                case "11":
                    returnValue = "+4";
                    break;
                case "12":
                    returnValue = "+4";
                    break;
                case "13":
                    returnValue = "+5";
                    break;
                case "14":
                    returnValue = "+5";
                    break;
                case "15":
                    returnValue = "+5";
                    break;
                case "16":
                    returnValue = "+5";
                    break;
                case "17":
                    returnValue = "+6";
                    break;
                case "18":
                    returnValue = "+6";
                    break;
                case "19":
                    returnValue = "+6";
                    break;
                case "20":
                    returnValue = "+6";
                    break;
                default:
                    returnValue = "error";
                    break;
            }
            return returnValue;
        }

        private void statImageButton_Click(object sender, EventArgs e)
        {
            statImageButton.BackColor = Color.Chocolate;
            combatImageButton.BackColor = Color.Transparent;
            magicImageButton.BackColor = Color.Transparent;
            inventoryImageButton.BackColor = Color.Transparent;
            backgroundImageButton.BackColor = Color.Transparent;
            saveNQuitImageButton.BackColor = Color.Transparent;
            statPanel.Visible = true;
            combatPanel.Visible = false;
            magicPanel.Visible = false;
            inventoryPanel.Visible = false;
            backgroundPanel.Visible = false;
            quitNSavePanel.Visible = false;
        }

        private void combatImageButton_Click(object sender, EventArgs e)
        {
            statImageButton.BackColor = Color.Transparent;
            combatImageButton.BackColor = Color.Chocolate;
            magicImageButton.BackColor = Color.Transparent;
            inventoryImageButton.BackColor = Color.Transparent;
            backgroundImageButton.BackColor = Color.Transparent;
            saveNQuitImageButton.BackColor = Color.Transparent;
            statPanel.Visible = false;
            combatPanel.Visible = true;
            magicPanel.Visible = false;
            inventoryPanel.Visible = false;
            backgroundPanel.Visible = false;
            quitNSavePanel.Visible = false;
        }

        private void magicImageButton_Click(object sender, EventArgs e)
        {
            statImageButton.BackColor = Color.Transparent;
            combatImageButton.BackColor = Color.Transparent;
            magicImageButton.BackColor = Color.Chocolate;
            inventoryImageButton.BackColor = Color.Transparent;
            backgroundImageButton.BackColor = Color.Transparent;
            saveNQuitImageButton.BackColor = Color.Transparent;
            statPanel.Visible = false;
            combatPanel.Visible = false;
            magicPanel.Visible = true;
            inventoryPanel.Visible = false;
            backgroundPanel.Visible = false;
            quitNSavePanel.Visible = false;
        }

        private void inventoryImageButton_Click(object sender, EventArgs e)
        {
            statImageButton.BackColor = Color.Transparent;
            combatImageButton.BackColor = Color.Transparent;
            magicImageButton.BackColor = Color.Transparent;
            inventoryImageButton.BackColor = Color.Chocolate;
            backgroundImageButton.BackColor = Color.Transparent;
            saveNQuitImageButton.BackColor = Color.Transparent;
            statPanel.Visible = false;
            combatPanel.Visible = false;
            magicPanel.Visible = false;
            inventoryPanel.Visible = true;
            backgroundPanel.Visible = false;
            quitNSavePanel.Visible = false;
        }

        private void backgroundImageButton_Click(object sender, EventArgs e)
        {
            statImageButton.BackColor = Color.Transparent;
            combatImageButton.BackColor = Color.Transparent;
            magicImageButton.BackColor = Color.Transparent;
            inventoryImageButton.BackColor = Color.Transparent;
            backgroundImageButton.BackColor = Color.Chocolate;
            saveNQuitImageButton.BackColor = Color.Transparent;
            statPanel.Visible = false;
            combatPanel.Visible = false;
            magicPanel.Visible = false;
            inventoryPanel.Visible = false;
            backgroundPanel.Visible = true;
            quitNSavePanel.Visible = false;
        }

        private void saveNQuitImageButton_Click(object sender, EventArgs e)
        {
            statImageButton.BackColor = Color.Transparent;
            combatImageButton.BackColor = Color.Transparent;
            magicImageButton.BackColor = Color.Transparent;
            inventoryImageButton.BackColor = Color.Transparent;
            backgroundImageButton.BackColor = Color.Transparent;
            saveNQuitImageButton.BackColor = Color.Chocolate;
            statPanel.Visible = false;
            combatPanel.Visible = false;
            magicPanel.Visible = false;
            inventoryPanel.Visible = false;
            backgroundPanel.Visible = false;
            quitNSavePanel.Visible = true;
        }

        private void weaponsArmorTab_Click(object sender, EventArgs e)
        {
            weaponsNArmorPanel.Visible = true;
            equipmentNGearPanel.Visible = false;
            moneyNTreasurePanel.Visible = false;
        }

        private void equipmentGearTab_Click(object sender, EventArgs e)
        {
            weaponsNArmorPanel.Visible = false;
            equipmentNGearPanel.Visible = true;
            moneyNTreasurePanel.Visible = false;
        }

        private void moneyTreasureTab_Click(object sender, EventArgs e)
        {
            weaponsNArmorPanel.Visible = false;
            equipmentNGearPanel.Visible = false;
            moneyNTreasurePanel.Visible = true;
        }

        private void InitiativeButton_Click(object sender, EventArgs e)
        {
            Random randy = new Random();
            initiativeScore.Text = randy.Next(1, 21).ToString();
        }

        //PUT NEW DROPDOWN HERE
        private void armorValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            armorClassValue.Text = determineArmorClass();
        }

        private string determineArmorClass()
        {
            string armorClass = "";
            switch (armorEquip.Text.ToLower())
            {
                case "padded":
                    armorClass =  armorClassValue.Text = (11 + int.Parse(DexterityMod.Text)).ToString();
                    break;
                case "leather":
                    armorClass =  armorClassValue.Text = (11 + int.Parse(DexterityMod.Text)).ToString();
                    break;
                case "studded leather":
                    armorClass = armorClassValue.Text = (12 + int.Parse(DexterityMod.Text)).ToString();
                    break;
                case "hide":
                    armorClass = armorClassValue.Text = (12 + int.Parse(DexterityMod.Text)).ToString();
                    break;
                case "Chain shirt":
                    armorClass = armorClassValue.Text = (13 + int.Parse(DexterityMod.Text)).ToString();
                    break;
                case "scale mail":
                    armorClass = armorClassValue.Text = (14 + int.Parse(DexterityMod.Text)).ToString();
                    break;
                case "breastplate":
                    armorClass = armorClassValue.Text = (14 + int.Parse(DexterityMod.Text)).ToString();
                    break;
                case "half plate":
                    armorClass = armorClassValue.Text = (15 + int.Parse(DexterityMod.Text)).ToString();
                    break;
                case "ring mail":
                    armorClass = armorClassValue.Text = "14";
                    break;
                case "chain mail":
                    armorClass = armorClassValue.Text = "16";
                    break;
                case "splint":
                    armorClass = armorClassValue.Text = "17";
                    break;
                case "plate":
                    armorClass = armorClassValue.Text = "18";
                    break;
                default:
                    armorClass = armorClassValue.Text = (10 + int.Parse(DexterityMod.Text)).ToString();
                    break;
            }
            return armorClass;
        }

        private void dashButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                speedScore.Text = (int.Parse(speedScore.Text) * 2).ToString();
                dashButton.BackColor = Color.Gray;
                dashButton.Enabled = false;
                checkActions();
            }
        }

        private void addToWeaponTableButton_Click(object sender, EventArgs e)
        {
            AddItemForm form = new AddItemForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem itemfromForm = form.addItemToTable();
                weaponsNArmorListview.Items.Add(itemfromForm);
            }
            form.Close();
            form.Dispose();
        }

        private void removeFromWeaponTableButton_Click(object sender, EventArgs e)
        {
            if (weaponsNArmorListview.SelectedItems.Count > 0)
            {
                for (int i = weaponsNArmorListview.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem item = weaponsNArmorListview.SelectedItems[i];
                    weaponsNArmorListview.Items[item.Index].Remove();
                }
            }
            else
            {
                NoItemsSelectedForm woops = new NoItemsSelectedForm();
                woops.Show(this);
            }
        }

        private void addtoEquipmentTableButton_Click(object sender, EventArgs e)
        {
            AddItemForm form = new AddItemForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem itemfromForm = form.addItemToTable();
                equipmentNGearList.Items.Add(itemfromForm);
            }
            form.Close();
            form.Dispose();
        }

        private void removeFromEquipmentTableButton_Click(object sender, EventArgs e)
        {
            if (equipmentNGearList.SelectedItems.Count > 0)
            {
                for (int i = equipmentNGearList.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem item = equipmentNGearList.SelectedItems[i];
                    equipmentNGearList.Items[item.Index].Remove();
                }
            }
            else
            {
                NoItemsSelectedForm woops = new NoItemsSelectedForm();
                woops.Show(this);
            }
        }

        private void addToMoneyTableButton_Click(object sender, EventArgs e)
        {
            AddTreasureForm form = new AddTreasureForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem itemfromForm = form.addItemToTable();
                treasureList.Items.Add(itemfromForm);
            }
            form.Close();
            form.Dispose();
        }

        private void removeFromMoneyTableButton_Click(object sender, EventArgs e)
        {
            if (treasureList.SelectedItems.Count > 0)
            {
                for (int i = treasureList.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem item = treasureList.SelectedItems[i];
                    treasureList.Items[item.Index].Remove();
                }
            }
            else
            {
                NoItemsSelectedForm woops = new NoItemsSelectedForm();
                woops.Show(this);
            }
        }

        private void editHealthButton_Click_1(object sender, EventArgs e)
        {
            HealthForm form = new HealthForm();
            if (form.ShowDialog(this) == DialogResult.Yes)
            {
                int amount = form.getAmount();
                if (hitPointsMeter.Value + amount > hitPointsMeter.Maximum)
                {
                    hitPointsMeter.Value = hitPointsMeter.Maximum;
                }
                else
                {
                    hitPointsMeter.Value = hitPointsMeter.Value + amount;
                }
            }
            else if (form.DialogResult == DialogResult.No)
            {
                int amount = form.getAmount();
                if (hitPointsMeter.Value - amount < hitPointsMeter.Minimum)
                {
                    hitPointsMeter.Value = hitPointsMeter.Minimum;
                }
                else
                {
                    hitPointsMeter.Value = hitPointsMeter.Value - amount;
                }
            }
            form.Close();
            form.Dispose();
        }
        
        private void addXpButton_Click_1(object sender, EventArgs e)
        {
            AddXpForm form = new AddXpForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                int amount = form.getAmount();
                nowXpValue.Text = (int.Parse(nowXpValue.Text) + amount).ToString();

                if (int.Parse(nowXpValue.Text) >= int.Parse(nextXpValue.Text))
                {
                    levelUpButton.Enabled = true;
                    levelUpButton.BackColor = Color.Gold;
                }
            }
            form.Close();
            form.Dispose();
        }

        //NEW EDIT MONEY BUTTON
        private void editMoneyButton_Click_1(object sender, EventArgs e)
        {
            MoneyManagerForm mm = new MoneyManagerForm();
            if (mm.ShowDialog(this) == DialogResult.OK)
            {
                int[] amounts = mm.getAmounts();
                copperValue.Text = (int.Parse(copperValue.Text) + amounts[0]).ToString();
                silverValue.Text = (int.Parse(silverValue.Text) + amounts[1]).ToString();
                electrumValue.Text = (int.Parse(electrumValue.Text) + amounts[2]).ToString();
                goldValue.Text = (int.Parse(goldValue.Text) + amounts[3]).ToString();
                platinumValue.Text = (int.Parse(platinumValue.Text) + amounts[4]).ToString();

                float total = (amounts[0] / 100) + (amounts[1] / 10) + (amounts[2] / 2) + (amounts[3]) + (amounts[4] * 10);
                totalMoneyValue.Text = getMoneyTotal(total);
            }
            else if (mm.DialogResult == DialogResult.No)
            {
                int[] amounts = mm.getAmounts();
                copperValue.Text = (int.Parse(copperValue.Text) - amounts[0]).ToString();
                silverValue.Text = (int.Parse(silverValue.Text) - amounts[1]).ToString();
                electrumValue.Text = (int.Parse(electrumValue.Text) - amounts[2]).ToString();
                goldValue.Text = (int.Parse(goldValue.Text) - amounts[3]).ToString();
                platinumValue.Text = (int.Parse(platinumValue.Text) - amounts[4]).ToString();

                float total = (amounts[0] / 100) + (amounts[1] / 10) + (amounts[2] / 2) + (amounts[3]) + (amounts[4] * 10);
                totalMoneyValue.Text = minusMoneyTotal(total);
            }
            mm.Close();
            mm.Dispose();
        }

        private void addSpellButton_Click(object sender, EventArgs e)
        {
            AddSpellForm form = new AddSpellForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem itemfromForm = form.addItemToTable();
                spellList.Items.Add(itemfromForm);
            }
            form.Close();
            form.Dispose();
        }

        private void removeSpellButton_Click(object sender, EventArgs e)
        {
            if (spellList.SelectedItems.Count > 0)
            {
                for (int i = spellList.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem item = spellList.SelectedItems[i];
                    spellList.Items[item.Index].Remove();
                }
            }
            else
            {
                NoItemsSelectedForm woops = new NoItemsSelectedForm();
                woops.Show(this);
            }
        }

        private void level1Choose_Click(object sender, EventArgs e)
        {
            if (level1LeftScore.Text != "0")
            {
                level1LeftScore.Text = (int.Parse(level1LeftScore.Text) - 1).ToString();
                if (level1LeftScore.Text == "0")
                {
                    level1Choose.BackColor = Color.Gray;
                    level1Choose.Enabled = false;
                }
            }
        }

        private void level2Choose_Click(object sender, EventArgs e)
        {
            if (level2LeftScore.Text != "0")
            {
                level2LeftScore.Text = (int.Parse(level2LeftScore.Text) - 1).ToString();
                if (level2LeftScore.Text == "0")
                {
                    level2Choose.BackColor = Color.Gray;
                    level2Choose.Enabled = false;
                }
            }
        }

        private void level3Choose_Click(object sender, EventArgs e)
        {
            if (level3LeftScore.Text != "0")
            {
                level3LeftScore.Text = (int.Parse(level3LeftScore.Text) - 1).ToString();
                if (level3LeftScore.Text == "0")
                {
                    level3Choose.BackColor = Color.Gray;
                    level3Choose.Enabled = false;
                }
            }
        }

        private void level4Choose_Click(object sender, EventArgs e)
        {
            if (level4LeftScore.Text != "0")
            {
                level4LeftScore.Text = (int.Parse(level4LeftScore.Text) - 1).ToString();
                if (level4LeftScore.Text == "0")
                {
                    level4Choose.BackColor = Color.Gray;
                    level4Choose.Enabled = false;
                }
            }
        }

        private void level5Choose_Click(object sender, EventArgs e)
        {
            if (level5LeftScore.Text != "0")
            {
                level5LeftScore.Text = (int.Parse(level5LeftScore.Text) - 1).ToString();
                if (level5LeftScore.Text == "0")
                {
                    level5Choose.BackColor = Color.Gray;
                    level5Choose.Enabled = false;
                }
            }
        }

        private void level6Choose_Click(object sender, EventArgs e)
        {
            if (level6LeftScore.Text != "0")
            {
                level6LeftScore.Text = (int.Parse(level6LeftScore.Text) - 1).ToString();
                if (level6LeftScore.Text == "0")
                {
                    level6Choose.BackColor = Color.Gray;
                    level6Choose.Enabled = false;
                }
            }
        }

        private void level7Choose_Click(object sender, EventArgs e)
        {
            if (level7LeftScore.Text != "0")
            {
                level7LeftScore.Text = (int.Parse(level7LeftScore.Text) - 1).ToString();
                if (level7LeftScore.Text == "0")
                {
                    level7Choose.BackColor = Color.Gray;
                    level7Choose.Enabled = false;
                }
            }
        }

        private void level8Choose_Click(object sender, EventArgs e)
        {
            if (level8LeftScore.Text != "0")
            {
                level8LeftScore.Text = (int.Parse(level8LeftScore.Text) - 1).ToString();
                if (level8LeftScore.Text == "0")
                {
                    level8Choose.BackColor = Color.Gray;
                    level8Choose.Enabled = false;
                }
            }
        }

        private void level9Choose_Click(object sender, EventArgs e)
        {
            if (level9LeftScore.Text != "0")
            {
                level9LeftScore.Text = (int.Parse(level9LeftScore.Text) - 1).ToString();
                if (level9LeftScore.Text == "0")
                {
                    level9Choose.BackColor = Color.Gray;
                    level9Choose.Enabled = false;
                }
            }
        }

        private void usePointsButton_Click(object sender, EventArgs e)
        {
            if (kiPointsValue.Text != "0")
            {
                kiPointsValue.Text = (int.Parse(kiPointsValue.Text) - 1).ToString();
                if (kiPointsValue.Text == "0")
                {
                    usePointsButton.BackColor = Color.Gray;
                    usePointsButton.Enabled = false;
                }
            }
        }

        private void useSlotButton_Click(object sender, EventArgs e)
        {
            if (WarlockSpellSlots.Text != "0")
            {
                WarlockSpellSlots.Text = (int.Parse(WarlockSpellSlots.Text) - 1).ToString();
                if (WarlockSpellSlots.Text == "0")
                {
                    useSlotButton.BackColor = Color.Gray;
                    useSlotButton.Enabled = false;
                }
            }
        }

        private void castSpellButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                statPanel.Visible = false;
                combatPanel.Visible = false;
                magicPanel.Visible = true;
                inventoryPanel.Visible = false;
                backgroundPanel.Visible = false;
                quitNSavePanel.Visible = false;

                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                castSpellButton.Enabled = false;
                castSpellButton.BackColor = Color.Gray;
                checkActions();
            }
        }
    
        private void attackButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                attackButton.BackColor = Color.Gray;
                attackButton.Enabled = false;
                checkActions();
            }
        }

        private void checkActions()
        {
            if (remainingActionsScore.Text == "0")
            {
                attackButton.BackColor = Color.Gray;
                attackButton.Enabled = false;
                castSpellButton.BackColor = Color.Gray;
                castSpellButton.Enabled = false;
                dashButton.BackColor = Color.Gray;
                dashButton.Enabled = false;
                disengageButton.BackColor = Color.Gray;
                disengageButton.Enabled = false;
                dodgeButton.BackColor = Color.Gray;
                dodgeButton.Enabled = false;
                helpButton.BackColor = Color.Gray;
                helpButton.Enabled = false;
                hideButton.BackColor = Color.Gray;
                hideButton.Enabled = false;
                readyButton.BackColor = Color.Gray;
                readyButton.Enabled = false;
                searchButton.BackColor = Color.Gray;
                searchButton.Enabled = false;
                useObjectButton.BackColor = Color.Gray;
                useObjectButton.Enabled = false;
                grappleButton.BackColor = Color.Gray;
                grappleButton.Enabled = false;
                useClassFeatureButton.BackColor = Color.Gray;
                useClassFeatureButton.Enabled = false;
                shoveButton.BackColor = Color.Gray;
                shoveButton.Enabled = false;
                improvButton.BackColor = Color.Gray;
                improvButton.Enabled = false;
            }
        }

        private void disengageButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                disengageButton.BackColor = Color.Gray;
                disengageButton.Enabled = false;
                checkActions();
            }
        }

        private void dodgeButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                dodgeButton.BackColor = Color.Gray;
                dodgeButton.Enabled = false;
                checkActions();
            }
        }

        private void helpButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                helpButton.BackColor = Color.Gray;
                helpButton.Enabled = false;
                checkActions();
            }
        }
        private void hideButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                hideButton.BackColor = Color.Gray;
                hideButton.Enabled = false;
                checkActions();
            }
        }

        private void readyButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                readyButton.BackColor = Color.Gray;
                readyButton.Enabled = false;
                checkActions();
            }
        }

        private void searchButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                searchButton.BackColor = Color.Gray;
                searchButton.Enabled = false;
                checkActions();
            }
        }

        private void useObjectButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                useObjectButton.BackColor = Color.Gray;
                useObjectButton.Enabled = false;
                checkActions();
            }
        }

        private void grappleButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                grappleButton.BackColor = Color.Gray;
                grappleButton.Enabled = false;
                checkActions();
            }
        }

        private void useClassFeatureButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                useClassFeatureButton.BackColor = Color.Gray;
                useClassFeatureButton.Enabled = false;
                checkActions();
            }
        }

        private void shoveButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                shoveButton.BackColor = Color.Gray;
                shoveButton.Enabled = false;
                checkActions();
            }
        }

        private void improvButton_Click_1(object sender, EventArgs e)
        {
            if (remainingActionsScore.Text != "0")
            {
                remainingActionsScore.Text = (int.Parse(remainingActionsScore.Text) - 1).ToString();
                improvButton.BackColor = Color.Gray;
                improvButton.Enabled = false;
                checkActions();
            }
        }

        private void bonusActionButton_Click_1(object sender, EventArgs e)
        {
            if (remainingBonusScore.Text != "0")
            {
                remainingBonusScore.Text = (int.Parse(remainingBonusScore.Text) - 1).ToString();
                if (remainingBonusScore.Text == "0")
                {
                    bonusActionButton.BackColor = Color.Gray;
                    bonusActionButton.Enabled = false;
                }
            }
        }

        private void actionsResetButton_Click_1(object sender, EventArgs e)
        {
            attackButton.BackColor = Color.Orange;
            attackButton.Enabled = true;
            castSpellButton.BackColor = Color.Orange;
            castSpellButton.Enabled = true;
            dashButton.BackColor = Color.Orange;
            dashButton.Enabled = true;
            disengageButton.BackColor = Color.Orange;
            disengageButton.Enabled = true;
            dodgeButton.BackColor = Color.Orange;
            dodgeButton.Enabled = true;
            helpButton.BackColor = Color.Orange;
            helpButton.Enabled = true;
            hideButton.BackColor = Color.Orange;
            hideButton.Enabled = true;
            readyButton.BackColor = Color.Orange;
            readyButton.Enabled = true;
            searchButton.BackColor = Color.Orange;
            searchButton.Enabled = true;
            useObjectButton.BackColor = Color.Orange;
            useObjectButton.Enabled = true;
            grappleButton.BackColor = Color.Orange;
            grappleButton.Enabled = true;
            useClassFeatureButton.BackColor = Color.Orange;
            useClassFeatureButton.Enabled = true;
            shoveButton.BackColor = Color.Orange;
            shoveButton.Enabled = true;
            improvButton.BackColor = Color.Orange;
            improvButton.Enabled = true;
            bonusActionButton.BackColor = Color.SlateBlue;
            bonusActionButton.Enabled = true;
            remainingActionsScore.Text = determineActions();
            remainingBonusScore.Text = determineBonusActions();
            speedScore.Text = unchangingSpeedScore.Text;
        }
        
        private void shortRestButton_Click_1(object sender, EventArgs e)
        {
            ShortRestForm form = new ShortRestForm(hitPointsMeter.Value, hitPointsMeter.Maximum, int.Parse(hitDiceScore.Text), char_Class.Text.ToString());
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                int[] resultsOfShortRest = form.getResults();
                hitPointsMeter.Value = resultsOfShortRest[0];
                hitDiceScore.Text = resultsOfShortRest[1].ToString();

                if (char_Class.Text.ToLower() == "warlock" || char_Class.Text.ToLower() == "monk")
                {
                    determineSpellSlots();
                    if (char_Class.Text.ToLower() == "warlock")
                    {

                    }
                }
            }
            form.Close();
            form.Dispose();
        }

        private void longRestButton_Click_1(object sender, EventArgs e)
        {
            if (hitPointsMeter.Value >= 1)
            {
                hitPointsMeter.Value = hitPointsMeter.Maximum;
                hitDiceScore.Text = unchangingHitDice.Text;
                determineSpellSlots();
                enableTheSpellSlots();
            }
        }

        private void levelUpButton_Click_1(object sender, EventArgs e)
        {
            if (int.Parse(currentLevelValue.Text) + 1 <= 20 || int.Parse(currentLevelValue.Text) != 20)
            {
                //determine next level up
                currentLevelValue.Text = (int.Parse(currentLevelValue.Text) + 1).ToString();
                nextXpValue.Text = determineNextLevelXp(currentLevelValue.Text);

                //determine level up traits
                determineClassTraits();
                determineSpellSlots();

                //TODO: form for choosing stuff? 
                int hitDie = 0;
                switch (char_Class.Text.ToLower())
                {
                    case "barbarian":
                        hitDie = 12;
                        break;
                    case "fighter":
                    case "paladin":
                    case "Ranger":
                        hitDie = 10;
                        break;
                    case "bard":
                    case "cleric":
                    case "druid":
                    case "monk":
                    case "rogue":
                    case "warlock":
                        hitDie = 8;
                        break;
                    case "sorcerer":
                    case "wizard":
                        hitDie = 6;
                        break;
                    default:
                        break;
                }
                hitDie = hitDie + 1;
                Random randy = new Random();
                int Increase = randy.Next(1, hitDie) + int.Parse(ConstitutionMod.Text);
                hitPointsMeter.Maximum = hitPointsMeter.Maximum + Increase;
                hitPointsMeter.Value = hitPointsMeter.Maximum;

                //increase amount of hit die
                hitDiceScore.Text = currentLevelValue.Text;
                unchangingHitDice.Text = currentLevelValue.Text;
            }
            if (nextXpValue.Text != "N/A")
            {
                if (int.Parse(nowXpValue.Text) < int.Parse(nextXpValue.Text))
                {
                    levelUpButton.Enabled = false;
                    levelUpButton.BackColor = Color.Gray;
                }
            }
            if (nextXpValue.Text == "N/A")
            {
                levelUpButton.Enabled = false;
                levelUpButton.BackColor = Color.Gray;
                addXpButton.Enabled = false;
                addXpButton.BackColor = Color.Gray;
            }
        }

        private void determineClassTraits()
        {
            switch (char_Class.Text.ToLower())
            {
                case "barbarian":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Rage (2 uses), Unarmored Defense, ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Reckless Attack, Danger Sense, ";
                            break;
                        case 3:
                            ClassTraits.Text = ClassTraits.Text + "Rage (3 uses), Primal Path, ";
                            break;
                        case 4:
                            improveAbilityScores();
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Extra Attack, Fast Movement, ";
                            break;
                        case 6:
                            ClassTraits.Text = ClassTraits.Text + "Rage (4 uses), Path Feature, ";
                            break;
                        case 7:
                            ClassTraits.Text = ClassTraits.Text + "Feral Instinct, ";
                            break;
                        case 8:
                            improveAbilityScores();
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Brutal Critical (1 die), ";
                            break;
                        case 10:
                            ClassTraits.Text = ClassTraits.Text + "Pather Feature 2, ";
                            break;
                        case 11:
                            ClassTraits.Text = ClassTraits.Text + "Relentless Rage, ";
                            break;
                        case 12:
                            ClassTraits.Text = ClassTraits.Text + "Rage (5 uses), ";
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Brutal Critical (2 dice), ";
                            break;
                        case 14:
                            ClassTraits.Text = ClassTraits.Text + "Path Feature 3, ";
                            break;
                        case 15:
                            ClassTraits.Text = ClassTraits.Text + "Persistent Rage, ";
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Rage (6 uses), Brutal Critical (3 dice), ";
                            break;
                        case 18:
                            ClassTraits.Text = ClassTraits.Text + "indomitable Might, ";
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "Rage (Unlimited uses), Primal Champion, ";
                            break;
                        default:
                            break;
                    }
                    break;
                case "fighter":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Fighting Style, Second Wind, ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Action Surge (one use), ";
                            break;
                        case 3:
                            ClassTraits.Text = ClassTraits.Text + "Martial Archetype, ";
                            break;
                        case 4:
                            improveAbilityScores();
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Extra Attack 1, ";
                            break;
                        case 6:
                            improveAbilityScores();
                            break;
                        case 7:
                            ClassTraits.Text = ClassTraits.Text + "Martial Archetype Feature 1, ";
                            break;
                        case 8:
                            improveAbilityScores();
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "indomitable (one use), ";
                            break;
                        case 10:
                            ClassTraits.Text = ClassTraits.Text + "Martial Archetype Feature 2, ";
                            break;
                        case 11:
                            ClassTraits.Text = ClassTraits.Text + "Extra Attack 2, ";
                            break;
                        case 12:
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Indomitable (2 uses), ";
                            break;
                        case 14:
                            improveAbilityScores();
                            break;
                        case 15:
                            ClassTraits.Text = ClassTraits.Text + "Martial Archetype Feature 3, ";
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Action Surge (2 uses), Indomitable (3 uses), ";
                            break;
                        case 18:
                            ClassTraits.Text = ClassTraits.Text + "Martial Archetype Feature 4, ";
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "Extra Attack 3, ";
                            break;
                        default:
                            break;
                    }
                    break;
                case "paladin":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Divine Sense, Lay on Hands, ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Fighting Style, Spellcasting, Divine Smite, ";
                            break;
                        case 3:
                            ClassTraits.Text = ClassTraits.Text + "Divine Health, Sacred Oath, ";
                            break;
                        case 4:
                            improveAbilityScores();
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Extra Attack, ";
                            break;
                        case 6:
                            ClassTraits.Text = ClassTraits.Text + "Aura Of Protection, ";
                            break;
                        case 7:
                            ClassTraits.Text = ClassTraits.Text + "Sacred Oath Feature 1, ";
                            break;
                        case 8:
                            improveAbilityScores();
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            break;
                        case 10:
                            ClassTraits.Text = ClassTraits.Text + "Aura of Courage, ";
                            break;
                        case 11:
                            ClassTraits.Text = ClassTraits.Text + "Improved Divine Smite, ";
                            break;
                        case 12:
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            break;
                        case 14:
                            ClassTraits.Text = ClassTraits.Text + "Cleansing Touch, ";
                            break;
                        case 15:
                            ClassTraits.Text = ClassTraits.Text + "Sacred Oath Feature 2, ";
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            break;
                        case 18:
                            ClassTraits.Text = ClassTraits.Text + "Aura Improvements, ";
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "Sacred Oath feature 3, ";
                            break;
                        default:
                            break;
                    }
                    break;
                case "ranger":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Favored Enemy, Natural Explorer, ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Fighting style, Spellcasting, ";
                            break;
                        case 3:
                            ClassTraits.Text = ClassTraits.Text + "Ranger Archetype, Primeval Awareness, ";
                            break;
                        case 4:
                            improveAbilityScores();
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Extra Attack, ";
                            break;
                        case 6:
                            ClassTraits.Text = ClassTraits.Text + "Favored Enemy improvement 1, Natural Explorer Improvement 1, ";
                            break;
                        case 7:
                            ClassTraits.Text = ClassTraits.Text + "Ranger Archetype Feature 1, ";
                            break;
                        case 8:
                            improveAbilityScores();
                            ClassTraits.Text = ClassTraits.Text + "Land's Stride, ";
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            break;
                        case 10:
                            ClassTraits.Text = ClassTraits.Text + "Natural Explorer Improvement 2, Hide in plain sight, ";
                            break;
                        case 11:
                            ClassTraits.Text = ClassTraits.Text + "Ranger Archetype Feature 2, ";
                            break;
                        case 12:
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            break;
                        case 14:
                            ClassTraits.Text = ClassTraits.Text + "Favored Enemy Improvement 2, Vanish, ";
                            break;
                        case 15:
                            ClassTraits.Text = ClassTraits.Text + "Ranger Archetype Feature 3, ";
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            break;
                        case 18:
                            ClassTraits.Text = ClassTraits.Text + "Feral Senses, ";
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "Foe Slayer, ";
                            break;
                        default:
                            break;
                    }
                    break;
                case "bard":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Spellcasting, Bardic Inspiration(d6), ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Jack of all Trades, Song of Rest (d6), ";
                            break;
                        case 3:
                            ClassTraits.Text = ClassTraits.Text + "Bard College, Expertise, ";
                            break;
                        case 4:
                            improveAbilityScores();
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Bardic Inspiration (d8), Font of Inspiration, ";
                            break;
                        case 6:
                            ClassTraits.Text = ClassTraits.Text + "Countercharm, Bard College Feature, ";
                            break;
                        case 7:
                            break;
                        case 8:
                            improveAbilityScores();
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Song of Rest, ";
                            break;
                        case 10:
                            ClassTraits.Text = ClassTraits.Text + "Bardic Inspiration (d10), Expertise, Magical Secrets, ";
                            break;
                        case 11:
                            break;
                        case 12:
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Song of Rest (d10), ";
                            break;
                        case 14:
                            ClassTraits.Text = ClassTraits.Text + "Magical Secrets, Bard College Feature 2, ";
                            break;
                        case 15:
                            ClassTraits.Text = ClassTraits.Text + "Bardic Inspiration (d12), ";
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Song of Rest (d12), ";
                            break;
                        case 18:
                            ClassTraits.Text = ClassTraits.Text + "Magical Secrets, ";
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "Superior Inspiration, ";
                            break;
                        default:
                            break;
                    }
                    break;
                case "cleric":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Spellcasting, Divine Domain, ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Channel Divinity (1/rest), Divine Domain Feature, ";
                            break;
                        case 3:
                            break;
                        case 4:
                            improveAbilityScores();
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Destroy Undead (CR 1/2), ";
                            break;
                        case 6:
                            ClassTraits.Text = ClassTraits.Text + " Channel Divinity (2/rest), Divine Domain Feature, ";
                            break;
                        case 7:
                            break;
                        case 8:
                            improveAbilityScores();
                            ClassTraits.Text = ClassTraits.Text + "Destroy Undead (CR 1), Divine Domain Feature, ";
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            break;
                        case 10:
                            ClassTraits.Text = ClassTraits.Text + "Divine Intervention, ";
                            break;
                        case 11:
                            ClassTraits.Text = ClassTraits.Text + "Destroy Undead (CR 2), ";
                            break;
                        case 12:
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            break;
                        case 14:
                            ClassTraits.Text = ClassTraits.Text + "Destroy Undead (CR 3), ";
                            break;
                        case 15:
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Destroy Undead (CR 4), Divine Domain Feature, ";
                            break;
                        case 18:
                            ClassTraits.Text = ClassTraits.Text + "Channel Divinity (3/rest), ";
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "Divine Intervention Improvement, ";
                            break;
                        default:
                            break;
                    }
                    break;
                case "druid":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Druidic, Spellcasting, ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Wild Shape, Druidic Circle, ";
                            break;
                        case 3:
                            break;
                        case 4:
                            improveAbilityScores();
                            ClassTraits.Text = ClassTraits.Text + "Wild Shape Improvement 1, ";
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            break;
                        case 6:
                            ClassTraits.Text = ClassTraits.Text + "Druidic Circle Feature 1, ";
                            break;
                        case 7:
                            break;
                        case 8:
                            improveAbilityScores();
                            ClassTraits.Text = ClassTraits.Text + "Wild Shape Improvement 2, ";
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            break;
                        case 10:
                            ClassTraits.Text = ClassTraits.Text + "Druid Circle Feature 2, ";
                            break;
                        case 11:
                            break;
                        case 12:
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            break;
                        case 14:
                            ClassTraits.Text = ClassTraits.Text + "Druid Circle Feature 3, ";
                            break;
                        case 15:
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            break;
                        case 18:
                            ClassTraits.Text = ClassTraits.Text + "Timeless Body, Beast Spells, ";
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "ArchDruid, ";
                            break;
                        default:
                            break;
                    }
                    break;
                case "monk":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Martial Arts (1d4), Unarmored Defense, ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Ki, Unarmored Movement (+ 10 ft), ";
                            break;
                        case 3:
                            ClassTraits.Text = ClassTraits.Text + "Monastic Tradition, Deflect Missiles, ";
                            break;
                        case 4:
                            improveAbilityScores();
                            ClassTraits.Text = ClassTraits.Text + "Slow Fall, ";
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Martial Arts (1d6), Extra Attack, Stunning Strike, ";
                            break;
                        case 6:
                            ClassTraits.Text = ClassTraits.Text + "Ki-Empowered Strikes, Monastic Tradition Feature 1, Unarmored Movement (+15 ft), ";
                            break;
                        case 7:
                            ClassTraits.Text = ClassTraits.Text + "Evasion, Stillness of Mind, ";
                            break;
                        case 8:
                            improveAbilityScores();
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Unarmored Movement Improvement, ";
                            break;
                        case 10:
                            ClassTraits.Text = ClassTraits.Text + "Purity of Body, Unarmored Movement (+ 20 ft), ";
                            break;
                        case 11:
                            ClassTraits.Text = ClassTraits.Text + "Martial Arts (1d8), Monastic Tradition Feature 2, ";
                            break;
                        case 12:
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Tongue of the Sun and Moon, ";
                            break;
                        case 14:
                            ClassTraits.Text = ClassTraits.Text + "Unarmored Movement (+ 25 ft), Diamond Soul, ";
                            break;
                        case 15:
                            ClassTraits.Text = ClassTraits.Text + "Timeless Body, ";
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Martial Arts (1d10), Monastic Tradition Feature 3, ";
                            break;
                        case 18:
                            ClassTraits.Text = ClassTraits.Text + "Empty Body, Unarmored Movement (+ 30 ft), ";
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "Perfect Self, ";
                            break;
                        default:
                            break;
                    }
                    break;
                case "rogue":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Sneak Attack (1d6), Expertise, Thieve's Cant, ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Cunning Action, ";
                            break;
                        case 3:
                            ClassTraits.Text = ClassTraits.Text + "Roguish Archetype, ";
                            break;
                        case 4:
                            improveAbilityScores();
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Uncanny Dodge, ";
                            break;
                        case 6:
                            ClassTraits.Text = ClassTraits.Text + "Expertise, ";
                            break;
                        case 7:
                            ClassTraits.Text = ClassTraits.Text + "Evasion, ";
                            break;
                        case 8:
                            improveAbilityScores();
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Roguish Archetype Feature 1, ";
                            break;
                        case 10:
                            improveAbilityScores();
                            break;
                        case 11:
                            ClassTraits.Text = ClassTraits.Text + "Reliable Talent, ";
                            break;
                        case 12:
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Roguish Archetype Feature 2, ";
                            break;
                        case 14:
                            ClassTraits.Text = ClassTraits.Text + "Blindsense, ";
                            break;
                        case 15:
                            ClassTraits.Text = ClassTraits.Text + "Slippery Mind, ";
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Roguish Archetype feature 3, ";
                            break;
                        case 18:
                            ClassTraits.Text = ClassTraits.Text + "Elusive, ";
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "Stroke of Luck, ";
                            break;
                        default:
                            break;
                    }
                    break;
                case "warlock":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Otherworldy Patron, Pact Magic, ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Eldritch Invocations, ";
                            break;
                        case 3:
                            ClassTraits.Text = ClassTraits.Text + "Pact Boon, ";
                            break;
                        case 4:
                            improveAbilityScores();
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            break;
                        case 6:
                            ClassTraits.Text = ClassTraits.Text + ", ";
                            break;
                        case 7:
                            break;
                        case 8:
                            improveAbilityScores();
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            break;
                        case 10:
                            ClassTraits.Text = ClassTraits.Text + "Otherworldly Patron Feature 1, ";
                            break;
                        case 11:
                            ClassTraits.Text = ClassTraits.Text + "Mystic Arcanum (6th Level), ";
                            break;
                        case 12:
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Mystic Arcanum (7th Level), ";
                            break;
                        case 14:
                            ClassTraits.Text = ClassTraits.Text + "Otherworldy Patron Feature 2, ";
                            break;
                        case 15:
                            ClassTraits.Text = ClassTraits.Text + "Mystic Arcanum (8th Level), ";
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Mystic Arcanum (9th Level), ";
                            break;
                        case 18:
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "Eldritch Master, ";
                            break;
                        default:
                            break;
                    }
                    break;
                case "sorcerer":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Spellcasting, Sorcerous Origin, ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Font of Magic, ";
                            break;
                        case 3:
                            ClassTraits.Text = ClassTraits.Text + "Metamagic, ";
                            break;
                        case 4:
                            improveAbilityScores();
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            break;
                        case 6:
                            ClassTraits.Text = ClassTraits.Text + "Sorcerous origin Feature 1, ";
                            break;
                        case 7:
                            break;
                        case 8:
                            improveAbilityScores();
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            break;
                        case 10:
                            ClassTraits.Text = ClassTraits.Text + "Metamagic 2, ";
                            break;
                        case 11:
                            break;
                        case 12:
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            break;
                        case 14:
                            ClassTraits.Text = ClassTraits.Text + "Sorcerous origin Feature 2, ";
                            break;
                        case 15:
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            ClassTraits.Text = ClassTraits.Text + "Metamagic 3, ";
                            break;
                        case 18:
                            ClassTraits.Text = ClassTraits.Text + "Sorcerous origin Feature 3, ";
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "Sorcerous Restoration, ";
                            break;
                        default:
                            break;
                    }
                    break;
                case "wizard":
                    switch (int.Parse(currentLevelValue.Text))
                    {
                        case 1:
                            ClassTraits.Text = ClassTraits.Text + "Spellcasting, Arcane Recovery, ";
                            break;
                        case 2:
                            ClassTraits.Text = ClassTraits.Text + "Arcane Tradition, ";
                            break;
                        case 3:
                            break;
                        case 4:
                            improveAbilityScores();
                            break;
                        case 5:
                            levelUpProficiencyBonus();
                            break;
                        case 6:
                            ClassTraits.Text = ClassTraits.Text + "Arcane Tradition Feature 1, ";
                            break;
                        case 7:
                            break;
                        case 8:
                            improveAbilityScores();
                            break;
                        case 9:
                            levelUpProficiencyBonus();
                            break;
                        case 10:
                            ClassTraits.Text = ClassTraits.Text + "Arcane Tradition Feature 2, ";
                            break;
                        case 11:
                            break;
                        case 12:
                            improveAbilityScores();
                            break;
                        case 13:
                            levelUpProficiencyBonus();
                            break;
                        case 14:
                            ClassTraits.Text = ClassTraits.Text + "Arcane Tradition Feature 3, ";
                            break;
                        case 15:
                            break;
                        case 16:
                            improveAbilityScores();
                            break;
                        case 17:
                            levelUpProficiencyBonus();
                            break;
                        case 18:
                            ClassTraits.Text = ClassTraits.Text + "Spell Mastery, ";
                            break;
                        case 19:
                            improveAbilityScores();
                            break;
                        case 20:
                            ClassTraits.Text = ClassTraits.Text + "Signature Spell, ";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void improveAbilityScores()
        {
            AbilityScoreImproveForm form = new AbilityScoreImproveForm(StrengthScore.Text, DexterityScore.Text, IntelligenceScore.Text, ConstitutionScore.Text, WisdomScore.Text, CharismaScore.Text);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                //abilities
                string[] abScores = form.getResults();
                StrengthScore.Text = abScores[0];
                DexterityScore.Text = abScores[1];
                IntelligenceScore.Text = abScores[2];
                ConstitutionScore.Text = abScores[3];
                WisdomScore.Text = abScores[4];
                CharismaScore.Text = abScores[5];
                //modifiers
                CharismaMod.Text = getModifier(CharismaScore.Text);
                WisdomMod.Text = getModifier(WisdomScore.Text);
                ConstitutionMod.Text = getModifier(ConstitutionScore.Text);
                IntelligenceMod.Text = getModifier(IntelligenceScore.Text);
                DexterityMod.Text = getModifier(DexterityScore.Text);
                StrengthMod.Text = getModifier(StrengthScore.Text);

                //Skills
                string[] seperator = { ", " };
                string[] skillProfs = HiddenskillProficiencies.Text.Split(seperator, StringSplitOptions.None);
                assignSkills(skillProfs, int.Parse(profBonusScore.Text));

                //level up spellcasting stuff
                int spellAbilityModifier = getSpellMod(spellAbilityValue.Text);
                spellSaveDCValue.Text = (8 + spellAbilityModifier + int.Parse(profBonusScore.Text)).ToString();
                spellAttackBonusValue.Text = (spellAbilityModifier + int.Parse(profBonusScore.Text)).ToString();
            }
            form.Close();
            form.Dispose();
        }

        private int getSpellMod(string text)
        {
            switch (text)
            {
                case "Charisma":
                    return int.Parse(CharismaMod.Text);
                case "Intelligence":
                    return int.Parse(IntelligenceMod.Text);
                default: //wisdom
                    return int.Parse(WisdomMod.Text);
            }
        }

        private void levelUpProficiencyBonus()
        {
            int newProfBonus = int.Parse(profBonusScore.Text.Replace("+", "")) + 1;
            profBonusScore.Text = (int.Parse(profBonusScore.Text.Replace("+", "")) + 1).ToString();
            string[] seperator = { ", " };
            string[] savers = permanentAbilitySaves.Text.Split(seperator, StringSplitOptions.None);
            assignAbilitySaves(savers, newProfBonus);
        }

        private void yesQuitButton_Click_1(object sender, EventArgs e)
        {
            //save stuff to tables
            DnD_Character_ManagerDBDataSetTableAdapters.TreasureTableTableAdapter treasureTableAdapt =
                new DnD_Character_ManagerDBDataSetTableAdapters.TreasureTableTableAdapter();
            DnD_Character_ManagerDBDataSetTableAdapters.equipmentTableTableAdapter equipAdapt =
                new DnD_Character_ManagerDBDataSetTableAdapters.equipmentTableTableAdapter();
            DnD_Character_ManagerDBDataSetTableAdapters.spellsTableTableAdapter spelladapt =
                new DnD_Character_ManagerDBDataSetTableAdapters.spellsTableTableAdapter();
            DnD_Character_ManagerDBDataSetTableAdapters.weaponsNArmorTableTableAdapter weaponsAdapt =
                new DnD_Character_ManagerDBDataSetTableAdapters.weaponsNArmorTableTableAdapter();
            ///
            ///
            ///
            ///         FIX THIS!!!
            ///
            ///
            ///
            ///
            ///
            //TODO: FIX THIS!!!
            foreach (ListViewItem item in treasureList.Items)
            {
                //treasureTableAdapt.Delete(Convert.ToInt32(rowItems[0]), characterUniqueID.Text, item.SubItems[0].Text.ToString(), Convert.ToInt32(item.SubItems[1].Text), Convert.ToInt32(item.SubItems[2].Text), Convert.ToInt32(item.SubItems[3].Text));
                treasureTableAdapt.Insert(characterUniqueID.Text, item.SubItems[0].Text.ToString(), Convert.ToInt32(item.SubItems[1].Text), Convert.ToInt32(item.SubItems[2].Text), Convert.ToInt32(item.SubItems[3].Text));
            }

            foreach (ListViewItem item in equipmentNGearList.Items)
            {
                equipAdapt.Insert(characterUniqueID.Text, item.SubItems[0].Text.ToString(), Convert.ToInt32(item.SubItems[1].Text), item.SubItems[2].Text, Convert.ToInt32(item.SubItems[3].Text), Convert.ToInt32(item.SubItems[4].Text));
            }

            foreach (ListViewItem item in weaponsNArmorListview.Items)
            {
                weaponsAdapt.Insert(characterUniqueID.Text, item.SubItems[0].Text.ToString(), Convert.ToInt32(item.SubItems[1].Text), item.SubItems[2].Text, Convert.ToInt32(item.SubItems[3].Text), Convert.ToInt32(item.SubItems[4].Text));
            }

            foreach (ListViewItem item in spellList.Items)
            {
                spelladapt.Insert(characterUniqueID.Text, item.SubItems[0].Text.ToString(), Convert.ToInt32(item.SubItems[1].Text), item.SubItems[2].Text.ToString());
            }


            //save character to character table
            DnD_Character_ManagerDBDataSetTableAdapters.CharactersTableAdapter characterTableAdapter =
                new DnD_Character_ManagerDBDataSetTableAdapters.CharactersTableAdapter();
            var rowsFromCharTable = characterTableAdapter.GetData().Rows;
            foreach (DataRow row in rowsFromCharTable)
            {
                var rowItems = row.ItemArray;
                if (char_Name.Text == rowItems[1].ToString())
                {
                    //delete that old entry
                    characterTableAdapter.Delete(Convert.ToInt32(rowItems[0]), rowItems[1].ToString(),
                        rowItems[2].ToString(), rowItems[3].ToString(), Convert.ToInt32(rowItems[4]),
                        Convert.ToInt32(rowItems[5]), Convert.ToInt32(rowItems[6]), Convert.ToInt32(rowItems[7]),
                        Convert.ToInt32(rowItems[8]), Convert.ToInt32(rowItems[9]), Convert.ToInt32(rowItems[10]),
                        Convert.ToInt32(rowItems[11]), Convert.ToInt32(rowItems[12]), Convert.ToInt32(rowItems[13]),
                        Convert.ToInt32(rowItems[14]), Convert.ToInt32(rowItems[15]),
                        rowItems[16].ToString(), rowItems[19].ToString(), rowItems[20].ToString(), rowItems[21].ToString(),
                        rowItems[22].ToString(), rowItems[23].ToString(), rowItems[24].ToString(), Convert.ToInt32(rowItems[25]),
                        Convert.ToInt32(rowItems[26]), Convert.ToInt32(rowItems[27]), Convert.ToInt32(rowItems[28]), Convert.ToInt32(rowItems[29]),
                        rowItems[30].ToString(), Convert.ToInt32(rowItems[37]), Convert.ToInt32(rowItems[38]));

                    //enter a new one
                    characterTableAdapter.Insert(char_Name.Text, char_Race.Text, char_Class.Text,
                                int.Parse(currentLevelValue.Text), int.Parse(nowXpValue.Text), hitPointsMeter.Maximum, hitPointsMeter.Value,
                                int.Parse(currentLevelValue.Text), int.Parse(hitDiceScore.Text),
                                int.Parse(StrengthScore.Text), int.Parse(DexterityScore.Text), int.Parse(IntelligenceScore.Text),
                                int.Parse(ConstitutionScore.Text), int.Parse(CharismaScore.Text), int.Parse(WisdomScore.Text),
                                permanentAbilitySaves.Text, HiddenskillProficiencies.Text, proficienciesTextBox.Text, languagesTextBox.Text,
                                LHandEquip.Text, RHandEquip.Text, armorEquip.Text, otherEquippedTextBox.Text,
                                characterUniqueID.Text, int.Parse(copperValue.Text), int.Parse(silverValue.Text), int.Parse(electrumValue.Text),
                                int.Parse(goldValue.Text), int.Parse(platinumValue.Text), backgroundValue.Text, backstoryBox.Text, alliesNOrgBox.Text,
                                traitsBox.Text, idealsBox.Text, bondsBox.Text, flawsBox.Text, int.Parse(unchangingSpeedScore.Text), int.Parse(kiPointsValue.Text));
                }
            }
            Main_Menu menu = new Main_Menu();
            Close();
            Dispose();
            menu.Show();
        }

        private void noQuitButton_Click_1(object sender, EventArgs e)
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

        private void charactersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.charactersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dnD_Character_ManagerDBDataSet);

        }

        private void Character_Manager_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dnD_Character_ManagerDBDataSet.Characters' table. You can move, or remove it, as needed.
            this.charactersTableAdapter.Fill(this.dnD_Character_ManagerDBDataSet.Characters);

        }

        private void LHandEquip_TextChanged(object sender, EventArgs e)
        {
            //TODO: add more options?
            if (LHandEquip.Text.ToLower().Contains("shield"))
            {
                armorClassValue.Text = (Int32.Parse(armorClassValue.Text) + 2).ToString();
            }
        }

        private void RHandEquip_TextChanged(object sender, EventArgs e)
        {
            if (RHandEquip.Text.ToLower().Contains("shield"))
            {
                armorClassValue.Text = (Int32.Parse(armorClassValue.Text) + 2).ToString();
            }
        }

        private void combatPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quickReferences_Click(object sender, EventArgs e)
        {
            QuickReferences qrForm = new QuickReferences();
            if (qrForm.ShowDialog(this) == DialogResult.OK)
            {
               //do something...
            }
        }
    }
}
