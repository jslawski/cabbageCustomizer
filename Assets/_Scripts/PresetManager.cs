using UnityEngine;
using CharacterCustomizer;

public class PresetManager : MonoBehaviour
{
    public static PresetManager instance;

    private int previousPreset = -1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void LoadPreset(int newPreset)
    {        
        this.previousPreset = CurrentPlayerData.data.equippedPreset;
        CurrentPlayerData.data.equippedPreset = newPreset;

        GetPresetAsyncRequest getPresetRequest = new GetPresetAsyncRequest(CurrentPlayerData.data.username, newPreset, this.PresetLoadSuccess, this.PresetLoadFailure);
        getPresetRequest.Send();
    }

    private void PresetLoadSuccess(string data)
    {
        CurrentPlayerData.data.attributeSettingsJSON = data;
        CharacterPreview.instance.character.LoadCharacterFromJSON(CurrentPlayerData.data.attributeSettingsJSON);
    }

    private void PresetLoadFailure()
    {
        CurrentPlayerData.data.equippedPreset = this.previousPreset;
    }
}
