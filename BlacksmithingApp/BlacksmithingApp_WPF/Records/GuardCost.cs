namespace BlacksmithingApp_WinForms;

public record GuardCost(
    string WeaponPartName,
    int MetalCost,
    int OtherMaterialCost,
    int LvlReq,
    bool HQMRequired,
    bool LoyaltyCoinRequired,
    int PremsCost
    );