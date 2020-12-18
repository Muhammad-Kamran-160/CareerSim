using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CA : MonoBehaviour {

    public Text TypesInstruction;
    public GameObject CATick;
    public GameObject PCOptions;
    public GameObject VAOptions;
    public GameObject VATab;
    public GameObject CAtab;
    public GameObject PCtab;
    public Button btn1;
    public Text AP;

    public DataBase DB;
    public int ReqCount;

    public TypesOfCharacter Parent;
    public GameObject ItemPrefab;
    public GameObject CAOptions;
    public Transform Content;
    public Button b1;
    public Button b2;
    public Button NextBtn;
    public List<GameObject> Buttons = new List<GameObject>();

    private void OnEnable() {
        CATick.SetActive(false);
        TypesInstruction.text = "Select 2 Career Anchors for your character.\nYour Satisfaction Level is affected by the job and company\nalign with your Career Anchors.";
        NextBtn.GetComponent<Button>().interactable = false;
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
        Parent.CareerAnchor.Clear();
        //Buttons.Clear();
        ReqCount = 0;

        for (int i = 0; i < Content.childCount; i++) {
            Destroy(Content.GetChild(i).gameObject);
        }
        for (int i = 0; i < DB.character.CareerAnchor.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = DB.character.CareerAnchor[i];
            item.GetComponent<Item2>().Btn.onClick.AddListener(() => {
                //bool found = false;

                if (item.GetComponent<Item2>().isSelected) {
                    ColorBlock c = item.GetComponent<Item2>().Btn.colors;
                    c.normalColor = Color.white;
                    //colors.highlightedColor = new Color32(255, 100, 100, 255);
                    item.GetComponent<Item2>().Btn.colors = c;
                    //Point PP = new Point(item.GetComponent<Item2>().Title.text, 0, item.GetComponent<Item2>().Title.text);

                    //Parent.CareerAnchor.Add(item.GetComponent<Item2>().Title.text);

                    for (int j = 0; j < Parent.CareerAnchor.Count; j++) {
                        if (Parent.CareerAnchor[j] == item.GetComponent<Item2>().Title.text) {
                            Parent.CareerAnchor.RemoveAt(j);
                        }
                    }

                    foreach (GameObject button in Buttons) {
                        Debug.Log("disabling buttons:");
                        button.GetComponent<Item2>().Btn.GetComponent<Button>().interactable = true;
                    }
                    //b1 = null;
                    ReqCount--;
                    NextBtn.interactable = false;
                    CATick.SetActive(false);
                    Parent.CASelected = false;
                    item.GetComponent<Item2>().isSelected = false;

                } else {
                    ColorBlock colors = item.GetComponent<Item2>().Btn.colors;
                    colors.normalColor = new Color32(81, 169, 171, 255);
                    //colors.highlightedColor = new Color32(255, 100, 100, 255);
                    item.GetComponent<Item2>().Btn.colors = colors;
                    Parent.CareerAnchor.Add(item.GetComponent<Item2>().Title.text);
                    
                    ReqCount++;

                    if (ReqCount == 2) {
                        //b2 = item.GetComponent<Item2>().Btn;
                        foreach (GameObject button in Buttons) {
                            if(Parent.CareerAnchor[0] != button.GetComponent<Item2>().Title.text && Parent.CareerAnchor[1] != button.GetComponent<Item2>().Title.text) {
                                button.GetComponent<Item2>().Btn.GetComponent<Button>().interactable = false;
                            }
                        }
                    }

                    item.GetComponent<Item2>().isSelected = true;
                }

                

            //    foreach (Player player in DB.Players) {
            //        if (player.Name == Parent.AD.CurrentPlayer.Name && player.Email == Parent.AD.CurrentPlayer.Email) {
            //            found = true;
            //            break;
            //        }
            //    }
            //    if (found) {
            //        if (ReqCount < Character.CACount) {
                       
            //            ReqCount++;
            //        }
            //    }
            //ReqCount++;
            //    if (ReqCount == 1) {
            //        b1 = item.GetComponent<Item2>().Btn;
            //    }
            //    if (ReqCount == 2) {
            //        b2 = item.GetComponent<Item2>().Btn;
            //        foreach (Button button in Buttons) {
            //            if (button != b1 && button != b2) {
            //                Debug.Log("disabling buttons:");
            //                button.interactable = false;
            //            }
            //        }
            //    }
            });
            Buttons.Add(item);
        }
        GameObject saveBtn = Instantiate(Parent.SaveBtnPrefab, Content);
        saveBtn.GetComponent<Button>().onClick.AddListener(() => {
            Save();
            //ColorBlock colors = btn1.colors;
            //colors.normalColor = new Color32(255, 255, 255, 255);
            //btn1.colors = colors;
            
        });
    }
    public void DropDownBtn() {
        CAOptions.SetActive(!CAOptions.activeSelf);
    }
    public void Save() {
        
        if (ReqCount == Character.CACount) {
            CATick.SetActive(true);
            //Debug.Log("CA");
            Parent.CASelected = true;
            NextBtn.GetComponent<Button>().interactable = true;
        }
    }
    public void onClickBackBtn() {

        ColorBlock colors = btn1.colors;
        colors.normalColor = new Color32(255, 255, 255, 255);
        btn1.colors = colors;

        Parent.CASelected = false;
        //Buttons.Clear();
        //ReqCount = 0;
        this.gameObject.SetActive(false);
        PCtab.SetActive(true);
        CAOptions.SetActive(false);
        //PCOptions.SetActive(false);
    }
    public void onClickNextBtn() {
        if (Parent.PCSelected == true) {

            ColorBlock colors = btn1.colors;
            colors.normalColor = new Color32(255, 255, 255, 255);
            btn1.colors = colors;

            CAOptions.SetActive(false);
            VAOptions.SetActive(false);
            CATick.SetActive(true);
            CAtab.SetActive(false);
            VATab.SetActive(true);
        }
    }
}
