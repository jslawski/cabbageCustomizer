using UnityEngine;
using Newtonsoft.Json;
using CharacterCustomizer;

public class SaveButton : MonoBehaviour
{
    private string previousSettings;

    //When clicked, equip the preset and update the attribute values
    public void SaveButtonClicked()
    {
        this.previousSettings = CurrentPlayerData.data.attributeSettingsJSON;
        CurrentPlayerData.data.attributeSettingsJSON = JsonConvert.SerializeObject(AttributeSettings.CurrentSettings);
        
        SaveAsyncRequest saveRequest = new SaveAsyncRequest(CurrentPlayerData.data.username, CurrentPlayerData.data.equippedPreset, CurrentPlayerData.data.attributeSettingsJSON, this.SaveSuccess, this.SaveFailure);
        saveRequest.Send();
    }

    private void SaveSuccess(string data)
    {
        Debug.Log("Save Success!");
    }

    private void SaveFailure()
    {
        Debug.Log("Save Failed...");
        CurrentPlayerData.data.attributeSettingsJSON = this.previousSettings;
    }
}
