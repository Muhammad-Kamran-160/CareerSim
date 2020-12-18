using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLifeCard : MonoBehaviour
{
    public DataBase DB;
    public AppData AD;

    public GameObject NoChoiceScreen;
    public GameObject ChoiceScreen;


    public void onclickTakeSecondLifeCardBtn() {
        AD.LC = DB.LifeCards.LCs[Random.Range(0, DB.LifeCards.LCs.Count)];
        //AD.LC = DB.LifeCards.LCs[5];

        if (AD.LC.choice == LifeCard.No || AD.LC.choice == LifeCard.Yes) {
            this.gameObject.SetActive(false);
            NoChoiceScreen.SetActive(true);

        } else if (AD.LC.choice == LifeCard.YesNo) {
            this.gameObject.SetActive(false);
            ChoiceScreen.SetActive(true);
        }
    }
}
