using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    public int damage = 15;
    public bool isPrepared = false;
    public int chase_range = 2;
    public int health = 25;
    public int max_health = 25;
    public int coord_x;
    public int coord_y;
    public int prepare_status = 0;
    public bool isReturning = false;
    bool isActive = false;
    bool isInitiated = false;
    public bool deathuntoggled = false;

    public TextMeshPro text_health;

    public Animator animator;
    public PlayerBehav player;
    public TileGenerator map_generator;
    public Isle_Behaviour initial_position;
    public Isle_Behaviour current_position;
    public Isle_Behaviour player_position;
    Isle_Behaviour target;
    public Animation attack;
    public int attack_direction;
    public Game game;


    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Controller").GetComponent<Game>();
        if(animator!=null)
            animator.SetInteger("State", 0);
        player = GameObject.Find("Player").GetComponent<PlayerBehav>();
        map_generator =  GameObject.Find("Controller").GetComponent<TileGenerator>();
        text_health.text = health + "/" + max_health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initiate(Isle_Behaviour initial_position) {
        this.initial_position = initial_position;
        current_position = initial_position;
        coord_x = current_position.field.x;
        coord_y = current_position.field.y;
        onLocationChange(current_position.gameObject);
        //UpdatePlayerPosition();
        isInitiated = true;
    }

    public void Cycle()
    {
        if (health > 0) { 
        UpdatePlayerPosition();

        if (!isActive)
        {
            if (IsPlayerInRange(chase_range))
            {
                Notice();
                isPrepared = false;
            }         //else
                //Do nothing
                
        }
        else
        {
            if (IsPlayerInRange(1) || prepare_status > 0)
                if (isPrepared)
                    Attack();
                else
                    Prepare();
            else
            {
                if (ShouldIReturn())
                    isReturning = true;
                    
                Move();
                if (current_position == initial_position)
                {
                    isActive = !isActive;
                    isReturning = false;
                }
                isPrepared = false;
            }
        }

        }

    }

    public void UpdatePlayerPosition() {
        player_position = player.location.GetComponent<Isle_Behaviour>();
    }


    public void Notice() {
        isActive = true;
        if (animator != null)
            animator.SetInteger("State", 1);
        //playnoticeanimation
    }

    public void Prepare() {
        if (animator != null)
            animator.SetInteger("State", 1);
        prepare_status++;
        if (prepare_status >= 2)
        {
            prepare_status = 0;
            isPrepared = true;
            
        }
        //int left_or_right = player_position.field.x - current_position.field.x;
        //int up_or_down = player_position.field.y - current_position.field.y;
        //attack_direction = 1 * (left_or_right) + (3) * up_or_down;
        //target = player_position;
        //playprepareanimation            
        }

    public void Attack() {
        //if(player_position  == target)

        if (IsPlayerInRange(1))
        {
            CheckAgainstPlayer();
            if (player_position.field.x - coord_x > 0)
            {
                if (animator != null)
                    animator.SetInteger("State", 4);
            }
            else {
                if (animator != null)
                    animator.SetInteger("State", 5);
            }
            //Debug.Log("Zaatakowalem");
        }
        isPrepared = false;
        //animator.SetInteger("State", 0);
    }


    public bool IsPlayerInRange(int chase_range){
        int x = player_position.field.x;
        int y = player_position.field.y;
        if ((Mathf.Abs(coord_x - x) <= chase_range && Mathf.Abs(coord_y - y)== 0) || (Mathf.Abs(coord_y - y) <= chase_range && Mathf.Abs(coord_x - x) == 0))
            return true;
        return false;
    }
    public void CheckAgainstPlayer() {
        game.ChallengePlayer(this);
    }


    public void RecieveDamage(int damage) {
        health -= damage;
        text_health.text = health + "/" + max_health;
        if (health <= 0)
        {
            if (animator != null)
                animator.SetInteger("State", 10);
                deathuntoggled = true;
                current_position.gameObject.GetComponent<Enemy_Container>().isOccupated = false;
                current_position.gameObject.GetComponent<Enemy_Container>().occupation = null;
                Destroy(gameObject, 1);
            
        }
    }

    public void Move() {
        if (animator != null)
            animator.SetInteger("State", 0);
        Isle_Behaviour target_field;
        int general_direction;
        int src_x;
        int src_y;
        Isle_Behaviour temp;


        if (isReturning) {
           src_x = initial_position.field.x;
           src_y = initial_position.field.y;
        }
        else
        {
           src_x = player_position.field.x;
           src_y = player_position.field.y;
        }
        general_direction = 1 * Sign(src_x - coord_x) + 3 * Sign((coord_y - src_y));
        if (src_x != coord_x || src_y != coord_y) {       
            //Debug.Log("General direction " + general_direction + " src x y " + src_x + " " +src_y + " cordx cordy " + coord_x + " " + coord_y );
            if (general_direction > 0)
            {
                if (general_direction > 2)
                {
                    if (general_direction == 4)
                    {
                        //prawo
                        temp = map_generator.FindFieldOfXandY(coord_x + 1, coord_y);
                        if (isFieldAvaible(temp))
                            MoveFromTo(current_position.gameObject, temp.gameObject);
                        else
                        {
                            //góra
                            temp = map_generator.FindFieldOfXandY(coord_x, coord_y - 1);
                            if (isFieldAvaible(temp))
                                MoveFromTo(current_position.gameObject, temp.gameObject);
                        }
                    }
                    //general dir == 3
                    else
                    {
                        //góra
                        temp = map_generator.FindFieldOfXandY(coord_x, coord_y - 1);
                        if (isFieldAvaible(temp))
                            MoveFromTo(current_position.gameObject, temp.gameObject);
                    }

                }
                else
                {
                    if (general_direction == 2)
                    {
                        // lewo
                        temp = map_generator.FindFieldOfXandY(coord_x - 1, coord_y);
                        if (isFieldAvaible(temp))
                            MoveFromTo(current_position.gameObject, temp.gameObject);
                        else
                        {
                            //gora
                            temp = map_generator.FindFieldOfXandY(coord_x, coord_y - 1);
                            if (isFieldAvaible(temp))
                                MoveFromTo(current_position.gameObject, temp.gameObject);
                        }
                    }

                    //general dir == 1
                    else
                    {
                        //prawo
                        temp = map_generator.FindFieldOfXandY(coord_x + 1, coord_y);
                        if (isFieldAvaible(temp))
                            MoveFromTo(current_position.gameObject, temp.gameObject);
                    }

                }
            }
            else
            {
                if (general_direction < -2)
                {
                    if (general_direction == -4)
                    {
                        //lewo
                        temp = map_generator.FindFieldOfXandY(coord_x - 1, coord_y);
                        if (isFieldAvaible(temp))
                            MoveFromTo(current_position.gameObject, temp.gameObject);
                        else
                        {
                            //dół
                            temp = map_generator.FindFieldOfXandY(coord_x, coord_y + 1);
                            if (isFieldAvaible(temp))
                                MoveFromTo(current_position.gameObject, temp.gameObject);
                        }
                    }
                    //general dir == -3
                    else
                    {
                        //dół
                        temp = map_generator.FindFieldOfXandY(coord_x, coord_y + 1);
                        if (isFieldAvaible(temp))
                            MoveFromTo(current_position.gameObject, temp.gameObject);
                    }

                }
                else
                {
                    if (general_direction == -2)
                    {
                        //prawo
                        temp = map_generator.FindFieldOfXandY(coord_x + 1, coord_y);
                        if (isFieldAvaible(temp))
                            MoveFromTo(current_position.gameObject, temp.gameObject);
                        else
                        {
                            //dół
                            temp = map_generator.FindFieldOfXandY(coord_x, coord_y + 1);
                            if (isFieldAvaible(temp))
                                MoveFromTo(current_position.gameObject, temp.gameObject);
                        }

                    }
                    //general dir == -1
                    else
                    {
                        //lewo
                        temp = map_generator.FindFieldOfXandY(coord_x - 1, coord_y);
                        if (isFieldAvaible(temp))
                            MoveFromTo(current_position.gameObject, temp.gameObject);
                    }

                }
            }
        }
    }

    public int Sign(int number) {
        if (number != 0)
            return (int)Mathf.Sign(number);
        else
            return 0;

    }
    public bool isFieldAvaible(Isle_Behaviour target_field) {
        if (target_field.field.evaluate() == 1 && target_field.isPassable && target_field != player_position)
            return true;
        else
           return false;
    }



    public bool ShouldIReturn() {
        if (Mathf.Abs(current_position.field.x - initial_position.field.x) + Mathf.Abs(current_position.field.y - initial_position.field.y) >= chase_range)
            return true;
        return false;
    }

    public void onLocationChange(GameObject new_location)
    {
        current_position = new_location.GetComponent<Isle_Behaviour>();
        GameObject location = current_position.gameObject;
        coord_x = current_position.field.x;
        coord_y = current_position.field.y;
        new_location.GetComponent<Enemy_Container>().occupation = this;
        new_location.GetComponent<Enemy_Container>().isOccupated = true;
        transform.position = new Vector3(location.transform.position.x, location.transform.position.y, -1);
        transform.SetParent(new_location.transform);
    }


    public void MoveFromTo(GameObject current, GameObject target)
    {
        //if (game.GetComponent<Game>().isPlayerAlive && !game.GetComponent<Game>().isMovementLocked)
        //{
            Field current_field = current.GetComponent<Isle_Behaviour>().field;
            Field target_field = target.GetComponent<Isle_Behaviour>().field;
        if (target.GetComponent<Isle_Behaviour>().isPassable && target.GetComponent<Enemy_Container>().occupation == null)
                if (IsNeighbouring(current_field.x, current_field.y, target_field.x, target_field.y) )
                {
                    if (current != null)
                    {
                        current.GetComponent<Enemy_Container>().occupation = null;
                        current.GetComponent<Enemy_Container>().isOccupated = false;
                    }
                    onLocationChange(target);
                }
    }
    //}


    public bool IsNeighbouring(int x1, int y1, int x2, int y2)
    {
        if (Mathf.Abs(x1 - x2) == 1 && y1 == y2)
            return true;
        if (Mathf.Abs(y1 - y2) == 1 && x1 == x2)
            return true;
        return false;
    }



}
