using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Class_Library
{

    public class Race
    {
        public string description { get; set; }
        public List<AbilityScore> abilityScoreIncrease { get; set; }
        public int maxAge { get; set; }
        public string size { get; set; }
        public List<string> languages { get; set; }
        public int speed { get; set; }
        public List<Trait> traits { get; set; }
        public List<string> proficiencies { get; set; }
        public List<string> cantrips { get; set; }
    }
    /// <summary>
    //////////////////////////////////////////////////////////////////// DWARVES
    /// </summary>
    public class Dwarf : Race
    {
        public Dwarf()
        {
            description = "Bold and hardy, dwarves are known as skilled warriors, miners, "
                + "and workers of stone and metal. Though they stand well under 5 feet tall, "
                + "dwarves are so broad and compact that they can weigh as much as a human standing "
                + "nearly two feet taller. Their courage and endurance are also easily a match for "
                + "any of the larger folk. Dwarven skin ranges from deep brown to a paler hue tinged "
                + "with red, but the most common shades are light brown or deep tan, like certain "
                + "tones of earth. Their hair, worn long but in simple styles, is usually black, "
                + "gray, or brown, though paler dwarves often have red hair. Male dwarves value their "
                + "beards highly and groom them carefully. \n"
                + "Dwarves can live to be more than 400 years old, they respect the traditions of their "
                + "clans, holding honor above all. Dwarves are true to their word and decisive in action, "
                + "sometimes to the point of stubbornness. Dwarves have a strong sense of justice, and "
                + "are slow to forget the wrongs committed against them and their friends, even more to a clan member.";

            abilityScoreIncrease.Add(new AbilityScore("Constitution", 2));
            maxAge = 450;
            size = "medium";
            languages.Add("Common");
            languages.Add("Dwarvish");
            speed = 25;
            traits.Add(new Darkvision());
            traits.Add(new DwarvenResilience());
            traits.Add(new ToolProficiency());
            traits.Add(new StoneCunning());
            proficiencies.Add("battleaxe");
            proficiencies.Add("handaxe");
            proficiencies.Add("throwing hammer");
            proficiencies.Add("warhammer");
            //todo: add artisans tools choice to dwarven creation
        }
    }

    public class HillDwarf : Dwarf
    {
        public HillDwarf()
        {
            description += "\n As a hill dwarf, you have keen senses, deep intuition, "
                + "and remarkable resilience.";
            abilityScoreIncrease.Add(new AbilityScore("Wisdom", 1));
            traits.Add(new DwarvenToughness());
        }
    }
    public class MountainDwarf : Dwarf
    {
        public MountainDwarf()
        {
            description += "\n As a mountain dwarf, you're strong and hardy, "
                + "accustomed to a difficult life in rugged terrain. You're "
                + "probably on the tall side (for a dwarf), and tend toward "
                + "lighter coloration.";
            abilityScoreIncrease.Add(new AbilityScore("Strength", 2));
            proficiencies.Add("light armor");
            proficiencies.Add("medium armor");
        }
    }
    
    public class Elf : Race
    {
        public Elf()
        {
            description = "Elves are a magical people of otherworldy grace, "
                + "living in the world but not entirely part of it. They "
                + "live in places of ethereal beauty, in the midst of ancient "
                + "forests or in silvery spires glittering with faerie light, "
                + "where soft music drifts through the air and gentle fragrances "
                + "waft on the breeze. Elves love nature and magic, art and artistry "
                + "music and poetry, and the good things of the world. \n"
                + "Elves can live well over 700 years, giving them a broad perspective "
                + "on events that might trouble the shorter-lived races more deeply. "
                + "They are more often amused than excited, and more likely to be curious "
                + "than greedy. They tend to remain aloog and unfazed by petty happenstance. "
                + "when pursuing a goal, however, elves can be focused and relentless. "
                + "Slow to make friends and enemies, and even slower to forget them.";
            abilityScoreIncrease.Add(new AbilityScore("Dexterity", 2));
            maxAge = 1000;
            size = "medium";
            languages.Add("Common");
            languages.Add("Elvish");
            speed = 30;
            traits.Add(new Darkvision());
            traits.Add(new FeyAncestry());
            traits.Add(new Trance());
            proficiencies.Add("Perception");
        }
    }

    public class HighElf : Elf
    {
        public HighElf()
        {
            description += "\n As a high elf, you have a keen mind and a mastery of "
                        + "at least the basics of magic. There are two kinds of "
                        + "high elves, those who think themselves better than "
                        + "other races of the world (even other elves), who are "
                        + "haughty and reclusive. The other type are more common "
                        + "and more friendly, which are more often encountered "
                        + "among the other races.";
            abilityScoreIncrease.Add(new AbilityScore("Intelligence", 1));
            proficiencies.Add("longsword");
            proficiencies.Add("shortsword");
            proficiencies.Add("longbow");
            proficiencies.Add("shortbow");
            traits.Add(new CantripHighElf());
            traits.Add(new ExtraLanguage());
        }
    }

    public class WoodElf : Elf
    {
        public WoodElf()
        {
            description += "\n As a wood elf, you have keen senses and intuition, and "
                + "your feet carry you quickly and stealthily through your native forests.";
            abilityScoreIncrease.Add(new AbilityScore("Wisdom", 1));
            proficiencies.Add("longsword");
            proficiencies.Add("shortsword");
            proficiencies.Add("longbow");
            proficiencies.Add("shortbow");
            traits.Add(new FleetOfFoot());
            traits.Add(new MaskOfTheWild());
        }
    }

    public class DarkElf : Elf
    {
        public DarkElf()
        {
            description += "\n Descended from an earlier subrace of dark-skinned elves, the "
                + "drow were banished from the surface world for following the goddess Lolth "
                + "down the path to evil and corruption. Now they have built their own civilization "
                + "in the depths of the Underdark, patterned after the Way of Lolth. Also called "
                + "dark elves, the drow have black skin that resembles polished obsidian and stark "
                + "white or pale yellow hair. They commonly have very pale eyes, in shades of lilac, "
                + "silver, pink, red, and blue. They tend to be smaller and thinner than most elves. "
                + "Drow adventurers are rare. Mostly staying within the underdark.";
            abilityScoreIncrease.Add(new AbilityScore("Charisma", 1));
            proficiencies.Add("rapier");
            proficiencies.Add("shortsword");
            proficiencies.Add("hand crossbow");
            traits.Add(new SuperiorDarkvision());
            traits.Add(new SunlightSensitivity());
            traits.Add(new DrowMagic());
        }
    }

    public class Halfling : Race
    {
        public Halfling()
        {
            description = "The diminutive halfings survive in a world full of larger "
                + "creatures by avoiding notice or, barring that, avoiding offense. "
                + "standing about 3 feet tall, they appear relatively harmless and "
                + "so have managed to survive for centuries in the shadow of empires "
                + "and on the edges of wars and political strife. They are inclined "
                + "to be stout, weighing between 40 and 45 pounds. \n"
                + "Halfling men often sports long sideburns, but beards are rare among "
                + "them and mustaches even more so. They like to wear simple, comfortable, "
                + "and practical clothes, favoring bright colors. \n"
                + "Halflings are an affable and cheerful people. They cherish the bonds of "
                + "family and friendship as well as the comforts of hearth and home, "
                + "harboring few dreams of gold or glory. Even adventurers among them usually "
                + "venture into the world for reasons of community, friendship, wanderlust, "
                + "or curiosity. They love discovering new things, even simple things, "
                + "such as an exotic food or an unfamiliar style of clothing.\n"
                + "Halflings are easily moved to pity and hate to see any living thing "
                + "suffer. they are generous, happily sharing what they have even in lean times.";
            abilityScoreIncrease.Add(new AbilityScore("Dexterity", 2));
            maxAge = 250;
            size = "small";
            languages.Add("Common");
            languages.Add("Halfling");
            speed = 25;
            traits.Add(new Lucky());
            traits.Add(new Brave());
            traits.Add(new HalflingNimbleness());
        }
    }

    public class LightFootHalfling : Halfling
    {
        public LightFootHalfling()
        {
            description += "/n As a lightfoot halfing, you can easily hide from notice, "+
                "even using other peoplt as cover. You're inclined to be affable and get " +
                "along well with others. Lightfoots are more prone to wanderlust than other " +
                "halflings, and often dwell alongside other races or take up a nomadic life.";


            abilityScoreIncrease.Add(new AbilityScore("Charisma", 1));
            traits.Add(new NaturallyStealthy());
        }
    }

    public class StoutHalfling : Halfling
    {
        public StoutHalfling()
        {
            description += "/n As a stout halfling, you're hardier than average and " +
                "have some resistance to poison. Some say that stouts have dwarven blood.";
            abilityScoreIncrease.Add(new AbilityScore("Constitution", 1));
            traits.Add(new StoutResilience());
        }
    }

    public class Human : Race
    {
        public Human()
        {
            description = "Humans are the most adaptable and ambitious people" +
                        "among the common races. They have widely varying" +
                        "tastes, morals, and customs in the many different lands" +
                        "where they have settled. When they settle, though," +
                        "they stay: they build cities to last for the ages, and" +
                        "great kingdoms that can persist for long centuries. An" +
                        "individual human might have a relatively short life span," +
                        "but a human nation or culture preserves traditions" +
                        "with origins far beyond the reach of any single human's" +
                        "memory. They live fully in the present, making them" +
                        "well suited to the adventuring life but also plan for the"+
                        "future, striving to leave a lasting legacy.Individually and" +
                        "as a group, humans are adaptable opportunists, and" +
                        "they stay alert to changing political and social dynamics.";
            abilityScoreIncrease.Add(new AbilityScore("Strength", 1));
            abilityScoreIncrease.Add(new AbilityScore("Intelligence", 1));
            abilityScoreIncrease.Add(new AbilityScore("Constitution", 1));
            abilityScoreIncrease.Add(new AbilityScore("Dexterity", 1));
            abilityScoreIncrease.Add(new AbilityScore("Wisdom", 1));
            abilityScoreIncrease.Add(new AbilityScore("Charisma", 1));
            maxAge = 95;
            size = "medium";
            languages.Add("Common");
            //have an option for players to add one other language. provide choices.
            speed = 30;
        }
    }

    public class DragonBorn : Race
    {
        public DragonBorn()
        {
            description = "Dragonborn look very much like dragons standing erect " +
                            "in humanoid form, though they lack wings or a tail. The " +
                            "first dragonborn had scales of vibrant hues matching " +
                            "the colors of their dragon kin, but generations of " +
                            "interbreeding have created a more uniform appearance. " +
                            "Their small, fine scales are usually brass or bronze " +
                            "in color, sometimes ranging to scarlet, rust, gold, or " +
                            "copper-green. They are tall and strongly built, often " +
                            "standing close to 6 1/2 feet tall and weighing 300 pounds " +
                            "ar more. Their hands and feet are strong, talonlike " +
                            "claws with three fingers and a thumb on each hand. " +
                            "The blood of a particular type of dragon runs " +
                            "very strong through some dragonborn clans. These " +
                            "dragonborn often boast scales that more closely match " +
                            "those of their dragon ancestor-bright red, green, blue, " +
                            "or white, lustrous black, ar gleaming metallic gold, " +
                            "silver, brass, copper, or bronze.";
            abilityScoreIncrease.Add(new AbilityScore("Strength", 2));
            abilityScoreIncrease.Add(new AbilityScore("Charisma", 1));
            maxAge = 85;
            size = "medium";
            speed = 30;
            languages.Add("Common"); languages.Add("Draconic");
            traits.Add(new DraconicAncestry());
            traits.Add(new BreathWeapon());
            traits.Add(new DraconicDamageResistance());
        }
    }


}
