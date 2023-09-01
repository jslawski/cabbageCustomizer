using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType { BaseCabbage, Headpiece, Eyebrows, EyebrowL, EyebrowR, Eyes, EyeL, EyeR, Nose, Mouth, Acc1, Acc2, Acc3, None };

public abstract class CabbageAttribute : MonoBehaviour
{
    public AttributeType attributeType;

    public abstract void Initialize();

    public abstract void UpdateAttributeObject();

    public abstract void ResetAttribute();
    public abstract void ResetAttributeSetting(SliderSetting settingToReset);

    public abstract void SetAssetName(string newName);
    public abstract void SetHorizontalPosition(float newPos);
    public abstract void SetVerticalPosition(float newPos);
    public abstract void SetScaleX(float newScale);
    public abstract void SetScaleY(float newScale);
    public abstract void SetRotation(float newRot);
    public abstract void SetDepth(int newDepth);
    public abstract void SetColor(int colorIndex, int newColor);
    public abstract void SetFlipX();
    public abstract void SetFlipY();

    public abstract string GetAssetName();
    public abstract float GetHorizontalPosition();
    public abstract float GetVerticalPosition();
    public abstract float GetScaleX();
    public abstract float GetScaleY();
    public abstract float GetRotation();
    public abstract int GetDepth();
    public abstract int[] GetColors();
    public abstract bool GetFlipX();
    public abstract bool GetFlipY();

    public abstract ChildCabbageAttribute[] GetChildren();
}