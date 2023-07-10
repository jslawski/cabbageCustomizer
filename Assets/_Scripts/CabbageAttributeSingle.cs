using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageAttributeSingle : CabbageAttribute
{
    private SpriteRenderer spriteRenderer;

    public override void SetupAttribute()
    {
        this.attributeTransform = GetComponent<Transform>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.attributeSide = AttributeSide.Both;

        this.currentSettings = new AttributeSettings();        

        this.ResetAttribute();        
    }

    public override void UpdateSingleSprite(Sprite newSprite)
    {
        this.currentSettings.sprite = newSprite;
        this.ApplySettings();
    }

    public override void UpdateMultiSprite(Sprite[] newSprites)
    {
        this.UpdateSingleSprite(newSprites[0]);
    }

    public override void UpdateHorizontalPosition(float newXPosition)
    {
        this.currentSettings.position = new Vector3(newXPosition, this.currentSettings.position.y, this.currentSettings.position.z);
        this.ApplySettings();
    }

    public override void UpdateVerticalPosition(float newYPosition)
    {
        this.currentSettings.position = new Vector3(this.currentSettings.position.x, newYPosition, this.currentSettings.position.z);
        this.ApplySettings();
    }

    public override void UpdateScale(float newScale)
    {
        this.currentSettings.scale = new Vector3(newScale, newScale, newScale);
        this.ApplySettings();
    }

    public override void UpdateRotation(float newZRotation)
    {
        this.currentSettings.rotation = Quaternion.Euler(0.0f, 0.0f, newZRotation);
        this.ApplySettings();
    }

    public override void UpdateDepth(float newDepth)
    {
        this.currentSettings.depth = (int)newDepth;
        this.ApplySettings();
    }

    public override void UpdateXFlip(bool flipX)
    {
        this.currentSettings.flipX = flipX;
        this.ApplySettings();
    }

    public override void UpdateSide(AttributeSide newSide)
    {
        //Do nothing
    }

    public override Sprite GetSingleSprite()
    {
        return this.currentSettings.sprite;
    }

    public override Sprite[] GetMultiSprite()
    {
        return null;
    }

    public override Vector3 GetPosition()
    {
        return this.currentSettings.position;
    }

    public override Vector3 GetScale()
    {
        return this.currentSettings.scale;
    }

    public override Quaternion GetRotation()
    {
        return this.currentSettings.rotation;
    }

    public override int GetDepth()
    {
        return this.currentSettings.depth;
    }

    public override bool GetXFlip()
    {
        return this.currentSettings.flipX;
    }

    public override void ResetAttribute(bool resetSprite = false)
    {
        AttributeSettings resetSettings = new AttributeSettings(this.defaultSettings);

        if (resetSprite == false)
        {
            resetSettings.sprite = this.currentSettings.sprite;
        }

        this.currentSettings = resetSettings;
        this.ApplySettings();
    }

    protected override void ApplySettings()
    {
        this.attributeTransform.localPosition = this.currentSettings.position;
        this.attributeTransform.localScale = this.currentSettings.scale;
        this.attributeTransform.localRotation = this.currentSettings.rotation;
        this.spriteRenderer.sprite = this.currentSettings.sprite;
        this.spriteRenderer.sortingOrder = this.currentSettings.depth;
        this.spriteRenderer.flipX = this.currentSettings.flipX;
    }
}
