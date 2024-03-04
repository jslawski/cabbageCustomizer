using CharacterCustomizer;

public class AttributeSpritePanelButton : PanelButton
{
    protected override void SelectedCallback()
    {
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(CurrentCustomizerData.instance.currentAttributeType);

        currentAttribute.SetAssetName(this.panelButtonHelper.centerAttributeSprite.name);

        currentAttribute.UpdateAttributeObject();
    }
}
