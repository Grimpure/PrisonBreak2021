using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new List<Item>();
    private float weight = 0;
    private float maxWeight = 100;
    
    public bool AddItem(Item i)
    {
        if (weight + i.GetWeight() <= maxWeight)
        {
            items.Add(i);
            weight += i.GetWeight();
            return true;
        } else
        {
            Debug.Log("MAXIMUM WEIGHT REACHED, ITEM REFUSED");
            return false;
        }
    }

    public bool RemoveItem(Item i)
    {
        bool success = items.Remove(i);

        if (success)
        {
            weight -= i.GetWeight();
        }
        return success;
    }

    public bool HasItem(Item i)
    {
        return items.Contains(i);
    }

    public bool CanOpenDoor(int id)
    {
        bool result = false;

        foreach (Item item in items)
        {
            if(item is AccessItem)
            {
                if (((AccessItem) item).OpensDoor(id))
                {
                    result = true;
                }
            }
        }
        return result;
    }
}
