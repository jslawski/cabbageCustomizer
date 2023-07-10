using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType { Base, Headpiece, Eyebrows, Eyes, Nose, Mouth, Accessory1, Accessory2, Accessory3 };
public enum AttributeSide { Left, Both, Right }

public abstract class CabbageAttribute : MonoBehaviour
{
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
