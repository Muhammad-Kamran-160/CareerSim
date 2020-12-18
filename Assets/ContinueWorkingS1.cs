using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueWorkingS1 : MonoBehaviour
{
    public AppData course;
    public GameObject stats;
    public GameObject GamePlay;
    public GameObject ACC;
    public GameObject HC;
    public GameObject HR;
    public GameObject IT;
    public GameObject RT;
    public GameObject Me;
    public GameObject NextScreen;


    // Start is called before the first frame update
    private void OnEnable() {

        course.MyFinalJob.FieldName = course.CurrentPlayer.MyJob.FieldName;
        course.MyFinalJob.JobTitle = course.CurrentPlayer.MyJob.JobTitle;

        course.SelectThree.Clear();
        Debug.Log("My JOB TITLE ON STARTING JOB ==>" + course.MyFinalJob.JobTitle);
        Debug.Log("My JOB FINAL TITLE ON STARTING JOB => " + course.CurrentPlayer.MyJob.JobTitle);

        Debug.Log("My JOB FIELD ON STARTING JOB ==>" + course.MyFinalJob.FieldName);
        Debug.Log("My JOB FINAL FIELD ON STARTING JOB => " + course.CurrentPlayer.MyJob.FieldName);
        switch (course.MyFinalJob.FieldName) {
            case AppData.Fields.Accountancy:
                ACC.SetActive(true);
                break;
            case AppData.Fields.HumanResource:
                HR.SetActive(true);
                break;
            case AppData.Fields.InformationTechnology:
                IT.SetActive(true);
                break;
            case AppData.Fields.HealthCare:
                HC.SetActive(true);
                break;
            case AppData.Fields.Retail:
                RT.SetActive(true);
                break;
            case AppData.Fields.Media:
                Me.SetActive(true);
                break;
        }
    }
    private void OnDisable() {
        ACC.SetActive(false);
        HC.SetActive(false);
        HR.SetActive(false);
        IT.SetActive(false);
        RT.SetActive(false);
        Me.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        NextScreen.SetActive(true);
    }
}
