using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perk{
    int category;
    Perk previous;

    public Perk(int category, Perk previous)
    {
        this.category = category;
        this.previous = previous;
    }


}
