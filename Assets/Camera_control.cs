using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_control : MonoBehaviour
{
    public float MIN_X, MAX_X, MIN_Y, MAX_Y;
    public PlayerBehav player;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetBoundaries(float minx, float maxx, float miny, float maxy) {
        MIN_X = minx;
        MAX_X = maxx;
        MIN_Y = miny;
        MAX_Y = maxy;        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(
           Mathf.Clamp(player.transform.position.x, MIN_X, MAX_X),
           Mathf.Clamp(player.transform.position.y, MIN_Y, MAX_Y),
            -3);
    }
}
