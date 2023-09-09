using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCabbageAttribute : CabbageAttribute
{
    protected SpriteRenderer attributeSprite;
    protected Transform attributeTransform;
    
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
        AttributeSettingsData settingsData = AttributeSettings.GetLatestAttributeSettingsData(this.attributeType);
        Sprite newSprite = AttributeSpriteDicts.GetSprite(this.attributeType, settingsData.name);

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
        AttributeSettings.SetAttributeSettings(this.attributeType, AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.attributeType), true);
    }

    public override void ResetAttributeSetting(AttributeSettingType settingToReset)
    {
        switch (settingToReset)
        {
            case AttributeSettingType.Horizontal_Position:
                this.SetHorizontalPosition(AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.attributeType).horPos);
                break;
            case AttributeSettingType.Vertical_Position:
                this.SetVerticalPosition(AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.attributeType).verPos);
                break;
            case AttributeSettingType.Scale_X:
                this.SetScaleX(AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.attributeType).scaleX);
                break;
            case AttributeSettingType.Scale_Y:
                this.SetScaleY(AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.attributeType).scaleY);
                break;
            case AttributeSettingType.Rotation:
               this.SetRotation(AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.attributeType).rot);
                break;
            case AttributeSettingType.Depth:
                this.SetDepth(AttributeSettings.DefaultSettings.GetAttributeSettingsData(this.attributeType).dep);
                break;
            default:
                Debug.LogError("Unknown Setting: " + settingToReset);
                return;
        }
    }
    
    #region Setters
    public override void SetAssetName(string newName)
    {
        AttributeSettings.SetName(this.attributeType, newName);        
    }

    public override void SetHorizontalPosition(float newPos)
    {
        AttributeSettings.SetHorizontalPosition(this.attributeType, newPos);        
    }

    public override void SetVerticalPosition(float newPos)
    {
        AttributeSettings.SetVerticalPosition(this.attributeType, newPos);        
    }

    public override void SetScaleX(float newScale)
    {
        AttributeSettings.SetScaleX(this.attributeType, newScale);        
    }

    public override void SetScaleY(float newScale)
    {
        AttributeSettings.SetScaleY(this.attributeType, newScale);        
    }

    public override void SetRotation(float newRot)
    {
        AttributeSettings.SetRotation(this.attributeType, newRot);        
    }

    public override void SetDepth(int newDepth)
    {
        AttributeSettings.SetDepth(this.attributeType, newDepth);        
    }

    public override void SetColor(int colorIndex, int newColor)
    {
        AttributeSettings.SetColor(this.attributeType, colorIndex, newColor);        
    }

    public override void SetFlipX()
    {
        AttributeSettings.SetFlipX(this.attributeType);        
    }

    public override void SetFlipY()
    {
        AttributeSettings.SetFlipY(this.attributeType);        
    }
    #endregion

    #region Getters
    public override string GetAssetName()
    {
        return AttributeSettings.GetAttributeSpriteName(this.attributeType);
    }

    public override float GetHorizontalPosition()
    {
        return AttributeSettings.GetAttributePosition(this.attributeType).x;
    }
    public override float GetVerticalPosition()
    {
        return AttributeSettings.GetAttributePosition(this.attributeType).y;
    }

    public override float GetScaleX()
    {
        return AttributeSettings.GetAttributeScale(this.attributeType).x;
    }

    public override float GetScaleY()
    {
        return AttributeSettings.GetAttributeScale(this.attributeType).y;
    }

    public override float GetRotation()
    {
        return AttributeSettings.GetAttributeRotation(this.attributeType);
    }

    public override int GetDepth()
    {
        return AttributeSettings.GetAttributeDepth(this.attributeType);
    }

    public override int[] GetColors()
    {
        return AttributeSettings.GetAttributeColors(this.attributeType);
    }

    public override bool GetFlipX()
    {
        return AttributeSettings.GetAttributeFlipX(this.attributeType);
    }

    public override bool GetFlipY()
    {
        return AttributeSettings.GetAttributeFlipY(this.attributeType);
    }

    public override ChildCabbageAttribute[] GetChildren()
    {
        return new ChildCabbageAttribute[0];
    }
    #endregion
}
