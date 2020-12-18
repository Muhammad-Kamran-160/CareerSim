using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolyLevelScreen : MonoBehaviour
{
    public AppData AD;
    public Text Title;
    public Text BodyTxt;
    public GameObject stats;

    public GameObject GamePlay;
    public GameObject QuestionScreen;
    public GameObject backScreen;

    public Button NextBtn;

    private void OnEnable() {
        BodyTxt.text = "You have "+ AD.CurrentPlayer.RemainingActionPoints+" action points.\n\nYou have to pass\nthis test to\ngraduate.";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AD.CurrentPlayer.RemainingActionPoints < 2 || AD.CurrentPlayer.Bank < 500) {
            NextBtn.interactable = false;
        } else {
            NextBtn.interactable = true;
        }
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
        AD.CurrentPlayer.Bank -= 500;
        AD.CurrentPlayer.RemainingActionPoints -= 2;
        this.gameObject.SetActive(false);
        QuestionScreen.SetActive(true);
    }
    public void onClickBackBtn()
    {
        this.gameObject.SetActive(false);
        backScreen.SetActive(true);
    }
}
