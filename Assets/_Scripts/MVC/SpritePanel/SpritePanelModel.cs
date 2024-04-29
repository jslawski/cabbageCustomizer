using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class SpritePanelModel : SettingsPanelModel
{
    [HideInInspector]
    public SpriteButtonController[] allButtonControllers;
    [HideInInspector]
    public SpriteButtonController selectedButton;
    [HideInInspector]
    public int pageIndex = 0;

    [HideInInspector]
    public AttributeType lastAttributeType = AttributeType.None;

    private void Awake()
    {
        this.allButtonControllers = GetComponentsInChildren<SpriteButtonController>();
    }
}
