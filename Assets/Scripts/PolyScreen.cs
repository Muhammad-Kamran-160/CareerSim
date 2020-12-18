using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolyScreen : MonoBehaviour
{
    public GameObject SchoolLevel, UniLevel;
    public AppData course;
    public GameObject stats;
    public GameObject GamePlay;
    //public GameObject CousesScreen;
    public GameObject UnPassedLevelsScreen;
    public Text CourseScreenTitle;
    public Text CertiTxt;


    public GameObject selectedBtn;
    public AppData player;

    public GameObject AccountncyBtn;
    public GameObject HealthcareBtn;
    public GameObject HRBtn;
    public GameObject ITBtn;
    public GameObject RetailBtn;
    public GameObject MediaBtn;

    public GameObject AccountancyCourses;
    public GameObject healthCareCourses;
    public GameObject HRCourses;
    public GameObject ITCourses;
    public GameObject RetailCourses;
    public GameObject MediaCourses;
    public GameObject PopUp;
    public Text Title;
    public Text MainTxt;
    public Text panel;

    public Button NextButton;

    public Button AC;
    public Button HC;
    public Button HR;
    public Button IT;
    public Button Re;
    public Button Me;

    public Sprite Selected;
    public Sprite UnSelected;

    private void ChangeSprite(int index) {
        switch (index) {
            case 1:
                AC.image.sprite = Selected;
                HC.image.sprite = HR.image.sprite = IT.image.sprite = Me.image.sprite = Re.image.sprite = UnSelected;
                break;
            case 2:
                HC.image.sprite = Selected;
                AC.image.sprite = HR.image.sprite = IT.image.sprite = Me.image.sprite = Re.image.sprite = UnSelected;
                break;
            case 3:
                HR.image.sprite = Selected;
                HC.image.sprite = AC.image.sprite = IT.image.sprite = Me.image.sprite = Re.image.sprite = UnSelected;
                break;
            case 4:
                IT.image.sprite = Selected;
                HC.image.sprite = HR.image.sprite = AC.image.sprite = Me.image.sprite = Re.image.sprite = UnSelected;
                break;
            case 5:
                Re.image.sprite = Selected;
                HC.image.sprite = HR.image.sprite = IT.image.sprite = Me.image.sprite = AC.image.sprite = UnSelected;
                break;
            case 6:
                Me.image.sprite = Selected;
                HC.image.sprite = HR.image.sprite = IT.image.sprite = AC.image.sprite = Re.image.sprite = UnSelected;
                break;
        }
    }

    private void OnEnable() {

        AC.image.sprite = HC.image.sprite = HR.image.sprite = IT.image.sprite = Me.image.sprite = Re.image.sprite = UnSelected;

        NextButton.GetComponent<Button>().interactable = false;

        if (player.CurrentPlayer.IsPolySelected) {
            panel.text = "You need 2 AP and $500 to attempt this test.";
            Title.text = "Polytechnic";
            MainTxt.text = "Which diploma would you want to take?";
        } else {
            if (player.CurrentPlayer.edu == "Junior College" || course.Degree == "bac") {
                panel.text = "You need 3 AP and $1,000 to attempt this test.";
                Title.text = "Bachelor’s";
                MainTxt.text = "Which degree would you want to take?";
            } else if (player.CurrentPlayer.edu == "Junior College") {
                Debug.Log("dingdongding");
                panel.text = "You need 2 AP to attempt this test.";

            } else if (player.CurrentPlayer.edu == "Bachelor" || course.Degree == "mas") {
                panel.text = "You need 4 AP and $2,000 to attempt this test.";
                Title.text = "Master's";
                MainTxt.text = "Which degree would you want to take?";
            } else if (player.CurrentPlayer.edu == "Master" || course.Degree == "phd") {
                panel.text = "You need 5 AP and $3,000 to attempt this test.";
                Title.text = "PhD";
            }
        }
    }
    public void onClickBackButton() {
        if (course.CurrentPlayer.IsPolySelected)
        {
            // back to school level
            SchoolLevel.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            // back to uny level
            UniLevel.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PopUp.SetActive(false); 
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
    public void onClickNextBtn()
    {
        
        if (player.CurrentPlayer.edu == "Secondary" || player.CurrentPlayer.AccountancyClear == true)
        {
            
            this.gameObject.SetActive(false);
            selectedBtn.SetActive(true);
           // player.counter++;

        }
        else if (player.CurrentPlayer.edu == "Poly" || player.CurrentPlayer.HealthCareClear == true)
        {
            
            this.gameObject.SetActive(false);
            selectedBtn.SetActive(true);
            //player.counter++;
        }
        else if (player.CurrentPlayer.edu == "Poly" || player.CurrentPlayer.HRClear == true)
        {
           
            this.gameObject.SetActive(false);
            selectedBtn.SetActive(true);
          //  player.counter++;
        }
        else if (player.CurrentPlayer.edu == "Poly" || player.CurrentPlayer.ITClear == true)
        {
            
            this.gameObject.SetActive(false);
            selectedBtn.SetActive(true);
            //player.counter++;
        }
        else if (player.CurrentPlayer.edu == "Poly" || player.CurrentPlayer.RetailClear == true)
        {
            
            this.gameObject.SetActive(false);
            selectedBtn.SetActive(true);
            //player.counter++;
        }
        else if (player.CurrentPlayer.edu == "Poly" || player.CurrentPlayer.MediaClear == true)
        {
            
            this.gameObject.SetActive(false);
            selectedBtn.SetActive(true);
          //  player.counter++;
        }
        else
        {
            this.gameObject.SetActive(false);
            UnPassedLevelsScreen.SetActive(true);
        }
    }
    public void onClickAccountancyBtn()
    {
        ChangeSprite(1);
        NextButton.interactable = (true);
        course.CurrentPlayer.Course = AppData.Fields.Accountancy;
        PopUp.SetActive(true);
        CourseScreenTitle.text = "Accountancy";
        AccountancyCourses.SetActive(true);
        CertiTxt.text = "Accountancy Diploma acheived.";
        Debug.Log(course.Course);
        //CousesScreen.SetActive()
        selectedBtn = AccountncyBtn;
        
    }
    public void onClickHealthCareBtn() {
        ChangeSprite(2);
        NextButton.interactable = (true);
        course.CurrentPlayer.Course = AppData.Fields.HealthCare;
        PopUp.SetActive(true);
        CertiTxt.text = "Healthcare Diploma acheived.";
        CourseScreenTitle.text = "Healthcare";
        healthCareCourses.SetActive(true);
        Debug.Log(course.Course);
        selectedBtn = HealthcareBtn;
        
    }
    public void onClickHRBtn() {
        ChangeSprite(3);
        NextButton.interactable = (true);
        course.CurrentPlayer.Course = AppData.Fields.HumanResource;
        PopUp.SetActive(true);
        CertiTxt.text = "HR Diploma acheived.";
        CourseScreenTitle.text = "Human Resources";
        HRCourses.SetActive(true);
        Debug.Log(course.Course);
        selectedBtn = HRBtn;
        
    }
    public void onClickITBtn() {
        ChangeSprite(4);
        NextButton.interactable = (true);
        course.CurrentPlayer.Course = AppData.Fields.InformationTechnology;
        PopUp.SetActive(true);
        CertiTxt.text = "IT Diploma acheived.";
        CourseScreenTitle.text = "Information Technology";
        ITCourses.SetActive(true);
        Debug.Log(course.Course);
        selectedBtn = ITBtn;
       

    }
    public void onClickRetailBtn() {
        ChangeSprite(5);
        NextButton.interactable = (true);
        course.CurrentPlayer.Course = AppData.Fields.Retail;
        PopUp.SetActive(true);
        CertiTxt.text = "Retail Diploma acheived.";
        CourseScreenTitle.text = "Retail";
        Debug.Log(course.Course);
        selectedBtn = RetailBtn;
        RetailCourses.SetActive(true);

    }
    public void onClickMediaBtn() {
        ChangeSprite(6);
        NextButton.interactable = (true);
        course.CurrentPlayer.Course = AppData.Fields.Media;
        PopUp.SetActive(true);
        CertiTxt.text = "Media Diploma acheived.";
        CourseScreenTitle.text = "Media";
        Debug.Log(course.Course);
        selectedBtn = MediaBtn;
        MediaCourses.SetActive(true);


    }
    public void OnClickCross() {
        PopUp.SetActive(false);
    }
}
