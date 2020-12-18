using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VAStats : MonoBehaviour
{



    public AppData player;
    public DataBase DB;
    public int ReqCount;

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
        for (int i = 0; i < player.CurrentPlayer.Values.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = player.CurrentPlayer.Values[i];
            //item.GetComponent<Item1>().cost.text = player.CurrentPlayer.PerformanceCharacter[i].cost.ToString();

        }

    }

    public void DropDownBtn() {
        MIOptions.SetActive(!MIOptions.activeSelf);
    }

}
