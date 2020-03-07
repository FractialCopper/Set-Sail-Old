using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmass {

    Isle isle;
    int commoners;
    double chance;
    int gold;
    int penaltyAmmount;
    Penalty penalty;
    List<Loot> loot;

    public Landmass(Isle isle, int commoners, double chance, int gold, int penaltyAmmount, Penalty penalty, List<Loot> loot)
    {
        this.isle = isle;
        this.commoners = commoners;
        this.chance = chance;
        this.gold = gold;
        this.penaltyAmmount = penaltyAmmount;
        this.penalty = penalty;
        this.loot = loot;
    }

    public struct Loot
    {
        Item item;
        int quantity;
    }
}
