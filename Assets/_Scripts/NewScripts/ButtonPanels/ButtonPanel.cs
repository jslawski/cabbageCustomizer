using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
    protected enum DisplayOrigin { Left, Right, Top, Bottom, UpperLeft, UpperRight, LowerLeft, LowerRight };
    
    public bool displayNavigationPanel = false;

    [SerializeField]
    private GameObject _buttonsParent;
    
    [SerializeField]
    protected DisplayOrigin buttonDisplayOrigin = DisplayOrigin.Left;

    public PanelButton[] panelButtons;

    protected int selectedButtonIndex = -1;

    protected float updatePanelSpeed_ = 0.025f;
    
    protected void Awake()
    {
        this.panelButtons = this._buttonsParent.GetComponentsInChildren<PanelButton>();

        this.ReorderButtons();
    }

    protected void ReorderButtons()
    {
        switch (this.buttonDisplayOrigin)
        {
            case DisplayOrigin.Left:
                this.panelButtons = this.panelButtons.OrderBy(button => (button.transform.position.x)).ToArray();
                break;
            case DisplayOrigin.Right:
                this.panelButtons = this.panelButtons.OrderBy(button => (-button.transform.position.x)).ToArray();
                break;
            case DisplayOrigin.Top:
                this.panelButtons = this.panelButtons.OrderBy(button => (-button.transform.position.y)).ToArray();
                break;
            case DisplayOrigin.Bottom:
                this.panelButtons = this.panelButtons.OrderBy(button => (button.transform.position.y)).ToArray();
                break;
            case DisplayOrigin.UpperLeft:
                this.panelButtons = this.panelButtons.OrderBy(button => (button.transform.position.x - button.transform.position.y)).ToArray();
                break;
            case DisplayOrigin.UpperRight:
                this.panelButtons = this.panelButtons.OrderBy(button => (-button.transform.position.x - button.transform.position.y)).ToArray();
                break;
            case DisplayOrigin.LowerLeft:
                this.panelButtons = this.panelButtons.OrderBy(button => (button.transform.position.x + button.transform.position.y)).ToArray();
                break;
            case DisplayOrigin.LowerRight:
                this.panelButtons = this.panelButtons.OrderBy(button => (-button.transform.position.x + button.transform.position.y)).ToArray();
                break;
            default:
                Debug.LogError("Unknown DisplayOrigin: " + this.buttonDisplayOrigin);
                break;
        }
    }

    public virtual void DisplayPanel()
    {
        StartCoroutine(this.RevealButtons());
    }

    public virtual void HidePanel()
    {
        StartCoroutine(this.HideButtons());
    }
    
    public void SelectPanelButton(PanelButton selectedButton)
    {
        this.selectedButtonIndex = Array.FindIndex<PanelButton>(this.panelButtons, (x => x == selectedButton));

        this.UpdateHighlightedButton();
        
        this.SelectPanelButtonCallback();
    }

    protected void DisableAllButtons()
    {
        for (int i = 0; i < this.panelButtons.Length; i++)
        {
            this.panelButtons[i].DisableButton(false);
        }
    }

    protected void EnableAllButtons()
    {
        for (int i = 0; i < this.panelButtons.Length; i++)
        {
            this.panelButtons[i].EnableButton();
        }
    }

    protected virtual void SelectPanelButtonCallback() { }

    protected IEnumerator RevealButtons()
    {
        this.DisableAllButtons();

        for (int i = 0; i < this.panelButtons.Length; i++)
        {
            this.panelButtons[i].DisableHighlight();
            this.panelButtons[i].Reveal();

            yield return new WaitForSeconds(this.updatePanelSpeed_);
        }
        
        this.RevealButtonsCallback();
    }

    protected virtual void RevealButtonsCallback()
    {
        this.EnableAllButtons();
    }

    protected IEnumerator HideButtons()
    {
        this.DisableAllButtons();

        for (int i = 0; i < this.panelButtons.Length; i++)
        {    
            this.panelButtons[i].Hide();
            yield return new WaitForSeconds(this.updatePanelSpeed_);
        }
    }

    protected void UpdateHighlightedButton()
    {
        for (int i = 0; i < this.panelButtons.Length; i++)
        {
            if (i == this.selectedButtonIndex)
            {
                this.panelButtons[i].EnableHighlight();
            }
            else
            {
                this.panelButtons[i].DisableHighlight();
            }
        }
    }
}
