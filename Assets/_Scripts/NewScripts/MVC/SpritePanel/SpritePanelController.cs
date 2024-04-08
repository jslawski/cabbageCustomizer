using UnityEngine;
using CharacterCustomizer;

public class SpritePanelController : SettingsPanelController
{
    private SpritePanelModel _model;
    private SpritePanelView _view;

    [SerializeField]
    private AttributeTypePanelController _attributeTypePanelController;

    protected override void Awake()
    {
        base.Awake();
    
        this._model = GetComponent<SpritePanelModel>();
        this._view = GetComponent<SpritePanelView>();
    }

    private void Start()
    {
        this.RefreshView();
    }

    public void SetPageIndex(int newIndex)
    {
        this._model.pageIndex = newIndex;
    }

    public void ButtonClicked(SpriteButtonController selectedButton)
    {
        this._model.selectedButton = selectedButton;

        this.UpdateAttributeTypePanelButtonSprite();

        this.RefreshView();
    }

    private void UpdateAttributeTypePanelButtonSprite()
    {
        AttributeTypeButtonController attributeTypeButtonController = this._attributeTypePanelController.GetSelectedButton();
        AttributeType currentAttributeType = MasterController.instance.GetCurrentAttributeType();

        if (currentAttributeType != AttributeType.Eyebrows && currentAttributeType != AttributeType.Eyes)
        {
            attributeTypeButtonController.SetCenterSprite(this._model.selectedButton.GetCenterSprite());
        }
        else
        {
            attributeTypeButtonController.SetLeftSprite(this._model.selectedButton.GetLeftSprite());
            attributeTypeButtonController.SetRightSprite(this._model.selectedButton.GetRightSprite());
        }

        attributeTypeButtonController.RefreshView();

        this.UpdateDoubleAttributePanelButtonSprite();
    }

    private void UpdateDoubleAttributePanelButtonSprite()
    {
        AttributeType currentAttributeType = MasterController.instance.GetCurrentAttributeType();

        if (currentAttributeType == AttributeType.EyebrowL || currentAttributeType == AttributeType.EyebrowR)
        {
            AttributeTypeButtonController eyebrowsController = this._attributeTypePanelController.GetAttributeTypeButtonController(AttributeType.Eyebrows);

            if (currentAttributeType == AttributeType.EyebrowL)
            {
                eyebrowsController.SetLeftSprite(this._model.selectedButton.GetCenterSprite());
            }
            else
            {
                eyebrowsController.SetRightSprite(this._model.selectedButton.GetCenterSprite());
            }

            eyebrowsController.RefreshView();
        }
        else if (currentAttributeType == AttributeType.EyeL || currentAttributeType == AttributeType.EyeR)
        {
            AttributeTypeButtonController eyesController = this._attributeTypePanelController.GetAttributeTypeButtonController(AttributeType.Eyes);

            if (currentAttributeType == AttributeType.EyeL)
            {
                eyesController.SetLeftSprite(this._model.selectedButton.GetCenterSprite());
            }
            else
            {
                eyesController.SetRightSprite(this._model.selectedButton.GetCenterSprite());
            }

            eyesController.RefreshView();
        }
    }

    public override void RefreshView()
    {
        this._view.UpdateView();
    }
}
