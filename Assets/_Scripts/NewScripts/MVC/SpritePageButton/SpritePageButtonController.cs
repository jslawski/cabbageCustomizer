using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePageButtonController : MonoBehaviour
{
    private SpritePageButtonModel _model;
    private SpritePageButtonView _view;

    private SpritePanelController _spritePanelController;

    private void Awake()
    {
        this._model = GetComponent<SpritePageButtonModel>();
        this._view = GetComponent<SpritePageButtonView>();

        this._spritePanelController = GetComponentInParent<SpritePanelController>();
    }

    public void ButtonClicked()
    {
        int newPageIndex = this._spritePanelController.GetPageIndex() + this._model.pageIncrement;
        this._spritePanelController.SetPageIndex(newPageIndex);

        this._spritePanelController.RefreshView();
    }

    public void SetInteractableStatus(bool isInteractable)
    {
        this._model.isInteractable = isInteractable;
    }

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
