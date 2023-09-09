using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttributeSpriteDicts
{
    private static Dictionary<string, Sprite> BaseCabbageDict;
    private static Dictionary<string, Sprite> HeadpieceDict;
    private static Dictionary<string, Sprite> EyebrowsDict;
    private static Dictionary<string, Sprite> EyesDict;
    private static Dictionary<string, Sprite> NoseDict;
    private static Dictionary<string, Sprite> MouthDict;
    private static Dictionary<string, Sprite> AccDict;    

    public static void Setup()
    {
        AttributeSpriteDicts.BaseCabbageDict = AttributeSpriteDicts.PopulateDict("Base");
        AttributeSpriteDicts.HeadpieceDict = AttributeSpriteDicts.PopulateDict("Headpiece");
        AttributeSpriteDicts.EyebrowsDict = AttributeSpriteDicts.PopulateDict("Eyebrows");
        AttributeSpriteDicts.EyesDict = AttributeSpriteDicts.PopulateDict("Eyes");
        AttributeSpriteDicts.NoseDict = AttributeSpriteDicts.PopulateDict("Nose");
        AttributeSpriteDicts.MouthDict = AttributeSpriteDicts.PopulateDict("Mouth");
        AttributeSpriteDicts.AccDict = AttributeSpriteDicts.PopulateDict("Accessory");
    }

    private static Dictionary<string, Sprite> PopulateDict(string resourcesFolder)
    {
        Dictionary<string, Sprite> returnDict = new Dictionary<string, Sprite>();

        Sprite[] allSprites = Resources.LoadAll<Sprite>("CharacterCreator/" + resourcesFolder + "/");

        foreach (Sprite curSprite in allSprites)
        {
            returnDict[curSprite.name] = curSprite;
        }

        return returnDict;
    }

    public static void AddCustomCabbage(string customCabbageName)
    {
        AttributeSpriteDicts.BaseCabbageDict[customCabbageName] = Resources.Load<Sprite>("CharacterCreator/CustomCabbages/" + customCabbageName);
    }

    private static Dictionary<string, Sprite> GetDict(AttributeType attType)
    {
        switch (attType)
        {
            case AttributeType.BaseCabbage:
                return AttributeSpriteDicts.BaseCabbageDict;
            case AttributeType.Headpiece:
                return AttributeSpriteDicts.HeadpieceDict;
            case AttributeType.Eyebrows:
            case AttributeType.EyebrowL:
            case AttributeType.EyebrowR:
                return AttributeSpriteDicts.EyebrowsDict;
            case AttributeType.Eyes:
            case AttributeType.EyeL:
            case AttributeType.EyeR:
                return AttributeSpriteDicts.EyesDict;
            case AttributeType.Nose:
                return AttributeSpriteDicts.NoseDict;
            case AttributeType.Mouth:
                return AttributeSpriteDicts.MouthDict;
            case AttributeType.Acc1:
            case AttributeType.Acc2:
            case AttributeType.Acc3:
                return AttributeSpriteDicts.AccDict;
            default:
                Debug.LogError("Unknown AttributeType: " + attType);
                return null;
        }
    }

    public static Sprite GetSprite(AttributeType attType, string spriteName)
    {
        Dictionary<string, Sprite> targetDict = GetDict(attType);
        
        if (targetDict != null && targetDict.ContainsKey(spriteName))
        {
            return targetDict[spriteName];
        }

        return null;
    }

    public static List<Sprite> GetAllSprites(AttributeType attType)
    {
        Dictionary<string, Sprite> targetDict = GetDict(attType);

        List<Sprite> allSprites = new List<Sprite>();

        if (targetDict != null)
        {
            foreach (KeyValuePair<string, Sprite> pair in targetDict)
            {
                allSprites.Add(pair.Value);
            }

            return allSprites;
        }

        return allSprites;
    }
}
