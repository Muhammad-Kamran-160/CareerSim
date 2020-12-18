using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class waitinScreenForRound : MonoBehaviour
{
    [SerializeField] private IndusturiesJobLimit JobLimits;
    public AppData AD;
    public DataBase DB;
    public Text BodyText;
    public GameObject nextScreen;
    public bool permission = false;
    public GameObject stats;
    public GameObject GamePlay;
    private char[] bodyJsonString;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() {
        StartCoroutine(LifeCardCorout_Server());
        FindObjectOfType<IndusturiesJobLimit>().GetJobLimitsData();
        //BodyText.text = "Waiting for round " + (DB.RoundCounter) + "\n to begin!";
        //StartCoroutine(LifeCardCorout());
    }

    private IEnumerator LifeCardCorout() {
        

        yield return new WaitForSeconds(3f);

        this.gameObject.SetActive(false);
        nextScreen.SetActive(true);
        DB.isRoundStarted = true;

        /*
        UploadData ud = new UploadData();
        ud.UploadAllData(AD, DB);
        StartCoroutine(SendData(ud.PlayerDataJson));
        // Round Started here...
        DB.isRoundStarted = true;
        */
    }
    public IEnumerator SendData(string data) {

        Debug.Log("Sending data: " + data);



        var request = new UnityWebRequest("http://18.223.239.177/hello/addplayer/", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(data);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);


        //        UnityWebRequest www = UnityWebRequest.Post("http://18.223.239.177/hello/addplayer/", data);
        //        www.method = UnityWebRequest.kHttpVerbPOST;
        //        www.uploadHandler.contentType = "application/json";
        ////      www.SetRequestHeader("Cotent-Type", "application/json");
        //        www.SetRequestHeader("Accept", "application/json");
        //        yield return www.SendWebRequest();
        //        Debug.Log("Request sent...");
        //        if (www.isNetworkError || www.isHttpError) {
        //            Debug.Log(www.error);
        //        } else {
        //            string dataReceived = www.downloadHandler.text;
        //            Debug.Log("Data received: " + dataReceived);
        //            MyPlayerData MPD = JsonUtility.FromJson<MyPlayerData>(dataReceived);
        //            //Debug.Log("_id: " + MPD._id);
        //        }



        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string dataReceived = request.downloadHandler.text;
            Debug.Log("Data received: " + dataReceived);
            IdClassStructure id_data = JsonUtility.FromJson<IdClassStructure>(dataReceived);
            AD.id_to_send_with = id_data._id;
            //Debug.Log("_id: " + MPD._id);

        }
    }
    private IEnumerator Corout_Delay()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(LifeCardCorout_Server());
    }
    private IEnumerator LifeCardCorout_Server() {
        string gameTocken = GameObject.FindObjectOfType<DataBase>().GameCode;
        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/get/game/" + gameTocken);
        yield return www.SendWebRequest();

        string data = "";
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            data = www.downloadHandler.text;
            if (data == "null")
            {
                BodyText.text = "Waiting for facilitator to create a New Game...";
                Debug.Log("Round not started by the facilitator yet, Checking again...");
                // Checking again...
                //StartCoroutine(LifeCardCorout_Server());
                StartCoroutine(Corout_Delay());
            }
            else
            {
                //Debug.Log("gameIDData: " + data);
                AD.gameIdData = JsonUtility.FromJson<GameIdData>(data);
                AD.game_id_data = AD.gameIdData._id;
                AD.CurrentPlayer.RemainingActionPoints = AD.gameIdData.actionpoints;
                //AD.CurrentPlayer.Bank = AD.gameIdData.money;
                DB.RoundTimer = AD.gameIdData.duration;
                DB.TotalRounds = AD.gameIdData.totalrounds;
                DB.roundCounter = DB.RoundCounter = AD.gameIdData.roundno;
                DB.isRoundStarted = AD.gameIdData.start;

                if (AD.CurrentPlayer.Bank == 0)
                {
                    AD.CurrentPlayer.Bank = AD.gameIdData.money;
                }

                if(AD.gameIdData.totalrounds == AD.gameIdData.roundno && AD.gameIdData.start == false)
                {
                    BodyText.text = "Waiting for facilitator to create a New Game...";
                    Debug.Log("Game not created by the facilitator yet, Checking again...");
                    // Checking again...
                    StartCoroutine(Corout_Delay());
                    //StartCoroutine(LifeCardCorout_Server());
                }
                else
                {
                    BodyText.text = "Waiting for round " + (DB.RoundCounter + 1) + "\n to begin!";
                }

                if (AD.gameIdData.start)
                {

                    //DB.roundCounter++;
                    //DB.RoundCounter++;

                    // Round Started here...
                    //AD.CurrentPlayer.RemainingActionPoints = AD.gameIdData.actionpoints;
                    //AD.CurrentPlayer.Bank = AD.gameIdData.money;
                    //DB.RoundTimer = AD.gameIdData.duration * 60f;
                    //DB.TotalRounds = AD.gameIdData.totalrounds;
                    //DB.isRoundStarted = AD.gameIdData.start;

                    // SEND DATA AT START OF ROUND HERE...
                    // send initial data here...
                    UploadData ud = GameObject.FindObjectOfType<UploadData>();
                    ud.UploadAllData(AD, DB, AD.gameIdData.roundno);

                    this.gameObject.SetActive(false);
                    nextScreen.SetActive(true);
                    // Get jobs limit data at start of each round
                    JobLimits.GetJobLimitsData();
                }
                else
                {
                    Debug.Log("Round not started by the facilitator yet, Checking again...");
                    // Checking again...
                    StartCoroutine(LifeCardCorout_Server());
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (permission==true)
        //{
        //    this.gameObject.SetActive(false);
        //    nextScreen.SetActive(true);
        //}
        //else
        //{
        //    this.gameObject.SetActive(true);
        //    nextScreen.SetActive(false);
        //}
    }
    public void onClickStatsBtn()
    {
        this.gameObject.SetActive(false);
        stats.SetActive(true);
    }
    public void onClickGameWorldBtn()
    {
        this.gameObject.SetActive(false);
        GamePlay.SetActive(true);
    }
    public void GetData()
    {
        AppData AD = GameObject.FindObjectOfType<AppData>();
        // Current Round...
        Debug.Log(DB.RoundCounter);
        // AP signal
        Debug.Log(AD.APDown);
        // Player Name...
        Debug.Log(AD.CurrentPlayer.Name);
        // Industry...
        Debug.Log(AD.CurrentPlayer.MyJob.FieldName);
        // CurrentJob...
        Debug.Log(AD.CurrentPlayer.MyJob.JobTitle);
        
        // Education Levels...
            // PhD
        for (int i = 0; i < AD.CurrentPlayer.Phd.Count; i++)
        {
            Debug.Log(AD.CurrentPlayer.Phd[i].edu);
        }
            // Master's
        for (int i = 0; i < AD.CurrentPlayer.Mast.Count; i++)
        {
            Debug.Log(AD.CurrentPlayer.Mast[i].edu);
        }
            // Bachelors's
        for (int i = 0; i < AD.CurrentPlayer.Bach.Count; i++)
        {
            Debug.Log(AD.CurrentPlayer.Bach[i].edu);
        }
            // Poly
        for (int i = 0; i < AD.CurrentPlayer.Poly.Count; i++)
        {
            Debug.Log(AD.CurrentPlayer.Poly[i].edu);
        }
            // junior college, secondary and primary
        for (int i = AD.CurrentPlayer.Educations.Count-1; i > -1; i--)
        {
            Debug.Log(AD.CurrentPlayer.Educations[i].edu);
        }
        // Possessions / Lifestyles
        for (int i = 0; i < AD.CurrentPlayer.Possession.Count; i++)
        {
            Debug.Log(AD.CurrentPlayer.Possession[i]);
        }
        // Bank Account
        Debug.Log(AD.CurrentPlayer.Bank);
    }
}
