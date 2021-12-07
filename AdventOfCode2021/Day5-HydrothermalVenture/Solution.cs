
using Day5_HydrothermalVenture;

var lines = File.ReadAllLines("input.txt");



HydrothermalVentCreator creator = new HydrothermalVentCreator();
creator.ParseHydrothermalVentCoordsAndCreateLines(lines);

int totalOverlaps = creator.GetNumberOfCoordsWithOverlappingVentLines();

Console.WriteLine(totalOverlaps);

