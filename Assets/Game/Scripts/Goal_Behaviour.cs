using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Behaviour : Field
{
   
   
    public Goal_Behaviour(int x, int y) : base(x, y)
    {
        
       
    }

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }


    // Start is called before the first frame update
    public override int evaluate() {
        
        return 10;
    }

    
}
