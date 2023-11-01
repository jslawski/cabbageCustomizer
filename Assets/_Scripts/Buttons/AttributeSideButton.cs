using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CharacterCustomizer;

public class AttributeSideButton : MonoBehaviour
{
    public Button buttonComponent;

    public AttributeType parentAttribute;
    public AttributeType buttonAttribute;

    private SettingsAttributeSideWidget widget;

    // Start is called before the first frame update
    void Start()
    {
        this.widget = GetComponentInParent<SettingsAttributeSideWidget>();
    }
    
    public void UpdateAttributeSide()
    {
        CharacterPreview.instance.UpdateSideCache(this.parentAttribute, this.buttonAttribute);
        this.widget.UpdateAttributeSide(this.buttonAttribute);
    }
}
