using UnityEngine;
using CharacterCustomizer;

public abstract class SettingsWidget : MonoBehaviour
{    
    protected CharacterAttribute associatedAttribute;

    public abstract void SetupWidget();
    public abstract void RefreshWidget(CharacterAttribute attObj);
}
