using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsAttributeSideWidget : SettingsWidget
{
    [SerializeField]
    private AttributeSideButton leftButton;
    [SerializeField]
    private AttributeSideButton bothButton;
    [SerializeField]
    private AttributeSideButton rightButton;    

    public override void SetupWidget(AttributeType newType)
    {
        if (newType == AttributeType.Eyebrows || newType == AttributeType.Eyes)
        {
            this.gameObject.SetActive(true);
            this.ToggleButtons(CharacterPreview.instance.GetAttributeFromType(newType).attributeSide);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void UpdateAttributeSide(AttributeSide newSide)
    {
        CharacterPreview.instance.GetAttributeFromType(CharacterPreview.instance.currentAttribute).UpdateSide(newSide);
        SettingsPanel.instance.RefreshWidgets(CharacterPreview.instance.currentAttribute);
        this.ToggleButtons(newSide);
    }

    private void ToggleButtons(AttributeSide newSide)
    {
        switch (newSide)
        {
            case AttributeSide.Left:
                this.leftButton.buttonComponent.interactable = false;
                this.bothButton.buttonComponent.interactable = true;
                this.rightButton.buttonComponent.interactable = true;
                break;
            case AttributeSide.Both:
                this.leftButton.buttonComponent.interactable = true;
                this.bothButton.buttonComponent.interactable = false;
                this.rightButton.buttonComponent.interactable = true;
                break;
            case AttributeSide.Right:
                this.leftButton.buttonComponent.interactable = true;
                this.bothButton.buttonComponent.interactable = true;
                this.rightButton.buttonComponent.interactable = false;
                break;
            default:
                Debug.LogError("Unknown Attribute Side: " + newSide);
                break;
        }
    }
}
