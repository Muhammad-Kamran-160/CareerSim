using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PrimaryMcqQOne : MonoBehaviour
{
    public AppData player;
    public DataBase DB;
    //public Quiz q;
    public Text title;
    public Text question;
    public Text BtnText;
    public Button op1Btn;
    public Button op2Btn;
    public Button op3Btn;
    public Button op4Btn;
    public Button NextBtn;
    public Button Finish;
    public GameObject finalScreen;
    public GameObject test;
    public GameObject SLevels;

    List<TestDet> sawaal;

    public int index = 0;
    public int questionCount = 0;
    int th = 0;
    int ms = 0;

    public Sprite Selected, Unselected;

    int quizIndex = 2;  // generate random index for the quiz...

    Quiz Q = new Quiz();

    private void QFn(List<QuizModel> L) {
        if (L.Count <= 0) {
            TestEnded();
            //switch (player.Degree) {
            //    case "pol":
            //        player.CurrentPlayer.Poly[player.CurrentPlayer.Poly.Count - 1].per = 100;
            //        break;
            //    case "bac":
            //        player.CurrentPlayer.Bach[player.CurrentPlayer.Bach.Count - 1].per = 100;
            //        break;
            //    case "mas":
            //        player.CurrentPlayer.Mast[player.CurrentPlayer.Mast.Count - 1].per = 100;
            //        break;
            //    case "phd":
            //        player.CurrentPlayer.Phd[player.CurrentPlayer.Phd.Count - 1].per = 100;
            //        break;
            //}
            return;
        }
        Debug.Log("::::::::::::::::::::::::::::::::::::::::::::::::::::quiz started::::::::::::::::::::::::::::::::::::::::::::::::::::");

        quizIndex = Random.Range(0, L.Count);
        
        Q = new Quiz();

        Debug.Log("Quiz: " + L[0].name + " L: " + L[0].questions.Length);

        for (int i = 0; i < L[quizIndex].questions.Length; i++) {
            Debug.Log("..........................................Looping...");
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
    private void TestEnded() {
        TestPassCheck();
        finalScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
    private void OnEnable() {
        op1Btn.image.sprite = op2Btn.image.sprite = op3Btn.image.sprite = op4Btn.image.sprite = Unselected;
        NextBtn.gameObject.GetComponent<Button>().interactable = (false);
        if (player.CurrentPlayer.IsPolySelected) {

            QFn(DB.QuizesPol);
            player.CurrentPlayer.CurrentQuizName = "pol";
        } else {
            //bool polyFlag = false;
            //for (int i = 0; i < player.CurrentPlayer.Poly.Count; i++) {
            //    if (player.CurrentPlayer.Poly[i].per >= 50) {
            //        polyFlag = true;
            //    }
            //}
            if (player.CurrentPlayer.Poly.Count > 0 && player.Degree == "bac") {
                player.CurrentPlayer.CurrentQuizName = "bac";
                QFn(DB.QuizesBac);
                //Debug.Log("-------------------------------------------------------------------true");
            } else {
                //Debug.Log("-------------------------------------------------------------------not true: " + (player.CurrentPlayer.Poly.Count > 0) +" && "+ player.Degree);
                switch (player.CurrentPlayer.edu) {
                    //case "pol":
                    //    QFn(DB.QuizesBac);
                    //    player.CurrentPlayer.CurrentQuizName = "bac";
                    //    break;
                    case "Null":
                        player.CurrentPlayer.CurrentQuizName = "pri";
                        QFn(DB.QuizesPri);
                        break;
                    case "Primary":
                        player.CurrentPlayer.CurrentQuizName = "sec";
                        QFn(DB.QuizesSec);
                        break;
                    case "Secondary":
                        player.CurrentPlayer.CurrentQuizName = "jun";
                        QFn(DB.QuizesJun);
                        break;
                    case "Junior College":
                        player.CurrentPlayer.CurrentQuizName = "bac";
                        QFn(DB.QuizesBac);
                        break;
                    case "Bachelor":
                        if (player.Degree == "bac") {
                            player.CurrentPlayer.CurrentQuizName = "bac";
                            QFn(DB.QuizesBac);
                        } else if (player.Degree == "mas") {
                            player.CurrentPlayer.CurrentQuizName = "mas";
                            QFn(DB.QuizesMas);
                        } else if (player.Degree == "phd") {
                            player.CurrentPlayer.CurrentQuizName = "phd";
                            QFn(DB.QuizesPhd);
                        } else {
                            player.CurrentPlayer.CurrentQuizName = "mas";
                            QFn(DB.QuizesMas);
                        }
                        break;
                    case "Master":
                        if (player.Degree == "mas") {
                            player.CurrentPlayer.CurrentQuizName = "mas";
                            QFn(DB.QuizesMas);
                        } else if (player.Degree == "bac") {
                            player.CurrentPlayer.CurrentQuizName = "bac";
                            QFn(DB.QuizesBac);
                        } else if (player.Degree == "phd") {
                            player.CurrentPlayer.CurrentQuizName = "phd";
                            QFn(DB.QuizesPhd);
                        } else {
                            player.CurrentPlayer.CurrentQuizName = "phd";
                            QFn(DB.QuizesPhd);
                        }
                        break;
                    case "PhD":
                        if (player.Degree == "mas") {
                            player.CurrentPlayer.CurrentQuizName = "mas";
                            QFn(DB.QuizesMas);
                        } else if (player.Degree == "bac") {
                            player.CurrentPlayer.CurrentQuizName = "bac";
                            QFn(DB.QuizesBac);
                        } else if (player.Degree == "phd") {
                            player.CurrentPlayer.CurrentQuizName = "phd";
                            QFn(DB.QuizesPhd);
                        }
                        break;
                }
            }
        }

        //Debug.Log("total quizzes: ==================> " + DB.Quizes.Count);

        //Debug.Log("enabled");
        
        //for (int i = 0; i < DB.Quizes[quizIndex].questions.Length; i++) {
        //    int rai = -1;
        //    for (int j = 0; j < DB.Quizes[quizIndex].questions[i].options.Length; j++) {
        //        if (DB.Quizes[quizIndex].questions[i].options[j].isAnswer) {
        //            rai = j;
        //            break;
        //        }
        //    }
        //    string[] ops = new string[DB.Quizes[quizIndex].questions[i].options.Length];
        //    for (int j = 0; j < DB.Quizes[quizIndex].questions[i].options.Length; j++) {
        //        ops[j] = DB.Quizes[quizIndex].questions[i].options[j].name;
        //    }
        //    TestDet td = new TestDet(DB.Quizes[quizIndex].questions[i].name, ops, rai);
        //    Q.sawaal.Add(td);
        //    th=Q.Threshold = DB.Quizes[quizIndex].threshold;

        //}

        if (index < Q.sawaal.Count) 
        {

            sawaal = Q.sawaal;

            //Debug.Log("question: " + sawaal[index].Question);
            question.text = sawaal[index].Question;
            op1Btn.GetComponent<Button>().GetComponentInChildren<Text>().text = "A. " + sawaal[index].Option[0];
            op2Btn.GetComponent<Button>().GetComponentInChildren<Text>().text = "B. " + sawaal[index].Option[1];

            if(sawaal[index].Option.Length > 2) {
                op3Btn.GetComponent<Button>().gameObject.SetActive(true);
                op4Btn.GetComponent<Button>().gameObject.SetActive(true);
                op3Btn.GetComponent<Button>().GetComponentInChildren<Text>().text = "C. " + sawaal[index].Option[2];
                op4Btn.GetComponent<Button>().GetComponentInChildren<Text>().text = "D. " + sawaal[index].Option[3];
            } else {
                op3Btn.GetComponent<Button>().gameObject.SetActive(false);
                op4Btn.GetComponent<Button>().gameObject.SetActive(false);
            }

            //Debug.Log("enabled: " + index);
            questionCount++;

            switch (player.CurrentPlayer.CurrentQuizName) {
                case "pri":
                    title.text = "Primary School";
                    break;
                case "sec":
                    title.text = "Secondary School";
                    break;
                case "jun":
                    title.text = "Junior College";
                    break;
                case "pol":
                    title.text = "Diploma in " + player.CurrentPlayer.Course;
                    break;
                case "bac":
                    title.text = "Bachelor's in " + player.CurrentPlayer.Course;
                    break;
                case "mas":
                    title.text = "Master's in " + player.CurrentPlayer.Course;
                    break;
                case "phd":
                    title.text = "PhD in " + player.CurrentPlayer.Course;
                    break;
            }
            /*
            //if (player.CurrentPlayer.edu == "Null") {
            //    title.text = "Primary School";

            //} else if (player.CurrentPlayer.edu == "Primary") {

            //    title.text = "Secondary School";
            //} else if (player.CurrentPlayer.edu == "Secondary") {

            //    title.text = "Junior College";
            //} else if (player.CurrentPlayer.edu == "Junior College") {

            //    title.text = "Diploma in " + player.CurrentPlayer.Course;
            //} else if (player.CurrentPlayer.edu == "Poly") {

            //    title.text = "Bachelor's in " + player.CurrentPlayer.Course;
            //} else if (player.CurrentPlayer.edu == "Bachelor") {

            //    title.text = "Master's in " + player.CurrentPlayer.Course;
            //} else if (player.CurrentPlayer.edu == "Master") {

            //    title.text = "PhD in " + player.CurrentPlayer.Course;
            //}
            //NextBtn.GetComponent<Button>().interactable = false;
            */
        } else {
            questionCount = index = 0;
            Q = new Quiz();
            
        }
        if (questionCount == th) {

            BtnText.text = "Finish";
        }
        
    }
    void Start()
    {
        //index = Random.Range(0, DB.Quizes.sawaal.Count);
        ms = 0;

        //question.text = sawaal[index].Question;
        //op1Btn.GetComponent<Button>().GetComponentInChildren<Text>().text = "A. "+ sawaal[index].Option[0];
        //op2Btn.GetComponent<Button>().GetComponentInChildren<Text>().text = "B. "+ sawaal[index].Option[1];
        //op3Btn.GetComponent<Button>().GetComponentInChildren<Text>().text = "C. "+ sawaal[index].Option[2];
        //op4Btn.GetComponent<Button>().GetComponentInChildren<Text>().text = "D. "+ sawaal[index].Option[3];
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNextbtn1() {
        if (questionCount > 0 && questionCount < Q.sawaal.Count) {
            if (selectedIndex == sawaal[index].AnswerIndex) {
                Q.myScore++;
                ms++;
            }
            index++;
            OnEnable();
        } else {
            if (selectedIndex == sawaal[index].AnswerIndex) {
                Q.myScore++;
                ms++;
            }
            TestPassCheck();
        }
    }

    public void OnClickNextbtn()
    {
        if (questionCount > 0 && questionCount < Q.sawaal.Count) {
            //Debug.Log(selectedIndex + " == " + sawaal[index].AnswerIndex+" th:"+Q.Threshold + " ms----------->: "+Q.myScore);
            if (selectedIndex == sawaal[index].AnswerIndex) {
                Q.myScore++;
                ms++;
                Debug.Log(selectedIndex + " == " + sawaal[index].AnswerIndex + " th:" + th + " ms----------->: " + ms);
                Debug.Log("myscore: " + Q.myScore);
            }
            index++;
            OnEnable();
        } else {

            if (selectedIndex == sawaal[index].AnswerIndex) {
                Q.myScore++;
                ms++;
                Debug.Log(selectedIndex + " == " + sawaal[index].AnswerIndex + " th:" + th + " ms----------->: " + ms);
                Debug.Log("myscore: " + Q.myScore);
            }

            Debug.Log(selectedIndex + " == " + sawaal[index].AnswerIndex + " th:" + th + " ms: " + ms);

            if (ms >= th) { 
                //finalScreen.gameObject.SetActive(true);
                if (player.CurrentPlayer.edu == "Null"/*player.CurrentPlayer.PrimaryScore>=0 && player.CurrentPlayer.PrimaryScore <=3*/) {
                    player.CurrentPlayer.PrimaryScore++;
                    if (player.CurrentPlayer.edu == "Null" || player.CurrentPlayer.PrimaryScore == 4) {
                        Debug.Log("advdasvsvvsfvs");
                        //SLevels.gameObject.SetActive(false);
                        player.CurrentPlayer.edu = "Primary";
                        player.counter++;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        //title.text = "Secondary School";
                        this.gameObject.SetActive(false);

                        finalScreen.gameObject.SetActive(true);
                        questionCount = 0;
                        index = 0;
                        //DB.Quizes.sawaal.Count = 0;
                    } else {
                        test.SetActive(true);
                        this.gameObject.SetActive(false);
                        Debug.Log("psc: " + player.CurrentPlayer.PrimaryScore);
                    }
                } else if (/*player.CurrentPlayer.edu=="Null" &&*/ player.CurrentPlayer.edu == "Primary" /*&& player.CurrentPlayer.SecodaryScore>=0 && player.CurrentPlayer.SecodaryScore <=3*/) {
                    player.CurrentPlayer.SecodaryScore++;

                    if (player.CurrentPlayer.edu == "Primary" || player.CurrentPlayer.SecodaryScore == 4) {
                        player.CurrentPlayer.edu = "Secondary";
                        player.counter++;//@!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        //title.text = "Junior College";
                        finalScreen.gameObject.SetActive(true);
                        this.gameObject.SetActive(false);
                    } else {
                        test.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                    player.CurrentPlayer.PrimaryClear = true;
                    Debug.Log("s-sc: " + player.CurrentPlayer.SecodaryScore);
                } else if (player.CurrentPlayer.edu == "Secondary" /*&& player.CurrentPlayer.PolyScore >= 0 */) {
                    player.CurrentPlayer.PolyScore++;
                    if (player.CurrentPlayer.edu == "Secondary" || player.CurrentPlayer.PolyScore == 1) {
                        player.CurrentPlayer.edu = "Junior College";
                        player.counter++;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        //title.text = "Polytechnic in " + player.CurrentPlayer.Course;
                        Debug.Log("1234567890" + player.CurrentPlayer.Course);
                        finalScreen.gameObject.SetActive(true);
                        this.gameObject.SetActive(false);
                        player.CurrentPlayer.SecondaryClear = true;
                    } else {
                        test.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                } else if (player.CurrentPlayer.edu == "Junior College") {
                    player.CurrentPlayer.JuniorScore++;
                    if (player.CurrentPlayer.JuniorScore == 1) {
                        //title.text = "Bachelor in Human Resources"/*+player.CurrentPlayer.Course*/;
                        player.CurrentPlayer.edu = "Poly";
                        player.counter++;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        finalScreen.gameObject.SetActive(true);
                        this.gameObject.SetActive(false);
                        player.CurrentPlayer.AccountancyClear = true;
                    } else {
                        test.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                    Debug.Log("vsdvsdvsvsv" + player.CurrentPlayer.PolyScore);
                } else if (player.CurrentPlayer.edu == "Poly") {
                    player.CurrentPlayer.BachlorScore += 5;
                    Debug.Log(player.CurrentPlayer.BachlorScore);
                    if (player.CurrentPlayer.edu == "Poly" || player.CurrentPlayer.BachlorScore == 20) {
                        //title.text = "Master in Human Resources"/*+player.CurrentPlayer.Course*/;
                        player.CurrentPlayer.edu = "Bachelor";
                        player.counter++;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        player.CurrentPlayer.BachY1Clear = true;
                        finalScreen.gameObject.SetActive(true);
                        this.gameObject.SetActive(false);
                        PointsCalculatios();
                        Debug.Log("112211122112221122112211221122 :  " + player.CurrentPlayer.Skills.Accountacy[0].Cost);
                        Debug.Log("112211122112221122112211221122 :  " + player.CurrentPlayer.Skills.Accountacy[1].Cost);
                        Debug.Log("112211122112221122112211221122 :  " + player.CurrentPlayer.Skills.Accountacy[4].Cost);

                    } else {
                        test.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                } else if (player.CurrentPlayer.edu == "Bachelor") {
                    player.CurrentPlayer.BachlorScore += 5;
                    if (player.CurrentPlayer.edu == "Bachelor" || player.CurrentPlayer.BachlorScore >= 40) {
                        //title.text = "PhD in Human Resources"/*+player.CurrentPlayer.Course*/;
                        player.CurrentPlayer.edu = "Master";
                        player.counter++;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        MasterPointsCalculatios();
                        finalScreen.gameObject.SetActive(true);
                        this.gameObject.SetActive(false);
                        player.CurrentPlayer.HRClear = true;
                    } else {
                        test.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                } else if (player.CurrentPlayer.edu == "Master") {
                    player.CurrentPlayer.BachlorScore += 5;
                    if (player.CurrentPlayer.edu == "Master" || player.CurrentPlayer.BachlorScore >= 50) {
                        //title.text = "Master";
                        player.CurrentPlayer.edu = "PhD";
                        player.counter++;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                       // PhDPointsCalculatios();
                        player.CurrentPlayer.MasterClear = true;
                        finalScreen.gameObject.SetActive(true);
                        this.gameObject.SetActive(false);
                        player.CurrentPlayer.ITClear = true;
                    } else {
                        player.CurrentPlayer.ITClear = true;
                        test.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                } else if (player.CurrentPlayer.edu == "Uni Bachlor Year 3") {
                    player.CurrentPlayer.MasterScore += 5;
                    if (player.CurrentPlayer.edu == "Uni Bachlor Year 3" || player.CurrentPlayer.MasterScore <= 50) {
                        //title.text = "PhD";
                        player.CurrentPlayer.edu = "Master";
                        player.CurrentPlayer.PhDClear = true;
                        finalScreen.gameObject.SetActive(true);
                        this.gameObject.SetActive(false);
                        player.CurrentPlayer.RetailClear = true;

                    } else {
                        test.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                } else if (player.CurrentPlayer.edu == "Master") {
                    player.CurrentPlayer.MasterScore += 5;

                    if (player.CurrentPlayer.edu == "Master" || player.CurrentPlayer.MasterScore == 20) {
                        title.text = "Junior College";
                        player.CurrentPlayer.edu = "PhD";
                        finalScreen.gameObject.SetActive(true);
                        this.gameObject.SetActive(false);
                        player.CurrentPlayer.MediaClear = true;
                    } else {
                        test.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                } else if (player.CurrentPlayer.edu == "Media") {
                    title.text = "Uni Bachlor Year 1";
                    player.CurrentPlayer.edu = "Junior College";
                    player.CurrentPlayer.juniorClgClear = true;
                } else if (player.CurrentPlayer.edu == "Junior College") {
                    title.text = "Uni Bachlor Year 2";
                    player.CurrentPlayer.edu = "Uni Bachlor Year 1";
                    player.CurrentPlayer.BachY1Clear = true;
                    //this.gameObject.SetActive(false);
                    //Certificate.SetActive(true);
                } else if (player.CurrentPlayer.edu == "Uni Bachlor Year 1") {
                    title.text = "Bachlor's year 3 Module";
                    player.CurrentPlayer.edu = "Uni Bachlor Year 2";
                    player.CurrentPlayer.BachY2Clear = true;
                } else if (player.CurrentPlayer.edu == "Uni Bachlor Year 2") {
                    title.text = "Master";
                    player.CurrentPlayer.edu = "Uni Bachlor Year 3";
                    player.CurrentPlayer.BachY3clear = true;
                } else if (player.CurrentPlayer.edu == "Uni Bachlor Year 3") {
                    title.text = "PhD";
                    player.CurrentPlayer.edu = "Master";
                    player.CurrentPlayer.MasterClear = true;
                } else if (player.CurrentPlayer.edu == "Master") {
                    player.CurrentPlayer.edu = "PhD";
                    player.CurrentPlayer.PhDClear = true;
                }
                th = 0;
                ms = 0;
            } else {
                this.gameObject.SetActive(false);
                th  = 0;
                ms = 0;
                SLevels.gameObject.SetActive(true);
                BtnText.text = "Next";
            }
            index = questionCount = 0;
            BtnText.text = "Next";
        }
    }
    
    public void TestPassCheck() {
        //Debug.Log("Function called");
        if (ms >= th * 0.5f) {
            //Debug.Log("Condition passed");
            if (player.CurrentPlayer.CurrentQuizName == "pol" || player.CurrentPlayer.edu != "Null" && player.CurrentPlayer.edu != "Primary") {
                //Debug.Log("Poly Started.");
                //player.CurrentPlayer.edu = "Poly";
                player.CurrentPlayer.CurrentQuizPercentage = ((float)ms / (float)th) * 100f;
                if (th == 0) player.CurrentPlayer.CurrentQuizPercentage = 100;
                PolyPointsCalculatios();
                //Debug.Log("Poly calculation done");
                finalScreen.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                //Debug.Log("Poly ended.");
            }
            if (player.CurrentPlayer.CurrentQuizName == "pri") {
                player.CurrentPlayer.CurrentQuizPercentage = ((float)ms / (float)th) * 100f;
                if (th == 0) player.CurrentPlayer.CurrentQuizPercentage = 100;
                player.CurrentPlayer.edu = "Primary";
                player.counter++;
                this.gameObject.SetActive(false);
                finalScreen.gameObject.SetActive(true);
                questionCount = 0;
                index = 0;
            } else if (player.CurrentPlayer.CurrentQuizName == "sec") {
                player.CurrentPlayer.CurrentQuizPercentage = ((float)ms / (float)th) * 100f;
                if (th == 0) player.CurrentPlayer.CurrentQuizPercentage = 100;
                player.CurrentPlayer.edu = "Secondary";
                player.counter += 2;
                finalScreen.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            } else if (player.CurrentPlayer.CurrentQuizName == "jun") {
                player.CurrentPlayer.CurrentQuizPercentage = ((float)ms / (float)th) * 100f;
                if (th == 0) player.CurrentPlayer.CurrentQuizPercentage = 100;
                player.CurrentPlayer.edu = "Junior College";
                player.counter++;
                finalScreen.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            } else if (player.CurrentPlayer.CurrentQuizName == "bac") {
                player.CurrentPlayer.CurrentQuizPercentage = ((float)ms / (float)th) * 100f;
                if (th == 0) player.CurrentPlayer.CurrentQuizPercentage = 100;
                player.CurrentPlayer.edu = "Bachelor";
                player.CurrentPlayer.BachelorsDone = true;
                player.counter++;
                PointsCalculatios();
                Debug.Log("Points Calculation done");
                finalScreen.gameObject.SetActive(true);
                finalScreen.gameObject.SetActive(false);
                finalScreen.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            } else if (player.CurrentPlayer.CurrentQuizName == "mas") {
                player.CurrentPlayer.CurrentQuizPercentage = ((float)ms / (float)th) * 100f;
                if (th == 0) player.CurrentPlayer.CurrentQuizPercentage = 100;
                player.CurrentPlayer.edu = "Master";
                player.CurrentPlayer.MastersDone = true;
                player.counter++;
                MasterPointsCalculatios();
                finalScreen.gameObject.SetActive(true);
                finalScreen.gameObject.SetActive(false);
                finalScreen.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            } else if (player.CurrentPlayer.CurrentQuizName == "phd") {
                player.CurrentPlayer.CurrentQuizPercentage = ((float)ms / (float)th) * 100f;
                if (th == 0) player.CurrentPlayer.CurrentQuizPercentage = 100;
                player.CurrentPlayer.edu = "PhD";
                player.CurrentPlayer.PhdDone = true;
                player.counter++;
                PhDPointsCalculatios();
                finalScreen.gameObject.SetActive(true);
                finalScreen.gameObject.SetActive(false);
                finalScreen.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
            th = 0;
            ms = 0;
        } else {
            this.gameObject.SetActive(false);
            th = 0;
            ms = 0;
            SLevels.gameObject.SetActive(true);
            BtnText.text = "Next";
            player.CurrentPlayer.CurrentQuizName = "";
        }
        index = questionCount = 0;
        BtnText.text = "Next";
    }
    
    
    int selectedIndex = -1;
    public void onRightOptionClick(Text T)
    {
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
        //int ind = -1;
        //for (ind = 0; ind < 3; ind++) ;
        //string s = "";
        //for (int i = ind; i < T.text.Length; i++) {
        //    s += T.text[i];
        //}
        ////Debug.Log(index + " <=== vhslvblvbgv " + s + " " + sawaal[index].Option[sawaal[index].AnswerIndex]);
        //if (sawaal[index].Option[sawaal[index].AnswerIndex] == s) {
        //    DB.Quizes.myScore++;
        //}
    }
    public void onClickOption1()
    {
        op1Btn.image.sprite = Selected;
        op2Btn.image.sprite = op3Btn.image.sprite = op4Btn.image.sprite = Unselected;
    }
    public void onClickOption2()
    {
        op2Btn.image.sprite = Selected;
        op1Btn.image.sprite = op3Btn.image.sprite = op4Btn.image.sprite = Unselected;
    }
    public void onClickOption3()
    {
        op3Btn.image.sprite = Selected;
        op1Btn.image.sprite = op2Btn.image.sprite = op4Btn.image.sprite = Unselected;
    }
    public void onClickOption4()
    {
        op4Btn.image.sprite = Selected;
        op1Btn.image.sprite = op3Btn.image.sprite = op2Btn.image.sprite = Unselected;
    }

    public void PointsCalculatios() {
        //Debug.Log("War gya in start");
        if (player.CurrentPlayer.Course == AppData.Fields.Accountancy) {
            //Debug.Log("War gya Accontancy");
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                //Debug.Log("War gya");
                 if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 3 * .5;
                }
                //Debug.Log("Logic smart Values calculated");
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 3 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 3 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 3 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 3 * .1) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 3 * .1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * .1) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * .1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 3 * .1) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 3 * .1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 3 * .1) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 3 * .1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 3 * .1) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 3 * .1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 3 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 3 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 3 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 3 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 3 * 1.5;
                }
            }
           if(player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1.5;
                }
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 2 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 2 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 4 * .5;
                }

            }else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 2 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 2 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 2 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 2 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 2 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 2 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 2* 1) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 2 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 3 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 2 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 2 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 2 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 2 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 2 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 2 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 2 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 2 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 2 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 2 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 4 * 1.5;
                }
            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 4 * .5;
                }
            }else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 4 * 1.5;
                }
            }
        }

        else if (player.CurrentPlayer.Course == AppData.Fields.HealthCare) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1.5;
                }
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * .5;
                }
                
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * .6;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * .8;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1.2;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1.3;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1.4;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1.5;
                }
            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 2 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 2 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 2 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 2 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 2 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 2 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 2 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 2 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 2 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 2 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 2 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 2 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 2 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 2 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 2 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 2 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 2 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 2 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 2 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 2 * 1.5;
                }
            }


            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .8;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.2;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.3;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.4;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.5;
                }
            }


        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.HumanResource) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * .5;
                }
               
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1.5;
                }
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * .8;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 3 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1.2;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1.3;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1.4;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1.5;
                }

            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 3 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1.5;
                }
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1.5;
                }
            }
        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.InformationTechnology) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {

                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 2 * .5) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 2 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 3 * .5;
                }
                
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 2 * .6) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 2 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 3 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 2 * .7) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 2 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 3 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 2 * .8) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 2 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 3 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 2 * 1) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 2 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 3 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 2 * 1.1) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 2 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 3 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 2 * 1.2) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 2 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 3 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 2 * 1.3) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 2 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 3 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 2 * 1.4) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 2 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 3 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 2 * 1.5) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 2 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 3 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .6;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.5;
                }

            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) { 
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1.5;
                }
            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 3 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 3 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 3 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 3 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 3 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 3 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 3 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 3 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 3 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 3 * 1.5;
                }
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * .5;
                }
   
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 3 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1.5;
                }
            }
        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.Media) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 2 * .5) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 2 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 2 * .5) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 2 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 2 * .6) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 2 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 2 * .6) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 2 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 2 * .7) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 2 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 2 * .7) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 2 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 2 * .8) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 2 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 2 * .8) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 2 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 2 * 1) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 2 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 2 * 1) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 2 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 2 * 1.1) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 2 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 2 * 1.1) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 2 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 2 * 1.2) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 2 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 2 * 1.2) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 2 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 2 * 1.3) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 2 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 2 * 1.3) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 2 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 2 * 1.4) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 2 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 2 * 1.4) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 2 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 2 * 1.5) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 2 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 2 * 1.5) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 2 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1.5;
                }
            }




            



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 2 * .5) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 2 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * .5) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 2 * .6) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 2 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 5 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * .6) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 2 * .7) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 2 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * .7) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 2 * .8) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 2 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * .8) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 2 * 1) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 2 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 2 * 1.1) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 2 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1.1) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 2 * 1.2) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 2 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1.2) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 2 * 1.3) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 2 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1.3) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 2 * 1.4) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 2 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1.4) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1.4;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 2 * 1.5) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 2 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1.5) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1.5;
                }
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * .5) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * .6) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * .7) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * .8) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1.1) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1.2) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1.3) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1.4) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1.5) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1.5;
                }
            }



            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .5;
                }
                
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.5;
                }
            }
        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.Retail) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * .5;
                }
                
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * .5;
                }
                
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1.5;
                }
            }








            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * .5;
                }
                
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * 1.5;
                }
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * .5) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 4 * .5;
                }
                
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * .6) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * .7) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * .8) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 4 * 1.5;
                }
            }



            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * .5;
                }
              
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 *1.1) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1.5;
                }
            }



            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * .5;
                }
  
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * .6;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * .8;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1.2;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1.3;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1.4;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1.5;
                }

            }
        }
    }

    public void MasterPointsCalculatios() {
        Debug.Log("War gya in start");
        if (player.CurrentPlayer.Course == AppData.Fields.Accountancy) {
            Debug.Log("War gya Accontancy");
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                Debug.Log("War gya");

                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 5 * .5;

                Debug.Log("Logic smart Values calculated");
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 5 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 5 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 5 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 5 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 5 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 5 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 5 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 5 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 5 * 1.5;
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 5 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 5 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 5 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 5 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 5 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 5 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 5 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 5 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 5 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 5 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 5 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 5 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 5 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 5 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 5 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 5 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 5 * 1.5;
            }
        } else if (player.CurrentPlayer.Course == AppData.Fields.HealthCare) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 4 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 4 * 1.5;
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 4 * 1.5;

            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 4 * 1.5;
            }


            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.5;


            }


        } else if (player.CurrentPlayer.Course == AppData.Fields.HumanResource) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.HR[10].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.HR[10].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.HR[10].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.HR[10].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.HR[10].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.HR[10].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.HR[10].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.HR[10].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.HR[10].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[4].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.HR[10].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[11].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[14].Cost = 4 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[8].Cost = 4 * 1.5;

            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[7].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[7].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[7].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[7].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[7].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[7].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[7].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[7].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[7].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[5].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[6].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[7].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[12].Cost = 4 * 1.5;

            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[2].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[13].Cost = 4 * 1.5;
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.HR[0].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.HR[0].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.HR[0].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.HR[0].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.HR[0].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.HR[0].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.HR[0].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.HR[0].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.HR[0].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.HR[0].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HR[9].Cost = 4 * 1.5;
            }
        } else if (player.CurrentPlayer.Course == AppData.Fields.InformationTechnology) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.IT[6].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.IT[7].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.IT[9].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.IT[11].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.IT[6].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.IT[7].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.IT[9].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.IT[11].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.IT[6].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.IT[7].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.IT[9].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.IT[11].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.IT[6].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.IT[7].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.IT[9].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.IT[11].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.IT[6].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.IT[7].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.IT[9].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.IT[11].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.IT[6].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.IT[7].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.IT[9].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.IT[11].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.IT[6].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.IT[7].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.IT[9].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.IT[11].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.IT[6].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.IT[7].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.IT[9].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.IT[11].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.IT[6].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.IT[7].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.IT[9].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.IT[11].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.IT[6].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.IT[7].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.IT[9].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.IT[11].Cost = 4 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.IT[8].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.IT[8].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.IT[8].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.IT[8].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.IT[8].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.IT[8].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.IT[8].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.IT[8].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.IT[8].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.IT[8].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.IT[12].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.5;
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.IT[1].Cost = 4 * 1.5;


            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.IT[10].Cost = 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.IT[10].Cost = 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.IT[10].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.IT[10].Cost = 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.IT[10].Cost = 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.IT[10].Cost = 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.IT[10].Cost = 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.IT[10].Cost = 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.IT[10].Cost = 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.IT[10].Cost = 4 * 1.5;

            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.IT[0].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.IT[0].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.IT[0].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.IT[0].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.IT[0].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.IT[0].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.IT[0].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.IT[0].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.IT[0].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.IT[0].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.IT[5].Cost = 4 * 1.5;

            }
        } else if (player.CurrentPlayer.Course == AppData.Fields.Media) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Media[9].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Media[10].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Media[9].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Media[10].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Media[9].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Media[10].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Media[9].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Media[10].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Media[9].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Media[10].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Media[9].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Media[10].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Media[9].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Media[10].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Media[9].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Media[10].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Media[9].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Media[10].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Media[9].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Media[10].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Media[11].Cost = 3 * 1.5;

            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Media[1].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.Media[2].Cost = 2 * .5;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Media[1].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.Media[2].Cost = 2 * .6;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Media[1].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.Media[2].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Media[1].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.Media[2].Cost = 2 * .8;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Media[1].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.Media[2].Cost = 2 * 1;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Media[1].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.Media[2].Cost = 2 * 1.1;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Media[1].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.Media[2].Cost = 2 * 1.2;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Media[1].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.Media[2].Cost = 2 * 1.3;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Media[1].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.Media[2].Cost = 2 * 1.4;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Media[1].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.Media[2].Cost = 2 * 1.5;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Media[7].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Media[8].Cost = 4 * 1.5;
            }








            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Media[4].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.Media[5].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Media[13].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Media[4].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.Media[5].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Media[13].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Media[4].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.Media[5].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Media[13].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Media[4].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.Media[5].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Media[13].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Media[4].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.Media[5].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Media[13].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Media[4].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.Media[5].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Media[13].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Media[4].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.Media[5].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Media[13].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Media[4].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.Media[5].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Media[13].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Media[4].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.Media[5].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Media[13].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Media[4].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.Media[5].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Media[12].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Media[13].Cost = 4 * 1.5;
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Media[3].Cost = 4 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Media[3].Cost = 4 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Media[3].Cost = 4 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Media[3].Cost = 4 * .8;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Media[3].Cost = 4 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Media[3].Cost = 4 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Media[3].Cost = 4 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Media[3].Cost = 4 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Media[3].Cost = 4 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Media[3].Cost = 4 * 1.5;


            }



            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .8;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.5;


            }
        } else if (player.CurrentPlayer.Course == AppData.Fields.Retail) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 4 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {

                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 4 * 1.5;

            }








            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 4 * 1.5;
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 5 * .5;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 5 * .5)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 5 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 5 * .6;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 5 * .6)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 5 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 5 * .7;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 5 * .7)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 5 * .8;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 5 * .8)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 5 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 5 * 1;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 5 * 1)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 5 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 5 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 5 * 1.1)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 5 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 5 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 5 * 1.2)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 5 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 5 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 5 * 1.3)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 5 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 5 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 5 * 1.4)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 5 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 5 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 5 * 1.5)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 5 * 1.5;
            }



            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 4 * 1.5;
            }



            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {

                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 4 * 1.5;

            }
        }
    }


    public void PolyPointsCalculatios() {
        Debug.Log("War gya in start");
        if (player.CurrentPlayer.Course == AppData.Fields.Accountancy) {
            Debug.Log("War gya Accontancy");
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                Debug.Log("War gya");

                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 2 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 0 * .5)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 0 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 2 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 2 * .5;

                Debug.Log("Logic smart Values calculated");
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 2 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 0 * .6)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 0 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 2 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 2 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 0 * .7)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 0 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 2 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 2 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 0 * .8)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 0 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 2 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 2 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 2 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 0 * 1)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 0 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 2 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 2 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 2 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 0 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 0 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 2 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 2 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 2 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 0 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 0 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 2 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 2 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 2 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 0 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 0 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 2 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 2 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 2 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 0 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 0 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 2 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 2 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 2 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 0 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 0 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 2 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 2 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 4 * 1.5;
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 2 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 2 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 2 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 2 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 2 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 2 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 2 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 2 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 3 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * .5;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * .6;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * .8;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * 1;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * 1.1;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * 1.2;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * 1.3;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * 1.4;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 2 * 1.5;
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 3 * 1.5;
            }
        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.HealthCare) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 3 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 3 * 1.5;
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 3 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 3 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 3 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 3 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 3 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 3 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 3 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 3 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 3 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 3 * 1.5;

            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 0 * .5)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 0 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 0 * .6)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 0 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 0 * .7)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 0 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 0 * .8)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 0 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 0 * 1)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 0 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 0 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 0 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 0 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 0 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 0 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 0 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 0 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 0 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 0 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 0 * 1.5;
            }


            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 4 * 1.5;


            }


        }
        
        else if (player.CurrentPlayer.Course == AppData.Fields.HumanResource) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HR[4].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.HR[10].Cost = 2 * .5;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HR[11].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HR[14].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HR[4].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.HR[10].Cost = 2 * .6;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HR[11].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HR[14].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[4].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.HR[10].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[11].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[14].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HR[4].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.HR[10].Cost = 2 * .8;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HR[11].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HR[14].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HR[4].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.HR[10].Cost = 2 * 1;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HR[11].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HR[14].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HR[4].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.HR[10].Cost = 2 * 1.1;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HR[11].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HR[14].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HR[4].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.HR[10].Cost = 2 * 1.2;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HR[11].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HR[14].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HR[4].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.HR[10].Cost = 2 * 1.3;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HR[11].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HR[14].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HR[4].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.HR[10].Cost = 2 * 1.4;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HR[11].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HR[14].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HR[4].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HR[10].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.HR[10].Cost = 2 * 1.5;
                if (player.CurrentPlayer.Skills.HR[11].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HR[11].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HR[14].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HR[14].Cost = 3 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HR[8].Cost = 3 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HR[8].Cost = 3 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[8].Cost = 3 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HR[8].Cost = 3 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HR[8].Cost = 3 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HR[8].Cost = 3 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HR[8].Cost = 3 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HR[8].Cost = 3 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HR[8].Cost = 3 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HR[8].Cost = 3 * 1.5;

            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HR[5].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HR[6].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.HR[7].Cost = 2 * .5;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HR[12].Cost = 3 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HR[5].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HR[6].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.HR[7].Cost = 2 * .6;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HR[12].Cost = 3 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[5].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[6].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.HR[7].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[12].Cost = 3 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[5].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[6].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.HR[7].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[12].Cost = 3 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HR[5].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HR[6].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.HR[7].Cost = 2 * 1;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HR[12].Cost = 3 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HR[5].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HR[6].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.HR[7].Cost = 2 * 1.1;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HR[12].Cost = 3 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HR[5].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HR[6].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.HR[7].Cost = 2 * 1.2;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HR[12].Cost = 3 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HR[5].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HR[6].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.HR[7].Cost = 2 * 1.3;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HR[12].Cost = 3 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HR[5].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HR[6].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.HR[7].Cost = 2 * 1.4;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HR[12].Cost = 3 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HR[5].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HR[6].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HR[6].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HR[7].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.HR[7].Cost = 2 * 1.5;
                if (player.CurrentPlayer.Skills.HR[12].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HR[12].Cost = 3 * 1.5;

            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.HR[1].Cost = 2 * .5;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HR[2].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.HR[3].Cost = 2 * .5;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HR[13].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.HR[1].Cost = 2 * .6;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HR[2].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.HR[3].Cost = 2 * .6;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HR[13].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.HR[1].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[2].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.HR[3].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[13].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.HR[1].Cost = 2 * .8;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HR[2].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.HR[3].Cost = 2 * .8;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HR[13].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.HR[1].Cost = 2 * 1;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HR[2].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.HR[3].Cost = 2 * 1;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HR[13].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.HR[1].Cost = 2 * 1.1;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HR[2].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.HR[3].Cost = 2 * 1.1;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HR[13].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.HR[1].Cost = 2 * 1.2;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HR[2].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.HR[3].Cost = 2 * 1.2;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HR[13].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.HR[1].Cost = 2 * 1.3;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HR[2].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.HR[3].Cost = 2 * 1.3;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HR[13].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.HR[1].Cost = 2 * 1.4;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HR[2].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.HR[3].Cost = 2 * 1.4;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HR[13].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.HR[1].Cost = 2 * 1.5;
                if (player.CurrentPlayer.Skills.HR[2].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HR[2].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HR[3].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.HR[3].Cost = 2 * 1.5;
                if (player.CurrentPlayer.Skills.HR[13].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HR[13].Cost = 3 * 1.5;
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HR[0].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.HR[9].Cost = 3 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HR[0].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.HR[9].Cost = 3 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[0].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.HR[9].Cost = 3 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HR[0].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.HR[9].Cost = 3 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HR[0].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.HR[9].Cost = 3 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HR[0].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.HR[9].Cost = 3 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HR[0].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.HR[9].Cost = 3 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HR[0].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.HR[9].Cost = 3 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HR[0].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.HR[9].Cost = 3 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HR[0].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.HR[9].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.HR[9].Cost = 3 * 1.5;
            }
        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.InformationTechnology) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.IT[6].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.IT[7].Cost = 2 * .5;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 0 * .5)
                    player.CurrentPlayer.Skills.IT[9].Cost = 0 * .5;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.IT[11].Cost = 2 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.IT[6].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.IT[7].Cost = 2 * .6;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 0 * .6)
                    player.CurrentPlayer.Skills.IT[9].Cost = 0 * .6;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.IT[11].Cost = 2 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.IT[6].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.IT[7].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 0 * .7)
                    player.CurrentPlayer.Skills.IT[9].Cost = 0 * .7;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.IT[11].Cost = 2 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.IT[6].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.IT[7].Cost = 2 * .8;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 0 * .8)
                    player.CurrentPlayer.Skills.IT[9].Cost = 0 * .8;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.IT[11].Cost = 2 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.IT[6].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.IT[7].Cost = 2 * 1;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 0 * 1)
                    player.CurrentPlayer.Skills.IT[9].Cost = 0 * 1;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.IT[11].Cost = 2 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.IT[6].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.IT[7].Cost = 2 * 1.1;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 0 * 1.1)
                    player.CurrentPlayer.Skills.IT[9].Cost = 0 * 1.1;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.IT[11].Cost = 2 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.IT[6].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.IT[7].Cost = 2 * 1.2;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 0 * 1.2)
                    player.CurrentPlayer.Skills.IT[9].Cost = 0 * 1.2;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.IT[11].Cost = 2 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.IT[6].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.IT[7].Cost = 2 * 1.3;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 0 * 1.3)
                    player.CurrentPlayer.Skills.IT[9].Cost = 0 * 1.3;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.IT[11].Cost = 2 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.IT[6].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.IT[7].Cost = 2 * 1.4;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 0 * 1.4)
                    player.CurrentPlayer.Skills.IT[9].Cost = 0 * 1.4;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.IT[11].Cost = 2 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.IT[6].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.IT[6].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.IT[7].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.IT[7].Cost = 2 * 1.5;
                if (player.CurrentPlayer.Skills.IT[9].Cost < 0 * 1.5)
                    player.CurrentPlayer.Skills.IT[9].Cost = 0 * 1.5;
                if (player.CurrentPlayer.Skills.IT[11].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.IT[11].Cost = 2 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.IT[8].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.IT[12].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.IT[8].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.IT[12].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.IT[8].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.IT[12].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.IT[8].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.IT[12].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.IT[8].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.IT[12].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.IT[8].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.IT[12].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.IT[8].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.IT[12].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.IT[8].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.IT[12].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.IT[8].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.IT[12].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.IT[8].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.IT[8].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.IT[12].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.IT[12].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.IT[13].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.IT[13].Cost = 3 * 1.5;
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.IT[1].Cost = 3 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.IT[1].Cost = 3 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.IT[1].Cost = 3 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.IT[1].Cost = 3 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.IT[1].Cost = 3 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.IT[1].Cost = 3 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.IT[1].Cost = 3 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.IT[1].Cost = 3 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.IT[1].Cost = 3 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.IT[1].Cost = 3 * 1.5;


            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.IT[10].Cost = 2 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.IT[10].Cost = 2 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.IT[10].Cost = 2 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.IT[10].Cost = 2 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.IT[10].Cost = 2 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.IT[10].Cost = 2 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.IT[10].Cost = 2 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.IT[10].Cost = 2 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.IT[10].Cost = 2 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.IT[10].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.IT[10].Cost = 2 * 1.5;

            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 0 * .5)
                    player.CurrentPlayer.Skills.IT[0].Cost = 0 * .5;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.IT[5].Cost = 3 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 0 * .6)
                    player.CurrentPlayer.Skills.IT[0].Cost = 0 * .6;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.IT[5].Cost = 3 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 0 * .7)
                    player.CurrentPlayer.Skills.IT[0].Cost = 0 * .7;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.IT[5].Cost = 3 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 0 * .8)
                    player.CurrentPlayer.Skills.IT[0].Cost = 0 * .8;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.IT[5].Cost = 3 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 0 * 1)
                    player.CurrentPlayer.Skills.IT[0].Cost = 0 * 1;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.IT[5].Cost = 3 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 0 * 1.1)
                    player.CurrentPlayer.Skills.IT[0].Cost = 0 * 1.1;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.IT[5].Cost = 3 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 0 * 1.2)
                    player.CurrentPlayer.Skills.IT[0].Cost = 0 * 1.2;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.IT[5].Cost = 3 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 0 * 1.3)
                    player.CurrentPlayer.Skills.IT[0].Cost = 0 * 1.3;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.IT[5].Cost = 3 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 0 * 1.4)
                    player.CurrentPlayer.Skills.IT[0].Cost = 0 * 1.4;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.IT[5].Cost = 3 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 0 * 1.5)
                    player.CurrentPlayer.Skills.IT[0].Cost = 0 * 1.5;
                if (player.CurrentPlayer.Skills.IT[5].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.IT[5].Cost = 3 * 1.5;

            }
        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.Media) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 0 * .5)
                    player.CurrentPlayer.Skills.Media[9].Cost = 0 * .5;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 1 * .5)
                    player.CurrentPlayer.Skills.Media[10].Cost = 1 * .5;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.Media[11].Cost = 2 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 0 * .6)
                    player.CurrentPlayer.Skills.Media[9].Cost = 0 * .6;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 1 * .6)
                    player.CurrentPlayer.Skills.Media[10].Cost = 1 * .6;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.Media[11].Cost = 2 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 0 * .7)
                    player.CurrentPlayer.Skills.Media[9].Cost = 0 * .7;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 1 * .7)
                    player.CurrentPlayer.Skills.Media[10].Cost = 1 * .7;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.Media[11].Cost = 2 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 0 * .8)
                    player.CurrentPlayer.Skills.Media[9].Cost = 0 * .8;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 1 * .8)
                    player.CurrentPlayer.Skills.Media[10].Cost = 1 * .8;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.Media[11].Cost = 2 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 0 * 1)
                    player.CurrentPlayer.Skills.Media[9].Cost = 0 * 1;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 1 * 1)
                    player.CurrentPlayer.Skills.Media[10].Cost = 1 * 1;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.Media[11].Cost = 2 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 0 * 1.1)
                    player.CurrentPlayer.Skills.Media[9].Cost = 0 * 1.1;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 1 * 1.1)
                    player.CurrentPlayer.Skills.Media[10].Cost = 1 * 1.1;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.Media[11].Cost = 2 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 0 * 1.2)
                    player.CurrentPlayer.Skills.Media[9].Cost = 0 * 1.2;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 1 * 1.2)
                    player.CurrentPlayer.Skills.Media[10].Cost = 1 * 1.2;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.Media[11].Cost = 2 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 0 * 1.3)
                    player.CurrentPlayer.Skills.Media[9].Cost = 0 * 1.3;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 1 * 1.3)
                    player.CurrentPlayer.Skills.Media[10].Cost = 1 * 1.3;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.Media[11].Cost = 2 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 0 * 1.4)
                    player.CurrentPlayer.Skills.Media[9].Cost = 0 * 1.4;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 1 * 1.4)
                    player.CurrentPlayer.Skills.Media[10].Cost = 1 * 1.4;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.Media[11].Cost = 2 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 0 * 1.5)
                    player.CurrentPlayer.Skills.Media[9].Cost = 0 * 1.5;
                if (player.CurrentPlayer.Skills.Media[10].Cost < 1 * 1.5)
                    player.CurrentPlayer.Skills.Media[10].Cost = 1 * 1.5;
                if (player.CurrentPlayer.Skills.Media[11].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.Media[11].Cost = 2 * 1.5;

            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Media[7].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Media[8].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Media[7].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Media[8].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Media[7].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Media[8].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Media[7].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Media[8].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Media[7].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Media[8].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Media[7].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Media[8].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Media[7].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Media[8].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Media[7].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Media[8].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Media[7].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Media[8].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Media[1].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Media[2].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Media[2].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Media[7].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Media[7].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Media[8].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Media[8].Cost = 3 * 1.5;
            }








            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 0 * .5)
                    player.CurrentPlayer.Skills.Media[4].Cost = 0 * .5;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * .5)
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * .5;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.Media[12].Cost = 2 * .5;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 0 * .6)
                    player.CurrentPlayer.Skills.Media[4].Cost = 0 * .6;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * .6)
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * .6;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.Media[12].Cost = 2 * .6;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 0 * .7)
                    player.CurrentPlayer.Skills.Media[4].Cost = 0 * .7;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * .7)
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * .7;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.Media[12].Cost = 2 * .7;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 0 * .8)
                    player.CurrentPlayer.Skills.Media[4].Cost = 0 * .8;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * .8)
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * .8;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.Media[12].Cost = 2 * .8;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 0 * 1)
                    player.CurrentPlayer.Skills.Media[4].Cost = 0 * 1;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1)
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.Media[12].Cost = 2 * 1;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 0 * 1.1)
                    player.CurrentPlayer.Skills.Media[4].Cost = 0 * 1.1;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1.1)
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1.1;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.Media[12].Cost = 2 * 1.1;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 0 * 1.2)
                    player.CurrentPlayer.Skills.Media[4].Cost = 0 * 1.2;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1.2)
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1.2;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.Media[12].Cost = 2 * 1.2;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 0 * 1.3)
                    player.CurrentPlayer.Skills.Media[4].Cost = 0 * 1.3;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1.3)
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1.3;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.Media[12].Cost = 2 * 1.3;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 0 * 1.4)
                    player.CurrentPlayer.Skills.Media[4].Cost = 0 * 1.4;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1.4)
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1.4;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.Media[12].Cost = 2 * 1.4;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.Media[4].Cost < 0 * 1.5)
                    player.CurrentPlayer.Skills.Media[4].Cost = 0 * 1.5;
                if (player.CurrentPlayer.Skills.Media[5].Cost < 4 * 1.5)
                    player.CurrentPlayer.Skills.Media[5].Cost = 4 * 1.5;
                if (player.CurrentPlayer.Skills.Media[12].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.Media[12].Cost = 2 * 1.5;
                if (player.CurrentPlayer.Skills.Media[13].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.Media[13].Cost = 2 * 1.5;
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * .5)
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * .6)
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * .7)
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * .8)
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * .8;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1)
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1.1)
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1.2)
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1.3)
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1.4)
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 2 * 1.5)
                    player.CurrentPlayer.Skills.Media[3].Cost = 2 * 1.5;


            }



            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * .8;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Media[6].Cost = 3 * 1.5;


            }
        } else if (player.CurrentPlayer.Course == AppData.Fields.Retail) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[1].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[3].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[7].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[11].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[12].Cost = 3 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {

                if (player.CurrentPlayer.Skills.Retail[8].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 3 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 3 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 3 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 3 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 3 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 3 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 3 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 3 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 3 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[8].Cost = 3 * 1.5;

            }








            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .5)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .5;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .6)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .6;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .7)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .7;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .8)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .8;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.1)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.2)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.3)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.4)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.5)
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[6].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[13].Cost = 3 * 1.5;
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[0].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[2].Cost = 3 * 1.5;
            }



            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 3 * .5;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 3 * .6;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 3 * .7;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 3 * .8;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 3 * 1;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 3 * 1.1;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 3 * 1.2;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 3 * 1.3;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 3 * 1.4;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[5].Cost = 3 * 1.5;
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[9].Cost = 3 * 1.5;
            }



            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {

                if (player.CurrentPlayer.Skills.Retail[10].Cost < 3 * .5)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 3 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 3 * .6)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 3 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 3 * .7)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 3 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 3 * .8)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 3 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 3 * 1)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 3 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 3 * 1.1)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 3 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 3 * 1.2)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 3 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 3 * 1.3)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 3 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 3 * 1.4)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 3 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 3 * 1.5)
                    player.CurrentPlayer.Skills.Retail[10].Cost = 3 * 1.5;

            }
        }
    }


    public void PhDPointsCalculatios() {
        Debug.Log("War gya in start");
        if (player.CurrentPlayer.Course == AppData.Fields.Accountancy) {
            Debug.Log("War gya Accontancy");
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                Debug.Log("War gya");

                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 6 * .5;
                }

                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 6 * .5;
                }

                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * .5;
                }

                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 6 * .5;
                }

                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 6 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[0].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[0].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[1].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[1].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[5].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[5].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[8].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[8].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[9].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[9].Cost = 6 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[2].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[2].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[7].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[7].Cost = 6 * 1.5;
                }
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 0 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 0 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 0 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 0 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 0 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 0 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 0 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 0 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 0 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[4].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[4].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[6].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[6].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[11].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[11].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[12].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[12].Cost = 0 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[13].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[13].Cost = 6 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Accountacy[3].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[3].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Accountacy[10].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Accountacy[10].Cost = 6 * 1.5;
                }
            }
        } else if (player.CurrentPlayer.Course == AppData.Fields.HealthCare) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 0 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 6 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 0 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 0 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 0 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 0 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 0 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 0 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 0 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 0 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[7].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[7].Cost = 0 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[13].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[13].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[10].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[10].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[11].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[11].Cost = 6 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[0].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[0].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[1].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[1].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[8].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[8].Cost = 6 * 1.5;
                }
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 6 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 6 * .6;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 6 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 6 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 6 * 1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 6 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 6 * 1.2;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 6 * 1.3;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 6 * 1.4;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[2].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[2].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[12].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[12].Cost = 6 * 1.5;
                }

            }



            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 5 * .5;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 5 * .6;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 5 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 5 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 5 * 1;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 5 * 1.1;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 5 * 1.2;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 5 * 1.3;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 5 * 1.4;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[9].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[9].Cost = 5 * 1.5;
                }

            }




            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.HealtCare[3].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[3].Cost = 5 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[4].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[4].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[5].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[5].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HealtCare[6].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HealtCare[6].Cost = 6 * 1.5;
                }
            }
        } else if (player.CurrentPlayer.Course == AppData.Fields.HumanResource) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 5 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 0 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 5 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 0 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 5 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 0 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 5 * .8) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 5 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 0 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 5 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 0 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 5 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 0 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 5 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 0 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 5 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 0 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 5 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 0 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[4].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.HR[4].Cost = 5 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[10].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.HR[10].Cost = 0 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[11].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HR[11].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[14].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HR[14].Cost = 6 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 0 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 0 * .6;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 0 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 0 * .8;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 0 * 1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 0 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 0 * 1.2;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 0 * 1.3;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 0 * 1.4;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[8].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.HR[8].Cost = 0 * 1.5;
                }

            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 5 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 5 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 5 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 5 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 5 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 5 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 5 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 5 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 5 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 5 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 5 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 5 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 5 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 5 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 5 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 5 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 5 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 5 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 5 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 5 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 5 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 5 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 5 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 5 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 5 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 5 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 5 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[5].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.HR[5].Cost = 5 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[6].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.HR[6].Cost = 5 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[7].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.HR[7].Cost = 5 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[12].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HR[12].Cost = 6 * 1.5;
                }
            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 5 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * .5) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[1].Cost <6 * .6) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 5 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * .6) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 5 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * .7) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 5 * .8) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 5 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * .8) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 5 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 5 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1.1) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 5 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1.2) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 5 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1.3) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 5 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1.4) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[1].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HR[1].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[2].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.HR[2].Cost = 5 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[3].Cost < 4 * 1.5) {
                    player.CurrentPlayer.Skills.HR[3].Cost = 4 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[13].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HR[13].Cost = 6 * 1.5;
                }
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 6 * .5)
                {
                    player.CurrentPlayer.Skills.HR[0].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 6 * .5)
                {
                    player.CurrentPlayer.Skills.HR[9].Cost = 6 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 6 * .6;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 6 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 6 * .8;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 6 * 1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 6 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 6 * 1.2;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 6 * 1.3;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 6 * 1.4)
                {
                    player.CurrentPlayer.Skills.HR[0].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 6 * 1.4)
                {
                    player.CurrentPlayer.Skills.HR[9].Cost = 6 * 1.4;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.HR[0].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HR[0].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.HR[9].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.HR[9].Cost = 6 * 1.5;
                }
            }
        } else if (player.CurrentPlayer.Course == AppData.Fields.InformationTechnology) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 0 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 0 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 0 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 0 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 0 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 0 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 0 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 0 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 0 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 0 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 0 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 0 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 0 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 0 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 0 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 0 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 0 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 0 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[3].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[3].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[6].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[6].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[7].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.IT[7].Cost = 0 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[9].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[9].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[11].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.IT[11].Cost = 0 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 0 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 0 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 0 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 0 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 0 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 0 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 0 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 0 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 0 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[4].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[4].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[8].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.IT[8].Cost = 0 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[12].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[12].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[13].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[13].Cost = 6 * 1.5;
                }
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 5 * .5;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 5 * .6;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 5 * .7;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 5 * .7;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 5 * 1;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 5 * 1.1;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 5 * 1.2;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 5 * 1.3;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 5 * 1.4;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[1].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.IT[1].Cost = 5 * 1.5;
                }


            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 6 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 6 * .6;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 6 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 6 * .8;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 6 * 1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 6 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 6 * 1.2;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 6 * 1.3;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 6 * 1.4;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[2].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[2].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[10].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[10].Cost = 6 * 1.5;
                }

            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 6 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 6 * .6;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 6 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 6 * .8;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 6 * 1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 6 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 6 * 1.2;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 6 * 1.3;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 6 * 1.4;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.IT[0].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[0].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.IT[5].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.IT[5].Cost = 6 * 1.5;
                }

            }
        } else if (player.CurrentPlayer.Course == AppData.Fields.Media) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 0 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 0 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 0 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 0 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 0 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 0 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 0 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 0 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 0 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 0 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 0 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 0 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 0 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 0 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 0 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 0 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 0 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 0 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[9].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Media[9].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[10].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.Media[10].Cost = 0 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[11].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.Media[11].Cost = 0 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[1].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Media[1].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[2].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Media[2].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[7].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Media[7].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[8].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Media[8].Cost = 6 * 1.5;
                }
            }








            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 0 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 5 * .5;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 0 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 5 * .6;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 0 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 5 * .7;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 0 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 5 * .8) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 5 * .8;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 0 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 5 * 1;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 0 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 5 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 0 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 5 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 0 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 5 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 0 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 5 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[0].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Media[0].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[4].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Media[4].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[5].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.Media[5].Cost = 0 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[12].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.Media[12].Cost = 5 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Media[13].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Media[13].Cost = 6 * 1.5;
                }
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 5 * .5;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 5 * .6;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 5 * .7;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 5 * .8) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 5 * .8;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 5 * 1;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 5 * 1.1;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 5 * 1.2;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 5 * 1.3;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 5 * 1.4;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[3].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.Media[3].Cost = 5 * 1.5;
                }


            }



            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 5 * .5) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 5 * .5;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 5 * .6) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 5 * .6;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 5 * .7) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 5 * .7;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 5 * .8) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 5 * .8;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 5 * 1) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 5 * 1;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 5 * 1.1) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 5 * 1.1;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 5 * 1.2) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 5 * 1.2;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 5 * 1.3) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 5 * 1.3;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 5 * 1.4) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 5 * 1.4;
                }


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Media[6].Cost < 5 * 1.5) {
                    player.CurrentPlayer.Skills.Media[6].Cost = 5 * 1.5;
                }


            }
        } else if (player.CurrentPlayer.Course == AppData.Fields.Retail) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 0 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 0 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 0 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 0 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 0 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 0 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost <6 * .8) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 0 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 0 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 0 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 0 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 0 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 0 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 0 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 0 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 0 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 0 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 0 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 0 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[1].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[1].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[3].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[3].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[7].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[7].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[11].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[11].Cost = 0 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[12].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[12].Cost = 0 * 1.5;
                }
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {

                if (player.CurrentPlayer.Skills.Retail[8].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 0 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 0 * .6;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 0 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 0 * .8;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 0 * 1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 0 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 0 * 1.2;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 0 * 1.3;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 0 * 1.4;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[8].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[8].Cost = 0 * 1.5;
                }

            }


            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 0 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 0 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 0 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 0 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 0 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 0 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 0 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 0 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 0 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[4].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[4].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[6].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[6].Cost = 0 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[13].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[13].Cost = 6 * 1.5;
                }
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[0].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[0].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[2].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[2].Cost = 6 * 1.5;
                }
            }



            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 6 * .5;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 6 * .5) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 6 * .5;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 6 * .6;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 6 * .6) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 6 * .6;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 6 * .7;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 6 * .7) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 6 * .7;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 6 * .8;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 6 * .8) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 6 * .8;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 6 * 1;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 6 * 1) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 6 * 1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 6 * 1.1;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 6 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 6 * 1.1;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 6 * 1.2;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 6 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 6 * 1.2;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 6 * 1.3;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 6 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 6 * 1.3;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 6 * 1.4;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 6 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 6 * 1.4;
                }
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[5].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[5].Cost = 6 * 1.5;
                }
                if (player.CurrentPlayer.Skills.Retail[9].Cost < 6 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[9].Cost = 6 * 1.5;
                }
            }



            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {

                if (player.CurrentPlayer.Skills.Retail[10].Cost < 0 * .5) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 0 * .5;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 0 * .6) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 0 * .6;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 0 * .7) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 0 * .7;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 0 * .8) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 0 * .8;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 0 * 1) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 0 * 1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 0 * 1.1) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 0 * 1.1;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 0 * 1.2) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 0 * 1.2;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 0 * 1.3) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 0 * 1.3;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 0 * 1.4) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 0 * 1.4;
                }

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                if (player.CurrentPlayer.Skills.Retail[10].Cost < 0 * 1.5) {
                    player.CurrentPlayer.Skills.Retail[10].Cost = 0 * 1.5;
                }
            }
        }
    }


    /*
    public void MasterPointsCalculatios() {
        Debug.Log("War gya in start");
        if (player.CurrentPlayer.Course == AppData.Fields.Accountancy) {
            Debug.Log("War gya Accontancy");
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                Debug.Log("War gya");
                player.CurrentPlayer.Skills.Accountacy[0].Cost += 5 * .5;
                player.CurrentPlayer.Skills.Accountacy[1].Cost += 5 * .5;
                player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * .5;
                player.CurrentPlayer.Skills.Accountacy[8].Cost += 5 * .5;
                player.CurrentPlayer.Skills.Accountacy[9].Cost += 5 * .5;
                Debug.Log("Logic smart Values calculated");
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                player.CurrentPlayer.Skills.Accountacy[0].Cost += 5 * .6;
                player.CurrentPlayer.Skills.Accountacy[1].Cost += 5 * .6;
                player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * .6;
                player.CurrentPlayer.Skills.Accountacy[8].Cost += 5 * .6;
                player.CurrentPlayer.Skills.Accountacy[9].Cost += 5 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                player.CurrentPlayer.Skills.Accountacy[0].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Accountacy[1].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * .7;
                player.CurrentPlayer.Skills.Accountacy[8].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Accountacy[9].Cost += 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                player.CurrentPlayer.Skills.Accountacy[0].Cost += 5 * .8;
                player.CurrentPlayer.Skills.Accountacy[1].Cost += 5 * .8;
                player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * .8;
                player.CurrentPlayer.Skills.Accountacy[8].Cost += 5 * .8;
                player.CurrentPlayer.Skills.Accountacy[9].Cost += 5 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                player.CurrentPlayer.Skills.Accountacy[0].Cost += 5 * 1;
                player.CurrentPlayer.Skills.Accountacy[1].Cost += 5 * 1;
                player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1;
                player.CurrentPlayer.Skills.Accountacy[8].Cost += 5 * 1;
                player.CurrentPlayer.Skills.Accountacy[9].Cost += 5 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                player.CurrentPlayer.Skills.Accountacy[0].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.Accountacy[1].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.Accountacy[8].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.Accountacy[9].Cost += 5 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                player.CurrentPlayer.Skills.Accountacy[0].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.Accountacy[1].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.Accountacy[8].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.Accountacy[9].Cost += 5 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                player.CurrentPlayer.Skills.Accountacy[0].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.Accountacy[1].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.Accountacy[8].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.Accountacy[9].Cost += 5 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                player.CurrentPlayer.Skills.Accountacy[0].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.Accountacy[1].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.Accountacy[8].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.Accountacy[9].Cost += 5 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                player.CurrentPlayer.Skills.Accountacy[0].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.Accountacy[1].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.Accountacy[8].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.Accountacy[9].Cost += 5 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                player.CurrentPlayer.Skills.Accountacy[2].Cost += 5 * .5;
                player.CurrentPlayer.Skills.Accountacy[7].Cost += 5 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                player.CurrentPlayer.Skills.Accountacy[2].Cost+= 5 * .6;
                player.CurrentPlayer.Skills.Accountacy[7].Cost += 5 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                player.CurrentPlayer.Skills.Accountacy[2].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Accountacy[7].Cost += 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                player.CurrentPlayer.Skills.Accountacy[2].Cost += 5 * .8;
                player.CurrentPlayer.Skills.Accountacy[7].Cost += 5 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                player.CurrentPlayer.Skills.Accountacy[2].Cost += 5 * 1;
                player.CurrentPlayer.Skills.Accountacy[7].Cost += 5 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                player.CurrentPlayer.Skills.Accountacy[2].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.Accountacy[7].Cost += 5 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                player.CurrentPlayer.Skills.Accountacy[2].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.Accountacy[7].Cost += 5 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                player.CurrentPlayer.Skills.Accountacy[2].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.Accountacy[7].Cost += 5 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                player.CurrentPlayer.Skills.Accountacy[2].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.Accountacy[7].Cost += 5 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                player.CurrentPlayer.Skills.Accountacy[2].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.Accountacy[7].Cost += 5 * 1.5;
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                player.CurrentPlayer.Skills.Accountacy[4].Cost += 5 * .5;
                player.CurrentPlayer.Skills.Accountacy[6].Cost += 2 * .5;
                player.CurrentPlayer.Skills.Accountacy[11].Cost += 5 * .5;
                player.CurrentPlayer.Skills.Accountacy[12].Cost += 5 * .5;
                player.CurrentPlayer.Skills.Accountacy[13].Cost += 5 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                player.CurrentPlayer.Skills.Accountacy[4].Cost += 5 * .6;
                player.CurrentPlayer.Skills.Accountacy[6].Cost += 2 * .6;
                player.CurrentPlayer.Skills.Accountacy[11].Cost += 5 * .6;
                player.CurrentPlayer.Skills.Accountacy[12].Cost += 5 * .6;
                player.CurrentPlayer.Skills.Accountacy[13].Cost += 5 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                player.CurrentPlayer.Skills.Accountacy[4].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Accountacy[6].Cost += 2 * .7;
                player.CurrentPlayer.Skills.Accountacy[11].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Accountacy[12].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Accountacy[13].Cost += 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                player.CurrentPlayer.Skills.Accountacy[4].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Accountacy[6].Cost += 2 * .7;
                player.CurrentPlayer.Skills.Accountacy[11].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Accountacy[12].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Accountacy[13].Cost += 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                player.CurrentPlayer.Skills.Accountacy[4].Cost += 5 * 1;
                player.CurrentPlayer.Skills.Accountacy[6].Cost += 2 * 1;
                player.CurrentPlayer.Skills.Accountacy[11].Cost += 5 * 1;
                player.CurrentPlayer.Skills.Accountacy[12].Cost += 5 * 1;
                player.CurrentPlayer.Skills.Accountacy[13].Cost += 5 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                player.CurrentPlayer.Skills.Accountacy[4].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.Accountacy[6].Cost += 2 * 1.1;
                player.CurrentPlayer.Skills.Accountacy[11].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.Accountacy[12].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.Accountacy[13].Cost += 5 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                player.CurrentPlayer.Skills.Accountacy[4].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.Accountacy[6].Cost += 2 * 1.2;
                player.CurrentPlayer.Skills.Accountacy[11].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.Accountacy[12].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.Accountacy[13].Cost += 5 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                player.CurrentPlayer.Skills.Accountacy[4].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.Accountacy[6].Cost += 2 * 1.3;
                player.CurrentPlayer.Skills.Accountacy[11].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.Accountacy[12].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.Accountacy[13].Cost += 5 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                player.CurrentPlayer.Skills.Accountacy[4].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.Accountacy[6].Cost += 2 * 1.4;
                player.CurrentPlayer.Skills.Accountacy[11].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.Accountacy[12].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.Accountacy[13].Cost += 5 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                player.CurrentPlayer.Skills.Accountacy[4].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.Accountacy[6].Cost += 2 * 1.5;
                player.CurrentPlayer.Skills.Accountacy[11].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.Accountacy[12].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.Accountacy[13].Cost += 5 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                player.CurrentPlayer.Skills.Accountacy[3].Cost += 2 * .5;
                player.CurrentPlayer.Skills.Accountacy[10].Cost += 5 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                player.CurrentPlayer.Skills.Accountacy[3].Cost += 2 * .6;
                player.CurrentPlayer.Skills.Accountacy[10].Cost += 5 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                player.CurrentPlayer.Skills.Accountacy[3].Cost += 2 * .7;
                player.CurrentPlayer.Skills.Accountacy[10].Cost += 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                player.CurrentPlayer.Skills.Accountacy[3].Cost += 2 * .8;
                player.CurrentPlayer.Skills.Accountacy[10].Cost += 5 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                player.CurrentPlayer.Skills.Accountacy[3].Cost += 2 * 1;
                player.CurrentPlayer.Skills.Accountacy[10].Cost += 5 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                player.CurrentPlayer.Skills.Accountacy[3].Cost += 2 * 1.1;
                player.CurrentPlayer.Skills.Accountacy[10].Cost += 5 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                player.CurrentPlayer.Skills.Accountacy[3].Cost += 2 * 1.2;
                player.CurrentPlayer.Skills.Accountacy[10].Cost += 5 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                player.CurrentPlayer.Skills.Accountacy[3].Cost += 2 * 1.3;
                player.CurrentPlayer.Skills.Accountacy[10].Cost += 5 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                player.CurrentPlayer.Skills.Accountacy[3].Cost += 2 * 1.4;
                player.CurrentPlayer.Skills.Accountacy[10].Cost += 5 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                player.CurrentPlayer.Skills.Accountacy[3].Cost += 2 * 1.5;
                player.CurrentPlayer.Skills.Accountacy[10].Cost += 5 * 1.5;
            }
        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.HealthCare) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                player.CurrentPlayer.Skills.HealtCare[7].Cost += 2 * .5;
                player.CurrentPlayer.Skills.HealtCare[13].Cost += 4 * .5;
                player.CurrentPlayer.Skills.HealtCare[10].Cost += 4 * .5;
                player.CurrentPlayer.Skills.HealtCare[11].Cost += 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                player.CurrentPlayer.Skills.HealtCare[7].Cost += 2 * .6;
                player.CurrentPlayer.Skills.HealtCare[13].Cost += 4 * .6;
                player.CurrentPlayer.Skills.HealtCare[10].Cost += 4 * .6;
                player.CurrentPlayer.Skills.HealtCare[11].Cost += 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                player.CurrentPlayer.Skills.HealtCare[7].Cost += 2 * .7;
                player.CurrentPlayer.Skills.HealtCare[13].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HealtCare[10].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HealtCare[11].Cost += 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                player.CurrentPlayer.Skills.HealtCare[7].Cost += 2 * .8;
                player.CurrentPlayer.Skills.HealtCare[13].Cost += 4 * .8;
                player.CurrentPlayer.Skills.HealtCare[10].Cost += 4 * .8;
                player.CurrentPlayer.Skills.HealtCare[11].Cost += 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                player.CurrentPlayer.Skills.HealtCare[7].Cost += 2 * 1;
                player.CurrentPlayer.Skills.HealtCare[13].Cost += 4 * 1;
                player.CurrentPlayer.Skills.HealtCare[10].Cost += 4 * 1;
                player.CurrentPlayer.Skills.HealtCare[11].Cost += 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                player.CurrentPlayer.Skills.HealtCare[7].Cost += 2 * 1.1;
                player.CurrentPlayer.Skills.HealtCare[13].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.HealtCare[10].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.HealtCare[11].Cost += 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                player.CurrentPlayer.Skills.HealtCare[7].Cost += 2 * 1.2;
                player.CurrentPlayer.Skills.HealtCare[13].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.HealtCare[10].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.HealtCare[11].Cost += 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                player.CurrentPlayer.Skills.HealtCare[7].Cost += 2 * 1.3;
                player.CurrentPlayer.Skills.HealtCare[13].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.HealtCare[10].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.HealtCare[11].Cost += 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                player.CurrentPlayer.Skills.HealtCare[7].Cost += 2 * 1.4;
                player.CurrentPlayer.Skills.HealtCare[13].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.HealtCare[10].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.HealtCare[11].Cost += 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                player.CurrentPlayer.Skills.HealtCare[7].Cost += 2 * 1.5;
                player.CurrentPlayer.Skills.HealtCare[13].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.HealtCare[10].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.HealtCare[11].Cost += 4 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                player.CurrentPlayer.Skills.HealtCare[0].Cost += 5 * .5;
                player.CurrentPlayer.Skills.HealtCare[1].Cost += 5 * .5;
                player.CurrentPlayer.Skills.HealtCare[8].Cost += 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                player.CurrentPlayer.Skills.HealtCare[0].Cost += 5 * .6;
                player.CurrentPlayer.Skills.HealtCare[1].Cost += 5 * .6;
                player.CurrentPlayer.Skills.HealtCare[8].Cost += 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                player.CurrentPlayer.Skills.HealtCare[0].Cost += 5 * .7;
                player.CurrentPlayer.Skills.HealtCare[1].Cost += 5 * .7;
                player.CurrentPlayer.Skills.HealtCare[8].Cost += 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                player.CurrentPlayer.Skills.HealtCare[0].Cost += 5 * .8;
                player.CurrentPlayer.Skills.HealtCare[1].Cost += 5 * .8;
                player.CurrentPlayer.Skills.HealtCare[8].Cost += 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                player.CurrentPlayer.Skills.HealtCare[0].Cost += 5 * 1;
                player.CurrentPlayer.Skills.HealtCare[1].Cost += 5 * 1;
                player.CurrentPlayer.Skills.HealtCare[8].Cost += 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                player.CurrentPlayer.Skills.HealtCare[0].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.HealtCare[1].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.HealtCare[8].Cost += 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                player.CurrentPlayer.Skills.HealtCare[0].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.HealtCare[1].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.HealtCare[8].Cost += 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                player.CurrentPlayer.Skills.HealtCare[0].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.HealtCare[1].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.HealtCare[8].Cost += 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                player.CurrentPlayer.Skills.HealtCare[0].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.HealtCare[1].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.HealtCare[8].Cost += 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                player.CurrentPlayer.Skills.HealtCare[0].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.HealtCare[1].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.HealtCare[8].Cost += 4 * 1.5;
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                player.CurrentPlayer.Skills.HealtCare[2].Cost += 2 * .5;
                player.CurrentPlayer.Skills.HealtCare[12].Cost += 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                player.CurrentPlayer.Skills.HealtCare[2].Cost += 2 * .6;
                player.CurrentPlayer.Skills.HealtCare[12].Cost += 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                player.CurrentPlayer.Skills.HealtCare[2].Cost += 2 * .7;
                player.CurrentPlayer.Skills.HealtCare[12].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                player.CurrentPlayer.Skills.HealtCare[2].Cost += 2 * .7;
                player.CurrentPlayer.Skills.HealtCare[12].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                player.CurrentPlayer.Skills.HealtCare[2].Cost += 2 * 1;
                player.CurrentPlayer.Skills.HealtCare[12].Cost += 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                player.CurrentPlayer.Skills.HealtCare[2].Cost += 2 * 1.1;
                player.CurrentPlayer.Skills.HealtCare[12].Cost += 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                player.CurrentPlayer.Skills.HealtCare[2].Cost += 2 * 1.2;
                player.CurrentPlayer.Skills.HealtCare[12].Cost += 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                player.CurrentPlayer.Skills.HealtCare[2].Cost += 2 * 1.3;
                player.CurrentPlayer.Skills.HealtCare[12].Cost += 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                player.CurrentPlayer.Skills.HealtCare[2].Cost += 2 * 1.4;
                player.CurrentPlayer.Skills.HealtCare[12].Cost += 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                player.CurrentPlayer.Skills.HealtCare[2].Cost += 2 * 1.5;
                player.CurrentPlayer.Skills.HealtCare[12].Cost += 4 * 1.5;

            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * .5;
                player.CurrentPlayer.Skills.HealtCare[4].Cost += 5 * .5;
                player.CurrentPlayer.Skills.HealtCare[5].Cost += 5 * .5;
                player.CurrentPlayer.Skills.HealtCare[6].Cost += 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * .6;
                player.CurrentPlayer.Skills.HealtCare[4].Cost += 5 * .6;
                player.CurrentPlayer.Skills.HealtCare[5].Cost += 5 * .6;
                player.CurrentPlayer.Skills.HealtCare[6].Cost += 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * .7;
                player.CurrentPlayer.Skills.HealtCare[4].Cost += 5 * .7;
                player.CurrentPlayer.Skills.HealtCare[5].Cost += 5 * .7;
                player.CurrentPlayer.Skills.HealtCare[6].Cost += 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * .8;
                player.CurrentPlayer.Skills.HealtCare[4].Cost += 5 * .8;
                player.CurrentPlayer.Skills.HealtCare[5].Cost += 5 * .8;
                player.CurrentPlayer.Skills.HealtCare[6].Cost += 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1;
                player.CurrentPlayer.Skills.HealtCare[4].Cost += 5 * 1;
                player.CurrentPlayer.Skills.HealtCare[5].Cost += 5 * 1;
                player.CurrentPlayer.Skills.HealtCare[6].Cost += 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.HealtCare[4].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.HealtCare[5].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.HealtCare[6].Cost += 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.HealtCare[4].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.HealtCare[5].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.HealtCare[6].Cost += 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.HealtCare[4].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.HealtCare[5].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.HealtCare[6].Cost += 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.HealtCare[4].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.HealtCare[5].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.HealtCare[6].Cost += 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.HealtCare[4].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.HealtCare[5].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.HealtCare[6].Cost += 4 * 1.5;
            }


            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                player.CurrentPlayer.Skills.HealtCare[9].Cost += 4 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                player.CurrentPlayer.Skills.HealtCare[9].Cost += 4 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                player.CurrentPlayer.Skills.HealtCare[9].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                player.CurrentPlayer.Skills.HealtCare[9].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                player.CurrentPlayer.Skills.HealtCare[9].Cost += 4 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                player.CurrentPlayer.Skills.HealtCare[9].Cost += 4 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                player.CurrentPlayer.Skills.HealtCare[9].Cost += 4 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                player.CurrentPlayer.Skills.HealtCare[9].Cost += 4 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                player.CurrentPlayer.Skills.HealtCare[9].Cost += 4 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                player.CurrentPlayer.Skills.HealtCare[9].Cost += 4 * 1.5;


            }


        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.HumanResource) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                player.CurrentPlayer.Skills.HR[4].Cost += 4 * .5;
                player.CurrentPlayer.Skills.HR[10].Cost += 6 * .5;
                player.CurrentPlayer.Skills.HR[11].Cost += 4 * .5;
                player.CurrentPlayer.Skills.HR[14].Cost += 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                player.CurrentPlayer.Skills.HR[4].Cost += 4 * .6;
                player.CurrentPlayer.Skills.HR[10].Cost += 6 * .6;
                player.CurrentPlayer.Skills.HR[11].Cost += 4 * .6;
                player.CurrentPlayer.Skills.HR[14].Cost += 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                player.CurrentPlayer.Skills.HR[4].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HR[10].Cost += 6 * .7;
                player.CurrentPlayer.Skills.HR[11].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HR[14].Cost += 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                player.CurrentPlayer.Skills.HR[4].Cost += 4 * .8;
                player.CurrentPlayer.Skills.HR[10].Cost += 6 * .8;
                player.CurrentPlayer.Skills.HR[11].Cost += 4 * .8;
                player.CurrentPlayer.Skills.HR[14].Cost += 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                player.CurrentPlayer.Skills.HR[4].Cost += 4 * 1;
                player.CurrentPlayer.Skills.HR[10].Cost += 6 * 1;
                player.CurrentPlayer.Skills.HR[11].Cost += 4 * 1;
                player.CurrentPlayer.Skills.HR[14].Cost += 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                player.CurrentPlayer.Skills.HR[4].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.HR[10].Cost += 6 * 1.1;
                player.CurrentPlayer.Skills.HR[11].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.HR[14].Cost += 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                player.CurrentPlayer.Skills.HR[4].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.HR[10].Cost += 6 * 1.2;
                player.CurrentPlayer.Skills.HR[11].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.HR[14].Cost += 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                player.CurrentPlayer.Skills.HR[4].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.HR[10].Cost += 6 * 1.3;
                player.CurrentPlayer.Skills.HR[11].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.HR[14].Cost += 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                player.CurrentPlayer.Skills.HR[4].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.HR[10].Cost += 6 * 1.4;
                player.CurrentPlayer.Skills.HR[11].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.HR[14].Cost += 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                player.CurrentPlayer.Skills.HR[4].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.HR[10].Cost += 6 * 1.5;
                player.CurrentPlayer.Skills.HR[11].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.HR[14].Cost += 4 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                player.CurrentPlayer.Skills.HR[8].Cost += 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                player.CurrentPlayer.Skills.HR[8].Cost += 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                player.CurrentPlayer.Skills.HR[8].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                player.CurrentPlayer.Skills.HR[8].Cost += 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                player.CurrentPlayer.Skills.HR[8].Cost += 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                player.CurrentPlayer.Skills.HR[8].Cost += 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                player.CurrentPlayer.Skills.HR[8].Cost += 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                player.CurrentPlayer.Skills.HR[8].Cost += 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                player.CurrentPlayer.Skills.HR[8].Cost += 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                player.CurrentPlayer.Skills.HR[8].Cost += 4 * 1.5;

            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                player.CurrentPlayer.Skills.HR[5].Cost += 4 * .5;
                player.CurrentPlayer.Skills.HR[6].Cost += 4 * .5;
                player.CurrentPlayer.Skills.HR[7].Cost += 4 * .5;
                player.CurrentPlayer.Skills.HR[12].Cost += 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                player.CurrentPlayer.Skills.HR[5].Cost += 4 * .6;
                player.CurrentPlayer.Skills.HR[6].Cost += 4 * .6;
                player.CurrentPlayer.Skills.HR[7].Cost += 4 * .6;
                player.CurrentPlayer.Skills.HR[12].Cost += 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                player.CurrentPlayer.Skills.HR[5].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HR[6].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HR[7].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HR[12].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                player.CurrentPlayer.Skills.HR[5].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HR[6].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HR[7].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HR[12].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                player.CurrentPlayer.Skills.HR[5].Cost += 4 * 1;
                player.CurrentPlayer.Skills.HR[6].Cost += 4 * 1;
                player.CurrentPlayer.Skills.HR[7].Cost += 4 * 1;
                player.CurrentPlayer.Skills.HR[12].Cost += 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                player.CurrentPlayer.Skills.HR[5].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.HR[6].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.HR[7].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.HR[12].Cost += 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                player.CurrentPlayer.Skills.HR[5].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.HR[6].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.HR[7].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.HR[12].Cost += 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                player.CurrentPlayer.Skills.HR[5].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.HR[6].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.HR[7].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.HR[12].Cost += 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                player.CurrentPlayer.Skills.HR[5].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.HR[6].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.HR[7].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.HR[12].Cost += 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                player.CurrentPlayer.Skills.HR[5].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.HR[6].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.HR[7].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.HR[12].Cost += 4 * 1.5;

            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                player.CurrentPlayer.Skills.HR[1].Cost += 6 * .5;
                player.CurrentPlayer.Skills.HR[2].Cost += 4 * .5;
                player.CurrentPlayer.Skills.HR[3].Cost += 4 * .5;
                player.CurrentPlayer.Skills.HR[13].Cost += 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                player.CurrentPlayer.Skills.HR[1].Cost += 6 * .6;
                player.CurrentPlayer.Skills.HR[2].Cost += 4 * .6;
                player.CurrentPlayer.Skills.HR[3].Cost += 4 * .6;
                player.CurrentPlayer.Skills.HR[13].Cost += 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                player.CurrentPlayer.Skills.HR[1].Cost += 6 * .7;
                player.CurrentPlayer.Skills.HR[2].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HR[3].Cost += 4 * .7;
                player.CurrentPlayer.Skills.HR[13].Cost += 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                player.CurrentPlayer.Skills.HR[1].Cost += 6 * .8;
                player.CurrentPlayer.Skills.HR[2].Cost += 4 * .8;
                player.CurrentPlayer.Skills.HR[3].Cost += 4 * .8;
                player.CurrentPlayer.Skills.HR[13].Cost += 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1;
                player.CurrentPlayer.Skills.HR[2].Cost += 4 * 1;
                player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1;
                player.CurrentPlayer.Skills.HR[13].Cost += 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1.1;
                player.CurrentPlayer.Skills.HR[2].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.HR[13].Cost += 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1.2;
                player.CurrentPlayer.Skills.HR[2].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.HR[13].Cost += 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1.3;
                player.CurrentPlayer.Skills.HR[2].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.HR[13].Cost += 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1.4;
                player.CurrentPlayer.Skills.HR[2].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.HR[13].Cost += 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1.5;
                player.CurrentPlayer.Skills.HR[2].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.HR[13].Cost += 4 * 1.5;
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                player.CurrentPlayer.Skills.HR[0].Cost += 5 * .5;
                player.CurrentPlayer.Skills.HR[9].Cost += 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                player.CurrentPlayer.Skills.HR[0].Cost += 5 * .6;
                player.CurrentPlayer.Skills.HR[9].Cost += 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                player.CurrentPlayer.Skills.HR[0].Cost += 5 * .7;
                player.CurrentPlayer.Skills.HR[9].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                player.CurrentPlayer.Skills.HR[0].Cost += 5 * .8;
                player.CurrentPlayer.Skills.HR[9].Cost += 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                player.CurrentPlayer.Skills.HR[0].Cost += 5 * 1;
                player.CurrentPlayer.Skills.HR[9].Cost += 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                player.CurrentPlayer.Skills.HR[0].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.HR[9].Cost += 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                player.CurrentPlayer.Skills.HR[0].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.HR[9].Cost += 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                player.CurrentPlayer.Skills.HR[0].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.HR[9].Cost += 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                player.CurrentPlayer.Skills.HR[0].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.HR[9].Cost += 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                player.CurrentPlayer.Skills.HR[0].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.HR[9].Cost += 4 * 1.5;
            }
        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.InformationTechnology) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                player.CurrentPlayer.Skills.IT[3].Cost += 6 * .5;
                player.CurrentPlayer.Skills.IT[6].Cost += 5 * .5;
                player.CurrentPlayer.Skills.IT[7].Cost += 6 * .5;
                player.CurrentPlayer.Skills.IT[9].Cost += 4 * .5;
                player.CurrentPlayer.Skills.IT[11].Cost += 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                player.CurrentPlayer.Skills.IT[3].Cost += 6 * .6;
                player.CurrentPlayer.Skills.IT[6].Cost += 5 * .6;
                player.CurrentPlayer.Skills.IT[7].Cost += 6 * .6;
                player.CurrentPlayer.Skills.IT[9].Cost += 4 * .6;
                player.CurrentPlayer.Skills.IT[11].Cost += 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                player.CurrentPlayer.Skills.IT[3].Cost += 6 * .7;
                player.CurrentPlayer.Skills.IT[6].Cost += 5 * .7;
                player.CurrentPlayer.Skills.IT[7].Cost += 6 * .7;
                player.CurrentPlayer.Skills.IT[9].Cost += 4 * .7;
                player.CurrentPlayer.Skills.IT[11].Cost += 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                player.CurrentPlayer.Skills.IT[3].Cost += 6 * .8;
                player.CurrentPlayer.Skills.IT[6].Cost += 5 * .8;
                player.CurrentPlayer.Skills.IT[7].Cost += 6 * .8;
                player.CurrentPlayer.Skills.IT[9].Cost += 4 * .8;
                player.CurrentPlayer.Skills.IT[11].Cost += 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1;
                player.CurrentPlayer.Skills.IT[6].Cost += 5 * 1;
                player.CurrentPlayer.Skills.IT[7].Cost += 6 * 1;
                player.CurrentPlayer.Skills.IT[9].Cost += 4 * 1;
                player.CurrentPlayer.Skills.IT[11].Cost += 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1.1;
                player.CurrentPlayer.Skills.IT[6].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.IT[7].Cost += 6 * 1.1;
                player.CurrentPlayer.Skills.IT[9].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.IT[11].Cost += 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1.2;
                player.CurrentPlayer.Skills.IT[6].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.IT[7].Cost += 6 * 1.2;
                player.CurrentPlayer.Skills.IT[9].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.IT[11].Cost += 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1.3;
                player.CurrentPlayer.Skills.IT[6].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.IT[7].Cost += 6 * 1.3;
                player.CurrentPlayer.Skills.IT[9].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.IT[11].Cost += 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1.4;
                player.CurrentPlayer.Skills.IT[6].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.IT[7].Cost += 6 * 1.4;
                player.CurrentPlayer.Skills.IT[9].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.IT[11].Cost += 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1.5;
                player.CurrentPlayer.Skills.IT[6].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.IT[7].Cost += 6 * 1.5;
                player.CurrentPlayer.Skills.IT[9].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.IT[11].Cost += 4 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
                player.CurrentPlayer.Skills.IT[4].Cost += 6 * .5;
                player.CurrentPlayer.Skills.IT[8].Cost += 5 * .5;
                player.CurrentPlayer.Skills.IT[12].Cost += 4 * .5;
                player.CurrentPlayer.Skills.IT[13].Cost += 3 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                player.CurrentPlayer.Skills.IT[4].Cost += 6 * .6;
                player.CurrentPlayer.Skills.IT[8].Cost += 5 * .6;
                player.CurrentPlayer.Skills.IT[12].Cost += 4 * .6;
                player.CurrentPlayer.Skills.IT[13].Cost += 3 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                player.CurrentPlayer.Skills.IT[4].Cost += 6 * .7;
                player.CurrentPlayer.Skills.IT[8].Cost += 5 * .7;
                player.CurrentPlayer.Skills.IT[12].Cost += 4 * .7;
                player.CurrentPlayer.Skills.IT[13].Cost += 3 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                player.CurrentPlayer.Skills.IT[4].Cost += 6 * .8;
                player.CurrentPlayer.Skills.IT[8].Cost += 5 * .8;
                player.CurrentPlayer.Skills.IT[12].Cost += 4 * .8;
                player.CurrentPlayer.Skills.IT[13].Cost += 3 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1;
                player.CurrentPlayer.Skills.IT[8].Cost += 5 * 1;
                player.CurrentPlayer.Skills.IT[12].Cost += 4 * 1;
                player.CurrentPlayer.Skills.IT[13].Cost += 3 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1.1;
                player.CurrentPlayer.Skills.IT[8].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.IT[12].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.IT[13].Cost += 3 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1.2;
                player.CurrentPlayer.Skills.IT[8].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.IT[12].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.IT[13].Cost += 3 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1.3;
                player.CurrentPlayer.Skills.IT[8].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.IT[12].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.IT[13].Cost += 3 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1.4;
                player.CurrentPlayer.Skills.IT[8].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.IT[12].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.IT[13].Cost += 3 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1.5;
                player.CurrentPlayer.Skills.IT[8].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.IT[12].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.IT[13].Cost += 3 * 1.5;
            }




            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
                player.CurrentPlayer.Skills.IT[1].Cost += 4 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                player.CurrentPlayer.Skills.IT[1].Cost += 4 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                player.CurrentPlayer.Skills.IT[1].Cost += 4 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                player.CurrentPlayer.Skills.IT[1].Cost += 4 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                player.CurrentPlayer.Skills.IT[1].Cost += 4 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                player.CurrentPlayer.Skills.IT[1].Cost += 4 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                player.CurrentPlayer.Skills.IT[1].Cost += 4 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                player.CurrentPlayer.Skills.IT[1].Cost += 4 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                player.CurrentPlayer.Skills.IT[1].Cost += 4 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                player.CurrentPlayer.Skills.IT[1].Cost += 4 * 1.5;


            }



            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                player.CurrentPlayer.Skills.IT[2].Cost += 6 * .5;
                player.CurrentPlayer.Skills.IT[10].Cost += 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                player.CurrentPlayer.Skills.IT[2].Cost += 6 * .6;
                player.CurrentPlayer.Skills.IT[10].Cost += 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                player.CurrentPlayer.Skills.IT[2].Cost += 6 * .7;
                player.CurrentPlayer.Skills.IT[10].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                player.CurrentPlayer.Skills.IT[2].Cost += 6 * .8;
                player.CurrentPlayer.Skills.IT[10].Cost += 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1;
                player.CurrentPlayer.Skills.IT[10].Cost += 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1.1;
                player.CurrentPlayer.Skills.IT[10].Cost += 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1.2;
                player.CurrentPlayer.Skills.IT[10].Cost += 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1.3;
                player.CurrentPlayer.Skills.IT[10].Cost += 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1.4;
                player.CurrentPlayer.Skills.IT[10].Cost += 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1.5;
                player.CurrentPlayer.Skills.IT[10].Cost += 4 * 1.5;

            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                player.CurrentPlayer.Skills.IT[0].Cost += 5 * .5;
                player.CurrentPlayer.Skills.IT[5].Cost += 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                player.CurrentPlayer.Skills.IT[0].Cost += 5 * .6;
                player.CurrentPlayer.Skills.IT[5].Cost += 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                player.CurrentPlayer.Skills.IT[0].Cost += 5 * .7;
                player.CurrentPlayer.Skills.IT[5].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                player.CurrentPlayer.Skills.IT[0].Cost += 5 * .8;
                player.CurrentPlayer.Skills.IT[5].Cost += 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                player.CurrentPlayer.Skills.IT[0].Cost += 5 * 1;
                player.CurrentPlayer.Skills.IT[5].Cost += 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                player.CurrentPlayer.Skills.IT[0].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.IT[5].Cost += 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                player.CurrentPlayer.Skills.IT[0].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.IT[5].Cost += 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                player.CurrentPlayer.Skills.IT[0].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.IT[5].Cost += 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                player.CurrentPlayer.Skills.IT[0].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.IT[5].Cost += 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                player.CurrentPlayer.Skills.IT[0].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.IT[5].Cost += 4 * 1.5;

            }
        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.Media) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                player.CurrentPlayer.Skills.Media[9].Cost += 3 * .5;
                player.CurrentPlayer.Skills.Media[10].Cost += 3 * .5;
                player.CurrentPlayer.Skills.Media[11].Cost += 3 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                player.CurrentPlayer.Skills.Media[9].Cost += 3 * .6;
                player.CurrentPlayer.Skills.Media[10].Cost += 3 * .6;
                player.CurrentPlayer.Skills.Media[11].Cost += 3 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                player.CurrentPlayer.Skills.Media[9].Cost += 3 * .7;
                player.CurrentPlayer.Skills.Media[10].Cost += 3 * .7;
                player.CurrentPlayer.Skills.Media[11].Cost += 3 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                player.CurrentPlayer.Skills.Media[9].Cost += 3 * .8;
                player.CurrentPlayer.Skills.Media[10].Cost += 3 * .8;
                player.CurrentPlayer.Skills.Media[11].Cost += 3 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                player.CurrentPlayer.Skills.Media[9].Cost += 3 * 1;
                player.CurrentPlayer.Skills.Media[10].Cost += 3 * 1;
                player.CurrentPlayer.Skills.Media[11].Cost += 3 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                player.CurrentPlayer.Skills.Media[9].Cost += 3 * 1.1;
                player.CurrentPlayer.Skills.Media[10].Cost += 3 * 1.1;
                player.CurrentPlayer.Skills.Media[11].Cost += 3 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                player.CurrentPlayer.Skills.Media[9].Cost += 3 * 1.2;
                player.CurrentPlayer.Skills.Media[10].Cost += 3 * 1.2;
                player.CurrentPlayer.Skills.Media[11].Cost += 3 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                player.CurrentPlayer.Skills.Media[9].Cost += 3 * 1.3;
                player.CurrentPlayer.Skills.Media[10].Cost += 3 * 1.3;
                player.CurrentPlayer.Skills.Media[11].Cost += 3 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                player.CurrentPlayer.Skills.Media[9].Cost += 3 * 1.4;
                player.CurrentPlayer.Skills.Media[10].Cost += 3 * 1.4;
                player.CurrentPlayer.Skills.Media[11].Cost += 3 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                player.CurrentPlayer.Skills.Media[9].Cost += 3 * 1.5;
                player.CurrentPlayer.Skills.Media[10].Cost += 3 * 1.5;
                player.CurrentPlayer.Skills.Media[11].Cost += 3 * 1.5;

            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
                player.CurrentPlayer.Skills.Media[1].Cost += 4 * .5;
                player.CurrentPlayer.Skills.Media[2].Cost += 2 * .5;
                player.CurrentPlayer.Skills.Media[7].Cost += 4 * .5;
                player.CurrentPlayer.Skills.Media[8].Cost += 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                player.CurrentPlayer.Skills.Media[1].Cost += 4 * .6;
                player.CurrentPlayer.Skills.Media[2].Cost += 2 * .6;
                player.CurrentPlayer.Skills.Media[7].Cost += 4 * .6;
                player.CurrentPlayer.Skills.Media[8].Cost += 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                player.CurrentPlayer.Skills.Media[1].Cost += 4 * .7;
                player.CurrentPlayer.Skills.Media[2].Cost += 2 * .7;
                player.CurrentPlayer.Skills.Media[7].Cost += 4 * .7;
                player.CurrentPlayer.Skills.Media[8].Cost += 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                player.CurrentPlayer.Skills.Media[1].Cost += 4 * .8;
                player.CurrentPlayer.Skills.Media[2].Cost += 2 * .8;
                player.CurrentPlayer.Skills.Media[7].Cost += 4 * .8;
                player.CurrentPlayer.Skills.Media[8].Cost += 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                player.CurrentPlayer.Skills.Media[1].Cost += 4 * 1;
                player.CurrentPlayer.Skills.Media[2].Cost += 2 * 1;
                player.CurrentPlayer.Skills.Media[7].Cost += 4 * 1;
                player.CurrentPlayer.Skills.Media[8].Cost += 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                player.CurrentPlayer.Skills.Media[1].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.Media[2].Cost += 2 * 1.1;
                player.CurrentPlayer.Skills.Media[7].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.Media[8].Cost += 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                player.CurrentPlayer.Skills.Media[1].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.Media[2].Cost += 2 * 1.2;
                player.CurrentPlayer.Skills.Media[7].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.Media[8].Cost += 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                player.CurrentPlayer.Skills.Media[1].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.Media[2].Cost += 2 * 1.3;
                player.CurrentPlayer.Skills.Media[7].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.Media[8].Cost += 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                player.CurrentPlayer.Skills.Media[1].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.Media[2].Cost += 2 * 1.4;
                player.CurrentPlayer.Skills.Media[7].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.Media[8].Cost += 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                player.CurrentPlayer.Skills.Media[1].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.Media[2].Cost += 2 * 1.5;
                player.CurrentPlayer.Skills.Media[7].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.Media[8].Cost += 4 * 1.5;
            }








            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                player.CurrentPlayer.Skills.Media[0].Cost += 6 * .5;
                player.CurrentPlayer.Skills.Media[4].Cost += 3 * .5;
                player.CurrentPlayer.Skills.Media[5].Cost += 6 * .5;
                player.CurrentPlayer.Skills.Media[12].Cost += 3 * .5;
                player.CurrentPlayer.Skills.Media[13].Cost += 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                player.CurrentPlayer.Skills.Media[0].Cost += 6 * .6;
                player.CurrentPlayer.Skills.Media[4].Cost += 3 * .6;
                player.CurrentPlayer.Skills.Media[5].Cost += 6 * .6;
                player.CurrentPlayer.Skills.Media[12].Cost += 3 * .6;
                player.CurrentPlayer.Skills.Media[13].Cost += 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                player.CurrentPlayer.Skills.Media[0].Cost += 6 * .7;
                player.CurrentPlayer.Skills.Media[4].Cost += 3 * .7;
                player.CurrentPlayer.Skills.Media[5].Cost += 6 * .7;
                player.CurrentPlayer.Skills.Media[12].Cost += 3 * .7;
                player.CurrentPlayer.Skills.Media[13].Cost += 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                player.CurrentPlayer.Skills.Media[0].Cost += 6 * .8;
                player.CurrentPlayer.Skills.Media[4].Cost += 3 * .8;
                player.CurrentPlayer.Skills.Media[5].Cost += 6 * .8;
                player.CurrentPlayer.Skills.Media[12].Cost += 3 * .8;
                player.CurrentPlayer.Skills.Media[13].Cost += 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1;
                player.CurrentPlayer.Skills.Media[4].Cost += 3 * 1;
                player.CurrentPlayer.Skills.Media[5].Cost += 6 * 1;
                player.CurrentPlayer.Skills.Media[12].Cost += 3 * 1;
                player.CurrentPlayer.Skills.Media[13].Cost += 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1.1;
                player.CurrentPlayer.Skills.Media[4].Cost += 3 * 1.1;
                player.CurrentPlayer.Skills.Media[5].Cost += 6 * 1.1;
                player.CurrentPlayer.Skills.Media[12].Cost += 3 * 1.1;
                player.CurrentPlayer.Skills.Media[13].Cost += 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1.2;
                player.CurrentPlayer.Skills.Media[4].Cost += 3 * 1.2;
                player.CurrentPlayer.Skills.Media[5].Cost += 6 * 1.2;
                player.CurrentPlayer.Skills.Media[12].Cost += 3 * 1.2;
                player.CurrentPlayer.Skills.Media[13].Cost += 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1.3;
                player.CurrentPlayer.Skills.Media[4].Cost += 3 * 1.3;
                player.CurrentPlayer.Skills.Media[5].Cost += 6 * 1.3;
                player.CurrentPlayer.Skills.Media[12].Cost += 3 * 1.3;
                player.CurrentPlayer.Skills.Media[13].Cost += 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1.4;
                player.CurrentPlayer.Skills.Media[4].Cost += 3 * 1.4;
                player.CurrentPlayer.Skills.Media[5].Cost += 6 * 1.4;
                player.CurrentPlayer.Skills.Media[12].Cost += 3 * 1.4;
                player.CurrentPlayer.Skills.Media[13].Cost += 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1.5;
                player.CurrentPlayer.Skills.Media[4].Cost += 3 * 1.5;
                player.CurrentPlayer.Skills.Media[5].Cost += 6 * 1.5;
                player.CurrentPlayer.Skills.Media[12].Cost += 3 * 1.5;
                player.CurrentPlayer.Skills.Media[13].Cost += 4 * 1.5;
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                player.CurrentPlayer.Skills.Media[3].Cost += 4 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                player.CurrentPlayer.Skills.Media[3].Cost += 4 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                player.CurrentPlayer.Skills.Media[3].Cost += 4 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                player.CurrentPlayer.Skills.Media[3].Cost += 4 * .8;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                player.CurrentPlayer.Skills.Media[3].Cost += 4 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                player.CurrentPlayer.Skills.Media[3].Cost += 4 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                player.CurrentPlayer.Skills.Media[3].Cost += 4 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                player.CurrentPlayer.Skills.Media[3].Cost += 4 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                player.CurrentPlayer.Skills.Media[3].Cost += 4 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                player.CurrentPlayer.Skills.Media[3].Cost += 4 * 1.5;


            }



            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                player.CurrentPlayer.Skills.Media[6].Cost += 3 * .5;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                player.CurrentPlayer.Skills.Media[6].Cost += 3 * .6;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                player.CurrentPlayer.Skills.Media[6].Cost += 3 * .7;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                player.CurrentPlayer.Skills.Media[6].Cost += 3 * .8;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                player.CurrentPlayer.Skills.Media[6].Cost += 3 * 1;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                player.CurrentPlayer.Skills.Media[6].Cost += 3 * 1.1;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                player.CurrentPlayer.Skills.Media[6].Cost += 3 * 1.2;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                player.CurrentPlayer.Skills.Media[6].Cost += 3 * 1.3;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                player.CurrentPlayer.Skills.Media[6].Cost += 3 * 1.4;


            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                player.CurrentPlayer.Skills.Media[6].Cost += 3 * 1.5;


            }
        } 
        
        else if (player.CurrentPlayer.Course == AppData.Fields.Retail) {
            if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
                player.CurrentPlayer.Skills.Retail[1].Cost += 5 * .5;
                player.CurrentPlayer.Skills.Retail[3].Cost += 5 * .5;
                player.CurrentPlayer.Skills.Retail[7].Cost += 4 * .5;
                player.CurrentPlayer.Skills.Retail[11].Cost += 4 * .5;
                player.CurrentPlayer.Skills.Retail[12].Cost += 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
                player.CurrentPlayer.Skills.Retail[1].Cost += 5 * .6;
                player.CurrentPlayer.Skills.Retail[3].Cost += 5 * .6;
                player.CurrentPlayer.Skills.Retail[7].Cost += 4 * .6;
                player.CurrentPlayer.Skills.Retail[11].Cost += 4 * .6;
                player.CurrentPlayer.Skills.Retail[12].Cost += 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
                player.CurrentPlayer.Skills.Retail[1].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Retail[3].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Retail[7].Cost += 4 * .7;
                player.CurrentPlayer.Skills.Retail[11].Cost += 4 * .7;
                player.CurrentPlayer.Skills.Retail[12].Cost += 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
                player.CurrentPlayer.Skills.Retail[1].Cost += 5 * .8;
                player.CurrentPlayer.Skills.Retail[3].Cost += 5 * .8;
                player.CurrentPlayer.Skills.Retail[7].Cost += 4 * .8;
                player.CurrentPlayer.Skills.Retail[11].Cost += 4 * .8;
                player.CurrentPlayer.Skills.Retail[12].Cost += 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
                player.CurrentPlayer.Skills.Retail[1].Cost += 5 * 1;
                player.CurrentPlayer.Skills.Retail[3].Cost += 5 * 1;
                player.CurrentPlayer.Skills.Retail[7].Cost += 4 * 1;
                player.CurrentPlayer.Skills.Retail[11].Cost += 4 * 1;
                player.CurrentPlayer.Skills.Retail[12].Cost += 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
                player.CurrentPlayer.Skills.Retail[1].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.Retail[3].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.Retail[7].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.Retail[11].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.Retail[12].Cost += 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
                player.CurrentPlayer.Skills.Retail[1].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.Retail[3].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.Retail[7].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.Retail[11].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.Retail[12].Cost += 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
                player.CurrentPlayer.Skills.Retail[1].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.Retail[3].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.Retail[7].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.Retail[11].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.Retail[12].Cost += 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
                player.CurrentPlayer.Skills.Retail[1].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.Retail[3].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.Retail[7].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.Retail[11].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.Retail[12].Cost += 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
                player.CurrentPlayer.Skills.Retail[1].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.Retail[3].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.Retail[7].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.Retail[11].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.Retail[12].Cost += 4 * 1.5;
            }
            if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {

                player.CurrentPlayer.Skills.Retail[8].Cost += 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
                player.CurrentPlayer.Skills.Retail[8].Cost += 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
                player.CurrentPlayer.Skills.Retail[8].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
                player.CurrentPlayer.Skills.Retail[8].Cost += 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
                player.CurrentPlayer.Skills.Retail[8].Cost += 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
                player.CurrentPlayer.Skills.Retail[8].Cost += 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
                player.CurrentPlayer.Skills.Retail[8].Cost += 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
                player.CurrentPlayer.Skills.Retail[8].Cost += 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
                player.CurrentPlayer.Skills.Retail[8].Cost += 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
                player.CurrentPlayer.Skills.Retail[8].Cost += 4 * 1.5;

            }








            if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
                player.CurrentPlayer.Skills.Retail[4].Cost += 6 * .5;
                player.CurrentPlayer.Skills.Retail[6].Cost += 4 * .5;
                player.CurrentPlayer.Skills.Retail[13].Cost += 4 * .5;
                player.CurrentPlayer.Skills.Retail[14].Cost += 6 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
                player.CurrentPlayer.Skills.Retail[4].Cost += 6 * .6;
                player.CurrentPlayer.Skills.Retail[6].Cost += 4 * .6;
                player.CurrentPlayer.Skills.Retail[13].Cost += 4 * .6;
                player.CurrentPlayer.Skills.Retail[14].Cost += 6 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
                player.CurrentPlayer.Skills.Retail[4].Cost += 6 * .7;
                player.CurrentPlayer.Skills.Retail[6].Cost += 4 * .7;
                player.CurrentPlayer.Skills.Retail[13].Cost += 4 * .7;
                player.CurrentPlayer.Skills.Retail[14].Cost += 6 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
                player.CurrentPlayer.Skills.Retail[4].Cost += 6 * .8;
                player.CurrentPlayer.Skills.Retail[6].Cost += 4 * .8;
                player.CurrentPlayer.Skills.Retail[13].Cost += 4 * .8;
                player.CurrentPlayer.Skills.Retail[14].Cost += 6 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
                player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1;
                player.CurrentPlayer.Skills.Retail[6].Cost += 4 * 1;
                player.CurrentPlayer.Skills.Retail[13].Cost += 4 * 1;
                player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
                player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1.1;
                player.CurrentPlayer.Skills.Retail[6].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.Retail[13].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
                player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1.2;
                player.CurrentPlayer.Skills.Retail[6].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.Retail[13].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
                player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1.3;
                player.CurrentPlayer.Skills.Retail[6].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.Retail[13].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
                player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1.4;
                player.CurrentPlayer.Skills.Retail[6].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.Retail[13].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
                player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1.5;
                player.CurrentPlayer.Skills.Retail[6].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.Retail[13].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1.5;
            }

            if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
                player.CurrentPlayer.Skills.Retail[0].Cost += 5 * .5;
                player.CurrentPlayer.Skills.Retail[2].Cost += 5 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
                player.CurrentPlayer.Skills.Retail[0].Cost += 5 * .6;
                player.CurrentPlayer.Skills.Retail[2].Cost += 5 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
                player.CurrentPlayer.Skills.Retail[0].Cost += 5 * .7;
                player.CurrentPlayer.Skills.Retail[2].Cost += 5 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
                player.CurrentPlayer.Skills.Retail[0].Cost += 5 * .8;
                player.CurrentPlayer.Skills.Retail[2].Cost += 5 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
                player.CurrentPlayer.Skills.Retail[0].Cost += 5 * 1;
                player.CurrentPlayer.Skills.Retail[2].Cost += 5 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
                player.CurrentPlayer.Skills.Retail[0].Cost += 5 * 1.1;
                player.CurrentPlayer.Skills.Retail[2].Cost += 5 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
                player.CurrentPlayer.Skills.Retail[0].Cost += 5 * 1.2;
                player.CurrentPlayer.Skills.Retail[2].Cost += 5 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
                player.CurrentPlayer.Skills.Retail[0].Cost += 5 * 1.3;
                player.CurrentPlayer.Skills.Retail[2].Cost += 5 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
                player.CurrentPlayer.Skills.Retail[0].Cost += 5 * 1.4;
                player.CurrentPlayer.Skills.Retail[2].Cost += 5 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
                player.CurrentPlayer.Skills.Retail[0].Cost += 5 * 1.5;
                player.CurrentPlayer.Skills.Retail[2].Cost += 5 * 1.5;
            }



            if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
                player.CurrentPlayer.Skills.Retail[5].Cost += 4 * .5;
                player.CurrentPlayer.Skills.Retail[9].Cost += 4 * .5;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
                player.CurrentPlayer.Skills.Retail[5].Cost += 4 * .6;
                player.CurrentPlayer.Skills.Retail[9].Cost += 4 * .6;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
                player.CurrentPlayer.Skills.Retail[5].Cost += 4 * .7;
                player.CurrentPlayer.Skills.Retail[9].Cost += 4 * .7;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
                player.CurrentPlayer.Skills.Retail[5].Cost += 4 * .8;
                player.CurrentPlayer.Skills.Retail[9].Cost += 4 * .8;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
                player.CurrentPlayer.Skills.Retail[5].Cost += 4 * 1;
                player.CurrentPlayer.Skills.Retail[9].Cost += 4 * 1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
                player.CurrentPlayer.Skills.Retail[5].Cost += 4 * 1.1;
                player.CurrentPlayer.Skills.Retail[9].Cost += 4 * 1.1;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
                player.CurrentPlayer.Skills.Retail[5].Cost += 4 * 1.2;
                player.CurrentPlayer.Skills.Retail[9].Cost += 4 * 1.2;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
                player.CurrentPlayer.Skills.Retail[5].Cost += 4 * 1.3;
                player.CurrentPlayer.Skills.Retail[9].Cost += 4 * 1.3;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
                player.CurrentPlayer.Skills.Retail[5].Cost += 4 * 1.4;
                player.CurrentPlayer.Skills.Retail[9].Cost += 4 * 1.4;
            } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
                player.CurrentPlayer.Skills.Retail[5].Cost += 4 * 1.5;
                player.CurrentPlayer.Skills.Retail[9].Cost += 4 * 1.5;
            }



            if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {

                player.CurrentPlayer.Skills.Retail[10].Cost += 4 * .5;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
                player.CurrentPlayer.Skills.Retail[10].Cost += 4 * .6;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
                player.CurrentPlayer.Skills.Retail[10].Cost += 4 * .7;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
                player.CurrentPlayer.Skills.Retail[10].Cost += 4 * .8;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
                player.CurrentPlayer.Skills.Retail[10].Cost += 4 * 1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
                player.CurrentPlayer.Skills.Retail[10].Cost += 4 * 1.1;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
                player.CurrentPlayer.Skills.Retail[10].Cost += 4 * 1.2;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
                player.CurrentPlayer.Skills.Retail[10].Cost += 4 * 1.3;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
                player.CurrentPlayer.Skills.Retail[10].Cost += 4 * 1.4;

            } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
                player.CurrentPlayer.Skills.Retail[10].Cost += 4 * 1.5;

            }
        }
    }
    */



    //public void PhDPointsCalculatios() {
    //    Debug.Log("War gya in start");
    //    if (player.CurrentPlayer.Course == AppData.Fields.Accountancy) {
    //        Debug.Log("War gya Accontancy");
    //        if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
    //            Debug.Log("War gya");
    //            player.CurrentPlayer.Skills.Accountacy[0].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Accountacy[1].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * .5;
    //            player.CurrentPlayer.Skills.Accountacy[8].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Accountacy[9].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
    //            player.CurrentPlayer.Skills.Accountacy[0].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Accountacy[1].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * .6;
    //            player.CurrentPlayer.Skills.Accountacy[8].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Accountacy[9].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
    //            player.CurrentPlayer.Skills.Accountacy[0].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[1].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[8].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[9].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
    //            player.CurrentPlayer.Skills.Accountacy[0].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Accountacy[1].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * .8;
    //            player.CurrentPlayer.Skills.Accountacy[8].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Accountacy[9].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
    //            player.CurrentPlayer.Skills.Accountacy[0].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Accountacy[1].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1;
    //            player.CurrentPlayer.Skills.Accountacy[8].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Accountacy[9].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
    //            player.CurrentPlayer.Skills.Accountacy[0].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Accountacy[1].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1.1;
    //            player.CurrentPlayer.Skills.Accountacy[8].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Accountacy[9].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
    //            player.CurrentPlayer.Skills.Accountacy[0].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Accountacy[1].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1.2;
    //            player.CurrentPlayer.Skills.Accountacy[8].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Accountacy[9].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
    //            player.CurrentPlayer.Skills.Accountacy[0].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Accountacy[1].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1.3;
    //            player.CurrentPlayer.Skills.Accountacy[8].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Accountacy[9].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
    //            player.CurrentPlayer.Skills.Accountacy[0].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Accountacy[1].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1.4;
    //            player.CurrentPlayer.Skills.Accountacy[8].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Accountacy[9].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
    //            player.CurrentPlayer.Skills.Accountacy[0].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Accountacy[1].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Accountacy[5].Cost += 4 * 1.5;
    //            player.CurrentPlayer.Skills.Accountacy[8].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Accountacy[9].Cost += 6 * 1.5;
    //        }
    //        if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
    //            player.CurrentPlayer.Skills.Accountacy[2].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Accountacy[7].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
    //            player.CurrentPlayer.Skills.Accountacy[2].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Accountacy[7].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
    //            player.CurrentPlayer.Skills.Accountacy[2].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[7].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
    //            player.CurrentPlayer.Skills.Accountacy[2].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Accountacy[7].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
    //            player.CurrentPlayer.Skills.Accountacy[2].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Accountacy[7].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
    //            player.CurrentPlayer.Skills.Accountacy[2].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Accountacy[7].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
    //            player.CurrentPlayer.Skills.Accountacy[2].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Accountacy[7].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
    //            player.CurrentPlayer.Skills.Accountacy[2].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Accountacy[7].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
    //            player.CurrentPlayer.Skills.Accountacy[2].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Accountacy[7].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
    //            player.CurrentPlayer.Skills.Accountacy[2].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Accountacy[7].Cost += 6 * 1.5;
    //        }




    //        if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
    //            player.CurrentPlayer.Skills.Accountacy[4].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Accountacy[6].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Accountacy[11].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Accountacy[12].Cost += 0 * .5;
    //            player.CurrentPlayer.Skills.Accountacy[13].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
    //            player.CurrentPlayer.Skills.Accountacy[4].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Accountacy[6].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Accountacy[11].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Accountacy[12].Cost += 0 * .6;
    //            player.CurrentPlayer.Skills.Accountacy[13].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
    //            player.CurrentPlayer.Skills.Accountacy[4].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[6].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[11].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[12].Cost += 0 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[13].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
    //            player.CurrentPlayer.Skills.Accountacy[4].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[6].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[11].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[12].Cost += 0 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[13].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
    //            player.CurrentPlayer.Skills.Accountacy[4].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Accountacy[6].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Accountacy[11].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Accountacy[12].Cost += 0 * 1;
    //            player.CurrentPlayer.Skills.Accountacy[13].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
    //            player.CurrentPlayer.Skills.Accountacy[4].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Accountacy[6].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Accountacy[11].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Accountacy[12].Cost += 0 * 1.1;
    //            player.CurrentPlayer.Skills.Accountacy[13].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
    //            player.CurrentPlayer.Skills.Accountacy[4].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Accountacy[6].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Accountacy[11].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Accountacy[12].Cost += 0 * 1.2;
    //            player.CurrentPlayer.Skills.Accountacy[13].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
    //            player.CurrentPlayer.Skills.Accountacy[4].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Accountacy[6].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Accountacy[11].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Accountacy[12].Cost += 0 * 1.3;
    //            player.CurrentPlayer.Skills.Accountacy[13].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
    //            player.CurrentPlayer.Skills.Accountacy[4].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Accountacy[6].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Accountacy[11].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Accountacy[12].Cost += 0 * 1.4;
    //            player.CurrentPlayer.Skills.Accountacy[13].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
    //            player.CurrentPlayer.Skills.Accountacy[4].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Accountacy[6].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Accountacy[11].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Accountacy[12].Cost += 0 * 1.5;
    //            player.CurrentPlayer.Skills.Accountacy[13].Cost += 6 * 1.5;
    //        }
    //        if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
    //            player.CurrentPlayer.Skills.Accountacy[3].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Accountacy[10].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
    //            player.CurrentPlayer.Skills.Accountacy[3].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Accountacy[10].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
    //            player.CurrentPlayer.Skills.Accountacy[3].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Accountacy[10].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
    //            player.CurrentPlayer.Skills.Accountacy[3].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Accountacy[10].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
    //            player.CurrentPlayer.Skills.Accountacy[3].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Accountacy[10].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
    //            player.CurrentPlayer.Skills.Accountacy[3].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Accountacy[10].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
    //            player.CurrentPlayer.Skills.Accountacy[3].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Accountacy[10].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
    //            player.CurrentPlayer.Skills.Accountacy[3].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Accountacy[10].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
    //            player.CurrentPlayer.Skills.Accountacy[3].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Accountacy[10].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
    //            player.CurrentPlayer.Skills.Accountacy[3].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Accountacy[10].Cost += 6 * 1.5;
    //        }
    //    } 

    //    else if (player.CurrentPlayer.Course == AppData.Fields.HealthCare) {
    //        if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
    //            player.CurrentPlayer.Skills.HealtCare[7].Cost += 0 * .5;
    //            player.CurrentPlayer.Skills.HealtCare[13].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.HealtCare[10].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.HealtCare[11].Cost += 6 * .5;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
    //            player.CurrentPlayer.Skills.HealtCare[7].Cost += 0 * .6;
    //            player.CurrentPlayer.Skills.HealtCare[13].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.HealtCare[10].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.HealtCare[11].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
    //            player.CurrentPlayer.Skills.HealtCare[7].Cost += 0 * .7;
    //            player.CurrentPlayer.Skills.HealtCare[13].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.HealtCare[10].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.HealtCare[11].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
    //            player.CurrentPlayer.Skills.HealtCare[7].Cost += 0 * .8;
    //            player.CurrentPlayer.Skills.HealtCare[13].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.HealtCare[10].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.HealtCare[11].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
    //            player.CurrentPlayer.Skills.HealtCare[7].Cost += 0 * 1;
    //            player.CurrentPlayer.Skills.HealtCare[13].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.HealtCare[10].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.HealtCare[11].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
    //            player.CurrentPlayer.Skills.HealtCare[7].Cost += 0 * 1.1;
    //            player.CurrentPlayer.Skills.HealtCare[13].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.HealtCare[10].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.HealtCare[11].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
    //            player.CurrentPlayer.Skills.HealtCare[7].Cost += 0 * 1.2;
    //            player.CurrentPlayer.Skills.HealtCare[13].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.HealtCare[10].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.HealtCare[11].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
    //            player.CurrentPlayer.Skills.HealtCare[7].Cost += 0 * 1.3;
    //            player.CurrentPlayer.Skills.HealtCare[13].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.HealtCare[10].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.HealtCare[11].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
    //            player.CurrentPlayer.Skills.HealtCare[7].Cost += 0 * 1.4;
    //            player.CurrentPlayer.Skills.HealtCare[13].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.HealtCare[10].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.HealtCare[11].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
    //            player.CurrentPlayer.Skills.HealtCare[7].Cost += 0 * 1.5;
    //            player.CurrentPlayer.Skills.HealtCare[13].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.HealtCare[10].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.HealtCare[11].Cost += 6 * 1.5;
    //        }
    //        if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
    //            player.CurrentPlayer.Skills.HealtCare[0].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.HealtCare[1].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.HealtCare[8].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
    //            player.CurrentPlayer.Skills.HealtCare[0].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.HealtCare[1].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.HealtCare[8].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
    //            player.CurrentPlayer.Skills.HealtCare[0].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.HealtCare[1].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.HealtCare[8].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
    //            player.CurrentPlayer.Skills.HealtCare[0].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.HealtCare[1].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.HealtCare[8].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
    //            player.CurrentPlayer.Skills.HealtCare[0].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.HealtCare[1].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.HealtCare[8].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
    //            player.CurrentPlayer.Skills.HealtCare[0].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.HealtCare[1].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.HealtCare[8].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
    //            player.CurrentPlayer.Skills.HealtCare[0].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.HealtCare[1].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.HealtCare[8].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
    //            player.CurrentPlayer.Skills.HealtCare[0].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.HealtCare[1].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.HealtCare[8].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
    //            player.CurrentPlayer.Skills.HealtCare[0].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.HealtCare[1].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.HealtCare[8].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
    //            player.CurrentPlayer.Skills.HealtCare[0].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.HealtCare[1].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.HealtCare[8].Cost += 6 * 1.5;
    //        }




    //        if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
    //            player.CurrentPlayer.Skills.HealtCare[2].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.HealtCare[12].Cost += 6 * .5;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
    //            player.CurrentPlayer.Skills.HealtCare[2].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.HealtCare[12].Cost += 6 * .6;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
    //            player.CurrentPlayer.Skills.HealtCare[2].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.HealtCare[12].Cost += 6 * .7;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
    //            player.CurrentPlayer.Skills.HealtCare[2].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.HealtCare[12].Cost += 6 * .7;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
    //            player.CurrentPlayer.Skills.HealtCare[2].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.HealtCare[12].Cost += 6 * 1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
    //            player.CurrentPlayer.Skills.HealtCare[2].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.HealtCare[12].Cost += 6 * 1.1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
    //            player.CurrentPlayer.Skills.HealtCare[2].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.HealtCare[12].Cost += 6 * 1.2;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
    //            player.CurrentPlayer.Skills.HealtCare[2].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.HealtCare[12].Cost += 6 * 1.3;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
    //            player.CurrentPlayer.Skills.HealtCare[2].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.HealtCare[12].Cost += 6 * 1.4;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
    //            player.CurrentPlayer.Skills.HealtCare[2].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.HealtCare[12].Cost += 6 * 1.5;

    //        }



    //        if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
    //            player.CurrentPlayer.Skills.HealtCare[9].Cost += 5 * .5;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
    //            player.CurrentPlayer.Skills.HealtCare[9].Cost += 5 * .6;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
    //            player.CurrentPlayer.Skills.HealtCare[9].Cost += 5 * .7;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
    //            player.CurrentPlayer.Skills.HealtCare[9].Cost += 5 * .7;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
    //            player.CurrentPlayer.Skills.HealtCare[9].Cost += 5 * 1;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
    //            player.CurrentPlayer.Skills.HealtCare[9].Cost += 5 * 1.1;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
    //            player.CurrentPlayer.Skills.HealtCare[9].Cost += 5 * 1.2;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
    //            player.CurrentPlayer.Skills.HealtCare[9].Cost += 5 * 1.3;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
    //            player.CurrentPlayer.Skills.HealtCare[9].Cost += 5 * 1.4;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
    //            player.CurrentPlayer.Skills.HealtCare[9].Cost += 5 * 1.5;


    //        }




    //        if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
    //            player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * .5;
    //            player.CurrentPlayer.Skills.HealtCare[4].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.HealtCare[5].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.HealtCare[6].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
    //            player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * .6;
    //            player.CurrentPlayer.Skills.HealtCare[4].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.HealtCare[5].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.HealtCare[6].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
    //            player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * .7;
    //            player.CurrentPlayer.Skills.HealtCare[4].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.HealtCare[5].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.HealtCare[6].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
    //            player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * .8;
    //            player.CurrentPlayer.Skills.HealtCare[4].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.HealtCare[5].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.HealtCare[6].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
    //            player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1;
    //            player.CurrentPlayer.Skills.HealtCare[4].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.HealtCare[5].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.HealtCare[6].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
    //            player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1.1;
    //            player.CurrentPlayer.Skills.HealtCare[4].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.HealtCare[5].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.HealtCare[6].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
    //            player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1.2;
    //            player.CurrentPlayer.Skills.HealtCare[4].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.HealtCare[5].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.HealtCare[6].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
    //            player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1.3;
    //            player.CurrentPlayer.Skills.HealtCare[4].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.HealtCare[5].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.HealtCare[6].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
    //            player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1.4;
    //            player.CurrentPlayer.Skills.HealtCare[4].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.HealtCare[5].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.HealtCare[6].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
    //            player.CurrentPlayer.Skills.HealtCare[3].Cost += 5 * 1.5;
    //            player.CurrentPlayer.Skills.HealtCare[4].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.HealtCare[5].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.HealtCare[6].Cost += 6 * 1.5;
    //        }
    //    } 

    //    else if (player.CurrentPlayer.Course == AppData.Fields.HumanResource) {
    //        if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
    //            player.CurrentPlayer.Skills.HR[4].Cost += 5 * .5;
    //            player.CurrentPlayer.Skills.HR[10].Cost += 0 * .5;
    //            player.CurrentPlayer.Skills.HR[11].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.HR[14].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
    //            player.CurrentPlayer.Skills.HR[4].Cost += 5 * .6;
    //            player.CurrentPlayer.Skills.HR[10].Cost += 0 * .6;
    //            player.CurrentPlayer.Skills.HR[11].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.HR[14].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
    //            player.CurrentPlayer.Skills.HR[4].Cost += 5 * .7;
    //            player.CurrentPlayer.Skills.HR[10].Cost += 0 * .7;
    //            player.CurrentPlayer.Skills.HR[11].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.HR[14].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
    //            player.CurrentPlayer.Skills.HR[4].Cost += 5 * .8;
    //            player.CurrentPlayer.Skills.HR[10].Cost += 0 * .8;
    //            player.CurrentPlayer.Skills.HR[11].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.HR[14].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
    //            player.CurrentPlayer.Skills.HR[4].Cost += 5 * 1;
    //            player.CurrentPlayer.Skills.HR[10].Cost += 0 * 1;
    //            player.CurrentPlayer.Skills.HR[11].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.HR[14].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
    //            player.CurrentPlayer.Skills.HR[4].Cost += 5 * 1.1;
    //            player.CurrentPlayer.Skills.HR[10].Cost += 0 * 1.1;
    //            player.CurrentPlayer.Skills.HR[11].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.HR[14].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
    //            player.CurrentPlayer.Skills.HR[4].Cost += 5 * 1.2;
    //            player.CurrentPlayer.Skills.HR[10].Cost += 0 * 1.2;
    //            player.CurrentPlayer.Skills.HR[11].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.HR[14].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
    //            player.CurrentPlayer.Skills.HR[4].Cost += 5 * 1.3;
    //            player.CurrentPlayer.Skills.HR[10].Cost += 0 * 1.3;
    //            player.CurrentPlayer.Skills.HR[11].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.HR[14].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
    //            player.CurrentPlayer.Skills.HR[4].Cost += 5 * 1.4;
    //            player.CurrentPlayer.Skills.HR[10].Cost += 0 * 1.4;
    //            player.CurrentPlayer.Skills.HR[11].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.HR[14].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
    //            player.CurrentPlayer.Skills.HR[4].Cost += 5 * 1.5;
    //            player.CurrentPlayer.Skills.HR[10].Cost += 0 * 1.5;
    //            player.CurrentPlayer.Skills.HR[11].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.HR[14].Cost += 6 * 1.5;
    //        }
    //        if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
    //            player.CurrentPlayer.Skills.HR[8].Cost += 0 * .5;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
    //            player.CurrentPlayer.Skills.HR[8].Cost += 0 * .6;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
    //            player.CurrentPlayer.Skills.HR[8].Cost += 0 * .7;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
    //            player.CurrentPlayer.Skills.HR[8].Cost += 0 * .8;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
    //            player.CurrentPlayer.Skills.HR[8].Cost += 0 * 1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
    //            player.CurrentPlayer.Skills.HR[8].Cost += 0 * 1.1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
    //            player.CurrentPlayer.Skills.HR[8].Cost += 0 * 1.2;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
    //            player.CurrentPlayer.Skills.HR[8].Cost += 0 * 1.3;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
    //            player.CurrentPlayer.Skills.HR[8].Cost += 0 * 1.4;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
    //            player.CurrentPlayer.Skills.HR[8].Cost += 0 * 1.5;

    //        }




    //        if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
    //            player.CurrentPlayer.Skills.HR[5].Cost += 5 * .5;
    //            player.CurrentPlayer.Skills.HR[6].Cost += 5 * .5;
    //            player.CurrentPlayer.Skills.HR[7].Cost += 5 * .5;
    //            player.CurrentPlayer.Skills.HR[12].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
    //            player.CurrentPlayer.Skills.HR[5].Cost += 5 * .6;
    //            player.CurrentPlayer.Skills.HR[6].Cost += 5 * .6;
    //            player.CurrentPlayer.Skills.HR[7].Cost += 5 * .6;
    //            player.CurrentPlayer.Skills.HR[12].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
    //            player.CurrentPlayer.Skills.HR[5].Cost += 5 * .7;
    //            player.CurrentPlayer.Skills.HR[6].Cost += 5 * .7;
    //            player.CurrentPlayer.Skills.HR[7].Cost += 5 * .7;
    //            player.CurrentPlayer.Skills.HR[12].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
    //            player.CurrentPlayer.Skills.HR[5].Cost += 5 * .7;
    //            player.CurrentPlayer.Skills.HR[6].Cost += 5 * .7;
    //            player.CurrentPlayer.Skills.HR[7].Cost += 5 * .7;
    //            player.CurrentPlayer.Skills.HR[12].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
    //            player.CurrentPlayer.Skills.HR[5].Cost += 5 * 1;
    //            player.CurrentPlayer.Skills.HR[6].Cost += 5 * 1;
    //            player.CurrentPlayer.Skills.HR[7].Cost += 5 * 1;
    //            player.CurrentPlayer.Skills.HR[12].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
    //            player.CurrentPlayer.Skills.HR[5].Cost += 5 * 1.1;
    //            player.CurrentPlayer.Skills.HR[6].Cost += 5 * 1.1;
    //            player.CurrentPlayer.Skills.HR[7].Cost += 5 * 1.1;
    //            player.CurrentPlayer.Skills.HR[12].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
    //            player.CurrentPlayer.Skills.HR[5].Cost += 5 * 1.2;
    //            player.CurrentPlayer.Skills.HR[6].Cost += 5 * 1.2;
    //            player.CurrentPlayer.Skills.HR[7].Cost += 5 * 1.2;
    //            player.CurrentPlayer.Skills.HR[12].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
    //            player.CurrentPlayer.Skills.HR[5].Cost += 5 * 1.3;
    //            player.CurrentPlayer.Skills.HR[6].Cost += 5 * 1.3;
    //            player.CurrentPlayer.Skills.HR[7].Cost += 5 * 1.3;
    //            player.CurrentPlayer.Skills.HR[12].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
    //            player.CurrentPlayer.Skills.HR[5].Cost += 5 * 1.4;
    //            player.CurrentPlayer.Skills.HR[6].Cost += 5 * 1.4;
    //            player.CurrentPlayer.Skills.HR[7].Cost += 5 * 1.4;
    //            player.CurrentPlayer.Skills.HR[12].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
    //            player.CurrentPlayer.Skills.HR[5].Cost += 5 * 1.5;
    //            player.CurrentPlayer.Skills.HR[6].Cost += 5 * 1.5;
    //            player.CurrentPlayer.Skills.HR[7].Cost += 5 * 1.5;
    //            player.CurrentPlayer.Skills.HR[12].Cost += 6 * 1.5;
    //        }



    //        if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
    //            player.CurrentPlayer.Skills.HR[1].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.HR[2].Cost += 5 * .5;
    //            player.CurrentPlayer.Skills.HR[3].Cost += 4 * .5;
    //            player.CurrentPlayer.Skills.HR[13].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
    //            player.CurrentPlayer.Skills.HR[1].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.HR[2].Cost += 5 * .6;
    //            player.CurrentPlayer.Skills.HR[3].Cost += 4 * .6;
    //            player.CurrentPlayer.Skills.HR[13].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
    //            player.CurrentPlayer.Skills.HR[1].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.HR[2].Cost += 5 * .7;
    //            player.CurrentPlayer.Skills.HR[3].Cost += 4 * .7;
    //            player.CurrentPlayer.Skills.HR[13].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
    //            player.CurrentPlayer.Skills.HR[1].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.HR[2].Cost += 5 * .8;
    //            player.CurrentPlayer.Skills.HR[3].Cost += 4 * .8;
    //            player.CurrentPlayer.Skills.HR[13].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
    //            player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.HR[2].Cost += 5 * 1;
    //            player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1;
    //            player.CurrentPlayer.Skills.HR[13].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
    //            player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.HR[2].Cost += 5 * 1.1;
    //            player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1.1;
    //            player.CurrentPlayer.Skills.HR[13].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
    //            player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.HR[2].Cost += 5 * 1.2;
    //            player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1.2;
    //            player.CurrentPlayer.Skills.HR[13].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
    //            player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.HR[2].Cost += 5 * 1.3;
    //            player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1.3;
    //            player.CurrentPlayer.Skills.HR[13].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
    //            player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.HR[2].Cost += 5 * 1.4;
    //            player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1.4;
    //            player.CurrentPlayer.Skills.HR[13].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
    //            player.CurrentPlayer.Skills.HR[1].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.HR[2].Cost += 5 * 1.5;
    //            player.CurrentPlayer.Skills.HR[3].Cost += 4 * 1.5;
    //            player.CurrentPlayer.Skills.HR[13].Cost += 6 * 1.5;
    //        }

    //        if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
    //            player.CurrentPlayer.Skills.HR[0].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.HR[9].Cost += 6 * .5;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
    //            player.CurrentPlayer.Skills.HR[0].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.HR[9].Cost += 6 * .6;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
    //            player.CurrentPlayer.Skills.HR[0].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.HR[9].Cost += 6 * .7;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
    //            player.CurrentPlayer.Skills.HR[0].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.HR[9].Cost += 6 * .8;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
    //            player.CurrentPlayer.Skills.HR[0].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.HR[9].Cost += 6 * 1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
    //            player.CurrentPlayer.Skills.HR[0].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.HR[9].Cost += 6 * 1.1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
    //            player.CurrentPlayer.Skills.HR[0].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.HR[9].Cost += 6 * 1.2;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
    //            player.CurrentPlayer.Skills.HR[0].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.HR[9].Cost += 6 * 1.3;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
    //            player.CurrentPlayer.Skills.HR[0].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.HR[9].Cost += 6 * 1.4;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
    //            player.CurrentPlayer.Skills.HR[0].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.HR[9].Cost += 6 * 1.5;
    //        }
    //    } 

    //    else if (player.CurrentPlayer.Course == AppData.Fields.InformationTechnology) {
    //        if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
    //            player.CurrentPlayer.Skills.IT[3].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.IT[6].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.IT[7].Cost += 0 * .5;
    //            player.CurrentPlayer.Skills.IT[9].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.IT[11].Cost += 0 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
    //            player.CurrentPlayer.Skills.IT[3].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.IT[6].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.IT[7].Cost += 0 * .6;
    //            player.CurrentPlayer.Skills.IT[9].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.IT[11].Cost += 0 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
    //            player.CurrentPlayer.Skills.IT[3].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.IT[6].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.IT[7].Cost += 0 * .7;
    //            player.CurrentPlayer.Skills.IT[9].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.IT[11].Cost += 0 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
    //            player.CurrentPlayer.Skills.IT[3].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.IT[6].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.IT[7].Cost += 0 * .8;
    //            player.CurrentPlayer.Skills.IT[9].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.IT[11].Cost += 0 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
    //            player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.IT[6].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.IT[7].Cost += 0 * 1;
    //            player.CurrentPlayer.Skills.IT[9].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.IT[11].Cost += 0 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
    //            player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.IT[6].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.IT[7].Cost += 0 * 1.1;
    //            player.CurrentPlayer.Skills.IT[9].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.IT[11].Cost += 0 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
    //            player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.IT[6].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.IT[7].Cost += 0 * 1.2;
    //            player.CurrentPlayer.Skills.IT[9].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.IT[11].Cost += 0 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
    //            player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.IT[6].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.IT[7].Cost += 0 * 1.3;
    //            player.CurrentPlayer.Skills.IT[9].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.IT[11].Cost += 0 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
    //            player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.IT[6].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.IT[7].Cost += 0 * 1.4;
    //            player.CurrentPlayer.Skills.IT[9].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.IT[11].Cost += 0 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
    //            player.CurrentPlayer.Skills.IT[3].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.IT[6].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.IT[7].Cost += 0 * 1.5;
    //            player.CurrentPlayer.Skills.IT[9].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.IT[11].Cost += 0 * 1.5;
    //        }
    //        if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
    //            player.CurrentPlayer.Skills.IT[4].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.IT[8].Cost += 0 * .5;
    //            player.CurrentPlayer.Skills.IT[12].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.IT[13].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
    //            player.CurrentPlayer.Skills.IT[4].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.IT[8].Cost += 0 * .6;
    //            player.CurrentPlayer.Skills.IT[12].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.IT[13].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
    //            player.CurrentPlayer.Skills.IT[4].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.IT[8].Cost += 0 * .7;
    //            player.CurrentPlayer.Skills.IT[12].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.IT[13].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
    //            player.CurrentPlayer.Skills.IT[4].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.IT[8].Cost += 0 * .8;
    //            player.CurrentPlayer.Skills.IT[12].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.IT[13].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
    //            player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.IT[8].Cost += 0 * 1;
    //            player.CurrentPlayer.Skills.IT[12].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.IT[13].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
    //            player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.IT[8].Cost += 0 * 1.1;
    //            player.CurrentPlayer.Skills.IT[12].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.IT[13].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
    //            player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.IT[8].Cost += 0 * 1.2;
    //            player.CurrentPlayer.Skills.IT[12].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.IT[13].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
    //            player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.IT[8].Cost += 0 * 1.3;
    //            player.CurrentPlayer.Skills.IT[12].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.IT[13].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
    //            player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.IT[8].Cost += 0 * 1.4;
    //            player.CurrentPlayer.Skills.IT[12].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.IT[13].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
    //            player.CurrentPlayer.Skills.IT[4].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.IT[8].Cost += 0 * 1.5;
    //            player.CurrentPlayer.Skills.IT[12].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.IT[13].Cost += 6 * 1.5;
    //        }




    //        if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {
    //            player.CurrentPlayer.Skills.IT[1].Cost += 5 * .5;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
    //            player.CurrentPlayer.Skills.IT[1].Cost += 5 * .6;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
    //            player.CurrentPlayer.Skills.IT[1].Cost += 5 * .7;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
    //            player.CurrentPlayer.Skills.IT[1].Cost += 5 * .7;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
    //            player.CurrentPlayer.Skills.IT[1].Cost += 5 * 1;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
    //            player.CurrentPlayer.Skills.IT[1].Cost += 5 * 1.1;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
    //            player.CurrentPlayer.Skills.IT[1].Cost += 5 * 1.2;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
    //            player.CurrentPlayer.Skills.IT[1].Cost += 5 * 1.3;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
    //            player.CurrentPlayer.Skills.IT[1].Cost += 5 * 1.4;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
    //            player.CurrentPlayer.Skills.IT[1].Cost += 5 * 1.5;


    //        }



    //        if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
    //            player.CurrentPlayer.Skills.IT[2].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.IT[10].Cost += 6 * .5;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
    //            player.CurrentPlayer.Skills.IT[2].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.IT[10].Cost += 6 * .6;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
    //            player.CurrentPlayer.Skills.IT[2].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.IT[10].Cost += 6 * .7;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
    //            player.CurrentPlayer.Skills.IT[2].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.IT[10].Cost += 6 * .8;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
    //            player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.IT[10].Cost += 6 * 1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
    //            player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.IT[10].Cost += 6 * 1.1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
    //            player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.IT[10].Cost += 6 * 1.2;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
    //            player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.IT[10].Cost += 6 * 1.3;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
    //            player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.IT[10].Cost += 6 * 1.4;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
    //            player.CurrentPlayer.Skills.IT[2].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.IT[10].Cost += 6 * 1.5;

    //        }

    //        if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
    //            player.CurrentPlayer.Skills.IT[0].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.IT[5].Cost += 6 * .5;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
    //            player.CurrentPlayer.Skills.IT[0].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.IT[5].Cost += 6 * .6;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
    //            player.CurrentPlayer.Skills.IT[0].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.IT[5].Cost += 6 * .7;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
    //            player.CurrentPlayer.Skills.IT[0].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.IT[5].Cost += 6 * .8;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
    //            player.CurrentPlayer.Skills.IT[0].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.IT[5].Cost += 6 * 1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
    //            player.CurrentPlayer.Skills.IT[0].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.IT[5].Cost += 6 * 1.1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
    //            player.CurrentPlayer.Skills.IT[0].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.IT[5].Cost += 6 * 1.2;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
    //            player.CurrentPlayer.Skills.IT[0].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.IT[5].Cost += 6 * 1.3;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
    //            player.CurrentPlayer.Skills.IT[0].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.IT[5].Cost += 6 * 1.4;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
    //            player.CurrentPlayer.Skills.IT[0].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.IT[5].Cost += 6 * 1.5;

    //        }
    //    } 

    //    else if (player.CurrentPlayer.Course == AppData.Fields.Media) {
    //        if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
    //            player.CurrentPlayer.Skills.Media[9].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Media[10].Cost += 0 * .5;
    //            player.CurrentPlayer.Skills.Media[11].Cost += 0 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
    //            player.CurrentPlayer.Skills.Media[9].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Media[10].Cost += 0 * .6;
    //            player.CurrentPlayer.Skills.Media[11].Cost += 0 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
    //            player.CurrentPlayer.Skills.Media[9].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Media[10].Cost += 0 * .7;
    //            player.CurrentPlayer.Skills.Media[11].Cost += 0 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
    //            player.CurrentPlayer.Skills.Media[9].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Media[10].Cost += 0 * .8;
    //            player.CurrentPlayer.Skills.Media[11].Cost += 0 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
    //            player.CurrentPlayer.Skills.Media[9].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Media[10].Cost += 0 * 1;
    //            player.CurrentPlayer.Skills.Media[11].Cost += 0 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
    //            player.CurrentPlayer.Skills.Media[9].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Media[10].Cost += 0 * 1.1;
    //            player.CurrentPlayer.Skills.Media[11].Cost += 0 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
    //            player.CurrentPlayer.Skills.Media[9].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Media[10].Cost += 0 * 1.2;
    //            player.CurrentPlayer.Skills.Media[11].Cost += 0 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
    //            player.CurrentPlayer.Skills.Media[9].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Media[10].Cost += 0 * 1.3;
    //            player.CurrentPlayer.Skills.Media[11].Cost += 0 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
    //            player.CurrentPlayer.Skills.Media[9].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Media[10].Cost += 0 * 1.4;
    //            player.CurrentPlayer.Skills.Media[11].Cost += 0 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
    //            player.CurrentPlayer.Skills.Media[9].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Media[10].Cost += 0 * 1.5;
    //            player.CurrentPlayer.Skills.Media[11].Cost += 0 * 1.5;
    //        }
    //        if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {
    //            player.CurrentPlayer.Skills.Media[1].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Media[2].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Media[7].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Media[8].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
    //            player.CurrentPlayer.Skills.Media[1].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Media[2].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Media[7].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Media[8].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
    //            player.CurrentPlayer.Skills.Media[1].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Media[2].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Media[7].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Media[8].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
    //            player.CurrentPlayer.Skills.Media[1].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Media[2].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Media[7].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Media[8].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
    //            player.CurrentPlayer.Skills.Media[1].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Media[2].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Media[7].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Media[8].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
    //            player.CurrentPlayer.Skills.Media[1].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Media[2].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Media[7].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Media[8].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
    //            player.CurrentPlayer.Skills.Media[1].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Media[2].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Media[7].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Media[8].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
    //            player.CurrentPlayer.Skills.Media[1].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Media[2].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Media[7].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Media[8].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
    //            player.CurrentPlayer.Skills.Media[1].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Media[2].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Media[7].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Media[8].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
    //            player.CurrentPlayer.Skills.Media[1].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Media[2].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Media[7].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Media[8].Cost += 6 * 1.5;
    //        }








    //        if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
    //            player.CurrentPlayer.Skills.Media[0].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Media[4].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Media[5].Cost += 0 * .5;
    //            player.CurrentPlayer.Skills.Media[12].Cost += 5 * .5;
    //            player.CurrentPlayer.Skills.Media[13].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
    //            player.CurrentPlayer.Skills.Media[0].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Media[4].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Media[5].Cost += 0 * .6;
    //            player.CurrentPlayer.Skills.Media[12].Cost += 5 * .6;
    //            player.CurrentPlayer.Skills.Media[13].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
    //            player.CurrentPlayer.Skills.Media[0].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Media[4].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Media[5].Cost += 0 * .7;
    //            player.CurrentPlayer.Skills.Media[12].Cost += 5 * .7;
    //            player.CurrentPlayer.Skills.Media[13].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
    //            player.CurrentPlayer.Skills.Media[0].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Media[4].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Media[5].Cost += 0 * .8;
    //            player.CurrentPlayer.Skills.Media[12].Cost += 5 * .8;
    //            player.CurrentPlayer.Skills.Media[13].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
    //            player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Media[4].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Media[5].Cost += 0 * 1;
    //            player.CurrentPlayer.Skills.Media[12].Cost += 5 * 1;
    //            player.CurrentPlayer.Skills.Media[13].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
    //            player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Media[4].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Media[5].Cost += 0 * 1.1;
    //            player.CurrentPlayer.Skills.Media[12].Cost += 5 * 1.1;
    //            player.CurrentPlayer.Skills.Media[13].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
    //            player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Media[4].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Media[5].Cost += 0 * 1.2;
    //            player.CurrentPlayer.Skills.Media[12].Cost += 5 * 1.2;
    //            player.CurrentPlayer.Skills.Media[13].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
    //            player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Media[4].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Media[5].Cost += 0 * 1.3;
    //            player.CurrentPlayer.Skills.Media[12].Cost += 5 * 1.3;
    //            player.CurrentPlayer.Skills.Media[13].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
    //            player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Media[4].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Media[5].Cost += 0 * 1.4;
    //            player.CurrentPlayer.Skills.Media[12].Cost += 5 * 1.4;
    //            player.CurrentPlayer.Skills.Media[13].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
    //            player.CurrentPlayer.Skills.Media[0].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Media[4].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Media[5].Cost += 0 * 1.5;
    //            player.CurrentPlayer.Skills.Media[12].Cost += 5 * 1.5;
    //            player.CurrentPlayer.Skills.Media[13].Cost += 6 * 1.5;
    //        }

    //        if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
    //            player.CurrentPlayer.Skills.Media[3].Cost += 5 * .5;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
    //            player.CurrentPlayer.Skills.Media[3].Cost += 5 * .6;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
    //            player.CurrentPlayer.Skills.Media[3].Cost += 5 * .7;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
    //            player.CurrentPlayer.Skills.Media[3].Cost += 5 * .8;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
    //            player.CurrentPlayer.Skills.Media[3].Cost += 5 * 1;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
    //            player.CurrentPlayer.Skills.Media[3].Cost += 5 * 1.1;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
    //            player.CurrentPlayer.Skills.Media[3].Cost += 5 * 1.2;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
    //            player.CurrentPlayer.Skills.Media[3].Cost += 5 * 1.3;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
    //            player.CurrentPlayer.Skills.Media[3].Cost += 5 * 1.4;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
    //            player.CurrentPlayer.Skills.Media[3].Cost += 5 * 1.5;


    //        }



    //        if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
    //            player.CurrentPlayer.Skills.Media[6].Cost += 5 * .5;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
    //            player.CurrentPlayer.Skills.Media[6].Cost += 5 * .6;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
    //            player.CurrentPlayer.Skills.Media[6].Cost += 5 * .7;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
    //            player.CurrentPlayer.Skills.Media[6].Cost += 5 * .8;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
    //            player.CurrentPlayer.Skills.Media[6].Cost += 5 * 1;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
    //            player.CurrentPlayer.Skills.Media[6].Cost += 5 * 1.1;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
    //            player.CurrentPlayer.Skills.Media[6].Cost += 5 * 1.2;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
    //            player.CurrentPlayer.Skills.Media[6].Cost += 5 * 1.3;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
    //            player.CurrentPlayer.Skills.Media[6].Cost += 5 * 1.4;


    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
    //            player.CurrentPlayer.Skills.Media[6].Cost += 5 * 1.5;


    //        }
    //    } 

    //    else if (player.CurrentPlayer.Course == AppData.Fields.Retail) {
    //        if (player.CurrentPlayer.MultipleIntelligence[1].cost == 1) {
    //            player.CurrentPlayer.Skills.Retail[1].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Retail[3].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Retail[7].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Retail[11].Cost += 0 * .5;
    //            player.CurrentPlayer.Skills.Retail[12].Cost += 0 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 2) {
    //            player.CurrentPlayer.Skills.Retail[1].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Retail[3].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Retail[7].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Retail[11].Cost += 0 * .6;
    //            player.CurrentPlayer.Skills.Retail[12].Cost += 0 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 3) {
    //            player.CurrentPlayer.Skills.Retail[1].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Retail[3].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Retail[7].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Retail[11].Cost += 0 * .7;
    //            player.CurrentPlayer.Skills.Retail[12].Cost += 0 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 4) {
    //            player.CurrentPlayer.Skills.Retail[1].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Retail[3].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Retail[7].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Retail[11].Cost += 0 * .8;
    //            player.CurrentPlayer.Skills.Retail[12].Cost += 0 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 5) {
    //            player.CurrentPlayer.Skills.Retail[1].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Retail[3].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Retail[7].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Retail[11].Cost += 0 * 1;
    //            player.CurrentPlayer.Skills.Retail[12].Cost += 0 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 6) {
    //            player.CurrentPlayer.Skills.Retail[1].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Retail[3].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Retail[7].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Retail[11].Cost += 0 * 1.1;
    //            player.CurrentPlayer.Skills.Retail[12].Cost += 0 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 7) {
    //            player.CurrentPlayer.Skills.Retail[1].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Retail[3].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Retail[7].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Retail[11].Cost += 0 * 1.2;
    //            player.CurrentPlayer.Skills.Retail[12].Cost += 0 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 8) {
    //            player.CurrentPlayer.Skills.Retail[1].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Retail[3].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Retail[7].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Retail[11].Cost += 0 * 1.3;
    //            player.CurrentPlayer.Skills.Retail[12].Cost += 0 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 9) {
    //            player.CurrentPlayer.Skills.Retail[1].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Retail[3].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Retail[7].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Retail[11].Cost += 0 * 1.4;
    //            player.CurrentPlayer.Skills.Retail[12].Cost += 0 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[1].cost == 10) {
    //            player.CurrentPlayer.Skills.Retail[1].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Retail[3].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Retail[7].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Retail[11].Cost += 0 * 1.5;
    //            player.CurrentPlayer.Skills.Retail[12].Cost += 0 * 1.5;
    //        }
    //        if (player.CurrentPlayer.MultipleIntelligence[6].cost == 1) {

    //            player.CurrentPlayer.Skills.Retail[8].Cost += 0 * .5;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 2) {
    //            player.CurrentPlayer.Skills.Retail[8].Cost += 0 * .6;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 3) {
    //            player.CurrentPlayer.Skills.Retail[8].Cost += 0 * .7;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 4) {
    //            player.CurrentPlayer.Skills.Retail[8].Cost += 0 * .8;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 5) {
    //            player.CurrentPlayer.Skills.Retail[8].Cost += 0 * 1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 6) {
    //            player.CurrentPlayer.Skills.Retail[8].Cost += 0 * 1.1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 7) {
    //            player.CurrentPlayer.Skills.Retail[8].Cost += 0 * 1.2;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 8) {
    //            player.CurrentPlayer.Skills.Retail[8].Cost += 0 * 1.3;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 9) {
    //            player.CurrentPlayer.Skills.Retail[8].Cost += 0 * 1.4;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[6].cost == 10) {
    //            player.CurrentPlayer.Skills.Retail[8].Cost += 0 * 1.5;

    //        }


    //        if (player.CurrentPlayer.MultipleIntelligence[3].cost == 1) {
    //            player.CurrentPlayer.Skills.Retail[4].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Retail[6].Cost += 0 * .5;
    //            player.CurrentPlayer.Skills.Retail[13].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Retail[14].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 2) {
    //            player.CurrentPlayer.Skills.Retail[4].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Retail[6].Cost += 0 * .6;
    //            player.CurrentPlayer.Skills.Retail[13].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Retail[14].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 3) {
    //            player.CurrentPlayer.Skills.Retail[4].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Retail[6].Cost += 0 * .7;
    //            player.CurrentPlayer.Skills.Retail[13].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Retail[14].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 4) {
    //            player.CurrentPlayer.Skills.Retail[4].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Retail[6].Cost += 0 * .8;
    //            player.CurrentPlayer.Skills.Retail[13].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Retail[14].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 5) {
    //            player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Retail[6].Cost += 0 * 1;
    //            player.CurrentPlayer.Skills.Retail[13].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 6) {
    //            player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Retail[6].Cost += 0 * 1.1;
    //            player.CurrentPlayer.Skills.Retail[13].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 7) {
    //            player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Retail[6].Cost += 0 * 1.2;
    //            player.CurrentPlayer.Skills.Retail[13].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 8) {
    //            player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Retail[6].Cost += 0 * 1.3;
    //            player.CurrentPlayer.Skills.Retail[13].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 9) {
    //            player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Retail[6].Cost += 0 * 1.4;
    //            player.CurrentPlayer.Skills.Retail[13].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[3].cost == 10) {
    //            player.CurrentPlayer.Skills.Retail[4].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Retail[6].Cost += 0 * 1.5;
    //            player.CurrentPlayer.Skills.Retail[13].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Retail[14].Cost += 6 * 1.5;
    //        }

    //        if (player.CurrentPlayer.MultipleIntelligence[7].cost == 1) {
    //            player.CurrentPlayer.Skills.Retail[0].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Retail[2].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 2) {
    //            player.CurrentPlayer.Skills.Retail[0].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Retail[2].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 3) {
    //            player.CurrentPlayer.Skills.Retail[0].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Retail[2].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 4) {
    //            player.CurrentPlayer.Skills.Retail[0].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Retail[2].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 5) {
    //            player.CurrentPlayer.Skills.Retail[0].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Retail[2].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 6) {
    //            player.CurrentPlayer.Skills.Retail[0].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Retail[2].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 7) {
    //            player.CurrentPlayer.Skills.Retail[0].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Retail[2].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 8) {
    //            player.CurrentPlayer.Skills.Retail[0].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Retail[2].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 9) {
    //            player.CurrentPlayer.Skills.Retail[0].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Retail[2].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[7].cost == 10) {
    //            player.CurrentPlayer.Skills.Retail[0].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Retail[2].Cost += 6 * 1.5;
    //        }



    //        if (player.CurrentPlayer.MultipleIntelligence[2].cost == 1) {
    //            player.CurrentPlayer.Skills.Retail[5].Cost += 6 * .5;
    //            player.CurrentPlayer.Skills.Retail[9].Cost += 6 * .5;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 2) {
    //            player.CurrentPlayer.Skills.Retail[5].Cost += 6 * .6;
    //            player.CurrentPlayer.Skills.Retail[9].Cost += 6 * .6;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 3) {
    //            player.CurrentPlayer.Skills.Retail[5].Cost += 6 * .7;
    //            player.CurrentPlayer.Skills.Retail[9].Cost += 6 * .7;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 4) {
    //            player.CurrentPlayer.Skills.Retail[5].Cost += 6 * .8;
    //            player.CurrentPlayer.Skills.Retail[9].Cost += 6 * .8;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 5) {
    //            player.CurrentPlayer.Skills.Retail[5].Cost += 6 * 1;
    //            player.CurrentPlayer.Skills.Retail[9].Cost += 6 * 1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 6) {
    //            player.CurrentPlayer.Skills.Retail[5].Cost += 6 * 1.1;
    //            player.CurrentPlayer.Skills.Retail[9].Cost += 6 * 1.1;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 7) {
    //            player.CurrentPlayer.Skills.Retail[5].Cost += 6 * 1.2;
    //            player.CurrentPlayer.Skills.Retail[9].Cost += 6 * 1.2;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 8) {
    //            player.CurrentPlayer.Skills.Retail[5].Cost += 6 * 1.3;
    //            player.CurrentPlayer.Skills.Retail[9].Cost += 6 * 1.3;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 9) {
    //            player.CurrentPlayer.Skills.Retail[5].Cost += 6 * 1.4;
    //            player.CurrentPlayer.Skills.Retail[9].Cost += 6 * 1.4;
    //        } else if (player.CurrentPlayer.MultipleIntelligence[2].cost == 10) {
    //            player.CurrentPlayer.Skills.Retail[5].Cost += 6 * 1.5;
    //            player.CurrentPlayer.Skills.Retail[9].Cost += 6 * 1.5;
    //        }



    //        if (player.CurrentPlayer.MultipleIntelligence[0].cost == 1) {

    //            player.CurrentPlayer.Skills.Retail[10].Cost += 0 * .5;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 2) {
    //            player.CurrentPlayer.Skills.Retail[10].Cost += 0 * .6;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 3) {
    //            player.CurrentPlayer.Skills.Retail[10].Cost += 0 * .7;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 4) {
    //            player.CurrentPlayer.Skills.Retail[10].Cost += 0 * .8;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 5) {
    //            player.CurrentPlayer.Skills.Retail[10].Cost += 0 * 1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 6) {
    //            player.CurrentPlayer.Skills.Retail[10].Cost += 0 * 1.1;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 7) {
    //            player.CurrentPlayer.Skills.Retail[10].Cost += 0 * 1.2;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 8) {
    //            player.CurrentPlayer.Skills.Retail[10].Cost += 0 * 1.3;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 9) {
    //            player.CurrentPlayer.Skills.Retail[10].Cost += 0 * 1.4;

    //        } else if (player.CurrentPlayer.MultipleIntelligence[0].cost == 10) {
    //            player.CurrentPlayer.Skills.Retail[10].Cost += 0 * 1.5;

    //        }
    //    }
    //}


}

