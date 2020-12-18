using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopEnd : MonoBehaviour {
    public AppData AD;
    public Text BodyText;
    public Button ConfirmBtn;
    public GameObject CategoryScreen;
    public GameObject GameWorldScreen;

    public void Update() {
        if (AD.CurrentPlayer.Bank < AD.ShopMoney) {
            ConfirmBtn.interactable = false;
        } else {
            ConfirmBtn.interactable = true;
        }
    }

    private void OnEnable() {
        // Budget
        if (AD.Budget) {
            if (AD.Car) {
                BodyText.text = "You\'re purchasing Budget Car";
                AD.ShopAP = 2;
                AD.ShopMoney = 10000;
            } else if (AD.Phone) {
                BodyText.text = "You\'re purchasing Budget Phone";
                AD.ShopAP = 2;
                AD.ShopMoney = 1000;
            } else if (AD.Travel) {
                BodyText.text = "You\'re purchasing Budget Travel";
                AD.ShopAP = 2;
                AD.ShopMoney = 5000;
            } else if (AD.House) {
                BodyText.text = "You\'re purchasing Budget House";
                AD.ShopAP = 2;
                AD.ShopMoney = 80000;
            }
        } else if (AD.Economic) {
            // Economical
            if (AD.Car) {
                BodyText.text = "You\'re purchasing Economical Car";
                AD.ShopAP = 3;
                AD.ShopMoney = 30000;
            } else if (AD.Phone) {
                BodyText.text = "You\'re purchasing Economical Mobile Phone";
                AD.ShopAP = 3;
                AD.ShopMoney = 3000;
            } else if (AD.House) {
                BodyText.text = "You\'re purchasing Economical House";
                AD.ShopAP = 3;
                AD.ShopMoney = 125000;
            }
        } else if (AD.Luxury) {
            // luxury
            if (AD.Car) {
                BodyText.text = "You\'re purchasing Luxury Car";
                AD.ShopAP = 5;
                AD.ShopMoney = 80000;
            } else if (AD.Phone) {
                BodyText.text = "You\'re purchasing Luxury Phone";
                AD.ShopAP = 5;
                AD.ShopMoney = 5000;
            } else if (AD.Travel) {
                BodyText.text = "You\'re purchasing Luxury Travel";
                AD.ShopAP = 4;
                AD.ShopMoney = 15000;
            } else if (AD.House) {
                BodyText.text = "You\'re purchasing Luxury House";
                AD.ShopAP = 5;
                AD.ShopMoney = 250000;
            }
        }
        string str = Mathf.Abs(AD.ShopMoney).ToString();
        string str2 = "";
        int count = 0;
        for (int i = 0; i < str.Length; i++) {
            str2 += str[str.Length - 1 - i];
            count++;
            if (count % 3 == 0 && i != str.Length - 1) {
                str2 += ",";
            }
        }
        string finalString = "";
        for (int i = 0; i < str2.Length; i++) {
            finalString += str2[str2.Length - 1 - i];
        }
        ConfirmBtn.GetComponentInChildren<Text>().text = "Confirm\n-" + AD.ShopAP + " AP\n-$" + finalString;
    }
    public void onClickConfirmBtn() {
        // update player profile data
        if (AD.Budget) {
            if (AD.Car) {
                AD.CurrentPlayer.ShopPossessions.Add(new Possession("Car", "Budget"));
            }else if (AD.House) {
                AD.CurrentPlayer.ShopPossessions.Add(new Possession("House", "Budget"));
            } else if (AD.Phone) {
                AD.CurrentPlayer.ShopPossessions.Add(new Possession("Mobile Phone", "Budget"));
            } else if (AD.Travel) {
                AD.CurrentPlayer.ShopPossessions.Add(new Possession("Travel", "Budget"));
            }
        } else if (AD.Economic) {
            if (AD.Car) {
                AD.CurrentPlayer.ShopPossessions.Add(new Possession("Car", "Economy"));
            } else if (AD.House) {
                AD.CurrentPlayer.ShopPossessions.Add(new Possession("House", "Economy"));
            } else if (AD.Phone) {
                AD.CurrentPlayer.ShopPossessions.Add(new Possession("Mobile Phone", "Economy"));
            }
        } else if (AD.Luxury) {
            if (AD.Car) {
                AD.CurrentPlayer.ShopPossessions.Add(new Possession("Car", "Luxury"));
            } else if (AD.House) {
                AD.CurrentPlayer.ShopPossessions.Add(new Possession("House", "Luxury"));
            } else if (AD.Phone) {
                AD.CurrentPlayer.ShopPossessions.Add(new Possession("Mobile Phone", "Luxury"));
            } else if (AD.Travel) {
                AD.CurrentPlayer.ShopPossessions.Add(new Possession("Travel", "Luxury"));
            }
        }
        AD.CurrentPlayer.Bank -= AD.ShopMoney;
        AD.CurrentPlayer.RemainingActionPoints -= AD.ShopAP;
        AD.ShopMoney = 0;
        AD.ShopAP = 0;
        AD.Car = AD.House = AD.Phone = AD.Travel = AD.Budget = AD.Economic = AD.Luxury = false;
        GameWorldScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void onClickBackBtn() {
        CategoryScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void onClickGameWorldBtn() {
        GameWorldScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
