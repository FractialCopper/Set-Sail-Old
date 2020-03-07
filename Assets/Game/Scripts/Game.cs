using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    //public Ship ship;
    public Town town;
    public Stats playerstats;
    public GameObject objec1;
    public GameObject player;
    public Stats stats_combined;
    public List<double> stats_array;
    public Inventory inventory;
    public int currentLevel;
    public Compass_Behaviour compass;
    public Interface_Equipped equipped;

    public GameObject lost_info;
    public GameObject won_info;



    public int shipHealth;
    public int maxHealth;
    public int crewFeed;
    public int maxFeed;

    public int gold;

    public TextMeshProUGUI coins;
    public TextMeshProUGUI health;
    public Slider health_slider;
    public GameObject text;
    public TextMeshProUGUI level_text;


    public bool isPlayerAlive = true;
    public bool isMovementLocked = false;
    public TileGenerator map_generator;
    /*public Button speed;
    public Button firepower;
    public Button endurance;
    public Button luck;
    public Button charisma;
    public Button weight;
    public Button maneuver;
    public Button morale;
    */
    public int defaultGold;
    public GameObject morale;
    public GameObject luck;
    public GameObject speed;
    public GameObject maneuver;
    public GameObject endurance;
    public GameObject firepower;
    public GameObject charisma;
    public GameObject weight;

    public GameObject animated_info;
    public TextMeshPro status_update_text;
    public SpriteRenderer status_update_image;
    // Use this for initialization

    void Awake() {
        inventory = player.GetComponent<Inventory>();
        currentLevel = 1;
        generateFirstLevel();
        gold = defaultGold;
       
    }

    void Start () {
        
        playerstats = new Stats(25,25,25,25,25,25,25,25);        
        UpdateStats();
        //assignStatsToInterface(playerstats);
        town = new Town(new List<Town.Places>());
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Cycle() {
        //speed manevuer weight morale luck charisma
        //speed, maneuver - no dmg from deep ocean
        //morale - bonus hp
        //luck - bonus gold
        //charisma - bonus item
        //inventory.LootItem(Random.Range(1+ (currentLevel - 1) * 12,13+(currentLevel-1)*12));
        //weight - chance to lose item
        if (stats_combined != null) { 
            if (stats_combined.Charisma * 0.001 > Random.Range(0f, 1f)) {
                if (player.GetComponent<PlayerBehav>().location.GetComponent<Isle_Behaviour>().field.evaluate() == 1)
                {
                  
                    GameObject spawned = Instantiate(animated_info);
                    spawned.transform.SetParent(GameObject.Find("Player").transform);
                    status_update_image = spawned.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
                    status_update_text = spawned.GetComponentInChildren<TextMeshPro>();
                    status_update_text.text = "+ 1";
                    status_update_text.color = Color.green;
                    status_update_image.sprite = Resources.Load<Sprite>("Sprites/Icons/barrel");
                    inventory.LootItem(Random.Range(1 + (currentLevel - 1) * 12, 13 + (currentLevel - 1) * 12));
                }
                Debug.Log("Prkd Charisma");
            }
            if (stats_combined.Speed * 0.001 > Random.Range(0f, 1f) || stats_combined.Maneuver * 0.01 > Random.Range(0f, 1f))
            {
                if (player.GetComponent<PlayerBehav>().location.GetComponent<Isle_Behaviour>().field.evaluate() == 1 && shipHealth > 0)
                {

                    GameObject spawned = Instantiate(animated_info);
                    spawned.transform.SetParent(GameObject.Find("Player").transform);
                    status_update_image = spawned.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
                    status_update_text = spawned.GetComponentInChildren<TextMeshPro>();
                    status_update_text.text = "+ 2";
                    status_update_text.color = Color.green;
                    status_update_image.sprite = Resources.Load<Sprite>("Sprites/Icons/health");
                    AddShipHealth(2);
                }
                Debug.Log("Prkd  Speed/Maneuver");
            }
            if (stats_combined.Morale * 0.001 > Random.Range(0f, 1f) && shipHealth>0)
            {
                if (player.GetComponent<PlayerBehav>().location.GetComponent<Isle_Behaviour>().field.evaluate() == 1)
                {

                    GameObject spawned = Instantiate(animated_info);
                    spawned.transform.SetParent(GameObject.Find("Player").transform);
                    status_update_image = spawned.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
                    status_update_text = spawned.GetComponentInChildren<TextMeshPro>();
                    int number = Random.Range(1, 10);
                    status_update_text.text = "+ "+number;
                    status_update_text.color = Color.green;
                    status_update_image.sprite = Resources.Load<Sprite>("Sprites/Icons/health");
                    AddShipHealth(number);
                }
                Debug.Log("Prkd  Morale");
            }
            if (stats_combined.Luck * 0.001 > Random.Range(0f, 1f)) {
                if (player.GetComponent<PlayerBehav>().location.GetComponent<Isle_Behaviour>().field.evaluate() == 1)
                {

                    GameObject spawned = Instantiate(animated_info);
                    spawned.transform.SetParent(GameObject.Find("Player").transform);
                    status_update_image = spawned.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
                    status_update_text = spawned.GetComponentInChildren<TextMeshPro>();
                    int number = Random.Range(1, 4);
                    status_update_text.text = "+ " + number;
                    status_update_text.color = Color.green;
                    status_update_image.sprite = Resources.Load<Sprite>("Sprites/Icons/coins");
                    AddGold(number);
                }
                Debug.Log("Prkd  Luck");
            }
            if (stats_combined.Weight * 0.001 > Random.Range(0f, 1f))
            {
                if (player.GetComponent<PlayerBehav>().location.GetComponent<Isle_Behaviour>().field.evaluate() == 1)
                {

                    GameObject spawned = Instantiate(animated_info);
                    spawned.transform.SetParent(GameObject.Find("Player").transform);
                    status_update_image = spawned.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
                    status_update_text = spawned.GetComponentInChildren<TextMeshPro>();
                    status_update_text.text = "- 1";
                    status_update_text.color = Color.red;
                    status_update_image.sprite = Resources.Load<Sprite>("Sprites/Icons/barrel");
                    inventory.DropRandom();
                }
                Debug.Log("Prkd  Weight");
            }
        }
        map_generator.Cycle();
        compass.Cycle();
    }

    



    public void UpdateList(Stats playerstats) {
        stats_array = new List<double>() { playerstats.Speed, playerstats.Firepower, playerstats.Endurance, playerstats.Luck, playerstats.Charisma, playerstats.Weight, playerstats.Maneuver, playerstats.Morale, };

    }

    public List<double> GetStatlist() {
        return stats_array;
    }

    public void ChallengePlayer(Enemy_Behaviour enemy) {
        int inc_damage = enemy.damage;
        int given_damage = (int) playerstats.Firepower / 5;
        player.GetComponent<PlayerBehav>().RecieveDamage(-(inc_damage - (int)playerstats.Endurance / 5));
        enemy.RecieveDamage(given_damage);
    }
    public void Attack(Enemy_Behaviour enemy) {
        int given_damage = (int)playerstats.Firepower / 5;
        enemy.RecieveDamage(given_damage);
    }


    public void TakeDamage(float ammount) {
        shipHealth += Mathf.RoundToInt(ammount);
        assignStatsToInterface(stats_combined);
        if (shipHealth <= 0)
        {
            isPlayerAlive = false;
            gameLost();
        }
    }

    public void ImproveStats(Stats improve) {
        if (gold > 0) {
            gold--;
            playerstats += improve;
            stats_combined += improve;
            assignStatsToInterface(stats_combined);
            UpdateList(stats_combined);
        }
    }

    public void assignStatsToInterface(Stats playerstats) {
        if (won_info.active && currentLevel < 5)
            won_info.SetActive(false);
        if (coins != null)
            coins.text = gold.ToString();
        if (level_text != null)
            level_text.text = "Poziom " +currentLevel.ToString();
        if (health != null)
            health.text = shipHealth + "/" + maxHealth;
        if (shipHealth > 0 && lost_info.active)
            lost_info.SetActive(false);
        if (health_slider != null)
            health_slider.value = shipHealth;
        if (text != null)
          text.GetComponent<TextMeshProUGUI>().text = "SPD " + playerstats.Speed + "    FRP " + playerstats.Firepower + "   END" + playerstats.Endurance + "  LCK " + playerstats.Luck + "\nCHAR " + playerstats.Charisma + "    WGH " + playerstats.Weight + "  MANR " + playerstats.Maneuver + "   MRL "  + playerstats.Morale;
        if(speed!=null)
            speed.GetComponent<TextMeshProUGUI>().text = playerstats.Speed.ToString();
        if (firepower != null)
            firepower.GetComponent<TextMeshProUGUI>().text = playerstats.Firepower.ToString();
        if (endurance != null)
            endurance.GetComponent<TextMeshProUGUI>().text = playerstats.Endurance.ToString();
        if (luck != null)
            luck.GetComponent<TextMeshProUGUI>().text = playerstats.Luck.ToString();
        if (charisma != null)
            charisma.GetComponent<TextMeshProUGUI>().text = playerstats.Charisma.ToString();
        if (weight != null)
            weight.GetComponent<TextMeshProUGUI>().text = playerstats.Weight.ToString();
        if (maneuver != null)
            maneuver.GetComponent<TextMeshProUGUI>().text = playerstats.Maneuver.ToString();
        if (morale != null)
            morale.GetComponent<TextMeshProUGUI>().text = playerstats.Morale.ToString();
    }
    public void AddShipHealth(int ammount) {
        if ((shipHealth + ammount) > maxHealth)
            shipHealth = maxHealth;
        else
            shipHealth +=ammount;

        if (shipHealth <= 0)
        {
            isPlayerAlive = false;
            gameLost();
        }
        assignStatsToInterface(stats_combined);
    }

    public void SetDefaultStats() {
        playerstats = new Stats(25, 25, 25, 25, 25, 25, 25, 25);
        gold = 0;
        currentLevel = 1;
        shipHealth = maxHealth;
        isPlayerAlive = true;
        isMovementLocked = false;

    }


    public void AddGold(int ammount) {
        gold += ammount;
        if (gold < 0)
            gold = 0;
        assignStatsToInterface(stats_combined);
    }

    public void UpdateStats(Stats equipment) {
        stats_combined = equipment + playerstats;
        
        assignStatsToInterface(stats_combined);
        UpdateList(stats_combined);
    }
    public void UpdateStats()
    {
        stats_combined = playerstats;
        assignStatsToInterface(stats_combined);
        UpdateList(stats_combined);
    }
    public void ReceivePenalty(Penalty penalty) {
        string name = penalty.Name;
        int ammount = penalty.Ammount;

        if (name.Equals("gold")) {
            AddGold(-ammount);
            Debug.Log("wypadł gold");
        }
        if (name.Equals("dur")) {
            AddShipHealth(-ammount);
            Debug.Log("wypadł health");
        }
        if (name.Equals("inventory")){
            inventory.DropRandom();
            Debug.Log("wypadł item");
        }

    }
    public void generateFirstLevel() {
        map_generator.InitiateAndGenerate();
        
    }

    public void loadNextLevel() {
        if (currentLevel < 5) {
            currentLevel += 1;
            map_generator.DeleteMap();
            map_generator.ChangeSettings((int)(map_generator.map_Width*1.3), (int)(map_generator.map_Height*1.3),(int)(map_generator.goal_distance*1.3),map_generator.octaves,map_generator.persistance,map_generator.lacunarity,map_generator.seed,map_generator.offset,map_generator.minIslandProximity,map_generator.fiveFieldsNeighbours,map_generator.noiseScale,map_generator.islandMarker);
            generateNewLevel();
            
        }
        else
            gameFinish();
    }

    public void generateNewLevel() {       
        map_generator.InitiateAndGenerate();
        assignStatsToInterface(stats_combined);
       // UpdateStats();
    }

    public void gameFinish(){
        won_info.SetActive(true);
        isMovementLocked = true;
    }

    public void gameLost() {
        lost_info.SetActive(true);
    }


    public void RestartGame() {
        map_generator.DeleteMap();
        SetDefaultStats();
        inventory.DropAllItems();
        equipped.RemoveAllItems();
        map_generator.UseDefaults();        
        map_generator.InitiateAndGenerate();
        gold = defaultGold;
        UpdateStats();
        inventory.InitiateRandomItems();

    }




    public void ReceivePrize(Prize prize) {
        Item item = prize.Item;
        string name = prize.Name;
        int quantity = prize.Quantity;
        int ammount = prize.Ammount;

        if (prize.Item != null)
            for (int i = 0; i < prize.Quantity; i++)
            {
                inventory.LootItem(Random.Range(1+ (currentLevel - 1) * 12,13+(currentLevel-1)*12));
                //Debug.Log("Otrzymano item");
            }

        else if (prize.Name.Equals("gold"))
            AddGold(ammount);
        else if (prize.Name.Equals("dur"))
            AddShipHealth(ammount);

    }
}
