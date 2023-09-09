using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageCharacter : MonoBehaviour
{
    private Dictionary<AttributeType, CabbageAttribute> attributeDict;

    private void Awake()
    {
        this.SetupDict();
    }

    private void SetupDict()
    {
        CabbageAttribute[] attributeArray = GetComponentsInChildren<CabbageAttribute>(true);

        this.attributeDict = new Dictionary<AttributeType, CabbageAttribute>();
        this.attributeDict[AttributeType.BaseCabbage] = Array.Find(attributeArray, element => element.attributeType == AttributeType.BaseCabbage);
        this.attributeDict[AttributeType.Headpiece] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Headpiece);
        this.attributeDict[AttributeType.Eyebrows] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Eyebrows);
        this.attributeDict[AttributeType.Eyes] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Eyes);
        this.attributeDict[AttributeType.Nose] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Nose);
        this.attributeDict[AttributeType.Mouth] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Mouth);
        this.attributeDict[AttributeType.Acc1] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Acc1);
        this.attributeDict[AttributeType.Acc2] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Acc2);
        this.attributeDict[AttributeType.Acc3] = Array.Find(attributeArray, element => element.attributeType == AttributeType.Acc3);

        this.InitializeAttributes();

        //Add child attributes
        this.attributeDict[AttributeType.EyebrowL] = this.attributeDict[AttributeType.Eyebrows].GetChildren()[0];
        this.attributeDict[AttributeType.EyebrowR] = this.attributeDict[AttributeType.Eyebrows].GetChildren()[1];
        this.attributeDict[AttributeType.EyeL] = this.attributeDict[AttributeType.Eyes].GetChildren()[0];
        this.attributeDict[AttributeType.EyeR] = this.attributeDict[AttributeType.Eyes].GetChildren()[1];
    }

    private void InitializeAttributes()
    {
        foreach (KeyValuePair<AttributeType, CabbageAttribute> entry in this.attributeDict)
        {
            entry.Value.Initialize();
        }
    }

    public void LoadCharacterFromJSON(string settingsJSON)
    {
        AllAttributeSettingsData settingsData = JsonUtility.FromJson<AllAttributeSettingsData>(settingsJSON);

        if (settingsData.baseCabbage.name != string.Empty)
        {
            AttributeSettings.LoadData(settingsData);
        }
        else
        {
            this.RandomlyGenerateCharacter();
        }

        this.UpdateAllAttributes();
    }

    public void UpdateAllAttributes()
    {
        foreach (KeyValuePair<AttributeType, CabbageAttribute> entry in this.attributeDict)
        {
            entry.Value.UpdateAttributeObject();
        }
    }

    public CabbageAttribute GetAttribute(AttributeType attType)
    {
        return this.attributeDict[attType];
    }

    private bool FlipCoin()
    {
        bool result = UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f;

        return result;
    }

    public void RandomlyGenerateCharacter()
    {
        //First set all attributes to their default values
        AttributeSettings.LoadData(AttributeSettings.DefaultSettings);

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

    private void RandomlyGenerateBase()
    {
        //Base will always be cabbage
        CabbageAttribute associatedAttribute = this.GetAttribute(AttributeType.BaseCabbage);

        associatedAttribute.SetAssetName("cabbage");

        if (this.FlipCoin() == true)
        {
            associatedAttribute.SetFlipX();
        }

        if (this.FlipCoin() == true)
        {
            associatedAttribute.SetFlipY();
        }
    }

    private void RandomlyGenerateHeadpiece()
    {
        List<Sprite> allSprites = AttributeSpriteDicts.GetAllSprites(AttributeType.Headpiece);
        Sprite randomSprite = allSprites[UnityEngine.Random.Range(0, allSprites.Count)];

        CabbageAttribute associatedAttribute = this.GetAttribute(AttributeType.Headpiece);

        associatedAttribute.SetAssetName(randomSprite.name);

        if (this.FlipCoin())
        {
            associatedAttribute.SetFlipX();
        }
    }

    private void RandomlyGenerateEyebrows()
    {
        List<Sprite> allSprites = AttributeSpriteDicts.GetAllSprites(AttributeType.Headpiece);

        int randomOddIndex = UnityEngine.Random.Range(0, allSprites.Count);

        if (randomOddIndex % 2 != 0)
        {
            randomOddIndex -= 1;
        }

        Sprite randomSprite = allSprites[randomOddIndex];

        //Only store the spritesheet name, not the sprite itself
        //Ex: "eyes1", but not "eyes1_0"
        //Resources.Load<Sprite>() can't find the sprite if you don't reference the spritesheet name
        string[] spriteNames = randomSprite.name.Split("_");

        CabbageAttribute associatedAttribute = this.GetAttribute(AttributeType.Eyebrows);

        associatedAttribute.SetAssetName(spriteNames[0]);

        //Flip both eyebrows simultaneously
        if (this.FlipCoin() == true)
        {
            associatedAttribute.SetFlipX();
        }
        if (this.FlipCoin() == true)
        {
            associatedAttribute.SetFlipY();
        }

        //Randomize scale individually
        associatedAttribute.GetChildren()[0].SetScaleX(UnityEngine.Random.Range(2.0f, 4.0f));
        associatedAttribute.GetChildren()[0].SetScaleY(UnityEngine.Random.Range(2.0f, 4.0f));
        associatedAttribute.GetChildren()[1].SetScaleX(UnityEngine.Random.Range(2.0f, 4.0f));
        associatedAttribute.GetChildren()[1].SetScaleY(UnityEngine.Random.Range(2.0f, 4.0f));

        //Randomize position individually
        associatedAttribute.GetChildren()[0].SetHorizontalPosition(UnityEngine.Random.Range(-4.0f, -2.0f));
        associatedAttribute.GetChildren()[0].SetVerticalPosition(UnityEngine.Random.Range(0.0f, 2.0f));
        associatedAttribute.GetChildren()[1].SetHorizontalPosition(UnityEngine.Random.Range(2.0f, 4.0f));
        associatedAttribute.GetChildren()[1].SetVerticalPosition(UnityEngine.Random.Range(0.0f, 2.0f));
    }

    private void RandomlyGenerateEyes()
    {
        List<Sprite> allSprites = AttributeSpriteDicts.GetAllSprites(AttributeType.Eyes);

        int randomOddIndex = UnityEngine.Random.Range(0, allSprites.Count);

        if (randomOddIndex % 2 != 0)
        {
            randomOddIndex -= 1;
        }

        Sprite randomSprite = allSprites[randomOddIndex];

        //Only store the spritesheet name, not the sprite itself
        //Ex: "eyes1", but not "eyes1_0"
        //Resources.Load<Sprite>() can't find the sprite if you don't reference the spritesheet name
        string[] spriteNames = randomSprite.name.Split("_");

        CabbageAttribute associatedAttribute = this.GetAttribute(AttributeType.Eyes);

        associatedAttribute.SetAssetName(spriteNames[0]);

        //Flip both eyes simultaneously
        if (this.FlipCoin() == true)
        {
            associatedAttribute.SetFlipX();
        }
        if (this.FlipCoin() == true)
        {
            associatedAttribute.SetFlipY();
        }

        //Randomize scale individually
        associatedAttribute.GetChildren()[0].SetScaleX(UnityEngine.Random.Range(2.0f, 4.0f));
        associatedAttribute.GetChildren()[0].SetScaleY(UnityEngine.Random.Range(2.0f, 4.0f));
        associatedAttribute.GetChildren()[1].SetScaleX(UnityEngine.Random.Range(2.0f, 4.0f));
        associatedAttribute.GetChildren()[1].SetScaleY(UnityEngine.Random.Range(2.0f, 4.0f));

        //Randomize position individually
        associatedAttribute.GetChildren()[0].SetHorizontalPosition(UnityEngine.Random.Range(-4.0f, -2.0f));
        associatedAttribute.GetChildren()[0].SetVerticalPosition(UnityEngine.Random.Range(-2.0f, 0.5f));
        associatedAttribute.GetChildren()[1].SetHorizontalPosition(UnityEngine.Random.Range(2.0f, 4.0f));
        associatedAttribute.GetChildren()[1].SetVerticalPosition(UnityEngine.Random.Range(-2.0f, 0.5f));
    }

    private void RandomlyGenerateNose()
    {
        List<Sprite> allSprites = AttributeSpriteDicts.GetAllSprites(AttributeType.Nose);
        Sprite randomSprite = allSprites[UnityEngine.Random.Range(0, allSprites.Count)];

        CabbageAttribute associatedAttribute = this.GetAttribute(AttributeType.Nose);

        associatedAttribute.SetAssetName(randomSprite.name);

        if (this.FlipCoin() == true)
        {
            associatedAttribute.SetFlipX();
        }

        associatedAttribute.SetScaleX(UnityEngine.Random.Range(2.0f, 4.0f));
        associatedAttribute.SetScaleY(UnityEngine.Random.Range(2.0f, 4.0f));
    }

    private void RandomlyGenerateMouth()
    {
        List<Sprite> allSprites = AttributeSpriteDicts.GetAllSprites(AttributeType.Mouth);
        Sprite randomSprite = allSprites[UnityEngine.Random.Range(0, allSprites.Count)];

        CabbageAttribute associatedAttribute = this.GetAttribute(AttributeType.Mouth);

        associatedAttribute.SetAssetName(randomSprite.name);

        if (this.FlipCoin() == true)
        {
            associatedAttribute.SetFlipX();
        }

        if (this.FlipCoin() == true)
        {
            associatedAttribute.SetFlipY();
        }

        associatedAttribute.SetScaleX(UnityEngine.Random.Range(2.0f, 4.0f));
        associatedAttribute.SetScaleY(UnityEngine.Random.Range(2.0f, 4.0f));
    }

    private void RandomlyGenerateAccessory(AttributeType accNum)
    {
        //50% chance to not spawn an accessory
        if (this.FlipCoin() == true)
        {
            return;
        }

        List<Sprite> allSprites = AttributeSpriteDicts.GetAllSprites(accNum);
        Sprite randomSprite = allSprites[UnityEngine.Random.Range(0, allSprites.Count)];

        CabbageAttribute associatedAttribute = this.GetAttribute(accNum);

        associatedAttribute.SetAssetName(randomSprite.name);

        if (this.FlipCoin() == true)
        {
            associatedAttribute.SetFlipX();
        }

        float uniformScale = UnityEngine.Random.Range(0.5f, 1.5f);

        associatedAttribute.SetScaleX(uniformScale);
        associatedAttribute.SetScaleY(uniformScale);
    }
}
