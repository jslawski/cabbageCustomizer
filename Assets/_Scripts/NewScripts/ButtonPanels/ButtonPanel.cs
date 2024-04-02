using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _buttonsParent;

    protected PanelButtonController[] panelButtons_;

    protected int selectedButtonIndex_;
    
    public virtual void Reveal()
    {
        this.panelButtons_ = this._buttonsParent.GetComponentsInChildren<PanelButtonController>(true);

        for (int i = 0; i < this.panelButtons_.Length; i++)
        {
            this.panelButtons_[i].Reveal();
        }

        this.RevealCallback();
    }

    public virtual void Hide()
    {
        for (int i = 0; i < this.panelButtons_.Length; i++)
        {
            this.panelButtons_[i].Hide();
        }

        this.HideCallback();
    }

    protected void HighlightButtonAtIndex(int index)
    {
        for (int i = 0; i < this.panelButtons_.Length; i++)
        {
            if (i == index)
            {
                this.panelButtons_[i].HighlightButton();
            }
            else
            {
                this.panelButtons_[i].UnhighlightButton();
            }
        }
    }

    public virtual void ButtonSelected(PanelButtonController selectedButton) 
    {
        this.selectedButtonIndex_ = Array.FindIndex<PanelButtonController>(this.panelButtons_, (x => x == selectedButton));
    }

    protected virtual void RevealCallback() { }

    protected virtual void HideCallback() { }

    
}
