using UnityEngine;

public abstract class SettingsWidget : MonoBehaviour
{    
    protected CabbageAttribute associatedAttribute;

    public abstract void SetupWidget();
    public abstract void RefreshWidget(CabbageAttribute attObj);
}
