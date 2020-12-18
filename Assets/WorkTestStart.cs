using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkTestStart: MonoBehaviour
{

    public AppData AD;
    public DataBase db;
    public GameObject stats;


    public Text BodyTxt;
    public GameObject GamePlay;
    public GameObject QuestionScreen;
    public GameObject backScreen;

    public Button NextBtn;



    private void OnEnable()
    {
        AD.MyFinalJob.FieldName = AD.CurrentPlayer.MyJob.FieldName;
        AD.MyFinalJob.JobTitle = AD.CurrentPlayer.MyJob.JobTitle;

        if (BodyTxt != null)
        {
            int flag = 0;
            switch (AD.feildskills)
            {
                case "Accountancy":
                    if (db.Quizes_AC.Count == 0) flag = 1;
                    break;
                case "HC":
                    if (db.Quizes_HC.Count == 0) flag = 1;
                    break;
                case "HR":
                    if (db.Quizes_HR.Count == 0) flag = 1;
                    break;
                case "IT":
                    if (db.Quizes_IT.Count == 0) flag = 1;
                    break;
                case "Retail":
                    if (db.Quizes_RE.Count == 0) flag = 1;
                    break;
                case "Media":
                    if (db.Quizes_ME.Count == 0) flag = 1;
                    break;
                default:
                    flag = 0;
                    break;
            }
            if (flag == 1)
            {
                BodyTxt.text = "Use 1 AP and $100 to level up \n\n";
                for (int i = 0; i < AD.SelectThree.Count; i++)
                {
                    switch (AD.feildskills)
                    {
                        case "Accountancy":
                            BodyTxt.text += AD.CurrentPlayer.Skills.Accountacy[AD.SelectThree[i].Listindex].title + "\n";
                            break;
                        case "HC":
                            BodyTxt.text += AD.CurrentPlayer.Skills.HealtCare[AD.SelectThree[i].Listindex].title + "\n";
                            break;
                        case "HR":
                            BodyTxt.text += AD.CurrentPlayer.Skills.HR[AD.SelectThree[i].Listindex].title + "\n";
                            break;
                        case "IT":
                            BodyTxt.text += AD.CurrentPlayer.Skills.IT[AD.SelectThree[i].Listindex].title + "\n";
                            break;
                        case "Retail":
                            BodyTxt.text += AD.CurrentPlayer.Skills.Retail[AD.SelectThree[i].Listindex].title + "\n";
                            break;
                        case "Media":
                            BodyTxt.text += AD.CurrentPlayer.Skills.Media[AD.SelectThree[i].Listindex].title + "\n";
                            break;
                    }
                }
            }
            else
            {
                BodyTxt.text = "You have " + AD.CurrentPlayer.RemainingActionPoints + " action points.\n\nYou have to pass\nthis test to work.";
                Debug.Log("My JOB TITLE ON STARTING JOB ==>" + AD.MyFinalJob.JobTitle);
                Debug.Log("My JOB FINAL TITLE ON STARTING JOB => " + AD.CurrentPlayer.MyJob.JobTitle);

                Debug.Log("My JOB FIELD ON STARTING JOB ==>" + AD.MyFinalJob.FieldName);
                Debug.Log("My JOB FINAL FIELD ON STARTING JOB => " + AD.CurrentPlayer.MyJob.FieldName);
            }
        }
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (AD.CurrentPlayer.RemainingActionPoints < 1) {
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
        if (AD.IsContinueEdu) {

            int reqAmount = AD.SelectThree.Count * 100;
            int reqAP = AD.SelectThree.Count;
            if (AD.CurrentPlayer.Bank >= reqAmount && AD.CurrentPlayer.RemainingActionPoints >= reqAP) {
                AD.CurrentPlayer.RemainingActionPoints -= reqAP;
                AD.CurrentPlayer.Bank -= reqAmount;
                // continue education...
                this.gameObject.SetActive(false);
                QuestionScreen.SetActive(true);
            } else {
                // show popup;
            }

        } else {
            AD.CurrentPlayer.RemainingActionPoints -= 1;
            Debug.Log("My JOB TITLE ON STARTING JOB ==>" + AD.MyFinalJob.JobTitle);
            Debug.Log("My JOB FINAL TITLE ON STARTING JOB => " + AD.CurrentPlayer.MyJob.JobTitle);

            Debug.Log("My JOB FIELD ON STARTING JOB ==>" + AD.MyFinalJob.FieldName);
            Debug.Log("My JOB FINAL FIELD ON STARTING JOB => " + AD.CurrentPlayer.MyJob.FieldName);

            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        }
    }
    public void onRightOptionClick(Text T) {
        if (T.text[0] == 'A') {
            
        }
        if (T.text[0] == 'B') {
            
        }
        if (T.text[0] == 'C') {
            
        }
        if (T.text[0] == 'D') {
            
        }
        NextBtn.gameObject.SetActive(true);
    }
    public void onClickNextBtnInQuiz() {
        this.gameObject.SetActive(false);
        QuestionScreen.SetActive(true);
    }
    public void onClickBackBtn() {
        this.gameObject.SetActive(false);
        backScreen.SetActive(true);
    }
}
