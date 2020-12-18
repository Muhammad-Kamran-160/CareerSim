using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courses : MonoBehaviour

{
    public GameObject quizScreen;
    public GameObject stats;

    public GameObject GamePlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickCourse() {
        this.gameObject.SetActive(false);
        quizScreen.SetActive(true);
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
