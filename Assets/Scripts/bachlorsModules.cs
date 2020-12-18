using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bachlorsModules : MonoBehaviour

{
    public Text HeaderTxt;
    public Text text;
    public GameObject stats;

    public GameObject GamePlay;
    public GameObject QuestionScreen;
    public GameObject unPassedLevelScreen;
    public AppData player;
    // Start is called before the first frame update
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
    public void onClickModule1Btn()
    {
        if (player.CurrentPlayer.edu == "Junior College" || player.CurrentPlayer.BachY1Clear == true)
        {
            HeaderTxt.text = "Bachelor";
            text.text = "Which Course do you want to take?";
            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
            unPassedLevelScreen.SetActive(true);
        }
    }
    public void onClickModule2Btn()
    {
        if (player.CurrentPlayer.edu == "Uni Bachlor Year 1" || player.CurrentPlayer.BachY2Clear == true)
        {
            HeaderTxt.text = "Bachelor";
            text.text = "Which Course do you want to take?";
            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
            unPassedLevelScreen.SetActive(true);
        }
    }
    public void onClickModule3Btn()
    {
        if (player.CurrentPlayer.edu == "Uni Bachlor Year 2" || player.CurrentPlayer.BachY3clear == true)
        {
            HeaderTxt.text = "Bachelor";
            text.text = "Which Course do you want to take?";
            this.gameObject.SetActive(false);
            QuestionScreen.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
            unPassedLevelScreen.SetActive(true);
        }
    }
}
