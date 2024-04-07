using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class AttributeTypePanelController : MonoBehaviour
{
    private AttributeTypePanelModel _model;
    private AttributeTypePanelView _view;

    private void Awake()
    {
        this._model = GetComponent<AttributeTypePanelModel>();
        this._view = GetComponent<AttributeTypePanelView>();
    }

    private void Start()
    {
        this.RefreshView();
    }

    public void ButtonClicked(AttributeTypeButtonController selectedButton)
    {
        AttributeType currentAttributeType = MasterController.instance.GetCurrentAttributeType();
    
        this._model.selectedButton = selectedButton;

        this._model.showEyebrowsButtons = (currentAttributeType == AttributeType.Eyebrows ||
                                            currentAttributeType == AttributeType.EyebrowL ||
                                            currentAttributeType == AttributeType.EyebrowR);

        this._model.showEyesButtons = (currentAttributeType == AttributeType.Eyes ||
                                        currentAttributeType == AttributeType.EyeL ||
                                        currentAttributeType == AttributeType.EyeR);

        MasterController.instance.RefreshView();

        this.RefreshView();
    }

    public AttributeTypeButtonController GetSelectedButton()
    {
        return this._model.selectedButton;
    }

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
