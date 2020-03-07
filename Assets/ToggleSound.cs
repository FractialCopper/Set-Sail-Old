using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    public bool isDisabled = false;
    public Sprite enabled;
    public Sprite disabled;
    public Image image_to_change;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ToggleSounds);

    }

    public void ToggleSounds() {
        if (isDisabled)
        {
            isDisabled = false;
            image_to_change.sprite = enabled;
            AudioListener.pause = false;
        }
        else
        {
            isDisabled = true;
            image_to_change.sprite = disabled;
            AudioListener.pause = true;
        }

    } 
}
