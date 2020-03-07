using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Equipment{
    int currQuantity;
    int size;
    List<Item> equipment;

    public Equipment(int size, List<Item> equipment)
    {
        this.size = size;
        this.equipment = equipment;
        currQuantity = equipment.Count();
    }

    public bool addItem(Item item) {
        if (currQuantity < size)
        {
            equipment.Add(item);
            return true;
        }
        else
            return false;
     }

    public Stats sumOfStats() {
        Stats result = new Stats(0,0,0,0,0,0,0,0);
        foreach (Item item in equipment) {
            result.addStats(item.Stats);
        }
        return result;
    }
}
