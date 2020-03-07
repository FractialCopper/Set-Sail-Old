using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartMap : MonoBehaviour
{
    public Game game;
    public Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
    }

    public void RestartGame() {
        game.RestartGame();
    }
}


