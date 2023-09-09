using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using CabbageCustomizer;

public class PresetManager : MonoBehaviour
{
    public static PresetManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void LoadPreset(int newPreset)
    {        
        StartCoroutine(this.LoadPresetAttributeSettings(newPreset));
    }


    private IEnumerator LoadPresetAttributeSettings(int newPreset)
    {
        string fullURL = TwitchSecrets.ServerName + "/getPreset.php";

        WWWForm form = new WWWForm();
        form.AddField("username", CurrentPlayerData.data.username);
        form.AddField("preset", newPreset);

        using (UnityWebRequest www = UnityWebRequest.Post(fullURL, form))
        {
            yield return www.SendWebRequest();

            CurrentPlayerData.data.attributeSettingsJSON = www.downloadHandler.text;
        }

        CurrentPlayerData.data.equippedPreset = newPreset;        

        CharacterPreview.instance.character.LoadCharacterFromJSON(CurrentPlayerData.data.attributeSettingsJSON);
    }
}
