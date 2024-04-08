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

        this.SetSelectedButtonInteractableStatus();
    }

    public void ButtonClicked(SpritePageButtonController selectedButton)
    {
        this._model.selectedButton = selectedButton;

        this.SetSelectedButtonInteractableStatus();

        this.RefreshView();
    }

    public void SetSelectedButtonInteractableStatus()
    {
        if (this._spritePanelController.GetPageIndex() == 0)
        {
            this._model.allButtonControllers[0].SetInteractableStatus(false);
            this._model.allButtonControllers[1].SetInteractableStatus(true);
        }
        else if (this._spritePanelController.GetPageIndex() == this._spritePanelController.GetMaxPages())
        {
            this._model.allButtonControllers[0].SetInteractableStatus(true);
            this._model.allButtonControllers[1].SetInteractableStatus(false);
        }
        else
        {
            this._model.allButtonControllers[0].SetInteractableStatus(true);
            this._model.allButtonControllers[1].SetInteractableStatus(true);
        }
    }

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
