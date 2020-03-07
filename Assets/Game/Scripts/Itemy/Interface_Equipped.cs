using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface_Equipped : MonoBehaviour
{
    // Start is called before the first frame update
    public Interface_Item sails;
    public Interface_Item stern;
    public Interface_Item fuselage;
    public Interface_Item cannons;
    public Game game;
    public Stats stats;

    public void UpdateSlot(string name, Item item)
    {
        if (item != null) { 
        switch (name)
        {
            case "Sails":
                if (item.item_class == "Sails")
                    sails.UpdateInterface(item);
                break;
            case "Stern":
                if (item.item_class == "Stern")
                    stern.UpdateInterface(item);
                break;
            case "Fuselage":
                if (item.item_class == "Fuselage")
                    fuselage.UpdateInterface(item);
                break;
            case "Cannons":
                if (item.item_class == "Cannons")
                    cannons.UpdateInterface(item);
                break;
        }
        }
        game.UpdateStats(WearedModifiers());
       
    }

    public bool IsCapable(string name, Item item) {
        switch (name)
        {
            case "Sails":
                if (item.item_class == "Sails")
                    return true;
                else
                    return false;
               case "Stern":
                if (item.item_class == "Stern")
                    return true;
                else
                    return false;
            case "Fuselage":
                if (item.item_class == "Fuselage")
                    return true;
                else
                    return false;
            case "Cannons":
                if (item.item_class == "Cannons")
                    return true;
                else
                    return false;
        }
        return true;
    }
    /*public void AddItem(Item item)
    {
        UpdateSlot(items.FindIndex(i => i.item == null), item);
    }
    public void RemoveItem(Item item)
    {
        UpdateSlot(items.FindIndex(i => i.item == item), null);

    }*/
    public Stats WearedModifiers() {
        stats = cannons.GetComponent<Interface_Item>().GetItemStats() + fuselage.GetComponent<Interface_Item>().GetItemStats() + sails.GetComponent<Interface_Item>().GetItemStats() + stern.GetComponent<Interface_Item>().GetItemStats();
        return stats;
    }

    public void RemoveAllItems() {
        Item item = null;
        sails.UpdateInterface(item);
        stern.UpdateInterface(item);
        fuselage.UpdateInterface(item);
        cannons.UpdateInterface(item);
    }
    /*public void RemoveItem(int index)
    {
        UpdateSlot(index, null);
    }*/


}
