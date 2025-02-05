using Convert_input2JSON_txt.Records;

namespace Convert_input2JSON_txt;

class Program
{
    static void Main(string[] args)
    {
        static List<BladeCost> BladeCosts() => new() 
        { 
            new("Basic blade", 10, 0, 3, false, false, 0), 
            new("Dagger blade", 7, 0, 3, false, false, 0),
            new("Narrow blade", 8, 0, 4, true, false, 0),
            new("Rapier blade", 6, 0, 5, true, false, 0),
            new("Spearhead", 3, 3, 5, true, false, 0),
            new("Axe head", 8, 5, 6, true, false, 0),
            new("Stiletto blade", 4, 0, 6, true, false, 0), 
            new("Strange axe head", 10, 5, 7, true, false, 0),
            new("Battle axe head", 10, 5, 7, true, false, 0),
            new("Long blade", 12, 0, 8, true, false, 0),
            new("Halberd head", 14, 0, 9, true, true, 0),
            new("Hallengard axe head", 12, 6, 9, true, true, 0),
            new("Warhammer head", 9, 6, 9, true, true, 0),
            new("Noble blade", 16, 0, 10, false, false, 20),
            new("Mythic blade", 12, 4, 10, false, false, 20),
            new("Exotic blade", 14, 0, 10, false, false, 18),
            new("Scimitar blade", 15, 0, 10, false, false, 20),
        };

        static List<GuardCost> GuardCosts() => new()
        {
            new("Basic guard", 5, 0, 3, false, false, 0),
            new("Extender", 0, 6, 4, false, false, 0),
            new("Odd guard", 4, 0, 4, false, false, 0),
            new("Round guard", 4, 6, 6, false, false, 0),
            new("Small guard", 3, 0, 6, false, false, 0),
            new("Jeweled guard", 3, 8, 8, true, false, 0),
            new("Banded extender", 2, 6, 9, false, false, 0),
            new("Balreskan guard", 10, 0, 9, false, false, 0),
            new("Noble guard", 6, 4, 10, false, false, 0),
            new("Mythic guard", 10, 0, 10, false, false, 0),
            new("Exotic guard", 6, 0, 10, false, false, 0),
        };
        
        
    }
}