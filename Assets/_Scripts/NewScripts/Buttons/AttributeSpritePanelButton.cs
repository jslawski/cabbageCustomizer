using CharacterCustomizer;
using UnityEngine;

public class AttributeSpritePanelButton : PanelButton
{
    protected override void SelectedCallback()
    {
        CharacterAttribute currentAttribute = CharacterPreview.instance.GetCachedAttribute(CurrentCustomizerData.instance.currentAttributeType);
        currentAttribute.SetAssetName(this.panelButtonHelper.centerAttributeSprite.sprite.name);
        currentAttribute.UpdateAttributeObject();
    }
}
