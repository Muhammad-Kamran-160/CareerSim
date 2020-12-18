using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillsTestScreen : MonoBehaviour
{
    public AppData AD;
    public Text Title;
    public Text question;
    //public Button op1Btn;
    //public Button op2Btn;
    //public Button op3Btn;
    //public Button op4Btn;
    public Button NextBtn;
    public Button Finish;
    public GameObject finalScreen;
    public GameObject test;
    public GameObject SLevels;

    private void OnEnable() {
        //if (AD.ListName == "AccontancySkills") {
        //    Title.text = AD.CurrentPlayer.Skills.Accountacy[AD.Listindex].title;
            
        //} else if (AD.ListName == "HealthCareSkills") {
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
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void OnClickNextbtn() {
        this.gameObject.SetActive(false);

        finalScreen.gameObject.SetActive(true);
        //finalScreen.gameObject.SetActive(true);
        //if (AD.ListName == "AccontancySkills") {
            
        //    AD.CurrentPlayer.Skills.Accountacy[AD.Listindex].Cost++;
        //} else if (AD.ListName == "HealthCareSkills") {
            
        //    AD.CurrentPlayer.Skills.HealtCare[AD.Listindex].Cost++;
        //} else if (AD.ListName == "HR") {
           
        //    AD.CurrentPlayer.Skills.HR[AD.Listindex].Cost++;
        //} else if (AD.ListName == "IT") {
           
        //    AD.CurrentPlayer.Skills.IT[AD.Listindex].Cost++;
        //} else if (AD.ListName == "Retail") {
           
        //    AD.CurrentPlayer.Skills.Retail[AD.Listindex].Cost++;
        //} else if (AD.ListName == "Media") {
            
        //    AD.CurrentPlayer.Skills.Media[AD.Listindex].Cost++;
        //}
    }

    public void onRightOptionClick() {
        NextBtn.GetComponent<Button>().interactable = true;
    }
}
