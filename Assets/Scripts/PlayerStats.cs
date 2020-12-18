using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public AppData PlayerNow;
    public Text MI;
    public Text PC;
    public Text skills;
    public Text eduLevel;
    public Text careerAnchores;
    public Text values;
    public Text possessions;
    public Text bankAccount;
    public Text SatisfactionLevel;
    public GameObject nextScreen;
    public GameObject RoundWaitingScreen;
    // Start is called before the first frame update
    void Start()
    {
        MI.text = "";
        for (int i = 0; i < PlayerNow.CurrentPlayer.MultipleIntelligence.Count; i++)
        {
            MI.text += PlayerNow.CurrentPlayer.MultipleIntelligence[i].Title;
            if (i != PlayerNow.CurrentPlayer.MultipleIntelligence.Count - 1)
            {
                MI.text += ", ";
            }
        }
        PC.text = "";
        for (int i = 0; i < PlayerNow.CurrentPlayer.PerformanceCharacter.Count; i++)
        {
            PC.text += PlayerNow.CurrentPlayer.PerformanceCharacter[i].Title;
            if (i != PlayerNow.CurrentPlayer.PerformanceCharacter.Count - 1)
            {
                PC.text += ", ";
            }
        }
        careerAnchores.text = "";
        for (int i = 0; i < PlayerNow.CurrentPlayer.CareerAnchor.Count; i++)
        {
            careerAnchores.text += PlayerNow.CurrentPlayer.CareerAnchor[i].ToString();
            if (i != PlayerNow.CurrentPlayer.CareerAnchor.Count - 1)
            {
                careerAnchores.text += ", ";
            }
        }
        values.text = "";
        for (int i = 0; i < PlayerNow.CurrentPlayer.Values.Count; i++)
        {
            values.text += PlayerNow.CurrentPlayer.Values[i].ToString();
            if (i != PlayerNow.CurrentPlayer.Values.Count - 1)
            {
                values.text += ", ";
            }
        }
        Debug.Log("Action Points: " + PlayerNow.CurrentPlayer.RemainingActionPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickNextBtn()
    {
        this.gameObject.SetActive(false);
        nextScreen.SetActive(true);
    }
    public void onClickCrossBtn() {
        this.gameObject.SetActive(false);
        RoundWaitingScreen.SetActive(true);
    }
}
