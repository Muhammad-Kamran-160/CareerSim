using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAStats : MonoBehaviour
{



    public AppData player;
    public DataBase DB;
    public int ReqCount;

    public TypesOfCharacter Parent;
    public GameObject ItemPrefab;
    public GameObject MIOptions;
    public Transform Content;
    public GameObject os5;
    public GameObject os6;
    public GameObject os7;
    public GameObject os2;

    public bool ifDroppedDown;

    // Start is called before the first frame update
    void Start() {
        LoadDropDown();
    }

    // Update is called once per frame
    void Update() {

    }

    private void LoadDropDown() {
        for (int i = 0; i < player.CurrentPlayer.CareerAnchor.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = player.CurrentPlayer.CareerAnchor[i];
            //item.GetComponent<Item1>().cost.text = player.CurrentPlayer.PerformanceCharacter[i].cost.ToString();

        }

    }

    public void DropDownBtn() {
        MIOptions.SetActive(!MIOptions.activeSelf);
        //if (!ifDroppedDown) {
        //    Debug.Log("1234567890");

           
        //    os2.GetComponent<VAStats>().transform.localPosition = new Vector3(18, -747, 0);
            
            
        //    os5.SetActive(false);
        //    os6.SetActive(false);
        //    os7.SetActive(false);
        //    ifDroppedDown = true;
        //} else if (ifDroppedDown) {

           
        //    os2.GetComponent<VAStats>().transform.localPosition = new Vector3(18, -238, 0);
            
            
        //    os5.SetActive(true);
        //    os6.SetActive(true);
        //    os7.SetActive(true);
        //    ifDroppedDown = false;
        //}
    }

}
