using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeSideButton : MonoBehaviour
{
    public Button buttonComponent;

    public AttributeType buttonAttribute;

    private SettingsAttributeSideWidget widget;

    // Start is called before the first frame update
    void Start()
    {
        this.widget = GetComponentInParent<SettingsAttributeSideWidget>();
    }
    
    public void UpdateAttributeSide()
    {        
        this.widget.UpdateAttributeSide(this.buttonAttribute);
    }
}
