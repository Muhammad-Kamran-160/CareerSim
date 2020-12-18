using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimarySchoolPassS : MonoBehaviour
{
    public AppData player;
    public GameObject Round2;

    public GameObject stats;
    public GameObject GamePlay;
    public GameObject SchoolMenu;
    public Text certifcatetext;
    public Text HeaderText;

    public GameObject ScrollView;
    public Text SkillsTxt;

    private void OnDisable()
    {
        if (player.CurrentPlayer.CurrentQuizName == "jun")
        {
            player.CurrentPlayer.edu = "Junior College";
        }
        player.CurrentPlayer.CurrentQuizName = "";
    }
    // Start is called before the first frame update
    private void OnEnable() {
        ScrollView.gameObject.SetActive(true);
        Debug.Log(player.CurrentPlayer.edu);
        if (player.CurrentPlayer.CurrentQuizName == "pri") {
            ScrollView.gameObject.SetActive(false);
            certifcatetext.text = "PSLE achieved.";
            HeaderText.text = "Primary School";
            player.CurrentPlayer.Educations.Add(new EduRec(certifcatetext.text, player.CurrentPlayer.CurrentQuizPercentage));

        } else if (player.CurrentPlayer.CurrentQuizName == "sec") {
            ScrollView.gameObject.SetActive(false);
            certifcatetext.text = "O Level achieved.";
            HeaderText.text = "Secondary School";
            player.CurrentPlayer.Educations.Add(new EduRec(certifcatetext.text, player.CurrentPlayer.CurrentQuizPercentage));

        } 
        //else if (player.CurrentPlayer.edu == "Poly") {
            
        //    player.CurrentPlayer.Diplomas.Add("Diploma in " + player.CurrentPlayer.Course + " achieved.");

        //    certifcatetext.text = "Diploma in "+ player.CurrentPlayer.Course+" achieved.";
        //    HeaderText.text = "Diploma in " + player.CurrentPlayer.Course;

        //} 
        else if (player.CurrentPlayer.edu == "Accountancy") {

            certifcatetext.text = "Diploma in Healthcare achieved.";
            HeaderText.text = "Polytechnic-Healthcare";

        } else if (player.CurrentPlayer.edu == "Healthcare") {

            certifcatetext.text = "Diploma in HR achieved.";
            HeaderText.text = "Polytechnic-HR";

        } else if (player.CurrentPlayer.edu == "HR") {

            certifcatetext.text = "Diploma in IT achieved.";
            HeaderText.text = "Polytechnic-IT";

        } else if (player.CurrentPlayer.edu == "IT") {

            certifcatetext.text = "Diploma in Retail achieved.";
            HeaderText.text = "Polytechnic-Retail";

        } else if (player.CurrentPlayer.edu == "Retail") {

            certifcatetext.text = "Diploma in Media achieved.";
            HeaderText.text = "Polytechnic-Media";

        } else if (player.CurrentPlayer.CurrentQuizName == "jun") {
            ScrollView.gameObject.SetActive(false);
            certifcatetext.text = "A Level achieved.";
            HeaderText.text = "Junior College";
            player.CurrentPlayer.Educations.Add(new EduRec(certifcatetext.text, player.CurrentPlayer.CurrentQuizPercentage));

        } else if (player.CurrentPlayer.CurrentQuizName == "bac") {

            certifcatetext.text = "Bachelor's Degree in " + player.CurrentPlayer.Course+" achieved.";
            HeaderText.text = "Bachelor's in " + player.CurrentPlayer.Course;
            player.CurrentPlayer.Bach.Add(new EduRec(certifcatetext.text, player.CurrentPlayer.CurrentQuizPercentage));
            AddSkills(player.CurrentPlayer.Course);
        } else if (player.CurrentPlayer.edu == "Uni Bachlor Year 2") {

            certifcatetext.text = "Uni Bachlor Year 2 achieved.";
            HeaderText.text = "Uni Bachlor Year 2";

        } else if (player.CurrentPlayer.edu == "Uni Bachlor Year 3") {

            certifcatetext.text = "Uni Bachlor Year 3 achieved.";
            HeaderText.text = "Uni Bachlor Year 3";

        } else if (player.CurrentPlayer.CurrentQuizName == "mas") {

            certifcatetext.text = "Master's Degree in " + player.CurrentPlayer.Course + " achieved.";
            HeaderText.text = "Master's in " +player.CurrentPlayer.Course;
            player.CurrentPlayer.Mast.Add(new EduRec(certifcatetext.text, player.CurrentPlayer.CurrentQuizPercentage));
            AddSkills(player.CurrentPlayer.Course);
        } else if (player.CurrentPlayer.CurrentQuizName == "phd") {

            certifcatetext.text = "PhD Degree in "+ player.CurrentPlayer.Course + " achieved.";
            HeaderText.text = "PhD in " + player.CurrentPlayer.Course;
            player.CurrentPlayer.Phd.Add(new EduRec(certifcatetext.text, player.CurrentPlayer.CurrentQuizPercentage));
            AddSkills(player.CurrentPlayer.Course);
        } else if (player.CurrentPlayer.IsPolySelected) {
            player.CurrentPlayer.Poly.Add(new EduRec("Diploma in " + player.CurrentPlayer.Course + " achieved.", player.CurrentPlayer.CurrentQuizPercentage));
            player.CurrentPlayer.Diplomas.Add("Diploma in " + player.CurrentPlayer.Course + " achieved.");
            certifcatetext.text = "Diploma in " + player.CurrentPlayer.Course + " achieved.";
            HeaderText.text = "Diploma in " + player.CurrentPlayer.Course;
            AddSkills(player.CurrentPlayer.Course);
            //Debug.Log(player.CurrentPlayer.edu);
        }
        player.CurrentPlayer.UpdateSkillsValueEqually();
        player.CurrentPlayer.UpdateMyValues();
        
    }
    private void AddSkills(string data) {
        UpdateSkillsValueEqually();
        SkillsTxt.text = "";
        switch (data) {
            case AppData.Fields.Accountancy:
                for (int i = 0; i < player.CurrentPlayer.Skills.Accountacy.Count; i++) {
                    string str = "";
                    if (player.CurrentPlayer.Skills.Accountacy[i].Cost > 0)
                    {
                        if (player.CurrentPlayer.Skills.Accountacy[i].GetStringRepresentation() != null)
                        {
                            str = player.CurrentPlayer.Skills.Accountacy[i].GetStringRepresentation();
                        }
                        else
                        {
                            str = player.CurrentPlayer.Skills.Accountacy[i].Cost.ToString("0.00");
                            if (player.CurrentPlayer.Skills.Accountacy[i].Cost > 6) str = "6";
                        }
                        Debug.Log("Poly-Acc: " + str);
                        player.CurrentPlayer.LifeCardSkills.Add(new EduRec(player.CurrentPlayer.Skills.Accountacy[i].title, (float)player.CurrentPlayer.Skills.Accountacy[i].Cost));
                        SkillsTxt.text += "+" + player.CurrentPlayer.Skills.Accountacy[i].title + ": " + str + "\n";
                    }
                }
                break;
            case AppData.Fields.HealthCare:
                for (int i = 0; i < player.CurrentPlayer.Skills.HealtCare.Count; i++) {
                    if (player.CurrentPlayer.Skills.HealtCare[i].Cost > 0)
                    {
                        string str = "";
                        if (player.CurrentPlayer.Skills.HealtCare[i].GetStringRepresentation() != null)
                        {
                            str = player.CurrentPlayer.Skills.HealtCare[i].GetStringRepresentation();
                        }
                        else
                        {
                            str = player.CurrentPlayer.Skills.HealtCare[i].Cost.ToString("0.00");
                            if (player.CurrentPlayer.Skills.HealtCare[i].Cost > 6) str = "6";
                        }
                        player.CurrentPlayer.LifeCardSkills.Add(new EduRec(player.CurrentPlayer.Skills.HealtCare[i].title, (float)player.CurrentPlayer.Skills.HealtCare[i].Cost));
                        SkillsTxt.text += "+" + player.CurrentPlayer.Skills.HealtCare[i].title + ": " + str + "\n";
                    }
                }
                break;
            case AppData.Fields.HumanResource:
                for (int i = 0; i < player.CurrentPlayer.Skills.HR.Count; i++) {
                    if (player.CurrentPlayer.Skills.HR[i].Cost > 0)
                    {
                        string str = "";
                        if (player.CurrentPlayer.Skills.HR[i].GetStringRepresentation() != null)
                        {
                            str = player.CurrentPlayer.Skills.HR[i].GetStringRepresentation();
                        }
                        else
                        {
                            str = player.CurrentPlayer.Skills.HR[i].Cost.ToString("0.00");
                            if (player.CurrentPlayer.Skills.HR[i].Cost > 6) str = "6";
                        }
                        Debug.Log("HR: " + str);
                        player.CurrentPlayer.LifeCardSkills.Add(new EduRec(player.CurrentPlayer.Skills.HR[i].title, (float)player.CurrentPlayer.Skills.HR[i].Cost));
                        SkillsTxt.text += "+" + player.CurrentPlayer.Skills.HR[i].title + ": " + str + "\n";
                    }
                }
                break;
            case AppData.Fields.InformationTechnology:
                for (int i = 0; i < player.CurrentPlayer.Skills.IT.Count; i++) {
                    if (player.CurrentPlayer.Skills.IT[i].Cost > 0)
                    {
                        string str = "";
                        if (player.CurrentPlayer.Skills.IT[i].GetStringRepresentation() != null)
                        {
                            str = player.CurrentPlayer.Skills.IT[i].GetStringRepresentation();
                        }
                        else
                        {
                            str = player.CurrentPlayer.Skills.IT[i].Cost.ToString("0.00");
                            if (player.CurrentPlayer.Skills.IT[i].Cost > 6) str = "6";
                        }
                        Debug.Log("IT: " + str);
                        player.CurrentPlayer.LifeCardSkills.Add(new EduRec(player.CurrentPlayer.Skills.IT[i].title, (float)player.CurrentPlayer.Skills.IT[i].Cost));
                        SkillsTxt.text += "+" + player.CurrentPlayer.Skills.IT[i].title + ": " + str + "\n";
                    }
                }
                break;
            case AppData.Fields.Media:
                for (int i = 0; i < player.CurrentPlayer.Skills.Media.Count; i++) {
                    if (player.CurrentPlayer.Skills.Media[i].Cost > 0)
                    {
                        string str = "";
                        if (player.CurrentPlayer.Skills.Media[i].GetStringRepresentation() != null)
                        {
                            str = player.CurrentPlayer.Skills.Media[i].GetStringRepresentation();
                        }
                        else
                        {
                            str = player.CurrentPlayer.Skills.Media[i].Cost.ToString("0.00");
                            if (player.CurrentPlayer.Skills.Media[i].Cost > 6) str = "6";
                        }
                        Debug.Log("MED: " + str);
                        player.CurrentPlayer.LifeCardSkills.Add(new EduRec(player.CurrentPlayer.Skills.Media[i].title, (float)player.CurrentPlayer.Skills.Media[i].Cost));
                        SkillsTxt.text += "+" + player.CurrentPlayer.Skills.Media[i].title + ": " + str + "\n";
                    }
                }
                break;
            case AppData.Fields.Retail:
                for (int i = 0; i < player.CurrentPlayer.Skills.Retail.Count; i++) {
                    if (player.CurrentPlayer.Skills.Retail[i].Cost > 0)
                    {
                        string str = "";
                        if (player.CurrentPlayer.Skills.Retail[i].GetStringRepresentation() != null)
                        {
                            str = player.CurrentPlayer.Skills.Retail[i].GetStringRepresentation();
                        }
                        else
                        {
                            str = player.CurrentPlayer.Skills.Retail[i].Cost.ToString("0.00");
                            if (player.CurrentPlayer.Skills.Retail[i].Cost > 6) str = "6";
                        }
                        Debug.Log("RET: " + str);
                        player.CurrentPlayer.LifeCardSkills.Add(new EduRec(player.CurrentPlayer.Skills.Retail[i].title, (float)player.CurrentPlayer.Skills.Retail[i].Cost));
                        SkillsTxt.text += "+" + player.CurrentPlayer.Skills.Retail[i].title + ": " + str + "\n";
                    }
                }
                break;
        }
    }
    public void UpdateSkillsValueEqually() {
        double a = player.CurrentPlayer.Skills.Accountacy[2].Cost;
        if (a > player.CurrentPlayer.Skills.HealtCare[0].Cost) {
            player.CurrentPlayer.Skills.HealtCare[0].Cost = a;
        }

        a = player.CurrentPlayer.Skills.Accountacy[3].Cost;
        if (a > player.CurrentPlayer.Skills.HR[1].Cost) {
            player.CurrentPlayer.Skills.HR[1].Cost = a;
        }
        if (a > player.CurrentPlayer.Skills.IT[2].Cost) {
            player.CurrentPlayer.Skills.IT[2].Cost = a;
        }
        if (a > player.CurrentPlayer.Skills.Media[0].Cost) {
            player.CurrentPlayer.Skills.Media[0].Cost = a;
        }
        if (a > player.CurrentPlayer.Skills.Retail[4].Cost) {
            player.CurrentPlayer.Skills.Retail[4].Cost = a;
        }

        a = player.CurrentPlayer.Skills.Accountacy[5].Cost;
        if (a > player.CurrentPlayer.Skills.Retail[7].Cost) {
            player.CurrentPlayer.Skills.Retail[7].Cost = a;
        }

        a = player.CurrentPlayer.Skills.Accountacy[6].Cost;
        if (a > player.CurrentPlayer.Skills.HealtCare[2].Cost) {
            player.CurrentPlayer.Skills.HealtCare[2].Cost = a;
        }

        a = player.CurrentPlayer.Skills.HealtCare[7].Cost;
        if (a > player.CurrentPlayer.Skills.HR[10].Cost) {
            player.CurrentPlayer.Skills.HR[10].Cost = a;
        }

        a = player.CurrentPlayer.Skills.HealtCare[10].Cost;
        if (a > player.CurrentPlayer.Skills.HR[11].Cost) {
            player.CurrentPlayer.Skills.HR[11].Cost = a;
        }

        a = player.CurrentPlayer.Skills.IT[4].Cost;
        if (a > player.CurrentPlayer.Skills.Media[2].Cost) {
            player.CurrentPlayer.Skills.Media[2].Cost = a;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickStatsBtn()
    {
        this.gameObject.SetActive(false);
        stats.SetActive(true);
    }
    public void onClickGameWorldBtn()
    {
        this.gameObject.SetActive(false);
        GamePlay.SetActive(true);
    }
    public void onClickBackToSchoolBtn()
    {
        
        
            this.gameObject.SetActive(false);
            SchoolMenu.SetActive(true);
        
    }
}
