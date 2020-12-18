using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AppData : MonoBehaviour {

    public Player.Job MyFinalJob = new Player.Job();
    public DataBase DB;
    [HideInInspector] public GameIdData gameIdData;
    public string game_id_data;
    public string id_to_send_with;


    public bool Car;
    public bool Phone;
    public bool House;
    public bool Travel;

    public bool Budget;
    public bool Economic;
    public bool Luxury;

    public int ShopAP, ShopMoney;

    public Text Money, AP;
    
    public int AvgCount = 0;
    public int AvgSum = 0;

    public int counter = 0;
    [HideInInspector] public LifeCard LC;
    public string feildskills;
    public bool IsContinueEdu = false;

    public bool LifeCardEveryPerRound = false;
    public bool LifeCardEveryPerRoundTemp = false;

    public bool APDown = false;

    private void Start()
    {

        //StartCoroutine(corout());
    }

    //private IEnumerator corout()
    //{
    //    GameIdData2 g = new GameIdData2();
    //    string gg = JsonUtility.ToJson(g);
    //    var request = new UnityWebRequest("http://18.223.239.177/hello/game/newgame", "POST");
    //    byte[] bodyRaw = Encoding.UTF8.GetBytes(gg);
    //    request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
    //    request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //    request.SetRequestHeader("Content-Type", "application/json");
    //    yield return request.SendWebRequest();
    //    Debug.Log("Status Code: " + request.responseCode);
    //}
    private bool isCoroutStarted = false;
    private void Update() {
        AP.text = "Action Points: " + CurrentPlayer.RemainingActionPoints;
        Money.text = "Bank Account: $" + CurrentPlayer.BankString;

        if (DB.isRoundStarted && CurrentPlayer.RemainingActionPoints <= 0 && !isCoroutStarted) { // also check if round is started here.
            APDown = true;
            isCoroutStarted = true;
            StartCoroutine(AP_Coroutine());
        } else {
            APDown = false;
        }
        if (CurrentPlayer.RemainingActionPoints > 0) {
            isCoroutStarted = false;
        }
    }

    public IEnumerator AP_Coroutine() {
        yield return new WaitForSeconds(1.0f);
    }

    [System.Serializable]
    public class ThreeSelection
    {
        public int Listindex;
        public string ListName;

    }

    public Player CurrentPlayer;
    
    public string Course = "";
    public string Degree = "";

    //public int Listindex;
    //public string ListName;
    public const int selectionLimit = 3;
    public List<ThreeSelection> SelectThree = new List<ThreeSelection>();

    AppData()
    {
    }

    // ahsan's editing...

    public class Fields
    {
        public const string Accountancy = "Accountancy";
        public const string HealthCare = "Healthcare";
        public const string HumanResource = "Human Resources";
        public const string InformationTechnology = "Information Technology";
        public const string Media = "Media";
        public const string Retail = "Retail";
    }

    public class JobTitles
    {
        public const string Accountancy_ChiefFinancialOfficeer = "Chief Financial Officer";
        public const string Accountancy_ManagementAccountingBusinessController = "Management Accounting - Business Controller";
        public const string Accountancy_FinancialAccountingFinancialControl = "Financial Accounting - Financial Controller";
        public const string Accountancy_ManagementAccountingFinancialPlaningAndAnalysisManager = "Management Accounting - Financial Planning and Analysis Manager";
        public const string Accountancy_FinancialAccountingFinanceManager = "Financial Accounting - Finance Manager";
        public const string Accountancy_ManagementAccountingAccountingExecutive = "Management Accounting - Accounting Executive";
        public const string Accountancy_FinancialAccountingAccountsExecutive = "Financial Accounting - Accounts Executive";

        public const string HealthCare_SeniorPrincipalPhysiotherapyResearcher = "Senior Principal Physiotherapy Researcher";
        public const string HealthCare_SeniorPhysiotherapist = "Senior Physiotherapist";
        public const string HealthCare_SeniorPrincipalPhysiotherapistClinical = "Senior Principal Physiotherapist (Clinical)";
        public const string HealthCare_SeniorPrincipalPhysiotherapyEducator = "Senior Principal Physiotherapy Educator";
        public const string HealthCare_PrincipalPhysiotherapyResearcher = "Principal Physiotherapy Researcher";
        public const string HealthCare_Physiotherapist = "Physiotherapist";
        public const string HealthCare_PrincipalPhysiotherapistClinical = "Principal Physiotherapist  (Clinical)";
        public const string HealthCare_PrincipalPhysiotherapyEducator = "Principal Physiotherapy Educator";

        public const string HumanResource_ChiefHumanResourceOfficer = "Chief Human Resources Officer";
        public const string HumanResource_HeadPerformanceRewards = "Head, Performance & Rewards";
        public const string HumanResource_ManagerPerformanceRewards = "Manager, Performance & Rewards";
        public const string HumanResource_ExecutivePerformanceRewards = "Executive, Performance & Rewards";
        public const string HumanResource_HeadTalentAttraction = "Head, Talent & Attraction";
        public const string HumanResource_ManagerTalentAttraction = "Manager, Talent & Attraction";
        public const string HumanResource_ExecutiveTalentAttraction = "Executive, Talent & Attraction";
        public const string HumanResource_HeadEmployeeExperienceReleations = "Head, Employee Experience & Relations";
        public const string HumanResource_ManagerEmployeeExperienceReleations = "Manager, Employee Experience & Relations";
        public const string HumanResource_ExecutiveExployeeExperienceRelations = "Executive, Employee Experience & Relations";

        public const string InformationTechnology_ChiefTechnologyOfficer = "Chief Technology Officer";
        public const string InformationTechnology_ApplicationsArchitecture = "Applications Architect";
        public const string InformationTechnology_ApplicationsDevelopmentManager = "Applications Development Manager";
        public const string InformationTechnology_ApplicationsDeveloper = "Applications Developer";
        public const string InformationTechnology_HeadOfProduct = "Head of Product";
        public const string InformationTechnology_LeadUXDesigner = "Lead UX Designer";
        public const string InformationTechnology_SeniorUXDesigner = "Senior UX Designer";
        public const string InformationTechnology_UXDesigner = "UX Designer";

        public const string Media_ExecutiveProductBroadcast = "Executive Producer - Broadcast";
        public const string Media_ProducerBroadcast = "Producer - Broadcast";
        public const string Media_AssistantProducerBroadcast = "Assistant Producer - Broadcast";
        public const string Media_ProductionAssistant = "Production Assistant";
        public const string Media_ChiefEditor = "Chief Editor";
        public const string Media_ExecutiveEditor = "Executive Editor";
        public const string Media_SeniorReporterSeniorCorrespondent = "Senior Reporter / Senior Correspondent";
        public const string Media_ReporterCorrespondent = "Reporter / Correspondent ";

        public const string Retail_ChiefExecutiveOfficerManaging = "Chief Executive Officer / Managing Director";
        public const string Retail_BrandDirector = "Brand Director";
        public const string Retail_BrandManager = "Brand Manager";
        public const string Retail_BrandAssociate = "Brand Associate";
        public const string Retail_MarchandisingDirector = "Merchandising Director";
        public const string Retail_MarchandisingManager = "Merchandising Manager";
        public const string Retail_VisualMarchandising = "Visual Merchandiser";
    }
}
//public class GameIdData2
//{
//    public int gameno;
//    public int totalrounds;
//    public int roundno;
//    public int duration;    //
//    public string token;            // do i receive the token here ???...
//    public int actionpoints;    //
//    public int money;       //
//    public bool start;

//    public GameIdData2()
//    {
//        gameno = 1;
//        totalrounds = 5;
//        roundno = 1;
//        duration = 5;
//        token = "897183";
//        actionpoints = 10;
//        money = 100;
//        start = true;
//    }
//}
