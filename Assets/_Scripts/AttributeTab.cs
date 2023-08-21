using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeTab : MonoBehaviour
{
    [SerializeField]
    private AttributeType attributeType;
    
    public void UpdatePanels()
    {
        AttributeSettingsManager.currentAttribute = this.attributeType;
        AttributeButtonPanel.instance.UpdateAttributeGrid(this.attributeType);
        SettingsPanel.instance.RefreshWidgets();
    }
}
