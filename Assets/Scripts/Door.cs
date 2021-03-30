﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int id;
    public bool open = false;
    private float initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Interactable";
        initialRotation = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (open && transform.rotation.eulerAngles.y < initialRotation + 80)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, initialRotation + 80, 0), 5);
        }
        else if (!open && transform.rotation.eulerAngles.y > initialRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, initialRotation, 0), 5);
        }

    }

    public void Open()
    {
        open = !open;
    }

    public void Action(PlayerManager player)
    {
        if (player.CanOpenDoor(id))
        {
            Open();
        } else
        {
            Debug.Log("Key Missing");
        }
    }
}
