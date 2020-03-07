using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TogglePanel : MonoBehaviour,IPointerClickHandler
{

    bool toggled = false;
    public float x_move;
    public float y_move;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!toggled)
        {
            
            transform.position = new Vector3(transform.position.x + x_move * transform.lossyScale.x, transform.position.y + y_move * transform.lossyScale.y, transform.position.z);
            toggled = !toggled;
        }
        else
        {
            transform.position = new Vector3(transform.position.x - x_move * transform.lossyScale.x, transform.position.y - y_move * transform.lossyScale.y, transform.position.z);
            toggled = !toggled;
        }

    }

 
}
