using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TwitchAuth : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OpenTab(string url);

    private string twitchAuthURL = "https://id.twitch.tv/oauth2/authorize";

    private string twitchAuthStateVerify;
    private string authCode = "";

    private HttpClient httpClient = new HttpClient();

    [SerializeField]
    private Button loginButton;

    [SerializeField]
    private GameObject characterCanvas;
    [SerializeField]
    private GameObject characterPreview;
    
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
        
        Application.OpenURL(totalAuthURL);

        StartCoroutine(this.WaitForAuthToken());
    }

    private IEnumerator WaitForAuthToken()
    {        
        while (this.authCode == "")
        {
            yield return new WaitForSeconds(1.0f);

            string fullURL = TwitchSecrets.ServerName + "/getAuthCode.php";

            WWWForm form = new WWWForm();
            form.AddField("state", this.twitchAuthStateVerify);

            using (UnityWebRequest www = UnityWebRequest.Post(fullURL, form))
            {
                yield return www.SendWebRequest();

                if (www.downloadHandler.text != string.Empty)
                {                    
                    this.authCode = www.downloadHandler.text;
                }
            }
        }

        this.GetUserData();
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

    private void LoadUserData(string data)
    {
        CurrentPlayerData.data = JsonUtility.FromJson<PlayerData>(data);        
    }
}
