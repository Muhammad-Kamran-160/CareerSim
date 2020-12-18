using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPossessionDropdown : MonoBehaviour
{
    public AppData LocalDB;
    public DataBase DB;
    public int ReqCount;

    //public TypesOfCharacter Parent;
    public GameObject ItemPrefab;
    public GameObject PossessionsOptions;
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
        for (int i = 0; i < LocalDB.CurrentPlayer.Possession.Count; i++) {
            if (LocalDB.CurrentPlayer.Possession[i] != "" && LocalDB.CurrentPlayer.Possession[i] != "Plus Luxury Mobile Phone" && LocalDB.CurrentPlayer.Possession[i] != "Plus Economical Car") {
                GameObject item = Instantiate(ItemPrefab, Content);
                item.GetComponent<Item2>().Title.text = LocalDB.CurrentPlayer.Possession[i];
            }
        }
        for (int i = 0; i < LocalDB.CurrentPlayer.ShopPossessions.Count; i++) {
            GameObject item = Instantiate(ItemPrefab, Content);
            item.GetComponent<Item2>().Title.text = LocalDB.CurrentPlayer.ShopPossessions[i].Category + " " + LocalDB.CurrentPlayer.ShopPossessions[i].Name;
        }
    }

    public void DropDownBtn() {
        PossessionsOptions.SetActive(!PossessionsOptions.activeSelf);
    }

}
