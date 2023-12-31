using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class AttributeButtonPanel : MonoBehaviour
{
    public static AttributeButtonPanel instance;

    [SerializeField]
    private GameObject attributeButtonPrefab;
    [SerializeField]
    private GameObject gridLayoutParent;

    private bool isDoubleAttribute = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Initialize()
    {
        this.UpdateAttributeGrid(AttributeType.BaseCabbage);
    }

    public void UpdateAttributeGrid(AttributeType selectedAttribute)
    {
        this.isDoubleAttribute = false;

        this.DestroyCurrentButtons();

        List<Sprite> attributeSprites = AttributeSpriteDicts.GetAllSprites(selectedAttribute);

        if (selectedAttribute == AttributeType.Eyebrows || selectedAttribute == AttributeType.Eyes)
        {
            this.isDoubleAttribute = true;
        }        

        if (selectedAttribute != AttributeType.BaseCabbage)
        {
            GameObject buttonInstance = Instantiate(this.attributeButtonPrefab, this.gridLayoutParent.transform);
            buttonInstance.GetComponent<AttributeButton>().SetupButton(selectedAttribute, new Sprite[] { Resources.Load<Sprite>("CharacterCreator/Clear") });
            buttonInstance.GetComponent<AttributeButton>().isClearButton = true;
        }

        if (this.isDoubleAttribute == false)
        {
            if (selectedAttribute == AttributeType.BaseCabbage || selectedAttribute == AttributeType.Acc1 ||
                selectedAttribute == AttributeType.Acc2 || selectedAttribute == AttributeType.Acc3)
            {
                List<Sprite> customCabbages = AttributeSpriteDicts.GetAllCustomCabbageSprites(CurrentPlayerData.data.customCabbages);

                for (int i = 0; i < customCabbages.Count; i++)
                {
                    GameObject buttonInstance = Instantiate(this.attributeButtonPrefab, this.gridLayoutParent.transform);
                    buttonInstance.GetComponent<AttributeButton>().SetupButton(selectedAttribute, new Sprite[] { customCabbages[i] });
                }
            }

            foreach (Sprite newSprite in attributeSprites)
            {
                GameObject buttonInstance = Instantiate(this.attributeButtonPrefab, this.gridLayoutParent.transform);
                buttonInstance.GetComponent<AttributeButton>().SetupButton(selectedAttribute, new Sprite[] { newSprite });
            }
        }
        else
        {
            for (int i = 0; i < attributeSprites.Count - 1; i += 2)
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
