using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanelController : MonoBehaviour
{    
    public void SetVisibleStatus(bool isVisible)
    {
        this.GetComponent<SettingsPanelModel>().shouldShow = isVisible;
    }

    public bool GetVisibleStatus()
    { 
        return this.GetComponent<SettingsPanelModel>().shouldShow;
    }

    public virtual void RefreshView()
    { 
        
    }
}
