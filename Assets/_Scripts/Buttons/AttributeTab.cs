using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class AttributeTab : MonoBehaviour
{
    [SerializeField]
    private AttributeType attributeType;
    
    public void UpdatePanels()
    {
        AttributeButtonPanel.instance.UpdateAttributeGrid(this.attributeType);
        SettingsPanel.instance.UpdateSettingsPanel(this.attributeType);
    }
}
