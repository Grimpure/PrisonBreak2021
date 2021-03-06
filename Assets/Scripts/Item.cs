﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
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


    public string GetName()
    {
        return name;
    }

    public float GetWeight()
    {
        return weight;
    }
}
