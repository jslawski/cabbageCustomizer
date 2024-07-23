using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanelController : MonoBehaviour
{    
    public void SetVisibleStatus(bool isVisible)
    {
        this.GetComponent<SettingsPanelModel>().shouldShow = isVisible;
    }

    public virtual void RefreshView()
    { 
        
    }
}
