using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class APIConnection : MonoBehaviour
{

    string user;
    string password;

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Received: " + webRequest.downloadHandler.text);
                    JSONNode JsonObject = JSON.Parse(webRequest.downloadHandler.text);

                    //Example JSON response:
                    //results: [{
                    //"login": {
                    //"uuid": "155e77ee-ba6d-486f-95ce-0e0c0fb4b919",
                    //"username": "silverswan131",
                    //"password": "firewall",
                    //"salt": "TQA1Gz7x",
                    //"md5": "dc523cb313b63dfe5be2140b0c05b3bc",
                    //"sha1": "7a4aa07d1bedcc6bcf4b7f8856643492c191540d",
                    //"sha256": "74364e96174afa7d17ee52dd2c9c7a4651fe1254f471a78bda0190135dcd3480"
                    //}]

                    Debug.Log("Username: " + JsonObject["results"][0]["login"]["username"].Value);
                    Debug.Log("Password: " + JsonObject["results"][0]["login"]["password"].Value);

                    user = JsonObject["results"][0]["login"]["username"].Value;
                    password = JsonObject["results"][0]["login"]["password"].Value;

                    ResultUserInfo();

                    break;
            }
        }
    }

    void Awake()
    {
        StartCoroutine(GetRequest("https://randomuser.me/api/"));
    }

    public void ResultUserInfo()
    {
        SetLoginNote loginNote = this.gameObject.GetComponent<SetLoginNote>();
        CheckLogin loginCheck = this.gameObject.GetComponent<CheckLogin>();

        loginNote.SetLoginInfo(user, password);
        loginCheck.GetLogin(user, password);
    }
}