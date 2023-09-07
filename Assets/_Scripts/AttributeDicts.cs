using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttributeDicts
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
        AttributeDicts.BaseCabbageDict = AttributeDicts.PopulateDict("Base");
        AttributeDicts.HeadpieceDict = AttributeDicts.PopulateDict("Headpiece");
        AttributeDicts.EyebrowsDict = AttributeDicts.PopulateDict("Eyebrows");
        AttributeDicts.EyesDict = AttributeDicts.PopulateDict("Eyes");
        AttributeDicts.NoseDict = AttributeDicts.PopulateDict("Nose");
        AttributeDicts.MouthDict = AttributeDicts.PopulateDict("Mouth");
        AttributeDicts.AccDict = AttributeDicts.PopulateDict("Accessory");
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
        AttributeDicts.BaseCabbageDict[customCabbageName] = Resources.Load<Sprite>("CharacterCreator/CustomCabbages/" + customCabbageName);
    }

    private static Dictionary<string, Sprite> GetDict(AttributeType attType)
    {
        switch (attType)
        {
            case AttributeType.BaseCabbage:
                return AttributeDicts.BaseCabbageDict;
            case AttributeType.Headpiece:
                return AttributeDicts.HeadpieceDict;
            case AttributeType.Eyebrows:
            case AttributeType.EyebrowL:
            case AttributeType.EyebrowR:
                return AttributeDicts.EyebrowsDict;
            case AttributeType.Eyes:
            case AttributeType.EyeL:
            case AttributeType.EyeR:
                return AttributeDicts.EyesDict;
            case AttributeType.Nose:
                return AttributeDicts.NoseDict;
            case AttributeType.Mouth:
                return AttributeDicts.MouthDict;
            case AttributeType.Acc1:
            case AttributeType.Acc2:
            case AttributeType.Acc3:
                return AttributeDicts.AccDict;
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
