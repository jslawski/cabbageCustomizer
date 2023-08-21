using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageAttribute : MonoBehaviour
{    
    public AttributeType attributeType;

    private SpriteRenderer attributeSprite;
    private Transform attributeTransform;

    private void Start()
    {
        if (this.attributeType != AttributeType.EyebrowB && this.attributeType != AttributeType.EyeB)
        {
            this.attributeSprite = GetComponent<SpriteRenderer>();
        }

        this.attributeTransform = GetComponent<Transform>();
    }

    private string GetSpritePath()
    {
        string spritePath = "CharacterCreator/";

        switch (this.attributeType)
        {
            case AttributeType.BaseCabbage:
                return spritePath + "Base/";
            case AttributeType.Headpiece:
                return spritePath + "Headpiece/";
            case AttributeType.EyebrowL:                
            case AttributeType.EyebrowR:                
            case AttributeType.EyebrowB:
                return spritePath + "Eyebrows/";                
            case AttributeType.EyeL:                
            case AttributeType.EyeR:                
            case AttributeType.EyeB:
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

    public void UpdateAttributeObject()
    {
        AttributeSettingsData settingsData = AttributeSettingsManager.GetLatestAttributeSettingsData(this.attributeType);

        this.attributeTransform.localPosition = new Vector3(settingsData.horPos, settingsData.verPos, 0.0f);
        this.attributeTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, settingsData.rot);

        if (this.attributeType != AttributeType.EyebrowB && this.attributeType != AttributeType.EyeB)
        {
            this.attributeTransform.localScale = new Vector3(settingsData.scaleX, settingsData.scaleY, 1.0f);
            this.attributeSprite.sprite = Resources.Load<Sprite>(this.GetSpritePath() + settingsData.name);
            this.attributeSprite.sortingOrder = settingsData.dep;
            this.attributeSprite.flipX = settingsData.flipX;
            this.attributeSprite.flipY = settingsData.flipY;
            //Do colors later
        }
    }

    public void UpdateAssetName(string newName)
    {
        AttributeSettingsManager.SetName(this.attributeType, newName);
        this.UpdateAttributeObject();
    }

    public void UpdateHorizontalPosition(float newPos)
    {
        AttributeSettingsManager.SetHorizontalPosition(this.attributeType, newPos);
        this.UpdateAttributeObject();
    }

    public void UpdateVerticalPosition(float newPos)
    {
        AttributeSettingsManager.SetVerticalPosition(this.attributeType, newPos);
        this.UpdateAttributeObject();
    }

    public void UpdateScaleX(float newScale)
    {
        AttributeSettingsManager.SetScaleX(this.attributeType, newScale);
        this.UpdateAttributeObject();
    }

    public void UpdateScaleY(float newScale)
    {
        AttributeSettingsManager.SetScaleY(this.attributeType, newScale);
        this.UpdateAttributeObject();
    }

    public void UpdateRotation(float newRot)
    {
        AttributeSettingsManager.SetRotation(this.attributeType, newRot);
        this.UpdateAttributeObject();
    }

    public void UpdateDepth(int newDepth)
    {
        AttributeSettingsManager.SetDepth(this.attributeType, newDepth);
        this.UpdateAttributeObject();
    }

    public void UpdateColor(int colorIndex, int newColor)
    {
        AttributeSettingsManager.SetColor(this.attributeType, colorIndex, newColor);
        this.UpdateAttributeObject();
    }

    public void UpdateFlipX()
    {
        AttributeSettingsManager.SetFlipX(this.attributeType);
        this.UpdateAttributeObject();
    }

    public void UpdateFlipY()
    {
        AttributeSettingsManager.SetFlipY(this.attributeType);
        this.UpdateAttributeObject();
    }
}


















/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType { BaseCabbage, Headpiece, EyebrowL, EyebrowR, EyebrowB, EyeL, EyeR, EyeB, Nose, Mouth, Acc1, Acc2, Acc3, None };
public enum AttributeSide { Left, Both, Right }

public abstract class CabbageAttribute : MonoBehaviour
{
    public AttributeSettingsData settingsData;

    [SerializeField]
    protected AttributeType attributeType;
    [SerializeField]
    protected AttributeSettings defaultSettings;

    protected Transform attributeTransform;
    protected AttributeSettings currentSettings;

    [HideInInspector]
    public AttributeSide attributeSide = AttributeSide.Both;
    public abstract void SetupAttribute();
    public abstract void UpdateSingleSprite(Sprite newSprite);
    public abstract void UpdateMultiSprite(Sprite[] newSprites);    
    public abstract void UpdateHorizontalPosition(float newXPosition);
    public abstract void UpdateVerticalPosition(float newYPosition);
    public abstract void UpdateScale(float newScale);
    public abstract void UpdateRotation(float newZRotation);
    public abstract void UpdateDepth(float newDepth);
    public abstract void UpdateXFlip(bool flipX);
    public abstract void UpdateSide(AttributeSide newSide);

    public abstract Sprite GetSingleSprite();
    public abstract Sprite[] GetMultiSprite();
    public abstract Vector3 GetPosition();
    public abstract Vector3 GetScale();
    public abstract Quaternion GetRotation();
    public abstract int GetDepth();
    public abstract bool GetXFlip();

    public abstract void ResetAttribute(bool resetSprite = false);
    protected abstract void ApplySettings();
}
*/