using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{

    PlayerManager pM;

    // Start is called before the first frame update
    void Start()
    {
        pM = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(MarkForDrop);
    }

    private void MarkForDrop()
    {
        pM.DropItem(this.gameObject.GetComponentInChildren<Text>().text);
        Destroy(this.gameObject);
    }
}
