using System;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum PanelButtonAnimationTriggers { Neutral, Appear, Hide, Release, Push, Hover, Disable, Enable }

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
        this.ChangeAnimationState(PanelButtonAnimationTriggers.Appear);
    }

    public void Hide()
    {
        this.interactable = false;
        this.ChangeAnimationState(PanelButtonAnimationTriggers.Hide);
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
        this.ChangeAnimationState(PanelButtonAnimationTriggers.Enable);
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
        this.ChangeAnimationState(PanelButtonAnimationTriggers.Disable);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        
        if (this.interactable == false)
        {
            return;
        }

        this.ChangeAnimationState(PanelButtonAnimationTriggers.Hover);

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
        
        this.ChangeAnimationState(PanelButtonAnimationTriggers.Neutral);

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

        this.ChangeAnimationState(PanelButtonAnimationTriggers.Push);

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
        this.ChangeAnimationState(PanelButtonAnimationTriggers.Neutral);

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

    protected void ChangeAnimationState(PanelButtonAnimationTriggers newState)
    {
        PanelButtonAnimationTriggers[] states =
            (PanelButtonAnimationTriggers[])Enum.GetValues(typeof(PanelButtonAnimationTriggers));

        for (int i = 0; i < states.Length; i++)
        {
            if (states[i] == newState)
            {
                this.animator.SetTrigger(states[i].ToString());
            }
            else
            {
                //this.animator.ResetTrigger(states[i].ToString());
            }
        }
    }
}