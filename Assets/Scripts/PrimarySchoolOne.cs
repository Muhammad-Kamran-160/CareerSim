using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimarySchoolOne : MonoBehaviour
{
    public GameObject unPassedLevelScreen;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickUnPassedLevelsBtn()
    {
        this.gameObject.SetActive(false);
        unPassedLevelScreen.SetActive(true);
    }
}
