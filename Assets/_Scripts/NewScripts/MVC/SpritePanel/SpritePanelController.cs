using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePanelController : MonoBehaviour
{
    private SpritePanelModel _model;
    private SpritePanelView _view;

    private void Awake()
    {
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

    public void ButtonClicked()
    {
        this._view.UpdateView();
    }

    public void RefreshView()
    {
        this._view.UpdateView();
    }
}
