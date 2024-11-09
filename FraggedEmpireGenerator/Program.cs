// See https://aka.ms/new-console-template for more information
using FraggedEmpireGenerator;
using Newtonsoft.Json;

Console.WriteLine("test");

var creater = new Creature();
Console.WriteLine(JsonConvert.SerializeObject(creater));

Console.WriteLine("Creatures");

var encounter = EncounterGenerator.CreateEncounter(NPCType.HenchmenGroup);

var serializer = new CreatureSerializer();
serializer.Append(encounter.Creatures);

Console.WriteLine(serializer);
