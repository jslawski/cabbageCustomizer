using UnityEngine;
using CharacterCustomizer;

public static class AttributeAssetManager
{
    public static Sprite GetAttributeSprite(AttributeType attributeType, string spriteName)
    {
        string folderName = "CharacterCreator/";

        switch (attributeType)
        {
            case AttributeType.BaseCabbage:
                return (Resources.Load<Sprite>(folderName + "Base/" + spriteName));
            case AttributeType.Headpiece:
                return (Resources.Load<Sprite>(folderName + "Headpiece/" + spriteName));
            case AttributeType.Eyebrows:
            case AttributeType.EyebrowL:
            case AttributeType.EyebrowR:
                folderName += "Eyebrows/";
                return AttributeAssetManager.GetSpritesheetSprite(folderName, spriteName);
            case AttributeType.Eyes:
            case AttributeType.EyeL:
            case AttributeType.EyeR:
                folderName += "Eyes/";
                return AttributeAssetManager.GetSpritesheetSprite(folderName, spriteName);
            case AttributeType.Nose:
                return (Resources.Load<Sprite>(folderName + "Nose/" + spriteName));
            case AttributeType.Mouth:
                return (Resources.Load<Sprite>(folderName + "Mouth/" + spriteName));
            case AttributeType.Acc1:
            case AttributeType.Acc2:
            case AttributeType.Acc3:
                return (Resources.Load<Sprite>(folderName + "Accessory/" + spriteName));
            default:
                Debug.LogError("Unknown AttributeType: " + attributeType);
                return null;
        }
    }

    private static Sprite GetSpritesheetSprite(string folderName, string spriteName)
    {
        string[] spriteInfo = spriteName.Split("_");

        Sprite[] spritesheet = Resources.LoadAll<Sprite>(folderName + spriteInfo[0]);

        for (int i = 0; i < spritesheet.Length; i++)
        {
            if (spritesheet[i].name == spriteName)
            {
                return spritesheet[i];
            }
        }

        return null;
    }
}
