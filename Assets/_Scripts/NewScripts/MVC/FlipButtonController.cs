using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class FlipButtonController : MonoBehaviour
{
    public bool flipX = false;
    public bool flipY = false;

    public void ButtonClicked()
    {
        if (MasterController.instance.GetCurrentAttributeType() == AttributeType.Eyebrows ||
            MasterController.instance.GetCurrentAttributeType() == AttributeType.Eyes)
        {
            this.FlipDoubleAttribute();
        }
        else
        {
            this.FlipSingleAttribute();
        }
    }
    
    private void FlipSingleAttribute()
    {
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(MasterController.instance.GetCurrentAttributeType());

        if (this.flipX == true)
        {
            currentAttribute.SetFlipX();
        }
        if (this.flipY == true)
        {
            currentAttribute.SetFlipY();
        }
        
        currentAttribute.UpdateAttributeObject();
    }

    private void FlipDoubleAttribute()
    {
        CharacterAttribute leftAttribute;
        CharacterAttribute rightAttribute;

        if (MasterController.instance.GetCurrentAttributeType() == AttributeType.Eyebrows)
        {
            leftAttribute = CharacterPreview.instance.GetCachedAttribute(AttributeType.EyebrowL);
            rightAttribute = CharacterPreview.instance.GetCachedAttribute(AttributeType.EyebrowR);

        }
        else if (MasterController.instance.GetCurrentAttributeType() == AttributeType.Eyes)
        {
            leftAttribute = CharacterPreview.instance.GetCachedAttribute(AttributeType.EyeL);
            rightAttribute = CharacterPreview.instance.GetCachedAttribute(AttributeType.EyeR);
        }
        else
        {
            Debug.LogError("Unknown Attribute Type: " + MasterController.instance.GetCurrentAttributeType());
            return;
        }

        if (this.flipX == true)
        {
            leftAttribute.SetFlipX();
            rightAttribute.SetFlipX();
        }
        if (this.flipY == true)
        {
            leftAttribute.SetFlipY();
            rightAttribute.SetFlipY();
        }
        
        leftAttribute.UpdateAttributeObject();
        rightAttribute.UpdateAttributeObject();
    }
}
