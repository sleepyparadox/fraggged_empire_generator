using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraggedEmpireGenerator.Definitions
{
    public class WeaponDefinition : IDefinition
    {
        public WeaponDefinition(string name, params WeaponType[] weaponTypes) 
        {
            Name = name;
            WeaponTypes = new List<WeaponType>(weaponTypes);
            Traits = new List<ITraitValue>();
        }

        public WeaponDefinition AddTraits(params ITraitValue[] traits)
        {
            Traits.AddRange(traits);
            return this;
        }

        public string Name;
        public int HitDice;
        public int Hit;
        public int Range;
        public int EndDmg;
        public int CritDmg;
        public List<WeaponType> WeaponTypes;
        public int AquireKnowledge;
        public int AquireTime;
        public int Resources;
        public List<ITraitValue> Traits;

        public override string ToString()
        {
            return Name;
        }
    }
}
