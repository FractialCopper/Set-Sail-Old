using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Field {
    public int x;
    public int y;

    public Field(int x, int y) {
        this.x = x;
        this.y = y;
    }
    public virtual int evaluate() { return 0; }
}
