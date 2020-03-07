using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Description : MonoBehaviour
{

    GameObject description;
    GameObject descriptiontext;
    Interface_Item itemshell;
    Image image;

    public Image panel;
    public Image stat1;
    public Image stat2;
    public TextMeshProUGUI text_stat1;
    public TextMeshProUGUI text_stat2;
    Color color;
    Color color2;
    public Image description_image;
    void Awake() {
        panel = GameObject.Find("Item_Stats").GetComponent<Image>();
        description = GameObject.Find("Description");
        descriptiontext = GameObject.Find("Description_Text");
        itemshell = gameObject.GetComponent<Interface_Item>();
        image = description.GetComponent<Image>();
        color = image.color;
        color2 = panel.color;
        ClearDescription();
    }
    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void ChangeDescription()
    {
        if (itemshell.item != null) { 
            image.color = color;
            panel.color = color2;
            //descriptiontext.GetComponent<TextMeshProUGUI>().text = "Class: " + itemshell.item.item_class + "\n" + itemshell.item.name + "\n" + itemshell.item.desc;
            description_image.color = Color.white;
            description_image.sprite = Resources.Load<Sprite>("Sprites/Items/" + itemshell.item.item_class);
            int i = 0;
            foreach (double stat in itemshell.item.Stats.GetList())
            {
                if (stat > 0)
                {
                    if (text_stat1.text.Equals(""))
                    {
                        text_stat1.text = "+ " + stat;
                        stat1.sprite = Resources.Load<Sprite>("Sprites/Stats/" + i);
                        stat1.color = Color.white;
                    }
                    else
                    {
                        text_stat2.text = "+ " + stat;
                        stat2.sprite = Resources.Load<Sprite>("Sprites/Stats/" + i);
                        stat2.color = Color.white;
                    }
                }
                i++;
            }
        }
    }

    public void ClearDescription() {
        description_image.color = Color.clear;
        panel.color = Color.clear;
        image.color = Color.clear;
        stat1.color = Color.clear;
        stat2.color = Color.clear;
        text_stat1.text ="";
        text_stat2.text ="";
        descriptiontext.GetComponent<TextMeshProUGUI>().text = "";
    }
}
