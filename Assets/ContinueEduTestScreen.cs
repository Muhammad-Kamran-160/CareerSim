using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueEduTestScreen : MonoBehaviour {
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
            PassScreen.SetActive(true);
            this.gameObject.SetActive(false);
            return;
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

    private void OnDisable() {
        quizIndex = th = ms = questionIndex = 0;
    }
    private void OnEnable() {
        NextBtn.GetComponentInChildren<Text>().text = "Next";
        quizIndex = th = ms = questionIndex = 0;
        sawaal = new List<TestDet>();
        DataBase db = GameObject.FindObjectOfType<DataBase>();
        NextBtn.GetComponent<Button>().interactable = false;
        string selectedIndustury = AD.feildskills;
        switch (selectedIndustury) {
            case "Accountancy":
                QFn(db.Quizes_AC);
                break;
            case "HC":
                QFn(db.Quizes_HC);
                break;
            case "HR":
                QFn(db.Quizes_HR);
                break;
            case "IT":
                QFn(db.Quizes_IT);
                break;
            case "Retail":
                QFn(db.Quizes_RE);
                break;
            case "Media":
                QFn(db.Quizes_ME);
                break;
        }
        sawaal = Q.sawaal;
        LoadQuestion();
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
        Debug.Log("Called start");
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
        NextBtn.GetComponent<Button>().interactable = (true);
        Debug.Log("Called Next");
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
    public void OnClickNext()
    {
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
