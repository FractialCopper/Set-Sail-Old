using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container_Behaviour : MonoBehaviour
{
    public Enemy_Behaviour enemy;
    public GameObject enemy_contained;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cycle() {       
        if (enemy_contained != null) { 
            enemy = enemy_contained.GetComponent<Enemy_Behaviour>();
            enemy.Cycle();
        }           

    }
}
