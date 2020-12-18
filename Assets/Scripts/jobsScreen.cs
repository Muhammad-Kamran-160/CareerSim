using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jobsScreen : MonoBehaviour
{
    public AppData AD;
    public GameObject NextScreen;
    public GameObject stats;

    public GameObject ACC;
    public GameObject HC;
    public GameObject HR;
    public GameObject IT;
    public GameObject RT;
    public GameObject Me;

    public GameObject GamePlay;
    public GameObject FindJobScreen;

    public bool check = false;

    private void OnDisable() {
        check = false;
        ACC.SetActive(false);
        HC.SetActive(false);
        HR.SetActive(false);
        IT.SetActive(false);
        RT.SetActive(false);
        Me.SetActive(false);
    }
    private void OnEnable() {
        check = true;
        switch (AD.feildskills) {
            case "Accountancy":
                ACC.SetActive(true);
                break;
            case "HR":
                HR.SetActive(true);
                break;
            case "IT":
                IT.SetActive(true);
                break;
            case "HC":
                HC.SetActive(true);
                break;
            case "Retail":
                RT.SetActive(true);
                break;
            case "Media":
                Me.SetActive(true);
                break;
        }
    }

    // Start is called before the first frame update
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
    public void onClickBackBtn() {
        AD.SelectThree.Clear();
        FindJobScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
