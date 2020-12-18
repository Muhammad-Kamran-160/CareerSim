
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsTestPassScreen : MonoBehaviour
{
    public AppData AD;
    public GameObject Round2;

    public GameObject stats;
    public GameObject GamePlay;
    public GameObject SchoolMenu;
    public Text certifcatetext;
    public Text HeaderText;

    // Start is called before the first frame update
    private void OnEnable() {

        //if (AD.ListName == "AccontancySkills") {
        //    certifcatetext.text = AD.CurrentPlayer.Skills.Accountacy[AD.Listindex].title + " Skill increased";
        //    HeaderText.text = AD.CurrentPlayer.Skills.Accountacy[AD.Listindex].title;
        //} else if (AD.ListName == "HealthCareSkills") {
        //    certifcatetext.text = AD.CurrentPlayer.Skills.HealtCare[AD.Listindex].title + " Skill increased";
        //    HeaderText.text = AD.CurrentPlayer.Skills.HealtCare[AD.Listindex].title;
        //} else if (AD.ListName == "HR") {
        //    certifcatetext.text = AD.CurrentPlayer.Skills.HR[AD.Listindex].title + " Skill increased";
        //    HeaderText.text = AD.CurrentPlayer.Skills.HR[AD.Listindex].title;
        //} else if (AD.ListName == "IT") {
        //    certifcatetext.text = AD.CurrentPlayer.Skills.IT[AD.Listindex].title + " Skill increased";
        //    HeaderText.text = AD.CurrentPlayer.Skills.IT[AD.Listindex].title;
        //} else if (AD.ListName == "Retail") {
        //    certifcatetext.text = AD.CurrentPlayer.Skills.Retail[AD.Listindex].title + " Skill increased";
        //    HeaderText.text = AD.CurrentPlayer.Skills.Retail[AD.Listindex].title;
        //} else if (AD.ListName == "Media") {
        //    certifcatetext.text = AD.CurrentPlayer.Skills.Media[AD.Listindex].title + " Skill increased";
        //    HeaderText.text = AD.CurrentPlayer.Skills.Media[AD.Listindex].title;
        //}


        

        
    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void onClickStatsBtn() {
        this.gameObject.SetActive(false);
        stats.SetActive(true);
    }
    public void onClickGameWorldBtn() {
        this.gameObject.SetActive(false);
        GamePlay.SetActive(true);
    }
    public void onClickBackToSchoolBtn() {
        
            this.gameObject.SetActive(false);
            SchoolMenu.SetActive(true);
       
    }
}
