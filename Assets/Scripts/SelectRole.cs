using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectRole : MonoBehaviour
{
    public GameObject NextScreenForPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ONClickPlayer()
    {
        this.gameObject.SetActive(false);
        NextScreenForPlayer.SetActive(true);

    }
}
