using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town {
    List<Places> buildingsState;

    public Town(List<Places> buildings)
    {
        this.buildingsState = buildings;
    }


    public struct Places {
        Building building;
        int level;
    }
}
