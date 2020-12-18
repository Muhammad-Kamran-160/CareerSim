using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MIStats : MonoBehaviour
{

    

    public AppData player;
    public DataBase DB;
    public int ReqCount;

    public TypesOfCharacter Parent;
    public GameObject ItemPrefab;
    public GameObject MIOptions;
    public GameObject os;
    public GameObject os1;
    public GameObject os2;
    public GameObject os3;
    public GameObject os4;
    public bool ifDroppedDown;
    public GameObject os5;
    public GameObject os6;
    public GameObject os7;
    public Transform Content;
    public Transform Test;
   


    // Start is called before the first frame update
    void Start() {
        LoadDropDown();
    }

    // Update is called once per frame
    void Update() {

    }

    private void LoadDropDown() {
        
        for (int i = 0; i < player.CurrentPlayer.MultipleIntelligence.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item1>().Title.text = player.CurrentPlayer.MultipleIntelligence[i].Title;
            item.GetComponent<Item1>().cost.text = player.CurrentPlayer.MultipleIntelligence[i].cost.ToString();
            //item.GetComponent<Item1>().Btn.onClick.AddListener(() => {
            //    bool found = false;
            //    //item.GetComponent<Item1>().Btn.
            //    ColorBlock colors = item.GetComponent<Item1>().Btn.colors;
            //    colors.normalColor = new Color32(81, 169, 171, 255);
            //    //colors.highlightedColor = new Color32(255, 100, 100, 255);
            //    item.GetComponent<Item1>().Btn.colors = colors;

            //    foreach (Player player in DB.Players) {
            //        if (player.Name == Parent.AD.CurrentPlayer.Name && player.Email == Parent.AD.CurrentPlayer.Email) {
            //            found = true;
            //            break;
            //        }
            //    }
            //    if (found) {
            //        if (Parent.AD.CurrentPlayer.ActionPoints > int.Parse(item.GetComponent<Item1>().cost.text)) {
            //            Parent.MultipleIntelligence.Add(new Point(item.GetComponent<Item1>().Title.text, int.Parse(item.GetComponent<Item1>().cost.text)));
            //            Parent.AD.CurrentPlayer.ActionPoints -= int.Parse(item.GetComponent<Item1>().cost.text);
            //            ReqCount++;
            //            Debug.Log(player.CurrentPlayer.ActionPoints);
            //        }
            //    }
            //});
        }
        
    }

    public void DropDownBtn() {
        Debug.Log("bcbsadjbcdbc");
        
        MIOptions.SetActive(!MIOptions.activeSelf);
        Debug.Log("1234567890");
        //if (!ifDroppedDown) {
        //    Debug.Log("1234567890");
        //    os.GetComponent<PCStats>().transform.localPosition = new Vector3(18, -373, 0);
        //    os1.GetComponent<CAStats>().transform.localPosition = new Vector3(18, -560, 0);
        //    os2.GetComponent<VAStats>().transform.localPosition = new Vector3(18, -747, 0);
        //    os3.SetActive(false);
        //    os4.SetActive(false);
        //    ifDroppedDown = true;
        //}
        //else if(ifDroppedDown) {
        //    os.GetComponent<PCStats>().transform.localPosition = new Vector3(18, 139, 0);
        //    os1.GetComponent<CAStats>().transform.localPosition = new Vector3(18, -49, 0);
        //    os2.GetComponent<VAStats>().transform.localPosition = new Vector3(18, -238, 0);
        //    os3.SetActive(true);
        //    os4.SetActive(true) ;
        //    ifDroppedDown = false;
        //}
    }
    
}
