using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item1 : MonoBehaviour {
    int[] name = new int[8] {5,5,5,5,5,5,5,5 };
    public AppData AD;
    public TypesOfCharacter player;
    public Text Title;
    public Text cost;
    public Button Btn;
    public int index;

    public void OnClickPlus() {
        if (AD.CurrentPlayer.ActionPoints - 50 < 0) {
            int c = int.Parse(cost.text);
            if (c + 1 <= 10) {
                c += 1;
                cost.text = c.ToString();
                name[index] = c;
                AD.CurrentPlayer.MultipleIntelligence[index].cost = name[index];
                if (AD.CurrentPlayer.ActionPoints > int.Parse(cost.text)) {
                    //Parent.MultipleIntelligence.Add(new Point(item.GetComponent<Item1>().Title.text, int.Parse(item.GetComponent<Item1>().cost.text),""));
                    AD.CurrentPlayer.ActionPoints += 1;
                    AD.CurrentPlayer.RemainingActionPoints -= 1;
                    


                }
            }
        }
    }
    public void OnClickMinus() {
        int c = int.Parse(cost.text);
        if (c - 1 >= 1) {
            c -= 1;
            cost.text = c.ToString();
            name[index] = c;
            AD.CurrentPlayer.MultipleIntelligence[index].cost = name[index];
            if (AD.CurrentPlayer.ActionPoints > int.Parse(cost.text)) {
                //Parent.MultipleIntelligence.Add(new Point(item.GetComponent<Item1>().Title.text, int.Parse(item.GetComponent<Item1>().cost.text),""));
                AD.CurrentPlayer.ActionPoints -= 1;
                AD.CurrentPlayer.RemainingActionPoints += 1;


            }
        }
    }
}
