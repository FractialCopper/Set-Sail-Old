using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass_Behaviour : MonoBehaviour
{
    public PlayerBehav player;
    public Game game;
    Isle_Behaviour location;
    Isle_Behaviour goal;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Cycle()
    {
        location = player.location.GetComponent<Isle_Behaviour>();
        goal = game.map_generator.goal_tile;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (location != null && goal != null)
        {
            //Debug.Log(location.field.x + " + " + location.field.y + " | " + goal.field.x + " + " + goal.field.y);
            Vector2 location_vector = new Vector2(location.field.x, -location.field.y);
            Vector2 goal_vector = new Vector2(goal.field.x,-goal.field.y);
            Vector2 true_vector = new Vector2(goal.gameObject.transform.position.x,0);
               
            if (goal.field.x - location.field.x != 0 && goal.field.y - location.field.y != 0) {
                if (goal.field.x - location.field.x > 0)
                    //transform.rotation = Quaternion.identity * Quaternion.Euler(new Vector3(0, 0, Mathf.Pow(Mathf.Tan((goal_vector.y - location_vector.y) / (goal_vector.x - location_vector.x)), -1) * Mathf.Rad2Deg + 270));
                    transform.Rotate(new Vector3(0, 0, (Mathf.Atan2((goal_vector.y - location_vector.y) , (goal_vector.x - location_vector.x)) * Mathf.Rad2Deg -90 )));
                else
                    //transform.rotation = Quaternion.identity * Quaternion.Euler(new Vector3(0, 0, -Mathf.Pow(Mathf.Tan((goal_vector.y - location_vector.y) / (goal_vector.x - location_vector.x)), -1) * Mathf.Rad2Deg + 90));
                    transform.Rotate( new Vector3(0, 0, (Mathf.Atan2((goal_vector.y - location_vector.y) ,(goal_vector.x - location_vector.x)) * Mathf.Rad2Deg -90)));

            }

            else if (goal.field.x - location.field.x == 0)
            {
                if (goal.field.y - location.field.y > 0)
                
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                else
                    transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (goal.field.y - location.field.y == 0) {
                if (goal.field.x - location.field.x > 0)
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                else
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                }
        }

    }
    //transform.rotation = (Quaternion.Euler(0, 0, Mathf.Pow(Mathf.Tan((goal.field.y - location.field.y) / (goal.field.x - location.field.x)), -1)));
}