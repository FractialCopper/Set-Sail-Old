using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventBehav : MonoBehaviour
{
    public bool toggled = false;
    
    public float x_move;
    public float y_move;
    public TriggeredEvent trigg_event;
    //public TextMeshProUGUI event_description;
    public Button option_1;
    public Button option_2;
    public TextMeshProUGUI option_1_text;
    public TextMeshProUGUI option_2_text;
    public Game game;
    public GameObject animated_info;
    public TextMeshProUGUI success_chance;
    public TextMeshProUGUI fail_chance;


    static Color success = new Color(125,253,108,255);
    static Color fail = new Color(245, 60, 0, 255);
   

    public TextMeshPro status_update_text;
    public SpriteRenderer status_update_image;

    //public Activate_Animation animation;
    public Image image;
   
    
    public Image prize_image;
    public Image penalty_image;


    void Awake()
    {
       
        option_1 = GameObject.Find("Option_1").GetComponent<Button>();
        option_2 = GameObject.Find("Option_2").GetComponent<Button>();
        option_1.onClick.AddListener(OnAgree);
        option_2.onClick.AddListener(OnDisagree);
        //status_update_image = animated_info.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
        //status_update_text = animated_info.GetComponentInChildren<TextMeshPro>();
        //event_description = GameObject.Find("Event_Description").GetComponent<TextMeshProUGUI>();
        option_1_text = GameObject.Find("Option_1_Text").GetComponent<TextMeshProUGUI>(); 
        option_2_text = GameObject.Find("Option_2_Text").GetComponent<TextMeshProUGUI>();
        game = GameObject.Find("Controller").GetComponent<Game>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Toggle() {
        
        
            if (!toggled)
                transform.position = new Vector3(transform.position.x + x_move * transform.lossyScale.x, transform.position.y + y_move * transform.lossyScale.y, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x - x_move * transform.lossyScale.x, transform.position.y - y_move * transform.lossyScale.y, transform.position.z);
            toggled = !toggled;

        
    }

    public void AssignSprites() {
        image.sprite = Resources.Load<Sprite>("Sprites/Stats/" + trigg_event.test.stat_id);
        Prize prize = trigg_event.prize;
        Penalty penalty = trigg_event.penalty;
        string name = penalty.Name;

        if (prize.Item != null)
           prize_image.sprite = Resources.Load<Sprite>("Sprites/Icons/barrel"  );

        else if (prize.Name.Equals("gold"))
            prize_image.sprite = Resources.Load<Sprite>("Sprites/Icons/coins");

        else if (prize.Name.Equals("dur"))
            prize_image.sprite = Resources.Load<Sprite>("Sprites/Icons/health");

     
        if (name.Equals("gold"))
        {
            penalty_image.sprite = Resources.Load<Sprite>("Sprites/Icons/coins");
        }
        if (name.Equals("dur"))
        {
            penalty_image.sprite = Resources.Load<Sprite>("Sprites/Icons/health");
        }
        if (name.Equals("inventory"))
        {
            penalty_image.sprite = Resources.Load<Sprite>("Sprites/Icons/barrel");
        }

    }


    public void Trigger(TriggeredEvent tevent) {
        if (!tevent.solved) { 
        if (!toggled && tevent != null)
        {
            trigg_event = tevent;
            //event_description.text = tevent.flavour_text;
            option_1_text.text = tevent.option_one;
            option_2_text.text = tevent.option_two;
            float chance = tevent.ShowChance(game.GetStatlist()[trigg_event.test.stat_id]);
            success_chance.text ="(" + chance.ToString("F2")+"%)";
            fail_chance.text = "(" + (100 - chance).ToString("F2") + "%)";
            AssignSprites();

            }

        Toggle();
        }
       // if (toggled && !tevent.solved)
        //{
          //  Toggle();
        //}
    }
    public void OnAgree() {
        if (toggled)
        {
            //Debug.Log("OnAgree");
            bool passed = trigg_event.Test(game.GetStatlist()[trigg_event.test.stat_id]);
            Toggle();

            GameObject spawned = Instantiate(animated_info);
            spawned.transform.SetParent(GameObject.Find("Player").transform);
            status_update_image = spawned.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
            status_update_text = spawned.GetComponentInChildren<TextMeshPro>();


            if (passed)
            {
               // Debug.Log("passed");
                trigg_event.OnSuccess();
                if (trigg_event.prize.Item != null)
                    status_update_text.text = "+ 1";
                else
                    status_update_text.text = "+ " + trigg_event.prize.Ammount;

                status_update_text.color = Color.green;
                status_update_image.sprite = prize_image.sprite;
                //animation.TriggerAnimation();
;           
            }
            else
            {
                //Debug.Log("failed");
                trigg_event.OnFail();
                if (trigg_event.penalty.Name.Equals("item"))
                    status_update_text.text = "- ";
                else
                    status_update_text.text = "- " + trigg_event.penalty.Ammount;

                status_update_text.color = Color.red;
                status_update_image.sprite = penalty_image.sprite;
                //animation.TriggerAnimation();

            }  
        }
        else
        {
            Toggle();
        }
    }

    public void OnDisagree() {
        //Debug.Log("OnDisagree");
        if (!toggled)
        {
            Toggle();
        }
        else
        {
            Toggle();
        }

    }
  
}
