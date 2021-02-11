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
        GameManager.Instance.RegisterPickupItem(this);
    }

    public void Action(PlayerManager player)
    {
        if (player.AddItem(CreateItem()))
        {
            Remove();
        }

    }

    public void Remove()
    {
        gameObject.SetActive(false);
    }

    public void Respawn(Vector3 pos)
    {
        gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        gameObject.SetActive(true);
    }

    public abstract Item CreateItem();
}
