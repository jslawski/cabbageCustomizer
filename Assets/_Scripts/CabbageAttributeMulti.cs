using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CabbageAttributeMulti : CabbageAttribute
{
    private CabbageAttributeSingle[] childAttributes;
        
    public override void SetupAttribute()
    {
        this.attributeTransform = GetComponent<Transform>();
        this.childAttributes = GetComponentsInChildren<CabbageAttributeSingle>();
        this.attributeSide = AttributeSide.Both;

        this.currentSettings = new AttributeSettings();

        foreach (CabbageAttributeSingle childAttribute in this.childAttributes)
        {
            childAttribute.SetupAttribute();
        }

        this.ResetAttribute();
    }

    public override void UpdateSingleSprite(Sprite newSprite)
    {
        //Do nothing
    }

    public override void UpdateMultiSprite(Sprite[] newSprites)
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
                this.childAttributes[0].UpdateSingleSprite(newSprites[0]);
                return;
            case AttributeSide.Both:
                this.childAttributes[0].UpdateSingleSprite(newSprites[0]);
                this.childAttributes[1].UpdateSingleSprite(newSprites[1]);
                return;
            case AttributeSide.Right:
                this.childAttributes[1].UpdateSingleSprite(newSprites[1]);
                return;
        }
    }

    public override void UpdateHorizontalPosition(float newXPosition)
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
                this.childAttributes[0].UpdateHorizontalPosition(newXPosition);
                break;
            case AttributeSide.Both:
                this.currentSettings.position = new Vector3(newXPosition, this.currentSettings.position.y, this.currentSettings.position.z);
                ApplySettings();
                break;
            case AttributeSide.Right:
                this.childAttributes[1].UpdateHorizontalPosition(newXPosition);
                break;
        }
    }

    public override void UpdateVerticalPosition(float newYPosition)
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
                this.childAttributes[0].UpdateVerticalPosition(newYPosition);
                break;
            case AttributeSide.Both:
                this.currentSettings.position = new Vector3(this.currentSettings.position.x, newYPosition, this.currentSettings.position.z);
                ApplySettings();
                break;
            case AttributeSide.Right:
                this.childAttributes[1].UpdateVerticalPosition(newYPosition);
                break;
        }
    }

    public override void UpdateScale(float newScale)
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
                this.childAttributes[0].UpdateScale(newScale);
                break;
            case AttributeSide.Both:
                this.childAttributes[0].UpdateScale(newScale);
                this.childAttributes[1].UpdateScale(newScale);                
                break;
            case AttributeSide.Right:
                this.childAttributes[1].UpdateScale(newScale);
                break;
        }
    }

    public override void UpdateRotation(float newZRotation)
    {       
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
                this.childAttributes[0].UpdateRotation(newZRotation);
                break;
            case AttributeSide.Both:
                this.currentSettings.rotation = Quaternion.Euler(0.0f, 0.0f, newZRotation);
                ApplySettings();
                break;
            case AttributeSide.Right:
                this.childAttributes[1].UpdateRotation(newZRotation);
                break;
        }
    }

    public override void UpdateDepth(float newDepth)
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
                this.childAttributes[0].UpdateDepth(newDepth);
                break;
            case AttributeSide.Both:
                this.childAttributes[0].UpdateDepth(newDepth);
                this.childAttributes[1].UpdateDepth(newDepth);                
                break;
            case AttributeSide.Right:
                this.childAttributes[1].UpdateDepth(newDepth);
                break;
        }
    }

    public override void UpdateXFlip(bool flipX)
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
                this.childAttributes[0].UpdateXFlip(flipX);
                break;
            case AttributeSide.Both:
                this.childAttributes[0].UpdateXFlip(flipX);
                this.childAttributes[1].UpdateXFlip(flipX);
                break;
            case AttributeSide.Right:
                this.childAttributes[1].UpdateXFlip(flipX);
                break;
        }
    }

    public override void UpdateSide(AttributeSide newSide)
    {
        this.attributeSide = newSide;
    }

    public override Sprite GetSingleSprite()
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
                return this.childAttributes[0].GetSingleSprite();                                       
            case AttributeSide.Right:
                return this.childAttributes[1].GetSingleSprite();
            case AttributeSide.Both:
            default:
                return null;
        }
    }

    public override Sprite[] GetMultiSprite()
    {
        return new Sprite[2] { this.childAttributes[0].GetSingleSprite(), this.childAttributes[1].GetSingleSprite() };
    }

    public override Vector3 GetPosition()
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
                return this.childAttributes[0].GetPosition();
            case AttributeSide.Both:
                return this.currentSettings.position;                
            case AttributeSide.Right:
                return this.childAttributes[1].GetPosition();
            default:
                return Vector3.zero;
        }
    }

    public override Vector3 GetScale()
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
            case AttributeSide.Both:
                return this.childAttributes[0].GetScale();                
            case AttributeSide.Right:
                return this.childAttributes[1].GetScale();
            default:
                return Vector3.zero;
        }
    }

    public override Quaternion GetRotation()
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
                return this.childAttributes[0].GetRotation();
            case AttributeSide.Both:
                return this.currentSettings.rotation;
            case AttributeSide.Right:
                return this.childAttributes[1].GetRotation();
            default:
                return new Quaternion();
        }
    }
    
    public override int GetDepth()
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
            case AttributeSide.Both:
                return this.childAttributes[0].GetDepth();
            case AttributeSide.Right:
                return this.childAttributes[1].GetDepth();
            default:
                return -5;
        }
    }

    public override bool GetXFlip()
    {
        switch (this.attributeSide)
        {
            case AttributeSide.Left:
            case AttributeSide.Both:
                return this.childAttributes[0].GetXFlip();
            case AttributeSide.Right:
                return this.childAttributes[1].GetXFlip();
            default:
                return false;
        }
    }

    public override void ResetAttribute(bool resetSprite = false)
    {
        this.currentSettings = new AttributeSettings(this.defaultSettings);
        this.ApplySettings();

        foreach (CabbageAttributeSingle childAttribute in this.childAttributes)
        {
            childAttribute.ResetAttribute(resetSprite);
        }
    }

    protected override void ApplySettings()
    {
        this.attributeTransform.localPosition = this.currentSettings.position;
        this.attributeTransform.localRotation = this.currentSettings.rotation;
        this.attributeTransform.localScale = this.currentSettings.scale;
    }
}
