using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritePageButtonView : MonoBehaviour
{
    private SpritePageButtonModel _model;

    private Button _button;

    private void Awake()
    {
        this._model = GetComponent<SpritePageButtonModel>();
        this._button = GetComponent<Button>();
    }

    public void UpdateView()
    {
        this._button.interactable = this._model.isInteractable;
    }
}
