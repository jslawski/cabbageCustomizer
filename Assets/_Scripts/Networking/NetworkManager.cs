using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public delegate bool NetworkRequestVerify(string responseBody);

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SendRequest(string endpointPath, WWWForm form, NetworkRequestSuccess successCallback = null, NetworkRequestFailure failureCallback = null, NetworkRequestVerify verifyCallback = null)
    {
        StartCoroutine(this.SendRequestCoroutine(endpointPath, form, successCallback, failureCallback, verifyCallback));
    }

    private IEnumerator SendRequestCoroutine(string endpointPath, WWWForm form, NetworkRequestSuccess successCallback = null, NetworkRequestFailure failureCallback = null, NetworkRequestVerify verifyCallback = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(endpointPath, form))
        {
            yield return www.SendWebRequest();

            this.VerifyAndCallback(www, successCallback, failureCallback, verifyCallback);

            www.Dispose();
        }
    }

    private void VerifyAndCallback(UnityWebRequest www, NetworkRequestSuccess successCallback = null, NetworkRequestFailure failureCallback = null, NetworkRequestVerify verifyCallback = null)
    {
        bool success = false;
        bool isError = (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError);

        if (verifyCallback != null)
        {
            success = (verifyCallback(www.downloadHandler.text) == true) && (isError == false);
        }
        else
        {
            success = (isError == false);
        }

        if (success == true)
        {
            if (successCallback != null)
            {
                successCallback(www.downloadHandler.text);
            }
        }
        else if (failureCallback != null)
        {
            failureCallback();
        }
    }
}
