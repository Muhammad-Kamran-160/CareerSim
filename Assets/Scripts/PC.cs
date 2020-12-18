using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC : MonoBehaviour {
    public Text TypesInstruction;
    public GameObject PCTick;
    public GameObject CATab;
    public GameObject PCtab;
    public GameObject MItab;
    public Button btn1;
    public Button NextBtn;
    public Text AP;
    public DataBase DB;
    public int ReqCount = 0;

    public TypesOfCharacter Parent;
    public GameObject ItemPrefab;
    public GameObject PCOptions;
    public Transform Content;
    public List<Button> Buttons = new List<Button>();
    public Button b1;
    //public Button b2;

    public int num = 0;
    public int last = -1;

    private void OnEnable() {
        PCTick.SetActive(false);
       //PCOptions.SetActive(true);
        TypesInstruction.text = "Choose 1 Performance Character.\nYou will get the relevant bonus throughout the game.";
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
        //Parent.PerformanceCharacter.Clear();
        //Buttons.Clear();
        ReqCount = 0;
        num = 0;
        for (int i = 0; i < Content.childCount; i++) {
            Destroy(Content.GetChild(i).gameObject);
        }
        //Debug.Log("jcoskbcdvuiosdbvsdovbsvobsdvovbovbodvbsodbvosdvbosdvb");
        for (int i = 0; i < DB.character.PerformanceCharacter.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = DB.character.PerformanceCharacter[i].Title;
            item.GetComponent<Item2>().Desc.text = DB.character.PerformanceCharacter[i].des;
            //Debug.Log("asdfcadfda: "+DB.character.PerformanceCharacter[i].des);
            item.GetComponent<Item2>().Btn.onClick.AddListener(() => {
                bool found = false;

               
                if (ReqCount >= 2) {
                    //foreach (Button button in Buttons) {
                    //    if (button != b1 && button != b2) {
                    //        Debug.Log("disabling buttons:");
                    //        button.interactable = false;
                    //    }
                    //}
                } else {

                    if (item.GetComponent<Item2>().isSelected) {
                        ColorBlock c = item.GetComponent<Item2>().Btn.colors;
                        c.normalColor = Color.white;
                        //colors.highlightedColor = new Color32(255, 100, 100, 255);
                        item.GetComponent<Item2>().Btn.colors = c;
                        
                        Point PP = new Point(item.GetComponent<Item2>().Title.text, num, item.GetComponent<Item2>().Title.text);

                        for (int j = 0; j < Parent.PerformanceCharacter.Count; j++) {
                            if(Parent.PerformanceCharacter[j].Title == item.GetComponent<Item2>().Title.text) {
                                Parent.PerformanceCharacter.RemoveAt(j);
                            }
                        }
                        
                        Parent.PerformanceCharacter.Remove(PP);

                        Debug.Log("Debug====================> " + Parent.PerformanceCharacter.Contains(PP));

                        foreach (Button button in Buttons) {
                            Debug.Log("disabling buttons:");
                            button.interactable = true;
                        }
                        b1 = null;
                        ReqCount--;
                        Parent.PCSelected = false;
                        NextBtn.interactable = false;
                        PCTick.SetActive(false);
                        item.GetComponent<Item2>().isSelected = false;
                    } else {
                        ColorBlock colors = item.GetComponent<Item2>().Btn.colors;
                        colors.normalColor = new Color32(81, 169, 171, 255);
                        //colors.highlightedColor = new Color32(255, 100, 100, 255);
                        item.GetComponent<Item2>().Btn.colors = colors;

                        Point P = new Point(item.GetComponent<Item2>().Title.text, num, item.GetComponent<Item2>().Title.text);
                        Parent.PerformanceCharacter.Add(P);
                        last = num;
                        b1 = item.GetComponent<Item2>().Btn;

                        ReqCount++;
                        if (ReqCount == 1) {
                            foreach (Button button in Buttons) {
                                if (button != b1 /*&& button != b2*/) {
                                    //Debug.Log("disabling buttons:");
                                    button.interactable = false;
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
                    //    if (ReqCount < Character.PCCount) {
                    //        ReqCount++;

                    //    }
                    //}
                    //if (ReqCount == 1) {
                    //    b1=item.GetComponent<Item2>().Btn;
                    //    foreach (Button button in Buttons) {
                    //        if (button != b1 /*&& button != b2*/) {
                    //            Debug.Log("disabling buttons:");
                    //            button.interactable = false;
                    //        }
                    //    }
                    ////if (ReqCount == 2) {
                    ////    b2 = item.GetComponent<Item2>().Btn;
                        
                    ////    }
                    //}

                }
                
                num++;
            });

            Buttons.Add(item.GetComponent<Item2>().Btn);

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
        PCOptions.SetActive(!PCOptions.activeSelf);
    }
    public void Save() {
        
        if (ReqCount == Character.PCCount) {
            //Debug.Log("PC");
            Parent.PCSelected = true;
            PCTick.SetActive(true);
            NextBtn.GetComponent<Button>().interactable = true;
        }
    }
    public void onClickBackBtn() {

        ColorBlock colors = btn1.colors;
        colors.normalColor = new Color32(255, 255, 255, 255);
        btn1.colors = colors;

        //for (int i = 0; i < Content.childCount; i++) {
        //    Destroy(Content.GetChild(i).gameObject);
        //}
        //NextBtn.GetComponent<Button>().interactable = false;
        Parent.PCSelected = false;
        //Buttons.Clear();
        this.gameObject.SetActive(false);
        PCOptions.SetActive(false);
        MItab.SetActive(true);
    }
    public void onClickNextBtn() {
        if (Parent.PCSelected == true) {

            ColorBlock colors = btn1.colors;
            colors.normalColor = new Color32(255, 255, 255, 255);
            btn1.colors = colors;

            PCOptions.SetActive(false);
            //PCOptions.SetActive(false);
            
            PCtab.SetActive(false);
            CATab.SetActive(true);
        }
    }
}
