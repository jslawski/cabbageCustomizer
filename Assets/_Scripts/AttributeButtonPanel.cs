using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeButtonPanel : MonoBehaviour
{
    public static AttributeButtonPanel instance;

    [SerializeField]
    private GameObject attributeButtonPrefab;
    [SerializeField]
    private GameObject gridLayoutParent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        this.UpdateAttributeGrid(AttributeType.Base);
    }

    public void UpdateAttributeGrid(AttributeType selectedAttribute)
    {
        this.DestroyCurrentButtons();

        Sprite[] attributeSprites;

        switch (selectedAttribute)
        {
            case AttributeType.Base:
                attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Base");
                break;
            case AttributeType.Headpiece:
                attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Headpiece");
                break;
            case AttributeType.Eyebrows:
                attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyebrows");
                break;
            case AttributeType.Eyes:
                attributeSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyes");
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
                Debug.LogError("Unknown Attribute Type: " + selectedAttribute);
                break;
        }

        if (selectedAttribute != AttributeType.Base)
        {
            GameObject buttonInstance = Instantiate(this.attributeButtonPrefab, this.gridLayoutParent.transform);
            buttonInstance.GetComponent<AttributeButton>().SetupButton(selectedAttribute, new Sprite[] { Resources.Load<Sprite>("CharacterCreator/Clear") });
            buttonInstance.GetComponent<AttributeButton>().isClearButton = true;
        }

        if (selectedAttribute != AttributeType.Eyebrows && 
            selectedAttribute != AttributeType.Eyes)
        {
            foreach (Sprite newSprite in attributeSprites)
            {
                GameObject buttonInstance = Instantiate(this.attributeButtonPrefab, this.gridLayoutParent.transform);
                buttonInstance.GetComponent<AttributeButton>().SetupButton(selectedAttribute, new Sprite[] { newSprite });
            }
        }
        else
        {
            for (int i = 0; i < attributeSprites.Length - 1; i += 2)
            {
                GameObject buttonInstance = Instantiate(this.attributeButtonPrefab, this.gridLayoutParent.transform);
                buttonInstance.GetComponent<AttributeButton>().
                    SetupButton(selectedAttribute, 
                    new Sprite[] { attributeSprites[i], attributeSprites[i + 1]});
            }
        }
    }

    private void DestroyCurrentButtons()
    {
        for (int i = 0; i < this.gridLayoutParent.transform.childCount; i++)
        {
            Destroy(this.gridLayoutParent.transform.GetChild(i).gameObject);
        }
    }
}
