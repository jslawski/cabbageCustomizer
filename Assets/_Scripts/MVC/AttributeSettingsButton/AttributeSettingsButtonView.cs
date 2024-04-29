using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeSettingsButtonView : MonoBehaviour
{
    private AttributeSettingsButtonModel _model;

    [SerializeField]
    private Button _button;

    private void Awake()
    {
        this._model = GetComponent<AttributeSettingsButtonModel>();
    }

    private void UpdateSelectedStatus()
    {
        if (this._model.isSelected == true)
        {
            this._button.image.color = Color.yellow;
        }
        else
        {
            this._button.image.color = Color.white;
        }
    }

    public void UpdateView()
    {
        this.UpdateSelectedStatus();
    }
}
