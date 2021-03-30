using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLogin : MonoBehaviour
{
    //N = Username, P = Password
    string inputN;
    string inputP;

    string validN;
    string validP;

    public GameObject accessGrant;
    public GameObject accessDeny;

    public GameObject endDoor;

    //Gets API Results
    public void GetLogin(string user, string password)
    {
        validN = user;
        validP = password;
    }

    public void ReadInputName(string name)
    {
        inputN = name;
        Debug.Log(inputN);
    }

    public void ReadInputPass(string pass)
    {
        inputP = pass;
        Debug.Log(inputP);
    }

    public void CheckValidLogin()
    {
        if (inputN == validN && inputP == validP)
        {
            //Grant Access
            Debug.Log("Access Granted!");
            accessGrant.SetActive(true);
            endDoor.gameObject.SetActive(false);
        }
        else
        {
            //Deny Access
            Debug.LogError("Access Denied!");
            accessDeny.SetActive(true);
        }
    }

}
