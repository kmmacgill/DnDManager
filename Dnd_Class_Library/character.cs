using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Class_Library
{
    class character
    {
        Race myRace { get; set; }
        DnDClass myClass { get; set; }
        int level { get; set; }
        int HitPoints { get; set; }
        int ArmorClass { get; set; }
        AbilityScore[] Ability_Scores { get; set; }
        int ProfBonus { get; set; }
        string alignment { get; set; }
        DnDObject[] inventory { get; set; }
        string[] ideals { get; set; }
        string[] bonds { get; set; }
        string[] flaws { get; set; }
        Background background { get; set; }
    }
}
