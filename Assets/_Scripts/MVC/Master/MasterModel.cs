using UnityEngine;
using CharacterCustomizer;

public class MasterModel : MonoBehaviour
{
    [HideInInspector]
    public AttributeType currentAttributeType;
    [HideInInspector]
    public AttributeSettingsData currentAttributeSettingsData;
    [HideInInspector]
    public SettingsPanelController currentSettingsPanelController;
}
