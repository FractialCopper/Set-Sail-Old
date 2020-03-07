using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint {

    List<Ingredients> ingredients;
    Item result;

    public Blueprint(List<Ingredients> ingredients, Item result)
    {
        this.ingredients = ingredients;
        this.result = result;
    }

    public struct Ingredients{
        Item item;
        int quantity;
    }
}
