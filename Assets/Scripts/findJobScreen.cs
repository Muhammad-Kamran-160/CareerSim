using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class findJobScreen : MonoBehaviour
{
    public AppData player;
    public GameObject GamePlay;
    public GameObject stats;
    public GameObject selectedBtn = null;
    public Text CourseScreenTitle;
    public GameObject JobsScreen;
    public GameObject BackScreen;

    public GameObject AccountancyBtn;
    public GameObject HealthCareBtn;
    public GameObject HRBtn;
    public GameObject ITBtn;
    public GameObject RetailBtn;
    public GameObject MediaBtn;

    public GameObject AccountncyJobs;
    public GameObject HealthcareJobs;
    public GameObject HRJobs;
    public GameObject ITJobs;
    public GameObject RetailJobs;
    public GameObject MediaJobs;

    public GameObject Popup;

    public Button NextBtn;

    public Button _AccBtn;
    public Button _HCBtn;
    public Button _HRBtn;
    public Button _ITBtn;
    public Button _RetBtn;
    public Button _MedBtn;
    public Sprite Selected;
    public Sprite UnSelected;

    private void OnEnable() {
        player.IsContinueEdu = true;
        _AccBtn.image.sprite = _HCBtn.image.sprite = _HRBtn.image.sprite = _ITBtn.image.sprite = _RetBtn.image.sprite = _MedBtn.image.sprite = UnSelected;
        NextBtn.interactable = false;
    }
    private void ChangeSprite(int index) {
        switch (index) {
            case 1:
                _AccBtn.image.sprite = Selected;
                _HCBtn.image.sprite = _HRBtn.image.sprite = _ITBtn.image.sprite = _RetBtn.image.sprite = _MedBtn.image.sprite = UnSelected;
                break;
            case 2:
                _HCBtn.image.sprite = Selected;
                _AccBtn.image.sprite = _HRBtn.image.sprite = _ITBtn.image.sprite = _RetBtn.image.sprite = _MedBtn.image.sprite = UnSelected;
                break;
            case 3:
                _HRBtn.image.sprite = Selected;
                _HCBtn.image.sprite = _AccBtn.image.sprite = _ITBtn.image.sprite = _RetBtn.image.sprite = _MedBtn.image.sprite = UnSelected;
                break;
            case 4:
                _ITBtn.image.sprite = Selected;
                _HCBtn.image.sprite = _HRBtn.image.sprite = _AccBtn.image.sprite = _RetBtn.image.sprite = _MedBtn.image.sprite = UnSelected;
                break;
            case 5:
                _RetBtn.image.sprite = Selected;
                _HCBtn.image.sprite = _HRBtn.image.sprite = _ITBtn.image.sprite = _AccBtn.image.sprite = _MedBtn.image.sprite = UnSelected;
                break;
            case 6:
                _MedBtn.image.sprite = Selected;
                _HCBtn.image.sprite = _HRBtn.image.sprite = _ITBtn.image.sprite = _RetBtn.image.sprite = _AccBtn.image.sprite = UnSelected;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        NextBtn.interactable = false;
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
    public void onClickNextBtn()
    {
        this.gameObject.SetActive(false);
        JobsScreen.SetActive(true);
        selectedBtn.SetActive(true);
    }
    public void onClickCrossBtn() {
        Popup.SetActive(false);
    }
    public void onClickAccountancyBtn() {
        ChangeSprite(1);
        player.feildskills = "Accountancy";
        CourseScreenTitle.text = "Accountancy skills";
        Popup.SetActive(true);
        AccountncyJobs.SetActive(true);
        selectedBtn = AccountancyBtn;
        NextBtn.interactable = true;

    }
    public void onClickHealthCareBtn() {
        ChangeSprite(2);
        player.feildskills = "HC";
        CourseScreenTitle.text = "Healthcare skills";
        Popup.SetActive(true);
        HealthcareJobs.SetActive(true);
        selectedBtn = HealthCareBtn;
        NextBtn.interactable = true;

    }
    public void onClickHRBtn() {
        ChangeSprite(3);
        player.feildskills = "HR";
        CourseScreenTitle.text = "Human Resources skills";
        Popup.SetActive(true);
        HRJobs.SetActive(true);
        selectedBtn = HRBtn;
        NextBtn.interactable = true;
    }
    public void onClickITBtn() {
        ChangeSprite(4);
        player.feildskills = "IT";
        CourseScreenTitle.text = "Information Technology skills";
        Popup.SetActive(true);
        ITJobs.SetActive(true);
        selectedBtn = ITBtn;
        NextBtn.interactable = true;

    }
    public void onClickRetailBtn() {
        ChangeSprite(5);
        player.feildskills = "Retail";
        CourseScreenTitle.text = "Retail skills";
        Popup.SetActive(true);
        selectedBtn = RetailBtn;
        RetailJobs.SetActive(true);
        NextBtn.interactable = true;
    }
    public void onClickMediaBtn() {
        ChangeSprite(6);
        player.feildskills = "Media";
        CourseScreenTitle.text = "Media skills";
        Popup.SetActive(true);
        selectedBtn = MediaBtn;
        MediaJobs.SetActive(true);
        NextBtn.interactable = true;

    }
    public void OnClickBackabtn() {
        this.gameObject.SetActive(false);
        BackScreen.SetActive(true);
    }
}
