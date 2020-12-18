using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCareCourses : MonoBehaviour
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
        Debug.Log(DB.skill.HealtCare.Count);
        for (int i = 0; i < DB.skill.HealtCare.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<item4>().Title.text = DB.skill.HealtCare[i].title;

            item.GetComponent<Button>().onClick.AddListener(() => {
                MainScreen.SetActive(false);
                quizScreen.SetActive(true);

            });
        }


    }
}
