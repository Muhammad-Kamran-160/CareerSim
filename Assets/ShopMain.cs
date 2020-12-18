using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMain : MonoBehaviour {

    public AppData AD;

    public GameObject CategoryScreen;
    public GameObject GameWorldScreen;

    private void OnEnable() {
        AD.Car = AD.Phone = AD.House = AD.Travel = false;
    }

    public void onClickCar() {
        AD.Car = true;
        AD.Phone = AD.House = AD.Travel = false;
        CategoryScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void onClickPhone() {
        AD.Phone = true;
        AD.Car = AD.House = AD.Travel = false;
        CategoryScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void onClickHouse() {
        AD.House = true;
        AD.Car = AD.Travel = AD.Phone = false;
        CategoryScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void onClickTravel() {
        AD.Travel = true;
        AD.House = AD.Car = AD.Phone = false;
        CategoryScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void onClickGameworld() {
        GameWorldScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
