using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaCourses : MonoBehaviour
{
    public DataBase DB;

    public GameObject ItemPrefab;

    public Transform Content;
    public GameObject quizScreen;
    public GameObject MainScreen;
    // Start is called before the first frame update
    void Start() {
        LoadDropDown();
    }

    // Update is called once per frame
    void Update() {

    }
    private void LoadDropDown() {
        Debug.Log(DB.skill.Media.Count);
        for (int i = 0; i < DB.skill.Media.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<item4>().Title.text = DB.skill.Media[i].title;

            item.GetComponent<Button>().onClick.AddListener(() => {
                MainScreen.SetActive(false);
                quizScreen.SetActive(true);

            });
        }


    }
}
