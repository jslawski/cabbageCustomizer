using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAttributeTypeButtonPanel : ButtonPanel
{
    public override void Reveal()
    {
        base.Reveal();
        this.HideSideButtons();
    }
    
    public void RevealSideButtons()
    {
        this.panelButtons_[1].Reveal();
        this.panelButtons_[2].Reveal();
    }

    public void HideSideButtons()
    {
        this.panelButtons_[1].Hide();
        this.panelButtons_[2].Hide();
    }    
}
