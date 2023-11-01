using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SaveAsyncRequest : AsyncRequest
{
    public SaveAsyncRequest(string username, int preset, string attributeSettings, NetworkRequestSuccess successCallback = null, NetworkRequestFailure failureCallback = null)
    {
        string url = ServerSecrets.ServerName + "/twitchBot/setEquippedPreset.php";

        this.form = new WWWForm();
        this.form.AddField("username", username);
        this.form.AddField("preset", preset);
        this.form.AddField("attributeSettings", attributeSettings);

        this.SetupRequest(url, successCallback, failureCallback);
    }

    protected override bool Verify()
    {
        return (this.www.downloadHandler.text == "Success");
    }
}
