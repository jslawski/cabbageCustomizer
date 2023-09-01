using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCabbageAttribute : SingleCabbageAttribute
{
    [HideInInspector]
    public int childIndex = 0;

    public AttributeType childAttributeType;

    public override void UpdateAttributeObject()
    {
        AttributeSettingsData settingsData = AttributeSettingsManager.GetLatestAttributeSettingsData(this.childAttributeType);

        this.attributeTransform.localPosition = new Vector3(settingsData.horPos, settingsData.verPos, 0.0f);
        this.attributeTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, settingsData.rot);
        this.attributeTransform.localScale = new Vector3(settingsData.scaleX, settingsData.scaleY, 1.0f);

        Sprite[] spritesheet = Resources.LoadAll<Sprite>(this.GetSpritePath() + settingsData.name);
        this.attributeSprite.sprite = spritesheet[this.childIndex];
        this.attributeSprite.sortingOrder = settingsData.dep;
        this.attributeSprite.flipX = settingsData.flipX;
        this.attributeSprite.flipY = settingsData.flipY;
        //Do colors later
    }

    public override void ResetAttribute()
    {
        AttributeSettingsManager.SetAttributeSettings(this.childAttributeType, AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.childAttributeType), true);
    }

    public override void ResetAttributeSetting(SliderSetting settingToReset)
    {
        switch (settingToReset)
        {
            case SliderSetting.Horizontal_Position:
                AttributeSettingsManager.SetHorizontalPosition(this.childAttributeType, AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.childAttributeType).horPos);
                break;
            case SliderSetting.Vertical_Position:
                AttributeSettingsManager.SetVerticalPosition(this.childAttributeType, AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.childAttributeType).verPos);
                break;
            case SliderSetting.Scale_X:
                AttributeSettingsManager.SetScaleX(this.childAttributeType, AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.childAttributeType).scaleX);
                break;
            case SliderSetting.Scale_Y:
                AttributeSettingsManager.SetScaleY(this.childAttributeType, AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.childAttributeType).scaleY);
                break;
            case SliderSetting.Rotation:
                AttributeSettingsManager.SetRotation(this.childAttributeType, AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.childAttributeType).rot);
                break;
            case SliderSetting.Depth:
                AttributeSettingsManager.SetDepth(this.childAttributeType, AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.childAttributeType).dep);
                break;
            default:
                Debug.LogError("Unknown Setting: " + settingToReset);
                return;
        }
    }

    #region Setters
    public override void SetAssetName(string newName)
    {
        AttributeSettingsManager.SetName(this.childAttributeType, newName);
    }

    public override void SetHorizontalPosition(float newPos)
    {
        AttributeSettingsManager.SetHorizontalPosition(this.childAttributeType, newPos);
    }

    public override void SetVerticalPosition(float newPos)
    {
        AttributeSettingsManager.SetVerticalPosition(this.childAttributeType, newPos);
    }

    public override void SetScaleX(float newScale)
    {
        AttributeSettingsManager.SetScaleX(this.childAttributeType, newScale);
    }

    public override void SetScaleY(float newScale)
    {
        AttributeSettingsManager.SetScaleY(this.childAttributeType, newScale);
    }

    public override void SetRotation(float newRot)
    {
        AttributeSettingsManager.SetRotation(this.childAttributeType, newRot);
    }

    public override void SetDepth(int newDepth)
    {
        AttributeSettingsManager.SetDepth(this.childAttributeType, newDepth);
    }

    public override void SetColor(int colorIndex, int newColor)
    {
        AttributeSettingsManager.SetColor(this.childAttributeType, colorIndex, newColor);
    }

    public override void SetFlipX()
    {
        AttributeSettingsManager.SetFlipX(this.childAttributeType);
    }

    public override void SetFlipY()
    {
        AttributeSettingsManager.SetFlipY(this.childAttributeType);
    }
    #endregion

    #region Getters
    public override string GetAssetName()
    {
        return AttributeSettingsManager.GetAttributeSpriteName(this.childAttributeType);
    }

    public override float GetHorizontalPosition()
    {
        return AttributeSettingsManager.GetAttributePosition(this.childAttributeType).x;
    }
    public override float GetVerticalPosition()
    {
        return AttributeSettingsManager.GetAttributePosition(this.childAttributeType).y;
    }

    public override float GetScaleX()
    {
        return AttributeSettingsManager.GetAttributeScale(this.childAttributeType).x;
    }

    public override float GetScaleY()
    {
        return AttributeSettingsManager.GetAttributeScale(this.childAttributeType).y;
    }

    public override float GetRotation()
    {
        return AttributeSettingsManager.GetAttributeRotation(this.childAttributeType);
    }

    public override int GetDepth()
    {
        return AttributeSettingsManager.GetAttributeDepth(this.childAttributeType);
    }

    public override int[] GetColors()
    {
        return AttributeSettingsManager.GetAttributeColors(this.childAttributeType);
    }

    public override bool GetFlipX()
    {
        return AttributeSettingsManager.GetAttributeFlipX(this.childAttributeType);
    }

    public override bool GetFlipY()
    {
        return AttributeSettingsManager.GetAttributeFlipY(this.childAttributeType);
    }
    #endregion
}
