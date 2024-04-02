using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class AttributeTypeButtonController : MonoBehaviour
{
    private AttributeTypeButtonModel _model;
    private AttributeTypeButtonView _view;

    private void Awake()
    {
        this._model = GetComponent<AttributeTypeButtonModel>();
        this._view = GetComponent<AttributeTypeButtonView>();
    }

    private void InitializeSprites()
    {
        if (this._model.attributeType == AttributeType.Eyebrows)
        {
            string leftSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyebrowL).name;
            string rightSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyebrowR).name;
            this.SetLeftSprite(this.GetSprite(leftSpriteName));
            this.SetRightSprite(this.GetSprite(rightSpriteName));
        }
        else if (this._model.attributeType == AttributeType.Eyes)
        {
            string leftSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeL).name;
            string rightSpriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(AttributeType.EyeR).name;
            this.SetLeftSprite(this.GetSprite(leftSpriteName));
            this.SetRightSprite(this.GetSprite(rightSpriteName));
        }
        else
        {
            string spriteName = AttributeSettings.CurrentSettings.GetAttributeSettingsData(this._model.attributeType).name;
            this.SetCenterSprite(this.GetSprite(spriteName));
        }
    }

    public void ButtonClicked()
    {
        CurrentCustomizerData.instance.SetCurrentAttributeType(this._model.attributeType);
    }

    public void SetSelectedStatus(bool isSelected)
    {
        this._model.isSelected = isSelected;
    }

    public void SetVisibleStatus(bool isVisible)
    {
        this._model.shouldShow = isVisible;
        this.InitializeSprites();
    }

    public void SetLeftSprite(Sprite newSprite)
    {
        this._model.leftSprite = newSprite;
    }

    public void SetRightSprite(Sprite newSprite)
    {
        this._model.rightSprite = newSprite;
    }

    public void SetCenterSprite(Sprite newSprite)
    {
        this._model.centerSprite = newSprite;
    }

    private Sprite GetSprite(string spriteName)
    {
        string folderName = "CharacterCreator/";

        if (spriteName == "")
        {
            return this._model.defaultSprite;
        }

        switch (this._model.attributeType)
        {
            case AttributeType.BaseCabbage:
                return (Resources.Load<Sprite>(folderName + "Base/" + spriteName));
            case AttributeType.Headpiece:
                return (Resources.Load<Sprite>(folderName + "Headpiece/" + spriteName));
            case AttributeType.EyebrowL:
            case AttributeType.EyebrowR:
                folderName += "Eyebrows/";
                return this.GetSpritesheetSprite(folderName, spriteName);
            case AttributeType.EyeL:
            case AttributeType.EyeR:
                folderName += "Eyes/";
                return this.GetSpritesheetSprite(folderName, spriteName);
            case AttributeType.Nose:
                return (Resources.Load<Sprite>(folderName + "Nose/" + spriteName));
            case AttributeType.Mouth:
                return (Resources.Load<Sprite>(folderName + "Mouth/" + spriteName));
            case AttributeType.Acc1:
            case AttributeType.Acc2:
            case AttributeType.Acc3:
                return (Resources.Load<Sprite>(folderName + "Accessory/" + spriteName));
            default:
                Debug.LogError("Unknown AttributeType: " + this._model.attributeType);
                return this._model.defaultSprite;
        }
    }

    private Sprite GetSpritesheetSprite(string folderName, string spriteName)
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

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
