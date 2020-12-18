using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uniLevels : MonoBehaviour
{
    public Text HeaderTxt;
    public Text text;
    public Text BodyText;
    public GameObject BachlorLevelsScreen;
    public GameObject stats;
    public GameObject BackScreen;

    public GameObject GamePlay;
    public GameObject QuestionScreen;
    public GameObject unPassedLevelScreen;
    public GameObject PassedLevelScreen;
    public AppData player;

    public GameObject NotEnouhPercentageScreen;
    public Text NotEnouhPercentageScreenText;

    private void OnEnable() {
        BodyText.text= "You have " + player.CurrentPlayer.RemainingActionPoints + " action points.";
    }
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
    public void onClickBAckBtn() {
        this.gameObject.SetActive(false);
        BackScreen.SetActive(true);
    }

    public void onClickBachlorLevelsBtn()
    {
        bool flag = false;
        for (int i = 0; i < player.CurrentPlayer.Poly.Count; i++) {
            if (player.CurrentPlayer.Poly[i].per >= 50f || player.CurrentPlayer.Educations[player.CurrentPlayer.Educations.Count-1].per >= 90f) {
                flag = true;
                break;
            }
        }
        if (player.CurrentPlayer.Educations[player.CurrentPlayer.Educations.Count - 1].per >= 90f) {
            flag = true;
        }
        if (!flag) {
            // you have these percentages but you need poly per this and jun col per this.
            NotEnouhPercentageScreenText.text = "";
            NotEnouhPercentageScreenText.text = "You have " + player.CurrentPlayer.Educations[player.CurrentPlayer.Educations.Count - 1].per + "% in Junior College and " +
                 " below 50% in your Diploma of Polytechnic.\n You need atleast 50% in Polytechnic or 90% in Junior College.";
            this.gameObject.SetActive(false);
            NotEnouhPercentageScreen.SetActive(true);
        } else {
            player.Degree = "bac";
            Debug.Log(player.counter);
            bool polyFlag = false;
            for (int i = 0; i < player.CurrentPlayer.Poly.Count; i++) {
                if (player.CurrentPlayer.Poly[i].per >= 50) {
                    polyFlag = true;
                }
            }
            if (polyFlag || player.CurrentPlayer.Educations.Count >= 3 || player.CurrentPlayer.edu == "Junior College" || player.CurrentPlayer.BachelorsDone || player.counter == 4) {
                this.gameObject.SetActive(false);
                BachlorLevelsScreen.SetActive(true);
                //player.counter++;
            } else {
                this.gameObject.SetActive(false);
                PassedLevelScreen.SetActive(true);
            }
        }
    }
    
    public void onClickMasterBtn()
    {
        player.Degree = "mas";
        if (player.CurrentPlayer.edu == "Bachelor" || player.CurrentPlayer.MastersDone /*|| player.CurrentPlayer.MasterClear == true*/)
        {
            bool flag = false;
            for (int i = 0; i < player.CurrentPlayer.Bach.Count; i++) {
                if(player.CurrentPlayer.Bach[i].per > 70f) {
                    flag = true;
                    break;
                }
            }
            if (flag) {
                HeaderTxt.text = "Master";
                text.text = "Which Course do you want to take?";
                this.gameObject.SetActive(false);
                QuestionScreen.SetActive(true);
                //player.counter++;
            } else {
                // you do not have enoug percentage.
                NotEnouhPercentageScreenText.text = "";
                NotEnouhPercentageScreenText.text = "You have below 70% in your Bachelor's degree.\n You need above 70% in Bachelor's degree.";
                this.gameObject.SetActive(false);
                NotEnouhPercentageScreen.SetActive(true);
            }
        } else {
            this.gameObject.SetActive(false);
            unPassedLevelScreen.SetActive(true);
        }
    }
    public void onClickPhDBtn()
    {
        player.Degree = "phd";
        if (player.CurrentPlayer.edu == "Master" || player.CurrentPlayer.MastersDone || player.CurrentPlayer.PhdDone || player.CurrentPlayer.PhDClear == true)
        {
            bool flag = false;
            for (int i = 0; i < player.CurrentPlayer.Mast.Count; i++) {
                if (player.CurrentPlayer.Mast[i].per > 70) {
                    flag = true;
                    break;
                }
            }
            if (flag) {
                HeaderTxt.text = "PhD";
                text.text = "Which Course do you want to take?";
                this.gameObject.SetActive(false);
                QuestionScreen.SetActive(true);
                //player.counter++;
            } else {
                // you do not have enough percetage in masters
                NotEnouhPercentageScreenText.text = "You have below 70% in your Master's degree.\n You need above 70% in Master's degree.";
                this.gameObject.SetActive(false);
                NotEnouhPercentageScreen.SetActive(true);
            }
        } else {
            this.gameObject.SetActive(false);
            unPassedLevelScreen.SetActive(true);
        }
    }

}
//if (player.CurrentPlayer.edu == "Master" || player.CurrentPlayer.PhDClear == true)