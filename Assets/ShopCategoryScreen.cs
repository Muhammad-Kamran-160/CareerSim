using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCategoryScreen : MonoBehaviour {
    
    public AppData AD;
    public Text ItemText;
    public Button NextBtn;
    public GameObject Popup;
    public GameObject ShopEndScreen;
    public Button EconomicBtn;
    public GameObject ShopMainScreen;
    public GameObject GameWorldScreen;
    public Text PopUpText;

    public Sprite Selected, Unselected;
    public Button Btn1, Btn2, Btn3;

    private void OnEnable() {
        Btn1.image.sprite = Btn2.image.sprite = Btn3.image.sprite = Unselected;
        AD.Economic = AD.Budget = AD.Luxury = false;
        EconomicBtn.gameObject.SetActive(true);
        NextBtn.interactable = false;
        if (AD.Car) {
            ItemText.text = "What type of car would you like?";
        } else if (AD.Phone) {
            ItemText.text = "What type of mobile phone would you like?";
        } else if (AD.House) {
            ItemText.text = "What type of house would you like?";
        } else if (AD.Travel) {
            EconomicBtn.gameObject.SetActive(false);
            ItemText.text = "What type of travel would you like?";
        }
    }
    public void onClickBudget() {
        Btn1.image.sprite = Selected;
        Btn2.image.sprite = Btn3.image.sprite = Unselected;
        if (AD.Car) {
            PopUpText.text = "You will need 2 AP and $10,000 to purchase this";
            AD.ShopAP = 2;
            AD.ShopMoney = 10000;
        } else if (AD.Phone) {
            PopUpText.text = "You will need 2 AP and $1,000 to purchase this";
            AD.ShopAP = 2;
            AD.ShopMoney = 1000;
        } else if (AD.Travel) {
            PopUpText.text = "You will need 2 AP and $5,000 to purchase this";
            AD.ShopAP = 2;
            AD.ShopMoney = 5000;
        } else if (AD.House) {
            PopUpText.text = "You will need 2 AP and $80,000 to purchase this";
        }
        AD.Budget = true;
        AD.Economic = false;
        AD.Luxury = false;
        Popup.SetActive(true);
    }
    public void onClickEconomical() {
        Btn2.image.sprite = Selected;
        Btn1.image.sprite = Btn3.image.sprite = Unselected;
        if (AD.Car) {
            PopUpText.text = "You will need 3 AP and $30,000 to purchase this";
            AD.ShopAP = 3;
            AD.ShopMoney = 30000;
        } else if (AD.Phone) {
            PopUpText.text = "You will need 3 AP and $3,000 to purchase this";
            AD.ShopAP = 3;
            AD.ShopMoney = 3000;
        } else if (AD.House) {
            PopUpText.text = "You will need 3 AP and $125,000 to purchase this";
            AD.ShopAP = 3;
            AD.ShopMoney = 125000;
        }
        AD.Budget = false;
        AD.Luxury = false;
        AD.Economic = true;
        Popup.SetActive(true);
    }
    public void onClickLuxury() {
        Btn3.image.sprite = Selected;
        Btn2.image.sprite = Btn1.image.sprite = Unselected;
        if (AD.Car) {
            PopUpText.text = "You will need 5 AP and $80,000 to purchase this";
            AD.ShopAP = 5;
            AD.ShopMoney = 80000;
        } else if (AD.Phone) {
            PopUpText.text = "You will need 5 AP and $5,000 to purchase this";
            AD.ShopAP = 5;
            AD.ShopMoney = 5000;
        } else if (AD.Travel) {
            PopUpText.text = "You will need 4 AP and $15,000 to purchase this";
            AD.ShopAP = 4;
            AD.ShopMoney = 15000;
        } else if (AD.House) {
            PopUpText.text = "You will need 5 AP and $250,000 to purchase this";
            AD.ShopAP = 5;
            AD.ShopMoney = 250000;
        }
        AD.Budget = false;
        AD.Economic = false;
        AD.Luxury = true;
        Popup.SetActive(true);
    }
    public void onClickNext() {
        ShopEndScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void onClickPopupCrossBtn() {
        Popup.SetActive(false);
        NextBtn.interactable = true;
    }
    public void onClickBackBtn() {
        ShopMainScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void onClickGameworld() {
        GameWorldScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
