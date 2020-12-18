using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupEduDropdown : MonoBehaviour {
    public AppData player;
    public DataBase DB;
    public int ReqCount;

    //public TypesOfCharacter Parent;
    public GameObject ItemPrefab;
    public GameObject EduOptions;
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
        for (int i = player.CurrentPlayer.Phd.Count-1; i > -1 ; i--) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = player.CurrentPlayer.Phd[i].edu;
        }
        for (int i = player.CurrentPlayer.Mast.Count - 1; i > -1; i--) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = player.CurrentPlayer.Mast[i].edu;
        }
        for (int i = player.CurrentPlayer.Bach.Count - 1; i > -1; i--) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = player.CurrentPlayer.Bach[i].edu;
        }
        for (int i = player.CurrentPlayer.Poly.Count - 1; i > -1; i--) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = player.CurrentPlayer.Poly[i].edu;
        }
        for (int i = player.CurrentPlayer.Educations.Count - 1; i > -1; i--) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = player.CurrentPlayer.Educations[i].edu;
        }

    }

    public void DropDownBtn() {
        EduOptions.SetActive(!EduOptions.activeSelf);
    }

}
