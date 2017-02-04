using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Class_Library
{
    abstract public class DnDClass
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DnDClass() { }

        abstract public string Name { get; set; }
        abstract public int HitDie { get; set; }
        abstract public string ArmorProf { get; set; }
        abstract public string WeaponProf { get; set; }
        abstract public string ToolProf { get; set; }
        abstract public string SavingThrow { get; set; }
        abstract public string Skills { get; set; }
        abstract public List<string> StartingEquipChoices { get; set; }
        abstract public List<string> StartingEquipMandatory { get; set; }
        abstract public bool DoesSpellCasting { get; set; }
    }

    public class Barbarian : DnDClass
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Barbarian()
        {
            Name = "Barbarian";
            HitDie = 12;
        }

        public override string ArmorProf
        {
            get
            {
                return ArmorProf;
            }

            set
            {
                ArmorProf = value;
            }
        }

        public override bool DoesSpellCasting
        {
            get
            {
                return DoesSpellCasting;
            }

            set
            {
                DoesSpellCasting = value;
            }
        }

        public override int HitDie
        {
            get
            {
                return HitDie;
            }

            set
            {
                HitDie = value;
            }
        }

        public override string Name
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }

        public override string SavingThrow
        {
            get
            {
                return SavingThrow;
            }

            set
            {
                
            }
        }

        public override string Skills
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override List<string> StartingEquipChoices
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override List<string> StartingEquipMandatory
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override string ToolProf
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override string WeaponProf
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
