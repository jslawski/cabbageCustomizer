using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(PanelButtonHelper))]
public class PanelButton : Button, IAnimatedUIElement
{
    protected PanelButtonHelper panelButtonHelper_;

    protected AudioChannelSettings sfxSettingsDefault_;
    protected AudioChannelSettings sfxSettingsRandomPitch_;

    protected override void Awake()
    {
        base.Awake();

        this.panelButtonHelper_ = GetComponent<PanelButtonHelper>();

        this.sfxSettingsDefault_ = new AudioChannelSettings(false, 1.0f, 1.0f, 1.0f, "SFX");
        this.sfxSettingsRandomPitch_ = new AudioChannelSettings(false, 0.9f, 1.1f, 1.0f, "SFX");
    }

    public void Reveal()
    {
        this.ChangeAnimationState(AnimatedUIElementState.Appear);
        StartCoroutine(EnableButton());
    }

    public void Hide()
    {
        this.interactable = false;
        this.ChangeAnimationState(AnimatedUIElementState.Hide);
    }

    private IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(0.5f);
        this.interactable = true;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        
        if (this.interactable == false)
        {
            return;
        }

        this.ChangeAnimationState(AnimatedUIElementState.Hovered);

        if (this.panelButtonHelper_.HighlightedSprite != null)
        {
            this.panelButtonHelper_.buttonBackground.sprite = this.panelButtonHelper_.HighlightedSprite;
        }

        if (this.panelButtonHelper_.onPointerEnterSound != null)
        {
            AudioManager.instance.Play(this.panelButtonHelper_.onPointerEnterSound, this.sfxSettingsRandomPitch_);
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);

        if (this.interactable == false)
        {
            return;
        }
        
        this.ChangeAnimationState(AnimatedUIElementState.Neutral);

        if (this.panelButtonHelper_.NormalSprite != null)
        {
            this.panelButtonHelper_.buttonBackground.sprite = this.panelButtonHelper_.NormalSprite;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        if (this.interactable == false)
        {
            return;
        }

        this.ChangeAnimationState(AnimatedUIElementState.Pushed);

        if (this.panelButtonHelper_.PushedSprite != null)
        {
            this.panelButtonHelper_.buttonBackground.sprite = this.panelButtonHelper_.PushedSprite;
        }

        if (this.panelButtonHelper_.onPointerDownSound != null)
        {
            AudioManager.instance.Play(this.panelButtonHelper_.onPointerDownSound, this.sfxSettingsDefault_);
        }
    }

    public void SelectButton()
    {
        this.ChangeAnimationState(AnimatedUIElementState.Released);

        if (this.panelButtonHelper_.NormalSprite != null)
        {
            this.panelButtonHelper_.buttonBackground.sprite = this.panelButtonHelper_.NormalSprite;
        }

        if (this.panelButtonHelper_.onPointerUpSound != null)
        {
            AudioManager.instance.Play(this.panelButtonHelper_.onPointerUpSound, this.sfxSettingsDefault_);
        }

        this.SelectedCallback();
    }

    protected virtual void SelectedCallback()
    {

    }

    protected void ChangeAnimationState(AnimatedUIElementState newState)
    {
        AnimatedUIElementState[] states =
            (AnimatedUIElementState[])Enum.GetValues(typeof(AnimatedUIElementState));

        for (int i = 0; i < states.Length; i++)
        {
            if (states[i] == newState)
            {
                this.animator.SetTrigger(states[i].ToString());
            }
            else
            {
                this.animator.ResetTrigger(states[i].ToString());
            }
        }
    }
}