using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public List<string> itemclasses = new List<string>() {"Ingredient","Usable","Stern","Fuselage","Sails","Cannons" };
    public string item_class;
    public string name;
    string icon;
    public string desc;
    Stats stats;
    public Sprite image;
    public int id;

    

    public Item(int id, string name, string icon, string desc,int id_class)
    {
        item_class = itemclasses[id_class];
        this.id = id;
        this.name = name;
        this.icon = icon;
        this.desc = desc;
        image = Resources.Load<Sprite>("Sprites/Items/" + icon);
    }
    public Item(int id, string name, string icon, string desc)
    {
        item_class = itemclasses[0];
        this.id = id;
        this.name = name;
        this.icon = icon;
        this.desc = desc;
        image = Resources.Load<Sprite>("Sprites/Items/" + icon);
    }

    public Item(Item item) {
        this.item_class = item.item_class;
        this.id = item.id;
        this.name = item.name;
        this.desc = item.desc;
        this.image = item.image;
        if (item.stats != null)
            this.stats = item.stats;
    }

    public Item(int id,string name, string icon, string desc, Stats stats,int id_class) : this(id,name, icon, desc,id_class)
    {
        this.stats = stats;
    }
    public Item(int id, string name, string icon, string desc, Stats stats) : this(id, name, icon, desc)
    {
        this.stats = stats;
    }

    public Stats Stats
    {
        get
        {
            return stats;
        }

        set
        {
            stats = value;
        }
    }
}
