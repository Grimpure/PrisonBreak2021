using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Inventory inv;
    public float baseMaxWeight;

    // Start is called before the first frame update
    void Start()
    {
        inv = new Inventory(baseMaxWeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem(Item i)
    {
        Debug.Log("Adding Item: " + i.GetName() + " to " + this.gameObject.name + "'s Inventory");
        return inv.AddItem(i);
    }

    public void PickItemUp()
    {
        IInteractable i = /*make this the hit gameObject*/GetComponent<IInteractable>();
        i.Action(this);
    }

}
