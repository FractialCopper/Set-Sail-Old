using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{

    public Camera_control camera;

    // Use this for initialization
    public float startingX;
    public float startingY;
    public int map_Height;
    public int map_Width;
    public int goal_distance;



    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;


    public int minIslandProximity;
    public int fiveFieldsNeighbours;

    public float noiseScale;
    public float islandMarker;
    public Isle_Behaviour[,] map_array;
    public Isle_Behaviour goal_tile;
    //public
    public float percent_factor = 0.85f;
    float tilesize = 1;
    public GameObject player;
    // public
    Tilemap tilemap;
    List<Enemy_Behaviour> enemies;
    // public
    public Compass_Behaviour compass;
    //TileType[] tiles;
    //public GameObject text;
    public GameObject shark;
    public GameObject map;
    public GameObject meduza;
    public GameObject islandType1;
    public GameObject islandType2;
    public GameObject islandType3;
    public GameObject goal;

    public int numberOfEnemies;

    

    int default_map_Height;
    int default_map_Width;
    int default_goal_distance;
    int default_octaves;
    float default_persistance;
    float default_lacunarity;
    Vector2 default_offset;
    int default_minIslandProximity;
    int default_fiveFieldsNeighbours;
    float default_noiseScale;
    float default_islandMarker;

    public void Start() {
        // InitiateAndGenerate();
        SetDefaults();
        //compass = GameObject.Find("Compass").GetComponent<Compass_Behaviour>();
    }

    public void SetDefaults() {
        default_map_Height = map_Height;
        default_map_Width = map_Width;
        default_goal_distance = goal_distance;
        default_octaves = octaves;
        default_persistance = persistance;
        default_lacunarity = lacunarity;
        default_offset = offset;
        default_minIslandProximity = minIslandProximity;
        default_fiveFieldsNeighbours = fiveFieldsNeighbours;
        default_noiseScale = noiseScale;
        default_islandMarker = islandMarker;
    }

    public void UseDefaults() {
        map_Height = default_map_Height;
        map_Width = default_map_Width;
        goal_distance = default_goal_distance;
        octaves = default_octaves;
        persistance = default_persistance;
        lacunarity = default_lacunarity;
        offset = default_offset;
        minIslandProximity = default_minIslandProximity;
        fiveFieldsNeighbours = default_fiveFieldsNeighbours;
        noiseScale = default_noiseScale;
        islandMarker = default_islandMarker;
        numberOfEnemies = map_Height * map_Width / 25;

    }

    public void ChangeSettings(int map_Width, int map_Height, int goal_distance, int octaves, float persistance, float lacunarity, int seed, Vector2 offset, int minIslandProximity, int fiveFieldsNeighbours, float noiseScale, float islandMarker) {
        this.map_Width = map_Width;
        this.map_Height = map_Height;
        this.goal_distance = goal_distance;
        this.octaves = octaves;
        this.persistance = persistance;
        this.lacunarity = lacunarity;
        this.seed =Random.Range(-100000,10000);
        this.offset = offset;
        this.minIslandProximity = minIslandProximity;
        this.fiveFieldsNeighbours = fiveFieldsNeighbours;
        this.noiseScale = noiseScale;
        this.islandMarker = islandMarker;
        numberOfEnemies = map_Height * map_Width / 25;
    }

    public void InitiateAndGenerate()
    {
        map_array = new Isle_Behaviour[map_Width, map_Height];
        startingX = 10f;
        startingY = 10f;
        seed = Random.Range(-100000, 10000); 
        GenerateMap(startingX, startingY);
        enemies = new List<Enemy_Behaviour>();
        numberOfEnemies = map_Height * map_Width /25;
        player.GetComponent<PlayerBehav>().onLocationChange(GetUnoccupiedField().gameObject);        
        setGoal(findFieldWithMinimalDistanceFromPlayer(goal_distance));
        compass.Cycle();
        checkNeighbours();
        camera.SetBoundaries(startingX + 4.7f, startingX + map_Width - 4.6f, startingY - map_Width + 3.6f, startingY - 1.6f);
        CreateEnemy(shark);
        //Debug.Log(goal_tile.field.x + " " + goal_tile.field.y);
    }

    public void CreateEnemy(GameObject enemy) {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject instantiated = Instantiate(enemy);
            instantiated.GetComponent<Enemy_Behaviour>().Initiate(GetUnnocupiedFieldForEnemy());
            enemies.Add(instantiated.GetComponent<Enemy_Behaviour>());
        }        
       
    }


    public Isle_Behaviour GetUnnocupiedFieldForEnemy() {
        Isle_Behaviour result;
        result = map_array[Random.Range(0, map_Width), Random.Range(0, map_Height)];
        if (result.field.evaluate() == 1 && !result.gameObject.GetComponent<Enemy_Container>().isOccupated && result.isPassable &&  result != player.GetComponent<PlayerBehav>().location.GetComponent<Isle_Behaviour>())
            return result;
        else
            return GetUnnocupiedFieldForEnemy();
    }

    public void Cycle() {
        foreach (Enemy_Behaviour enemy in enemies)
        {
            if(enemy!=null)
                enemy.Cycle();
        }
    }

    public void GenerateMap(float x, float y)
    {
        float firstObjectX = x + tilesize / 2f;
        float firstObjectY = y + tilesize / 2f;
        float[,] noiseMap = NormalizeNoise(NoiseGeneration.generateNoiseMap(map_Height, map_Width, noiseScale, seed, octaves, persistance, lacunarity, offset), minIslandProximity, fiveFieldsNeighbours);
        Vector3 startingPoint = new Vector3(firstObjectX, firstObjectY, 0);
        GameObject temp = null;

        for (int i = 0; i < map_Width; i++)
        {
            for (int j = 0; j < map_Height; j++)
            {
                temp = null;
                if (noiseMap[i, j] >= islandMarker)
                {
                    temp = Instantiate(islandType1);


                    temp.transform.position = new Vector3(startingPoint.x + tilesize * i, startingPoint.y - tilesize * j, 0);
                    //ameObject island = Instantiate(meduza);
                    // meduza.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y, temp.transform.position.z-0.6f);
                    temp.GetComponent<Isle_Behaviour>().field = new Isle(i, j, 10);
                    temp.GetComponent<Isle_Behaviour>().tevent = new TriggeredEvent("Na wyspie znajduje się pare rozbitków chetnych do dołączenia. Więzieni są jednak przez tubylców. Czy im pomożesz?", "Tak", "Nie", new Penalty(), new Prize());
                }
                else
                {
                    if (noiseMap[i, j] >= islandMarker * percent_factor)
                    {
                        temp = Instantiate(islandType2);
                        temp.transform.position = new Vector3(startingPoint.x + tilesize * i, startingPoint.y - tilesize * j, 0);
                        temp.GetComponent<Isle_Behaviour>().field = new Water(i, j, false);
                    }
                    else
                    {
                        if (noiseMap[i, j] < islandMarker * percent_factor)
                        {
                            temp = Instantiate(islandType3);
                            //, new Vector3(startingPoint.x + tilesize * i, startingPoint.y - tilesize * j, 0), Quaternion.identity
                            temp.transform.position = new Vector3(startingPoint.x + tilesize * i, startingPoint.y - tilesize * j, 0);
                            temp.GetComponent<Isle_Behaviour>().field = new Water(i, j, true);
                            if (noiseMap[i, j] < (islandMarker * percent_factor) / 4)
                            {
                                temp.transform.GetChild(1).gameObject.SetActive(true);
                                temp.GetComponent<Isle_Behaviour>().isPassable = false;

                            }

                        }
                    }
                }
                temp.transform.parent = map.transform;
                //temp.GetComponent<Isle_Behaviour>().field = new Water(i, j, true);
                map_array[i, j] = temp.GetComponent<Isle_Behaviour>();

                
            }
        }
        
    }

    public Isle_Behaviour GetUnoccupiedField() {
        Isle_Behaviour isle = map_array[Random.Range(0, map_Width), Random.Range(0, map_Height)];
        if (isle.isPassable && isle.field.evaluate() != 2 && isle.field.evaluate() != 10)
            return isle;
        else
            return GetUnoccupiedField();

    }

    public void DeleteMap() {

        for (int i = 0; i < map_Width; i++) {
            for (int j = 0; j < map_Height; j++) {
                // Debug.Log(i + " " + j);
                map_array[i, j].gameObject.SetActive(false);
                map_array[i, j] = null;
            }
        }
        goal_tile = null;
        foreach (Enemy_Behaviour enemy in enemies)
            if (enemy != null)
                Destroy(enemy.gameObject);
        enemies.Clear();
    }
    public Isle_Behaviour FindFieldOfXandY(int x, int y) {
        //Debug.Log(x + " Out of bounds??   " + y);
        if (x >= 0 && y >= 0)
            return map_array[x, y];
        else
            throw new System.Exception("Poza skalą");
    } 

    public void setProperTextures()
    {



    }

    public void setGoal(Field field) {
        int x = field.x;
        int y = field.y;
        GameObject randomTile = map_array[x, y].gameObject;
        GameObject goal_field = Instantiate(goal);
        goal_field.transform.position = randomTile.transform.position;
        randomTile.SetActive(false);
        goal_field.GetComponent<Isle_Behaviour>().field = new Goal_Behaviour(x, y);
        map_array[x, y] = goal_field.GetComponent<Isle_Behaviour>();
        goal_tile = map_array[x, y];
    }


    public Field findFieldWithMinimalDistanceFromPlayer(int distance) {
        GameObject current_field = player.GetComponent<PlayerBehav>().location;
        int base_x = current_field.GetComponent<Isle_Behaviour>().field.x;
        int base_y = current_field.GetComponent<Isle_Behaviour>().field.y;
        int x;
        int y;
        for (int i = 0; i < 100; i++) {
            x = Random.Range(0, map_Width);
            y = Random.Range(0, map_Height);
            if (Mathf.Sqrt(Mathf.Pow(base_x - x, 2) + Mathf.Pow(base_y - y, 2)) > distance)
                return map_array[x, y].field;
        }
        
       /* x = Random.Range(0, map_Width);
        y = Random.Range(0, map_Height);
        if (x != base_x || y != base_y)
            return map_array[x, y].field;
        else*/
        return findFieldWithMinimalDistanceFromPlayer(distance-1);
    }
    

    public float[,] NormalizeNoise(float[,] map, int minIslandProximity,int fiveFieldsNeighbours) {
        for (int i = 0; i < map_Height; i++) {
            for (int j = 0; j < map_Width; j++) {
                if (map[j, i] >= islandMarker)
                {
                    map = CleanseNeighbourhood(map, minIslandProximity, j,i);
                    //Debug.Log("entered");
                }
            }
        }
        return map;
      }

    public void checkNeighbours() {

        bool[] result = (deepWaterNeighbours(map_array[0, 0]));
        for (int i = 0; i < result.Length; i++) {
           // Debug.Log(result[i]);
        }
    }


    public bool[] deepWaterNeighbours(Isle_Behaviour isle) {
        bool[] neighbours = new bool[4];

        bool left = true;
        bool right = true;
        bool top = true;
        bool down = true;
             

        int x = isle.field.x;
        int y = isle.field.y;
        if (x - 1 < 0 || map_array[x - 1, y].field.evaluate() != 1)
            left = false;
        if (x + 1 > map_Width-1 || map_array[x + 1, y].field.evaluate() != 1)
            right = false;
        if (y - 1 < 0 || map_array[x, y-1].field.evaluate() != 1)
            down = false;
        if (y + 1 > map_Height - 1 || map_array[x, y+1].field.evaluate() != 1)
            top = false;
        neighbours[0] = left;
        neighbours[1] = right;
        neighbours[2] = down;
        neighbours[3] = top;

        return neighbours;
    }


    public float[,] CleanseNeighbourhood(float[,] map_temp, int minIslandProximity,int x, int y) {
       
        for (int i = 0; i < minIslandProximity*2; i++)
        {
            for (int j = 0; j < minIslandProximity*2; j++)
            {
                if ((j != minIslandProximity || i != minIslandProximity) && x + minIslandProximity - j < map_Width && y +minIslandProximity - i < map_Height && x + minIslandProximity - j >= 0  && y + minIslandProximity - i >= 0)
                {
                    //Debug.Log("initiated");
                    if (map_temp[x + minIslandProximity - j, y + minIslandProximity - i] >= islandMarker)
                    {
                        map_temp[x + minIslandProximity - j, y + minIslandProximity - i] = map_temp[x + minIslandProximity - j, y + minIslandProximity - i] * (percent_factor*0.90f);
                       // Debug.Log("modified");
                    }
                }
            }
        }
        return map_temp;
    }


 
    
}
// do redukcji odległości wysp, nie usuwa po ukosie
/*for (int i = 0; i < minIslandProximity; i++) {
           for (int j = 0; j < minIslandProximity; j++)
           {
               if ((j != 0 || i != 0 ) &&  x + j <map_Width && y + i <map_Height ) {
                   Debug.Log("initiated");
                   if (map_temp[x + j,y + i] >= islandMarker)
                   {
                       map_temp[x+j, y + i] = map_temp[x+j,y+i] / 2f;
                       Debug.Log("modified");
                   }
               }
           }
       }
       */
