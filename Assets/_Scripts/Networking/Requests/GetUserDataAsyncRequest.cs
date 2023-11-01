using UnityEngine;
using CabbageNetwork;
public class GetUserDataAsyncRequest : AsyncRequest
{
    public GetUserDataAsyncRequest(string authCode, NetworkRequestSuccess successCallback = null, NetworkRequestFailure failureCallback = null)
    {
        string url = ServerSecrets.ServerName + "/twitchBot/auth/getInitialUserData.php";

        this.form = new WWWForm();
        this.form.AddField("authCode", authCode);

        this.SetupRequest(url, successCallback, failureCallback);
    }
}
