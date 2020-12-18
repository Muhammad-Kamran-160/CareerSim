using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataBase : MonoBehaviour {

    public string _id_Player;
    public int InitialActionPoints = 50;
    public string GameCode = "-";
    public Character character;
    public skills skill;
    public List<Player> Players;
    public Industries industries = new Industries();
    public List<QuizModel> Quizes = new List<QuizModel>();

    [HideInInspector]
    public LifeCard LifeCards = new LifeCard();
    
    public string QuizLevel = "";

    /// <summary>
    /// Quiz Lists Started
    /// </summary>

    public List<QuizModel> QuizesPri = new List<QuizModel>();
    public List<QuizModel> QuizesSec = new List<QuizModel>();
    public List<QuizModel> QuizesJun = new List<QuizModel>();
    public List<QuizModel> QuizesPol = new List<QuizModel>();
    public List<QuizModel> QuizesBac = new List<QuizModel>();
    public List<QuizModel> QuizesMas = new List<QuizModel>();
    public List<QuizModel> QuizesPhd = new List<QuizModel>();
    
    public List<QuizModel> Quizes_Chief_Financial_Officer = new List<QuizModel>();
    public List<QuizModel> Quizes_Management_Accounting_Accounting_Executive = new List<QuizModel>();
    public List<QuizModel> Quizes_Management_Accounting_Financial_Planning_and_Analysis_Manager = new List<QuizModel>();
    public List<QuizModel> Quizes_Management_Accounting_Business_Controller = new List<QuizModel>();
    public List<QuizModel> Quizes_Financial_Accounting_Accounts_Executive = new List<QuizModel>();
    public List<QuizModel> Quizes_Financial_Accounting_Finance_Manager = new List<QuizModel>();
    public List<QuizModel> Quizes_Financial_Accounting_Financial_Controller = new List<QuizModel>();

    public List<QuizModel> Quizes_Senior_Principal_Physiotherapy_Researcher = new List<QuizModel>();
    public List<QuizModel> Quizes_Senior_Principal_Physiotherapist_Clinical = new List<QuizModel>();
    public List<QuizModel> Quizes_Senior_Principal_Physiotherapy_Educator = new List<QuizModel>();
    public List<QuizModel> Quizes_Principal_Physiotherapy_Educator = new List<QuizModel>();
    public List<QuizModel> Quizes_Principal_Physiotherapist_Clinical = new List<QuizModel>();
    public List<QuizModel> Quizes_Principal_Physiotherapy_Researcher = new List<QuizModel>();
    public List<QuizModel> Quizes_Senior_Physiotherapist = new List<QuizModel>();
    public List<QuizModel> Quizes_Physiotherapist = new List<QuizModel>();

    public List<QuizModel> Quizes_Chief_Human_Resource_Officer = new List<QuizModel>();
    public List<QuizModel> Quizes_Head_Performance_Rewards = new List<QuizModel>();
    public List<QuizModel> Quizes_Manager_Performance_Rewards = new List<QuizModel>();
    public List<QuizModel> Quizes_Executive_Performance_Rewards = new List<QuizModel>();
    public List<QuizModel> Quizes_Head_Employee_Experience_Relations = new List<QuizModel>();
    public List<QuizModel> Quizes_Manager_Employee_Experience_Relations = new List<QuizModel>();
    public List<QuizModel> Quizes_Executive_Employee_Experience_Relations = new List<QuizModel>();
    public List<QuizModel> Quizes_Head_Talent_Attraction = new List<QuizModel>();
    public List<QuizModel> Quizes_Manager_Talent_Attraction = new List<QuizModel>();
    public List<QuizModel> Quizes_Executive_Talent_Attraction = new List<QuizModel>();

    public List<QuizModel> Quizes_Head_of_Product = new List<QuizModel>();
    public List<QuizModel> Quizes_Lead_UX_Designer = new List<QuizModel>();
    public List<QuizModel> Quizes_Senior_UX_Designer = new List<QuizModel>();
    public List<QuizModel> Quizes_UX_Designer = new List<QuizModel>();
    public List<QuizModel> Quizes_Chief_Technology_Officer = new List<QuizModel>();
    public List<QuizModel> Quizes_Applications_Architect = new List<QuizModel>();
    public List<QuizModel> Quizes_Applications_Development_Manager = new List<QuizModel>();
    public List<QuizModel> Quizes_Applications_Developer = new List<QuizModel>();

    public List<QuizModel> Quizes_Executive_Producer_Broadcast = new List<QuizModel>();
    public List<QuizModel> Quizes_Producer_Broadcast = new List<QuizModel>();
    public List<QuizModel> Quizes_Assistant_Producer_Broadcast = new List<QuizModel>();
    public List<QuizModel> Quizes_Production_Assistant = new List<QuizModel>();
    public List<QuizModel> Quizes_Chief_Editor = new List<QuizModel>();
    public List<QuizModel> Quizes_Executive_Editor = new List<QuizModel>();
    public List<QuizModel> Quizes_Senior_Reporter_Senior_Correspondent = new List<QuizModel>();
    public List<QuizModel> Quizes_Reporter_Correspondent = new List<QuizModel>();

    public List<QuizModel> Quizes_Chief_Executive_Officer_Managing_Director = new List<QuizModel>();
    public List<QuizModel> Quizes_Brand_Director = new List<QuizModel>();
    public List<QuizModel> Quizes_Brand_Manager = new List<QuizModel>();
    public List<QuizModel> Quizes_Brand_Associate = new List<QuizModel>();
    public List<QuizModel> Quizes_Merchandising_Director = new List<QuizModel>();
    public List<QuizModel> Quizes_Merchandising_Manager = new List<QuizModel>();
    public List<QuizModel> Quizes_Visual_Merchandiser = new List<QuizModel>();

    public List<QuizModel> Quizes_AC = new List<QuizModel>();
    public List<QuizModel> Quizes_HC = new List<QuizModel>();
    public List<QuizModel> Quizes_HR = new List<QuizModel>();
    public List<QuizModel> Quizes_IT = new List<QuizModel>();
    public List<QuizModel> Quizes_RE = new List<QuizModel>();
    public List<QuizModel> Quizes_ME = new List<QuizModel>();
    //public List<MyLifeCardData> LifeCardsDownloaded = new List<MyLifeCardData>();

    /// <summary>
    /// Quiz Lists ended
    /// </summary>

    public bool RoundOneEnded = false;
    public bool JobEnded = false;
    public int RoundCounter = 0;
    public int TotalRounds = 0;
    public float RoundTimer = 20;
    public bool isRoundStarted = false;
    public bool isLoaded = false;

    private void Awake() {
        character = new Character();
        skill = new skills();

        //UnityWebRequest www = UnityWebRequest.Post("http://18.223.239.177/hello/player/update/123", )

    }

    

    /// <summary>


    private IEnumerator Checking_If_Round_Ended()
    {
        if (isRoundStarted)
        {
            string gameTocken = GameObject.FindObjectOfType<DataBase>().GameCode;
            if (!string.IsNullOrEmpty(gameTocken))
            {
                UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/get/game/" + gameTocken);
                yield return www.SendWebRequest();
                string data = "";
                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    AppData AD = GameObject.FindObjectOfType<AppData>();

                    //data = www.downloadHandler.text;
                    //Debug.Log("gameIDData: " + data);
                    //GameIdData gameIdData = new GameIdData();
                    //gameIdData = JsonUtility.FromJson<GameIdData>(data);
                    //isRoundStarted = gameIdData.start;
                    data = www.downloadHandler.text;
                    //Debug.Log("gameIDData: " + data);
                    AD.gameIdData = JsonUtility.FromJson<GameIdData>(data);
                    //AD.game_id_data = AD.gameIdData._id;
                    //AD.CurrentPlayer.RemainingActionPoints = AD.gameIdData.actionpoints;
                    //AD.CurrentPlayer.Bank = AD.gameIdData.money;
                    ////DB.RoundTimer = AD.gameIdData.duration * 60f;
                    ////DB.TotalRounds = AD.gameIdData.totalrounds;
                    isRoundStarted = AD.gameIdData.start;
                    if (isRoundStarted == false)
                    {
                        RoundOneEnded = true;
                    }

                }
            }
        }
    }


    /// </summary>



    float CheckTimer = 3f;

    // Start is called before the first frame update
    void Start() {
        Screen.fullScreen = true;
        StartCoroutine(DownloadLifeCard());
    }



    IEnumerator DownloadLifeCard()
    {
        string LifeCardData = "";

        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/get/lifecards");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            LifeCardData = www.downloadHandler.text;
            //Debug.Log(LifeCardData);
            MyLifeCardData[] lifecards = JsonHelper.getJsonArray<MyLifeCardData>(LifeCardData);
            //Debug.Log("LIFE CARD => " + lifecards.Length);
            LifeCards.insertLifeCards(lifecards);
        }
    }

    public int roundCounter = 0;

    float JobStatusCheck_Timer = 5f;

    // Update is called once per frame
    void Update() {

        AppData LocalDB = GameObject.FindObjectOfType<AppData>();
        string str = LocalDB.CurrentPlayer.Bank.ToString();
        string str2 = "";

        bool checkoo = false;
        //Debug.Log("LENGTH OF BANK ACCOUNT DIGITS: " + str.Length);
        int count = 0;
        for (int i = 0; i < str.Length; i++) {
            if ((count + 1) % 7 == 0) {
                str2 += ",";
                //Debug.Log("answered");
            }

            str2 += str[str.Length - 1 - i];
            count++;
            if (count % 3 == 0 && checkoo == false && str.Length > 3) {
                str2 += ",";
                checkoo = true;
            }

        }
        LocalDB.CurrentPlayer.BankString = "";
        for (int i = 0; i < str2.Length; i++) {
            LocalDB.CurrentPlayer.BankString += str2[str2.Length - 1 - i];
        }

        if (CheckTimer <= 0)
        {
            StartCoroutine(Checking_If_Round_Ended());
            CheckTimer = 3;
        }
        else
        {
            CheckTimer -= Time.deltaTime;
        }

        //if (Input.GetKeyDown(KeyCode.Escape)) {

        //    roundCounter++;
        //    RoundCounter++;

        //    RoundOneEnded = true;
        //    Debug.Log("escaped pressed");
        //}

        // round timer...
        if (RoundTimer < 0 && isRoundStarted)
        {
            //RoundTimer = 300f;      // use round timer instead...
            //roundCounter++;
            //RoundCounter++;
            RoundOneEnded = true;
            if (GameObject.FindObjectOfType<AppData>().AvgCount > 0) {
                GameObject.FindObjectOfType<AppData>().CurrentPlayer.AvgSalary = GameObject.FindObjectOfType<AppData>().AvgSum / GameObject.FindObjectOfType<AppData>().AvgCount;
            }
            GameObject.FindObjectOfType<AppData>().AvgSum = GameObject.FindObjectOfType<AppData>().AvgCount = 0;
            Debug.Log("escaped pressed");
        }
        else
        {
            if (isRoundStarted)
            {
                RoundTimer -= Time.deltaTime;
                //Debug.Log("Time Left: " + RoundTimer);
            }
        }


        if (Connection.instance.isConnected) {
            if (!isLoaded) {
                MyTest.instance.LoadData();

                if(MyTest.instance.q != null) {
                    //MyTest.instance.q.Fetch("5dbd7ddf415ca23da4e38213");
                    isLoaded = true;
                }
            }
        }

        if (!string.IsNullOrEmpty(LocalDB.MyFinalJob.JobTitle) && RoundCounter > 1) {
            if (JobStatusCheck_Timer <= 0) {
                JobStatusCheck_Timer = 5f;
                StartCoroutine(CheckJobStatus());
            } else {
                JobStatusCheck_Timer -= Time.deltaTime;
            }
        }

    }
    private IEnumerator CheckJobStatus() {
        // check job status here
        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/getplayers/getbyid/" + _id_Player);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            string playerJson = www.downloadHandler.text;
            MyPlayerData MPD = JsonUtility.FromJson<MyPlayerData>(playerJson);
            JobEnded = !MPD.jobstatus;
        }
    }
}

[Serializable]
public class skills
{

    public const int WordSmart = 0;
    public const int LogicalSmart = 1;
    public const int SelfSmart = 2;
    public const int PeopleSmart = 3;
    public const int MusicSmart = 4;
    public const int BodySmart = 5;
    public const int PictureSmart = 6;
    public const int NatureSmart = 7;


    public List<SkillsDes> Accountacy=new List<SkillsDes>();
    public List<SkillsDes> HealtCare = new List<SkillsDes>();
    public List<SkillsDes> HR = new List<SkillsDes>();
    public List<SkillsDes> IT = new List<SkillsDes>();
    public List<SkillsDes> Retail = new List<SkillsDes>();
    public List<SkillsDes> Media = new List<SkillsDes>();

    public skills() {

        //Accountacy.Add(new SkillsDes("Accounting Standards", ""));
        SkillsDes sd = new SkillsDes("Accounting Systems", 0);
        sd.MI = skills.LogicalSmart;
        Accountacy.Add(sd);
        //Accountacy.Add(new SkillsDes("Audit Compliance", ""));
        //Accountacy.Add(new SkillsDes("Audit Frameworks", ""));
        //Accountacy.Add(new SkillsDes("Benchmarking", ""));
        //Accountacy.Add(new SkillsDes("Business Acumen", ""));
        //Accountacy.Add(new SkillsDes("Business Development", ""));
        //Accountacy.Add(new SkillsDes("Business Innovation", ""));
        sd = new SkillsDes("Business Planning", 0);
        sd.MI = skills.LogicalSmart;
        Accountacy.Add(sd);
        //Accountacy.Add(new SkillsDes("Business Development", ""));
        // Accountacy.Add(new SkillsDes("Business Process Management", ""));
        // Accountacy.Add(new SkillsDes("Capital Expenditure and Investment Evaluation", ""));
        // Accountacy.Add(new SkillsDes("Capital Raising", ""));
        sd = new SkillsDes("Change Management", 0);
        sd.MI = skills.SelfSmart;
        Accountacy.Add(sd);
        sd = new SkillsDes("Communication", 0);
        sd.MI = skills.PeopleSmart;
        Accountacy.Add(sd);
        // Accountacy.Add(new SkillsDes("Compliance", ""));
        // Accountacy.Add(new SkillsDes("Conflict Management", ""));
        sd = new SkillsDes("Corporate and Business Law", 0);
        sd.MI = skills.WordSmart;
        Accountacy.Add(sd);
        //Accountacy.Add(new SkillsDes("Cost Management", ""));
        //Accountacy.Add(new SkillsDes("Creative Thinking", ""));
        //Accountacy.Add(new SkillsDes("Cyber Security", ""));
        sd = new SkillsDes("Data Analytics", 0);
        sd.MI = skills.LogicalSmart;
        Accountacy.Add(sd);
        sd = new SkillsDes("Decision Making", 0);
        sd.MI = skills.WordSmart;
        Accountacy.Add(sd);
        //Accountacy.Add(new SkillsDes("Developing People", ""));
        //Accountacy.Add(new SkillsDes("Digital Literacy", ""));
        //Accountacy.Add(new SkillsDes("Disruption Management", ""));
        // Accountacy.Add(new SkillsDes("Enterprise Risk Management", ""));
        // Accountacy.Add(new SkillsDes("Ethical Climate", ""));
        sd = new SkillsDes("Ethical Conflict Resolution", 0);
        sd.MI = skills.SelfSmart;
        Accountacy.Add(sd);
        //Accountacy.Add(new SkillsDes("Ethical Culture", ""));
        //Accountacy.Add(new SkillsDes("Financial Analysis", ""));
        //Accountacy.Add(new SkillsDes("Financial Closing", ""));
        sd = new SkillsDes("Financial Management", 0);
        sd.MI = skills.LogicalSmart;
        Accountacy.Add(sd);
        // Accountacy.Add(new SkillsDes("Financial Planning", ""));
        //Accountacy.Add(new SkillsDes("Financial Report Quality", ""));
        sd = new SkillsDes("Financial Reporting", 0);
        sd.MI = skills.LogicalSmart;
        Accountacy.Add(sd);
        // Accountacy.Add(new SkillsDes("Financial Statements Review", ""));
        //Accountacy.Add(new SkillsDes("Fraud Risk Management", ""));
        //Accountacy.Add(new SkillsDes("Global Mindset", ""));
        //Accountacy.Add(new SkillsDes("Governance", ""));
        //Accountacy.Add(new SkillsDes("Group Accounting and Consolidation", ""));
        //Accountacy.Add(new SkillsDes("Infocomm Technology Adoption and Innovation", ""));
        //Accountacy.Add(new SkillsDes("Infocomm Technology Environment and Development", ""));
        //Accountacy.Add(new SkillsDes("Infocomm Technology Governance", ""));
        //Accountacy.Add(new SkillsDes("Internal Controls", ""));
        //Accountacy.Add(new SkillsDes("Interpersonal skills", ""));
        //Accountacy.Add(new SkillsDes("Leadership", ""));
        //Accountacy.Add(new SkillsDes("Lifelong Learning", ""));
        //Accountacy.Add(new SkillsDes("Macroeconomic Analysis", ""));
        sd = new SkillsDes("Management Decision Making", 0);
        sd.MI = skills.PeopleSmart;
        Accountacy.Add(sd);
        //Accountacy.Add(new SkillsDes("Managing Diversity", ""));
        //Accountacy.Add(new SkillsDes("Merger and Acquisitions", ""));
        //Accountacy.Add(new SkillsDes("Non- Financial Reporting", ""));
        //Accountacy.Add(new SkillsDes("Performance Management", ""));
        //Accountacy.Add(new SkillsDes("Problem Solving", ""));
        //Accountacy.Add(new SkillsDes("Professional Growth", ""));
        //Accountacy.Add(new SkillsDes("Professional Scepticism and Judgment", ""));
        //Accountacy.Add(new SkillsDes("Professional Standards", ""));
        sd = new SkillsDes("Project Execution and Control", 0);
        sd.MI = skills.WordSmart;
        Accountacy.Add(sd);
        sd = new SkillsDes("Project Feasibility", 0);
        sd.MI = skills.WordSmart;
        Accountacy.Add(sd);
        //Accountacy.Add(new SkillsDes("Regulatory Risk Assessment", ""));
        //Accountacy.Add(new SkillsDes("Regulatory Strategy", ""));
        //Accountacy.Add(new SkillsDes("Resource Management", ""));
        //Accountacy.Add(new SkillsDes("Risk Management Strategy", ""));
        //Accountacy.Add(new SkillsDes("Resource Management", ""));
        //Accountacy.Add(new SkillsDes("Sense Making", ""));
        //Accountacy.Add(new SkillsDes("Service Orientation", ""));
        //Accountacy.Add(new SkillsDes("Stakeholder Management", ""));
        //Accountacy.Add(new SkillsDes("Tax Compliance", ""));
        //Accountacy.Add(new SkillsDes("Tax Computation", ""));
        //Accountacy.Add(new SkillsDes("Tax Implications", ""));
        sd = new SkillsDes("Taxation Laws", 0);
        sd.MI = skills.WordSmart;
        Accountacy.Add(sd);
        //Accountacy.Add(new SkillsDes("Teamwork", ""));
        //Accountacy.Add(new SkillsDes("Transactional Accounting", ""));
        //Accountacy.Add(new SkillsDes("Transfer Pricing", ""));
        //Accountacy.Add(new SkillsDes("Treasury Management", ""));
        //Accountacy.Add(new SkillsDes("Valuation", ""));




        //HealtCare.Add(new SkillsDes("Analysis of Research Data", ""));
        //HealtCare.Add(new SkillsDes("Assistive Devices Prescription in Occupational Therapy", ""));
        //HealtCare.Add(new SkillsDes("Audit Management", ""));
        //HealtCare.Add(new SkillsDes("Case History Taking in Physiotherapy", ""));
        sd = new SkillsDes("Change Management", 0);
        sd.MI = skills.SelfSmart;
        HealtCare.Add(sd);
        //HealtCare.Add(new SkillsDes("Client Advocacy", ""));
        //HealtCare.Add(new SkillsDes("Client Assessment for Occupational Therapy", ""));
        //HealtCare.Add(new SkillsDes("Client Assessment for Physiotherapy", ""));
        //HealtCare.Add(new SkillsDes("Client Education in Rehabilitation Therapy", ""));
        //HealtCare.Add(new SkillsDes("Clinical Governance", ""));
        //HealtCare.Add(new SkillsDes("Clinical Incident Management in Rehabilitation Therapy", ""));
        //HealtCare.Add(new SkillsDes("Clinical Record Documentation and Management in Rehabilitation Therapy", ""));
        //HealtCare.Add(new SkillsDes("Clinical Services Development", ""));
        //HealtCare.Add(new SkillsDes("Clinical Teaching and Supervision", ""));
        //HealtCare.Add(new SkillsDes("Communication", ""));
        sd = new SkillsDes("Continuous Improvement Management", 0);
        sd.MI = skills.SelfSmart;
        HealtCare.Add(sd);
        //HealtCare.Add(new SkillsDes("Creative Thinking", ""));
        //HealtCare.Add(new SkillsDes("Data Collection and Management", ""));
        sd = new SkillsDes("Decision Making", 0);
        sd.MI = skills.WordSmart;
        HealtCare.Add(sd);
        //HealtCare.Add(new SkillsDes("Department Financial Management", ""));
        //HealtCare.Add(new SkillsDes("Developing People", ""));
        //HealtCare.Add(new SkillsDes("Development on Intervention Plan for Physiotherapy", ""));
        //HealtCare.Add(new SkillsDes("Effective Client Communication", ""));
        //HealtCare.Add(new SkillsDes("Emergency Response and Crisis Management", ""));
        //HealtCare.Add(new SkillsDes("Environmental Assessment and Modification for Occupational Therapy", ""));
        //HealtCare.Add(new SkillsDes("Environmental Assessment and Modification for Physiotherapy", ""));
        //HealtCare.Add(new SkillsDes("Goal Setting in Rehabilitation Therapy", ""));
        //HealtCare.Add(new SkillsDes("Group Therapy Planning and Implementation", ""));
        //HealtCare.Add(new SkillsDes("Health Promotion", ""));
        sd = new SkillsDes("Individual and Cultural Diversity", 0);
        sd.MI = skills.PeopleSmart;
        HealtCare.Add(sd);
        //HealtCare.Add(new SkillsDes("Infection Control", ""));
        //HealtCare.Add(new SkillsDes("Inter-Professional Collaboration", ""));
        //HealtCare.Add(new SkillsDes("Inter-professional Collaboration", ""));
        //HealtCare.Add(new SkillsDes("Interpersonal Skills", ""));
        //HealtCare.Add(new SkillsDes("Intervention Planning in Occupational Therapy", ""));
        //HealtCare.Add(new SkillsDes("Inventory Management in Rehabilitation Therapy", ""));
        //HealtCare.Add(new SkillsDes("Leadership", ""));
        sd = new SkillsDes("Learning Needs Analysis", 0);
        sd.MI = skills.PeopleSmart;
        HealtCare.Add(sd);
        //HealtCare.Add(new SkillsDes("Lifelong Learning", ""));
        sd = new SkillsDes("Management of Stakeholders", 0);
        sd.MI = skills.PeopleSmart;
        HealtCare.Add(sd);
        sd = new SkillsDes("People Management", 0);
        sd.MI = skills.PeopleSmart;
        HealtCare.Add(sd);
        //HealtCare.Add(new SkillsDes("Performance Management", ""));
        sd = new SkillsDes("Problem Solving", 0);
        sd.MI = skills.LogicalSmart;
        HealtCare.Add(sd);
        //HealtCare.Add(new SkillsDes("Professional Consultation", 0));
        sd = new SkillsDes("Professional, Legal and Ethical Healthcare Practice", 0);
        sd.MI = skills.SelfSmart;
        HealtCare.Add(sd);
        sd = new SkillsDes("Programme Delivery", 0);
        sd.MI = skills.LogicalSmart;
        HealtCare.Add(sd);
        //HealtCare.Add(new SkillsDes("Programme Design", ""));
        //HealtCare.Add(new SkillsDes("Programme Evaluation", ""));
        sd = new SkillsDes("Project Management", 0);
        sd.MI = skills.LogicalSmart;
        HealtCare.Add(sd);
        sd = new SkillsDes("Reflective Practice", 0);
        sd.MI = skills.SelfSmart;
        HealtCare.Add(sd);
        //HealtCare.Add(new SkillsDes("Research Proposal Development", ""));
        //HealtCare.Add(new SkillsDes("Research Translation ", ""));
        //HealtCare.Add(new SkillsDes("Resource Management", ""));
        //HealtCare.Add(new SkillsDes("Risk Management", ""));
        //HealtCare.Add(new SkillsDes("Scientific Writing and Communication", ""));
        //HealtCare.Add(new SkillsDes("Sense Making", ""));
        //HealtCare.Add(new SkillsDes("Service Quality Management", ""));
        sd = new SkillsDes("Strategy Development", 0);
        sd.MI = skills.WordSmart;
        HealtCare.Add(sd);
        sd = new SkillsDes("Strategy Execution", 0);
        sd.MI = skills.LogicalSmart;
        HealtCare.Add(sd);
        //HealtCare.Add(new SkillsDes("Teamwork", ""));
        //HealtCare.Add(new SkillsDes("Therapeutic Equipment Prescription in Physiotherapy", ""));
        //HealtCare.Add(new SkillsDes("Therapy Discharge Planning", ""));
        //HealtCare.Add(new SkillsDes("Therapy Intervention Evaluation", ""));
        //HealtCare.Add(new SkillsDes("Therapy Intervention Implementation", ""));
        //HealtCare.Add(new SkillsDes("Transdisciplinary Thinking", ""));
        //HealtCare.Add(new SkillsDes("Workforce Planning", ""));
        //HealtCare.Add(new SkillsDes("Workplace Safety and Health", ""));
        //HealtCare.Add(new SkillsDes("Workplace Violence", ""));


        //HR.Add(new SkillsDes("Benefits Management", ""));
        sd = new SkillsDes("Business Acumen", 0);
        sd.MI = skills.NatureSmart;
        HR.Add(sd);
        //HR.Add(new SkillsDes("Career Framework Design", ""));
        sd = new SkillsDes("Communication", 0);
        sd.MI = skills.PeopleSmart;
        HR.Add(sd);
        //HR.Add(new SkillsDes("Compensation Management", ""));
        //HR.Add(new SkillsDes("Computational Thinking", ""));
        //HR.Add(new SkillsDes("Conduct and Behaviour Management", ""));
        //HR.Add(new SkillsDes("Contingent Workforce Management", ""));
        //HR.Add(new SkillsDes("Creative Thinking", ""));
        //HR.Add(new SkillsDes("Data Collection & Preparation", ""));
        //HR.Add(new SkillsDes("Data Governance", ""));
        //HR.Add(new SkillsDes("Data Management", ""));
        //HR.Add(new SkillsDes("Decision Making", ""));
        //HR.Add(new SkillsDes("Developing People", ""));
        //HR.Add(new SkillsDes("Digital Literacy", ""));
        //HR.Add(new SkillsDes("Digital Marketing & Communication", ""));
        sd = new SkillsDes("Diversity and Inclusion Management", 0);
        sd.MI = skills.PeopleSmart;
        HR.Add(sd);
        sd = new SkillsDes("Employee Communication Management", 0);
        sd.MI = skills.PeopleSmart;
        HR.Add(sd);
        //HR.Add(new SkillsDes("Employee Engagement Management", ""));
        //HR.Add(new SkillsDes("Employee Mobility Management", ""));
        //HR.Add(new SkillsDes("Employee Relationship Management", ""));
        //HR.Add(new SkillsDes("Employer Branding", ""));
        //HR.Add(new SkillsDes("Executive Remuneration Management", ""));
        sd = new SkillsDes("Financial Acumen", 0);
        sd.MI = skills.LogicalSmart;
        HR.Add(sd);
        //HR.Add(new SkillsDes("Global Mindset", ""));
        //HR.Add(new SkillsDes("Health & Wellness Programme Management", ""));
        //HR.Add(new SkillsDes("Human Resources Advisory", ""));
        sd = new SkillsDes("Human Resources Analytics and Insights", 0);
        sd.MI = skills.WordSmart;
        HR.Add(sd);
        //HR.Add(new SkillsDes("Human Resources Digitalisation", ""));
        sd = new SkillsDes("Human Resources Policies and Legislation Framework Management", 0);
        sd.MI = skills.WordSmart;
        HR.Add(sd);
        sd = new SkillsDes("Human Resources Practices Implementation", 0);
        sd.MI = skills.WordSmart;
        HR.Add(sd);
        //HR.Add(new SkillsDes("Human Resources Service Quality Management", ""));
        //HR.Add(new SkillsDes("Human Resources Strategy", ""));
        //HR.Add(new SkillsDes("Human Resources Strategy Formulation", ""));
        //HR.Add(new SkillsDes("Human Resources Systems Management", ""));
        //HR.Add(new SkillsDes("Industry Networking", ""));
        //HR.Add(new SkillsDes("Interpersonal Skills", ""));
        //HR.Add(new SkillsDes("Involuntary Exit Management", ""));
        //HR.Add(new SkillsDes("Job Analysis and Evaluation", ""));
        //HR.Add(new SkillsDes("Labour Relations Management", ""));
        //HR.Add(new SkillsDes("Leadership", ""));
        //HR.Add(new SkillsDes("Leadership Development", ""));
        //HR.Add(new SkillsDes("Learning and Development Strategy", ""));
        //HR.Add(new SkillsDes("Managing Diversity", ""));
        //HR.Add(new SkillsDes("Onboarding", ""));
        sd = new SkillsDes("Operational Excellence", 0);
        sd.MI = skills.SelfSmart;
        HR.Add(sd);
        sd = new SkillsDes("Organisational Change Management", 0);
        sd.MI = skills.NatureSmart;
        HR.Add(sd);
        //HR.Add(new SkillsDes("Organisational Culture Development", ""));
        //HR.Add(new SkillsDes("Organisational Design", ""));
        //HR.Add(new SkillsDes("Organisational Diagnosis", ""));
        //HR.Add(new SkillsDes("Organisational Event Management", ""));
        //HR.Add(new SkillsDes("Organisational Strategy Development", ""));
        //HR.Add(new SkillsDes("Performance Management", ""));
        sd = new SkillsDes("Problem Solving", 0);
        sd.MI = skills.LogicalSmart;
        HR.Add(sd);
        sd = new SkillsDes("Project Management", 0);
        sd.MI = skills.LogicalSmart;
        HR.Add(sd);
        //HR.Add(new SkillsDes("Recruitment Channel Management", ""));
        //HR.Add(new SkillsDes("Resource Management", ""));
        //HR.Add(new SkillsDes("Risk Management", ""));
        //HR.Add(new SkillsDes("Selection Management", ""));
        //HR.Add(new SkillsDes("Sense Making", ""));
        //HR.Add(new SkillsDes("Service Orientation", ""));
        sd = new SkillsDes("Skills Framework Adoption", 0);
        sd.MI = skills.WordSmart;
        HR.Add(sd);
        sd = new SkillsDes("Stakeholder Engagement and Management", 0);
        sd.MI = skills.PeopleSmart;
        HR.Add(sd);
        ///*HR.Add(new SkillsDes("Strategic Workforce Planning"*/, ""));
        //HR.Add(new SkillsDes("Succession Planning", ""));
        //HR.Add(new SkillsDes("Talent Management", ""));
        //HR.Add(new SkillsDes("Teamwork", ""));
        sd = new SkillsDes("Technology Integration", 0);
        sd.MI = skills.LogicalSmart;
        HR.Add(sd);
        //HR.Add(new SkillsDes("Total Rewards Philosophy Development", ""));
        //HR.Add(new SkillsDes("Transdisciplinary Thinking", ""));
        //HR.Add(new SkillsDes("Voluntary Exit Management", ""));
        //HR.Add(new SkillsDes("Workplace Optimisation", ""));


        //IT.Add(new SkillsDes("Applications Development", ""));
        //IT.Add(new SkillsDes("Applications Integration", ""));
        //IT.Add(new SkillsDes("Applications Support and Enhancement", ""));
        //IT.Add(new SkillsDes("Brand Management ", ""));
        sd = new SkillsDes("Business Innovation", 0);
        sd.MI = skills.NatureSmart;
        IT.Add(sd);
        sd = new SkillsDes("Business Needs Analysis", 0);
        sd.MI = skills.WordSmart;
        IT.Add(sd);
        //IT.Add(new SkillsDes("Business Risk Management ", ""));
        //IT.Add(new SkillsDes("Change Management ", ""));
        sd = new SkillsDes("Communication", 0);
        sd.MI = skills.PeopleSmart;
        IT.Add(sd);
        sd = new SkillsDes("Computational Thinking", 0);
        sd.MI = skills.LogicalSmart;
        IT.Add(sd);
        //IT.Add(new SkillsDes("Configuration Tracking", ""));
        sd = new SkillsDes("Creative Thinking", 0);
        sd.MI = skills.PictureSmart;
        IT.Add(sd);
        //IT.Add(new SkillsDes("Customer Experience Management", ""));
        //IT.Add(new SkillsDes("Data Design", ""));
        //IT.Add(new SkillsDes("Database Administration", ""));
        //IT.Add(new SkillsDes("Decision Making", ""));
        //IT.Add(new SkillsDes("Developing People", ""));
        //IT.Add(new SkillsDes("Digital Literacy", ""));
        //IT.Add(new SkillsDes("Embedded Systems Interface Design", ""));
        sd = new SkillsDes("Emerging Technology Synthesis", 0);
        sd.MI = skills.NatureSmart;
        IT.Add(sd);
        //IT.Add(new SkillsDes("Enterprise Architecture", ""));
        //IT.Add(new SkillsDes("Global Mindset", ""));
        //IT.Add(new SkillsDes("Interpersonal Skills", ""));
        //IT.Add(new SkillsDes("IT Strategy", ""));
        //IT.Add(new SkillsDes("Leadership", ""));
        //IT.Add(new SkillsDes("Lifelong Learning", ""));
        //IT.Add(new SkillsDes("Market Research", ""));
        //IT.Add(new SkillsDes("Partnership Management", ""));
        //IT.Add(new SkillsDes("Performance Management", ""));
        //IT.Add(new SkillsDes("Portfolio Management", ""));
        //IT.Add(new SkillsDes("Problem Management", ""));
        //IT.Add(new SkillsDes("Problem Solving", ""));
        //IT.Add(new SkillsDes("Product Management", ""));
        sd = new SkillsDes("Programme Management", 0);
        sd.MI = skills.LogicalSmart;
        IT.Add(sd);
        //IT.Add(new SkillsDes("Quality Standards", ""));
        //IT.Add(new SkillsDes("Security Architecture", ""));
        sd = new SkillsDes("Sense Making", 0);
        sd.MI = skills.LogicalSmart;
        IT.Add(sd);
        //IT.Add(new SkillsDes("Service Orientation", ""));
        //IT.Add(new SkillsDes("Software Configuration", ""));
        sd = new SkillsDes("Software Design", 0);
        sd.MI = skills.PictureSmart;
        IT.Add(sd);
        //IT.Add(new SkillsDes("Software Testing", ""));
        sd = new SkillsDes("Solution Architecture", 0);
        sd.MI = skills.LogicalSmart;
        IT.Add(sd);
        sd = new SkillsDes("Stakeholder Management", 0);
        sd.MI = skills.PeopleSmart;
        IT.Add(sd);
        //IT.Add(new SkillsDes("Sustainability Management", ""));
        //IT.Add(new SkillsDes("System Integration", ""));
        //IT.Add(new SkillsDes("Teamwork", ""));
        sd = new SkillsDes("Test Planning", 0);
        sd.MI = skills.LogicalSmart;
        IT.Add(sd);
        //IT.Add(new SkillsDes("Transdisciplinary Thinking", ""));
        sd = new SkillsDes("User Experience Design", 0);
        sd.MI = skills.PictureSmart;
        IT.Add(sd);
        sd = new SkillsDes("User Interface Design", 0);
        sd.MI = skills.PictureSmart;
        IT.Add(sd);




        //Retail.Add(new SkillsDes("Brand Campaign Management ", ""));
        //Retail.Add(new SkillsDes("Brand Guideline Development ", ""));
        //Retail.Add(new SkillsDes("Brand Portfolio Management ", ""));
        //Retail.Add(new SkillsDes("Business Continuity Management ", ""));
        //Retail.Add(new SkillsDes("Business Continuity Planning ", ""));
        sd = new SkillsDes("Business Environment Analysis ", 0);
        sd.MI = skills.NatureSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("Business Negotiation ", ""));
        sd = new SkillsDes("Business Operational Planning", 0);
        sd.MI = skills.LogicalSmart;
        Retail.Add(sd);
        sd = new SkillsDes("Business Opportunities Development", 0);
        sd.MI = skills.NatureSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("Business Performance Management", ""));
        //Retail.Add(new SkillsDes("Business Relationship Building", ""));
        sd = new SkillsDes("Business Risk Assessment", 0);
        sd.MI = skills.LogicalSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("Category Management", ""));
        //Retail.Add(new SkillsDes("Category Marketing", ""));
        //Retail.Add(new SkillsDes("Colour Concept Application", ""));
        sd = new SkillsDes("Communication", 0);
        sd.MI = skills.PeopleSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("Communications Channel Management", ""));
        sd = new SkillsDes("Compliance with Legal Regulations", 0);
        sd.MI = skills.SelfSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("Conflict Management", ""));
        //Retail.Add(new SkillsDes("Consumer Intelligence Analysis", ""));
        //Retail.Add(new SkillsDes("Corporate Governance", ""));
        //Retail.Add(new SkillsDes("Creative Thinking", ""));
        //Retail.Add(new SkillsDes("Crisis Management", ""));
        //Retail.Add(new SkillsDes("Customer Acquisition Management", ""));
        sd = new SkillsDes("Customer Behaviour Analysis", 0);
        sd.MI = skills.PeopleSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("Customer Experience Innovation", ""));
        //Retail.Add(new SkillsDes("Customer Experience Management", ""));
        //Retail.Add(new SkillsDes("Customer Loyalty and Retention Strategy Formulation", ""));
        //Retail.Add(new SkillsDes("Customer Relationship Management (CRM)", ""));
        sd = new SkillsDes("Data Analytics", 0);
        sd.MI = skills.LogicalSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("Data-Mining and Modelling", ""));
        //Retail.Add(new SkillsDes("Decision Making", ""));
        //Retail.Add(new SkillsDes("Demand Analysis", ""));
        //Retail.Add(new SkillsDes("Design Concepts Generation", ""));
        //Retail.Add(new SkillsDes("Digital Image Production", ""));
        //Retail.Add(new SkillsDes("Drive Productivity and Innovation", ""));
        //Retail.Add(new SkillsDes("E-Commerce Campaign Management", ""));
        //Retail.Add(new SkillsDes("Effective Board Member", ""));
        //Retail.Add(new SkillsDes("Events Planning and Management", ""));
        //Retail.Add(new SkillsDes("Financial Analysis", ""));
        //Retail.Add(new SkillsDes("Financial Budget Planning and Management", ""));
        //Retail.Add(new SkillsDes("Franchise Management", ""));
        //Retail.Add(new SkillsDes("Global Mindset", ""));
        //Retail.Add(new SkillsDes("House Brand Development", ""));
        //Retail.Add(new SkillsDes("Idea Generation and Selection", ""));
        sd = new SkillsDes("Infographics and Data Visualisation", 0);
        sd.MI = skills.PictureSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("Innovation Management", ""));
        sd = new SkillsDes("Intellectual Property Management", 0);
        sd.MI = skills.SelfSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("International Marketing Programmes Management", ""));
        //Retail.Add(new SkillsDes("Interpersonal Skills", ""));
        //Retail.Add(new SkillsDes("Inventory Control", ""));
        //Retail.Add(new SkillsDes("Knowledge Management", ""));
        //Retail.Add(new SkillsDes("Leadership", ""));
        //Retail.Add(new SkillsDes("Manage Change", ""));
        //Retail.Add(new SkillsDes("Managing Diversity", ""));
        //Retail.Add(new SkillsDes("Market Entry Strategy Formulation", ""));
        //Retail.Add(new SkillsDes("Market Profiling", ""));
        sd = new SkillsDes("Market Research", 0);
        sd.MI = skills.WordSmart;
        Retail.Add(sd);
        sd = new SkillsDes("Market Trend Analysis", 0);
        sd.MI = skills.LogicalSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("Marketing Campaign Management", ""));
        //Retail.Add(new SkillsDes("Merchandise Buying", ""));
        //Retail.Add(new SkillsDes("Merchandise Performance Analysis", ""));
        //Retail.Add(new SkillsDes("Organisation and Board Relationship", ""));
        //Retail.Add(new SkillsDes("Organisation Evaluation for Business Excellence", ""));
        //Retail.Add(new SkillsDes("Organisation Representative ", ""));
        //Retail.Add(new SkillsDes("Organisational Alignment and Interdependency Analysis", ""));
        //Retail.Add(new SkillsDes("Organisational Analysis", ""));
        //Retail.Add(new SkillsDes("Organisational Planning and Target Setting", ""));
        //Retail.Add(new SkillsDes("Organisational Relationship Building", ""));
        //Retail.Add(new SkillsDes("Organisational Strategy Formulation", ""));
        //Retail.Add(new SkillsDes("Organisational Vision, Mission and Values Formulation", ""));
        //Retail.Add(new SkillsDes("People and Relationship Management", ""));
        //Retail.Add(new SkillsDes("People Development", ""));
        //Retail.Add(new SkillsDes("Personal Effectiveness", ""));
        //Retail.Add(new SkillsDes("Point-Of-Purchase Marketing", ""));
        //Retail.Add(new SkillsDes("Problem Identification", ""));
        //Retail.Add(new SkillsDes("Problem Solving", ""));
        sd = new SkillsDes("Process Improvement", 0);
        sd.MI = skills.LogicalSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("Product Costing & Pricing", ""));
        //Retail.Add(new SkillsDes("Product Development", ""));
        //Retail.Add(new SkillsDes("Product Performance Management", ""));
        //Retail.Add(new SkillsDes("Product Styling", ""));
        //Retail.Add(new SkillsDes("Productivity and Innovation Strategy", ""));
        //Retail.Add(new SkillsDes("Productivity Improvement", ""));
        //Retail.Add(new SkillsDes("Project Administration", ""));
        //Retail.Add(new SkillsDes("Project After Action Review", ""));
        //Retail.Add(new SkillsDes("Project Cost", ""));
        //Retail.Add(new SkillsDes("Project Feasibility", ""));
        //Retail.Add(new SkillsDes("Project Integration", ""));
        //Retail.Add(new SkillsDes("Project Plan", ""));
        //Retail.Add(new SkillsDes("Project Quality", ""));
        //Retail.Add(new SkillsDes("Project Resources", ""));
        //Retail.Add(new SkillsDes("Project Risk", ""));
        //Retail.Add(new SkillsDes("Project Scope", ""));
        //Retail.Add(new SkillsDes("Project Timeline", ""));
        //Retail.Add(new SkillsDes("Property and Infrastructural Planning", ""));
        //Retail.Add(new SkillsDes("Public Relations Campaign Management", ""));
        //Retail.Add(new SkillsDes("Quality Assurance", ""));
        //Retail.Add(new SkillsDes("Report Writing", ""));
        //Retail.Add(new SkillsDes("Resource Management", ""));
        //Retail.Add(new SkillsDes("Retail Space Utilisation", ""));
        //Retail.Add(new SkillsDes("Sense Making", ""));
        //Retail.Add(new SkillsDes("Sentiment Analysis", ""));
        //Retail.Add(new SkillsDes("Service Brand", ""));
        //Retail.Add(new SkillsDes("Service Information and Results", ""));
        //Retail.Add(new SkillsDes("Service Innovation", ""));
        //Retail.Add(new SkillsDes("Service Innovation Culture", ""));
        //Retail.Add(new SkillsDes("Service Leadership", ""));
        //Retail.Add(new SkillsDes("Service Orientation", ""));
        //Retail.Add(new SkillsDes("Shopper Marketing Campaign Management", ""));
        //Retail.Add(new SkillsDes("Social Media Management", ""));
        //Retail.Add(new SkillsDes("Stakeholder Management", ""));
        //Retail.Add(new SkillsDes("Supplier Performance", ""));
        //Retail.Add(new SkillsDes("Supplier Sourcing ", ""));
        //Retail.Add(new SkillsDes("Supply Chain Operational Costing", ""));
        //Retail.Add(new SkillsDes("Teamwork", ""));
        //Retail.Add(new SkillsDes("Technology Strategy Formulation", ""));
        //Retail.Add(new SkillsDes("User Interface and User Experience (UI and UX) Optimisation", ""));
        //Retail.Add(new SkillsDes("Vision Leadership", ""));
        //Retail.Add(new SkillsDes("Visual Collaterals Production", ""));
        //Retail.Add(new SkillsDes("Visual Design and Communication Principles", ""));
        //Retail.Add(new SkillsDes("Visual Merchandising Presentation", ""));
        //Retail.Add(new SkillsDes("Website Design", ""));
        //Retail.Add(new SkillsDes("Website Performance Management", ""));
        //Retail.Add(new SkillsDes("Workforce Diversity and Harmony", ""));
        sd = new SkillsDes("Workplace Communications", 0);
        sd.MI = skills.PeopleSmart;
        Retail.Add(sd);
        //Retail.Add(new SkillsDes("Workplace Safety and Health", ""));



        //Media.Add(new SkillsDes("Business Negotiation", ""));
        sd = new SkillsDes("Communication", 0);
        sd.MI = skills.PeopleSmart;
        Media.Add(sd);
        sd = new SkillsDes("Concept Creation", 0);
        sd.MI = skills.PictureSmart;
        Media.Add(sd);
        //Media.Add(new SkillsDes("Content Distribution", ""));
        //Media.Add(new SkillsDes("Contract and Vendor Management", ""));
        //Media.Add(new SkillsDes("Creative Storytelling", ""));
        sd = new SkillsDes("Creative Thinking", 0);
        sd.MI = skills.PictureSmart;
        Media.Add(sd);
        //Media.Add(new SkillsDes("Crew Selection", ""));
        //Media.Add(new SkillsDes("Decision Making", ""));
        //Media.Add(new SkillsDes("Developing People", ""));
        //Media.Add(new SkillsDes("Digital Literacy", ""));
        //Media.Add(new SkillsDes("Direction", ""));
        sd = new SkillsDes("Emergency Response Management", 0);
        sd.MI = skills.NatureSmart;
        Media.Add(sd);
        sd = new SkillsDes("Fundraising and Sponsorships", 0);
        sd.MI = skills.PeopleSmart;
        Media.Add(sd);
        //Media.Add(new SkillsDes("Immersive Design", ""));
        sd = new SkillsDes("Interpersonal Skills", 0);
        sd.MI = skills.PeopleSmart;
        Media.Add(sd);
        //Media.Add(new SkillsDes("Leadership", ""));
        sd = new SkillsDes("Legal and Compliance Management", 0);
        sd.MI = skills.SelfSmart;
        Media.Add(sd);
        //Media.Add(new SkillsDes("Location Scouting", ""));
        //Media.Add(new SkillsDes("Market Evaluation", ""));
        //Media.Add(new SkillsDes("Marketing Strategy", ""));
        //Media.Add(new SkillsDes("News Bulletin Production", ""));
        //Media.Add(new SkillsDes("News Delivery and Presentation", ""));
        sd = new SkillsDes("News Editing", 0);
        sd.MI = skills.PictureSmart;
        Media.Add(sd);
        sd = new SkillsDes("News Story Development", 0);
        sd.MI = skills.PictureSmart;
        Media.Add(sd);
        //Media.Add(new SkillsDes("News Story Research", ""));
        //Media.Add(new SkillsDes("Problem Solving", ""));
        //Media.Add(new SkillsDes("Procurement for Production Operations", ""));
        sd = new SkillsDes("Production Budget Management", 0);
        sd.MI = skills.LogicalSmart;
        Media.Add(sd);
        sd = new SkillsDes("Production Operations", 0);
        sd.MI = skills.LogicalSmart;
        Media.Add(sd);
        sd = new SkillsDes("Production Planning and Scheduling", 0);
        sd.MI = skills.LogicalSmart;
        Media.Add(sd);

        //Media.Add(new SkillsDes("Research", ""));
        //Media.Add(new SkillsDes("Resource Management", ""));
        //Media.Add(new SkillsDes("Sense Making", ""));
        //Media.Add(new SkillsDes("Service Orientation", ""));
        //Media.Add(new SkillsDes("Social Media Content Creation and Management", ""));
        //Media.Add(new SkillsDes("Studio Technical Production", ""));
        sd = new SkillsDes("Talent Casting", 0);
        sd.MI = skills.PeopleSmart;
        Media.Add(sd);
        sd = new SkillsDes("Teamwork", 0);
        sd.MI = skills.PeopleSmart;
        Media.Add(sd);
        //Media.Add(new SkillsDes("Video Editing", ""));
        //Media.Add(new SkillsDes("Vision Mixing", ""));
        
    }
}
[Serializable]
public class SkillsDes
{
    public string title;
    public double Cost;

    public int MI;
    public SkillsDes(string t,int d) {
        title = t;
        Cost = d;
    }
    public string GetStringRepresentation() {
        switch (title) {
            case "Communication":
                return GetStringValue();
            case "Decision Making":
                return GetStringValue();
            case "Problem Solving":
                return GetStringValue();
            case "Computational Thinking":
                return GetStringValue();
            case "Creative Thinking":
                return GetStringValue();
            case "Sense Making":
                return GetStringValue();
            case "Interpersonal Skills":
                return GetStringValue();
            case "Teamwork":
                return GetStringValue();
            default:
                return null;
        }
    }
    private string GetStringValue() {
        if (this.Cost >= 6) return "Advance";
        else if (this.Cost >= 4) return "Intermediate";
        else if (this.Cost < 4) return "Basic";
        return null;
    }
}



[Serializable]
public class Character {

    public const int PCCount = 1;
    public const int CACount = 2;
    public const int VACount = 5;

    public List<Point> MultipleIntelligence = new List<Point>();
    public List<Point> PerformanceCharacter = new List<Point>();
    public List<string> CareerAnchor = new List<string>();
    public List<string> Values = new List<string>();

    public Character() {
        MultipleIntelligence.Add(new Point("Word-smart", 5,""));
        MultipleIntelligence.Add(new Point("Logic-smart", 5, ""));
        MultipleIntelligence.Add(new Point("Self-smart", 5, ""));
        MultipleIntelligence.Add(new Point("People-smart", 5, ""));
        MultipleIntelligence.Add(new Point("Music-smart", 5, ""));
        MultipleIntelligence.Add(new Point("Body-smart", 5, ""));
        MultipleIntelligence.Add(new Point("Picture-smart", 5, ""));
        MultipleIntelligence.Add(new Point("Nature-smart", 5, ""));

        PerformanceCharacter.Add(new Point("Curiosity", 1, "Get another Life Card every round"));
        PerformanceCharacter.Add(new Point("Gratitude", 2, "Add 1 unit of satisfaction per round"));
        PerformanceCharacter.Add(new Point("Grit", 3, "Add 2 AP per round"));
        PerformanceCharacter.Add(new Point("Optimism", 4, "Add 0.5 satisfaction per round and add 5% in salary"));
        PerformanceCharacter.Add(new Point("Self-control", 5, "Add $100 per round"));
        PerformanceCharacter.Add(new Point("Social Intelligence", 6, "Add 10% in salary"));
        PerformanceCharacter.Add(new Point("Zest", 7, "Add 1 AP per round and add 5% in salary"));
        

        CareerAnchor.Add("Technical/functional competence");
        CareerAnchor.Add("General managerial competence");
        CareerAnchor.Add("Autonomy/independence");
        CareerAnchor.Add("Job security/stability");
        CareerAnchor.Add("Entrepreneurial creativity");
        CareerAnchor.Add("Service/dedication to a cause");
        CareerAnchor.Add("Pure challenge");
        CareerAnchor.Add("Lifestyle");

        Values.Add("Spirituality");
        Values.Add("Teaching, mentoring");
        Values.Add("Understanding, helping, or serving others");
        Values.Add("Vision (anticipating future directions, seeing the big picture)");
        Values.Add("Wealth, material well-being");
        Values.Add("Power, influence");
        Values.Add("Professional accomplishment");
        Values.Add("Professional conduct");
        Values.Add("Quality (excellent, thorough, accurate, or careful work)");
        Values.Add("Recognition from one's field");
        Values.Add("Rewarding and supportive relationships (with family, friends, colleagues)");
        Values.Add("Searching for knowledge, uncovering what is true");
        Values.Add("Self-examination, self-criticism, self-understanding");
        Values.Add("Social concerns (pursuing the common good; avoiding harm, caring about future generations)");
        Values.Add("Solitude, contemplation");
        Values.Add("Broad interests");
        Values.Add("Challenge");
        Values.Add("Courage, risk-taking");
        Values.Add("Creating balance in one's life");
        Values.Add("Creativity, pioneering (originality, imaginativeness)");
        Values.Add("Curiosity");
        Values.Add("Efficient work habits");
        Values.Add("Enjoyment of the activity itself");
        Values.Add("Faith");
        Values.Add("Fame, success");
        Values.Add("Hard work and commitment");
        Values.Add("Honesty and integrity");
        Values.Add("Independence");
        Values.Add("Openness (being receptive to new ideas or multiple perspectives)");
        Values.Add("Personal growth and learning");
    }
}
[Serializable]
public class Point {
    public string Title;
    public string des;
    public double cost;
    public Point(string t, int c,string s) {
        Title = t;
        cost = c;
        des=s;
    }
}
[Serializable]
public class EduRec {
    public string edu;
    public float per;
    public EduRec() { }
    public EduRec(string e, float p) { edu = e; per = p; }
}
[Serializable]
public class Possession {
    public string Name;
    public string Category;
    public Possession() {}
    public Possession(string Name, string Category) {
        this.Name = Name;
        this.Category = Category;
    }
}

[Serializable]
public class Player {

    public bool IsPolySelected = false;

    [Serializable]
    public class Job
    {
        public string FieldName;
        public string JobTitle;
        public int Salary;
        public string pro1, pro2, con;
        public int WorkExperience = 0;
        public Job() { FieldName = ""; JobTitle = ""; }
        public void Clear() {
            FieldName = "";
            JobTitle = "";
            Salary = 0;
            pro1 = pro2 = con = "";
        }
    }

    public Job MyJob = new Job();
    public int AvgSalary = 0;

    public string token = "";

    public string Name;
    public string Email;
    public int ActionPoints;
    public int RemainingActionPoints = 50;
    public String edu;
    public String diploma;

    public List<string> Diplomas = new List<string>();
    public List<EduRec> Educations = new List<EduRec>();
    public List<EduRec> Poly = new List<EduRec>();
    public List<EduRec> Bach = new List<EduRec>();
    public List<EduRec> Mast = new List<EduRec>();
    public List<EduRec> Phd  = new List<EduRec>();

    public string CurrentQuizName;
    public float CurrentQuizPercentage;

    public int PrimaryScore = 0;
    public int SecodaryScore = 0;
    public int PolyScore = 0;
    public int JuniorScore = 0;
    public int BachlorScore = 0;
    public int MasterScore = 0;
    public int PhdScore = 0;



    public bool PrimaryClear;
    public bool SecondaryClear;
    public bool juniorClgClear;
    public bool AccountancyClear;
    public bool HealthCareClear;
    public bool HRClear;
    public bool ITClear;
    public bool RetailClear;
    public bool MediaClear;
    public bool uniClear;
    public bool BachY1Clear;
    public bool BachY2Clear;
    public bool BachY3clear;
    public bool MasterClear;
    public bool PhDClear;

    public List<Possession> ShopPossessions = new List<Possession>();

    public int Bank = 0;
    public string BankString = "0";
    public List<string> Possession = new List<string>();
    public List<EduRec> LifeCardSkills = new List<EduRec>();
    public float SatisfactionLevel = 5.0f;
    public bool BachelorsDone = false;
    public bool MastersDone = false;
    public bool PhdDone = false;

    public string Course;
    public List<Point> MultipleIntelligence = new List<Point>();
    public List<Point> PerformanceCharacter = new List<Point>();
    public List<string> CareerAnchor = new List<string>();
    public List<string> Values = new List<string>();
    public List<string> Education = new List<string>(); // dont use it. also dont delete it.

    public skills Skills = new skills();
    public List<SkillsDes> MyValues = new List<SkillsDes>();

    public Player(string N, string E) {

        

        Name = N;
        Email = E;
        edu = "Null";
        ActionPoints = 40;
        RemainingActionPoints = 10;
        Course = "";
        diploma = "";
        PrimaryClear = false;
        SecondaryClear = false;
        juniorClgClear = false;
        AccountancyClear = false;
        HealthCareClear = true;
        HRClear = true;
        ITClear = true;
        RetailClear = true;
        MediaClear = true;
        uniClear = false;
        BachY1Clear = false;
        BachY2Clear = false;
        BachY3clear = false;
        MasterClear = false;
        PhDClear = false;

        UpdateMyValues();


    }
    public void UpdateSkillsValueEqually()
    {
        double a = Skills.Accountacy[2].Cost;
        if (a > Skills.HealtCare[0].Cost)
        {
            Skills.HealtCare[0].Cost = a;
        }
        a = Skills.HealtCare[0].Cost;
        if (a > Skills.Accountacy[2].Cost)
        {
            Skills.Accountacy[2].Cost = a;
        }

        a = Skills.Accountacy[3].Cost;
        if (a > Skills.HR[1].Cost)
        {
            Skills.HR[1].Cost = a;
        }
        if (a > Skills.IT[2].Cost)
        {
            Skills.IT[2].Cost = a;
        }
        if (a > Skills.Media[0].Cost)
        {
            Skills.Media[0].Cost = a;
        }
        if (a > Skills.Retail[4].Cost)
        {
            Skills.Retail[4].Cost = a;
        }
        ////////////
        //a = Skills.HR[1].Cost;
        //if (a > Skills.Accountacy[3].Cost)
        //{
        //    Skills.Accountacy[3].Cost = a;
        //}
        //a = Skills.IT[2].Cost;
        //if (a > Skills.Accountacy[3].Cost)
        //{
        //    Skills.Accountacy[3].Cost = a;
        //}
        //a = Skills.Media[0].Cost;
        //if (a > Skills.Accountacy[3].Cost)
        //{
        //    Skills.Accountacy[3].Cost = a;
        //}
        //a = Skills.Retail[4].Cost;
        //if (a > Skills.Accountacy[3].Cost)
        //{
        //    Skills.Accountacy[3].Cost = a;
        //}

        a = Skills.HR[1].Cost;
        if (a > Skills.Accountacy[3].Cost)
        {
            Skills.Accountacy[3].Cost = a;
        }
        if (a > Skills.IT[2].Cost)
        {
            Skills.IT[2].Cost = a;
        }
        if (a > Skills.Media[0].Cost)
        {
            Skills.Media[0].Cost = a;
        }
        if (a > Skills.Retail[4].Cost)
        {
            Skills.Retail[4].Cost = a;
        }
        ///

        a = Skills.IT[2].Cost;
        if (a > Skills.HR[1].Cost)
        {
            Skills.HR[1].Cost = a;
        }
        if (a > Skills.Accountacy[3].Cost)
        {
            Skills.Accountacy[3].Cost = a;
        }
        if (a > Skills.Media[0].Cost)
        {
            Skills.Media[0].Cost = a;
        }
        if (a > Skills.Retail[4].Cost)
        {
            Skills.Retail[4].Cost = a;
        }
        ///
        a = Skills.Media[0].Cost;
        if (a > Skills.HR[1].Cost)
        {
            Skills.HR[1].Cost = a;
        }
        if (a > Skills.IT[2].Cost)
        {
            Skills.IT[2].Cost = a;
        }
        if (a > Skills.Accountacy[3].Cost)
        {
            Skills.Accountacy[3].Cost = a;
        }
        if (a > Skills.Retail[4].Cost)
        {
            Skills.Retail[4].Cost = a;
        }
        ///
        a = Skills.Retail[4].Cost;
        if (a > Skills.HR[1].Cost)
        {
            Skills.HR[1].Cost = a;
        }
        if (a > Skills.IT[2].Cost)
        {
            Skills.IT[2].Cost = a;
        }
        if (a > Skills.Media[0].Cost)
        {
            Skills.Media[0].Cost = a;
        }
        if (a > Skills.Accountacy[3].Cost)
        {
            Skills.Accountacy[3].Cost = a;
        }

        /////////////////////////////

        a = Skills.Accountacy[5].Cost;
        if (a > Skills.Retail[7].Cost)
        {
            Skills.Retail[7].Cost = a;
        }
        a = Skills.Retail[7].Cost;
        if (a > Skills.Accountacy[5].Cost)
        {
            Skills.Accountacy[5].Cost = a;
        }

        a = Skills.Accountacy[6].Cost;
        if (a > Skills.HealtCare[2].Cost)
        {
            Skills.HealtCare[2].Cost = a;
        }
        a = Skills.HealtCare[2].Cost;
        if (a > Skills.Accountacy[6].Cost)
        {
            Skills.Accountacy[6].Cost = a;
        }

        a = Skills.HealtCare[7].Cost;
        if (a > Skills.HR[10].Cost)
        {
            Skills.HR[10].Cost = a;
        }
        a = Skills.HR[10].Cost;
        if (a > Skills.HealtCare[7].Cost)
        {
            Skills.HealtCare[7].Cost = a;
        }

        a = Skills.HealtCare[10].Cost;
        if (a > Skills.HR[11].Cost)
        {
            Skills.HR[11].Cost = a;
        }
        a = Skills.HR[11].Cost;
        if (a > Skills.HealtCare[10].Cost)
        {
            Skills.HealtCare[10].Cost = a;
        }

        a = Skills.IT[4].Cost;
        if (a > Skills.Media[2].Cost)
        {
            Skills.Media[2].Cost = a;
        }
        a = Skills.Media[2].Cost;
        if (a > Skills.IT[4].Cost)
        {
            Skills.IT[4].Cost = a;
        }
    }
    public List<SkillsDes> GetMySkills() {
        UpdateMyValues();
        return (MyValues);
    }

    public void UpdateMyValues() {
        MyValues.Clear();
        for (int i = 0; i < Skills.Accountacy.Count; i++) {
            MyValues.Add(Skills.Accountacy[i]);
        }
        for (int i = 0; i < Skills.HealtCare.Count; i++) {
            if (!HaveValues(Skills.HealtCare[i])) {
                MyValues.Add(Skills.HealtCare[i]);
            } else {
                //Debug.Log("repeated");
            }
        }
        for (int i = 0; i < Skills.HR.Count; i++) {
            if (!HaveValues(Skills.HR[i])) {
                MyValues.Add(Skills.HR[i]);
            } else {
                //Debug.Log("repeated");
            }
        }
        for (int i = 0; i < Skills.IT.Count; i++) {
            if (!HaveValues(Skills.IT[i])) {
                MyValues.Add(Skills.IT[i]);
            } else {
                //Debug.Log("repeated");
            }
        }
        for (int i = 0; i < Skills.Media.Count; i++) {
            if (!HaveValues(Skills.Media[i])) {
                MyValues.Add(Skills.Media[i]);
            } else {
                //Debug.Log("repeated");
            }
        }
        for (int i = 0; i < Skills.Retail.Count; i++) {
            if (!HaveValues(Skills.Retail[i])) {
                MyValues.Add(Skills.Retail[i]);
            } else {
                //Debug.Log("repeated");
            }
        }
    }
    public string GetCommaSeparatedAmount(int amount)
    {
        string rslt = "";
        string str = amount.ToString();
        string str2 = "";
        int count = 0;
        bool checkoo = false;
        //Debug.Log("LENGTH OF BANK ACCOUNT DIGITS: " + str.Length);
        for (int i = 0; i < str.Length; i++) {

            if ((count + 1) % 7 == 0) {
                str2 += ",";
                //Debug.Log("helpppp");
            }

            str2 += str[str.Length - 1 - i];
            count++;
            if (count % 3 == 0 && checkoo == false && str.Length > 3) {
                str2 += ",";
                checkoo = true;
            }

        }
        rslt = "";
            for (int i = 0; i < str2.Length; i++) {
                rslt += str2[str2.Length - 1 - i];
            }
        return (rslt);
    }
    bool HaveValues(SkillsDes sd) {
        foreach (SkillsDes skillsDes in MyValues) {
            if (sd.title == skillsDes.title) {
                return true;
            }
        }
        return false;
    }
    public bool UpdateSatisfaction() {
        return (UpdateSatisfaction2());
    }
    public bool UpdateSatisfaction2()
    {
        List<string> valuesData = new List<string>();
        List<string> CareerAnchorData = new List<string>();
        string[] Val0 = Values[0].Split(new char[5] { ' ', '(', ')', ',', ';' }, System.StringSplitOptions.RemoveEmptyEntries);
        string[] Val1 = Values[1].Split(new char[5] { ' ', '(', ')', ',', ';' }, System.StringSplitOptions.RemoveEmptyEntries);
        string[] Val2 = Values[2].Split(new char[5] { ' ', '(', ')', ',', ';' }, System.StringSplitOptions.RemoveEmptyEntries);
        string[] Val3 = Values[3].Split(new char[5] { ' ', '(', ')', ',', ';' }, System.StringSplitOptions.RemoveEmptyEntries);
        string[] Val4 = Values[4].Split(new char[5] { ' ', '(', ')', ',', ';' }, System.StringSplitOptions.RemoveEmptyEntries);
        
        string[] CA0 = CareerAnchor[0].Split(new char[5] { ' ', '(', ')', ',', ';' }, System.StringSplitOptions.RemoveEmptyEntries);
        string[] CA1 = CareerAnchor[1].Split(new char[5] { ' ', '(', ')', ',', ';' }, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < CA0.Length; i++) {
            bool flag = false;
            foreach(string str in CareerAnchorData)
            {
                if (str == CA0[i])
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                CareerAnchorData.Add(CA0[i]);
            }
        }
        for (int i = 0; i < CA1.Length; i++) {
            bool flag = false;
            foreach (string str in CareerAnchorData)
            {
                if (str == CA1[i])
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                CareerAnchorData.Add(CA1[i]);
            }
        }
        for (int i = 0; i < Val0.Length; i++) {
            bool flag = false;
            foreach (string str in valuesData)
            {
                if (str == Val0[i])
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                valuesData.Add(Val0[i]);
            }
        }
        for (int i = 0; i < Val1.Length; i++) {
            bool flag = false;
            foreach (string str in valuesData)
            {
                if (str == Val1[i])
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                valuesData.Add(Val1[i]);
            }
        }
        for (int i = 0; i < Val2.Length; i++) {
            bool flag = false;
            foreach (string str in valuesData)
            {
                if (str == Val2[i])
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                valuesData.Add(Val2[i]);
            }
        }
        for (int i = 0; i < Val3.Length; i++) {
            bool flag = false;
            foreach (string str in valuesData)
            {
                if (str == Val3[i])
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                valuesData.Add(Val3[i]);
            }
        }
        for (int i = 0; i < Val4.Length; i++) {
            bool flag = false;
            foreach (string str in valuesData)
            {
                if (str == Val4[i])
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                valuesData.Add(Val4[i]);
            }
        }
        if (GameObject.FindObjectOfType<AppData>().MyFinalJob.JobTitle != "") {

            Job job = GameObject.FindObjectOfType<AppData>().MyFinalJob;

            int[] PositivevaluesArray = new int[valuesData.Count];
            int[] PositiveCareerAnchorsArray = new int[CareerAnchorData.Count];
            int[] NegativeValuesArray = new int[valuesData.Count];
            int[] NegativeCareerAnchorsArray = new int[CareerAnchorData.Count];

            string[] pro1StrsData = job.pro1.Split(new char[6] { ' ', '(', ')', ';', ' ', ':' }, System.StringSplitOptions.RemoveEmptyEntries);
            string[] pro2StrsData = job.pro2.Split(new char[6] { ' ', '(', ')', ';', ' ', ':' }, System.StringSplitOptions.RemoveEmptyEntries);
            string[] cons1StrsData = job.con.Split(new char[6] { ' ', '(', ')', ';', ' ', ':' }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < valuesData.Count; i++)
            {
                for (int j = 0; j < pro1StrsData.Length; j++)
                {
                    if (valuesData[i] == pro1StrsData[j])
                    {
                        //Debug.Log("p1 found");
                        PositivevaluesArray[i] += 1;
                        break;
                    }
                }
                for (int j = 0; j < pro2StrsData.Length; j++)
                {
                    if (valuesData[i] == pro2StrsData[j])
                    {
                        //Debug.Log("p2 found");
                        if (PositivevaluesArray[i] != 1)
                            PositivevaluesArray[i] += 1;
                        break;
                    }
                }
                for (int j = 0; j < cons1StrsData.Length; j++)
                {
                    if (valuesData[i] == cons1StrsData[j])
                    {
                        //Debug.Log("c found");
                        NegativeValuesArray[i] += 1;
                        break;
                    }
                }
            }
            for (int i = 0; i < CareerAnchorData.Count; i++)
            {
                for (int j = 0; j < pro1StrsData.Length; j++)
                {
                    if (CareerAnchorData[i] == pro1StrsData[j])
                    {
                        //Debug.Log("ca1 found");
                        PositiveCareerAnchorsArray[i] += 1;
                        break;
                    }
                }
                for (int j = 0; j < pro2StrsData.Length; j++)
                {
                    if (CareerAnchorData[i] == pro2StrsData[j])
                    {
                        //Debug.Log("ca2 found");
                        if (PositiveCareerAnchorsArray[i] != 1)
                            PositiveCareerAnchorsArray[i] += 1;
                        break;
                    }
                }
                for (int j = 0; j < cons1StrsData.Length; j++)
                {
                    if (CareerAnchorData[i] == cons1StrsData[j])
                    {
                        //Debug.Log("ca c found");
                        NegativeCareerAnchorsArray[i] += 1;
                        break;
                    }
                }
            }
            int SatisfactionTotal = 0;
            int plus = 0;
            int minus = 0;
            for (int i = 0; i < PositivevaluesArray.Length; i++)
            {
                plus += PositivevaluesArray[i];
            }
            for (int i = 0; i < NegativeValuesArray.Length; i++)
            {
                minus += NegativeValuesArray[i];
            }
            for (int i = 0; i < PositiveCareerAnchorsArray.Length; i++)
            {
                plus += PositiveCareerAnchorsArray[i];
            }
            for (int i = 0; i < NegativeCareerAnchorsArray.Length; i++)
            {
                minus += NegativeCareerAnchorsArray[i];
            }

            SatisfactionTotal = plus - minus;
            
            Debug.Log(SatisfactionTotal + " : " + plus + " - " + minus);

            if (SatisfactionLevel + SatisfactionTotal < 0)
            {
                SatisfactionLevel = 0.0f;
            }
            else if (SatisfactionLevel + SatisfactionTotal > 10)
            {
                SatisfactionLevel = 10f;
            }
            else
            {
                this.SatisfactionLevel += SatisfactionTotal;
            }

            /*
            int pro1Count = 0;
            int pro2Count = 0;
            int consCount = 0;
            string[] pro1Strs = MyJob.pro1.Split(new char[6] { ' ', '(', ')', ';', ' ', ':' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < pro1Strs.Length; i++) {
                for (int j = 0; j < valuesData.Count; j++) {
                    if (pro1Strs[i] == valuesData[j]) {
                        pro1Count++;
                    }
                }
            }
            string[] pro2Strs = MyJob.pro2.Split(new char[1] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < pro2Strs.Length; i++) {
                for (int j = 0; j < valuesData.Count; j++) {
                    if (pro2Strs[i] == valuesData[j]) {
                        pro2Count++;
                    }
                }
            }
            string[] cons1Strs = MyJob.con.Split(new char[1] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < cons1Strs.Length; i++) {
                for (int j = 0; j < valuesData.Count; j++) {
                    if (cons1Strs[i] == valuesData[j]) {
                        consCount++;
                    }
                }
            }
            Debug.Log("Pro1: " + pro1Count + " Pro2: " + pro2Count + " == Con: " + consCount);

            float plus = 0;
            float minus = 0;

            if (pro1Count > 0 || pro2Count > 0) plus++;
            //if (pro2Count > 0) plus++;
            if (consCount > 0) minus++;

            //float satisfaction = ((pro1Count * 0.5f) + (pro2Count * 0.5f) - consCount);
            float satisfaction = plus + minus;
            Debug.Log(satisfaction);
            if (SatisfactionLevel + satisfaction < 0) {
                SatisfactionLevel = 0.0f;
            } else if (SatisfactionLevel + satisfaction > 10) {
                SatisfactionLevel = 10f;
            } else {
                this.SatisfactionLevel += satisfaction;
            }
            */
            return true;
        }
        return false;
    }
}
[Serializable]
public class TestDet {
    public string Question;
    public string[] Option;
    public int AnswerIndex;
    public TestDet(string q, string[] op, int AnsIndex) {
        Question = q;
        Option = op;
        AnswerIndex = AnsIndex;
    }
}

[Serializable]
public class Quiz
{
    public List<TestDet> sawaal = new List<TestDet>();
    public int Threshold = 0;
    public int myScore = 0;

    public void LoadQuiz() {
    }

    public Quiz() {

        //    List<String> op = new List<string>();
        //    op.Add("1");
        //    op.Add("3");
        //    op.Add("2");
        //    op.Add("5");
        //    sawaal.Add(new TestDet("What is 1+1 ?", op, 2));

        //    op = new List<string>();
        //    op.Add("1");
        //    op.Add("3");
        //    op.Add("10");
        //    op.Add("5");
        //    sawaal.Add(new TestDet("What is 5+5 ?", op, 2));

        //    op = new List<string>();
        //    op.Add("1");
        //    op.Add("3");
        //    op.Add("20");
        //    op.Add("5");
        //    sawaal.Add(new TestDet("What is 10+10 ?", op, 2));

        //    op = new List<string>();
        //    op.Add("1");
        //    op.Add("3");
        //    op.Add("30");
        //    op.Add("5");
        //    sawaal.Add(new TestDet("What is 10+20 ?", op, 2));
    }
}



[Serializable]
public class Company
{
    public String industry;
    public String CompanyName;
    public String pos1;
    public string pos2;
    public string neg;

    // ahsan's editing in constructor:....
    public Company(string ind, string cn, string p1, string p2, string n) {
        industry = ind;
        CompanyName = cn;
        pos1 = p1;
        pos2 = p2;
        neg = n;
    }

}
public class Industries
{
    public int JobLimit = 20;

    public int AccountancyJobs = 0;
    public int HCJobs = 0;
    public int HRJobs = 0;
    public int ITJobs = 0;
    public int RetailJobs = 0;
    public int MediaJobs = 0;

    public List<Company> Accountancy = new List<Company>();
    public List<Company> Healthcare = new List<Company>();
    public List<Company> HR = new List<Company>();
    public List<Company> IT = new List<Company>();
    public List<Company> Retail = new List<Company>();
    public List<Company> Media = new List<Company>();

    public Industries() {
        Accountancy.Add(new Company(AppData.Fields.Accountancy, "Ledger Solutions", " <b>  Creativity, pioneering (originality, imaginativeness):  </b>\n  You're able to express your originality and creativity in this job.", " <b>  Searching for knowledge, uncovering what is true: </b>\n  You will be able to search for knowledge and uncover truths in this job.", " <b>  Pure challenge: </b>\n  This job poses absolutely no challenge to you and you will be bored."));
        Accountancy.Add(new Company(AppData.Fields.Accountancy, "Banking Kings", " <b>  Courage, risk-taking:  </b>\n  You are able to show courage and take calculated risks in this job.", " <b>  Social concerns (pursuing the common good; avoiding harm, caring about future generations): </b>\n  This company is actively involved in social causes like human trafficking, environmental protection, and eradicating poverty.", " <b> Vision (anticipating future directions, seeing the big picture): </b>\n  Everyone here is only focused on the present, with no regard for the future of the company."));
        Accountancy.Add(new Company(AppData.Fields.Accountancy, "Coloxo", " <b>  Technical/functional competence:  </b>\n  This job allows you to be excellent at your job and do it better than almost anyone else.", " <b> Honesty and integrity: </b>\n  Your colleagues act honestly and with integrity.", " <b> Independence: </b>\n  You are discouraged from working independently in this job."));
        Accountancy.Add(new Company(AppData.Fields.Accountancy, "Black Gorge", " <b>  Technical/functional competence:  </b>\n  This job allows you to be excellent at your job and do it better than almost anyone else.", " <b> Understanding, helping, or serving others: </b>\n  Everyone in your team tries their best to understand, help and serve others.", " <b> Social concerns (pursuing the common good; avoiding harm, caring about future generations): </b>\n  This company engages in practices which are damaging to the environment and society."));
        Accountancy.Add(new Company(AppData.Fields.Accountancy, "Enver Douglass and Partners", " <b>  Lifestyle:  </b>\n  This company encourages its employees to live their lives fully. You are even able to take long periods off work to pursue your passions.", " <b> Service/dedication to a cause: </b>\n  This company has an inspiring mission and is actively engaged in social causes.", " <b> Solitude, contemplation: </b>\n  You cannot find time to be alone for reflection."));
        Accountancy.Add(new Company(AppData.Fields.Accountancy, "Frauk & Smail", " <b>  Job security/stability:  </b>\n  Most people who work in this company are 'lifers' - people who are happy working in this company for life.", " <b> Creating balance in one's life: </b>\n  You have a personally optimal blend of personal and work pursuits in this job. ", " <b> Power, influence: </b>\n  This role does not give you any power and influence in society."));
        Accountancy.Add(new Company(AppData.Fields.Accountancy, "Taxary", " <b>  Personal growth and learning:  </b>\n  You are always learning and growing in this job.", " <b>  Social concerns (pursuing the common good; avoiding harm, caring about future generations): </b>\n  This company is actively involved in social causes like human trafficking, environmental protection, and eradicating poverty.", " <b> Wealth, material well-being: </b>\n  This company pays less than the rest of the industry."));
        Accountancy.Add(new Company(AppData.Fields.Accountancy, "Investment Stack", " <b>  Spirituality:  </b>\n  Your company sees value in spirituality.", " <b>  Teaching, mentoring: </b> Your boss is an incredible mentor.", " <b> Self-examination, self-criticism, self-understanding: </b>\n  You will not know yourself better through this job."));
        Accountancy.Add(new Company(AppData.Fields.Accountancy, "Eflation", " <b>  Efficient work habits:  </b>\n  You are able to have efficient work habits in this job.", " <b> Creativity, pioneering (originality, imaginativeness): </b>\n  You're able to express your originality and creativity in this job.", " <b> Courage, risk-taking: </b>\n  You are made to feel timid and restricted from taking risks in this job."));
        Accountancy.Add(new Company(AppData.Fields.Accountancy, "Accoustic", " <b>  Social concerns (pursuing the common good; avoiding harm, caring about future generations):  </b>\n  This company is actively involved in social causes like human trafficking, environmental protection, and eradicating poverty.", " <b> Searching for knowledge, uncovering what is true: </b>\n  You will be able to search for knowledge and uncover truths in this job.", " <b> Professional conduct: </b>\n  Your colleagues are unprofessional at work."));

        Healthcare.Add(new Company("Healthcare", "Grace Clinic", " <b>  Creating balance in one's life:  </b>\n  You have a personally optimal blend of personal and work pursuits in this job.", " <b> Searching for knowledge, uncovering what is true: </b>\n  You will be able to search for knowledge and uncover truths in this job.", " <b> Fame, success: </b>\n  You will not be famous because of this job."));
        Healthcare.Add(new Company("Healthcare", "Brightside Medical", " <b>  Openness (being receptive to new ideas or multiple perspectives): </b>\n  Your teammates are open and always receptive to new ideas or multiple perspectives.", " <b> Teaching, mentoring:  </b>\n Your boss is an incredible mentor.", " <b> Solitude, contemplation:  </b>\n You cannot find time to be alone for reflection."));
        Healthcare.Add(new Company("Healthcare", "Paradise Grove Hospital", " <b>  Faith:  </b>\n  Your company sees value in having faith.", " <b> Job security/stability:  </b>\n Most people who work in this company are 'lifers' - people who are happy working in this company for life.", " <b> Power, influence:  </b>\n This role does not give you any power and influence in society."));
        Healthcare.Add(new Company("Healthcare", "Bayhealth Community Hospital", " <b>  Efficient work habits:  </b>\n You are able to have efficient work habits in this job.", " <b> Searching for knowledge, uncovering what is true:  </b>\n You will be able to search for knowledge and uncover truths in this job.", " <b> Teaching, mentoring:  </b>\n Your boss does not teach or mentor you."));
        Healthcare.Add(new Company("Healthcare", "Summit Physical Therapy", " <b>  Pure challenge:  </b>\n This job is never boring and each day brings a new and exciting challenge.", " <b> Searching for knowledge, uncovering what is true:  </b>\n You will be able to search for knowledge and uncover truths in this job.", " <b> Recognition from one's field:  </b>\n You are not recognized in your field."));
        Healthcare.Add(new Company("Healthcare", "Paramount Hospital", " <b> Faith:  </b>\n  Your company sees value in having faith.", " <b> Courage, risk-taking:  </b>\n You are able to show courage and take calculated risks in this job.", " <b> Challenge:  </b>\n This job poses absolutely no challenge to you and you will be bored."));
        Healthcare.Add(new Company("Healthcare", "Physio Pro", " <b> Efficient work habits:  </b>\n You are able to have efficient work habits in this job.", " <b> Lifestyle:  </b>\n This company encourages its employees to live their lives fully. You are even able to take long periods off work to pursue your passions.", " <b> Creativity, pioneering (originality, imaginativeness):  </b>\n This company stifles your creativity and discourages originality."));
        Healthcare.Add(new Company("Healthcare", "Exotherapy", " <b> Pure challenge:  </b>\n This job is never boring and each day brings a new and exciting challenge.", " <b> Rewarding and supportive relationships (with family, friends, colleagues):  </b>\n You have rewarding and supportive relationships with your friends, family and colleagues.", " <b> Professional conduct:  </b>\n Your colleagues are unprofessional at work."));
        Healthcare.Add(new Company("Healthcare", "Spring Fountain General Hospital", " <b> Curiosity:  </b>\n You're able to satisfy your curiosity in this job.", " <b> Lifestyle:  </b>\n This company encourages its employees to live their lives fully. You are even able to take long periods off work to pursue your passions.", " <b> Teaching, mentoring:  </b>\n Your boss does not teach or mentor you."));
        Healthcare.Add(new Company("Healthcare", "Angelstone Medical Clinic", " <b> Broad interests:  </b>\n You are able to pursue broad interests while in this job.", " <b> Understanding, helping, or serving others:  </b>\n Everyone in your team tries their best to understand, help and serve others.", " <b> Faith:  </b>\n Your company discourages having faith."));

        HR.Add(new Company(AppData.Fields.HumanResource, "Cointistics", " <b> Enjoyment of the activity itself:  </b>\n You will love what you do day-to-day.", " <b> Faith:  </b>\n Your company sees value in having faith.", " <b> Technical/functional competence:  </b>\n You'll only be alright at your job and will perform slightly poorer than others."));
        HR.Add(new Company(AppData.Fields.HumanResource, "Herofruit Campaigns", " <b> Autonomy/independence:  </b>\n Your boss gives you lots of autonomy. You  will be able to act under your own rules and have no interference or standards.", " <b> Quality (excellent, thorough, accurate, or careful work):  </b>\n You are able to deliver quality work.", " <b> Entrepreneurial creativity:  </b>\n This job does not allow you to be creative. "));
        HR.Add(new Company(AppData.Fields.HumanResource, "Drunkjar", " <b> Professional accomplishment:   </b>\n You will feel a sense of professional accomplishment in this job.", " <b> Power, influence:   </b>\n You will be able to impress people with your power and influence role in society.", " <b> Teaching, mentoring:   </b>\n Your boss does not teach or mentor you."));
        HR.Add(new Company(AppData.Fields.HumanResource, "Urbiac Foundation", " <b> Wealth, material well-being:  </b>\n This company pays more than the rest of the industry.", " <b> Efficient work habits:  </b>\n You are able to have efficient work habits in this job.", " <b> Hard work and commitment:  </b>\n Your hard work and commitment are not valued by this company."));
        HR.Add(new Company(AppData.Fields.HumanResource, "Funny.ly", " <b> Challenge:  </b>\n This job is never boring and each day brings a new and exciting challenge.", " <b> General managerial competence:  </b>\n You will be able to take a position of responsibility to tackle high-level problems, as well as manage and develop others.", " <b> Pure challenge:  </b>\n This job poses absolutely no challenge to you and you will be bored."));
        HR.Add(new Company(AppData.Fields.HumanResource, "Maze Microsystems", " <b> Understanding, helping, or serving others:  </b>\n Everyone in your team tries their best to understand, help and serve others.", " <b> Creativity, pioneering (originality, imaginativeness):  </b>\n You're able to express your originality and creativity in this job.", " <b> Independence:  </b>\n You are discouraged from working independently in this job."));
        HR.Add(new Company(AppData.Fields.HumanResource, "Thrillsy", " <b> Openness (being receptive to new ideas or multiple perspectives):  </b>\n Your teammates are open and always receptive to new ideas or multiple perspectives.", " <b> Wealth, material well-being:  </b>\n This company pays more than the rest of the industry.", " <b> Entrepreneurial creativity:  </b>\n This job does not allow you to be creative. "));
        HR.Add(new Company(AppData.Fields.HumanResource, "Econamic", " <b> Lifestyle:  </b>\n This company encourages its employees to live their lives fully. You are even able to take long periods off work to pursue your passions.", " <b> Searching for knowledge, uncovering what is true:  </b>\n You will be able to search for knowledge and uncover truths in this job.", " <b> Vision (anticipating future directions, seeing the big picture):  </b>\n Everyone here is only focused on the present, with no regard for the future of the company."));
        HR.Add(new Company(AppData.Fields.HumanResource, "Cism Intelligence", " <b> Social concerns (pursuing the common good; avoiding harm, caring about future generations):  </b>\n This company is actively involved in social causes like human trafficking, environmental protection, and eradicating poverty.", " <b> Technical/functional competence:  </b>\n This job allows you to be excellent at your job and do it better than almost anyone else.", " <b> Fame, success:  </b>\n You will not be famous because of this job."));
        HR.Add(new Company(AppData.Fields.HumanResource, "Security Wheel", " <b> General managerial competence:  </b>\n You will be able to take a position of responsibility to tackle high-level problems, as well as manage and develop others.", " <b> Power, influence:  </b>\n You will be able to impress people with your power and influence role in society.", " <b> Service/dedication to a cause:  </b>\n This company does not care about its social impact."));

        IT.Add(new Company("Information Technology", "Imagine Systems", " <b> Fame, success:  </b>\n You will be famous and successful because of this job.", " <b> Quality (excellent, thorough, accurate, or careful work):  </b>\n You are able to deliver quality work.", " <b> Professional accomplishment:  </b>\n You do not have a sense of professional accomplishment in this job."));
        IT.Add(new Company("Information Technology", "Techvology", " <b> Challenge:  </b>\n This job is never boring and each day brings a new and exciting challenge.", " <b> Spirituality:  </b>\n Your company sees value in spirituality.", " <b> Understanding, helping, or serving others:  </b>\n No one in your team tries to understand, help or serve others."));
        IT.Add(new Company("Information Technology", "Monobotics", " <b> Faith:  </b>\n Your company sees value in having faith.", " <b> Broad interests:  </b>\n You are able to pursue broad interests while in this job.", " <b> Creativity, pioneering (originality, imaginativeness):  </b>\n This company stifles your creativity and discourages originality."));
        IT.Add(new Company("Information Technology", "Proton Solutions", " <b> Quality (excellent, thorough, accurate, or careful work):  </b>\n You are able to deliver quality work.", " <b> Service/dedication to a cause:  </b>\n This company has an inspiring mission and is actively engaged in social causes.", " <b> Challenge:  </b>\n This job poses absolutely no challenge to you and you will be bored."));
        IT.Add(new Company("Information Technology", "Cog City", " <b> Wealth, material well-being:  </b>\n This company pays more than the rest of the industry.", " <b> Recognition from one's field:  </b>\n You are recognized in your field.", " <b> Challenge:  </b>\n This job poses absolutely no challenge to you and you will be bored."));
        IT.Add(new Company("Information Technology", "Electronic.ly", " <b> Efficient work habits:  </b>\n You are able to have efficient work habits in this job.", " <b> Creating balance in one's life:  </b>\n You have a personally optimal blend of personal and work pursuits in this job. ", " <b> Hard work and commitment:  </b>\n Your hard work and commitment are not valued by this company."));
        IT.Add(new Company("Information Technology", "Digitori", " <b> Solitude, contemplation:  </b>\n You are able to be alone for reflection.", " <b> Broad interests:  </b>\n You are able to pursue broad interests while in this job.", " <b> Courage, risk-taking:  </b>\n You are made to feel timid and restricted from taking risks in this job."));
        IT.Add(new Company("Information Technology", "Redhotdigital", " <b> Independence:  </b>\n You are able to work independently in this job.", " <b> Searching for knowledge, uncovering what is true:  </b>\n You will be able to search for knowledge and uncover truths in this job.", " <b> Vision (anticipating future directions, seeing the big picture):  </b>\n Everyone here is only focused on the present, with no regard for the future of the company."));
        IT.Add(new Company("Information Technology", "Pixelair", " <b> Teaching, mentoring:  </b>\n Your boss is an incredible mentor.", " <b> Professional conduct:  </b>\n Your colleagues act professionally at work.", " <b> Service/dedication to a cause:  </b>\n This company does not care about its social impact."));
        IT.Add(new Company("Information Technology", "Zoondo Technologies", " <b> Quality (excellent, thorough, accurate, or careful work):  </b>\n You are able to deliver quality work.", " <b> Searching for knowledge, uncovering what is true:  </b>\n You will be able to search for knowledge and uncover truths in this job.", " <b> Challenge:  </b>\n This job poses absolutely no challenge to you and you will be bored."));

        Media.Add(new Company("Media", "Hotvoice", " <b> Technical/functional competence:  </b>\n This job allows you to be excellent at your job and do it better than almost anyone else.", " <b> Courage, risk-taking:  </b>\n You are able to show courage and take calculated risks in this job.", " <b> Curiosity:  </b>\n This job does not satisfy your curiosity."));
        Media.Add(new Company("Media", "Mediaswire", " <b> Creativity, pioneering (originality, imaginativeness):  </b>\n You're able to express your originality and creativity in this job.", " <b> Professional conduct:  </b>\n Your colleagues act professionally at work.", " <b> Creating balance in one's life:  </b>\n You're unable to balance your personal pursuits and concerns in this job."));
        Media.Add(new Company("Media", "FilmHype", " <b> Independence:  </b>\n You are able to work independently in this job.", " <b> Entrepreneurial creativity:  </b>\n This job allows you to take ownership of your job, be creative, and brainstorm to implement new ideas. ", " <b> Wealth, material well-being:  </b>\n This company pays less than the rest of the industry."));
        Media.Add(new Company("Media", "Tasty", " <b> Pure challenge:  </b>\n This job is never boring and each day brings a new and exciting challenge.", " <b> Quality (excellent, thorough, accurate, or careful work): You are able to deliver quality work.", " <b> Personal growth and learning:  </b>\n You do not learn or grow in this job."));
        Media.Add(new Company("Media", "Produxio", " <b> Personal growth and learning:  </b>\n You are always learning and growing in this job.", " <b> Professional conduct:  </b>\n Your colleagues act professionally at work.", " <b> Enjoyment of the activity itself:  </b>\n You will dislike what you do day-to-day."));
        Media.Add(new Company("Media", "White Wolf Productions", " <b> Openness (being receptive to new ideas or multiple perspectives):  </b>\n Your teammates are open and always receptive to new ideas or multiple perspectives.", " <b> Creativity, pioneering (originality, imaginativeness):  </b>\n You're able to express your originality and creativity in this job.", " <b> Pure challenge:  </b>\n This job poses absolutely no challenge to you and you will be bored."));
        Media.Add(new Company("Media", "Revelation Network", " <b> Quality (excellent, thorough, accurate, or careful work):  </b>\n You are able to deliver quality work.", " <b> Entrepreneurial creativity:  </b>\n This job allows you to take ownership of your job, be creative, and brainstorm to implement new ideas. ", " <b> Efficient work habits:  </b>\n You have inefficient work habits in this job."));
        Media.Add(new Company("Media", "Journalistic", " <b> Solitude, contemplation:  </b>\n You are able to be alone for reflection.", " <b> Self-examination, self-criticism, self-understanding:  </b>\n You will know yourself better through this job.", " <b> Courage, risk-taking:  </b>\n You are made to feel timid and restricted from taking risks in this job."));
        Media.Add(new Company("Media", "Signalbite", " <b> Job security/stability:  </b>\n Most people who work in this company are 'lifers' - people who are happy working in this company for life.", " <b> Quality (excellent, thorough, accurate, or careful work):  </b>\n You are able to deliver quality work.", " <b> Service/dedication to a cause:  </b>\n This company does not care about its social impact."));
        Media.Add(new Company("Media", "Consumerix", " <b> Autonomy/independence:  </b>\n Your boss gives you lots of autonomy. You  will be able to act under your own rules and have no interference or standards.", " <b> Power, influence:  </b>\n You will be able to impress people with your power and influence role in society.", " <b> Social concerns (pursuing the common good; avoiding harm, caring about future generations):  </b>\n This company engages in practices which are damaging to the environment and society."));

        Retail.Add(new Company("Retail", "Onlyne", " <b> Curiosity:  </b>\n You're able to satisfy your curiosity in this job.", " <b> Service/dedication to a cause:  </b>\n This company has an inspiring mission and is actively engaged in social causes.", " <b> Creating balance in one's life:  </b>\n You're unable to balance your personal pursuits and concerns in this job."));
        Retail.Add(new Company("Retail", "Chock", " <b> Entrepreneurial creativity:  </b>\n This job allows you to take ownership of your job, be creative, and brainstorm to implement new ideas. ", " <b> General managerial competence:  </b>\n You will be able to take a position of responsibility to tackle high-level problems, as well as manage and develop others.", " <b> Professional accomplishment:  </b>\n You do not have a sense of professional accomplishment in this job."));
        Retail.Add(new Company("Retail", "Levi Craft", " <b> Pure challenge:  </b>\n This job is never boring and each day brings a new and exciting challenge.", " <b> Vision (anticipating future directions, seeing the big picture):  </b>\n Your teammates and the management are always focused on the future and on the big picture.", " <b> Hard work and commitment:  </b>\n Your hard work and commitment are not valued by this company."));
        Retail.Add(new Company("Retail", "Purchasio", " <b> Lifestyle:  </b>\n This company encourages its employees to live their lives fully. You are even able to take long periods off work to pursue your passions.", " <b> General managerial competence:  </b>\n You will be able to take a position of responsibility to tackle high-level problems, as well as manage and develop others.", " <b> Searching for knowledge, uncovering what is true:  </b>\n You are discouraged from uncovering truths in this job."));
        Retail.Add(new Company("Retail", "Shop Circuit", " <b> Wealth, material well-being:  </b>\n This company pays more than the rest of the industry.", " <b> Understanding, helping, or serving others:  </b>\n Everyone in your team tries their best to understand, help and serve others.", " <b> Honesty and integrity:  </b>\n Your colleagues act dishonestly and are unscrupulous in their dealings."));
        Retail.Add(new Company("Retail", "Merce&Lene", " <b> Professional conduct:  </b>\n Your colleagues act professionally at work.", " <b> Technical/functional competence:  </b>\n This job allows you to be excellent at your job and do it better than almost anyone else.", " <b> Autonomy/independence:  </b>\n Your boss micromanages you and makes you stick to his standards and rules. "));
        Retail.Add(new Company("Retail", "Shayne Streetman", " <b> Technical/functional competence:  </b>\n This job allows you to be excellent at your job and do it better than almost anyone else.", " <b> Job security/stability:  </b>\n Most people who work in this company are 'lifers' - people who are happy working in this company for life.", ", <b> Understanding, helping, or serving others:  </b>\n No one in your team tries to understand, help or serve others."));
        Retail.Add(new Company("Retail", "Friday Co.", " <b> Courage, risk-taking:  </b>\n You are able to show courage and take calculated risks in this job.", " <b> Vision (anticipating future directions, seeing the big picture):  </b>\n Your teammates and the management are always focused on the future and on the big picture.", " <b> Spirituality:  </b>\n Your company discourages spirituality."));
        Retail.Add(new Company("Retail", "My Butik", " <b> Quality (excellent, thorough, accurate, or careful work):  </b>\n You are able to deliver quality work.", " <b> Independence:  </b>\n You are able to work independently in this job.", " <b> Teaching, mentoring:  </b>\n Your boss does not teach or mentor you."));
        Retail.Add(new Company("Retail", "Table Top Shop", " <b> General managerial competence:   </b>\n You will be able to take a position of responsibility to tackle high-level problems, as well as manage and develop others.", " <b> Autonomy/independence:   </b>\n Your boss gives you lots of autonomy. You  will be able to act under your own rules and have no interference or standards.", " <b> Openness (being receptive to new ideas or multiple perspectives):   </b>\n Your teammates are closed off and narrow-minded."));



    }
}

public class LifeCard {
    public const int No = 0;
    public const int Yes = 1;
    public const int YesNo = 2;
    public string LifeCardDescription;
    public int choice;
    public int ActionPoint;
    public int Bank;
    public string Skill;
    public string LifeStyleAndPossession;

    public List<LifeCard> LCs = new List<LifeCard>();
    
    public LifeCard() {

        //LCs.Add(new LifeCard("You got hit by a car.", LifeCard.No, -2, 0, "", ""));
        //LCs.Add(new LifeCard("You won the lottery.", LifeCard.No, 0, +10000, "", ""));
        //LCs.Add(new LifeCard("Do you want to get married?", LifeCard.YesNo, -2, 0, "", "Married"));
        //LCs.Add(new LifeCard("A family member fell ill.", LifeCard.No, -1, -500, "", ""));
        //LCs.Add(new LifeCard("Do you want to play music on the side?", LifeCard.YesNo, -2, +500, "", ""));
        //LCs.Add(new LifeCard("Do you want to start an F&B business on the side?", LifeCard.YesNo, -3, -2000, "Leadership,Decision Making", "F&B Business Owner"));
        //LCs.Add(new LifeCard("Do you want to attend an art exhibition?", LifeCard.YesNo, -1, -500, "Creative Thinking", ""));
        //LCs.Add(new LifeCard("You got robbed.", LifeCard.No, 0, -1000, "", ""));
        //LCs.Add(new LifeCard("You helped a friend in need.", LifeCard.No, 1, -500, "", ""));
        //LCs.Add(new LifeCard("Do you want to dress up for a costume party?", LifeCard.YesNo, -2, 0, "Communication", ""));
        //LCs.Add(new LifeCard("You took a trip to an exotic country.", LifeCard.No, -2, -800, "Communication,Decision Making", ""));
        //LCs.Add(new LifeCard("Do you want to go on a spontaneous solo trip?", LifeCard.YesNo, -2, -500, "Communication", ""));
        //LCs.Add(new LifeCard("You petitioned for an environmental cause.", LifeCard.No, -1, 0, "Decision Making", ""));
        //LCs.Add(new LifeCard("Do you want to give to a charity?", LifeCard.YesNo, 0, -200, "Decision Making", ""));
        //LCs.Add(new LifeCard("You received a government payout.", LifeCard.No, 0, 200, "", ""));
        //LCs.Add(new LifeCard("You received red packets for the new year.", LifeCard.No, 0, 200, "", ""));
        //LCs.Add(new LifeCard("You gave red packets for the new year.", LifeCard.No, 0, -200, "", ""));
        //LCs.Add(new LifeCard("You got famous for no reason.", LifeCard.Yes, -1, 0, "", "Plus Luxury Mobile Phone"));
        //LCs.Add(new LifeCard("Do you want to be famous?", LifeCard.YesNo, -1, 0, "", "Plus Luxury Mobile Phone"));
        //LCs.Add(new LifeCard("You have a drinking problem.", LifeCard.No, -2, -500, "", ""));
        //LCs.Add(new LifeCard("You reconnect with an old friend.", LifeCard.No, +1, +200, "", ""));
        //LCs.Add(new LifeCard("Your annual taxes are due.", LifeCard.No, 0, 1000, "", ""));
        //LCs.Add(new LifeCard("Your laptop crashed.", LifeCard.No, 0, -500, "", ""));
        //LCs.Add(new LifeCard("A distant relative passed away and left you something.", LifeCard.No, 0, 0, "", "Plus Economical Car"));
        //LCs.Add(new LifeCard("Go bungee-jumping ?", LifeCard.YesNo, +1, -200, "Creative Thinking", ""));
        //LCs.Add(new LifeCard("Your pet is sick.", LifeCard.No, 0, -200, "", ""));
    }
    public LifeCard(string LifeCardDescription, int choice, int ActionPoint, int Bank, string Skill, string LifeStyleAndPossession) {
        this.LifeCardDescription = LifeCardDescription;
        this.choice = choice;
        this.ActionPoint = ActionPoint;
        this.Bank = Bank;
        this.Skill = Skill;
        this.LifeStyleAndPossession = LifeStyleAndPossession;
    }

    public void insertLifeCards(MyLifeCardData [] cards)
    {
        foreach (var item in cards)
        {
            string skillString = "";
            foreach (var stringItem in item.skills)
            {
                skillString = skillString + stringItem;
            }
            LCs.Add(new LifeCard(item.description, item.choice, item.actionpoints, item.money, skillString, item.possession));
        }
    }
}