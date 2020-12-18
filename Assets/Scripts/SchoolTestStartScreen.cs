using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SchoolTestStartScreen : MonoBehaviour {
    public AppData course;
    public Text Title;
    public Text BtnText;
    public Text BodyTxt;
    public GameObject stats;
    public AppData player;

    public Button NextBtn;

    public GameObject GamePlay;
    public GameObject QuestionScreen;
    public GameObject backScreen;
    public GameObject DegreebackScreen;

    int ap, money;

    public GameObject NotEnoughInstructionPanel;

    // Start is called before the first frame update
    private void OnEnable() {
        NotEnoughInstructionPanel.SetActive(false);
        BodyTxt.text = "You have " + course.CurrentPlayer.RemainingActionPoints + " action points.\n\nYou have to pass\nthis test to\ngraduate.";

        if (player.CurrentPlayer.IsPolySelected) {
            BtnText.text = " Start\n-$500\n-2 AP";
            Title.text = "Diploma in " + course.CurrentPlayer.Course;
            ap = 2;
            money = 500;
            //player.CurrentPlayer.IsPolySelected = false;
        } else {
            if (player.CurrentPlayer.edu == "Null") {
                Title.text = "Primary School";
                BtnText.text = " Start\n-1 AP";
                ap = 1;
                money = 0;
            } 
            //else if (player.CurrentPlayer.edu == "Poly") {
            //    BtnText.text = " Start\n-$1000\n-3 AP";
            //    Title.text = "Bachelor's in " + course.CurrentPlayer.Course;
            //    ap = 3;
            //    money = 1000;
            //} 
            else if (player.Degree == "phd" /*|| player.CurrentPlayer.edu == "Master"*/) {
                BtnText.text = " Start\n-$3,000\n-5 AP";
                Title.text = "PhD in " + course.CurrentPlayer.Course;
                ap = 5;
                money = 3000;
            } else if (player.Degree == "mas" /*|| player.CurrentPlayer.edu == "Bachelor"*/) {
                BtnText.text = " Start\n-$2,000\n-4 AP";
                Title.text = "Master's in " + course.CurrentPlayer.Course;
                ap = 4;
                money = 2000;
            } else if (player.Degree == "bac" /*|| player.CurrentPlayer.edu == "Junior College"*/) {
                BtnText.text = " Start\n-$1,000\n-3 AP";
                Title.text = "Bachelor's in " + course.CurrentPlayer.Course;
                ap = 3;
                money = 1000;
            } else if (player.CurrentPlayer.edu == "Secondary") {
                BtnText.text = " Start\n-2 AP";
                Title.text = "Junior College";
                ap = 2;
                money = 0;
            } else if (player.CurrentPlayer.edu == "Primary") {
                BtnText.text = " Start\n-1 AP";
                Title.text = "Secondary School";
                ap = 1;
                money = 0;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        //OnEnable();
        if (course.CurrentPlayer.RemainingActionPoints < ap || course.CurrentPlayer.Bank < money) {
            NextBtn.interactable = false;
            NotEnoughInstructionPanel.SetActive(true);
            BodyTxt.gameObject.SetActive(false);
        } else {
            BodyTxt.gameObject.SetActive(true);
            NextBtn.interactable = true;
            NotEnoughInstructionPanel.SetActive(false);
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
        if (player.CurrentPlayer.edu == "Null") {
            course.CurrentPlayer.RemainingActionPoints -= ap;
            course.CurrentPlayer.Bank -= money;
            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        } else if (player.CurrentPlayer.edu == "Primary") {
            course.CurrentPlayer.RemainingActionPoints -= ap;
            course.CurrentPlayer.Bank -= money;
            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        } else if (player.CurrentPlayer.edu == "Secondary") {
            course.CurrentPlayer.RemainingActionPoints -= ap;
            course.CurrentPlayer.Bank -= money;
            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        } else if (player.CurrentPlayer.edu == "Junior College") {
            course.CurrentPlayer.RemainingActionPoints -= ap;
            course.CurrentPlayer.Bank -= money;
            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        } else if (player.CurrentPlayer.edu == "Poly") {
            course.CurrentPlayer.RemainingActionPoints -= ap;
            course.CurrentPlayer.Bank -= money;
            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        } else if (player.CurrentPlayer.edu == "Bachelor") {
            course.CurrentPlayer.RemainingActionPoints -= ap;
            course.CurrentPlayer.Bank -= money;
            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        } else if (player.CurrentPlayer.edu == "Master") {
            course.CurrentPlayer.RemainingActionPoints -= ap;
            course.CurrentPlayer.Bank -= money;
            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        } else if (player.CurrentPlayer.edu == "PhD") {
            course.CurrentPlayer.RemainingActionPoints -= ap;
            course.CurrentPlayer.Bank -= money;
            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        }
    }
    public void onClickBackBtn() {
        if(course.Degree=="pol"|| course.Degree == "bac"|| course.Degree == "mas"|| course.Degree == "phd") {
            this.gameObject.SetActive(false);
            DegreebackScreen.SetActive(true);
        } else {
            this.gameObject.SetActive(false);
            backScreen.SetActive(true);
        }
    }
}
