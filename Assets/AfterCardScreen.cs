using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterCardScreen : MonoBehaviour
{
    public Button NextBtn;
    public AppData LocalDB;
    public GameObject NextScreen;
    public GameObject stats;
    public GameObject GamePlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LocalDB.CurrentPlayer.Bank < 500) {
            NextBtn.interactable = false;
        } else {
            NextBtn.interactable = true;
        }
    }
    public void OnClickNextBtn() {
        LocalDB.CurrentPlayer.Bank -= 500;
        this.gameObject.SetActive(false);
        NextScreen.SetActive(true);
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
