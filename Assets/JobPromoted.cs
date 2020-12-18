using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobPromoted : MonoBehaviour {
    private IndusturiesJobLimit JobLimits;
    public AppData LocalDB;
    public Text ConguratsText;

    private void Start() {
        JobLimits = FindObjectOfType<IndusturiesJobLimit>();
    }

    private void OnEnable() {
        ConguratsText.text = "You have been promoted to\n";
        ConguratsText.text += LocalDB.MyFinalJob.JobTitle + ". Your new Salary is now $" + LocalDB.CurrentPlayer.GetCommaSeparatedAmount(LocalDB.MyFinalJob.Salary);
        // send updated data of job limit here.
    }

    public void onClickBackBtn() {
        this.gameObject.SetActive(false);
    }
}
