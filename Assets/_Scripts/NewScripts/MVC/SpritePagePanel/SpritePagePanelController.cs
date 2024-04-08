using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePagePanelController : MonoBehaviour
{
    private SpritePagePanelModel _model;
    private SpritePagePanelView _view;

    private SpritePanelController _spritePanelController;

    private void Awake()
    {
        this._model = GetComponent<SpritePagePanelModel>();
        this._view = GetComponent<SpritePagePanelView>();

        this._spritePanelController = GetComponentInParent<SpritePanelController>();
    }

    public void ButtonClicked(SpritePageButtonController selectedButton)
    {
        this._model.selectedButton = selectedButton;

        this.SetSelectedButtonInteractableStatus();
    }

    private void SetSelectedButtonInteractableStatus()
    {
        if (this._spritePanelController.GetPageIndex() == 0 ||
                this._spritePanelController.GetPageIndex() == this._spritePanelController.GetMaxPages())
        {
            this._model.selectedButton.SetInteractableStatus(false);
        }
        else
        {
            this._model.selectedButton.SetInteractableStatus(true);
        }
    }

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
