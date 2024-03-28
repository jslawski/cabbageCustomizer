using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _buttonsParent;

    protected PanelButtonController[] panelButtons_;

    public bool displayNavigationPanel = false;
    
    protected void Awake()
    {
        this.panelButtons_ = this._buttonsParent.GetComponentsInChildren<PanelButtonController>();
    }

    public virtual void DisplayPanel()
    {
        for (int i = 0; i < this.panelButtons_.Length; i++)
        {
            this.panelButtons_[i].Reveal();
        }
    }

    public virtual void HidePanel()
    {
        for (int i = 0; i < this.panelButtons_.Length; i++)
        {
            this.panelButtons_[i].Hide();
        }
    }
}
