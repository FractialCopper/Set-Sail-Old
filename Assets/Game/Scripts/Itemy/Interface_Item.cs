using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Interface_Item : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    // Start is called before the first frame update
    public Item item;
    private Image image;
    private Interface_Item helditem;
    public GameObject canvas;
    public Interface_Equipped equipment;
   

    void Awake() {

        canvas = GameObject.Find("Canvas");
        image = GetComponentInChildren<Image>();
        equipment = GameObject.Find("Equipped_Panel").GetComponent<Interface_Equipped>();
        UpdateInterface(null);
        helditem = GameObject.Find("MovedItem").GetComponent<Interface_Item>();
        
    }

    public Stats GetItemStats() {
        if (item != null)
            return item.Stats;
        else
            return new Stats(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
    }

    public void UpdateInterface(Item item) {
        this.item = item;
        if (this.item != null)
        {
            image.color = Color.white;
            image.sprite = this.item.image;
        }
        else
           image.color = Color.clear;
       
    }

    /*public void OnPointerClick(PointerEventData eventData)
    {
    
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("drag_start");
        if (this.item != null)
        {
            if (helditem.item != null)
            {
                Item duplicate = new Item(helditem.item);
                helditem.UpdateInterface(this.item);
                UpdateInterface(duplicate);
            }
            else
            {
                helditem.UpdateInterface(this.item);
                UpdateInterface(null);
            }
        }
        helditem.GetComponent<Description>().ChangeDescription();
        /*else
          if (helditem.item != null)
        {
            UpdateInterface(helditem.item);
            helditem.UpdateInterface(null);
        }*/
     
    }
    public void OnTarget(Interface_Item from) {
        if (this.item != null)
        {
            if (helditem.item != null )
            {
                Debug.Log("On target1");
                Item duplicate = new Item(helditem.item);
                from.UpdateInterface(this.item);
                UpdateInterface(duplicate);
                helditem.UpdateInterface(null);
            }
            
            /*else
            {
                helditem.UpdateInterface(this.item);
                UpdateInterface(null);
            }*/
        }
        else
        {
            Debug.Log("On target");
            if (helditem.item != null)
            {
                from.UpdateInterface(this.item);
                UpdateInterface(helditem.item);
                helditem.UpdateInterface(null);
            }          
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        /*if (this.item != null)
        {
            if (helditem.item != null)
            {
                Item duplicate = new Item(helditem.item);
                helditem.UpdateInterface(this.item);
                UpdateInterface(duplicate);
            }
            else
            {
                helditem.UpdateInterface(this.item);
                UpdateInterface(null);
            }
        }*/
        //else
        //Set up the new Pointer Event
        List<RaycastResult> results = canvas.GetComponent<CanvasClickCheck>().CheckRaycast();
        int index = results.FindIndex(i => i.gameObject.tag == "Slot");
        if (index != -1 && equipment.IsCapable(results[index].gameObject.name, helditem.item))
        {
            RaycastResult result = results[index];
            result.gameObject.GetComponent<Interface_Item>().OnTarget(this);
        }
        else {
            Debug.Log("drag_end");
            if (helditem.item != null)
            {
                UpdateInterface(helditem.item);
                helditem.UpdateInterface(null);
            }
        }
        if (this.item != null)
            equipment.UpdateSlot(gameObject.name, this.item);
        else
            equipment.UpdateSlot(gameObject.name, null);
        helditem.GetComponent<Description>().ClearDescription();
        /*foreach (RaycastResult result in results)
        {
            if (result.gameObject.name == "Slot 2(Clone)") { 
            
            break;
            }            
        }*/




    }
}
