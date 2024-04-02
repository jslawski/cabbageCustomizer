using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CharacterCustomizer;

public class AttributeTypeButtonView : MonoBehaviour
{
    private AttributeTypeButtonModel _model;
    
    [SerializeField]
    private Image _leftImage;
    [SerializeField]
    private Image _rightImage;
    [SerializeField]
    private Image _centerImage;

    [SerializeField]
    private Button _button;

    private void Awake()
    {
        this._model = GetComponent<AttributeTypeButtonModel>();
    }

    private void Start()
    {
        if (this._model.attributeType == AttributeType.Eyebrows ||
        this._model.attributeType == AttributeType.Eyes)
        {
            this._leftImage.gameObject.SetActive(true);
            this._rightImage.gameObject.SetActive(true);
            this._centerImage.gameObject.SetActive(false);
        }
        else
        {
            this._leftImage.gameObject.SetActive(false);
            this._rightImage.gameObject.SetActive(false);
            this._centerImage.gameObject.SetActive(true);
        }
    }

    private void UpdateVisibleStatus()
    {
        this.gameObject.SetActive(this._model.shouldShow);
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

    private void UpdateButtonSprites()
    {
        this._leftImage.sprite = this._model.leftSprite;
        this._rightImage.sprite = this._model.rightSprite;
        this._centerImage.sprite = this._model.centerSprite;
    }

    public void UpdateView()
    {
        this.UpdateVisibleStatus();
        this.UpdateSelectedStatus();
        this.UpdateButtonSprites();
    }
}
