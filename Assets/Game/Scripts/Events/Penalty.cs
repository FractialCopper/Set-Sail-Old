using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penalty  {

    string name;
    int ammount;
    List<string> texts_of_choice = new List<string>() { "gold", "dur",
        //"debuff",
        "inventory" };

    public string Name { get => name; set => name = value; }
    public int Ammount { get => ammount; set => ammount = value; }

    public Penalty(string name)
    {
        this.name = name;
    }

    public Penalty(string name, int ammount)
    {
        this.name = name;
    }

    public Penalty() {
        RandomPenalty();
    }

    public void RandomPenalty()
    {
          name = texts_of_choice[Random.Range(0, texts_of_choice.Count)];
        if (name.Equals("gold"))
            ammount = Random.Range(1, 4);
        else if (name.Equals("dur"))
            ammount = Random.Range(3, 10);
        else
            ammount = 1;
    }
    void SetGold() {
        name = "gold";
    }
    void SetDurability()
    {
        name = "dur";
    }
    void SetDebuff()
    {
      //  name = "debuff";
    }
}
