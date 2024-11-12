using FraggedEmpireGenerator.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraggedEmpireGenerator.Tables.Weapons
{
    public class WeaponTraits : DefinitionTable<Trait>
    {
        public static readonly Trait Sidearm = new Trait("Sidearm");
        public static readonly Trait Small = new Trait("Small");
        public static readonly Trait Handed = new Trait("Hands");
        public static readonly Trait StrongHit = new Trait("Strong Hit 5-6", "Strong hits are 5+");
        public static readonly Trait StrongHitFirstIncrement = new Trait("Strong Hit 5-6", "Strong hits are 5+, within first range increment");
        public static readonly Trait HenchmanExtraCost1 = new Trait("Strong Henchman Extra Cost 1", "+1 Resource cost for Henchment NPCs");
        public static readonly Trait AttackWithReposition = new Trait("May Attack with the Reposition Action");
        public static readonly Trait MaxRange = new Trait("Max Range");
        public static readonly Trait MunitionBoost = new Trait("Munition Boost", "Munition Boost (+{0}d6 Hit)");

    }
}
