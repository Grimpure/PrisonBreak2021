using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject invUI;
    public GameObject UIContent;
    public GameObject buttonPrefab;

    [SerializeField]
    private Item content;
    public PlayerManager pM;

    //public GameObject selectedButton;

    public void InvToggle(bool b)
    {
        invUI.SetActive(b);
    }

    public void AddItem(Item i)
    {
        content = i;
        buttonPrefab.GetComponentInChildren<Text>().text = i.GetName();
        Instantiate(buttonPrefab, UIContent.transform);
    }
}
