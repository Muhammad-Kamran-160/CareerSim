using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public AppData LocalDB;
    public Text JobTitle;
    public Text EducationLevel;
    public Text Possessions;
    public Text Skills;
    public Text Bank;
    public Text Satisfaction;

    private void OnEnable() {
        UpdatePopup();
    }

    private void UpdatePopup() {
        if (string.IsNullOrEmpty(LocalDB.MyFinalJob.JobTitle)) {
            JobTitle.text = " None";
            //Debug.Log("===========================> " + LocalDB.MyFinalJob.JobTitle);

        } else {
            JobTitle.text = " " + LocalDB.MyFinalJob.JobTitle;
        }

        if (LocalDB.CurrentPlayer.Bank <= 0) {
            Bank.text = " $0";
        } else {
            Bank.text = " $" + LocalDB.CurrentPlayer.BankString + "";
        }
        Satisfaction.text = " " + LocalDB.CurrentPlayer.SatisfactionLevel + "/10";
    }

    private void Start() {
        UpdatePopup();
    }

    public void Cross() {
        this.gameObject.SetActive(false);
    }
}
