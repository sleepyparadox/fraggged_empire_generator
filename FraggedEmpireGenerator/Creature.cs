using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FraggedEmpireGenerator
{
    public class Encounter
    {
        public List<Creature> Creatures = new List<Creature>();
    }

    public class Creature
    {
        public string GroupId;
        public List<Trait> Traits = new List<Trait>();

        public string Name = "Critter";
        public int HitBonus = 2;
        public int HitDice = 3;
        public int HitDmgEndurance = 3;
        public int HitDmgCritical = 3;
        public int HitRange = 3;
        public int DefBase = 10;
        public int DefEndurance = 20;
        public int DefDurability = 1;
        public int DefArmour = 2;
        public int Mobility = 5;
        public int Actions = 1;

        public Creature DeepCopy()
        {
            return JsonConvert.DeserializeObject<Creature>(JsonConvert.SerializeObject(this));
        }
    }

    public enum NPCType
    {
        HenchmenGroup,
        TroopGroup,
        Skilled,
        Nemesis,
    }

    public struct Trait
    {
        public string Name;
        public string Desc;
        public Trait(string name, string desc)
        {
            Name = name;
            Desc = desc;
        }
    }

    public static class Traits
    {
        public static class NPCType
        {
            public static readonly Trait HechmenDamage = new Trait("Hechmen Damage", "Each Attacking Body grants +1d6 Hit and +1 End Dmg");
            public static readonly Trait HechmenLackInitiative = new Trait("Hechmen Lack Initiative", "Always acts last in combat");
            public static readonly Trait HechmenSharedEndurance = new Trait("Hechmen Shared Endurance", "Hechmen share endurance pool");
            public static readonly Trait HechmenBodies = new Trait("Shared Bodies", "Each attacking body adds +1d6 Hit and +1 End Dmg");
            public static readonly Trait HechmenSharedAction = new Trait("Hechmen Shared Action", "Hechmen share 1 action per turn");
            public static readonly Trait NPCMunitions1 = new Trait("NPC Munitions (1)", "1 Munitions per turn per weapon.\nModifiers (reload / disrupt) only apply to current or next turn.\nReload +2M");
            public static readonly Trait NPCMunitions2 = new Trait("NPC Munitions (2)", "2 Munitions per turn per weapon.\nModifiers (reload / disrupt) only apply to current or next turn.\nReload +2M");
        }
        public static class WeaponType
        {
            public static readonly Trait StrongHit = new Trait("Strong Hit 5-6", "Strong hits are 5+");
            public static readonly Trait HenchmanExtraCost1 = new Trait("Strong Henchman Extra Cost 1", "+1 Resource cost for Henchment NPCs");
        }
    }

    public class Weapon
    {
        public int SlotsUsed = 2;
        public int HandsUsed = 2;
        public int Range;
        // select base, select 1 variation
    }

    [Flags]
    public enum WeaponType
    {
        Gun,
        Shell,
        Companion ,
        Melee,
        Special,
    }

    public class BaseWeaponTableRow
    {
        public string Name;
        public WeaponType WeaponType;
        public int HitDice;
        public int Hit;
        public int Range;
        public int EndDmg;
        public int CritDmg;
        public int AquireTime;
        public int AquireEndurance;
        public int CostResources;

        public Trait[] Traits = new Trait[0];
    }

    public class WeaponGenerator
    {
    }

    public static class WeaponTables
    {
        public static List<BaseWeaponTableRow> SmallArms = new List<BaseWeaponTableRow>()
        {
            new BaseWeaponTableRow() { Name = "Pistol", HitDice = 3, Hit = 1, Range = 3, EndDmg = 0, CritDmg = 3, WeaponType = WeaponType.Gun, AquireTime = 8, CostResources = 1 },
            new BaseWeaponTableRow() { Name = "Submachine Gun (SMG)", HitDice = 4, Hit = 0, Range = 3, EndDmg = 1, CritDmg = 3, WeaponType = WeaponType.Gun, AquireTime = 12, CostResources = 2 },
            new BaseWeaponTableRow() { Name = "Shotgun (Gun)", HitDice = 3, Hit = 2, Range = 2, EndDmg = 2, CritDmg = 3, WeaponType = WeaponType.Gun, AquireTime = 10, CostResources = 2 },
            new BaseWeaponTableRow() { Name = "Shotgun (Shell)", HitDice = 3, Hit = 2, Range = 2, EndDmg = 2, CritDmg = 3, WeaponType = WeaponType.Shell, AquireTime = 10, CostResources = 2 },
            new BaseWeaponTableRow() { Name = "Rifle", HitDice = 2, Hit = 2, Range = 6, EndDmg = 0, CritDmg = 4, WeaponType = WeaponType.Gun, AquireTime = 12, CostResources = 2, Traits = new []{ Traits.WeaponType.StrongHit, Traits.WeaponType.HenchmanExtraCost1 } },
        };

        public static List<BaseWeaponTableRow> Variations = new List<BaseWeaponTableRow>()
        {
            new BaseWeaponTableRow() { Name = "Particle", EndDmg = -1, AquireTime = -4  },
            new BaseWeaponTableRow() { Name = "Metal Slugs / Barbs", Hit = -1, Range = -1, AquireTime = -2  },
            new BaseWeaponTableRow() { Name = "Disruptor Pulse", Hit = 1, EndDmg = 1, CritDmg = -1, AquireTime = -1  },
            new BaseWeaponTableRow() { Name = "Arc-Fire Bolts", Range = 1 },
            new BaseWeaponTableRow() { Name = "Phase Beam", Hit = -2, Range = -1 },
            new BaseWeaponTableRow() { Name = "Ion", Hit = 1, EndDmg = -1, AquireTime = 1 },
        };

        public static List<BaseWeaponTableRow> GunModifiers = new List<BaseWeaponTableRow>()
        {
            new BaseWeaponTableRow() { Name = "Personalised", Hit = 1, AquireTime = 10 },
            new BaseWeaponTableRow() { Name = "Dual Wield", HitDice = 1, EndDmg = 1, AquireTime = 12, AquireEndurance = 1 },
        };

        public static List<BaseWeaponTableRow> ShellModifiers = new List<BaseWeaponTableRow>()
        {
            new BaseWeaponTableRow() { Name = "Shrapnel", EndDmg = 1, CritDmg = -1, AquireTime = -1 },
        };
    }


    public class EncounterGenerator
    {
        public static Encounter CreateEncounter(NPCType npcType, int powerLevel = 2, int partySize = 4)
        {
            var encounter = new Encounter();
            if (npcType == NPCType.HenchmenGroup)
            {
                var henchman = new Creature();
                henchman.GroupId = "HenchmentGroup";
                henchman.Traits.Add(Traits.NPCType.HechmenDamage);
                henchman.Traits.Add(Traits.NPCType.HechmenLackInitiative);
                henchman.Traits.Add(Traits.NPCType.HechmenSharedEndurance);
                henchman.Traits.Add(Traits.NPCType.HechmenSharedAction);
                henchman.Traits.Add(Traits.NPCType.HechmenBodies);
                henchman.Traits.Add(Traits.NPCType.NPCMunitions1);
                henchman.HitBonus = 2;

                var statRow = EncounterTables.HenchmenGroup.Any(r => r.PowerHiKey <= powerLevel)
                            ? EncounterTables.HenchmenGroup.First(r => r.PowerHiKey <= powerLevel)
                            : EncounterTables.HenchmenGroup.Last();
                henchman.DefBase = statRow.Defence;
                henchman.DefArmour = statRow.Armour;
                henchman.DefDurability = statRow.Durability;
                henchman.DefEndurance = statRow.Endurance;
                henchman.Mobility = 5;
                henchman.Actions = 1;

                // generate weapon
                // no outfit / utility
                // no grit re-roll

                for (int i = 0; i < statRow.Bodies; i++)
                {
                    var copy = henchman.DeepCopy();
                    encounter.Creatures.Add(copy);
                }

            }
            else if (npcType == NPCType.TroopGroup)
            {
                var single1 = new Creature();
                var single2 = single1.DeepCopy();
                encounter.Creatures.Add(single1);
                encounter.Creatures.Add(single2);
            }
            else if (npcType == NPCType.Skilled)
            {
                var single = new Creature();
                encounter.Creatures.Add(single);
            }
            else if (npcType == NPCType.Nemesis)
            {
                var single = new Creature();
                encounter.Creatures.Add(single);
            }
            else
            {
                throw new NotSupportedException($"{npcType}");
            }
            return encounter;
        }
    }

    public struct EncounterTableRow
    {
        public int PowerHiKey; // "Av PC 1-3 Res" = 3 
        public int Defence;
        public int Armour;
        public int Durability;
        public int Bodies;
        public int Endurance;
        public int Resources;
        public int Variations;
    }

    public static class EncounterTables
    {
        public static List<EncounterTableRow> HenchmenGroup = new List<EncounterTableRow>()
        {
            new EncounterTableRow() { PowerHiKey = 3, Defence = 12, Armour = 3, Durability = 1, Bodies = 5, Endurance = 20, Resources = 1, Variations = 1},
            new EncounterTableRow() { PowerHiKey = 6, Defence = 13, Armour = 3, Durability = 1, Bodies = 6, Endurance = 22, Resources = 2, Variations = 1},
            new EncounterTableRow() { PowerHiKey = 9, Defence = 13, Armour = 3, Durability = 1, Bodies = 7, Endurance = 24, Resources = 3, Variations = 2},
            new EncounterTableRow() { PowerHiKey = 12, Defence = 14, Armour = 3, Durability = 1, Bodies = 8, Endurance = 26, Resources = 4, Variations = 2},
            new EncounterTableRow() { PowerHiKey = 15, Defence = 14, Armour = 3, Durability = 1, Bodies = 9, Endurance = 28, Resources = 5, Variations = 3},
            new EncounterTableRow() { PowerHiKey = 18, Defence = 15, Armour = 3, Durability = 1, Bodies = 10, Endurance = 30, Resources = 6, Variations = 3},
        };
    }
}
