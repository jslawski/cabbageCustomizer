using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AttributeButton : MonoBehaviour
{
    [HideInInspector]
    public AttributeType attributeType;
    [HideInInspector]
    public Sprite[] attributeSprites;

    [SerializeField]
    private Image leftImage;
    [SerializeField]
    private Image rightImage;
    [SerializeField]
    private Image centerImage;

    [HideInInspector]
    public bool isClearButton = false;

    public void SetupButton(AttributeType newType, Sprite[] newSprites)
    {
        this.attributeType = newType;
        this.attributeSprites = newSprites;

        this.SetupButtonImages(newSprites);
    }

    private void SetupButtonImages(Sprite[] newSprites)
    {
        if (newSprites.Length > 1)
        {
            this.centerImage.enabled = false;
            this.leftImage.enabled = true;
            this.rightImage.enabled = true;

            this.leftImage.sprite = newSprites[0];
            this.rightImage.sprite = newSprites[1];
        }
        else
        {
            this.centerImage.enabled = true;
            this.leftImage.enabled = false;
            this.rightImage.enabled = false;

            this.centerImage.sprite = newSprites[0];
        }
    }

    public void EquipAttribute()
    {
        if (this.isClearButton == true)
        {
            AttributeSettingsManager.SetName(this.attributeType, "");
        }
        else if (AttributeSettingsManager.currentAttribute == AttributeType.EyebrowB ||
            AttributeSettingsManager.currentAttribute == AttributeType.EyeB)
        {
            this.SetMultipleAttributeNames();
        }
        else
        {
            AttributeSettingsManager.SetName(this.attributeType, this.attributeSprites[0].name);
        }

        CharacterPreview.instance.UpdateAttribute();
    }

    private void SetMultipleAttributeNames()
    {
        if (AttributeSettingsManager.currentAttribute == AttributeType.EyebrowB)
        {
            AttributeSettingsManager.SetName(AttributeType.EyebrowL, this.attributeSprites[0].name);
            AttributeSettingsManager.SetName(AttributeType.EyebrowR, this.attributeSprites[1].name);
        }
        else if (AttributeSettingsManager.currentAttribute == AttributeType.EyeB)
        {
            AttributeSettingsManager.SetName(AttributeType.EyeL, this.attributeSprites[0].name);
            AttributeSettingsManager.SetName(AttributeType.EyeR, this.attributeSprites[1].name);
        }
    }
}
