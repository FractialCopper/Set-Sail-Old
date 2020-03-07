using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour {
    public GameObject player;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            //Debug.Log("Mouse Clicked");
            if (hit.collider != null && (!EventSystem.current.IsPointerOverGameObject(-1)))
            {
                //Debug.Log(hit.collider.gameObject.name);
                //player.GetComponent<PlayerBehav>().onLocationChange(hit.collider.gameObject)
                player.GetComponent<PlayerBehav>().MoveFromTo(player.GetComponent<PlayerBehav>().location, hit.collider.gameObject) ;
            }
        }
    }
}
