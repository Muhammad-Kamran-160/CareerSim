using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VA : MonoBehaviour {

    public Text TypesInstruction;
    public GameObject VATick;
    public GameObject CATab;
    public Text AP;


    public DataBase DB;
    public int ReqCount;
    public Button btn1;

    public TypesOfCharacter Parent;
    public GameObject ItemPrefab;
    public GameObject VAOptions;
    public Transform Content;
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;
    //public Button NextBtn;
    public List<GameObject> Buttons = new List<GameObject>();

    private void OnEnable() {
        VATick.SetActive(false);
        TypesInstruction.text = "Select 5 values for your character.\nYour Satisfaction Level is affected by how the job and company align with your values.";
        //NextBtn.GetComponent<Button>().interactable = false;
        //LoadDropDown();
        DropDownBtn();
        AP.text = "";
        ColorBlock colors = btn1.colors;
        colors.normalColor = new Color32(81, 169, 171, 255);
        btn1.colors = colors;
    }


    // Start is called before the first frame update
    void Start() {
        LoadDropDown();
    }

    // Update is called once per frame
    void Update() {
        
    }
    private void LoadDropDown() {
        Parent.Values.Clear();
        //Buttons.Clear();
        ReqCount = 0;

        for (int i = 0; i < Content.childCount; i++) {
            Destroy(Content.GetChild(i).gameObject);
        }
        for (int i = 0; i < DB.character.Values.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = DB.character.Values[i];
            item.GetComponent<Item2>().Btn.onClick.AddListener(() => {

                //bool found = false;
                if (item.GetComponent<Item2>().isSelected) {
                    ColorBlock c = item.GetComponent<Item2>().Btn.colors;
                    c.normalColor = Color.white;
                    //colors.highlightedColor = new Color32(255, 100, 100, 255);
                    item.GetComponent<Item2>().Btn.colors = c;

                    for (int j = 0; j < Parent.Values.Count; j++) {
                        if (Parent.Values[j] == item.GetComponent<Item2>().Title.text) {
                            Parent.Values.RemoveAt(j);
                        }
                    }

                    foreach (GameObject button in Buttons) {
                        Debug.Log("disabling buttons:");
                        button.GetComponent<Item2>().Btn.GetComponent<Button>().interactable = true;
                    }
                    //b1 = null;
                    ReqCount--;
                    VATick.SetActive(false);
                    Parent.VASelected = false;
                    item.GetComponent<Item2>().isSelected = false;
                } else {
                    ColorBlock colors = item.GetComponent<Item2>().Btn.colors;
                    colors.normalColor = new Color32(81, 169, 171, 255);
                    //colors.highlightedColor = new Color32(255, 100, 100, 255);
                    item.GetComponent<Item2>().Btn.colors = colors;
                    ReqCount++;
                    Parent.Values.Add(item.GetComponent<Item2>().Title.text);

                    if (ReqCount == 5) {
                        
                        foreach (GameObject button in Buttons) {
                            if (
                                    Parent.Values[0] != button.GetComponent<Item2>().Title.text &&
                                    Parent.Values[1] != button.GetComponent<Item2>().Title.text &&
                                    Parent.Values[2] != button.GetComponent<Item2>().Title.text &&
                                    Parent.Values[3] != button.GetComponent<Item2>().Title.text &&
                                    Parent.Values[4] != button.GetComponent<Item2>().Title.text
                            ) {
                                //Debug.Log("disabling buttons:");
                                button.GetComponent<Item2>().Btn.GetComponent<Button>().interactable = false;
                            }
                        }
                    }

                    item.GetComponent<Item2>().isSelected = true;
                }

                //foreach (Player player in DB.Players) {
                //    if (player.Name == Parent.AD.CurrentPlayer.Name && player.Email == Parent.AD.CurrentPlayer.Email) {
                //        found = true;
                //        break;
                //    }
                //}
                //if (found) {
                //    if (ReqCount < Character.VACount) {
                            
                //        ReqCount++;
                //    }
                //}
                
                //if (ReqCount == 1) {
                //    b1 = item.GetComponent<Item2>().Btn;
                //}
                //if (ReqCount == 2) {
                //    b2 = item.GetComponent<Item2>().Btn;
                    
                //}
                //if (ReqCount == 3) {
                //    b3 = item.GetComponent<Item2>().Btn;
                //}
                //if (ReqCount == 4) {
                //    b4 = item.GetComponent<Item2>().Btn;
                //}
                //if (ReqCount == 5) {
                //    b5 = item.GetComponent<Item2>().Btn;
                //    foreach (Button button in Buttons) {
                //        if (button != b1 && button != b2 && button != b3 && button != b4 && button != b5) {
                //            Debug.Log("disabling buttons:");
                //            button.interactable = false;
                //        }
                //    }
                //}
            });
            Buttons.Add(item);
            
        }
        GameObject saveBtn = Instantiate(Parent.SaveBtnPrefab, Content);
        saveBtn.GetComponent<Button>().onClick.AddListener(() => {
            Save();
            ColorBlock colors = btn1.colors;
            //colors.normalColor = new Color32(255, 255, 255, 255);
            //btn1.colors = colors;
            ////VAOptions.SetActive(false); // disabling this disturbs start btn display fun
            //VATick.SetActive(true);
        });
    }
    public void DropDownBtn() {
        VAOptions.SetActive(!VAOptions.activeSelf);
    }
    public void Save() {
        if (ReqCount == Character.VACount)
        {
            VATick.SetActive(true);
            //Debug.Log("VA");
            Parent.VASelected = true;

        }
    }
    public void onClickBackBtn() {

        ColorBlock colors = btn1.colors;
        colors.normalColor = new Color32(255, 255, 255, 255);
        btn1.colors = colors;

        //Buttons.Clear();
        Parent.VASelected = false;
        //ReqCount = 0;
        this.gameObject.SetActive(false);
        CATab.SetActive(true);
    }
}
