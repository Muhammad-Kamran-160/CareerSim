using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimarySubjects : MonoBehaviour
{
    public GameObject selectedBtn;
    public GameObject testStartScreeen;
    public GameObject NextScreen;
    public GameObject GamePlay;
    public GameObject stats;

    public GameObject ScienceBtn;
    public GameObject SocialBtn;
    public GameObject ComputerBtn;
    public GameObject englisBtn;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickScienceBtn() {
        NextScreen.SetActive(true);
        selectedBtn = ScienceBtn;
    }
    public void OnClickSocialBtn() {
        NextScreen.SetActive(true);
        selectedBtn = SocialBtn;
    }
    public void OnClickComputerBtn() {
        NextScreen.SetActive(true);
        selectedBtn = ComputerBtn;
    }
    public void OnClickEnglishBtn() {
        NextScreen.SetActive(true);

        selectedBtn = englisBtn;
    }
    public void OnClickNextBtn() {

        this.gameObject.SetActive(false);
        selectedBtn.SetActive(true);
    }
    public void onClickStatsBtn() {
        this.gameObject.SetActive(false);
        stats.SetActive(true);
    }
    public void onClickGameWorldBtn() {
        this.gameObject.SetActive(false);
        GamePlay.SetActive(true);
    }
}
