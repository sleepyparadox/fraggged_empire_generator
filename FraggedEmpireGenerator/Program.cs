// See https://aka.ms/new-console-template for more information
using FraggedEmpireGenerator;
using FraggedEmpireGenerator.Tables.Weapons;
using Newtonsoft.Json;



var smallArmsDefinitions = new SmallArms().GetDefinitions();

var encounter = EncounterGenerator.CreateEncounter(NPCType.HenchmenGroup);

var serializer = new CreatureSerializer();
serializer.Append(encounter.Creatures);

Console.WriteLine(serializer);
