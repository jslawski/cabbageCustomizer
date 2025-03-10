using CharacterCustomizer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanelController : MonoBehaviour
{    
    public AttributeType lastAttributeType = AttributeType.None;


    public void SetVisibleStatus(bool isVisible)
    {
        this.GetComponent<SettingsPanelModel>().shouldShow = isVisible;
    }

    public bool GetVisibleStatus()
    { 
        return this.GetComponent<SettingsPanelModel>().shouldShow;
    }

    public virtual void UpdateAttributeSetting()
    { 
    
    }

    public virtual void RefreshView()
    { 
        
    }
}
