﻿namespace Convert_input2JSON_txt.Records;

public record GuardCost(
    string WeaponPartName,
    int MetalCost,
    int OtherMaterialCost,
    int LvlReq,
    bool HQMRequired,
    bool LoyaltyCoinRequired,
    int PremsCost
    );