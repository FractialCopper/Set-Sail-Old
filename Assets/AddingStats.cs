using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingStats : MonoBehaviour
{
    public Game game;
    public bool toggled = false;
    // Start is called before the first frame update
 
    public void TogglePanels() {
        Transform go =  gameObject.transform;
        bool state;
        if (!toggled && game.gold > 0)
            state = true;
        else
            state = false;

        for (int i = 0; i < go.childCount; i++) {
            go.GetChild(i).gameObject.SetActive(state);
        }
        toggled = !toggled;
    }

    public void AddStats(int id) {
        List<double> toAdd = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, };
        toAdd[id] = 5;
        Stats converted = new Stats(toAdd);
        game.ImproveStats(converted);
        if (game.gold <= 0)
            TogglePanels();
    }
}
