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
            var table = new List<(string Name, string Hit, string Def, string Actions)>();

            foreach(var creature in creatures)
            {
                table.Add
                (
                    new 
                    (
                        "Critter", 
                        "3d6 (3 Endure, 1 Crit)", 
                        "10 (12 Durability, 2 Armour)",
                        "1"
                    )
                );
            }

            _builder.AppendLine("Name | Hit | Def | Actions");
            foreach (var row in table)
            {
                _builder.AppendLine($"{row.Name} | {row.Hit} | {row.Def} | {row.Actions}");
            }
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
