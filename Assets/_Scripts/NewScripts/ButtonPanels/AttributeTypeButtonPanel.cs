using CharacterCustomizer;
using UnityEngine;

public class AttributeTypeButtonPanel : ButtonPanel
{
    [SerializeField]
    private DoubleAttributeTypeButtonPanel[] _doubleAttributeTypeButtonPanels;
    [SerializeField]
    private PanelButtonController[] _doubleAttributeButtons;

    private void Awake()
    {
        this.Reveal();
    }

    public override void Reveal()
    {
        base.Reveal();
    
        for (int i = 0; i < this.panelButtons_.Length; i++)
        {
            this.panelButtons_[i].Reveal();
        }

        for (int i = 0; i < this._doubleAttributeTypeButtonPanels.Length; i++)
        {
            this._doubleAttributeTypeButtonPanels[i].Reveal();
        }

        this.RevealCallback();
    }

    public override void ButtonSelected(PanelButtonController selectedButton)
    {
        base.ButtonSelected(selectedButton);

        this.HighlightButtonAtIndex(this.selectedButtonIndex_);

        if (selectedButton == _doubleAttributeButtons[0])
        {
            this._doubleAttributeTypeButtonPanels[0].RevealSideButtons();
            this._doubleAttributeTypeButtonPanels[1].HideSideButtons();
        }
        else if (selectedButton == _doubleAttributeTypeButtonPanels[1])
        {
            this._doubleAttributeTypeButtonPanels[1].RevealSideButtons();
            this._doubleAttributeTypeButtonPanels[0].HideSideButtons();
        }
        else
        {
            this._doubleAttributeTypeButtonPanels[0].HideSideButtons();
            this._doubleAttributeTypeButtonPanels[1].HideSideButtons();
        }
    }

    protected override void RevealCallback()
    {
        base.RevealCallback();

        MasterController.instance.SetCurrentAttributeType(AttributeType.BaseCabbage);
    }
}
