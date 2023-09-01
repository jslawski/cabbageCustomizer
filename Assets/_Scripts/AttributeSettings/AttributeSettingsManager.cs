using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttributeSettingsManager
{
    public static AllAttributeSettingsData currentSettings;

    public static AllAttributeSettingsData defaultAttributeSettings;

    public static void Initialize()
    {
        AttributeSettingsManager.currentSettings = new AllAttributeSettingsData();

        TextAsset defaultValues = Resources.Load<TextAsset>("CharacterCreator/DefaultValues");
        AttributeSettingsManager.defaultAttributeSettings = 
            new AllAttributeSettingsData(JsonUtility.FromJson<AllAttributeSettingsData>(defaultValues.ToString()));

        AttributeSettingsManager.currentSettings = new AllAttributeSettingsData(AttributeSettingsManager.defaultAttributeSettings);
    }

    public static void LoadData(AllAttributeSettingsData allSettingsData)
    {
        AttributeSettingsManager.currentSettings = new AllAttributeSettingsData(allSettingsData);
    }

    public static void SetName(AttributeType attributeType, string newName)
    {
        AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).name = newName;       
    }

    public static void SetHorizontalPosition(AttributeType attributeType, float newPos)
    {
        AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).horPos = newPos;
    }

    public static void SetVerticalPosition(AttributeType attributeType, float newPos)
    {
        AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).verPos = newPos;
    }

    public static void SetScaleX(AttributeType attributeType, float newScale)
    {
        AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).scaleX = newScale;        
    }

    public static void SetScaleY(AttributeType attributeType, float newScale)
    {
        AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).scaleY = newScale;        
    }

    public static void SetRotation(AttributeType attributeType, float newRot)
    {
        AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).rot = newRot;
    }

    public static void SetDepth(AttributeType attributeType, int newDepth)
    {
        AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).dep = newDepth;        
    }

    public static void SetColor(AttributeType attributeType, int colorIndex, int newColor)
    {
        AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).colors[colorIndex] = newColor;        
    }

    public static void SetFlipX(AttributeType attributeType)
    {
        AttributeSettingsData targetAttributeSettings = AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType);
        targetAttributeSettings.flipX = !targetAttributeSettings.flipX;        
    }

    public static void SetFlipY(AttributeType attributeType)
    {
        AttributeSettingsData targetAttributeSettings = AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType);
        targetAttributeSettings.flipY = !targetAttributeSettings.flipY;
    }

    public static void SetAttributeSettings(AttributeType attributeType, AttributeSettingsData settingsData, bool isDefault = false)
    {
        AttributeSettingsData targetAttributeSettings = AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType);
        
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
        return new AttributeSettingsData(AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType));
    }

    public static string GetAttributeSpriteName(AttributeType attributeType)
    {
        return AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).name;
    }

    public static Vector2 GetAttributePosition(AttributeType attributeType)
    {
        Vector2 attributePosition = new Vector2();        
        attributePosition.x = AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).horPos;
        attributePosition.y = AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).verPos;
        
        return attributePosition;
    }

    public static Vector2 GetAttributeScale(AttributeType attributeType)
    {
        Vector2 attributeScale = new Vector2();
        attributeScale.x = AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).scaleX;
        attributeScale.y = AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).scaleY;

        return attributeScale;
    }

    public static float GetAttributeRotation(AttributeType attributeType)
    {        
        return AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).rot;
    }

    public static int GetAttributeDepth(AttributeType attributeType)
    {
        return AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).dep;
    }

    public static int[] GetAttributeColors(AttributeType attributeType)
    {
        return AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).colors;
    }

    public static bool GetAttributeFlipX(AttributeType attributeType)
    {
        return AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).flipX;
    }

    public static bool GetAttributeFlipY(AttributeType attributeType)
    {
        return AttributeSettingsManager.currentSettings.GetAttributeSettingsData(attributeType).flipY;
    }
}
