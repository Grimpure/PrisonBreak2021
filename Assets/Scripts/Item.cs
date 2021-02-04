using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private string name;
    private float weight;
    /* Optional Properties */
    //private bool stolen;
    //private bool quest;

    public Item(string name, float weight)
    {
        this.name = name;
        this.weight = weight;
    }

    public Item(string m_name)
    {
        this.name = m_name;
        weight = 0;
    }

    public float GetWeight()
    {
        return weight;
    }
}
