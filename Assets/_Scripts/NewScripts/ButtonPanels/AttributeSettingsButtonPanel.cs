using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class AttributeSettingsButtonPanel : ButtonPanel
{
    [SerializeField]
    private ButtonPanel _navigationButtonPanel;
    
    [SerializeField]
    private ButtonPanel _spriteButtonPanel;
    [SerializeField]
    private ButtonPanel _positionButtonPanel;
    [SerializeField]
    private ButtonPanel _scaleButtonPanel;
    [SerializeField]
    private ButtonPanel _rotationButtonPanel;

    private float _timeBetweenPanelDisplays = 0.5f;

    public override void DisplayPanel()
    {
        StartCoroutine(this.DisplayAllPanels());
    }

    private IEnumerator DisplayAllPanels()
    {
        StartCoroutine(this.RevealButtons());
        yield return new WaitForSeconds(this._timeBetweenPanelDisplays);
        this._navigationButtonPanel.DisplayPanel();
    }

    public void SpriteButtonClicked()
    {
        StartCoroutine(this.TransitionToNextButtonPanel(this._spriteButtonPanel));
    }

    public void PositionButtonClicked()
    {
        StartCoroutine(this.TransitionToNextButtonPanel(this._positionButtonPanel));
    }

    public void ScaleButtonClicked()
    {
        StartCoroutine(this.TransitionToNextButtonPanel(this._scaleButtonPanel));
    }

    public void RotationButtonClicked()
    {
        StartCoroutine(this.TransitionToNextButtonPanel(this._rotationButtonPanel));
    }

    public void FlipXButtonClicked()
    {
        //Flip X
    }

    public void FlipYButtonClicked()
    {
        //Flip Y
    }

    private IEnumerator TransitionToNextButtonPanel(ButtonPanel nextButtonPanel)
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

        nextButtonPanel.DisplayPanel();

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
