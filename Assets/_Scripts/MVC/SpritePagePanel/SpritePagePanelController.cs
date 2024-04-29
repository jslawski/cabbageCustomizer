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

    private void Start()
    {
        this.RefreshView();
    }

    public void ButtonClicked(SpritePageButtonController selectedButton)
    {
        this._model.selectedButton = selectedButton;

        this.RefreshView();
    }

    private void SetButtonsInteractableStatus()
    {
        int maxPages = this._spritePanelController.GetMaxPages();

        if (this._spritePanelController.GetMaxPages() == 0)
        {
            this._model.allButtonControllers[0].SetInteractableStatus(false);
            this._model.allButtonControllers[1].SetInteractableStatus(false);
        }
        else if (this._spritePanelController.GetPageIndex() == 0)
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
        this.SetButtonsInteractableStatus();
        this._view.UpdateView();
    }
}
