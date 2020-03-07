using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize
{
    List<string> texts_of_choice = new List<string>{"gold","dur","buff",};
    ItemManager item_manager = GameObject.Find("Controller").GetComponent<ItemManager>();
    Item item;    
    string name;
    int ammount;
    int quantity;

    public Item Item { get => item; set => item = value; }
    public string Name { get => name; set => name = value; }
    public int Ammount { get => ammount; set => ammount = value; }
    public int Quantity { get => quantity; set => quantity = value; }

    public Prize() {
        RandomPrize();
    }

    public Prize(string name, int ammount) {
        this.name = name;
        this.ammount = ammount;
    }

    public Prize(Item item) {
        this.item = item;
    }

    public Prize(Item item, int quantity) {
        this.item = item;
        this.quantity = quantity;
    }


    public void RandomPrize() {
        float result = Random.Range(0, 4);
        switch (result *100 % 3) {
            case 0:
                name = "gold";
                ammount = Random.Range(1, 4);
                break;
            case 1:                
                 item = item_manager.GetRandomItem();
                 quantity = 1;
                 ammount = 1;
                 break;
            case 2:
                //item = item_manager.GetRandomItem();
                //quantity = Random.Range(1, 3);
                name = "dur";
                ammount = Random.Range(3, 10);
                break;
        }
        //Debug.Log("Rezultat losowania: "  + result * 100 % 3);

        

    }


}
