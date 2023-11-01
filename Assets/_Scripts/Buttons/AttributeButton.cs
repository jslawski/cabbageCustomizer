using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CharacterCustomizer;

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
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(this.attributeType);

        if (this.isClearButton == true)
        {
            currentAttribute.SetAssetName(string.Empty);
        }
        else
        {
            string[] spriteNames = this.attributeSprites[0].name.Split("_");

            //Is a single attribute
            if (this.attributeSprites.Length == 1)
            {
                currentAttribute.SetAssetName(this.attributeSprites[0].name);
            }
            //Is a double attribute with "Both" selected
            else if (currentAttribute.GetChildren().Length > 1)
            {
                currentAttribute.GetChildren()[0].SetAssetName(this.attributeSprites[0].name);
                currentAttribute.GetChildren()[1].SetAssetName(this.attributeSprites[1].name);
            }
            //Is a double attribute with "Left" selected
            else if (currentAttribute.attributeType == AttributeType.EyebrowL || currentAttribute.attributeType == AttributeType.EyeL)
            {
                currentAttribute.SetAssetName(this.attributeSprites[0].name);
            }
            //Is a double attribute with "Right" selected
            else
            {
                currentAttribute.SetAssetName(this.attributeSprites[1].name);
            }            
        }

        currentAttribute.UpdateAttributeObject();
    }    
}
