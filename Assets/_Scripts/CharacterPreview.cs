using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterPreview : MonoBehaviour
{
    public static CharacterPreview instance;

    private Dictionary<AttributeType, CabbageAttribute> attributeDict;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        this.SetupDictionary();
    }

    private void SetupDictionary()
    {
        this.attributeDict = new Dictionary<AttributeType, CabbageAttribute>();

        CabbageAttribute[] attributeArray = GetComponentsInChildren<CabbageAttribute>(true);

        this.attributeDict[AttributeType.BaseCabbage] = Array.Find(attributeArray, element => element.attributeType == AttributeType.BaseCabbage);
        this.attributeDict[AttributeType.Headpiece] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Headpiece);
        this.attributeDict[AttributeType.EyebrowL] = Array.Find(attributeArray, element => element.attributeType == AttributeType.EyebrowL);
        this.attributeDict[AttributeType.EyebrowR] = Array.Find(attributeArray, element => element.attributeType == AttributeType.EyebrowR);
        this.attributeDict[AttributeType.EyebrowB] = Array.Find(attributeArray, element => element.attributeType == AttributeType.EyebrowB);
        this.attributeDict[AttributeType.EyeL] = Array.Find(attributeArray, element => element.attributeType == AttributeType.EyeL);
        this.attributeDict[AttributeType.EyeR] = Array.Find(attributeArray, element => element.attributeType == AttributeType.EyeR);
        this.attributeDict[AttributeType.EyeB] = Array.Find(attributeArray, element => element.attributeType == AttributeType.EyeB);
        this.attributeDict[AttributeType.Nose] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Nose);
        this.attributeDict[AttributeType.Mouth] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Mouth);
        this.attributeDict[AttributeType.Acc1] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Acc1);
        this.attributeDict[AttributeType.Acc2] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Acc2);
        this.attributeDict[AttributeType.Acc3] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Acc3);
    }

    public void RandomlyGenerateCharacter()
    {
        //First set all attributes to their default values
        AttributeSettingsManager.Setup(JsonUtility.FromJson<AllAttributeSettingsData>(Resources.Load<TextAsset>("DefaultValues").ToString()));

        this.RandomlyGenerateBase();
        this.RandomlyGenerateHeadpiece();
        this.RandomlyGenerateEyebrows();
        this.RandomlyGenerateEyes();
        this.RandomlyGenerateNose();
        this.RandomlyGenerateMouth();
        this.RandomlyGenerateAccessory(AttributeType.Acc1);
        this.RandomlyGenerateAccessory(AttributeType.Acc2);
        this.RandomlyGenerateAccessory(AttributeType.Acc3);

        this.UpdateAllAttributes();
    }

    private bool FlipCoin()
    {
        return (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f);
    }

    private void RandomlyGenerateBase()
    {        
        //Base will always be cabbage
        AttributeSettingsManager.SetName(AttributeType.BaseCabbage, "cabbage");
        
        if (this.FlipCoin() == true)
        {
            AttributeSettingsManager.SetFlipX(AttributeType.BaseCabbage);
        }

        if (this.FlipCoin() == true)
        {
            AttributeSettingsManager.SetFlipY(AttributeType.BaseCabbage);
        }       
    }

    private void RandomlyGenerateHeadpiece()
    {
        Sprite[] allSprites = Resources.LoadAll<Sprite>("CharacterCreator/Headpiece");
        Sprite randomSprite = allSprites[UnityEngine.Random.Range(0, allSprites.Length)];
        AttributeSettingsManager.SetName(AttributeType.Headpiece, randomSprite.name);
        
        if (this.FlipCoin())
        AttributeSettingsManager.SetFlipX(AttributeType.Headpiece);
    }

    private void RandomlyGenerateEyebrows()
    {
        Sprite[] allSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyebrows");

        int randomOddIndex = UnityEngine.Random.Range(0, allSprites.Length);

        if (randomOddIndex % 2 != 0)
        {
            randomOddIndex -= 1;
        }
        
        Sprite randomSpriteL = allSprites[randomOddIndex];
        Sprite randomSpriteR = allSprites[randomOddIndex + 1];
        AttributeSettingsManager.SetName(AttributeType.EyebrowL, randomSpriteL.name);
        AttributeSettingsManager.SetName(AttributeType.EyebrowR, randomSpriteR.name);

        //Flip both eyebrows simultaneously
        if (this.FlipCoin() == true)
        {
            AttributeSettingsManager.SetFlipX(AttributeType.EyebrowL);
            AttributeSettingsManager.SetFlipX(AttributeType.EyebrowR);
        }

        if (this.FlipCoin() == true)
        {
            AttributeSettingsManager.SetFlipY(AttributeType.EyebrowL);
            AttributeSettingsManager.SetFlipY(AttributeType.EyebrowR);
        }
    }

    private void RandomlyGenerateEyes()
    {
        Sprite[] allSprites = Resources.LoadAll<Sprite>("CharacterCreator/Eyes");

        int randomOddIndex = UnityEngine.Random.Range(0, allSprites.Length);

        if (randomOddIndex % 2 != 0)
        {
            randomOddIndex -= 1;
        }

        Sprite randomSpriteL = allSprites[randomOddIndex];
        Sprite randomSpriteR = allSprites[randomOddIndex + 1];
        AttributeSettingsManager.SetName(AttributeType.EyeL, randomSpriteL.name);
        AttributeSettingsManager.SetName(AttributeType.EyeR, randomSpriteR.name);

        //Flip both eyes simultaneously
        if (this.FlipCoin() == true)
        {
            AttributeSettingsManager.SetFlipX(AttributeType.EyeL);
            AttributeSettingsManager.SetFlipX(AttributeType.EyeR);
        }

        if (this.FlipCoin() == true)
        {
            AttributeSettingsManager.SetFlipY(AttributeType.EyeL);
            AttributeSettingsManager.SetFlipY(AttributeType.EyeR);
        }
    }

    private void RandomlyGenerateNose()
    {
        Sprite[] allSprites = Resources.LoadAll<Sprite>("CharacterCreator/Nose");
        Sprite randomSprite = allSprites[UnityEngine.Random.Range(0, allSprites.Length)];
        AttributeSettingsManager.SetName(AttributeType.Nose, randomSprite.name);
        
        if (this.FlipCoin() == true)
        {
            AttributeSettingsManager.SetFlipX(AttributeType.Nose);
        }
    }

    private void RandomlyGenerateMouth()
    {
        Sprite[] allSprites = Resources.LoadAll<Sprite>("CharacterCreator/Mouth");
        Sprite randomSprite = allSprites[UnityEngine.Random.Range(0, allSprites.Length)];
        AttributeSettingsManager.SetName(AttributeType.Mouth, randomSprite.name);

        if (this.FlipCoin() == true)
        {
            AttributeSettingsManager.SetFlipX(AttributeType.Mouth);
        }

        if (this.FlipCoin() == true)
        {
            AttributeSettingsManager.SetFlipY(AttributeType.Mouth);
        }        
    }

    private void RandomlyGenerateAccessory(AttributeType accNum)
    {
        Sprite[] allSprites = Resources.LoadAll<Sprite>("CharacterCreator/Accessory");
        Sprite randomSprite = allSprites[UnityEngine.Random.Range(0, allSprites.Length)];
        AttributeSettingsManager.SetName(accNum, randomSprite.name);

        if (this.FlipCoin() == true)
        {
            AttributeSettingsManager.SetFlipX(accNum);
        }

        if (this.FlipCoin() == true)
        {
            AttributeSettingsManager.SetFlipY(accNum);
        }        
    }

    public void LoadCharacterFromPresetData(string settingsJSON)
    {
        AllAttributeSettingsData settingsData = JsonUtility.FromJson<AllAttributeSettingsData>(settingsJSON);

        AttributeSettingsManager.Setup(settingsData);

        this.UpdateAllAttributes();
    }

    public void UpdateAllAttributes()
    {
        foreach (KeyValuePair<AttributeType, CabbageAttribute> att in this.attributeDict)
        {
            att.Value.UpdateAttributeObject();
        }        
    }

    public void UpdateAttribute()
    {
        this.attributeDict[AttributeSettingsManager.currentAttribute].UpdateAttributeObject();       
    }
}