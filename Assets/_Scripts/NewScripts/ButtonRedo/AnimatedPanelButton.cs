using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnimatedPanelButton: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _button;

    [SerializeField]
    private Sprite _defaultSprite;
    [SerializeField]
    private Sprite _highlightedSprite;
    
    [SerializeField]
    private Image _buttonBG;

    private Coroutine _highlightCoroutine = null;

    private void Awake()
    {
        this._button = GetComponent<Button>();
        //his._button.
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        this._buttonBG.sprite = this._highlightedSprite;

        if (this._highlightCoroutine == null)
        {
            this._highlightCoroutine = StartCoroutine(this.HighlightCoroutine());
        }
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        this._buttonBG.sprite = this._defaultSprite;
        StopCoroutine(this._highlightCoroutine);
        this._highlightCoroutine = null;
    }

    private IEnumerator HighlightCoroutine()
    {
    while (this._button.animator.GetCurrentAnimatorStateInfo(0).IsName("Highlighted") == false || this._button.animator.IsInTransition(0) == true)
        {
            Debug.LogError("Transitioning");    
            yield return null;
        }
        Debug.LogError("Done transitioning");
        while (this._button.animator.GetCurrentAnimatorStateInfo(0).IsName("Highlighted"))
        {
            Debug.LogError("Doin' highlight stuff now");
            yield return null;
        }
    }
}
