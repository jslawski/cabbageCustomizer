using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSettingsPanelModel : MonoBehaviour
{
    [HideInInspector]
    public AttributeSettingsButtonController[] allButtonControllers;
    [HideInInspector]
    public AttributeSettingsButtonController selectedButton;

    private void Awake()
    {
        this.allButtonControllers = GetComponentsInChildren<AttributeSettingsButtonController>();
    }
}
