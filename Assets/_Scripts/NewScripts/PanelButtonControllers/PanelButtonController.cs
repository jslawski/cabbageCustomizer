using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButtonController : MonoBehaviour
{
    protected Button button_;

    protected PanelButtonAnimator panelButtonAnimator_;

    protected Image centerSprite_;
    protected Image leftSprite_;
    protected Image rightSprite_;

    private void Awake()
    {
        this.button_ = GetComponent<Button>();
        this.panelButtonAnimator_ = GetComponent<PanelButtonAnimator>();

        Image[] allSprites = GetComponentsInChildren<Image>();

        this.centerSprite_ = allSprites[1];
        this.leftSprite_ = allSprites[2];
        this.rightSprite_ = allSprites[3];
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.button_.onClick.RemoveAllListeners();
        this.button_.onClick.AddListener(this.ButtonClicked);
    }

    public virtual void Reveal()
    {
        this.button_.onClick.RemoveAllListeners();
        this.button_.onClick.AddListener(this.ButtonClicked);

        this.panelButtonAnimator_.PlayRevealAnimation(this.RevealCallback);
    }

    protected virtual void RevealCallback()
    {
        this.button_.interactable = true;
    }

    public void Hide()
    {
        this.button_.interactable = false;
        this.panelButtonAnimator_.PlayHideAnimation(this.HideCallback);
    }

    protected virtual void HideCallback()
    {
        
    }

    protected virtual void ButtonClicked() { }
}
