using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TwitchAuth : MonoBehaviour
{
    private string twitchAuthURL = "https://id.twitch.tv/oauth2/authorize";

    private string twitchAuthStateVerify;
    private string authCode;

    private HttpClient httpClient = new HttpClient();

    [SerializeField]
    private Button loginButton;

    [SerializeField]
    private GameObject characterCanvas;
    [SerializeField]
    private GameObject characterPreview;

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
                                "redirect_uri=" + TwitchSecrets.RedirectURL + "&" +
                                "scope=user:read:email&" +
                                "state=" + this.twitchAuthStateVerify;

        this.StartLocalWebServer();

        Application.OpenURL(totalAuthURL);        
    }

    private void StartLocalWebServer()
    {
        HttpListener listener = new HttpListener();
        string prefix = TwitchSecrets.RedirectURL + "/";

        listener.Prefixes.Add(prefix);
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
        string fullURL = TwitchSecrets.ServerName + "/getInitialUserData.php";

        WWWForm form = new WWWForm();
        form.AddField("authCode", this.authCode);

        using (UnityWebRequest www = UnityWebRequest.Post(fullURL, form))
        {
            yield return www.SendWebRequest();            

            this.LoadUserData(www.downloadHandler.text);         
        }
        
        this.loginButton.gameObject.SetActive(false);
        this.characterCanvas.SetActive(true);
        this.characterPreview.SetActive(true);
    }

    private IEnumerator CheckForToken()
    {
        while (this.authCode == "")
        {
            yield return new WaitForSeconds(1.0f);
        }

        this.GetUserData();
    }

    private void LoadUserData(string data)
    {
        CurrentPlayerData.data = JsonUtility.FromJson<PlayerData>(data);
        CharacterPreview.instance.LoadCharacterFromPresetData(CurrentPlayerData.data.attributeSettingsJSON);
    }
}
