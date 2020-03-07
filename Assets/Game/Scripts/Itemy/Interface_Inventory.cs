using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface_Inventory : MonoBehaviour
{
    public List<Interface_Item> items = new List<Interface_Item>();
    public GameObject slotPrefab;
    public Transform slot;
    public int slot_quantity = 6;

    void Awake() {
        for (int i = 0; i < slot_quantity; i++) {
            GameObject prefab = Instantiate(slotPrefab);
            prefab.transform.SetParent(slot,false);
            items.Add(prefab.GetComponentInChildren<Interface_Item>());
        }
    }
    public void UpdateSlot(int id, Item item) {
          items[id].UpdateInterface(item);
    }
    public void AddItem(Item item) {
        UpdateSlot(items.FindIndex(i => i.item == null), item);
    }
    public void RemoveItem(Item item) {
       UpdateSlot(items.FindIndex(i => i.item == item), null);

    }
    public void RemoveItem(int index) {
        if (0 < index && index < items.Count)
            UpdateSlot(index, null);
    }

    public void RemoveAllItems() {
        int i = 0;
        foreach (Interface_Item item in items) {
            items[i].UpdateInterface(null);
            i++;
        }
    }
}
