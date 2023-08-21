using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType { BaseCabbage, Headpiece, EyebrowL, EyebrowR, EyebrowB, EyeL, EyeR, EyeB, Nose, Mouth, Acc1, Acc2, Acc3, None };
public enum AttributeSide { Left, Both, Right }

[System.Serializable]
public class AttributeSettingsData
{
    public string name = "";
    public float horPos = 0.0f;
    public float verPos = 0.0f;
    public float scaleX = 1.0f;
    public float scaleY = 1.0f;
    public float rot = 0.0f;
    public int dep = 0;
    public int[] colors;
    public bool flipX = false;
    public bool flipY = false;

    public AttributeSettingsData()
    {
        this.name = "";
        this.horPos = 0.0f;
        this.verPos = 0.0f;
        this.scaleX = 1.0f;
        this.scaleY = 1.0f;
        this.rot = 0.0f;
        this.dep = 0;
        this.colors = new int[3];
        this.flipX = false;
        this.flipY = false;
    }

    public AttributeSettingsData(AttributeSettingsData dataToCopy)
    {
        this.name = dataToCopy.name;
        this.horPos = dataToCopy.horPos;
        this.verPos = dataToCopy.verPos;
        this.scaleX = dataToCopy.scaleX;
        this.scaleY = dataToCopy.scaleY;
        this.rot = dataToCopy.rot;
        this.dep = dataToCopy.dep;
        this.colors = dataToCopy.colors;
        this.flipX = dataToCopy.flipX;
        this.flipY = dataToCopy.flipY;
    }
}

[System.Serializable]
public class AllAttributeSettingsData
{
    public AttributeSettingsData baseCabbage;
    public AttributeSettingsData headpiece;
    public AttributeSettingsData eyebrowL;
    public AttributeSettingsData eyebrowR;
    public AttributeSettingsData eyebrowB;
    public AttributeSettingsData eyeL;
    public AttributeSettingsData eyeR;
    public AttributeSettingsData eyeB;
    public AttributeSettingsData nose;
    public AttributeSettingsData mouth;
    public AttributeSettingsData acc1;
    public AttributeSettingsData acc2;
    public AttributeSettingsData acc3;
}

public static class AttributeSettingsManager
{
    public static AttributeType currentAttribute;

    private static Dictionary<AttributeType, AttributeSettingsData> attributeSettingsDict;

    private static AllAttributeSettingsData defaultAttributeSettings;

    public static void Setup(AllAttributeSettingsData allSettingsData)
    {
        AttributeSettingsManager.currentAttribute = AttributeType.BaseCabbage;

        AttributeSettingsManager.attributeSettingsDict[AttributeType.BaseCabbage] = allSettingsData.baseCabbage;
        AttributeSettingsManager.attributeSettingsDict[AttributeType.EyebrowL] = allSettingsData.eyebrowL;
        AttributeSettingsManager.attributeSettingsDict[AttributeType.EyebrowR] = allSettingsData.eyebrowR;
        AttributeSettingsManager.attributeSettingsDict[AttributeType.EyebrowB] = allSettingsData.eyebrowB;
        AttributeSettingsManager.attributeSettingsDict[AttributeType.EyeL] = allSettingsData.eyeL;
        AttributeSettingsManager.attributeSettingsDict[AttributeType.EyeR] = allSettingsData.eyeR;
        AttributeSettingsManager.attributeSettingsDict[AttributeType.EyeB] = allSettingsData.eyeB;
        AttributeSettingsManager.attributeSettingsDict[AttributeType.Nose] = allSettingsData.nose;
        AttributeSettingsManager.attributeSettingsDict[AttributeType.Mouth] = allSettingsData.mouth;
        AttributeSettingsManager.attributeSettingsDict[AttributeType.Acc1] = allSettingsData.acc1;
        AttributeSettingsManager.attributeSettingsDict[AttributeType.Acc2] = allSettingsData.acc2;
        AttributeSettingsManager.attributeSettingsDict[AttributeType.Acc3] = allSettingsData.acc3;

        AttributeSettingsManager.defaultAttributeSettings = JsonUtility.FromJson<AllAttributeSettingsData>(Resources.Load<TextAsset>("CharacterCreator/AttributeDefaults").text);
    }

    public static void SetName(AttributeType attributeType, string newName)
    {
        AttributeSettingsManager.attributeSettingsDict[attributeType].name = newName;
    }

    public static void SetHorizontalPosition(AttributeType attributeType, float newPos)
    {
        AttributeSettingsManager.attributeSettingsDict[attributeType].horPos = newPos;
    }

    public static void SetVerticalPosition(AttributeType attributeType, float newPos)
    {
        AttributeSettingsManager.attributeSettingsDict[attributeType].verPos = newPos;
    }

    public static void SetScaleX(AttributeType attributeType, float newScale)
    {
        AttributeSettingsManager.attributeSettingsDict[attributeType].scaleX = newScale;
    }

    public static void SetScaleY(AttributeType attributeType, float newScale)
    {
        AttributeSettingsManager.attributeSettingsDict[attributeType].scaleY = newScale;
    }

    public static void SetRotation(AttributeType attributeType, float newRot)
    {
        AttributeSettingsManager.attributeSettingsDict[attributeType].rot = newRot;
    }

    public static void SetDepth(AttributeType attributeType, int newDepth)
    {
        AttributeSettingsManager.attributeSettingsDict[attributeType].dep = newDepth;
    }

    public static void SetColor(AttributeType attributeType, int colorIndex, int newColor)
    {
        AttributeSettingsManager.attributeSettingsDict[attributeType].colors[colorIndex] = newColor;
    }

    public static void SetFlipX(AttributeType attributeType)
    {
        AttributeSettingsManager.attributeSettingsDict[attributeType].flipX = !AttributeSettingsManager.attributeSettingsDict[attributeType].flipX;
    }

    public static void SetFlipY(AttributeType attributeType)
    {
        AttributeSettingsManager.attributeSettingsDict[attributeType].flipY = !AttributeSettingsManager.attributeSettingsDict[attributeType].flipY;
    }

    public static void SetAttributeSettings(AttributeType attributeType, AttributeSettingsData settingsData, bool isDefault = false)
    {
        if (isDefault == false)
        {
            AttributeSettingsManager.attributeSettingsDict[attributeType].name = settingsData.name;
        }

        AttributeSettingsManager.attributeSettingsDict[attributeType].horPos = settingsData.horPos;
        AttributeSettingsManager.attributeSettingsDict[attributeType].verPos = settingsData.verPos;
        AttributeSettingsManager.attributeSettingsDict[attributeType].scaleX = settingsData.scaleX;
        AttributeSettingsManager.attributeSettingsDict[attributeType].scaleY = settingsData.scaleY;
        AttributeSettingsManager.attributeSettingsDict[attributeType].rot = settingsData.rot;
        AttributeSettingsManager.attributeSettingsDict[attributeType].dep = settingsData.dep;
        AttributeSettingsManager.attributeSettingsDict[attributeType].colors = settingsData.colors;
        AttributeSettingsManager.attributeSettingsDict[attributeType].flipX = settingsData.flipX;
        AttributeSettingsManager.attributeSettingsDict[attributeType].flipY = settingsData.flipY;
    }

    public static AttributeSettingsData GetLatestAttributeSettingsData(AttributeType attributeType)
    {
        return AttributeSettingsManager.attributeSettingsDict[attributeType];
    }

    public static string GetAttributeSpriteName(AttributeType attributeType)
    {
        return AttributeSettingsManager.attributeSettingsDict[attributeType].name;
    }

    public static Vector2 GetAttributePosition(AttributeType attributeType)
    {
        Vector2 attributePosition = new Vector2();
        attributePosition.x = AttributeSettingsManager.attributeSettingsDict[attributeType].horPos;
        attributePosition.y = AttributeSettingsManager.attributeSettingsDict[attributeType].verPos;
        
        return attributePosition;
    }

    public static Vector2 GetAttributeScale(AttributeType attributeType)
    {
        Vector2 attributeScale = new Vector2();
        attributeScale.x = AttributeSettingsManager.attributeSettingsDict[attributeType].scaleX;
        attributeScale.y = AttributeSettingsManager.attributeSettingsDict[attributeType].scaleY;

        return attributeScale;
    }

    public static float GetAttributeRotation(AttributeType attributeType)
    {        
        return AttributeSettingsManager.attributeSettingsDict[attributeType].rot;
    }

    public static int GetAttributeDepth(AttributeType attributeType)
    {
        return AttributeSettingsManager.attributeSettingsDict[attributeType].dep;
    }

    public static int[] GetAttributeColors(AttributeType attributeType)
    {
        return AttributeSettingsManager.attributeSettingsDict[attributeType].colors;
    }

    public static bool GetAttributeFlipX(AttributeType attributeType)
    {
        return AttributeSettingsManager.attributeSettingsDict[attributeType].flipX;
    }

    public static bool GetAttributeFlipY(AttributeType attributeType)
    {
        return AttributeSettingsManager.attributeSettingsDict[attributeType].flipY;
    }

    public static void ResetAttribute(AttributeType attributeType)
    {
        switch (attributeType)
        {
            case AttributeType.BaseCabbage:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.baseCabbage, true);
                break;
            case AttributeType.EyebrowL:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.eyebrowL, true);
                break;
            case AttributeType.EyebrowR:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.eyebrowR, true);
                break;
            case AttributeType.EyebrowB:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.eyebrowB, true);
                AttributeSettingsManager.SetAttributeSettings(AttributeType.EyebrowL, AttributeSettingsManager.defaultAttributeSettings.eyebrowL, true);
                AttributeSettingsManager.SetAttributeSettings(AttributeType.EyebrowR, AttributeSettingsManager.defaultAttributeSettings.eyebrowR, true);
                break;
            case AttributeType.EyeL:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.eyeL, true);
                break;
            case AttributeType.EyeR:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.eyeR, true);
                break;
            case AttributeType.EyeB:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.eyeB, true);
                AttributeSettingsManager.SetAttributeSettings(AttributeType.EyeL, AttributeSettingsManager.defaultAttributeSettings.eyeL, true);
                AttributeSettingsManager.SetAttributeSettings(AttributeType.EyeR, AttributeSettingsManager.defaultAttributeSettings.eyeR, true);
                break;
            case AttributeType.Nose:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.nose, true);
                break;
            case AttributeType.Mouth:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.mouth, true);
                break;
            case AttributeType.Acc1:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.acc1, true);
                break;
            case AttributeType.Acc2:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.acc2, true);
                break;
            case AttributeType.Acc3:
                AttributeSettingsManager.SetAttributeSettings(attributeType, AttributeSettingsManager.defaultAttributeSettings.acc3, true);
                break;
            default:
                Debug.LogError("Unknown AttributeType: " + attributeType);
                break;
        }
    }
}
