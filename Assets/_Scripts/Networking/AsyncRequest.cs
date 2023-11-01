using UnityEngine;
using UnityEngine.Networking;

public delegate bool NetworkRequestVerifyAsync();
public delegate void NetworkRequestSuccess(string responseBody);
public delegate void NetworkRequestFailure();

public class AsyncRequest
{
    protected UnityWebRequestAsyncOperation asyncOperation;
    protected NetworkRequestVerifyAsync verifyCallback;
    protected NetworkRequestSuccess successCallback;
    protected NetworkRequestFailure failureCallback;
    protected UnityWebRequest www;
    protected WWWForm form;

    public AsyncRequest()
    {
        this.asyncOperation = null;
        this.verifyCallback = null;
        this.successCallback = null;
        this.failureCallback = null;
        this.www = null;
        this.form = null;
    }

    protected void SetupRequest(string url, NetworkRequestSuccess successCallback, NetworkRequestFailure failureCallback)
    {
        this.www = UnityWebRequest.Post(url, this.form);
        this.successCallback = successCallback;
        this.failureCallback = failureCallback;
    }

    protected virtual bool Verify()
    {
        return (this.www.downloadHandler.text != string.Empty);
    }

    public void Send()
    {
        this.asyncOperation = this.www.SendWebRequest();
        this.asyncOperation.completed += (data) => { this.VerifyAndCallback(); };
    }

    protected void VerifyAndCallback()
    {
        bool isError = (this.www.result == UnityWebRequest.Result.ConnectionError || this.www.result == UnityWebRequest.Result.ProtocolError);

        if (isError == false)
        {
            if (this.Verify() == true)
            {
                if (this.successCallback != null)
                {
                    this.successCallback(this.www.downloadHandler.text);
                }
            }
            else if (this.failureCallback != null)
            {
                this.failureCallback();
            }
        }
        else if (this.failureCallback != null)
        {
            this.failureCallback();
        }

        this.www.Dispose();
    }
}
