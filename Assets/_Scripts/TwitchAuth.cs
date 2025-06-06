using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using CharacterCustomizer;

public class TwitchAuth : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OpenTab(string url);

    private string twitchAuthURL = "https://id.twitch.tv/oauth2/authorize";

    private string twitchAuthStateVerify;
    private string authCode = "";

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
                                "client_id=" + ServerSecrets.ClientID + "&" +
                                "redirect_uri=" + ServerSecrets.RedirectURL + "&" +
                                "scope=user:read:email&" +
                                "state=" + this.twitchAuthStateVerify;
        
        Application.OpenURL(totalAuthURL);

        this.SendAuthTokenRequest();
    }

    #region Get Auth Token
    private void SendAuthTokenRequest()
    {
        GetAuthCodeAsyncRequest authTokenRequest = new GetAuthCodeAsyncRequest(this.twitchAuthStateVerify, this.AuthCodeSuccess, this.AuthCodeFailure);
        authTokenRequest.Send();
    }

    private void AuthCodeSuccess(string data)
    {
        this.authCode = data;
        this.GetUserData();
    }

    private void AuthCodeFailure()
    {
        Invoke("SendAuthTokenRequest", 1.0f);
    }
    #endregion

    #region Get User Data
    private void GetUserData()
    {
        GetUserDataAsyncRequest getUserDataRequest = new GetUserDataAsyncRequest(this.authCode, this.GetUserDataSuccess, this.GetUserDataFailure);
        getUserDataRequest.Send();
    }

    private void GetUserDataSuccess(string data)
    {
        this.LoadUserData(data);

        this.loginButton.gameObject.transform.parent.gameObject.SetActive(false);
        this.characterCanvas.SetActive(true);
        this.characterPreview.SetActive(true);
    }

    private void GetUserDataFailure()
    {
        Debug.LogError("Error: unable to get initial user data");
    }

    
    private void LoadUserData(string data)
    {
        CurrentPlayerData.data = JsonUtility.FromJson<PlayerData>(data);
    }
    #endregion
}
