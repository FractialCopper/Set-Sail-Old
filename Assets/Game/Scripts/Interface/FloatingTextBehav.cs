using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextBehav : MonoBehaviour
{
    // Start is called before the first frame update

    float destroyTime  = 3f;
    void Start()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, - 10); 
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
