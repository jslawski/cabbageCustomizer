using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TwitchAuth : MonoBehaviour
{
    private string twitchAuthURL = "https://id.twitch.tv/oauth2/authorize";
    private string serverName = "http://localhost:7080";

    private string twitchAuthStateVerify;
    private string authCode;

    private HttpClient httpClient = new HttpClient();

    [SerializeField]
    private Button loginButton;

    private void Start()
    {
        this.authCode = "";
        StartCoroutine(this.CheckForToken());
    }

    public void ExecuteTwitchAuth()
    {
        this.loginButton.interactable = false;

        this.twitchAuthStateVerify = ((Int64)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();

        string totalAuthURL = this.twitchAuthURL + "?" +
                                "response_type=code&" + 
                                "client_id=" + TwitchSecrets.ClientID + "&" +
                                "redirect_uri=" + this.serverName + "&" +
                                "scope=user:read:email&" +
                                "state=" + this.twitchAuthStateVerify;

        this.StartLocalWebServer();

        Application.OpenURL(totalAuthURL);        
    }

    private void StartLocalWebServer()
    {
        HttpListener listener = new HttpListener();

        listener.Prefixes.Add(this.serverName + "/");
        listener.Start();
        listener.BeginGetContext(new AsyncCallback(this.IncomingHttpRequest), listener);
    }

    private void IncomingHttpRequest(IAsyncResult result)
    {
        string code;
        string state;
        HttpListener listener;
        HttpListenerContext context;
        HttpListenerRequest request;
        HttpListenerResponse response;
        string responseString;

        listener = (HttpListener)result.AsyncState;

        context = listener.EndGetContext(result);

        request = context.Request;

        code = request.QueryString.Get("code");
        state = request.QueryString.Get("state");

        Debug.LogError("Code: " + code + "\nState: " + state);

        response = context.Response;
        responseString = "<html><body><b>DONE!</b><br>(You can close this tab/window now)</body></html>";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

        response.ContentLength64 = buffer.Length;
        System.IO.Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();

        listener.Stop();
        
        if ((code.Length > 0) && (state == this.twitchAuthStateVerify))
        {
            this.authCode = code;
        }
    }

    private void GetUserData()
    {
        StartCoroutine(this.RequestUserData());        
    }

    private IEnumerator RequestUserData()
    {
        string fullURL = "http://localhost/twitchBot/getUserData.php";

        WWWForm form = new WWWForm();
        form.AddField("authCode", this.authCode);

        using (UnityWebRequest www = UnityWebRequest.Post(fullURL, form))
        {
            yield return www.SendWebRequest();

            Debug.LogError(www.downloadHandler.text);
        }

        SceneManager.LoadScene("MainScene");
    }

    private IEnumerator CheckForToken()
    {
        while (this.authCode == "")
        {
            yield return new WaitForSeconds(1.0f);
        }

        //Transition scenes here;

        this.GetUserData();
    }
}
