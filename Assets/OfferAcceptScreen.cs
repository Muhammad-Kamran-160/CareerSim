using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfferAcceptScreen : MonoBehaviour
{
    public AppData AD;
    public Text JobText;
    public GameObject Continue;
    public GameObject Back;
    public GameObject next;
    public GameObject GamePlay;
    public GameObject stats;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (JobText != null) {
            StartCoroutine(JobtextCoroutine());
        }
    }
    IEnumerator JobtextCoroutine() {
        yield return new WaitForSeconds(0.6f);
        JobText.text = "Your job is now\n" + AD.MyFinalJob.JobTitle;

        AD.MyFinalJob.FieldName = AD.CurrentPlayer.MyJob.FieldName;
        AD.MyFinalJob.JobTitle = AD.CurrentPlayer.MyJob.JobTitle;

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
    public void OnClickContinue() {

        AD.MyFinalJob.FieldName = AD.CurrentPlayer.MyJob.FieldName;
        AD.MyFinalJob.JobTitle = AD.CurrentPlayer.MyJob.JobTitle;

        Debug.Log("My JOB TITLE ON STARTING JOB ==>" + AD.MyFinalJob.JobTitle);
        Debug.Log("My JOB FINAL TITLE ON STARTING JOB => " + AD.CurrentPlayer.MyJob.JobTitle);

        Debug.Log("My JOB FIELD ON STARTING JOB ==>" + AD.MyFinalJob.FieldName);
        Debug.Log("My JOB FINAL FIELD ON STARTING JOB => " + AD.CurrentPlayer.MyJob.FieldName);

        AD.IsContinueEdu = false;
        this.gameObject.SetActive(false);
        Continue.SetActive(true);
    }
    public void OnClickBack() {
        this.gameObject.SetActive(false);
        Back.SetActive(true);
    }
    public void OnClickNext() {
        this.gameObject.SetActive(false);
        next.SetActive(true);
    }
    public void OnClickYes() {

        Debug.Log("My JOB TITLE ON STARTING JOB ==>" + AD.MyFinalJob.JobTitle);
        Debug.Log("My JOB FINAL TITLE ON STARTING JOB => " + AD.CurrentPlayer.MyJob.JobTitle);

        Debug.Log("My JOB FIELD ON STARTING JOB ==>" + AD.MyFinalJob.FieldName);
        Debug.Log("My JOB FINAL FIELD ON STARTING JOB => " + AD.CurrentPlayer.MyJob.FieldName);

        AD.CurrentPlayer.RemainingActionPoints -= 2;

        AD.CurrentPlayer.MyJob.FieldName = "";
        AD.CurrentPlayer.MyJob.JobTitle = "";
        AD.CurrentPlayer.MyJob.Salary = 0;

        this.gameObject.SetActive(false);
        Back.SetActive(true);
    }
}
