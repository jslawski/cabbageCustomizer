using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSettingsPanelView : MonoBehaviour
{
    private AttributeSettingsPanelModel _model;

    private void Awake()
    {
        this._model = GetComponent<AttributeSettingsPanelModel>();
    }

    public void UpdateView()
    {
        for (int i = 0; i < this._model.allButtonControllers.Length; i++)
        {
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
    }
}
