using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> items = new List<Item>();

    //2 Stern, 3 Fuselage, 4 Sails, 5 Cannons
    //stats - > 0 - speed 1- firepower 2- endurance 3- luck 
    //4- charisma 5- weight 6 - maneuver 7- morale  

    // item id, name, icon, description, stats, class_id
    void Initiate() {
        items = new List<Item>() {
            //Poziom 1
            new Item(1,"First_Level_Fuselage_1","Fuselage_1","opis",new Stats(10f,0f,10f,0,0,0,0,0),3),
            new Item(2,"First_Level_Cannons_1","Cannons_1","opis",new Stats(0f,20f,0f,0f,0f,10f,0f,0f),5),
            new Item(3,"First_Level_Sails_1","Sails_1","opis",new Stats(0f,0f,0f,10f,0f,0f,10f,0f),4),
            new Item(4,"First_Level_Stern_1","Stern_1","opis",new Stats(0f,0f,0f,0f,10f,0f,0f,10f),2),
            new Item(5,"First_Level_Fuselage_2","Fuselage_1","opis",new Stats(0f,0f,10f,0,0,0,10f,0),3),
            new Item(6,"First_Level_Cannons_2","Cannons_1","opis",new Stats(0f,10f,0f,10f,0f,0f,0f,0f),5),
            new Item(7,"First_Level_Sails_2","Sails_1","opis",new Stats(10f,0f,0f,0f,0f,0f,10f,0f),4),
            new Item(8,"First_Level_Stern_2","Stern_1","opis",new Stats(0f,10f,0f,0f,0f,0f,0f,10f),2),
            new Item(9,"First_Level_Fuselage_3","Fuselage_1","opis",new Stats(10f,0f,0f,0,0,0,10f,0),3),
            new Item(10,"First_Level_Cannons_3","Cannons_1","opis",new Stats(0f,10f,0f,0f,10f,0f,0f,0f),5),
            new Item(11,"First_Level_Sails_3","Sails_1","opis",new Stats(10f,0f,10f,0f,0f,0f,0f,0f),4),
            new Item(12,"First_Level_Stern_3","Stern_1","opis",new Stats(0f,10f,0f,0f,10f,0f,0f,0f),2),

            //Poziom 2
            new Item(13,"Second_Level_Fuselage_1","Fuselage_2","opis",new Stats(20f,0f,20f,0,0,0,0,0),3),
            new Item(14,"Second_Level_Cannons_1","Cannons_2","opis",new Stats(0f,40f,0f,0f,0f,20f,0f,0f),5),
            new Item(15,"Second_Level_Sails_1","Sails_2","opis",new Stats(0f,0f,0f,20f,0f,0f,20f,0f),4),
            new Item(16,"Second_Level_Stern_1","Stern_2","opis",new Stats(0f,0f,0f,0f,20f,0f,0f,20f),2),
            new Item(17,"Second_Level_Fuselage_2","Fuselage_2","opis",new Stats(0f,0f,20f,0,0,0,20f,0),3),
            new Item(18,"Second_Level_Cannons_2","Cannons_2","opis",new Stats(0f,20f,0f,20f,0f,0f,0f,0f),5),
            new Item(19,"Second_Level_Sails_2","Sails_2","opis",new Stats(20f,0f,0f,0f,0f,0f,20f,0f),4),
            new Item(20,"Second_Level_Stern_2","Stern_2","opis",new Stats(0f,20f,0f,0f,0f,0f,0f,20f),2),
            new Item(21,"Second_Level_Fuselage_3","Fuselage_2","opis",new Stats(20f,0f,0f,0,0,0,20f,0),3),
            new Item(22,"Second_Level_Cannons_3","Cannons_2","opis",new Stats(0f,20f,0f,0f,20f,0f,0f,0f),5),
            new Item(23,"Second_Level_Sails_3","Sails_2","opis",new Stats(20f,0f,20f,0f,0f,0f,0f,0f),4),
            new Item(24,"Second_Level_Stern_3","Stern_2","opis",new Stats(0f,20f,0f,0f,20f,0f,0f,0f),2),

            //Poziom 3

            new Item(25,"Third_Level_Fuselage_1","Fuselage_3","opis",new Stats(30f,0f,30f,0,0,0,0,0),3),
            new Item(26,"Third_Level_Cannons_1","Cannons_3","opis",new Stats(0f,60f,0f,0f,0f,30f,0f,0f),5),
            new Item(27,"Third_Level_Sails_1","Sails_3","opis",new Stats(0f,0f,0f,30f,0f,0f,30f,0f),4),
            new Item(28,"Third_Level_Stern_1","Stern_3","opis",new Stats(0f,0f,0f,0f,30f,0f,0f,30f),2),
            new Item(29,"Third_Level_Fuselage_2","Fuselage_3","opis",new Stats(0f,0f,30f,0,0,0,30f,0),3),
            new Item(30,"Third_Level_Cannons_2","Cannons_3","opis",new Stats(0f,30f,0f,30f,0f,0f,0f,0f),5),
            new Item(31,"Third_Level_Sails_2","Sails_3","opis",new Stats(30f,0f,0f,0f,0f,0f,30f,0f),4),
            new Item(32,"Third_Level_Stern_2","Stern_3","opis",new Stats(0f,30f,0f,0f,0f,0f,0f,30f),2),
            new Item(33,"Third_Level_Fuselage_3","Fuselage_3","opis",new Stats(30f,0f,0f,0,0,0,30f,0),3),
            new Item(34,"Third_Level_Cannons_3","Cannons_3","opis",new Stats(0f,30f,0f,0f,30f,0f,0f,0f),5),
            new Item(35,"Third_Level_Sails_3","Sails_3","opis",new Stats(30f,0f,30f,0f,0f,0f,0f,0f),4),
            new Item(36,"Third_Level_Stern_3","Stern_3","opis",new Stats(0f,30f,0f,0f,30f,0f,0f,0f),2),


            //Poziom 4
            new Item(37,"Fourth_Level_Fuselage_1","Fuselage_4","opis",new Stats(40f,0f,40f,0,0,0,0,0),3),
            new Item(38,"Fourth_Level_Cannons_1","Cannons_4","opis",new Stats(0f,80f,0f,0f,0f,40f,0f,0f),5),
            new Item(39,"Fourth_Level_Sails_1","Sails_4","opis",new Stats(0f,0f,0f,40f,0f,0f,40f,0f),4),
            new Item(40,"Fourth_Level_Stern_1","Stern_4","opis",new Stats(0f,0f,0f,0f,40f,0f,0f,40f),2),
            new Item(41,"Fourth_Level_Fuselage_2","Fuselage_4","opis",new Stats(0f,0f,40f,0,0,0,40f,0),3),
            new Item(42,"Fourth_Level_Cannons_2","Cannons_4","opis",new Stats(0f,40f,0f,40f,0f,0f,0f,0f),5),
            new Item(43,"Fourth_Level_Sails_2","Sails_4","opis",new Stats(40f,0f,0f,0f,0f,0f,40f,0f),4),
            new Item(44,"Fourth_Level_Stern_2","Stern_4","opis",new Stats(0f,40f,0f,0f,0f,0f,0f,40f),2),
            new Item(45,"Fourth_Level_Fuselage_3","Fuselage_4","opis",new Stats(40f,0f,0f,0,0,0,40f,0),3),
            new Item(46,"Fourth_Level_Cannons_3","Cannons_4","opis",new Stats(0f,40f,0f,0f,40f,0f,0f,0f),5),
            new Item(47,"Fourth_Level_Sails_3","Sails_4","opis",new Stats(40f,0f,40f,0f,0f,0f,0f,0f),4),
            new Item(48,"Fourth_Level_Stern_3","Stern_4","opis",new Stats(0f,40f,0f,0f,40f,0f,0f,0f),2),

            //Poziom 5 

            new Item(49,"Fifth_Level_Fuselage_1","Fuselage_5","opis",new Stats(50f,0f,50f,0,0,0,0,0),3),
            new Item(50,"Fifth_Level_Cannons_1","Cannons_5","opis",new Stats(0f,100f,0f,0f,0f,50f,0f,0f),5),
            new Item(51,"Fifth_Level_Sails_1","Sails_5","opis",new Stats(0f,0f,0f,50f,0f,0f,50f,0f),4),
            new Item(52,"Fifth_Level_Stern_1","Stern_5","opis",new Stats(0f,0f,0f,0f,50f,0f,0f,50f),2),
            new Item(53,"Fifth_Level_Fuselage_2","Fuselage_5","opis",new Stats(0f,0f,50f,0,0,0,50f,0),3),
            new Item(54,"Fifth_Level_Cannons_2","Cannons_5","opis",new Stats(0f,50f,0f,50f,0f,0f,0f,0f),5),
            new Item(55,"Fifth_Level_Sails_2","Sails_5","opis",new Stats(50f,0f,0f,0f,0f,0f,50f,0f),4),
            new Item(56,"Fifth_Level_Stern_2","Stern_5","opis",new Stats(0f,50f,0f,0f,0f,0f,0f,50f),2),
            new Item(57,"Fifth_Level_Fuselage_3","Fuselage_5","opis",new Stats(50f,0f,0f,0,0,0,50f,0),3),
            new Item(58,"Fifth_Level_Cannons_3","Cannons_5","opis",new Stats(0f,50f,0f,0f,50f,0f,0f,0f),5),
            new Item(59,"Fifth_Level_Sails_3","Sails_5","opis",new Stats(50f,0f,50f,0f,0f,0f,0f,0f),4),
            new Item(60,"Fifth_Level_Stern_3","Stern_5","opis",new Stats(0f,50f,0f,0f,50f,0f,0f,0f),2),


        };
        
    }
    public void AddItem(Item item) {
        items.Add(item);
    }

    public void AddItem(List<Item> item)
    {
        items.AddRange(item);
    }

    public Item GetItem(int id) {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string name)
    {
        return items.Find(item => item.name.Equals(name));
    }

    public Item GetRandomItem() {
        return items[Random.Range(0, items.Count)];
    }

    void Awake() {
        Initiate();
    }
}
