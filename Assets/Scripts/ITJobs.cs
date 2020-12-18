using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ITJobs : MonoBehaviour
{
    public jobsScreen ParentGameObject;
    public AppData AD;
    //public skills Parent;
    public GameObject ItemPrefab;

    public Transform Content;

    public GameObject MainScreen;

    public GameObject NextScreen;
    public GameObject state;

    public Button NextBtn;
    public List<GameObject> ButtonsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {
        LoadDropDown();
    }
    private void OnEnable() {
        LoadDropDown();
        NextBtn.interactable = false;
        AD.SelectThree.Clear();
    }
    // Update is called once per frame
    void Update() {
    }
    private void LoadDropDown() {
        ButtonsList.Clear();
        for (int i = 0; i < Content.transform.childCount; i++) {
            Destroy(Content.GetChild(i).gameObject);
        }
        
        Debug.Log("IT count: " + AD.CurrentPlayer.Skills.IT.Count);

        for (int i = 0; i < AD.CurrentPlayer.Skills.IT.Count; i++) {
            Debug.Log("dcascacsccacscscascasc");
            GameObject item = Instantiate(ItemPrefab, Content);
            //item.transform.GetChild(2).gameObject.SetActive(false);
            item.GetComponent<item5>().Title.text = AD.CurrentPlayer.Skills.IT[i].title;

            item.GetComponent<item5>().index = i;
            item.GetComponent<item5>().Btn.onClick.AddListener(() => {
                //MainScreen.SetActive(false);
                //NextScreen.SetActive(true);
                //state = NextScreen;
                //if (AD.SelectThree.Count < AppData.selectionLimit)
                //{
                //    AppData.ThreeSelection selection = new AppData.ThreeSelection();
                //    selection.ListName = AppData.Fields.InformationTechnology;
                //    selection.Listindex = item.GetComponent<item5>().index;
                //    AD.SelectThree.Add(selection);
                //}
                if (item.GetComponent<item5>().isSelected) {
                    ColorBlock c = item.GetComponent<item5>().Btn.colors;
                    //c.normalColor = new Color32(81, 169, 171, 255);
                    c.normalColor = Color.white;
                    c.highlightedColor = Color.white;
                    item.GetComponent<item5>().Btn.colors = c;
                    //state = NextScreen;
                    AppData.ThreeSelection selection = new AppData.ThreeSelection();
                    selection.ListName = AppData.Fields.InformationTechnology;
                    selection.Listindex = item.GetComponent<item5>().index;
                    foreach (GameObject button in ButtonsList) {
                        if (button != null) {
                            button.GetComponent<item5>().Btn.interactable = true;
                        }
                    }
                    NextBtn.interactable = false;
                    for (int k = 0; k < AD.SelectThree.Count; k++) {
                        if (AD.SelectThree[k].ListName == AppData.Fields.InformationTechnology && AD.SelectThree[k].Listindex == item.GetComponent<item5>().index) {
                            AD.SelectThree.RemoveAt(k);
                        }

                    }
                    item.GetComponent<item5>().isSelected = false;
                } else {
                    bool checkMe = false;
                    if (ParentGameObject != null) {
                        checkMe = true;
                        foreach (GameObject button in ButtonsList) {
                            if (button.GetComponent<item5>().Btn != item.GetComponent<item5>().Btn) {
                                button.GetComponent<item5>().Btn.interactable = false;
                            }
                        }
                    }
                    if ((AD.SelectThree.Count < AppData.selectionLimit) || checkMe) {
                        if (checkMe) {
                            NextBtn.interactable = true;
                            if (AD.SelectThree.Count == 1) {
                                return;
                            }
                        }
                        ColorBlock c = item.GetComponent<item5>().Btn.colors;
                        c.normalColor = new Color32(81, 169, 171, 255);
                        c.highlightedColor = new Color32(81, 169, 171, 255);
                        //c.selectedColor = new Color32(255, 100, 100, 255);
                        item.GetComponent<item5>().Btn.colors = c;
                        state = NextScreen;
                        AppData.ThreeSelection selection = new AppData.ThreeSelection();
                        selection.ListName = AppData.Fields.InformationTechnology;
                        selection.Listindex = item.GetComponent<item5>().index;
                        AD.SelectThree.Add(selection);
                        item.GetComponent<item5>().isSelected = true;
                        if (!checkMe) {
                            if (AD.SelectThree.Count == AppData.selectionLimit) {
                                NextBtn.interactable = true;
                                for (int m = 0; m < ButtonsList.Count; m++) {
                                    for (int n = 0; n < AD.SelectThree.Count; n++) {
                                        if (ButtonsList[m].GetComponent<item5>().index != AD.SelectThree[n].Listindex) {
                                            ButtonsList[m].GetComponent<item5>().Btn.interactable = false;
                                        }
                                    }
                                }
                                for (int m = 0; m < ButtonsList.Count; m++) {
                                    for (int n = 0; n < AD.SelectThree.Count; n++) {
                                        if (ButtonsList[m].GetComponent<item5>().index == AD.SelectThree[n].Listindex) {
                                            Debug.Log(ButtonsList[m].GetComponent<item5>().index + " == " + AD.SelectThree[n].Listindex);
                                            ButtonsList[m].GetComponent<item5>().Btn.interactable = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            ButtonsList.Add(item);
        }


    }

    public void onclicknextbtn() {
        this.gameObject.SetActive(false);
        state.SetActive(true);
    }
}
