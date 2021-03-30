using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Inventory inv;
    public float baseMaxWeight;
    public GameObject cam;

    public GameObject loginNote;

    public TMPro.TextMeshProUGUI interactTxt;

    public InventoryUI invUIManager;
    private bool invOpen;


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

        interactTxt.text = " ";

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 4f))
        {
            IInteractable i = hit.collider.GetComponent<IInteractable>();

            if (hit.collider.gameObject.tag == "Interactable")
            {
                //Debug.Log("Hit Interactable: " + hit.collider.name);

                if (hit.collider.GetComponent<Pickup>())
                {
                    interactTxt.SetText("Press E to Pick up " + hit.collider.GetComponent<Pickup>().name);
                }
                else if (hit.collider.GetComponent<Door>())
                {
                    interactTxt.SetText("Press E to Open with Key: [" + hit.collider.GetComponent<Door>().id + "]");
                } else if (hit.collider.GetComponent<InteractBlank>())
                {
                    interactTxt.SetText("Press E to Interact with: " + hit.collider.gameObject.name);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    i.Action(this);
                }
            }
            /*else if (hit.collider.gameObject.tag != "Interactable")
            {
                interactTxt.text = " ";
            }*/
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            invOpen = !invOpen; //Switches between True and False to Open and Close the Inventory
        }
        //Sets Inventory into the Active state
        if (invOpen == true)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            invUIManager.InvToggle(true);
        }
        else
        { //Sends Inventory into Inactive State
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            invUIManager.InvToggle(false);
        }

        if (inv.HasItem(inv.GetItemWithName("Login")))
        {
            loginNote.SetActive(true);
        }
        else
        {
            loginNote.SetActive(false);
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
        bool temp;
        //invUI.AddItem(i);
        if(inv.AddItem(i) == true)
        {
            temp = true;
            invUIManager.AddItem(i);
        } else { temp = false; }
        return temp;
    }

    public bool CanOpenDoor(int id)
    {
        return inv.CanOpenDoor(id);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ending")
        {
            //Load Outside
            Debug.Log("Endgame");
            SceneManager.LoadScene("ProceduralTerrain");
        }
    }
}
