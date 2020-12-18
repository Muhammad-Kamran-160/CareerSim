using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypesOfCharacter : MonoBehaviour {

    
    
    public GameObject CATab;
    public GameObject VATab;
    
    



    public bool MISelected, PCSelected, CASelected, VASelected;
    public AppData AD;
    public DataBase DB;
    public MI MI;
    public PC PC;
    public CA CA;
    public VA VA;
    public GameObject StartGameBtn;
    public GameObject SaveBtnPrefab;
    public GameObject NextScreen;
   // public List<Point> MultipleIntelligence = new List<Point>();
    public List<Point> PerformanceCharacter = new List<Point>();
    public List<string> CareerAnchor = new List<string>();
    public List<string> Values = new List<string>();

    private void Start() {
        StartGameBtn.SetActive(false);
        StartGameBtn.GetComponent<Button>().interactable = false;
        MI.gameObject.SetActive(true);
        

    }
    private void Update() {
        
        if (MISelected && PCSelected && CASelected && VASelected) {
            StartGameBtn.SetActive(true);
            StartGameBtn.GetComponent<Button>().interactable = true;

        } 
        else {
            StartGameBtn.SetActive(false);
            //print(MISelected + " " + PCSelected + " " + CASelected + " " + VASelected);
        }
    }
    public void StartGame() {
        //Debug.Log("1. called");
        //AD.CurrentPlayer.MultipleIntelligence = MultipleIntelligence;
        AD.CurrentPlayer.PerformanceCharacter = PerformanceCharacter;
        AD.CurrentPlayer.CareerAnchor = CareerAnchor;
        AD.CurrentPlayer.Values = Values;
        //Debug.Log("2. called");
        bool found = false;
        int index = -1;
        foreach (Player player in DB.Players) {
            index++;
            if (AD.CurrentPlayer.Name == player.Name && AD.CurrentPlayer.Email == player.Email) {
                found = true;
                break;
            }
        }
        //Debug.Log("3. called");
        if (found) {
            //DB.Players[index].MultipleIntelligence = MultipleIntelligence;
            DB.Players[index].PerformanceCharacter = PerformanceCharacter;
            DB.Players[index].CareerAnchor = CareerAnchor;
            DB.Players[index].Values = Values;
        }
        //Debug.Log("4. called");
        this.gameObject.SetActive(false);
        NextScreen.SetActive(true);
        //Debug.Log("called");
    }



    
}
