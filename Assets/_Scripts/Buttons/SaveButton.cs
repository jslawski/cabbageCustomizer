using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class SaveButton : MonoBehaviour
{
    //When clicked, equip the preset and update the attribute values
    public void SaveButtonClicked()
    {
        CurrentPlayerData.data.attributeSettingsJSON = JsonConvert.SerializeObject(AttributeSettings.CurrentSettings);

        StartCoroutine(this.SaveUserPreset());
    }

    private IEnumerator SaveUserPreset()
    {
        string fullURL = TwitchSecrets.ServerName + "/setEquippedPreset.php";

        WWWForm form = new WWWForm();
        form.AddField("username", CurrentPlayerData.data.username);
        form.AddField("preset", CurrentPlayerData.data.equippedPreset);
        form.AddField("attributeSettings", CurrentPlayerData.data.attributeSettingsJSON);

        using (UnityWebRequest www = UnityWebRequest.Post(fullURL, form))
        {
            yield return www.SendWebRequest();

            Debug.LogError(www.downloadHandler.text);
        }

        Debug.LogError("Saved!");
    }
}
