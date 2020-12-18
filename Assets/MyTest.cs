using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyTest : MonoBehaviour
{
    public DataBase db;
    public static MyTest instance;
    public List<QuizModel> q = null;
    public TokenModel t = null;

    private void Start() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Update() {
        if (MyQuiz != null && q == null) {
            Debug.Log("done ...........................>>>>>>>>>>>>>");
            q = MyQuiz;
            db.Quizes = q;
        }
    }

    string quizData = "";
    List<QuizModel> MyQuiz = null;

    IEnumerator GetText() {
        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/allmodules");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            quizData = www.downloadHandler.text;
            //string str = "{\"Q\":[" + quizData + "]}";
            QuizModel[] qarray = JsonHelper.getJsonArray<QuizModel>(quizData);

            MyQuiz = Parser.Parse(quizData);

            q = MyQuiz;
            foreach (QuizModel qm in qarray) {
                string str = qm.name.ToLower();
                string title = "";
                for (int i = 0; i < 3; i++) {
                    title += str[i];
                }
                if (title != "pri" && title != "sec" && title != "jun" && title != "pol" && title != "bac" && title != "mas" && title != "phd") {
                    title = qm.name;
                }
                switch (title) {
                    case "pri":
                        db.QuizesPri.Add(qm);
                        break;
                    case "sec":
                        db.QuizesSec.Add(qm);
                        break;
                    case "jun":
                        db.QuizesJun.Add(qm);
                        break;
                    case "pol":
                        db.QuizesPol.Add(qm);
                        break;
                    case "bac":
                        db.QuizesBac.Add(qm);
                        break;
                    case "mas":
                        db.QuizesMas.Add(qm);
                        break;
                    case "phd":
                        db.QuizesPhd.Add(qm);
                        break;
                    case "Chief Financial Officer":
                        Debug.Log("==============-------------------================--------------------- ADDED");
                        db.Quizes_Chief_Financial_Officer.Add(qm);
                        break;
                    case "Management Accounting - Accounting Executive":
                        db.Quizes_Management_Accounting_Accounting_Executive.Add(qm);
                        break;
                    case "Management Accounting - Financial Planning and Analysis Manager":
                        db.Quizes_Management_Accounting_Financial_Planning_and_Analysis_Manager.Add(qm);
                        break;
                    case "Management Accounting - Business Controller":
                        db.Quizes_Management_Accounting_Business_Controller.Add(qm);
                        break;
                    case "Financial Accounting - Accounts Executive":
                        db.Quizes_Financial_Accounting_Accounts_Executive.Add(qm);
                        break;
                    case "Financial Accounting - Finance Manager":
                        db.Quizes_Financial_Accounting_Finance_Manager.Add(qm);
                        break;
                    case "Financial Accounting - Financial Controller":
                        db.Quizes_Financial_Accounting_Financial_Controller.Add(qm);
                        break;
                    case "Senior Principal Physiotherapy Researcher":
                        db.Quizes_Senior_Principal_Physiotherapy_Researcher.Add(qm);
                        break;
                    case "Senior Principal Physiotherapist (Clinical)":
                        db.Quizes_Senior_Principal_Physiotherapist_Clinical.Add(qm);
                        break;
                    case "Senior Principal Physiotherapy Educator":
                        db.Quizes_Senior_Principal_Physiotherapy_Educator.Add(qm);
                        break;
                    case "Principal Physiotherapy Educator":
                        db.Quizes_Principal_Physiotherapy_Educator.Add(qm);
                        break;
                    case "Principal Physiotherapist (Clinical)":
                        db.Quizes_Principal_Physiotherapist_Clinical.Add(qm);
                        break;
                    case "Principal Physiotherapy Researcher":
                        db.Quizes_Principal_Physiotherapy_Researcher.Add(qm);
                        break;
                    case "Senior Physiotherapist":
                        db.Quizes_Senior_Physiotherapist.Add(qm);
                        break;
                    case "Physiotherapist":
                        db.Quizes_Physiotherapist.Add(qm);
                        break;
                    case "Chief Human Resource Officer":
                        db.Quizes_Chief_Human_Resource_Officer.Add(qm);
                        break;
                    case "Head, Performance & Rewards":
                        db.Quizes_Head_Performance_Rewards.Add(qm);
                        break;
                    case "Manager, Performance & Rewards":
                        db.Quizes_Manager_Performance_Rewards.Add(qm);
                        break;
                    case "Executive, Performance & Rewards":
                        db.Quizes_Executive_Performance_Rewards.Add(qm);
                        break;
                    case "Head, Employee Experience & Relations":
                        db.Quizes_Head_Employee_Experience_Relations.Add(qm);
                        break;
                    case "Manager, Employee Experience & Relations":
                        db.Quizes_Manager_Employee_Experience_Relations.Add(qm);
                        break;
                    case "Executive, Employee Experience & Relations":
                        db.Quizes_Executive_Employee_Experience_Relations.Add(qm);
                        break;
                    case "Head, Talent & Attraction":
                        db.Quizes_Head_Talent_Attraction.Add(qm);
                        break;
                    case "Manager, Talent & Attraction":
                        db.Quizes_Manager_Talent_Attraction.Add(qm);
                        break;
                    case "Executive, Talent & Attraction":
                        db.Quizes_Executive_Talent_Attraction.Add(qm);
                        break;
                    case "Head of Product":
                        db.Quizes_Head_of_Product.Add(qm);
                        break;
                    case "Lead UX Designer":
                        db.Quizes_Lead_UX_Designer.Add(qm);
                        break;
                    case "Senior UX Designer":
                        db.Quizes_Senior_UX_Designer.Add(qm);
                        break;
                    case "UX Designer":
                        db.Quizes_UX_Designer.Add(qm);
                        break;
                    case "Chief Technology Officer":
                        db.Quizes_Chief_Technology_Officer.Add(qm);
                        break;
                    case "Applications Architect":
                        db.Quizes_Applications_Architect.Add(qm);
                        break;
                    case "Applications Development Manager":
                        db.Quizes_Applications_Development_Manager.Add(qm);
                        break;
                    case "Applications Developer":
                        db.Quizes_Applications_Developer.Add(qm);
                        break;
                    case "Executive Producer - Broadcast":
                        db.Quizes_Executive_Producer_Broadcast.Add(qm);
                        break;
                    case "Producer - Broadcast":
                        db.Quizes_Producer_Broadcast.Add(qm);
                        break;
                    case "Assistant Producer Broadcast":
                        db.Quizes_Assistant_Producer_Broadcast.Add(qm);
                        break;
                    case "Production Assistant":
                        db.Quizes_Production_Assistant.Add(qm);
                        break;
                    case "Chief Editor":
                        db.Quizes_Chief_Editor.Add(qm);
                        break;
                    case "Executive Editor":
                        db.Quizes_Executive_Editor.Add(qm);
                        break;
                    case "Senior Reporter / Senior Correspondent":
                        db.Quizes_Senior_Reporter_Senior_Correspondent.Add(qm);
                        break;
                    case "Reporter / Correspondent":
                        db.Quizes_Reporter_Correspondent.Add(qm);
                        break;
                    case "Chief Executive Officer / Managing Director":
                        db.Quizes_Chief_Executive_Officer_Managing_Director.Add(qm);
                        break;
                    case "Brand Director":
                        db.Quizes_Brand_Director.Add(qm);
                        break;
                    case "Brand Manager":
                        db.Quizes_Brand_Manager.Add(qm);
                        break;
                    case "Brand Associate":
                        db.Quizes_Brand_Associate.Add(qm);
                        break;
                    case "Merchandising Director":
                        db.Quizes_Merchandising_Director.Add(qm);
                        break;
                    case "Merchandising Manager":
                        db.Quizes_Merchandising_Manager.Add(qm);
                        break;
                    case "Visual Merchandiser":
                        db.Quizes_Visual_Merchandiser.Add(qm);
                        break;
                    case "Accountancy":
                        db.Quizes_AC.Add(qm);
                        break;
                    case "Healthcare":
                        db.Quizes_HC.Add(qm);
                        break;
                    case "Human Resources":
                        db.Quizes_HR.Add(qm);
                        break;
                    case "Information Technology":
                        db.Quizes_IT.Add(qm);
                        break;
                    case "Retail":
                        db.Quizes_RE.Add(qm);
                        break;
                    case "Media":
                        db.Quizes_ME.Add(qm);
                        break;
                }
            }
  //          db.Quizes = q;
//            Debug.Log("quizzes loaded: " + MyQuiz[0].questions.Length);
        }
    }

    public void LoadData() {
        //    q = q.Fetch("5dbd7ddf415ca23da4e38213");
        //    t = t.Fetch("5de97ffe035a713b6c28aa68");
        //DataBase db = GetComponent<DataBase>();

        StartCoroutine(GetText());

        //foreach (Question question in q.questions) {
        //    int wai = -1;
        //    string[] op = new string[question.options.Length];

        //    for (int i = 0; i < op.Length; i++) {
        //        op[i] = question.options[i].name;
        //        if (question.options[i].isAnswer) {
        //            wai = i;
        //        }
        //    }

        //    TestDet td = new TestDet(question.name, op, wai);
        //    db.Quizes.sawaal.Add(td);
        //}
        //db.Quizes.Threshold = q.threshold;
        //db.Quizes.myScore = 0;
    }
}