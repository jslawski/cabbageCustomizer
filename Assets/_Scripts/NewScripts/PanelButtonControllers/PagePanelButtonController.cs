using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PagePanelButtonController : PanelButtonController
{
    public override void Reveal()
    {
        base.Reveal();

        this.leftSprite_.enabled = false;
        this.rightSprite_.enabled = false;
    }
}
