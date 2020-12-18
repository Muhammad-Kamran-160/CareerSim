using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item2 : MonoBehaviour {
    public Text Title;
    public Text Desc;
    public Button Btn;
    public bool isSelected;

    private void LateUpdate() {
        if (Btn != null) {
            ColorBlock c = Btn.colors;
            c.highlightedColor = c.normalColor;
            Btn.colors = c;
        }
    }

}
