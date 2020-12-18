using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    public Text RoundText;
    public DataBase DB;

    private void OnEnable()
    {
        RoundText.text = "Round " + DB.roundCounter;
    }

}
