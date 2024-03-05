using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelButton : Button
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
        this.interactable = true;
        this.ChangeAnimationState("Appear");
    }

    public void Hide()
    {
        this.interactable = false;
        this.ChangeAnimationState("Hide");
    }

    public void EnableHighlight()
    {
        if (this.panelButtonHelper.highlightBackground != null)
        {
            this.panelButtonHelper.highlightBackground.enabled = true;
        }
    }

    public void DisableHighlight()
    {
        if (this.panelButtonHelper.highlightBackground != null)
        {
            this.panelButtonHelper.highlightBackground.enabled = false;
        }
    }
    
    public void EnableButton()
    {
        this.interactable = true;

        StartCoroutine(this.EnableButtonCoroutine());
    }

    private IEnumerator EnableButtonCoroutine()
    {
        //Yield for one frame in case another Animation trigger is activated this frame
        yield return null;
        this.ChangeAnimationState("Enable");
    }

    public void DisableButton(bool animatedDisable)
    {
        this.interactable = false;

        if (animatedDisable == true)
        {
            StartCoroutine(this.DisableButtonCoroutine());
        }
    }

    private IEnumerator DisableButtonCoroutine()
    {
        //Yield for one frame in case another Animation trigger is activated this frame
        yield return null;
        this.ChangeAnimationState("Disable");
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        
        if (this.interactable == false)
        {
            return;
        }

        this.ChangeAnimationState("Hover");

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
        
        this.ChangeAnimationState("Neutral");

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

        this.ChangeAnimationState("Push");

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
        this.ChangeAnimationState("Neutral");

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

    protected void ChangeAnimationState(string newState)
    {
        StartCoroutine(this.FireAnimationTrigger(newState));
    }

    protected IEnumerator FireAnimationTrigger(string newState)
    {
        this.animator.SetTrigger(newState);

        yield return new WaitForSeconds(0.5f);

        this.animator.ResetTrigger(newState);
    }
}