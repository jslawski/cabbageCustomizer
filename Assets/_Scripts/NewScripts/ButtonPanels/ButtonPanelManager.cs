using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonPanelManager : MonoBehaviour
{
    public static ButtonPanelManager instance;

    [SerializeField]
    private ButtonPanel[] _buttonPanels;

    [SerializeField]
    private ButtonPanel navigationButtonPanel;

    private Stack<int> previousPanelIndices;
    private int currentPanelIndex = 0;

    private float timeBetweenPanels = 0.7f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        this.previousPanelIndices = new Stack<int>();
    }

    private void Start()
    {
        this._buttonPanels[0].DisplayPanel();

        if (this._buttonPanels[0].displayNavigationPanel == true)
        {
            this.navigationButtonPanel.DisplayPanel();
        }
    }

    public void DisplayNewPanel(int newPanelIndex)
    {
        this.previousPanelIndices.Push(this.currentPanelIndex);
        StartCoroutine(this.TransitionPanels(newPanelIndex));
    }

    public void ReturnToPreviousPanel()
    {
        this.HideCurrentPanel();
        this.DisplayPreviousPanel();
    }

    private void HideCurrentPanel()
    {
        this._buttonPanels[this.currentPanelIndex].HidePanel();

        if (this._buttonPanels[this.currentPanelIndex].displayNavigationPanel == true)
        {
            this.navigationButtonPanel.HidePanel();
        }
    }

    private IEnumerator TransitionPanels(int newPanelIndex)
    {
        this.HideCurrentPanel();

        yield return new WaitForSeconds(this.timeBetweenPanels);
        
        this.currentPanelIndex = newPanelIndex;
        this._buttonPanels[this.currentPanelIndex].DisplayPanel();

        if (this._buttonPanels[this.currentPanelIndex].displayNavigationPanel == true)
        {
            this.navigationButtonPanel.DisplayPanel();
        }
    }

    private void DisplayPreviousPanel()
    {
        if (this.previousPanelIndices.Count > 0)
        {
            StartCoroutine(this.TransitionPanels(this.previousPanelIndices.Pop()));
        }
    }
}
