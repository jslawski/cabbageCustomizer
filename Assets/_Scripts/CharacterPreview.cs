using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPreview : MonoBehaviour
{
    public CabbageAttribute baseAttribute;
    public CabbageAttribute headpieceAttribute;
    public CabbageAttribute eyebrowsAttribute;
    public CabbageAttribute eyesAttribute;
    public CabbageAttribute noseAttribute;
    public CabbageAttribute mouthAttribute;
    public CabbageAttribute accessory1Attribute;
    public CabbageAttribute accessory2Attribute;
    public CabbageAttribute accessory3Attribute;

    public AttributeType currentAttribute;

    public static CharacterPreview instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        this.SetupAttributes();

        this.RandomlyGenerateCharacter();
    }

    private void SetupAttributes()
    {
        this.baseAttribute.SetupAttribute();
        this.headpieceAttribute.SetupAttribute();
        this.eyebrowsAttribute.SetupAttribute();
        this.eyesAttribute.SetupAttribute();
        this.noseAttribute.SetupAttribute();
        this.mouthAttribute.SetupAttribute();
        this.accessory1Attribute.SetupAttribute();
        this.accessory2Attribute.SetupAttribute();
        this.accessory3Attribute.SetupAttribute();
    }

    public CabbageAttribute GetAttributeFromType(AttributeType attributeType)
    {
        switch (attributeType)
        {
            case AttributeType.Base:
                return this.baseAttribute;                
            case AttributeType.Headpiece:
                return this.headpieceAttribute;
                
            case AttributeType.Eyebrows:
                return this.eyebrowsAttribute;
            case AttributeType.Eyes:
                return this.eyesAttribute;
            case AttributeType.Nose:
                return this.noseAttribute;
            case AttributeType.Mouth:
                return this.mouthAttribute;
            case AttributeType.Accessory1:
                return this.accessory1Attribute;
            case AttributeType.Accessory2:
                return this.accessory2Attribute;
            case AttributeType.Accessory3:
                return this.accessory3Attribute;
            default:                
                Debug.LogError("Unknown Attribute Type: " + attributeType);
                return null;
        }
    }

    public void RandomlyGenerateCharacter()
    {
        //Base will always be cabbage
        this.baseAttribute.UpdateSingleSprite(Resources.Load<Sprite>("CharacterCreator/Base/cabbage"));
        this.headpieceAttribute.UpdateSingleSprite(this.RandomlySelectSingleSprite(AttributeType.Headpiece));
        this.eyebrowsAttribute.UpdateMultiSprite(this.RandomlySelectMultiSprite(AttributeType.Eyebrows));
        this.eyesAttribute.UpdateMultiSprite(this.RandomlySelectMultiSprite(AttributeType.Eyes));
        this.noseAttribute.UpdateSingleSprite(this.RandomlySelectSingleSprite(AttributeType.Nose));
        this.mouthAttribute.UpdateSingleSprite(this.RandomlySelectSingleSprite(AttributeType.Mouth));
        this.accessory1Attribute.UpdateSingleSprite(this.RandomlySelectSingleSprite(AttributeType.Accessory1));
        this.accessory2Attribute.UpdateSingleSprite(this.RandomlySelectSingleSprite(AttributeType.Accessory2));
        this.accessory3Attribute.UpdateSingleSprite(this.RandomlySelectSingleSprite(AttributeType.Accessory3));
    }

    private Sprite RandomlySelectSingleSprite(AttributeType attributeType)
    {
        Sprite[] attributeSprites;

        switch (attributeType)
        {
            case AttributeType.Base:
                attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Base");
                break;
            case AttributeType.Headpiece:
                attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Headpiece");
                break;
            case AttributeType.Nose:
                attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Nose");
                break;
            case AttributeType.Mouth:
                attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Mouth");
                break;
            case AttributeType.Accessory1:
            case AttributeType.Accessory2:
            case AttributeType.Accessory3:
                attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Accessory");
                break;
            default:
                attributeSprites = new Sprite[1];
                Debug.LogError("Incompatible Attribute Type: " + attributeType);
                break;
        }

        return attributeSprites[Random.Range(0, attributeSprites.Length)];
    }

    private Sprite[] RandomlySelectMultiSprite(AttributeType attributeType)
    {
        Sprite[] attributeSprites;

        switch (attributeType)
        {
            case AttributeType.Eyebrows:
                attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyebrows");
                break;
            case AttributeType.Eyes:
                attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyes");
                break;
            default:
                attributeSprites = new Sprite[1];
                Debug.LogError("Unknown Attribute Type: " + attributeType);
                break;
        }

        int randomOddIndex = Random.Range(0, attributeSprites.Length);

        if (randomOddIndex % 2 != 0)
        {
            randomOddIndex -= 1;
        }

        return new Sprite[] { attributeSprites[randomOddIndex], attributeSprites[randomOddIndex + 1] };


    }
}
