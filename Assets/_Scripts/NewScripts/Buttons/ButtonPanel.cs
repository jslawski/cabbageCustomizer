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
    
    protected PanelButton[] _panelButtons;

    protected int selectedButtonIndex = -1;

    protected float _updatePanelSpeed = 0.025f;
    
    protected void Awake()
    {
        this._panelButtons = this._buttonsParent.GetComponentsInChildren<PanelButton>();
        this.ReorderButtons();
    }

    protected void ReorderButtons()
    {
        switch (this.buttonDisplayOrigin)
        {
            case DisplayOrigin.Left:
                this._panelButtons = this._panelButtons.OrderBy(button => (button.transform.position.x)).ToArray();
                break;
            case DisplayOrigin.Right:
                this._panelButtons = this._panelButtons.OrderBy(button => (-button.transform.position.x)).ToArray();
                break;
            case DisplayOrigin.Top:
                this._panelButtons = this._panelButtons.OrderBy(button => (-button.transform.position.y)).ToArray();
                break;
            case DisplayOrigin.Bottom:
                this._panelButtons = this._panelButtons.OrderBy(button => (button.transform.position.y)).ToArray();
                break;
            case DisplayOrigin.UpperLeft:
                this._panelButtons = this._panelButtons.OrderBy(button => (button.transform.position.x - button.transform.position.y)).ToArray();
                break;
            case DisplayOrigin.UpperRight:
                this._panelButtons = this._panelButtons.OrderBy(button => (-button.transform.position.x - button.transform.position.y)).ToArray();
                break;
            case DisplayOrigin.LowerLeft:
                this._panelButtons = this._panelButtons.OrderBy(button => (button.transform.position.x + button.transform.position.y)).ToArray();
                break;
            case DisplayOrigin.LowerRight:
                this._panelButtons = this._panelButtons.OrderBy(button => (-button.transform.position.x + button.transform.position.y)).ToArray();
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

    public void HidePanel()
    {
        StartCoroutine(this.HideButtons());
    }

    public void SelectPanelButton(PanelButton selectedButton)
    {
        this.selectedButtonIndex = Array.FindIndex<PanelButton>(this._panelButtons, (x => x == selectedButton));

        this._panelButtons[this.selectedButtonIndex].SelectButton();

        this.SelectPanelButtonCallback();
    }

    protected virtual void SelectPanelButtonCallback() { }

    protected IEnumerator RevealButtons()
    {
        for (int i = 0; i < this._panelButtons.Length; i++)
        {
            this._panelButtons[i].Reveal();

            yield return new WaitForSeconds(this._updatePanelSpeed);
        }
    }

    protected IEnumerator HideButtons()
    {
        for (int i = 0; i < this._panelButtons.Length; i++)
        {
            this._panelButtons[i].interactable = false;
        }

        for (int i = 0; i < this._panelButtons.Length; i++)
        {
            if (i == this.selectedButtonIndex)
            {
                yield return null;
            }
            else
            {
                this._panelButtons[i].Hide();
                yield return new WaitForSeconds(this._updatePanelSpeed);
            }
        }

        /*
        if (this.selectedButtonIndex >= 0)
        {
            this.TransitionPanels();
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < this._panelButtons.Length; i++)
        {
            this._panelButtons[i].animator.SetTrigger("Wait");
        }
        */
    }
}
