using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButtonAnimator : MonoBehaviour
{
    private Image[] buttonImages;

    public void PlayRevealAnimation(Action revealCompletedCallback)
    {
        StartCoroutine(this.RevealAnimation(revealCompletedCallback));
    }

    private IEnumerator RevealAnimation(Action revealCompletedCallback)
    {
        Image[] buttonImages = GetComponentsInChildren<Image>(true);

        for (int i = 0; i < buttonImages.Length; i++)
        {
            buttonImages[i].enabled = true;
        }

        yield return null; //Wait for animation to complete

        revealCompletedCallback();
    }

    public void PlayHideAnimation(Action hideCompletedCallback)
    {
        StartCoroutine(this.HideAnimation(hideCompletedCallback));
    }

    private IEnumerator HideAnimation(Action hideCompletedCallback)
    {
        Image[] buttonImages = GetComponentsInChildren<Image>(true);

        for (int i = 0; i < buttonImages.Length; i++)
        {
            buttonImages[i].enabled = false;
        }

        yield return null; //Wait for animation to complete

        hideCompletedCallback();
    }
}
