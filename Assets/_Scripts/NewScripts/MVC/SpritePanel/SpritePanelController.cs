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

        if (MasterController.instance.GetCurrentAttributeType() != AttributeType.Eyebrows &&
            MasterController.instance.GetCurrentAttributeType() != AttributeType.Eyes)
        {
            attributeTypeButtonController.SetCenterSprite(this._model.selectedButton.GetCenterSprite());
        }
        else
        {
            attributeTypeButtonController.SetLeftSprite(this._model.selectedButton.GetLeftSprite());
            attributeTypeButtonController.SetRightSprite(this._model.selectedButton.GetRightSprite());
            //TODO: Update the dual attribute button with the newly selected sprites too
        }

        attributeTypeButtonController.RefreshView();
    }

    public override void RefreshView()
    {
        this._view.UpdateView();
    }
}
