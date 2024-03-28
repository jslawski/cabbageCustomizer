using CharacterCustomizer;

public class AttributeTypeButtonPanel : ButtonPanel
{
    private void Awake()
    {
        this.Reveal();
    }

    public override void ButtonSelected(PanelButtonController selectedButton)
    {
        base.ButtonSelected(selectedButton);

        this.HighlightButtonAtIndex(this.selectedButtonIndex_);
    }

    protected override void RevealCallback()
    {
        base.RevealCallback();

        CurrentCustomizerData.instance.SetCurrentAttributeType(AttributeType.BaseCabbage);
    }
}
