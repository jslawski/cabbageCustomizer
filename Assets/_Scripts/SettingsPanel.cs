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

    private void Start()
    {
        this.widgets = GetComponentsInChildren<SettingsWidget>();
        this.RefreshWidgets();
    }
    
    public void RefreshWidgets()
    {
        foreach (SettingsWidget widget in this.widgets)
        {
            widget.SetupWidget();
        }
    }
}
