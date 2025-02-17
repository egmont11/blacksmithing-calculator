namespace BlacksmithingApp_WinForms;

public record BladeCost(
    string WeaponPartName,
    int MetalCost,
    int OtherMaterialCost,
    int LvlReq,
    bool HQMRequired,
    bool LoyaltyCoinRequired,
    int PremsCost
);
