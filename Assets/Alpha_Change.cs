using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class Alpha_Change : MonoBehaviour
{
    bool isTransparent = false;
    public Image image;
    // Start is called before the first frame update
    public void SwitchAlpha()
    {
        Debug.Log("Switch_");
        
        if (!isTransparent)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 60);
            isTransparent = !isTransparent;
        }
        else { 
            image.color = new Color(image.color.r, image.color.g, image.color.b, 255);
            isTransparent = !isTransparent;
        }
    }

    public bool IsLocationInCorner(int x, int y) {
        if (x < 3 && y == 0)
            return true;
        return false;
    }

    public void Inform(int x , int y) {
        
        if (isTransparent && !IsLocationInCorner(x, y))
            SwitchAlpha();
        if (!isTransparent && IsLocationInCorner(x, y))
            SwitchAlpha();
    }
}
