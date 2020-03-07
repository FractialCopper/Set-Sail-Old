using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> backpack = new List<Item>();
    public ItemManager ItemManager;
    public Interface_Inventory UI_items;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            LootItem(Random.Range(1, 13));
        }

    }

    public void InitiateRandomItems() {
        for (int i = 0; i < 4; i++) {
            LootItem(Random.Range(1, 13));
        }
    }

    public void LootItem( int id) {
        Item item = ItemManager.GetItem(id);
        //Debug.Log("Got " + item.desc);
        backpack.Add(item);
        UI_items.AddItem(item);
    }
    public void LootItem(string name) {
        Item item = ItemManager.GetItem(name);
        backpack.Add(item);
        UI_items.AddItem(item);
    }

    public Item GetItem(int id) {
        return backpack.Find(item => item.id == id);
    }
    public Item GetItem(string name) {
        return backpack.Find(item => item.name.Equals(name));
    }

    public Item GetRandomItem() {
        if (backpack.Count > 0)
            return backpack[Random.Range(0, backpack.Count)];
        else
            return null;
    }

    public void DropRandom() {
        Item item = (GetRandomItem());
        if (item != null)
            DropItem(item.id);
    }

    public void DropItem(int id) {
        Item item = GetItem(id);
        if (item != null) {           
            UI_items.RemoveItem(item);
            backpack.Remove(item);
        }
    }
    public void DropAllItems() {
        backpack.Clear();
        UI_items.RemoveAllItems();
    }

}
