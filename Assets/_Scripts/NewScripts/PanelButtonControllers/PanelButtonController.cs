using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButtonController : MonoBehaviour
{
    protected Button button_;

    protected ButtonPanel buttonPanel_;

    protected PanelButtonAnimator panelButtonAnimator_;

    protected Image centerSprite_;
    protected Image leftSprite_;
    protected Image rightSprite_;

    public virtual void Reveal()
    {
        this.button_ = GetComponent<Button>();
        this.buttonPanel_ = GetComponentInParent<ButtonPanel>();
        this.panelButtonAnimator_ = GetComponent<PanelButtonAnimator>();

        Image[] allSprites = GetComponentsInChildren<Image>(true);

        this.centerSprite_ = allSprites[1];
        this.leftSprite_ = allSprites[2];
        this.rightSprite_ = allSprites[3];

        this.button_.onClick.RemoveAllListeners();
        this.button_.onClick.AddListener(this.ButtonClicked);

        this.panelButtonAnimator_.PlayRevealAnimation(this.RevealCallback);
    }
    
    public void Hide()
    {
        this.button_.interactable = false;
        this.panelButtonAnimator_.PlayHideAnimation(this.HideCallback);
    }

    public void EnableButton()
    {
        this.button_.interactable = true;
    }

    public void DisableButton()
    {
        this.button_.interactable = false;
    }

    public void HighlightButton()
    {
        this.button_.image.color = Color.yellow;
    }

    public void UnhighlightButton()
    {
        this.button_.image.color = Color.white;
    }

    public void UpdateCenterSprite(Sprite newSprite)
    {
        this.centerSprite_.sprite = newSprite;
    }

    public void UpdateLeftSprite(Sprite newSprite)
    {
        this.leftSprite_.sprite = newSprite;
    }

    public void UpdateRightSprite(Sprite newSprite)
    {
        this.rightSprite_.sprite = newSprite;
    }

    public void UpdateLeftRightSprite(Sprite newLeftSprite, Sprite newRightSprite)
    {
        this.leftSprite_.sprite = newLeftSprite;
        this.rightSprite_.sprite = newRightSprite;
    }

    protected virtual void RevealCallback()
    {
        this.button_.interactable = true;
    }

    protected virtual void HideCallback() { }

    protected virtual void ButtonClicked() 
    {
        this.buttonPanel_.ButtonSelected(this);
    }

    
}
