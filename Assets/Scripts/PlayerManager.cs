using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Inventory inv;
    public float baseMaxWeight;
    public GameObject cam;

    public Text interactInfo;

    // Start is called before the first frame update
    void Start()
    {
        inv = new Inventory(baseMaxWeight);
    }

    // Update is called once per frame
    void Update()
    {
        //Interact
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 4f))
        {
            IInteractable i = hit.collider.GetComponent<IInteractable>();
         
            if (i != null) 
            {
                //Debug.Log("Hit Interactable: " + hit.collider.name);
                
                interactInfo.text = "Press E to Interact with " + hit.collider.GetComponent<Pickup>().name;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    i.Action(this);
                }
            }
        } else { interactInfo.text = " "; }

        if (Input.GetKeyDown(KeyCode.F))
        {
            DropItem("DooDaa");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(cam.transform.position, cam.transform.position + cam.transform.forward * 2f);
    }

    public void DropItem(string name)
    {
        Item i = inv.GetItemWithName(name);

        if (i != null)
        {
            inv.RemoveItem(inv.GetItemWithName(name));
            GameManager.Instance.DropItem(name, transform.position + transform.forward);
            Debug.Log("Dropped " + name);
        } else { Debug.LogError("Could not find object"); }
    }

    public bool AddItem(Item i)
    {
        Debug.Log("Adding Item: " + i.GetName() + " to " + this.gameObject.name + "'s Inventory");
        return inv.AddItem(i);
    }

    public bool CanOpenDoor(int id)
    {
        return inv.CanOpenDoor(id);
    }
}
