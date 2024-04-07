using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePanelController : SettingsPanelController
{
    private SpritePanelModel _model;
    private SpritePanelView _view;

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
        this._view.UpdateView();
    }

    public override void RefreshView()
    {
        this._view.UpdateView();
    }
}
