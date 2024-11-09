// See https://aka.ms/new-console-template for more information
using FraggedEmpireGenerator;
using Newtonsoft.Json;



var encounter = EncounterGenerator.CreateEncounter(NPCType.HenchmenGroup);

var serializer = new CreatureSerializer();
serializer.Append(encounter.Creatures);

Console.WriteLine(serializer);
