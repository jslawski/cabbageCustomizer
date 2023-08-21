using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string username = "";
    public int equippedPreset = 0;
    public string attributeSettingsJSON;
}

public static class CurrentPlayerData
{
    public static PlayerData data;
}
