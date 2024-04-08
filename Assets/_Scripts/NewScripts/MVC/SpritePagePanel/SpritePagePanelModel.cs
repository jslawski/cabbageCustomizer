using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePagePanelModel : MonoBehaviour
{
    [HideInInspector]
    public SpritePageButtonController[] allButtonControllers;
    [HideInInspector]
    public SpritePageButtonController selectedButton;

    private void Awake()
    {
        this.allButtonControllers = GetComponentsInChildren<SpritePageButtonController>();
    }
}
