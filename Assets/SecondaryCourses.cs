using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryCourses : MonoBehaviour
{
    public GameObject selectedBtn;
    public GameObject testStartScreeen;
    public GameObject NextScreen;
    public GameObject GamePlay;
    public GameObject stats;

    public GameObject ChineseBtn;
    public GameObject BioBtn;
    public GameObject PysicsBtn;
    public GameObject GenralBtn;



    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnClickChineseBtn() {
        NextScreen.SetActive(true);
        selectedBtn = ChineseBtn;
    }
    public void OnClickBioBtn() {
        NextScreen.SetActive(true);
        selectedBtn = BioBtn;
    }
    public void OnClickPysicsBtn() {
        NextScreen.SetActive(true);
        selectedBtn = PysicsBtn;
    }
    public void OnClickGenralBtn() {
        NextScreen.SetActive(true);

        selectedBtn = GenralBtn;
    }
    public void OnClickNextBtn() {

        this.gameObject.SetActive(false);
        selectedBtn.SetActive(true);
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
