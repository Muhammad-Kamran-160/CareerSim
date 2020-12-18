using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScreen : MonoBehaviour
{
    public AppData AD;
    public Text Lottery;
    public GameObject stats;

    public GameObject GamePlay;
    public GameObject YesScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        Lottery.text = AD.LC.LifeCardDescription;
    }

    public void onYesBtn()
    {
        this.gameObject.SetActive(false);
        YesScreen.SetActive(true);
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
}
