using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBlank : MonoBehaviour, IInteractable
{
    //Exists to Display Login

    public GameObject loginScreen;

    bool loggingIn = false;

    public void Start()
    {
        loginScreen.SetActive(false);
    }

    public void Update()
    {
        if (loggingIn == true)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            loginScreen.SetActive(true);
        }
        else if (loggingIn == false)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            loginScreen.SetActive(false);
        }
    }

    public void Action(PlayerManager player)
    {
        loggingIn = !loggingIn;
    }
}
