using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HRCourses : MonoBehaviour
{
    public DataBase DB;

    public GameObject ItemPrefab;

    public Transform Content;
    public GameObject quizScreen;
    public GameObject MainScreen;
    // Start is called before the first frame update
    void Start()
    {
        LoadDropDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LoadDropDown() {
        Debug.Log(DB.skill.HR.Count);
        for (int i = 0; i < DB.skill.HR.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<item4>().Title.text = DB.skill.HR[i].title;

            item.GetComponent<Button>().onClick.AddListener(() => {
                MainScreen.SetActive(false);
                quizScreen.SetActive(true);

            });
        }


    }
}
