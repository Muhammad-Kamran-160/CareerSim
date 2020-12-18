using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoChoiceScreen : MonoBehaviour
{
    
    public AppData AD;
    public Text Lottery;
    public GameObject stats;
    public GameObject GamePlay;
    public GameObject Next;

    public GameObject SecondLifeCardScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnEnable() {
        //Debug.Log("Enabling", gameObject);
        if (Lottery == null)
            return;
        Lottery.text = "";
        Lottery.text = AD.LC.LifeCardDescription + "\n\n";
        if (AD.LC.ActionPoint != 0) {
            if (AD.LC.ActionPoint < 0) {
                //Lottery.text += "-";
            } else {
                Lottery.text += "+";
            }
            Lottery.text += AD.LC.ActionPoint + " AP\n\n";
        }

        if (AD.LC.Bank == 0) {
            //Lottery.text += "- $";
        } else {
            if (AD.LC.Bank < 0) {
                Lottery.text += "-$";
            } else {
                Lottery.text += "+$";
            }
            string str = Mathf.Abs(AD.LC.Bank).ToString();
            string str2 = "";
            int count = 0;
            for (int i = 0; i < str.Length; i++) {
                str2 += str[str.Length - 1 - i];
                count++;
                if (count % 3 == 0 && i != str.Length - 1) {
                    str2 += ",";
                }
            }
            string finalString = "";
            for (int i = 0; i < str2.Length; i++) {
                finalString += str2[str2.Length - 1 - i];
            }
            Lottery.text += finalString + "\n\n";
        }
        
        if(AD.LC.Skill == "") {
            //Lottery.text += "Skills: None\n\n";
        } else {
            //Lottery.text += "<b>Skills: </b> +" + AD.LC.Skill + "\n\n";
            Lottery.text += "<b>Skills: </b> \n";
            string[] s = AD.LC.Skill.Split(new char[1] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (string ss in s) {
                Lottery.text += "      +" + ss + "\n";
            }
            Lottery.text += '\n';
        }
        if(AD.LC.LifeStyleAndPossession == "") {
            //Lottery.text += "Lifestyle and Possessions: None";
        } else {
            Lottery.text += "<b>Lifestyle and Possessions:</b> \n      " + AD.LC.LifeStyleAndPossession;
        }

        AD.CurrentPlayer.Bank += AD.LC.Bank;
        AD.CurrentPlayer.RemainingActionPoints += AD.LC.ActionPoint;
        
        if (AD.LC.Skill != "") {
            char[] delimeters = new char[1] { ',' };
            string[] LC_Skills = AD.LC.Skill.Split(delimeters, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (SkillsDes skill in AD.CurrentPlayer.Skills.Accountacy) {
                foreach (string str in LC_Skills) {
                    if (str == skill.title) {
                        if (skill.Cost < 10) {
                            skill.Cost++;
                            Debug.Log("acc skill updated");
                        }
                    }
                }
            }
            foreach (SkillsDes skill in AD.CurrentPlayer.Skills.HealtCare) {
                foreach (string str in LC_Skills) {
                    if (str == skill.title) {
                        if (skill.Cost < 10) {
                            skill.Cost++;
                            Debug.Log("hc skill updated");
                        }
                    }
                }
            }
            foreach (SkillsDes skill in AD.CurrentPlayer.Skills.HR) {
                foreach (string str in LC_Skills) {
                    if (str == skill.title) {
                        if (skill.Cost < 10) {
                            skill.Cost++;
                            Debug.Log("hr skill updated");
                        }
                    }
                }
            }
            foreach (SkillsDes skill in AD.CurrentPlayer.Skills.IT) {
                foreach (string str in LC_Skills) {
                    if (str == skill.title) {
                        if (skill.Cost < 10) {
                            skill.Cost++;
                            Debug.Log("it skill updated");
                        }
                    }
                }
            }
            foreach (SkillsDes skill in AD.CurrentPlayer.Skills.Media) {
                foreach (string str in LC_Skills) {
                    if (str == skill.title) {
                        if (skill.Cost < 10) {
                            skill.Cost++;
                            Debug.Log("media skill updated");
                        }
                    }
                }
            }
            foreach (SkillsDes skill in AD.CurrentPlayer.Skills.Retail) {
                foreach (string str in LC_Skills) {
                    if (str == skill.title) {
                        if (skill.Cost < 10) {
                            skill.Cost++;
                            Debug.Log("retail skill updated");
                        }
                    }
                }
            }
            //AD.CurrentPlayer.LifeCardSkills.Add(AD.LC.Skill);   // life card opend level up in this skill....
        }
        
        if(AD.LC.LifeStyleAndPossession != "")
            AD.CurrentPlayer.Possession.Add(AD.LC.LifeStyleAndPossession);
        if (AD.LC.LifeStyleAndPossession == "Plus Economical Car") {
            AD.CurrentPlayer.ShopPossessions.Add(new Possession("Car", "Economy"));
        } else if (AD.LC.LifeStyleAndPossession == "Plus Luxury Mobile Phone") {
            AD.CurrentPlayer.ShopPossessions.Add(new Possession("Mobile Phone", "Luxury"));
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
    public void OnClickNextBtn() {
        this.gameObject.SetActive(false);
        if (AD.LifeCardEveryPerRound && AD.LifeCardEveryPerRoundTemp) {
            AD.LifeCardEveryPerRoundTemp = false;
            SecondLifeCardScreen.gameObject.SetActive(true);
        } else {
            Next.SetActive(true);
        }
    }
}
