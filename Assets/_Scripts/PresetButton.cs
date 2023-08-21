using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetButton : MonoBehaviour
{
    [SerializeField]
    private int presetID = -1;

    public void PresetButtonClicked()
    {
        PresetManager.instance.LoadPreset(this.presetID);
    }
}
