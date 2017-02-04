using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Class_Library
{
    public class Trait
    { 
        public string name { get; set; }
        public string description { get; set; }
    }
    public class Darkvision : Trait
    {
        public Darkvision()
        {
            name = "Darkvision";
            description = "Accustomed to life underground, "
                + "you have superior vision in dark and dim conditions. "
                + "You can see in dim light within 60 feet of you as if "
                + "it were bright light, and in darkness as if it were dim light. "
                + "You can't discern color in darkness, only shades of gray.";
        }
    }
    public class DwarvenResilience : Trait
    {
        public DwarvenResilience()
        {
            name = "Dwarven Resilience";
            description = "You have advantage on saving throws "
                + "against poison, and you have resistance against poison damage.";
        }
    }
    public class ToolProficiency : Trait
    {
        public ToolProficiency()
        {
            name = "Tool Proficiency";
            description = "You gain proficiency with the artisan's tools "
                + "of your choice: smith's tools, brewer's supplies, "
                + "or mason's tools.";
        }
    }
    public class StoneCunning : Trait
    {
        public StoneCunning()
        {
            name = "Stonecunning";
            description = "Whenever you make an Intelligence (History) "
                + "check related to the origin of stonework, you are "
                + "considered proficient in the History skill and add "
                + "double your proficiency bonus to the check, instead "
                + "of your normal proficiency bonus.";
        }
    }
    public class DwarvenToughness : Trait
    {
        public DwarvenToughness()
        {
            name = "Dwarven Toughness";
            description = "Your hit point maximum increases by 1, "
                + "and it increases by 1 every time you gain a leveI.";
        }
    }

    public class FeyAncestry : Trait
    {
        public FeyAncestry()
        {
            name = "Fey Ancestry";
            description = "You have advantage on saving throws against being "
                + "charmed, and magic can't put you to sleep.";
        }
    }
    public class Trance : Trait
    {
        public Trance()
        {
            name = "Trance";
            description = "Elves don't need to sleep. Instead, they meditate deeply, "
                + "remaining semiconscious, for 4 hours a day. While meditating, you can "
                + "dream after a fashion; such dreams are actually mental exercises that "
                + "have become reflexive through years of practice. After resting in this "
                + "way, you gain the same benefit that a human does from 8 hours of sleep.";
        }
    }
    public class CantripHighElf : Trait
    {
        public CantripHighElf()
        {
            name = "Cantrip";
            description = "You know one cantrip of your choice from the wizard spell "
                + "list. Intelligence is your spellcasting ability for it.";
        }
    }

    public class ExtraLanguage : Trait
    {
        public ExtraLanguage()
        {
            name = "Extra Language";
            description = "You can speak, read, and write one extra language of your choice.";
        }
    }

    public class FleetOfFoot : Trait
    {
        public FleetOfFoot()
        {
            name = "Fleet Of Foot";
            description = "Your base walking speed increases to 35 feet.";
        }
    }

    public class MaskOfTheWild : Trait
    {
        public MaskOfTheWild()
        {
            name = "Mask Of The Wild";
            description = "You can attempt to hide even when you are only lightly obscured "
                + "by foliage, heavy rain, falling snow, mist, and other natural phenomena.";
        }
    }

    public class SuperiorDarkvision : Trait
    {
        public SuperiorDarkvision()
        {
            name = "Superior Darkvision";
            description = "Your darkvision has a radius of 120 ft";
        }
    }

    public class SunlightSensitivity : Trait
    {
        public SunlightSensitivity()
        {
            name = "Sunlight Sensitivity";
            description = "You have disadvantage on attack rolls and on Wisdom (Perception) "
                + "checks that rely on sight when you, the target of your attack, or whatever "
                + "you are trying to perceive is in direct sunlight.";
        }
    }

    public class DrowMagic : Trait
    {
        public DrowMagic()
        {
            name = "Drow Magic";
            description = "You know the dancing lights cantrip. when you reach 3rd level, "
                + "you can cast the faerie fire spell once per day. When you reach 5th level, "
                + "you can also cast the darkness spell once per day. Charisma is your spellcasting "
                + "ability for these spells.";
        }
    }

    public class Lucky : Trait
    {
        public Lucky()
        {
            name = "Lucky";
            description = "When you roll a 1 on an attack roll, ability check, or saving throw, you can reroll the die and must use the new roll.";
        }
    }

    public class Brave : Trait
    {
        public Brave()
        {
            name = "Brave";
            description = "You have advantage on saving throws against being frightened.";
        }
    }

    public class HalflingNimbleness : Trait
    {
        public HalflingNimbleness()
        {
            name = "Halfling Nimbleness";
            description = "You can move through the space of any creature that is of a size larger than yours.";
        }
    }

    public class NaturallyStealthy : Trait
    {
        public NaturallyStealthy()
        {
            name = "Naturally Stealthy";
            description = "You can attempt to hide even when you are obscured only by a creature that is at least one size larger than you.";
        }
    }

    public class StoutResilience : Trait
    {
        public StoutResilience()
        {
            name = "Stout Resilience";
            description = "You have advantage on saving throws against poison, and you have resistance against poison damage.";
        }
    }

    public class DraconicAncestry : Trait
    {
        public DraconicAncestry()
        {
            name = "Draconic Ancestry";
            description = "Choose one type of dragon from the Draconic ancestry table. Your breath weapon and damage resistance are determined by the dragon type.";
        }
    }

    public class BreathWeapon : Trait
    {
        public BreathWeapon()
        {
            name = "Breath Weapon";
            description = "You can use your action to exhale destructive energy. Damage type and saving throw are determined by your draconic ancestry. " +
                "The DC for this saving throw equals 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and " + 
                "half as much damage on a successful one. The damage increases to 3d6 at 6th level, 4d6 at 11th level, and 5d6 at 16th level. To use again you must short/long rest.";
        }
    }

    public class DraconicDamageResistance : Trait
    {
        public DraconicDamageResistance()
        {
            name = "Draconic Damage Resistance";
            description = "You have resistance to the damage type associated with your draconic ancestry.";
        }
    }
}
