using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraggedEmpireGenerator.Definitions
{
    public class Trait : IDefinition, ITraitValue
    {
        public string Name;
        public string Desc;
        public int Value;
        public Trait? Parent;
        public List<Trait> Children;

        public Trait(string name, string desc = null)
        {
            Name = name;
            Desc = desc;
            Children = new List<Trait>();
        }

        public Trait SetParent(Trait trait)
        {
            Parent = trait;
            trait.Children.Add(this);
            return this;
        }

        Trait ITraitValue.GetTrait()
        {
            return this;
        }

        object? ITraitValue.GetValue()
        {
            return null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
