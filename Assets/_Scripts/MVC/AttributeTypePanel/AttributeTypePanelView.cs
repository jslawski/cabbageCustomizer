using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeTypePanelView : MonoBehaviour
{
    private AttributeTypePanelModel _model;

    private void Awake()
    {
        this._model = GetComponent<AttributeTypePanelModel>();
    }
    
    public void UpdateView()
    {
        for (int i = 0; i < this._model.allButtonControllers.Length; i++)
        {
            this._model.allButtonControllers[i].SetVisibleStatus(true);

            if (this._model.allButtonControllers[i] == this._model.selectedButton)
            {
                this._model.allButtonControllers[i].SetSelectedStatus(true);
            }
            else
            {
                this._model.allButtonControllers[i].SetSelectedStatus(false);
            }

            this._model.allButtonControllers[i].RefreshView();

        }

        for (int i = 0; i < this._model.eyebrowsLeftRightButtonControllers.Length; i++)
        {
            this._model.eyebrowsLeftRightButtonControllers[i].SetVisibleStatus(this._model.showEyebrowsButtons);
            this._model.eyebrowsLeftRightButtonControllers[i].RefreshView();
        }

        for (int i = 0; i < this._model.eyesLeftRightButtonControllers.Length; i++)
        {
            this._model.eyesLeftRightButtonControllers[i].SetVisibleStatus(this._model.showEyesButtons);
            this._model.eyesLeftRightButtonControllers[i].RefreshView();
        }
    }
}