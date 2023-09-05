using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string username = "";
    public int equippedPreset = 0;
    public string attributeSettingsJSON;
}

[System.Serializable]
public static class CurrentPlayerData
{
    public static PlayerData data;
}
