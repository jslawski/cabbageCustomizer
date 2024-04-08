using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePagePanelView : MonoBehaviour
{
    private SpritePagePanelModel _model;

    private void Awake()
    {
        this._model = GetComponent<SpritePagePanelModel>();
    }

    public void UpdateView()
    {
        for (int i = 0; i < this._model.allButtonControllers.Length; i++)
        {
            this._model.allButtonControllers[i].RefreshView();
        }
    }
}
