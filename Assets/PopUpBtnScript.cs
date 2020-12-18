using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBtnScript : MonoBehaviour
{
    public GameObject PopUp;
    public void ShowPopUp() {
        PopUp.SetActive(true);
    }
}
