using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelButton : Button
{
    public Image centerAttributeSprite;
    public Image leftAttributeSprite;
    public Image rightAttributeSprite;

    [SerializeField]
    protected Image buttonBackground_;
    [SerializeField]
    protected Image highlightBackground_;

    [SerializeField]
    protected Sprite normalSprite_;
    [SerializeField]
    protected Sprite highlightedSprite_;
    [SerializeField]
    protected Sprite pushedSprite_;

    [SerializeField]
    protected AudioClip onPointerEnterSound_;
    [SerializeField]
    protected AudioClip onPointerDownSound_;
    [SerializeField]
    protected AudioClip onPointerUpSound_;

    protected AudioChannelSettings sfxSettingsDefault_;
    protected AudioChannelSettings sfxSettingsRandomPitch_;

    protected ButtonPanel buttonPanel_;

    protected override void Awake()
    {
        base.Awake();

        this.sfxSettingsDefault_ = new AudioChannelSettings(false, 1.0f, 1.0f, 0.5f, "SFX");
        this.sfxSettingsRandomPitch_ = new AudioChannelSettings(false, 0.9f, 1.1f, 0.5f, "SFX");

        this.buttonPanel_ = GetComponentInParent<ButtonPanel>();
    }

    public virtual void Reveal()
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
        if (this.highlightBackground_ != null)
        {
            this.highlightBackground_.enabled = true;
        }
    }

    public void DisableHighlight()
    {
        if (this.highlightBackground_ != null)
        {
            this.highlightBackground_.enabled = false;
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

        if (this.highlightedSprite_ != null)
        {
            this.buttonBackground_.sprite = this.highlightedSprite_;
        }

        if (this.onPointerEnterSound_ != null)
        {
            AudioManager.instance.Play(this.onPointerEnterSound_, this.sfxSettingsRandomPitch_);
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

        if (this.normalSprite_ != null)
        {
            this.buttonBackground_.sprite = this.normalSprite_;
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

        if (this.pushedSprite_ != null)
        {
            this.buttonBackground_.sprite = this.pushedSprite_;
        }

        if (this.onPointerDownSound_ != null)
        {
            AudioManager.instance.Play(this.onPointerDownSound_, this.sfxSettingsDefault_);
        }
    }

    public virtual void SelectButton()
    {
        this.ChangeAnimationState("Neutral");

        if (this.normalSprite_ != null)
        {
            this.buttonBackground_.sprite = this.normalSprite_;
        }

        if (this.onPointerUpSound_ != null)
        {
            AudioManager.instance.Play(this.onPointerUpSound_, this.sfxSettingsDefault_);
        }

        this.buttonPanel_.SelectPanelButton(this);
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