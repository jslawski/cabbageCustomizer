using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCabbageAttribute : CabbageAttribute
{
    protected SpriteRenderer attributeSprite;
    protected Transform attributeTransform;

    protected string GetSpritePath()
    {
        string spritePath = "CharacterCreator/";

        switch (this.attributeType)
        {
            case AttributeType.BaseCabbage:
                return spritePath + "Base/";
            case AttributeType.Headpiece:
                return spritePath + "Headpiece/";
            case AttributeType.Eyebrows:
                return spritePath + "Eyebrows/";
            case AttributeType.Eyes:
                return spritePath + "Eyes/";
            case AttributeType.Nose:
                return spritePath + "Nose/";
            case AttributeType.Mouth:
                return spritePath + "Mouth/";
            case AttributeType.Acc1:
            case AttributeType.Acc2:
            case AttributeType.Acc3:
                return spritePath + "Accessory/";
            default:
                Debug.LogError("Unknown AttributeType: " + attributeType);
                return "";
        }
    }

    public override void Initialize()
    {
        if (this.attributeSprite == null)
        {
            this.attributeSprite = GetComponent<SpriteRenderer>();
        }

        if (this.attributeTransform == null)
        {
            this.attributeTransform = GetComponent<Transform>();
        }
    }

    public override void UpdateAttributeObject()
    {
        AttributeSettingsData settingsData = AttributeSettingsManager.GetLatestAttributeSettingsData(this.attributeType);
        Sprite newSprite = Resources.Load<Sprite>(this.GetSpritePath() + settingsData.name);

        this.attributeTransform.localPosition = new Vector3(settingsData.horPos, settingsData.verPos, 0.0f);
        this.attributeTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, settingsData.rot);
        this.attributeTransform.localScale = new Vector3(settingsData.scaleX, settingsData.scaleY, 1.0f);


        this.attributeSprite.sprite = newSprite;
        this.attributeSprite.sortingOrder = settingsData.dep;
        this.attributeSprite.flipX = settingsData.flipX;
        this.attributeSprite.flipY = settingsData.flipY;
        //Do colors later 
    }

    public override void ResetAttribute()
    {
        AttributeSettingsManager.SetAttributeSettings(this.attributeType, AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.attributeType), true);
    }

    public override void ResetAttributeSetting(SliderSetting settingToReset)
    {
        switch (settingToReset)
        {
            case SliderSetting.Horizontal_Position:
                this.SetHorizontalPosition(AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.attributeType).horPos);
                break;
            case SliderSetting.Vertical_Position:
                this.SetVerticalPosition(AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.attributeType).verPos);
                break;
            case SliderSetting.Scale_X:
                this.SetScaleX(AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.attributeType).scaleX);
                break;
            case SliderSetting.Scale_Y:
                this.SetScaleY(AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.attributeType).scaleY);
                break;
            case SliderSetting.Rotation:
               this.SetRotation(AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.attributeType).rot);
                break;
            case SliderSetting.Depth:
                this.SetDepth(AttributeSettingsManager.defaultAttributeSettings.GetAttributeSettingsData(this.attributeType).dep);
                break;
            default:
                Debug.LogError("Unknown Setting: " + settingToReset);
                return;
        }
    }
    
    #region Setters
    public override void SetAssetName(string newName)
    {
        AttributeSettingsManager.SetName(this.attributeType, newName);        
    }

    public override void SetHorizontalPosition(float newPos)
    {
        AttributeSettingsManager.SetHorizontalPosition(this.attributeType, newPos);        
    }

    public override void SetVerticalPosition(float newPos)
    {
        AttributeSettingsManager.SetVerticalPosition(this.attributeType, newPos);        
    }

    public override void SetScaleX(float newScale)
    {
        AttributeSettingsManager.SetScaleX(this.attributeType, newScale);        
    }

    public override void SetScaleY(float newScale)
    {
        AttributeSettingsManager.SetScaleY(this.attributeType, newScale);        
    }

    public override void SetRotation(float newRot)
    {
        AttributeSettingsManager.SetRotation(this.attributeType, newRot);        
    }

    public override void SetDepth(int newDepth)
    {
        AttributeSettingsManager.SetDepth(this.attributeType, newDepth);        
    }

    public override void SetColor(int colorIndex, int newColor)
    {
        AttributeSettingsManager.SetColor(this.attributeType, colorIndex, newColor);        
    }

    public override void SetFlipX()
    {
        AttributeSettingsManager.SetFlipX(this.attributeType);        
    }

    public override void SetFlipY()
    {
        AttributeSettingsManager.SetFlipY(this.attributeType);        
    }
    #endregion

    #region Getters
    public override string GetAssetName()
    {
        return AttributeSettingsManager.GetAttributeSpriteName(this.attributeType);
    }

    public override float GetHorizontalPosition()
    {
        return AttributeSettingsManager.GetAttributePosition(this.attributeType).x;
    }
    public override float GetVerticalPosition()
    {
        return AttributeSettingsManager.GetAttributePosition(this.attributeType).y;
    }

    public override float GetScaleX()
    {
        return AttributeSettingsManager.GetAttributeScale(this.attributeType).x;
    }

    public override float GetScaleY()
    {
        return AttributeSettingsManager.GetAttributeScale(this.attributeType).y;
    }

    public override float GetRotation()
    {
        return AttributeSettingsManager.GetAttributeRotation(this.attributeType);
    }

    public override int GetDepth()
    {
        return AttributeSettingsManager.GetAttributeDepth(this.attributeType);
    }

    public override int[] GetColors()
    {
        return AttributeSettingsManager.GetAttributeColors(this.attributeType);
    }

    public override bool GetFlipX()
    {
        return AttributeSettingsManager.GetAttributeFlipX(this.attributeType);
    }

    public override bool GetFlipY()
    {
        return AttributeSettingsManager.GetAttributeFlipY(this.attributeType);
    }

    public override ChildCabbageAttribute[] GetChildren()
    {
        return new ChildCabbageAttribute[0];
    }
    #endregion
}
