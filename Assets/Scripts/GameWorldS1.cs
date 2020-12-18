using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWorldS1 : MonoBehaviour
{
    public AppData AD;
    public GameObject nextScreen;
    public GameObject WorkScreen;
    public GameObject IndustriesScreen;
    public Text bodytxt;
    public GameObject ShopScreen;
    public GameObject ContinueEdu_FindJobScreen;
    public GameObject ContinueEduPopup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator Corout_Delay()
    {
        yield return new WaitForSeconds(1f);
        bodytxt.text = "You have " + AD.CurrentPlayer.RemainingActionPoints + " action points.\nWhat would you like to do?";
    }

    private void OnEnable() {
        AD.IsContinueEdu = false;
        StartCoroutine(Corout_Delay());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickSchoolBtn()
    {
        this.gameObject.SetActive(false);
        nextScreen.SetActive(true);
    }
    public void onClickWorkBtn() {
        this.gameObject.SetActive(false);
        WorkScreen.SetActive(true);
    }
    public void onClickContinueBtn() {
        if (AD.CurrentPlayer.Educations.Count < 2) {
            ContinueEduPopup.SetActive(true);
        } else {
            ContinueEdu_FindJobScreen.SetActive(true);
            this.gameObject.SetActive(false);
            AD.IsContinueEdu = true;
        }
    }
    public void CrossPopup() {
        ContinueEduPopup.SetActive(false);
    }
    public void onClickShopBtn() {
        ShopScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
