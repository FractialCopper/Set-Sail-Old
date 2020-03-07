using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Field {

    public bool isDeep;

    public Water(int x, int y):base(x,y)
    {       
        
    }

    public Water(int x, int y,bool isDeep) : base(x, y)
    {
        this.isDeep = isDeep;
    }
    public override int evaluate()
    {
        if (isDeep)
            return 1;
        else
            return 4;

    }
}
