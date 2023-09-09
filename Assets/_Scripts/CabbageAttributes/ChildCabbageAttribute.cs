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
        AttributeSettingsData settingsData = AttributeSettings.GetLatestAttributeSettingsData(this.childAttributeType);

        this.attributeTransform.localPosition = new Vector3(settingsData.horPos, settingsData.verPos, 0.0f);
        this.attributeTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, settingsData.rot);
        this.attributeTransform.localScale = new Vector3(settingsData.scaleX, settingsData.scaleY, 1.0f);

        if (settingsData.name == string.Empty)
        {
            this.attributeSprite.sprite = null;
        }
        else
        {
            //Sprite[] spritesheet = Resources.LoadAll<Sprite>(this.GetSpritePath() + settingsData.name);

            string specificSpriteName = settingsData.name + "_" + this.childIndex;
            //this.attributeSprite.sprite = spritesheet[specificSpriteName];

            this.attributeSprite.sprite = AttributeSpriteDicts.GetSprite(this.attributeType, specificSpriteName);
        }
        
        this.attributeSprite.sortingOrder = settingsData.dep;
        this.attributeSprite.flipX = settingsData.flipX;
        this.attributeSprite.flipY = settingsData.flipY;
        //Do colors later
    }
    
    public override void ResetAttribute()
    {
        AttributeSettings.SetAttributeSettings(this.childAttributeType, AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.childAttributeType), true);
    }

    public override void ResetAttributeSetting(AttributeSettingType settingToReset)
    {
        switch (settingToReset)
        {
            case AttributeSettingType.Horizontal_Position:
            case AttributeSettingType.Spacing:
                AttributeSettings.SetHorizontalPosition(this.childAttributeType, AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.childAttributeType).horPos);
                break;
            case AttributeSettingType.Vertical_Position:
                AttributeSettings.SetVerticalPosition(this.childAttributeType, AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.childAttributeType).verPos);
                break;
            case AttributeSettingType.Scale_X:
                AttributeSettings.SetScaleX(this.childAttributeType, AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.childAttributeType).scaleX);
                break;
            case AttributeSettingType.Scale_Y:
                AttributeSettings.SetScaleY(this.childAttributeType, AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.childAttributeType).scaleY);
                break;
            case AttributeSettingType.Rotation:
                AttributeSettings.SetRotation(this.childAttributeType, AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.childAttributeType).rot);
                break;
            case AttributeSettingType.Depth:
                AttributeSettings.SetDepth(this.childAttributeType, AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.childAttributeType).dep);
                break;
            default:
                Debug.LogError("Unknown Setting: " + settingToReset);
                return;
        }
    }

    #region Setters
    public override void SetAssetName(string newName)
    {
        AttributeSettings.SetName(this.childAttributeType, newName);
    }

    public override void SetHorizontalPosition(float newPos)
    {
        AttributeSettings.SetHorizontalPosition(this.childAttributeType, newPos);
    }

    public override void SetVerticalPosition(float newPos)
    {
        AttributeSettings.SetVerticalPosition(this.childAttributeType, newPos);
    }

    public override void SetScaleX(float newScale)
    {
        AttributeSettings.SetScaleX(this.childAttributeType, newScale);
    }

    public override void SetScaleY(float newScale)
    {
        AttributeSettings.SetScaleY(this.childAttributeType, newScale);
    }

    public override void SetRotation(float newRot)
    {
        AttributeSettings.SetRotation(this.childAttributeType, newRot);
    }

    public override void SetDepth(int newDepth)
    {
        AttributeSettings.SetDepth(this.childAttributeType, newDepth);
    }

    public override void SetColor(int colorIndex, int newColor)
    {
        AttributeSettings.SetColor(this.childAttributeType, colorIndex, newColor);
    }

    public override void SetFlipX()
    {
        AttributeSettings.SetFlipX(this.childAttributeType);
    }

    public override void SetFlipY()
    {
        AttributeSettings.SetFlipY(this.childAttributeType);
    }
    #endregion

    #region Getters
    public override string GetAssetName()
    {
        return AttributeSettings.GetAttributeSpriteName(this.childAttributeType);
    }

    public override float GetHorizontalPosition()
    {
        return AttributeSettings.GetAttributePosition(this.childAttributeType).x;
    }
    public override float GetVerticalPosition()
    {
        return AttributeSettings.GetAttributePosition(this.childAttributeType).y;
    }

    public override float GetScaleX()
    {
        return AttributeSettings.GetAttributeScale(this.childAttributeType).x;
    }

    public override float GetScaleY()
    {
        return AttributeSettings.GetAttributeScale(this.childAttributeType).y;
    }

    public override float GetRotation()
    {
        return AttributeSettings.GetAttributeRotation(this.childAttributeType);
    }

    public override int GetDepth()
    {
        return AttributeSettings.GetAttributeDepth(this.childAttributeType);
    }

    public override int[] GetColors()
    {
        return AttributeSettings.GetAttributeColors(this.childAttributeType);
    }

    public override bool GetFlipX()
    {
        return AttributeSettings.GetAttributeFlipX(this.childAttributeType);
    }

    public override bool GetFlipY()
    {
        return AttributeSettings.GetAttributeFlipY(this.childAttributeType);
    }
    #endregion
}
