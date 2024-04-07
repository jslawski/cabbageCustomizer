using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePanelModel : SettingsPanelModel
{
    [HideInInspector]
    public SpriteButtonController[] allButtonControllers;
    [HideInInspector]
    public SpriteButtonController selectedButton;
    [HideInInspector]
    public int pageIndex = 0;

    private void Awake()
    {
        this.allButtonControllers = GetComponentsInChildren<SpriteButtonController>();
    }
}
