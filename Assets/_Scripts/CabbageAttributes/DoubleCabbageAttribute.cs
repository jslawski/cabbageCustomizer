using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCabbageAttribute : CabbageAttribute
{
    private ChildCabbageAttribute[] childAttributes;

    public override void Initialize()
    {
        this.childAttributes = GetComponentsInChildren<ChildCabbageAttribute>();

        for (int i = 0; i < this.childAttributes.Length; i++)
        {
            this.childAttributes[i].Initialize();
            this.childAttributes[i].childIndex = i;
        }        
    }

    public override void UpdateAttributeObject()
    {
        foreach (ChildCabbageAttribute att in this.childAttributes)
        {
            att.UpdateAttributeObject();
        }
    }

    public override void ResetAttribute()
    {
        foreach (ChildCabbageAttribute att in this.childAttributes)
        {
            att.ResetAttribute();
        }                
    }

    public override void ResetAttributeSetting(AttributeSettingType settingToReset)
    {
        foreach (ChildCabbageAttribute att in this.childAttributes)
        {
            att.ResetAttributeSetting(settingToReset);
        }
    }

    #region Setters
    public override void SetAssetName(string newName)
    {
        foreach (ChildCabbageAttribute att in this.childAttributes)
        {
            att.SetAssetName(newName);
        }        
    }
    
    //When the player is modifying this value on both attributes, it changes the "spacing" between them
    public override void SetHorizontalPosition(float newPos)
    {        
        float newSpacing = newPos / 2.0f;

        this.childAttributes[0].SetHorizontalPosition(-newPos);
        this.childAttributes[1].SetHorizontalPosition(newPos);        
    }

    public override void SetVerticalPosition(float newPos)
    {
        foreach (ChildCabbageAttribute att in this.childAttributes)
        {
            att.SetVerticalPosition(newPos);
        }
    }

    public override void SetScaleX(float newScale)
    {
        foreach (ChildCabbageAttribute att in this.childAttributes)
        {
            att.SetScaleX(newScale);
        }
    }

    public override void SetScaleY(float newScale)
    {
        foreach (ChildCabbageAttribute att in this.childAttributes)
        {
            att.SetScaleY(newScale);
        }
    }

    public override void SetRotation(float newRot)
    {
        this.childAttributes[0].SetRotation(newRot);
        this.childAttributes[1].SetRotation(-newRot);
    }

    public override void SetDepth(int newDepth)
    {
        foreach (ChildCabbageAttribute att in this.childAttributes)
        {
            att.SetDepth(newDepth);
        }
    }

    public override void SetColor(int colorIndex, int newColor)
    {
        foreach (ChildCabbageAttribute att in this.childAttributes)
        {
            att.SetColor(colorIndex, newColor);
        }
    }

    public override void SetFlipX()
    {
        foreach (ChildCabbageAttribute att in this.childAttributes)
        {
            att.SetFlipX();
        }
    }

    public override void SetFlipY()
    {
        foreach (ChildCabbageAttribute att in this.childAttributes)
        {
            att.SetFlipY();
        }
    }
    #endregion

    #region Getters
    //Both child attributes should have the same spritesheet name, so just use the first one
    public override string GetAssetName()
    {
        return this.childAttributes[0].GetAssetName();
    }

    public override float GetHorizontalPosition()
    {
        float left = this.childAttributes[0].GetHorizontalPosition();
        float right = this.childAttributes[1].GetHorizontalPosition();

        return ((left + right ) / 2.0f);
    }

    public override float GetVerticalPosition()
    {
        float left = this.childAttributes[0].GetVerticalPosition();
        float right = this.childAttributes[1].GetVerticalPosition();

        return ((left + right) / 2.0f);
    }

    public override float GetScaleX()
    {
        float left = this.childAttributes[0].GetScaleX();
        float right = this.childAttributes[1].GetScaleX();

        return ((left + right) / 2.0f);
    }

    public override float GetScaleY()
    {
        float left = this.childAttributes[0].GetScaleY();
        float right = this.childAttributes[1].GetScaleY();

        return ((left + right) / 2.0f);
    }

    public override float GetRotation()
    {
        float left = this.childAttributes[0].GetRotation();
        float right = this.childAttributes[1].GetRotation();

        return ((left + right) / 2.0f);
    }

    public override int GetDepth()
    {
        int left = this.childAttributes[0].GetDepth();
        int right = this.childAttributes[1].GetDepth();

        return Mathf.RoundToInt((left + right) / 2.0f);
    }

    public override int[] GetColors()
    {
        int[] left = this.childAttributes[0].GetColors();
        int[] right = this.childAttributes[1].GetColors();

        int[] average = new int[left.Length];

        for (int i = 0; i < left.Length; i++)
        {
            average[i] = Mathf.RoundToInt((left[i] + right[i]) / 2.0f);
        }

        return average;
    }

    //Just pick the first one
    public override bool GetFlipX()
    {
        return this.childAttributes[0].GetFlipX();
    }

    //Just pick the first one
    public override bool GetFlipY()
    {
        return this.childAttributes[0].GetFlipY();
    }

    public override ChildCabbageAttribute[] GetChildren()
    {
        return this.childAttributes;
    }
    #endregion
}