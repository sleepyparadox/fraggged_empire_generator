using FraggedEmpireGenerator.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraggedEmpireGenerator.Tables.Weapons
{
    public class SmallArms : DefinitionTable<WeaponDefinition>
    {
        public static readonly WeaponDefinition Pistol = new WeaponDefinition("Pistol", WeaponType.Gun)
            { HitDice = 3, Hit = 1, Range = 3, EndDmg = 0, CritDmg = 3, AquireTime = 8, Resources = 1 }
            .AddTraits(WeaponTraits.Sidearm, WeaponTraits.Small, WeaponTraits.Handed.WithValue(1), WeaponTraits.AttackWithReposition, WeaponTraits.MaxRange.WithValue(30) );

        public static readonly WeaponDefinition SubmachineGun = new WeaponDefinition("Submachine Gun (SMG)", WeaponType.Gun)
            { HitDice = 4, Hit = 0, Range = 3, EndDmg = 1, CritDmg = 3, AquireTime = 12, Resources = 2 }
            .AddTraits(WeaponTraits.Small, WeaponTraits.MunitionBoost.WithValue(1), WeaponTraits.MaxRange.WithValue(30));

        public static readonly WeaponDefinition ShotgunGun = new WeaponDefinition("Shotgun (Gun)", WeaponType.Gun)
            { HitDice = 3, Hit = 2, Range = 2, EndDmg = 2, CritDmg = 3, AquireTime = 10, Resources = 2 }
            .AddTraits(WeaponTraits.StrongHitFirstIncrement, WeaponTraits.MaxRange.WithValue(30));

        public static readonly WeaponDefinition ShotgunShell = new WeaponDefinition("Shotgun (Shell)", WeaponType.Shell)
            { HitDice = 3, Hit = 2, Range = 2, EndDmg = 2, CritDmg = 3, AquireTime = 10, Resources = 2 }
            .AddTraits(WeaponTraits.StrongHitFirstIncrement, WeaponTraits.MaxRange.WithValue(30));

        public static readonly WeaponDefinition Rifle = new WeaponDefinition("Rifle", WeaponType.Shell)
            { HitDice = 2, Hit = 2, Range = 6, EndDmg = 0, CritDmg = 4, AquireTime = 12, Resources = 2 }
            .AddTraits(WeaponTraits.StrongHit, WeaponTraits.HenchmanExtraCost1);
    }

}
