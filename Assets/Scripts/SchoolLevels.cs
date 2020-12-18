using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolLevels : MonoBehaviour
{
    public AppData player;
    public GameObject PrimaryBtn;
    public GameObject SecondaryBtn;
    public GameObject JuniorClgBtn;
    public GameObject PloyBtn;
    public GameObject uniBtn;
    public GameObject PrimarySubjects;
    public GameObject SecondarySubjects;
    public GameObject PopUp;
    public GameObject next;
    public GameObject nextButton;
    public GameObject backButton;

    public GameObject UniLevelsScreen;
    public GameObject stats;
    public GameObject GamePlay;
    public GameObject QuestionScreen;
    public GameObject polyscreen;
    public GameObject UnPassedLevelsScreen;
    public GameObject PassedLevelsScreen;
    public Text panel;
    public Text bodyText;


    public Button BtnPri;
    public Button BtnSec;
    public Button BtnJun;
    public Button BtnPol;
    public Button BtnUni;

    public Sprite Selected;
    public Sprite UnSelected;


    private void OnEnable() {

        BtnPri.image.sprite = BtnSec.image.sprite = BtnJun.image.sprite = BtnPol.image.sprite = BtnUni.image.sprite = UnSelected;

        player.CurrentPlayer.IsPolySelected = false;
        bodyText.text = "You have "+player.CurrentPlayer.RemainingActionPoints+" action points.";
        nextButton.GetComponent<Button>().interactable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        PopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void ChangeSprite(int index) {
        switch (index) {
            case 1:
                BtnPri.image.sprite = Selected;
                BtnSec.image.sprite = BtnJun.image.sprite = BtnPol.image.sprite = BtnUni.image.sprite = UnSelected;
                break;
            case 2:
                BtnSec.image.sprite = Selected;
                BtnPri.image.sprite = BtnJun.image.sprite = BtnPol.image.sprite = BtnUni.image.sprite = UnSelected;
                break;
            case 3:
                BtnJun.image.sprite = Selected;
                BtnSec.image.sprite = BtnPri.image.sprite = BtnPol.image.sprite = BtnUni.image.sprite = UnSelected;
                break;
            case 4:
                BtnPol.image.sprite = Selected;
                BtnSec.image.sprite = BtnJun.image.sprite = BtnPri.image.sprite = BtnUni.image.sprite = UnSelected;
                break;
            case 5:
                BtnUni.image.sprite = Selected;
                BtnSec.image.sprite = BtnJun.image.sprite = BtnPol.image.sprite = BtnPri.image.sprite = UnSelected;
                break;
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
    public void onClickPrimaryLevelsBtn()
    {
        player.Degree = "pri";
        player.CurrentPlayer.IsPolySelected = false;
        ChangeSprite(1);
        if (player.CurrentPlayer.edu == "Null"  /*player.CurrentPlayer.PrimaryClear == true*/  /*&&  player.counter>=0*/)
        {
            nextButton.SetActive(false);
            backButton.SetActive(false);

            panel.text = "You need 1 AP to attempt this test.";
            PopUp.SetActive(true);
            // this.gameObject.SetActive(false);
            //PrimarySubjects.SetActive(true);

            nextButton.GetComponent<Button>().interactable = true;
            next = PrimaryBtn;
            //player.counter++;
        }
        else if(player.counter >0)
        {
            this.gameObject.SetActive(false);
            PassedLevelsScreen.SetActive(true);
        } else {
            this.gameObject.SetActive(false);
            UnPassedLevelsScreen.SetActive(true);
        }
    }
    public void onClickSecondaryLevelsBtn()
    {
        player.Degree = "sec";
        ChangeSprite(2);
        player.CurrentPlayer.IsPolySelected = false;
        Debug.Log("player.CurrentPlayer.edu: " + player.CurrentPlayer.edu +"&& player.CurrentPlayer.PrimaryScore: " + player.CurrentPlayer.PrimaryScore);
        if (player.CurrentPlayer.edu == "Primary" && player.counter >= 1/*&& player.CurrentPlayer.PrimaryScore>=4*/)
        {
            nextButton.SetActive(false);
            backButton.SetActive(false);
            panel.text = "You need 1 AP to attempt this test.";
            PopUp.SetActive(true);
            //this.gameObject.SetActive(false);
            //SecondarySubjects.SetActive(true);
            //player.counter++;
            nextButton.GetComponent<Button>().interactable = true;
            next = SecondaryBtn;
        } else if (player.counter > 1) {
            this.gameObject.SetActive(false);
            PassedLevelsScreen.SetActive(true);
        } else
        {
            this.gameObject.SetActive(false);
            UnPassedLevelsScreen.SetActive(true);
        }
    }
    public void onClickJuniorLevelsBtn()
    {
        player.Degree = "jun";
        ChangeSprite(3);
        player.CurrentPlayer.IsPolySelected = false;
        if (player.CurrentPlayer.edu == "Secondary" || player.CurrentPlayer.juniorClgClear == true && player.counter >= 2)
        {
            nextButton.SetActive(false);
            backButton.SetActive(false);
            panel.text = "You need 2 AP to attempt this test.";
            PopUp.SetActive(true);
            // this.gameObject.SetActive(false);
            //QuestionScreen.SetActive(true);
            //player.counter++;
            nextButton.GetComponent<Button>().interactable = true;
            next = JuniorClgBtn;
        } else if (player.counter > 2) {
            this.gameObject.SetActive(false);
            PassedLevelsScreen.SetActive(true);
        } else
        {
            this.gameObject.SetActive(false);
            UnPassedLevelsScreen.SetActive(true);
        }
    }
    public void onClickPolyLevelsBtn()
    {
        player.Degree = "pol";
        ChangeSprite(4);
        if (player.CurrentPlayer.edu != "Null" && player.CurrentPlayer.edu != "Primary")
        {
            player.CurrentPlayer.IsPolySelected = true;
            
            panel.text = "You need 2 AP and $500 to attempt this test.";
            //PopUp.SetActive(true);
            //this.gameObject.SetActive(false);
            //polyscreen.SetActive(true);
            //player.counter++;
            nextButton.GetComponent<Button>().interactable = true;
            next = PloyBtn;
        } else if (player.counter > 3) {
            this.gameObject.SetActive(false);
            PassedLevelsScreen.SetActive(true);
        } else
        {
            this.gameObject.SetActive(false);
            UnPassedLevelsScreen.SetActive(true);
        }
    }
    public void onClickUniLevelsBtn()
    {
        player.CurrentPlayer.IsPolySelected = false;
        ChangeSprite(5);
        bool polyFlag = false;
        for (int i = 0; i < player.CurrentPlayer.Poly.Count; i++) {
            if (player.CurrentPlayer.Poly[i].per >= 50) {
                polyFlag = true;
            }
        }
        if (polyFlag || player.CurrentPlayer.Educations.Count >= 3 || (player.CurrentPlayer.edu == "Junior College" || player.CurrentPlayer.edu == "Bachelor" || player.CurrentPlayer.edu == "Master" || player.CurrentPlayer.edu == "PhD") && player.counter >= 4)
        {
            panel.text = "You need 3 Ap to attempt this test.";
            //PopUp.SetActive(true);
            //this.gameObject.SetActive(false);
            //UniLevelsScreen.SetActive(true);
            //player.counter++;
            nextButton.GetComponent<Button>().interactable = true;
            next = uniBtn;
        } else if (player.counter > 8) {
            this.gameObject.SetActive(false);
            PassedLevelsScreen.SetActive(true);
        } else
        {
            this.gameObject.SetActive(false);
            UnPassedLevelsScreen.SetActive(true);
        }
    }
     public void OnClickCross() {
        nextButton.SetActive(true);
        backButton.SetActive(true);
        PopUp.SetActive(false);
     }
    public void OnClicknextBtn() {
        this.gameObject.SetActive(false);
        next.SetActive(true);
    }

}
