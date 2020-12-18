using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkFindJob : MonoBehaviour
{
    [SerializeField] private IndusturiesJobLimit JobLimits;
    public DataBase DB;
    public AppData LocalDB;

    public GameObject GamePlay;
    public GameObject stats;
    public GameObject selectedBtn;
    //public Text CourseScreenTitle;
    //public GameObject JobsScreen;
    public GameObject BackScreen;

    public GameObject AccountancyBtn;
    public GameObject HealthCareBtn;
    public GameObject HRBtn;
    public GameObject ITBtn;
    public GameObject RetailBtn;
    public GameObject MediaBtn;

    public GameObject AccountncyJobs;
    public GameObject HealthcareJobs;
    public GameObject HRJobs;
    public GameObject ITJobs;
    public GameObject RetailJobs;
    public GameObject MediaJobs;
    public GameObject JobNotAvailableScreen;

    public Button NextBtn;

    // Start is called before the first frame update
    void Start() {

    }
    private void OnEnable() {
        NextBtn.interactable = false;
        JobLimits.GetJobLimitsData();
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
    public void onClickNextBtn() {
        this.gameObject.SetActive(false);
        //JobsScreen.SetActive(true);
        selectedBtn.SetActive(true);
    }
    public void onClickAccountancyBtn() {
        //if (DB.industries.AccountancyJobs < DB.industries.JobLimit) {
        if (JobLimits.accounting.total_lower < JobLimits.accounting.total_upper) {
            NextBtn.interactable = true;
            //CourseScreenTitle.text = "Accountancy Jobs";
            LocalDB.CurrentPlayer.MyJob.FieldName = AppData.Fields.Accountancy;
            //AccountncyJobs.SetActive(true);
            selectedBtn = AccountncyJobs;
            //DB.industries.AccountancyJobs++;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, No job is available in this industry.";
        }

    }
    public void onClickHealthCareBtn() {
        //if (DB.industries.HCJobs < DB.industries.JobLimit) {
        if (JobLimits.healthcare.total_lower < JobLimits.healthcare.total_upper) {
            NextBtn.interactable = true;
            //CourseScreenTitle.text = "Healthcare Jobs";
            LocalDB.CurrentPlayer.MyJob.FieldName = AppData.Fields.HealthCare;
            //HealthcareJobs.SetActive(true);
            selectedBtn = HealthcareJobs;
            //DB.industries.HCJobs++;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, No job is available in this industry.";
        }


    }
    public void onClickHRBtn() {
        //if (DB.industries.HRJobs < DB.industries.JobLimit) {
        if (JobLimits.healthcare.total_lower < JobLimits.healthcare.total_upper) {
            NextBtn.interactable = true;
            //CourseScreenTitle.text = "Human Resources Jobs";
            LocalDB.CurrentPlayer.MyJob.FieldName = AppData.Fields.HumanResource;
            //HRJobs.SetActive(true);
            selectedBtn = HRJobs;
            //DB.industries.HRJobs++;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, No job is available in this industry.";
        }

    }
    public void onClickITBtn() {
        //if (DB.industries.ITJobs < DB.industries.JobLimit) {
        if (JobLimits.informationTechnology.total_lower < JobLimits.informationTechnology.total_upper) {
            NextBtn.interactable = true;
            //CourseScreenTitle.text = "Information Technology Jobs";
            LocalDB.CurrentPlayer.MyJob.FieldName = AppData.Fields.InformationTechnology;
            //ITJobs.SetActive(true);
            selectedBtn = ITJobs;
            //DB.industries.ITJobs++;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, No job is available in this industry.";
        }


    }
    public void onClickRetailBtn() {
        //if (DB.industries.RetailJobs < DB.industries.JobLimit) {
        if (JobLimits.retail.total_lower < JobLimits.retail.total_upper) {
            NextBtn.interactable = true;
            //CourseScreenTitle.text = "Retail Jobs";
            LocalDB.CurrentPlayer.MyJob.FieldName = AppData.Fields.Retail;
            selectedBtn = RetailJobs;
            //RetailJobs.SetActive(true);
            //DB.industries.RetailJobs++;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, No job is available in this industry.";
        }

    }
    public void onClickMediaBtn() {
        //if (DB.industries.MediaJobs < DB.industries.JobLimit) {
        if (JobLimits.media.total_lower < JobLimits.media.total_upper) {
            NextBtn.interactable = true;
            //CourseScreenTitle.text = "Media";
            LocalDB.CurrentPlayer.MyJob.FieldName = AppData.Fields.Media;
            selectedBtn = MediaJobs;
            //MediaJobs.SetActive(true);
            //DB.industries.MediaJobs++;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, No job is available in this industry.";
        }


    }
    public void OnClickBackabtn() {
        this.gameObject.SetActive(false);
        BackScreen.SetActive(true);
    }
    public void JobAvailableCheck() {
        
    }
}
