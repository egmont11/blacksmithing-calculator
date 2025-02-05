using System.ComponentModel;

namespace BlacksmithingApp_WinForms;

public partial class Form1 : Form
{
    private List<BladeCost> _jsonBladeCosts;
    private List<GuardCost> _jsonGuardCosts;
    private List<HiltCost> _jsonHiltCosts;
    
    private ComboBox bladeComboBox;
    private ComboBox guardComboBox;
    private ComboBox hiltComboBox;
    
    private Label totalMetalLabel;
    private Label totalOtherLabel;
    private Label totalPremsLabel;
    private Label minLevelLabel;
    
    public Form1()
    {
        InitializeComponent();
        LoadData();
        InitializeControls();
        SetupLayout();
    }
    
    private void LoadData()
    {
        _jsonBladeCosts = JsonUtils.SimpleReadBlades("data/BladeCosts.json");
        _jsonGuardCosts = JsonUtils.SimpleReadGuards("data/GuardCosts.json");
        _jsonHiltCosts = JsonUtils.SimpleReadHilts("data/Hiltcosts.json");
    }
    
    private void InitializeControls()
    {
        // Create ComboBoxes with specific sizes
        bladeComboBox = new ComboBox
        {
            Width = 200,
            Height = 30,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Margin = new Padding(10)
        };
        
        guardComboBox = new ComboBox
        {
            Width = 200,
            Height = 30,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Margin = new Padding(10)
        };
        
        hiltComboBox = new ComboBox
        {
            Width = 200,
            Height = 30,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Margin = new Padding(10)
        };
        
        // Create Labels with better visibility
        totalMetalLabel = new Label { 
            AutoSize = true,
            Font = new Font(Font.FontFamily, 12),
            Margin = new Padding(10)
        };
        
        totalOtherLabel = new Label {
            AutoSize = true,
            Font = new Font(Font.FontFamily, 12),
            Margin = new Padding(10)
        };
        
        totalPremsLabel = new Label {
            AutoSize = true,
            Font = new Font(Font.FontFamily, 12),
            Margin = new Padding(10)
        };
        
        minLevelLabel = new Label {
            AutoSize = true,
            Font = new Font(Font.FontFamily, 12),
            Margin = new Padding(10)
        };

        // Bind data to ComboBoxes
        if (_jsonBladeCosts?.Any() == true)
        {
            bladeComboBox.DataSource = new BindingList<BladeCost>(_jsonBladeCosts);
            bladeComboBox.DisplayMember = "WeaponPartName";
        }
        
        if (_jsonGuardCosts?.Any() == true)
        {
            guardComboBox.DataSource = new BindingList<GuardCost>(_jsonGuardCosts);
            guardComboBox.DisplayMember = "WeaponPartName";
        }
        
        if (_jsonHiltCosts?.Any() == true)
        {
            hiltComboBox.DataSource = new BindingList<HiltCost>(_jsonHiltCosts);
            hiltComboBox.DisplayMember = "WeaponPartName";
        }

        // Add event handlers
        bladeComboBox.SelectedIndexChanged += UpdateTotals;
        guardComboBox.SelectedIndexChanged += UpdateTotals;
        hiltComboBox.SelectedIndexChanged += UpdateTotals;
        
        // Set initial labels
        UpdateTotals(null, EventArgs.Empty);
    }
    
    private void SetupLayout()
    {
        TableLayoutPanel mainLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 3,
            Padding = new Padding(20)
        };

        // Set row heights as percentages
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15)); // Header row
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 35)); // ComboBox row
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50)); // Totals row

        // Set column widths to be equal
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));

        // Section Headers with adjusted height
        Label bladeLabel = new Label 
        { 
            Text = "Blade", 
            Font = new Font(Font.FontFamily, 12, FontStyle.Bold),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter
        };
        Label guardLabel = new Label 
        { 
            Text = "Guard", 
            Font = new Font(Font.FontFamily, 12, FontStyle.Bold),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter
        };
        Label hiltLabel = new Label 
        { 
            Text = "Hilt", 
            Font = new Font(Font.FontFamily, 12, FontStyle.Bold),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter
        };

        mainLayout.Controls.Add(bladeLabel, 0, 0);
        mainLayout.Controls.Add(guardLabel, 1, 0);
        mainLayout.Controls.Add(hiltLabel, 2, 0);
        
        mainLayout.Controls.Add(bladeComboBox, 0, 1);
        mainLayout.Controls.Add(guardComboBox, 1, 1);
        mainLayout.Controls.Add(hiltComboBox, 2, 1);
        
        // Totals Panel
        GroupBox totalsBox = new GroupBox
        {
            Text = "Total Requirements",
            Dock = DockStyle.Fill,
            Font = new Font(Font.FontFamily, 12, FontStyle.Bold)
        };
        
        FlowLayoutPanel totalsPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            Padding = new Padding(10)
        };
        
        totalsPanel.Controls.Add(totalMetalLabel);
        totalsPanel.Controls.Add(totalOtherLabel);
        totalsPanel.Controls.Add(totalPremsLabel);
        totalsPanel.Controls.Add(minLevelLabel);
        
        totalsBox.Controls.Add(totalsPanel);
        mainLayout.Controls.Add(totalsBox, 0, 2);
        mainLayout.SetColumnSpan(totalsBox, 3);
        
        Controls.Add(mainLayout);
    }

    private void UpdateTotals(object sender, EventArgs e)
    {
        var selectedBlade = bladeComboBox.SelectedItem as BladeCost;
        var selectedGuard = guardComboBox.SelectedItem as GuardCost;
        var selectedHilt = hiltComboBox.SelectedItem as HiltCost;
        
        int totalMetal = 0;
        int totalOther = 0;
        int totalPrems = 0;
        int minLevel = 0;
        
        if (selectedBlade != null)
        {
            totalMetal += selectedBlade.MetalCost;
            totalOther += selectedBlade.OtherMaterialCost;
            totalPrems += selectedBlade.PremsCost;
            minLevel = Math.Max(minLevel, selectedBlade.LvlReq);
        }
        
        if (selectedGuard != null)
        {
            totalMetal += selectedGuard.MetalCost;
            totalOther += selectedGuard.OtherMaterialCost;
            totalPrems += selectedGuard.PremsCost;
            minLevel = Math.Max(minLevel, selectedGuard.LvlReq);
        }
        
        if (selectedHilt != null)
        {
            totalMetal += selectedHilt.MetalCost;
            totalOther += selectedHilt.OtherMaterialCost;
            totalPrems += selectedHilt.PremsCost;
            minLevel = Math.Max(minLevel, selectedHilt.LvlReq);
        }
        
        totalMetalLabel.Text = $"Total Metal Cost: {totalMetal}";
        totalOtherLabel.Text = $"Total Other Materials: {totalOther}";
        totalPremsLabel.Text = $"Premium Cost: {totalPrems}";
        minLevelLabel.Text = $"Minimum Level Required: {minLevel}";
    }
}