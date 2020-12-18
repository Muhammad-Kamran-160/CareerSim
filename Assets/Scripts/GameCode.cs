using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameCode : MonoBehaviour
{
    public InputField inputField;
    public GameObject nextScreen;
    public Text IncorrectTokenNotification;

    public string TokenUrl = "http://18.223.239.177/hello/get/gametoken/";

    private void OnEnable() {
        
    }

    private IEnumerator TokenCheck() {
        UnityWebRequest www = UnityWebRequest.Get(TokenUrl + inputField.text);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            string info = www.downloadHandler.text;
            //Debug.Log("Received: " + info);
            if (info == "null" || string.IsNullOrWhiteSpace(inputField.text)) {
                IncorrectTokenNotification.gameObject.SetActive(true);
            } else {
                GameObject.FindObjectOfType<DataBase>().GameCode = inputField.text;
                this.gameObject.SetActive(false);
                nextScreen.SetActive(true);
            }
        }
    }

    public void onClickNextBtn()
    {
        StartCoroutine(TokenCheck());
    }

}
