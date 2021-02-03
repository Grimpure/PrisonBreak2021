using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private string name;
    private float weight;

    public Item(string name, float weight)
    {
        this.name = name;
        this.weight = weight;
    }

    public Item(string name)
    {
        this.name = name;
        weight = 0;
    }
}
