using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isle : Field {

    public int id;

    public Isle(int x, int y,int id) : base(x, y)
    {
        this.id = id;
    }

    public override int evaluate() {
        return 2;
    }
}
