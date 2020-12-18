using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobNotAvailable : MonoBehaviour {

    public GameObject WorkFindJob;
    public Text BodyText;

    public void onClickWorkFindJobBtn() {
        WorkFindJob.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
