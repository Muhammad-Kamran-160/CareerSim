using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueWorkTest : MonoBehaviour {

    public AppData AD;

    public GameObject PassScreen;
    public GameObject FailScreen;
    public GameObject NextBtn;

    public Text QuestionText;
    public Button OP1;
    public Button OP2;
    public Button OP3;
    public Button OP4;

    public Sprite Selected, Unselected;

    public int quizIndex, th, ms, questionIndex, selectedIndex = -1;
    public Quiz Q = new Quiz();
    public List<TestDet> sawaal = new List<TestDet>();

    private void QFn(List<QuizModel> L) {
        if (L.Count <= 0) {
            Debug.Log("RIGHT - Quiz Length Received: " + L.Count);
            PassScreen.SetActive(true);
            this.gameObject.SetActive(false);
            return;
        }
        else
        {
            Debug.Log("WRONG - Quiz Length Received: " + L.Count);
        }
        quizIndex = Random.Range(0, L.Count);
        Q = new Quiz();
        for (int i = 0; i < L[quizIndex].questions.Length; i++) {
            int rai = -1;
            for (int j = 0; j < L[quizIndex].questions[i].options.Length; j++) {
                if (L[quizIndex].questions[i].options[j].isAnswer) {
                    rai = j;
                    break;
                }
            }
            string[] ops = new string[L[quizIndex].questions[i].options.Length];
            for (int j = 0; j < L[quizIndex].questions[i].options.Length; j++) {
                ops[j] = L[quizIndex].questions[i].options[j].name;
            }
            TestDet td = new TestDet(L[quizIndex].questions[i].name, ops, rai);
            Q.sawaal.Add(td);
            th = Q.Threshold = L[quizIndex].questions.Length;
        }
    }
    private void OnEnable() {

        AD.MyFinalJob.FieldName = AD.CurrentPlayer.MyJob.FieldName;
        AD.MyFinalJob.JobTitle = AD.CurrentPlayer.MyJob.JobTitle;

        NextBtn.GetComponentInChildren<Text>().text = "Next";
        quizIndex = th = ms = questionIndex = 0;
        sawaal = new List<TestDet>();
        DataBase db = GameObject.FindObjectOfType<DataBase>();
        NextBtn.GetComponent<Button>().interactable = false;
        string jobTitle = AD.MyFinalJob.JobTitle;
        Debug.Log("My JOB TITLE ON STARTING JOB ==>" + AD.MyFinalJob.JobTitle);
        Debug.Log("My JOB FINAL TITLE ON STARTING JOB => " + AD.CurrentPlayer.MyJob.JobTitle);

        Debug.Log("My JOB FIELD ON STARTING JOB ==>" + AD.MyFinalJob.FieldName);
        Debug.Log("My JOB FINAL FIELD ON STARTING JOB => " + AD.CurrentPlayer.MyJob.FieldName);
        switch (jobTitle) {
            case "Chief Financial Officer":
                QFn(db.Quizes_Chief_Financial_Officer);
                break;
            case "Management Accounting - Accounting Executive":
                QFn(db.Quizes_Management_Accounting_Accounting_Executive);
                break;
            case "Management Accounting - Financial Planning and Analysis Manager":
                QFn(db.Quizes_Management_Accounting_Financial_Planning_and_Analysis_Manager);
                break;
            case "Management Accounting - Business Controller":
                QFn(db.Quizes_Management_Accounting_Business_Controller);
                break;
            case "Financial Accounting - Accounts Executive":
                QFn(db.Quizes_Financial_Accounting_Accounts_Executive);
                break;
            case "Financial Accounting - Finance Manager":
                QFn(db.Quizes_Financial_Accounting_Finance_Manager);
                break;
            case "Financial Accounting - Financial Controller":
                QFn(db.Quizes_Financial_Accounting_Financial_Controller);
                break;
            case "Senior Principal Physiotherapy Researcher":
                QFn(db.Quizes_Senior_Principal_Physiotherapy_Researcher);
                break;
            case "Senior Principal Physiotherapist (Clinical)":
                QFn(db.Quizes_Senior_Principal_Physiotherapist_Clinical);
                break;
            case "Senior Principal Physiotherapy Educator":
                QFn(db.Quizes_Senior_Principal_Physiotherapy_Educator);
                break;
            case "Principal Physiotherapy Educator":
                QFn(db.Quizes_Principal_Physiotherapy_Educator);
                break;
            case "Principal Physiotherapist (Clinical)":
                QFn(db.Quizes_Principal_Physiotherapist_Clinical);
                break;
            case "Principal Physiotherapy Researcher":
                QFn(db.Quizes_Principal_Physiotherapy_Researcher);
                break;
            case "Senior Physiotherapist":
                QFn(db.Quizes_Senior_Physiotherapist);
                break;
            case "Physiotherapist":
                QFn(db.Quizes_Physiotherapist);
                break;
            case "Chief Human Resource Officer":
                QFn(db.Quizes_Chief_Human_Resource_Officer);
                break;
            case "Head, Performance & Rewards":
                QFn(db.Quizes_Head_Performance_Rewards);
                break;
            case "Manager, Performance & Rewards":
                QFn(db.Quizes_Manager_Performance_Rewards);
                break;
            case "Executive, Performance & Rewards":
                QFn(db.Quizes_Executive_Performance_Rewards);
                break;
            case "Head, Employee Experience & Relations":
                QFn(db.Quizes_Head_Employee_Experience_Relations);
                break;
            case "Manager, Employee Experience & Relations":
                QFn(db.Quizes_Manager_Employee_Experience_Relations);
                break;
            case "Executive, Employee Experience & Relations":
                QFn(db.Quizes_Executive_Employee_Experience_Relations);
                break;
            case "Head, Talent & Attraction":
                QFn(db.Quizes_Head_Talent_Attraction);
                break;
            case "Manager, Talent & Attraction":
                QFn(db.Quizes_Manager_Talent_Attraction);
                break;
            case "Executive, Talent & Attraction":
                QFn(db.Quizes_Executive_Talent_Attraction);
                break;
            case "Head of Product":
                QFn(db.Quizes_Head_of_Product);
                break;
            case "Lead UX Designer":
                QFn(db.Quizes_Lead_UX_Designer);
                break;
            case "Senior UX Designer":
                QFn(db.Quizes_Senior_UX_Designer);
                break;
            case "UX Designer":
                QFn(db.Quizes_UX_Designer);
                break;
            case "Chief Technology Officer":
                QFn(db.Quizes_Chief_Technology_Officer);
                break;
            case "Applications Architect":
                QFn(db.Quizes_Applications_Architect);
                break;
            case "Applications Development Manager":
                QFn(db.Quizes_Applications_Development_Manager);
                break;
            case "Applications Developer":
                QFn(db.Quizes_Applications_Developer);
                break;
            case "Executive Producer - Broadcast":
                QFn(db.Quizes_Executive_Producer_Broadcast);
                break;
            case "Producer - Broadcast":
                QFn(db.Quizes_Producer_Broadcast);
                break;
            case "Assistant Producer - Broadcast":
                Debug.Log("Passing Quiz for : Assistant Producer - Broadcast");
                QFn(db.Quizes_Assistant_Producer_Broadcast);
                break;
            case "Production Assistant":
                Debug.Log("Passing Quiz for : Production Assistant");
                QFn(db.Quizes_Production_Assistant);
                break;
            case "Chief Editor":
                QFn(db.Quizes_Chief_Editor);
                break;
            case "Executive Editor":
                QFn(db.Quizes_Executive_Editor);
                break;
            case "Senior Reporter / Senior Correspondent":
                QFn(db.Quizes_Senior_Reporter_Senior_Correspondent);
                break;
            case "Reporter / Correspondent ":
                QFn(db.Quizes_Reporter_Correspondent);
                break;
            case "Chief Executive Officer / Managing Director":
                QFn(db.Quizes_Chief_Executive_Officer_Managing_Director);
                break;
            case "Brand Director":
                QFn(db.Quizes_Brand_Director);
                break;
            case "Brand Manager":
                QFn(db.Quizes_Brand_Manager);
                break;
            case "Brand Associate":
                QFn(db.Quizes_Brand_Associate);
                break;
            case "Merchandising Director":
                QFn(db.Quizes_Merchandising_Director);
                break;
            case "Merchandising Manager":
                QFn(db.Quizes_Merchandising_Manager);
                break;
            case "Visual Merchandiser":
                QFn(db.Quizes_Visual_Merchandiser);
                break;
        }
        sawaal = Q.sawaal;
        LoadQuestion();
    }
    private void OnDisable() {
        quizIndex = th = ms = questionIndex = 0;
    }
    private void LoadQuestion() {
        if (sawaal.Count <= 0) return;
        QuestionText.text = sawaal[questionIndex].Question;
        OP1.GetComponent<Button>().GetComponentInChildren<Text>().text = "A. " + sawaal[questionIndex].Option[0];
        OP2.GetComponent<Button>().GetComponentInChildren<Text>().text = "B. " + sawaal[questionIndex].Option[1];
        if (sawaal[questionIndex].Option.Length > 2) {
            OP3.GetComponent<Button>().gameObject.SetActive(true);
            OP4.GetComponent<Button>().gameObject.SetActive(true);
            OP3.GetComponent<Button>().GetComponentInChildren<Text>().text = "C. " + sawaal[questionIndex].Option[2];
            OP4.GetComponent<Button>().GetComponentInChildren<Text>().text = "D. " + sawaal[questionIndex].Option[3];
        } else {
            OP3.GetComponent<Button>().gameObject.SetActive(false);
            OP4.GetComponent<Button>().gameObject.SetActive(false);
        }
        questionIndex++;
        if (questionIndex == Q.sawaal.Count) {
            NextBtn.GetComponentInChildren<Text>().text = "Finish";
        }
    }
    public void onRightOptionClick(Text T) {
        if (T.text[0] == 'A') {
            selectedIndex = 0;
        }
        if (T.text[0] == 'B') {
            selectedIndex = 1;
        }
        if (T.text[0] == 'C') {
            selectedIndex = 2;
        }
        if (T.text[0] == 'D') {
            selectedIndex = 3;
        }
        NextBtn.gameObject.GetComponent<Button>().interactable = (true);
    }
    public void onClickOption1()
    {
        OP1.image.sprite = Selected;
        OP2.image.sprite = OP3.image.sprite = OP4.image.sprite = Unselected;
    }
    public void onClickOption2()
    {
        OP2.image.sprite = Selected;
        OP1.image.sprite = OP3.image.sprite = OP4.image.sprite = Unselected;
    }
    public void onClickOption3()
    {
        OP3.image.sprite = Selected;
        OP1.image.sprite = OP2.image.sprite = OP4.image.sprite = Unselected;
    }
    public void onClickOption4()
    {
        OP4.image.sprite = Selected;
        OP1.image.sprite = OP3.image.sprite = OP2.image.sprite = Unselected;
    }
    public void OnClickNext() {
        OP1.image.sprite = OP2.image.sprite = OP3.image.sprite = OP4.image.sprite = Unselected;
        // only if there are more qestions...
        if (questionIndex < Q.sawaal.Count) {
            if (selectedIndex == Q.sawaal[questionIndex].AnswerIndex) {
                Q.myScore++;
                ms++;
            }
            LoadQuestion();
        } else {
            if (selectedIndex == Q.sawaal[questionIndex - 1].AnswerIndex) {
                Q.myScore++;
                ms++;
            }
            if (ms >= th * 0.5f) {
                PassScreen.SetActive(true);
            } else {
                FailScreen.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
        NextBtn.GetComponent<Button>().interactable = false;
    }
}
