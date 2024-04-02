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
        this._model.selectedButton = selectedButton;
    
        this._model.showEyebrowsButtons = (CurrentCustomizerData.instance.currentAttributeType == AttributeType.Eyebrows);    
        this._model.showEyesButtons = (CurrentCustomizerData.instance.currentAttributeType == AttributeType.Eyes);

        this.RefreshView();
    }

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
