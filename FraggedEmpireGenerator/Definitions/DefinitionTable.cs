using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FraggedEmpireGenerator.Definitions
{
    public class DefinitionTable<TDefinition> where TDefinition : IDefinition
    {
        public List<TDefinition> GetDefinitions()
        {
            return GetDefinitionsBase().Cast<TDefinition>().ToList();
        }

        public List<IDefinition> GetDefinitionsBase()
        {
            var definitions = new List<IDefinition>();

            var fields = GetType().GetFields(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public)
                                  .Where(info => info.FieldType == typeof(TDefinition));
            foreach(var field in fields)
            {
                var val = field.GetValue(null);
                if(val is IDefinition def)
                {
                    definitions.Add(def);
                }
            }

            var props = GetType().GetProperties(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public)
                                 .Where(info => info.PropertyType == typeof(TDefinition));
            foreach (var prop in props)
            {
                var val = prop.GetValue(null);
                if (val is IDefinition def)
                {
                    definitions.Add(def);
                }
            }

            return definitions;
        }
    }
}
