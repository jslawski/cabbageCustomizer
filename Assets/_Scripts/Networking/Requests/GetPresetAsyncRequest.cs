using UnityEngine;
using CabbageNetwork;

public class GetPresetAsyncRequest : AsyncRequest
{
    public GetPresetAsyncRequest(string username, int preset, NetworkRequestSuccess successCallback = null, NetworkRequestFailure failureCallback = null)
    {
        string url = ServerSecrets.ServerName + "/twitchBot/getPreset.php";

        this.form = new WWWForm();
        this.form.AddField("username", username);
        this.form.AddField("preset", preset);
        
        this.SetupRequest(url, successCallback, failureCallback);
    }
}
