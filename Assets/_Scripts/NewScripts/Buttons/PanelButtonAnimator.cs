using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButtonAnimator : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        this._button = GetComponent<Button>();
    }

    public void PlayRevealAnimation(Action revealCompletedCallback)
    {
        StartCoroutine(this.RevealAnimation(revealCompletedCallback));
    }

    private IEnumerator RevealAnimation(Action revealCompletedCallback)
    {
        this._button.enabled = true;
    
        yield return null; //Wait for animation to complete

        revealCompletedCallback();
    }

    public void PlayHideAnimation(Action hideCompletedCallback)
    {
        StartCoroutine(this.HideAnimation(hideCompletedCallback));
    }

    private IEnumerator HideAnimation(Action hideCompletedCallback)
    {
        this._button.enabled = false;    

        yield return null; //Wait for animation to complete

        hideCompletedCallback();
    }
}
