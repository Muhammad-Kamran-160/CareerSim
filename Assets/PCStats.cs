using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCStats : MonoBehaviour
{



    public AppData player;
    public DataBase DB;
    public int ReqCount;

    public GameObject os;
    public GameObject os1;
    public GameObject os2;
    public GameObject os3;
    public GameObject os4;
    public GameObject os5;
    public bool ifDroppedDown;

    public TypesOfCharacter Parent;
    public GameObject ItemPrefab;
    public GameObject MIOptions;
    public Transform Content;

    // Start is called before the first frame update
    void Start() {
        LoadDropDown();
    }

    // Update is called once per frame
    void Update() {

    }

    private void LoadDropDown() {
        for (int i = 0; i < player.CurrentPlayer.PerformanceCharacter.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = player.CurrentPlayer.PerformanceCharacter[i].Title;
            //item.GetComponent<Item1>().cost.text = player.CurrentPlayer.PerformanceCharacter[i].cost.ToString();
            
        }

    }

    public void DropDownBtn() {
        MIOptions.SetActive(!MIOptions.activeSelf);
        //if (!ifDroppedDown) {
        //    Debug.Log("1234567890");
            
        //    os1.GetComponent<CAStats>().transform.localPosition = new Vector3(18, -560, 0);
        //    os2.GetComponent<VAStats>().transform.localPosition = new Vector3(18, -747, 0);
        //    os3.SetActive(false);
        //    os4.SetActive(false);
        //    os5.SetActive(false);
        //    ifDroppedDown = true;
        //} else if (ifDroppedDown) {
            
        //    os1.GetComponent<CAStats>().transform.localPosition = new Vector3(18, -49, 0);
        //    os2.GetComponent<VAStats>().transform.localPosition = new Vector3(18, -238, 0);
        //    os3.SetActive(true);
        //    os4.SetActive(true);
        //    os5.SetActive(true);
        //    ifDroppedDown = false;
        //}
    }

}
