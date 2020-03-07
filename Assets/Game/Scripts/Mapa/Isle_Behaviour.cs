using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isle_Behaviour : MonoBehaviour {

    public bool isPassable = true;
    public Field field;
    bool solved;
    public EventBehav enter_event;
    public TriggeredEvent tevent;
    GameObject player;
    PlayerBehav player_behaviour;
    public Container_Behaviour container;

    // Use this for initialization
    void Awake() {
        // do zmiany
       
        enter_event = GameObject.Find("Event").GetComponent<EventBehav>();
        player = GameObject.Find("Player");
        player_behaviour = player.GetComponent<PlayerBehav>();
        
    }

	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   

   public void OnEnter() {
        if (!solved)
        {
            if (field.evaluate() == 2)
            {
                enter_event.Trigger(tevent);
                //Debug.Log("Stat on enter: " + tevent.test.stat_id);
            }
            //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            //field.evaluate();
            if(field.evaluate() == 10)
                player_behaviour.onReachingGoal();
        }
    }

    public void OnLeave() {
        if (field.evaluate() == 2) {
            if(enter_event.toggled)
            enter_event.Trigger(tevent);
        }
        

    }
}
