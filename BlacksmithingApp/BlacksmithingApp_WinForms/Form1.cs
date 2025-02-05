namespace BlacksmithingApp_WinForms;

public partial class Form1 : Form
{
    private List<BladeCost> _jsonBladeCosts;
    private List<GuardCost> _jsonGuardCosts;
    private List<HiltCost> _jsonHiltCosts;
    
    public Form1()
    {
        _jsonBladeCosts = JsonUtils.SimpleReadBlades("data/BladeCosts.json");
        _jsonGuardCosts = JsonUtils.SimpleReadGuards("data/GuardCosts.json");
        _jsonHiltCosts = JsonUtils.SimpleReadHilts("data/Hiltcosts.json");
        
        foreach (var part in _jsonBladeCosts)
        {
            Console.WriteLine($"{part.WeaponPartName} - Metal Cost: {part.MetalCost}");
        }
        
        InitializeComponent();
    }
}