using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IInteractable
{
    public string name;
    public float weight;

    private void Start()
    {
        gameObject.tag = "Interactable";
    }

    public void Action(PlayerManager player)
    {
        player.AddItem(CreateItem());
    }

    public abstract Item CreateItem();
}
