using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PresetManager : MonoBehaviour
{
    public static PresetManager instance;

    public int selectedPreset;

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
        form.AddField("preset", CurrentPlayerData.data.equippedPreset);

        using (UnityWebRequest www = UnityWebRequest.Post(fullURL, form))
        {
            yield return www.SendWebRequest();
        }

            this.selectedPreset = newPreset;

        //Modify cabbage preview with latest preset attribute settings
    }


}
