using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSkillsDropdown : MonoBehaviour {
    public AppData LocalDB;
    public DataBase DB;
    public int ReqCount;

    //public TypesOfCharacter Parent;
    public GameObject ItemPrefab;
    public GameObject SkillsDropdownOptions;
    public Transform Content;

    void Start() {
        LoadDropDown();
    }
    private void OnEnable() {
        LoadDropDown();
    }

    private void LoadDropDown() {
        for (int i = 0; i < Content.childCount; i++) {
            Destroy(Content.transform.GetChild(i).gameObject);
        }
        List<SkillsDes> list = LocalDB.CurrentPlayer.GetMySkills();
        for (int i = 0; i < list.Count; i++) {
            if (list[i].Cost > 0) {
                GameObject item = Instantiate(ItemPrefab, Content);
                double c = list[i].Cost;
                if (c > 6) c = 6;
                string str = "";
                if (list[i].GetStringRepresentation() != null) {
                    str = list[i].GetStringRepresentation();
                } else {
                    str = c.ToString("0.00");
                }
                item.GetComponent<Item2>().Title.text = " " + list[i].title + ": " + str;
            }
        }
    }

    public void DropDownBtn() {
        SkillsDropdownOptions.SetActive(!SkillsDropdownOptions.activeSelf);
    }
}
