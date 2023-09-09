using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CabbageCustomizer;

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
        CabbageAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(this.attributeType);

        if (this.isClearButton == true)
        {
            currentAttribute.SetAssetName(string.Empty);
        }
        else
        {
            //Parse it this way to handle the case of single-sprite buttons and multi-sprite buttons
            string[] spriteNames = this.attributeSprites[0].name.Split("_");

            currentAttribute.SetAssetName(spriteNames[0]);
        }

        currentAttribute.UpdateAttributeObject();
    }    
}
