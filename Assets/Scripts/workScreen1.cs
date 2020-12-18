using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class workScreen1 : MonoBehaviour
{
    public AppData AD;
    public GameObject GamePlay;
    public GameObject stats;
    public GameObject findJobScreen;
    public GameObject NOJobYetS;
    public GameObject ContinueEdu;
    public GameObject State;
    public GameObject FindJobBtn;
    public GameObject ContinueWorkBtn;
    public GameObject Back;
    public GameObject nextButton;
    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable() {
        nextButton.GetComponent<Button>().interactable = false;
        ContinueWorkBtn.SetActive(!string.IsNullOrEmpty(AD.MyFinalJob.JobTitle));
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
    public void onClickFindJobBtn()
    {
        if (check == false) {
            //this.gameObject.SetActive(false);
            //findJobScreen.SetActive(true);
            State = findJobScreen;
            nextButton.GetComponent<Button>().interactable = true;
        } else {

            NOJobYetS.gameObject.SetActive(true);
            State = findJobScreen;
            //this.gameObject.SetActive(false);
        }
    }
    public void onClickContinueEduBtn() {
       // this.gameObject.SetActive(false);
        //ContinueEdu.SetActive(true);
        State = ContinueEdu;
        nextButton.GetComponent<Button>().interactable = true;
    }
    public void onClickNextBtn() {
        this.gameObject.SetActive(false);
        State.SetActive(true);
    }
    public void onClickBackBtn() {
        this.gameObject.SetActive(false);
        Back.SetActive(true);
    }
}
