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

    public struct EncounterTableStats
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
        public static List<EncounterTableStats> HenchmenGroup = new List<EncounterTableStats>()
        {
            new EncounterTableStats() { PowerHiKey = 3, Defence = 12, Armour = 3, Durability = 1, Bodies = 5, Endurance = 20, Resources = 1, Variations = 1},
            new EncounterTableStats() { PowerHiKey = 6, Defence = 13, Armour = 3, Durability = 1, Bodies = 6, Endurance = 22, Resources = 2, Variations = 1},
            new EncounterTableStats() { PowerHiKey = 9, Defence = 13, Armour = 3, Durability = 1, Bodies = 7, Endurance = 24, Resources = 3, Variations = 2},
            new EncounterTableStats() { PowerHiKey = 12, Defence = 14, Armour = 3, Durability = 1, Bodies = 8, Endurance = 26, Resources = 4, Variations = 2},
            new EncounterTableStats() { PowerHiKey = 15, Defence = 14, Armour = 3, Durability = 1, Bodies = 9, Endurance = 28, Resources = 5, Variations = 3},
            new EncounterTableStats() { PowerHiKey = 18, Defence = 15, Armour = 3, Durability = 1, Bodies = 10, Endurance = 30, Resources = 6, Variations = 3},
        };
    }
}
