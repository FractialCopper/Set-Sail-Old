using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehav : MonoBehaviour {

    // Use this for initialization
   
    
    public GameObject game;
    public GameObject location;
    public GameObject statusText;
    public Alpha_Change hp_bar;
    public Animator animator;

    
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
       animator.SetBool("Attack", false);
	}
    public void RecieveDamage(float ammount)
    {
        if (ammount < 0) { 
            game.GetComponent<Game>().TakeDamage(ammount);
            showText(ammount.ToString());
        }
    }


    public void showText(string message) {
        GameObject text = Instantiate(statusText);        
        text.transform.GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Icons/health");
        text.GetComponentInChildren<TextMeshPro>().text = message;
        text.GetComponentInChildren<TextMeshPro>().color = Color.red;

        //text.GetComponent<TextMesh>().text = message;

    }

    public void onLocationChange(GameObject new_location) {
        if(location!=null)
        location.GetComponent<Isle_Behaviour>().OnLeave();
        location = new_location;
        location.GetComponent<Isle_Behaviour>().OnEnter();
        transform.position = new Vector3(location.transform.position.x, location.transform.position.y,-1);
        //transform.position.Set(transform.position.x,transform.position.y, -1);
        hp_bar.Inform(location.GetComponent<Isle_Behaviour>().field.x,location.GetComponent<Isle_Behaviour>().field.y);
        //Debug.Log("x: " + location.GetComponent<Isle_Behaviour>().field.x + " y: " + location.GetComponent<Isle_Behaviour>().field.y);
        if (new_location.GetComponent<Isle_Behaviour>().field.evaluate() != 2)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);            
        }
        ClockCycle();
    }

    public void ClockCycle() {
        game.GetComponent<Game>().Cycle();
    }

    public void MoveFromTo(GameObject current, GameObject target)
    {
        GameObject toMove = target;
        if (game.GetComponent<Game>().isPlayerAlive && !game.GetComponent<Game>().isMovementLocked) { 
            Field current_field = current.GetComponent<Isle_Behaviour>().field;
            Field target_field = target.GetComponent<Isle_Behaviour>().field;
        if(target.GetComponent<Isle_Behaviour>().isPassable)    
            if (IsNeighbouring(current_field.x, current_field.y, target_field.x, target_field.y))
            {

                    if(!gameObject.transform.GetChild(0).gameObject.active)
                        gameObject.transform.GetChild(0).gameObject.SetActive(true);

                    if (current_field.evaluate() == 2)
                       current.transform.GetChild(0).gameObject.SetActive(false);

                    if (target_field.evaluate() == 2)
                    {
                      gameObject.transform.GetChild(0).gameObject.SetActive(false);
                      target.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    //Debug.Log(target_field.evaluate());
                    
                    if (target_field.evaluate() == 1)
                    {

                       
                        if (target.GetComponent<Enemy_Container>().isOccupated)
                        {
                            game.GetComponent<Game>().Attack(target.GetComponent<Enemy_Container>().occupation);
                            animator.SetBool("Attack", true);
                            toMove = current;
                            if(toMove.GetComponent<Isle_Behaviour>().field.evaluate()==1)
                                GetComponent<PlayerBehav>().RecieveDamage(-2);
                        }
                        else {
                            GetComponent<PlayerBehav>().RecieveDamage(-2);
                        }

                    }
                    if (toMove == current && toMove.GetComponent<Isle_Behaviour>().field.evaluate() == 2) {
                        gameObject.transform.GetChild(0).gameObject.SetActive(false);
                        toMove.transform.GetChild(0).gameObject.SetActive(true);
                        ClockCycle();
                    }
                    else
                        GetComponent<PlayerBehav>().onLocationChange(toMove);


                }
        }
    }

    public bool IsNeighbouring(int x1, int y1, int x2, int y2)
    {
        if (Mathf.Abs(x1 - x2) == 1 && y1 == y2)
            return true;
        if (Mathf.Abs(y1 - y2) == 1 && x1 == x2)
            return true;
        return false;
    }

    public void onReachingGoal() {
        game.GetComponent<Game>().loadNextLevel();
        Debug.Log("Nowy poziom");
    }
}
