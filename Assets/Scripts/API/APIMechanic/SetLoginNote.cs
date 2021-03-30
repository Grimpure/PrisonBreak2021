using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLoginNote : MonoBehaviour
{
    public Text loginNote;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetLoginInfo(string user, string password)
    {
        loginNote.text = "User: " + user + "\n" + "Password: " + password;
    }
}
