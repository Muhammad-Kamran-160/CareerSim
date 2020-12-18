using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findingJob : MonoBehaviour
{
    public AppData AD;
    public GameObject OfferScreen;
    public GameObject NotEligibleScreen;
    public GameObject NotAvailableScreen;
    public GameObject GamePlay;
    public GameObject stats;

    public bool available;
    public bool NotEligible;
    public bool NotAvailable;

    //private void OnEnable() {
    //    if (available) {
    //        this.gameObject.SetActive(false);
    //        OfferScreen.SetActive(true);
    //    } else if (NotAvailable) {
    //        this.gameObject.SetActive(false);
    //        NotAvailableScreen.SetActive(true);
    //    } else if(NotEligible) {
    //        this.gameObject.SetActive(false);
    //        NotEligibleScreen.SetActive(true);
    //    }
    //}

    private void OnEnable() {
        StartCoroutine(LoadJobCorout(3f));
    }

    IEnumerator LoadJobCorout(float Delatime) {
        
        yield return new WaitForSeconds(Delatime);

        //AD.CurrentPlayer.MyJob.FieldName
        this.gameObject.SetActive(false);
        OfferScreen.SetActive(true);

        //if (available) {
        //    this.gameObject.SetActive(false);
        //    OfferScreen.SetActive(true);
        
        //} else if (NotAvailable) {
        //    this.gameObject.SetActive(false);
        //    NotAvailableScreen.SetActive(true);

        //} else if (NotEligible) {
        //    this.gameObject.SetActive(false);
        //    NotEligibleScreen.SetActive(true);
        //}
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
}
