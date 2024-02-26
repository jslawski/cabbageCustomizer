using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelButton : Button, IAnimatedUIElement
{
    public PanelButtonHelper panelButtonHelper;

    protected AudioChannelSettings sfxSettingsDefault_;
    protected AudioChannelSettings sfxSettingsRandomPitch_;

    protected override void Awake()
    {
        base.Awake();

        this.panelButtonHelper = GetComponent<PanelButtonHelper>();

        this.sfxSettingsDefault_ = new AudioChannelSettings(false, 1.0f, 1.0f, 1.0f, "SFX");
        this.sfxSettingsRandomPitch_ = new AudioChannelSettings(false, 0.9f, 1.1f, 1.0f, "SFX");

        this.onClick.AddListener(this.SelectButton);
    }

    public void Reveal()
    {
        this.ChangeAnimationState(AnimatedUIElementState.Appear);
    }

    public void Hide()
    {
        this.interactable = false;
        this.ChangeAnimationState(AnimatedUIElementState.Hide);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        
        if (this.interactable == false)
        {
            return;
        }

        this.ChangeAnimationState(AnimatedUIElementState.Hovered);

        if (this.panelButtonHelper.HighlightedSprite != null)
        {
            this.panelButtonHelper.buttonBackground.sprite = this.panelButtonHelper.HighlightedSprite;
        }

        if (this.panelButtonHelper.onPointerEnterSound != null)
        {
            AudioManager.instance.Play(this.panelButtonHelper.onPointerEnterSound, this.sfxSettingsRandomPitch_);
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

        if (this.panelButtonHelper.NormalSprite != null)
        {
            this.panelButtonHelper.buttonBackground.sprite = this.panelButtonHelper.NormalSprite;
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

        if (this.panelButtonHelper.PushedSprite != null)
        {
            this.panelButtonHelper.buttonBackground.sprite = this.panelButtonHelper.PushedSprite;
        }

        if (this.panelButtonHelper.onPointerDownSound != null)
        {
            AudioManager.instance.Play(this.panelButtonHelper.onPointerDownSound, this.sfxSettingsDefault_);
        }
    }

    public void SelectButton()
    {
        this.ChangeAnimationState(AnimatedUIElementState.Released);

        if (this.panelButtonHelper.NormalSprite != null)
        {
            this.panelButtonHelper.buttonBackground.sprite = this.panelButtonHelper.NormalSprite;
        }

        if (this.panelButtonHelper.onPointerUpSound != null)
        {
            AudioManager.instance.Play(this.panelButtonHelper.onPointerUpSound, this.sfxSettingsDefault_);
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