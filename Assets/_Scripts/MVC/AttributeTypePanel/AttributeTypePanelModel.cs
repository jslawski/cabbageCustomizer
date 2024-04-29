using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeTypePanelModel : MonoBehaviour
{
    [HideInInspector]
    public AttributeTypeButtonController[] allButtonControllers;
    [HideInInspector]
    public bool showEyebrowsButtons = false;
    [HideInInspector]
    public bool showEyesButtons = false;
    [HideInInspector]
    public AttributeTypeButtonController selectedButton;

    public AttributeTypeButtonController[] eyebrowsLeftRightButtonControllers;    
    public AttributeTypeButtonController[] eyesLeftRightButtonControllers;

    private void Awake()
    {
        this.allButtonControllers = GetComponentsInChildren<AttributeTypeButtonController>(true);
    }
}
