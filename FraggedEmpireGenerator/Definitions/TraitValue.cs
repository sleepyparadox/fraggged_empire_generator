using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FraggedEmpireGenerator.Definitions
{
    public class TraitValue : ITraitValue
    {
        public Trait? Trait;
        public object? Value;

        public TraitValue(Trait trait, object? val)
        {
            Trait = trait;
            Value = val;
        }

        Trait? ITraitValue.GetTrait()
        {
            return Trait;
        }

        object? ITraitValue.GetValue()
        {
            return Value;
        }

        public override string ToString()
        {
            return Value != null 
                   ? $"{Trait} ({Value})"
                   : $"{Trait}";
        }
    }

    public static class TraitValueExtension
    {
        public static TraitValue WithValue(this Trait trait, object val)
        {
            return new TraitValue(trait, val);
        }
    }

    public interface ITraitValue
    {
        public Trait? GetTrait();
        public object? GetValue();
    }
}
