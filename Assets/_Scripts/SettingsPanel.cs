using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SettingsPanel : MonoBehaviour
{
    public static SettingsPanel instance;

    

    private SettingsWidget[] widgets;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        
    }

    public void Initialize()
    {
        this.widgets = GetComponentsInChildren<SettingsWidget>(true);
        this.SetupWidgets();
    }

    

    //Only called when a tab is clicked
    public void UpdateSettingsPanel(AttributeType attType)
    {
        this.SetupWidgets();
        this.RefreshWidgets(attType);
    }

    private void SetupWidgets()
    {
        foreach (SettingsWidget widget in this.widgets)
        {
            widget.SetupWidget();
        }
    }

    public void RefreshWidgets(AttributeType attType)
    {
        CabbageAttribute attObj = CharacterPreview.instance.GetCachedAttribute(attType);
        
        foreach (SettingsWidget widget in this.widgets)
        {
            widget.RefreshWidget(attObj);
        }
    }
}
