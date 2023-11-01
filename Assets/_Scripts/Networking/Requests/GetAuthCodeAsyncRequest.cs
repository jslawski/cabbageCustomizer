using UnityEngine;
using UnityEngine.Networking;

public class GetAuthCodeAsyncRequest : AsyncRequest
{
    public GetAuthCodeAsyncRequest(string verifyState, NetworkRequestSuccess successCallback = null, NetworkRequestFailure failureCallback = null)
    {
        string url = ServerSecrets.ServerName + "/twitchBot/auth/getAuthCode.php";

        this.form = new WWWForm();
        this.form.AddField("state", verifyState);

        this.SetupRequest(url, successCallback, failureCallback);
    }
}
