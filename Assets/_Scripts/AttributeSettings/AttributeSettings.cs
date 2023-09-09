using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttributeSettings
{
    private static AllAttributeSettingsData currentSettings;
    public static AllAttributeSettingsData CurrentSettings
    {
        get
        {
            if (AttributeSettings.currentSettings == null)
            {
                AttributeSettings.currentSettings = new AllAttributeSettingsData();
            }

            return AttributeSettings.currentSettings;
        }
        set
        {
            AttributeSettings.currentSettings = value;
        }
    }

    private static AllAttributeSettingsData defaultSettings;
    public static AllAttributeSettingsData DefaultSettings
    {
        get
        {
            if (AttributeSettings.defaultSettings == null)
            {
                TextAsset defaultValues = Resources.Load<TextAsset>("CharacterCreator/DefaultValues");
                AttributeSettings.defaultSettings = new AllAttributeSettingsData(JsonUtility.FromJson<AllAttributeSettingsData>(defaultValues.ToString()));
            }

            return AttributeSettings.defaultSettings;
        }
        set
        {
            AttributeSettings.defaultSettings = value;
        }
    }

    public static void LoadData(AllAttributeSettingsData allSettingsData)
    {
        AttributeSettings.currentSettings = new AllAttributeSettingsData(allSettingsData);
    }

    public static void SetName(AttributeType attributeType, string newName)
    {
        AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).name = newName;       
    }

    public static void SetHorizontalPosition(AttributeType attributeType, float newPos)
    {
        AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).horPos = newPos;
    }

    public static void SetVerticalPosition(AttributeType attributeType, float newPos)
    {
        AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).verPos = newPos;
    }

    public static void SetScaleX(AttributeType attributeType, float newScale)
    {
        AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).scaleX = newScale;        
    }

    public static void SetScaleY(AttributeType attributeType, float newScale)
    {
        AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).scaleY = newScale;        
    }

    public static void SetRotation(AttributeType attributeType, float newRot)
    {
        AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).rot = newRot;
    }

    public static void SetDepth(AttributeType attributeType, int newDepth)
    {
        AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).dep = newDepth;        
    }

    public static void SetColor(AttributeType attributeType, int colorIndex, int newColor)
    {
        AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).colors[colorIndex] = newColor;        
    }

    public static void SetFlipX(AttributeType attributeType)
    {
        AttributeSettingsData targetAttributeSettings = AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType);
        targetAttributeSettings.flipX = !targetAttributeSettings.flipX;        
    }

    public static void SetFlipY(AttributeType attributeType)
    {
        AttributeSettingsData targetAttributeSettings = AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType);
        targetAttributeSettings.flipY = !targetAttributeSettings.flipY;
    }

    public static void SetAttributeSettings(AttributeType attributeType, AttributeSettingsData settingsData, bool isDefault = false)
    {
        AttributeSettingsData targetAttributeSettings = AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType);
        
        //Don't reset the asset name if the player just clicked the "default" button
        if (isDefault == false)
        {
            targetAttributeSettings.name = settingsData.name;
        }

        targetAttributeSettings.horPos = settingsData.horPos;
        targetAttributeSettings.verPos = settingsData.verPos;
        targetAttributeSettings.scaleX = settingsData.scaleX;
        targetAttributeSettings.scaleY = settingsData.scaleY;
        targetAttributeSettings.rot = settingsData.rot;
        targetAttributeSettings.dep = settingsData.dep;
        targetAttributeSettings.colors = settingsData.colors;
        targetAttributeSettings.flipX = settingsData.flipX;
        targetAttributeSettings.flipY = settingsData.flipY;        

    }

    public static AttributeSettingsData GetLatestAttributeSettingsData(AttributeType attributeType)
    {
        return new AttributeSettingsData(AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType));
    }

    public static string GetAttributeSpriteName(AttributeType attributeType)
    {
        return AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).name;
    }

    public static Vector2 GetAttributePosition(AttributeType attributeType)
    {
        Vector2 attributePosition = new Vector2();        
        attributePosition.x = AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).horPos;
        attributePosition.y = AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).verPos;
        
        return attributePosition;
    }

    public static Vector2 GetAttributeScale(AttributeType attributeType)
    {
        Vector2 attributeScale = new Vector2();
        attributeScale.x = AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).scaleX;
        attributeScale.y = AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).scaleY;

        return attributeScale;
    }

    public static float GetAttributeRotation(AttributeType attributeType)
    {        
        return AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).rot;
    }

    public static int GetAttributeDepth(AttributeType attributeType)
    {
        return AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).dep;
    }

    public static int[] GetAttributeColors(AttributeType attributeType)
    {
        return AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).colors;
    }

    public static bool GetAttributeFlipX(AttributeType attributeType)
    {
        return AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).flipX;
    }

    public static bool GetAttributeFlipY(AttributeType attributeType)
    {
        return AttributeSettings.currentSettings.GetAttributeSettingsData(attributeType).flipY;
    }
}
