using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MI : MonoBehaviour {

    public Text TypesInstruction;
    public AppData AD;
    public GameObject MITick;
    public GameObject PCTab;
    public GameObject MItab;
    public Button btn1;
    public Button NextBtn;
    public Text text;

    public AppData player;
    public DataBase DB;
    public int ReqCount=8;

    public TypesOfCharacter Parent;
    public GameObject ItemPrefab;
    public GameObject MIOptions;
    public Transform Content;


    private void OnEnable() {
        MITick.SetActive(false);
        TypesInstruction.text = "Assign 50 points across the following 8 smarts.\nYour ‘smarts’ affect how quickly you gain skills.";
        NextBtn.GetComponent<Button>().interactable = false;
        LoadDropDown();
        DropDownBtn();
        ColorBlock colors = btn1.colors;
        colors.normalColor = new Color32(81, 169, 171, 255);
        btn1.colors = colors;
    }

    // Start is called before the first frame update
    void Start() {
        
        //MIOptions.SetActive(false);
        //MITick.SetActive(true);
        //PCTab.SetActive(true);
        //MItab.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        text.text = "You have assigned " + (AD.CurrentPlayer.ActionPoints) + "/50 points.";

        if(player.CurrentPlayer.RemainingActionPoints > 0) {
            NextBtn.interactable = false;
            MITick.SetActive(false);
        } else {

        }

    }

    private void LoadDropDown() {
        
        ReqCount = 0;
        for (int i = 0; i < Content.childCount; i++) {
            Destroy(Content.GetChild(i).gameObject);
        }
        player.CurrentPlayer.MultipleIntelligence = DB.character.MultipleIntelligence;
        for (int i = 0; i < DB.character.MultipleIntelligence.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item1>().Title.text = DB.character.MultipleIntelligence[i].Title;
            item.GetComponent<Item1>().cost.text = DB.character.MultipleIntelligence[i].cost.ToString();
            item.GetComponent<Item1>().index = i;
            item.GetComponent<Item1>().AD = player;

            

            //item.GetComponent<Item1>().Btn.onClick.AddListener(()=> {
                bool found = false;
            ////item.GetComponent<Item1>().Btn.
            //ColorBlock colors = item.GetComponent<Item1>().Btn.colors;
            //colors.normalColor = new Color32(81, 169, 171, 255);
            ////colors.highlightedColor = new Color32(255, 100, 100, 255);
            //item.GetComponent<Item1>().Btn.colors = colors;
            
            //AD.CurrentPlayer.ActionPoints -= (int)DB.character.MultipleIntelligence[i].cost;

            Debug.Log(DB.character.MultipleIntelligence[i].cost);
                foreach (Player player in DB.Players) {
                    if (player.Name == Parent.AD.CurrentPlayer.Name && player.Email == Parent.AD.CurrentPlayer.Email) {
                        found = true;
                        break;
                    }
                }
                if (found) {
                    //if (Parent.AD.CurrentPlayer.ActionPoints > int.Parse(item.GetComponent<Item1>().cost.text)) {
                    //    //Parent.MultipleIntelligence.Add(new Point(item.GetComponent<Item1>().Title.text, int.Parse(item.GetComponent<Item1>().cost.text),""));
                    //    Parent.AD.CurrentPlayer.ActionPoints -= int.Parse(item.GetComponent<Item1>().cost.text);
                    //    ReqCount++;
                    //    Debug.Log(player.CurrentPlayer.ActionPoints);
                    //}
                }
            //});
        }
        GameObject saveBtn = Instantiate(Parent.SaveBtnPrefab, Content);
        saveBtn.GetComponent<Button>().onClick.AddListener(()=> {
            Save();
            
        });
    }

    public void DropDownBtn() {
        MIOptions.SetActive(!MIOptions.activeSelf);
    }
    public void Save() {
        
        if (player.CurrentPlayer.RemainingActionPoints == 0) {
            NextBtn.GetComponent<Button>().interactable = true;
            //ColorBlock colors = btn1.colors;
            //colors.normalColor = new Color32(255, 255, 255, 255);
            //btn1.colors = colors;

            MITick.SetActive(true);
            NextBtn.interactable = true;


            //if (ReqCount > 0)
            {
                Parent.MISelected = true;
            }
            Debug.Log("Dil lagi esi ");
        } else {
            NextBtn.GetComponent<Button>().interactable = false;
        }
    }

    public void onClickNextBtn() {
        if (Parent.MISelected == true) {

            ColorBlock colors = btn1.colors;
            colors.normalColor = new Color32(255, 255, 255, 255);
            btn1.colors = colors;

            MIOptions.SetActive(false);
            MItab.SetActive(false);
            
            PCTab.SetActive(true);
        }
    }
}
