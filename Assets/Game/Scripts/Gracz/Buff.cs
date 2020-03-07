using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff 
{
    Stats stats_buffed;
    bool isbuff;

    public bool Isbuff { get => isbuff; set => isbuff = value; }

    public Buff(bool isbuff) {
        if (isbuff)
            RandomBuff();
        else
            RandomDebuff();
    }

    public Buff(Stats buff) {
        stats_buffed = buff;
    }


    void RandomDebuff() {
        int stat = Random.Range(0, 7);
        int debuff_value = Random.Range(5,15);
        List<double> stats = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
        stats[stat] = -debuff_value;
        stats_buffed = new Stats(stats);
    }
    void RandomBuff() {
        int stat = Random.Range(0, 7);
        int debuff_value = Random.Range(5, 15);
        List<double> stats = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
        stats[stat] = debuff_value;
        stats_buffed = new Stats(stats);
    }
}
