using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsStartScreen : MonoBehaviour
{
    public AppData AD;
    public Text Title;
    public Text BtnText;
    public GameObject stats;
    public Text BodyTxt;


    public GameObject GamePlay;
    public GameObject QuestionScreen;
    public GameObject backScreen;

    public Button NextBtn;

    private void OnEnable() {
        BodyTxt.text = "You have " + AD.CurrentPlayer.RemainingActionPoints + " action points.\n\nYou have to pass\nthis test to\nto increase skill.";
        BtnText.text = " Start\n-$3000\n-5 AP";
        //if (AD.ListName == "AccontancySkills") {
        //    Title.text = AD.CurrentPlayer.Skills.Accountacy[AD.Listindex].title;
        //}else if(AD.ListName == "HealthCareSkills") {
        //    Title.text = AD.CurrentPlayer.Skills.HealtCare[AD.Listindex].title;
        //} else if (AD.ListName == "HR") {
        //    Title.text = AD.CurrentPlayer.Skills.HR[AD.Listindex].title;
        //} else if (AD.ListName == "IT") {
        //    Title.text = AD.CurrentPlayer.Skills.IT[AD.Listindex].title;
        //} else if (AD.ListName == "Retail") {
        //    Title.text = AD.CurrentPlayer.Skills.Retail[AD.Listindex].title;
        //} else if (AD.ListName == "Media") {
        //    Title.text = AD.CurrentPlayer.Skills.Media[AD.Listindex].title;
        //}

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AD.CurrentPlayer.RemainingActionPoints < 5 || AD.CurrentPlayer.Bank < 3000) {
            NextBtn.interactable = false;
        } else {
            NextBtn.interactable = true;
        }
    }
    public void onClickStatsBtn() {
        this.gameObject.SetActive(false);
        stats.SetActive(true);
    }
    public void onClickGameWorldBtn() {
        this.gameObject.SetActive(false);
        GamePlay.SetActive(true);
    }
    public void onClickNextBtn() {
        AD.CurrentPlayer.RemainingActionPoints -= 5;
        AD.CurrentPlayer.Bank -= 3000;
        this.gameObject.SetActive(false);
        QuestionScreen.SetActive(true);
    }
    public void onClickBackBtn() {
        this.gameObject.SetActive(false);
        backScreen.SetActive(true);
    }
}
