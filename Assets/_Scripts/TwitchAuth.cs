using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using CabbageCustomizer;

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

    private void Awake()
    {
        AttributeSpriteDicts.Setup();
    }

    private string GenerateState()
    {
        Int64 timestamp = (Int64)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        Int64 salt = (Int64)UnityEngine.Random.Range(0, 10000);

        int sign = (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5f) ? 1 : -1;

        return (timestamp + (salt * sign)).ToString();

    }

    public void ExecuteTwitchAuth()
    {
        this.loginButton.interactable = false;

        int salt = (int)UnityEngine.Random.Range(0, 10000);

        this.twitchAuthStateVerify = this.GenerateState();

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
        Debug.LogError(this.authCode);

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
        Debug.LogError("Data: " + data);

        CurrentPlayerData.data = JsonUtility.FromJson<PlayerData>(data);

        foreach (string cabbageName in CurrentPlayerData.data.customCabbages)
        {
            AttributeSpriteDicts.AddCustomCabbage(cabbageName);
        }
    }
}
