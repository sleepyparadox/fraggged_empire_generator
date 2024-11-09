using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FraggedEmpireGenerator
{
    public class CreatureSerializer
    {
        StringBuilder _builder;

        public CreatureSerializer() 
        {
            _builder = new StringBuilder();
        }

        public void Append(List<Creature> creatures)
        {
            var table = new List<(string Name, string Hit, string Def, string Mobility, string Actions)>();

            foreach(var c in creatures)
            {
                table.Add
                (
                    new 
                    (
                        $"{c.Name}", 
                        $"{c.HitDice}d6 + {c.HitBonus} ({c.HitDmgEndurance} Endure, {c.HitDmgCritical} Crit, {c.HitRange} Range)", 
                        $"{c.DefArmour} ({c.DefEndurance} Endureance, {c.DefArmour} Armour, {c.DefDurability} Durability)",
                        $"{c.Mobility}",
                        $"{c.Actions}"
                    )
                );
            }

            _builder.AppendLine("| Name | Hit | Def | Mobility | Actions |");
            _builder.AppendLine("| ---- | --- | --- | -------- | ------- |");
            foreach (var row in table)
            {
                _builder.AppendLine($"| {row.Name} | {row.Hit} | {row.Def} | {row.Mobility} | {row.Actions} |");
            }

            _builder.AppendLine();
            foreach(var trait in creatures.SelectMany(c => c.Traits).DistinctBy(t => t.Name))
            {
                _builder.AppendLine($"{trait.Name}\n: {trait.Desc.Replace("\n", "\n: ")}");
                _builder.AppendLine();
            }
            _builder.AppendLine();

        }

        public void Clear()
        {
            _builder.Clear();
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}
