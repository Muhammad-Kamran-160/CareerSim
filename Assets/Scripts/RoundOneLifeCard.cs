using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundOneLifeCard : MonoBehaviour
{
    public DataBase DB;
    public AppData AD;
    public GameObject SchoolLevelsScreen;
    public GameObject SchoolLevelsScreen2;
    public Button Stats;
    public Button GameWorld;
    public Text HeaderText;
    public bool check = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        HeaderText.text = "Round " + DB.RoundCounter;
        //AD.CurrentPlayer.RemainingActionPoints = 50;
        //AD.CurrentPlayer.Bank = 10000;

        switch (AD.CurrentPlayer.PerformanceCharacter[0].Title) {
            case "Curiosity":
                AD.LifeCardEveryPerRound = true;
                break;
            case "Gratitude":
                if (AD.CurrentPlayer.SatisfactionLevel < 10)
                    AD.CurrentPlayer.SatisfactionLevel += 1.0f;
                break;
            case "Grit":
                AD.CurrentPlayer.RemainingActionPoints += 2;    // we dont need bool variable for this.
                break;
            case "Optimism":
                if (AD.CurrentPlayer.SatisfactionLevel < 10)
                   AD.CurrentPlayer.SatisfactionLevel += 0.5f;
                if (DB.roundCounter == 1) {
                    AD.MyFinalJob.Salary += (int)(AD.MyFinalJob.Salary * 0.05f);
                }
                break;
            case "Self-control":
                AD.CurrentPlayer.Bank += 100;
                break;
            case "Social Intelligence":
                if (DB.roundCounter == 1) {
                    AD.MyFinalJob.Salary += (int)(AD.MyFinalJob.Salary * 0.1f);
                }
                break;
            case "Zest":
                AD.CurrentPlayer.RemainingActionPoints += 1;
                if (DB.roundCounter == 1) {
                    AD.MyFinalJob.Salary += (int)(AD.MyFinalJob.Salary * 0.05f);
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickLifeCardBtn()
    {
        AD.LC = DB.LifeCards.LCs[Random.Range(0, DB.LifeCards.LCs.Count)];
        //AD.LC = DB.LifeCards.LCs[1];
        if (AD.LifeCardEveryPerRound) {
            AD.LifeCardEveryPerRoundTemp = true;
        }
        if (AD.LC.choice == LifeCard.No || AD.LC.choice == LifeCard.Yes) {
            this.gameObject.SetActive(false);
            SchoolLevelsScreen.SetActive(true);

        } else if (AD.LC.choice == LifeCard.YesNo) {
            this.gameObject.SetActive(false);
            SchoolLevelsScreen2.SetActive(true);
        }
    }
}
