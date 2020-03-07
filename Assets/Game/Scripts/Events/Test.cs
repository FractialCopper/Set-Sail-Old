using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test 
{
    public int stat_id;

    public Test() {
        stat_id = Random.Range(0, 8);
       // Debug.Log("Stat id: " + stat_id);
    }
    public Test(int stat_id) {
        this.stat_id = stat_id;
    }

    public bool Solve(double chance) {
        if (chance >= Random.Range(0f, 100f)) {
            return true;
        }
       else
            return false;
    }


}
