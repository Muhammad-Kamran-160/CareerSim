using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Mail;
using System;

public class WhoAreYou : MonoBehaviour
{
    public InputField Name;
    public InputField Email;
    public GameObject nextScreen;
    public DataBase DB;
    public AppData AD;
    public Text warning;
    public Text Nwarning;

    public bool IsValid(string emailaddress) {
        try {
            MailAddress m = new MailAddress(emailaddress);
            //Debug.Log("true---------");
            return true;
        } catch (FormatException) {
            warning.gameObject.SetActive(true);
            //Debug.Log("false---------");
            return false;
        }
    }
    private void OnEnable() {
        warning.gameObject.SetActive(false);
        Nwarning.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickNextBtn()
    {
        if (string.IsNullOrEmpty(Name.text)) {
            Debug.Log("Invalid name");
            Nwarning.gameObject.SetActive(true);
        } else if (string.IsNullOrEmpty(Email.text)) {
            Debug.Log("Invalid name");
            warning.gameObject.SetActive(true);
        } else {

            if (IsValid(Email.text)) {

                ColorBlock c = Email.colors;
                c.normalColor = Color.white;
                Email.colors = c;

                Player P = new Player(Name.text, Email.text);
                DB.Players.Add(P);
                AD.CurrentPlayer = P;
                this.gameObject.SetActive(false);
                nextScreen.SetActive(true);

            } else {
                ColorBlock c = Email.colors;
                c.normalColor = Color.red;
                Email.colors = c;
            }
        }
    }
}
