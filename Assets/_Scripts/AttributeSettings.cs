using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttributeSettings
{
    public Sprite sprite;
    public Vector3 position;
    public Vector3 scale;
    public Quaternion rotation;
    public int depth;
    public bool flipX;

    public AttributeSettings()
    {
        this.sprite = null;
        this.position = Vector3.zero;
        this.scale = Vector3.zero;
        this.rotation = new Quaternion();
        this.depth = 0;
        this.flipX = false;
    }

    public AttributeSettings(Sprite newSprite, Vector3 newPosition, Vector3 newScale, Quaternion newRotation, int newDepth, bool newFlipX, bool newFlipY)
    {
        this.sprite = newSprite;
        this.position = newPosition;
        this.scale = newScale;
        this.rotation = newRotation;
        this.depth = newDepth;
        this.flipX = newFlipX;
    }

    public AttributeSettings(AttributeSettings other)
    {
        if (other != null)
        {
            this.sprite = other.sprite;
            this.position = other.position;
            this.scale = other.scale;
            this.rotation = other.rotation;
            this.depth = other.depth;
            this.flipX = other.flipX;
        }
    }
}
