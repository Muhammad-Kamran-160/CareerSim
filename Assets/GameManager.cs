using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DataBase DB;
    public static GameManager instanceg;
    public GameObject playerGameCodeScreen, preReqAccountancyPanel, preReqHealthCarePanel,preReqHrPanel, preReqItPanel, preReqMediaPanel, preReqRetailPanel;
    public  float accountancySalary0, accountancySalary1, accountancySalary2, accountancySalary3, accountancySalary4, accountancySalary5, accountancySalary6, heathCareSalary0, heathCareSalary1, heathCareSalary2, heathCareSalary3, heathCareSalary4, heathCareSalary5, heathCareSalary6, heathCareSalary7, hrSalary0, hrSalary1, hrSalary2, hrSalary3, hrSalary4, hrSalary5, hrSalary6, hrSalary7, hrSalary8, hrSalary9, itSalary0, itSalary1, itSalary2, itSalary3, itSalary4, itSalary5, itSalary6, itSalary7, mediaSalary0, mediaSalary1, mediaSalary2, mediaSalary3, mediaSalary4, mediaSalary5, mediaSalary6, mediaSalary7, retailSalary0, retailSalary1, retailSalary2, retailSalary3, retailSalary4, retailSalary5, retailSalary6, retailSalary7;
    public GameObject[] infoScreens, allScreens, allAccountancyJobsButtons, allHealthCareJobsButtons, allHrJobsButtons, allItJobsButton, allMediaJobsButton, allRetailJobsButton;
    
    public string[] accountancylevel1prereq1, accountancylevel1prereq2, accountancylevel2prereq1, accountancylevel2prereq2, accountancylevel3prereq1, accountancylevel3prereq2, accountancylevel4prereq, healthCareLevel1PreReq, healthCareLevel2PreReq, healthCareLevel3PreReq1, healthCareLevel3PreReq2, healthCareLevel3PreReq3, healthCareLevel4PreReq, hRLevel1PreReq1, hRLevel1PreReq2, hRLevel1PreReq3, hRLevel2PreReq1, hRLevel2PreReq2, hRLevel2PreReq3, hRLevel3PreReq1, hRLevel3PreReq2, hRLevel3PreReq3, hRLevel4PreReq, iTLevel1PreReq1, iTLevel1PreReq2, iTLevel2PreReq1, iTLevel2PreReq2, iTLevel3PreReq1, iTLevel3PreReq2, iTLevel4PreReq1, iTLevel4PreReq2, mediaLevel1PreReq1, mediaLevel1PreReq2, mediaLevel2PreReq1, mediaLevel2PreReq2, mediaLevel3PreReq1, mediaLevel3PreReq2, mediaLevel4PreReq1, mediaLevel4PreReq2, retailLevel1PreReq1, retailLevel1PreReq2, retailLevel2PreReq1, retailLevel2PreReq2, retailLevel3PreReq1, retailLevel3PreReq2, retailLevel4PreReq;
    
    public Text[] accountancyvaluetexts, healthCareValueTexts, hrValueTexts, itValueTexts, mediaValueTexts, retailValueTexts;
    public Text AccPreReqScreenJobtitle, HCPreReqScreenJobtitle, HRPreReqScreenJobtitle, ITPreReqScreenJobtitle, MedPreReqScreenJobtitle, RetPreReqScreenJobtitle;
    public AppData instance;
    public bool level1Man, level2Man, level3Man, level1Fin, level2Fin, level3Fin, chiefFin, healthCareLevel1PhysiotherapistJob, healthCareLevel2SeniorPhysiotherapistJob, healthCareLevel3PrincipalPhysiotherapistClinicalJob, healthCareLevel4SeniorPrincipalPhysiotherapistClinicaljob, healthCareLevel3PrincipalPhysiotherapyEducator, healthCareLevel4SeniorPrincipalPhysiotherapyEducatorjob, healthCareLevel3PrincipalPhysiotherapyResearcherJob, healthCareLevel4SeniorPrincipalPhysiotherapyResearcherJob, hRlevel1ExecutivePerformanceandRewardsjob, hRlevel2ManagerPerformanceandRewardsjob, hRlevel3HeadPerformanceandRewardsjob, hRLevel1ExecutiveTalentAndAttractionjob, hRlevel2ManagerTalentAndAttractionjob, hRLevel3HeadTalentAndAttractionjob, hRLevel1ExecutiveEmployeeExperienceAndReactionsjob, hRLevel2ManagerEmployeeExperienceAndRelationsjob, hRLevel3HeadEmployeeExperienceAndRelationsjob, hRLevel4ChiefHumanResourceOfficerjob, ItLevel1ApplicationDeveloperjob, ItLevel2ApplicationDevelopmentManager, iTLevel3ApplicationArchitectjob, iTLevel4ChiefTechnologyOfficerjob, iTLevel1UXDesignerjob, ItLevel2SeniorUXDesignerjob, iTLevel3LeadUXDesginerjob, ItLevel4HeadOfProductjob, mediaLevel1ProductionAssistantjob, mediaLevel2AssistantProducerBroadcastjob, mediaLevel3ProducerBroadcastjob, mediaLevel4ExecutiveProducerBroadcastjob, mediaLevel1ReporterCorrespondentjob, mediaLevel2SeniorReporterSeniorCorrespondentjob, mediaLevel3ExecutiveEditorjob, mediaLevel4ChiefEditorjob, retailLevel1BrandAssociatejob, retailLevel2BrandManagerjob, retailLevel3BrandDirectorjob, retailLevel1VisualMerchandiserjob, retialLevel2MerchandisingManagerjob, retailLevel3MerchandisingDirectorjob, retailLevel4ChiefExecutiveOfficerManagingDirectorjob;
    // Start is called before the first frame update
    void Start()
    {
        if (instanceg == null) {
            instanceg = this;
        }
       // transform.GetChild(0).GetComponent<Text>().text = heathCareSalary0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (instanceg.DB.RoundOneEnded && instanceg.DB.RoundCounter <= /*5*/ instanceg.DB.TotalRounds) {   // max rounds limit.
            instanceg.DB.RoundOneEnded = false;
            UploadData ud = GameObject.FindObjectOfType<UploadData>();
            // Calling upload data here...
            int a = GameObject.FindObjectOfType<AppData>().gameIdData.roundno;
            ud.UploadAllData_Last(GameObject.FindObjectOfType<AppData>(), GameObject.FindObjectOfType<DataBase>(), a);
            
            // Sending job limits data at the end of round
            DB.GetComponent<IndusturiesJobLimit>().SendJobLimitsData();
            
            //instanceg.DB.RoundCounter++;
            TurnOffScreen();
        }
        if (instanceg.DB.JobEnded) {
            instanceg.DB.JobEnded = false;
            ClearJob();
        }
    }

    public void turnOffAllScreens() {
        foreach (var item in allScreens) {
            item.SetActive(false);
        }
    }

    public void onButtonClick(int screenIndexToOpen) {
        turnOffAllScreens();
        allScreens[screenIndexToOpen].SetActive(true);
        PlayerPrefs.SetInt("CurrentScreen", screenIndexToOpen);
    }
    public void TurnOffScreen() { // called when new round starts
        // save all data here...
        
        allScreens[PlayerPrefs.GetInt("CurrentScreen")].SetActive(false);
        allScreens[17].SetActive(true);
    }
    public void ClearJob() {
        instance.MyFinalJob.Clear();
    }

    public void closeInfoPanel(int screenNumber)
    {
        infoScreens[screenNumber].SetActive(false);
    }
    public void SetTitle(Text title) {
        RetPreReqScreenJobtitle.text = MedPreReqScreenJobtitle.text = ITPreReqScreenJobtitle.text = HRPreReqScreenJobtitle.text = HCPreReqScreenJobtitle.text = AccPreReqScreenJobtitle.text = title.text + " Prerequisites";
    }
    public void onAccountancyIotaButtonClick(int levelnumber)
    {
        switch (levelnumber) {
            case 11:
                accountancyvaluetexts[0].text = accountancylevel1prereq1[0];
                accountancyvaluetexts[1].text = accountancylevel1prereq1[1];
                accountancyvaluetexts[2].text = accountancylevel1prereq1[2];
                accountancyvaluetexts[3].text = accountancylevel1prereq1[3];
                accountancyvaluetexts[4].text = accountancylevel1prereq1[4];
                accountancyvaluetexts[5].text = accountancylevel1prereq1[5];
                accountancyvaluetexts[6].text = accountancylevel1prereq1[6];
                accountancyvaluetexts[7].text = accountancylevel1prereq1[7];
                accountancyvaluetexts[8].text = accountancylevel1prereq1[8];
                accountancyvaluetexts[9].text = accountancylevel1prereq1[9];
                accountancyvaluetexts[10].text = accountancylevel1prereq1[10];
                accountancyvaluetexts[11].text = accountancylevel1prereq1[11];
                accountancyvaluetexts[12].text = accountancylevel1prereq1[12];
                accountancyvaluetexts[13].text = accountancylevel1prereq1[13];
                break;
            case 12:
                accountancyvaluetexts[0].text = accountancylevel1prereq2[0];
                accountancyvaluetexts[1].text = accountancylevel1prereq2[1];
                accountancyvaluetexts[2].text = accountancylevel1prereq2[2];
                accountancyvaluetexts[3].text = accountancylevel1prereq2[3];
                accountancyvaluetexts[4].text = accountancylevel1prereq2[4];
                accountancyvaluetexts[5].text = accountancylevel1prereq2[5];
                accountancyvaluetexts[6].text = accountancylevel1prereq2[6];
                accountancyvaluetexts[7].text = accountancylevel1prereq2[7];
                accountancyvaluetexts[8].text = accountancylevel1prereq2[8];
                accountancyvaluetexts[9].text = accountancylevel1prereq2[9];
                accountancyvaluetexts[10].text = accountancylevel1prereq2[10];
                accountancyvaluetexts[11].text = accountancylevel1prereq2[11];
                accountancyvaluetexts[12].text = accountancylevel1prereq2[12];
                accountancyvaluetexts[13].text = accountancylevel1prereq2[13];
                break;


            case 21:
                accountancyvaluetexts[0].text = accountancylevel2prereq1[0];
                accountancyvaluetexts[1].text = accountancylevel2prereq1[1];
                accountancyvaluetexts[2].text = accountancylevel2prereq1[2];
                accountancyvaluetexts[3].text = accountancylevel2prereq1[3];
                accountancyvaluetexts[4].text = accountancylevel2prereq1[4];
                accountancyvaluetexts[5].text = accountancylevel2prereq1[5];
                accountancyvaluetexts[6].text = accountancylevel2prereq1[6];
                accountancyvaluetexts[7].text = accountancylevel2prereq1[7];
                accountancyvaluetexts[8].text = accountancylevel2prereq1[8];
                accountancyvaluetexts[9].text = accountancylevel2prereq1[9];
                accountancyvaluetexts[10].text = accountancylevel2prereq1[10];
                accountancyvaluetexts[11].text = accountancylevel2prereq1[11];
                accountancyvaluetexts[12].text = accountancylevel2prereq1[12];
                accountancyvaluetexts[13].text = accountancylevel2prereq1[13];
                break;
            case 22:
                accountancyvaluetexts[0].text = accountancylevel2prereq2[0];
                accountancyvaluetexts[1].text = accountancylevel2prereq2[1];
                accountancyvaluetexts[2].text = accountancylevel2prereq2[2];
                accountancyvaluetexts[3].text = accountancylevel2prereq2[3];
                accountancyvaluetexts[4].text = accountancylevel2prereq2[4];
                accountancyvaluetexts[5].text = accountancylevel2prereq2[5];
                accountancyvaluetexts[6].text = accountancylevel2prereq2[6];
                accountancyvaluetexts[7].text = accountancylevel2prereq2[7];
                accountancyvaluetexts[8].text = accountancylevel2prereq2[8];
                accountancyvaluetexts[9].text = accountancylevel2prereq2[9];
                accountancyvaluetexts[10].text = accountancylevel2prereq2[10];
                accountancyvaluetexts[11].text = accountancylevel2prereq2[11];
                accountancyvaluetexts[12].text = accountancylevel2prereq2[12];
                accountancyvaluetexts[13].text = accountancylevel2prereq2[13];
                break;

            case 31:
                accountancyvaluetexts[0].text = accountancylevel3prereq1[0];
                accountancyvaluetexts[1].text = accountancylevel3prereq1[1];
                accountancyvaluetexts[2].text = accountancylevel3prereq1[2];
                accountancyvaluetexts[3].text = accountancylevel3prereq1[3];
                accountancyvaluetexts[4].text = accountancylevel3prereq1[4];
                accountancyvaluetexts[5].text = accountancylevel3prereq1[5];
                accountancyvaluetexts[6].text = accountancylevel3prereq1[6];
                accountancyvaluetexts[7].text = accountancylevel3prereq1[7];
                accountancyvaluetexts[8].text = accountancylevel3prereq1[8];
                accountancyvaluetexts[9].text = accountancylevel3prereq1[9];
                accountancyvaluetexts[10].text = accountancylevel3prereq1[10];
                accountancyvaluetexts[11].text = accountancylevel3prereq1[11];
                accountancyvaluetexts[12].text = accountancylevel3prereq1[12];
                accountancyvaluetexts[13].text = accountancylevel3prereq1[13];
                break;
            case 32:
                accountancyvaluetexts[0].text = accountancylevel3prereq2[0];
                accountancyvaluetexts[1].text = accountancylevel3prereq2[1];
                accountancyvaluetexts[2].text = accountancylevel3prereq2[2];
                accountancyvaluetexts[3].text = accountancylevel3prereq2[3];
                accountancyvaluetexts[4].text = accountancylevel3prereq2[4];
                accountancyvaluetexts[5].text = accountancylevel3prereq2[5];
                accountancyvaluetexts[6].text = accountancylevel3prereq2[6];
                accountancyvaluetexts[7].text = accountancylevel3prereq2[7];
                accountancyvaluetexts[8].text = accountancylevel3prereq2[8];
                accountancyvaluetexts[9].text = accountancylevel3prereq2[9];
                accountancyvaluetexts[10].text = accountancylevel3prereq2[10];
                accountancyvaluetexts[11].text = accountancylevel3prereq2[11];
                accountancyvaluetexts[12].text = accountancylevel3prereq2[12];
                accountancyvaluetexts[13].text = accountancylevel3prereq2[13];
                break;

            case 4:
                accountancyvaluetexts[0].text = accountancylevel4prereq[0];
                accountancyvaluetexts[1].text = accountancylevel4prereq[1];
                accountancyvaluetexts[2].text = accountancylevel4prereq[2];
                accountancyvaluetexts[3].text = accountancylevel4prereq[3];
                accountancyvaluetexts[4].text = accountancylevel4prereq[4];
                accountancyvaluetexts[5].text = accountancylevel4prereq[5];
                accountancyvaluetexts[6].text = accountancylevel4prereq[6];
                accountancyvaluetexts[7].text = accountancylevel4prereq[7];
                accountancyvaluetexts[8].text = accountancylevel4prereq[8];
                accountancyvaluetexts[9].text = accountancylevel4prereq[9];
                accountancyvaluetexts[10].text = accountancylevel4prereq[10];
                accountancyvaluetexts[11].text = accountancylevel4prereq[11];
                accountancyvaluetexts[12].text = accountancylevel4prereq[12];
                accountancyvaluetexts[13].text = accountancylevel4prereq[13];
                break;
            default:
                break;
        }
        

        preReqAccountancyPanel.SetActive(true);
    }


    public void onHealthCareIotaButtonClick(int levelnumber)
    {
        switch (levelnumber)
        {
            case 1:
                healthCareValueTexts[0].text = healthCareLevel1PreReq[0];
                healthCareValueTexts[1].text = healthCareLevel1PreReq[1];
                healthCareValueTexts[2].text = healthCareLevel1PreReq[2];
                healthCareValueTexts[3].text = healthCareLevel1PreReq[3];
                healthCareValueTexts[4].text = healthCareLevel1PreReq[4];
                healthCareValueTexts[5].text = healthCareLevel1PreReq[5];
                healthCareValueTexts[6].text = healthCareLevel1PreReq[6];
                healthCareValueTexts[7].text = healthCareLevel1PreReq[7];
                healthCareValueTexts[8].text = healthCareLevel1PreReq[8];
                healthCareValueTexts[9].text = healthCareLevel1PreReq[9];
                healthCareValueTexts[10].text = healthCareLevel1PreReq[10];
                healthCareValueTexts[11].text = healthCareLevel1PreReq[11];
                healthCareValueTexts[12].text = healthCareLevel1PreReq[12];
                healthCareValueTexts[13].text = healthCareLevel1PreReq[13];
                break;


            case 2:
                healthCareValueTexts[0].text = healthCareLevel2PreReq[0];
                healthCareValueTexts[1].text = healthCareLevel2PreReq[1];
                healthCareValueTexts[2].text = healthCareLevel2PreReq[2];
                healthCareValueTexts[3].text = healthCareLevel2PreReq[3];
                healthCareValueTexts[4].text = healthCareLevel2PreReq[4];
                healthCareValueTexts[5].text = healthCareLevel2PreReq[5];
                healthCareValueTexts[6].text = healthCareLevel2PreReq[6];
                healthCareValueTexts[7].text = healthCareLevel2PreReq[7];
                healthCareValueTexts[8].text = healthCareLevel2PreReq[8];
                healthCareValueTexts[9].text = healthCareLevel2PreReq[9];
                healthCareValueTexts[10].text = healthCareLevel2PreReq[10];
                healthCareValueTexts[11].text = healthCareLevel2PreReq[11];
                healthCareValueTexts[12].text = healthCareLevel2PreReq[12];
                healthCareValueTexts[13].text = healthCareLevel2PreReq[13];
                break;

            case 31:
                healthCareValueTexts[0].text = healthCareLevel3PreReq1[0];
                healthCareValueTexts[1].text = healthCareLevel3PreReq1[1];
                healthCareValueTexts[2].text = healthCareLevel3PreReq1[2];
                healthCareValueTexts[3].text = healthCareLevel3PreReq1[3];
                healthCareValueTexts[4].text = healthCareLevel3PreReq1[4];
                healthCareValueTexts[5].text = healthCareLevel3PreReq1[5];
                healthCareValueTexts[6].text = healthCareLevel3PreReq1[6];
                healthCareValueTexts[7].text = healthCareLevel3PreReq1[7];
                healthCareValueTexts[8].text = healthCareLevel3PreReq1[8];
                healthCareValueTexts[9].text = healthCareLevel3PreReq1[9];
                healthCareValueTexts[10].text = healthCareLevel3PreReq1[10];
                healthCareValueTexts[11].text = healthCareLevel3PreReq1[11];
                healthCareValueTexts[12].text = healthCareLevel3PreReq1[12];
                healthCareValueTexts[13].text = healthCareLevel3PreReq1[13];
                break;
            case 32:
                healthCareValueTexts[0].text = healthCareLevel3PreReq2[0];
                healthCareValueTexts[1].text = healthCareLevel3PreReq2[1];
                healthCareValueTexts[2].text = healthCareLevel3PreReq2[2];
                healthCareValueTexts[3].text = healthCareLevel3PreReq2[3];
                healthCareValueTexts[4].text = healthCareLevel3PreReq2[4];
                healthCareValueTexts[5].text = healthCareLevel3PreReq2[5];
                healthCareValueTexts[6].text = healthCareLevel3PreReq2[6];
                healthCareValueTexts[7].text = healthCareLevel3PreReq2[7];
                healthCareValueTexts[8].text = healthCareLevel3PreReq2[8];
                healthCareValueTexts[9].text = healthCareLevel3PreReq2[9];
                healthCareValueTexts[10].text = healthCareLevel3PreReq2[10];
                healthCareValueTexts[11].text = healthCareLevel3PreReq2[11];
                healthCareValueTexts[12].text = healthCareLevel3PreReq2[12];
                healthCareValueTexts[13].text = healthCareLevel3PreReq2[13];
                break;
            case 33:
                healthCareValueTexts[0].text = healthCareLevel3PreReq3[0];
                healthCareValueTexts[1].text = healthCareLevel3PreReq3[1];
                healthCareValueTexts[2].text = healthCareLevel3PreReq3[2];
                healthCareValueTexts[3].text = healthCareLevel3PreReq3[3];
                healthCareValueTexts[4].text = healthCareLevel3PreReq3[4];
                healthCareValueTexts[5].text = healthCareLevel3PreReq3[5];
                healthCareValueTexts[6].text = healthCareLevel3PreReq3[6];
                healthCareValueTexts[7].text = healthCareLevel3PreReq3[7];
                healthCareValueTexts[8].text = healthCareLevel3PreReq3[8];
                healthCareValueTexts[9].text = healthCareLevel3PreReq3[9];
                healthCareValueTexts[10].text = healthCareLevel3PreReq3[10];
                healthCareValueTexts[11].text = healthCareLevel3PreReq3[11];
                healthCareValueTexts[12].text = healthCareLevel3PreReq3[12];
                healthCareValueTexts[13].text = healthCareLevel3PreReq3[13];
                break;

            case 4:
                healthCareValueTexts[0].text = healthCareLevel4PreReq[0];
                healthCareValueTexts[1].text = healthCareLevel4PreReq[1];
                healthCareValueTexts[2].text = healthCareLevel4PreReq[2];
                healthCareValueTexts[3].text = healthCareLevel4PreReq[3];
                healthCareValueTexts[4].text = healthCareLevel4PreReq[4];
                healthCareValueTexts[5].text = healthCareLevel4PreReq[5];
                healthCareValueTexts[6].text = healthCareLevel4PreReq[6];
                healthCareValueTexts[7].text = healthCareLevel4PreReq[7];
                healthCareValueTexts[8].text = healthCareLevel4PreReq[8];
                healthCareValueTexts[9].text = healthCareLevel4PreReq[9];
                healthCareValueTexts[10].text = healthCareLevel4PreReq[10];
                healthCareValueTexts[11].text = healthCareLevel4PreReq[11];
                healthCareValueTexts[12].text = healthCareLevel4PreReq[12];
                healthCareValueTexts[13].text = healthCareLevel4PreReq[13];
                break;
            default:
                break;
        }


        preReqHealthCarePanel.SetActive(true);
    }

    public void onHrIotaButtonClick(int levelnumber)
    {
        switch (levelnumber)
        {
            case 11:
                hrValueTexts[0].text = hRLevel1PreReq1[0];
                hrValueTexts[1].text = hRLevel1PreReq1[1];
                hrValueTexts[2].text = hRLevel1PreReq1[2];
                hrValueTexts[3].text = hRLevel1PreReq1[3];
                hrValueTexts[4].text = hRLevel1PreReq1[4];
                hrValueTexts[5].text = hRLevel1PreReq1[5];
                hrValueTexts[6].text = hRLevel1PreReq1[6];
                hrValueTexts[7].text = hRLevel1PreReq1[7];
                hrValueTexts[8].text = hRLevel1PreReq1[8];
                hrValueTexts[9].text = hRLevel1PreReq1[9];
                hrValueTexts[10].text = hRLevel1PreReq1[10];
                hrValueTexts[11].text = hRLevel1PreReq1[11];
                hrValueTexts[12].text = hRLevel1PreReq1[12];
                hrValueTexts[13].text = hRLevel1PreReq1[13];
                hrValueTexts[14].text = hRLevel1PreReq1[14];
                break;
            case 13:
                hrValueTexts[0].text = hRLevel1PreReq3[0];
                hrValueTexts[1].text = hRLevel1PreReq3[1];
                hrValueTexts[2].text = hRLevel1PreReq3[2];
                hrValueTexts[3].text = hRLevel1PreReq3[3];
                hrValueTexts[4].text = hRLevel1PreReq3[4];
                hrValueTexts[5].text = hRLevel1PreReq3[5];
                hrValueTexts[6].text = hRLevel1PreReq3[6];
                hrValueTexts[7].text = hRLevel1PreReq3[7];
                hrValueTexts[8].text = hRLevel1PreReq3[8];
                hrValueTexts[9].text = hRLevel1PreReq3[9];
                hrValueTexts[10].text = hRLevel1PreReq3[10];
                hrValueTexts[11].text = hRLevel1PreReq3[11];
                hrValueTexts[12].text = hRLevel1PreReq3[12];
                hrValueTexts[13].text = hRLevel1PreReq3[13];
                hrValueTexts[14].text = hRLevel1PreReq3[14];
                break;
            case 12:
                hrValueTexts[0].text = hRLevel1PreReq2[0];
                hrValueTexts[1].text = hRLevel1PreReq2[1];
                hrValueTexts[2].text = hRLevel1PreReq2[2];
                hrValueTexts[3].text = hRLevel1PreReq2[3];
                hrValueTexts[4].text = hRLevel1PreReq2[4];
                hrValueTexts[5].text = hRLevel1PreReq2[5];
                hrValueTexts[6].text = hRLevel1PreReq2[6];
                hrValueTexts[7].text = hRLevel1PreReq2[7];
                hrValueTexts[8].text = hRLevel1PreReq2[8];
                hrValueTexts[9].text = hRLevel1PreReq2[9];
                hrValueTexts[10].text = hRLevel1PreReq2[10];
                hrValueTexts[11].text = hRLevel1PreReq2[11];
                hrValueTexts[12].text = hRLevel1PreReq2[12];
                hrValueTexts[13].text = hRLevel1PreReq2[13];
                hrValueTexts[14].text = hRLevel1PreReq2[14];
                break;


            case 21:
                hrValueTexts[0].text = hRLevel2PreReq1[0];
                hrValueTexts[1].text = hRLevel2PreReq1[1];
                hrValueTexts[2].text = hRLevel2PreReq1[2];
                hrValueTexts[3].text = hRLevel2PreReq1[3];
                hrValueTexts[4].text = hRLevel2PreReq1[4];
                hrValueTexts[5].text = hRLevel2PreReq1[5];
                hrValueTexts[6].text = hRLevel2PreReq1[6];
                hrValueTexts[7].text = hRLevel2PreReq1[7];
                hrValueTexts[8].text = hRLevel2PreReq1[8];
                hrValueTexts[9].text = hRLevel2PreReq1[9];
                hrValueTexts[10].text = hRLevel2PreReq1[10];
                hrValueTexts[11].text = hRLevel2PreReq1[11];
                hrValueTexts[12].text = hRLevel2PreReq1[12];
                hrValueTexts[13].text = hRLevel2PreReq1[13];
                hrValueTexts[14].text = hRLevel2PreReq1[14];
                break;
            case 22:
                hrValueTexts[0].text = hRLevel2PreReq2[0];
                hrValueTexts[1].text = hRLevel2PreReq2[1];
                hrValueTexts[2].text = hRLevel2PreReq2[2];
                hrValueTexts[3].text = hRLevel2PreReq2[3];
                hrValueTexts[4].text = hRLevel2PreReq2[4];
                hrValueTexts[5].text = hRLevel2PreReq2[5];
                hrValueTexts[6].text = hRLevel2PreReq2[6];
                hrValueTexts[7].text = hRLevel2PreReq2[7];
                hrValueTexts[8].text = hRLevel2PreReq2[8];
                hrValueTexts[9].text = hRLevel2PreReq2[9];
                hrValueTexts[10].text = hRLevel2PreReq2[10];
                hrValueTexts[11].text = hRLevel2PreReq2[11];
                hrValueTexts[12].text = hRLevel2PreReq2[12];
                hrValueTexts[13].text = hRLevel2PreReq2[13];
                hrValueTexts[14].text = hRLevel2PreReq2[14];
                break;
            case 23:
                hrValueTexts[0].text = hRLevel2PreReq3[0];
                hrValueTexts[1].text = hRLevel2PreReq3[1];
                hrValueTexts[2].text = hRLevel2PreReq3[2];
                hrValueTexts[3].text = hRLevel2PreReq3[3];
                hrValueTexts[4].text = hRLevel2PreReq3[4];
                hrValueTexts[5].text = hRLevel2PreReq3[5];
                hrValueTexts[6].text = hRLevel2PreReq3[6];
                hrValueTexts[7].text = hRLevel2PreReq3[7];
                hrValueTexts[8].text = hRLevel2PreReq3[8];
                hrValueTexts[9].text = hRLevel2PreReq3[9];
                hrValueTexts[10].text = hRLevel2PreReq3[10];
                hrValueTexts[11].text = hRLevel2PreReq3[11];
                hrValueTexts[12].text = hRLevel2PreReq3[12];
                hrValueTexts[13].text = hRLevel2PreReq3[13];
                hrValueTexts[14].text = hRLevel2PreReq3[14];
                break;

            case 31:
                hrValueTexts[0].text = hRLevel3PreReq1[0];
                hrValueTexts[1].text = hRLevel3PreReq1[1];
                hrValueTexts[2].text = hRLevel3PreReq1[2];
                hrValueTexts[3].text = hRLevel3PreReq1[3];
                hrValueTexts[4].text = hRLevel3PreReq1[4];
                hrValueTexts[5].text = hRLevel3PreReq1[5];
                hrValueTexts[6].text = hRLevel3PreReq1[6];
                hrValueTexts[7].text = hRLevel3PreReq1[7];
                hrValueTexts[8].text = hRLevel3PreReq1[8];
                hrValueTexts[9].text = hRLevel3PreReq1[9];
                hrValueTexts[10].text = hRLevel3PreReq1[10];
                hrValueTexts[11].text = hRLevel3PreReq1[11];
                hrValueTexts[12].text = hRLevel3PreReq1[12];
                hrValueTexts[13].text = hRLevel3PreReq1[13];
                hrValueTexts[14].text = hRLevel3PreReq1[14];
                break;
            case 32:
                hrValueTexts[0].text = hRLevel3PreReq2[0];
                hrValueTexts[1].text = hRLevel3PreReq2[1];
                hrValueTexts[2].text = hRLevel3PreReq2[2];
                hrValueTexts[3].text = hRLevel3PreReq2[3];
                hrValueTexts[4].text = hRLevel3PreReq2[4];
                hrValueTexts[5].text = hRLevel3PreReq2[5];
                hrValueTexts[6].text = hRLevel3PreReq2[6];
                hrValueTexts[7].text = hRLevel3PreReq2[7];
                hrValueTexts[8].text = hRLevel3PreReq2[8];
                hrValueTexts[9].text = hRLevel3PreReq2[9];
                hrValueTexts[10].text = hRLevel3PreReq2[10];
                hrValueTexts[11].text = hRLevel3PreReq2[11];
                hrValueTexts[12].text = hRLevel3PreReq2[12];
                hrValueTexts[13].text = hRLevel3PreReq2[13];
                hrValueTexts[14].text = hRLevel3PreReq2[14];
                break;
            case 33:
                hrValueTexts[0].text = hRLevel3PreReq3[0];
                hrValueTexts[1].text = hRLevel3PreReq3[1];
                hrValueTexts[2].text = hRLevel3PreReq3[2];
                hrValueTexts[3].text = hRLevel3PreReq3[3];
                hrValueTexts[4].text = hRLevel3PreReq3[4];
                hrValueTexts[5].text = hRLevel3PreReq3[5];
                hrValueTexts[6].text = hRLevel3PreReq3[6];
                hrValueTexts[7].text = hRLevel3PreReq3[7];
                hrValueTexts[8].text = hRLevel3PreReq3[8];
                hrValueTexts[9].text = hRLevel3PreReq3[9];
                hrValueTexts[10].text = hRLevel3PreReq3[10];
                hrValueTexts[11].text = hRLevel3PreReq3[11];
                hrValueTexts[12].text = hRLevel3PreReq3[12];
                hrValueTexts[13].text = hRLevel3PreReq3[13];
                hrValueTexts[14].text = hRLevel3PreReq3[14];
                break;

            case 4:
                hrValueTexts[0].text = hRLevel4PreReq[0];
                hrValueTexts[1].text = hRLevel4PreReq[1];
                hrValueTexts[2].text = hRLevel4PreReq[2];
                hrValueTexts[3].text = hRLevel4PreReq[3];
                hrValueTexts[4].text = hRLevel4PreReq[4];
                hrValueTexts[5].text = hRLevel4PreReq[5];
                hrValueTexts[6].text = hRLevel4PreReq[6];
                hrValueTexts[7].text = hRLevel4PreReq[7];
                hrValueTexts[8].text = hRLevel4PreReq[8];
                hrValueTexts[9].text = hRLevel4PreReq[9];
                hrValueTexts[10].text = hRLevel4PreReq[10];
                hrValueTexts[11].text = hRLevel4PreReq[11];
                hrValueTexts[12].text = hRLevel4PreReq[12];
                hrValueTexts[13].text = hRLevel4PreReq[13];
                hrValueTexts[14].text = hRLevel4PreReq[14];
                break;
            default:
                break;
        }


        preReqHrPanel.SetActive(true);
    }

    public void onItIotaButtonClick(int levelnumber)
    {
        switch (levelnumber)
        {
            case 11:
                itValueTexts[0].text = iTLevel1PreReq1[0];
                itValueTexts[1].text = iTLevel1PreReq1[1];
                itValueTexts[2].text = iTLevel1PreReq1[2];
                itValueTexts[3].text = iTLevel1PreReq1[3];
                itValueTexts[4].text = iTLevel1PreReq1[4];
                itValueTexts[5].text = iTLevel1PreReq1[5];
                itValueTexts[6].text = iTLevel1PreReq1[6];
                itValueTexts[7].text = iTLevel1PreReq1[7];
                itValueTexts[8].text = iTLevel1PreReq1[8];
                itValueTexts[9].text = iTLevel1PreReq1[9];
                itValueTexts[10].text = iTLevel1PreReq1[10];
                itValueTexts[11].text = iTLevel1PreReq1[11];
                itValueTexts[12].text = iTLevel1PreReq1[12];
                itValueTexts[13].text = iTLevel1PreReq1[13];
                break;
            case 12:
                itValueTexts[0].text = iTLevel1PreReq2[0];
                itValueTexts[1].text = iTLevel1PreReq2[1];
                itValueTexts[2].text = iTLevel1PreReq2[2];
                itValueTexts[3].text = iTLevel1PreReq2[3];
                itValueTexts[4].text = iTLevel1PreReq2[4];
                itValueTexts[5].text = iTLevel1PreReq2[5];
                itValueTexts[6].text = iTLevel1PreReq2[6];
                itValueTexts[7].text = iTLevel1PreReq2[7];
                itValueTexts[8].text = iTLevel1PreReq2[8];
                itValueTexts[9].text = iTLevel1PreReq2[9];
                itValueTexts[10].text = iTLevel1PreReq2[10];
                itValueTexts[11].text = iTLevel1PreReq2[11];
                itValueTexts[12].text = iTLevel1PreReq2[12];
                itValueTexts[13].text = iTLevel1PreReq2[13];
                break;


            case 21:
                itValueTexts[0].text = iTLevel2PreReq1[0];
                itValueTexts[1].text = iTLevel2PreReq1[1];
                itValueTexts[2].text = iTLevel2PreReq1[2];
                itValueTexts[3].text = iTLevel2PreReq1[3];
                itValueTexts[4].text = iTLevel2PreReq1[4];
                itValueTexts[5].text = iTLevel2PreReq1[5];
                itValueTexts[6].text = iTLevel2PreReq1[6];
                itValueTexts[7].text = iTLevel2PreReq1[7];
                itValueTexts[8].text = iTLevel2PreReq1[8];
                itValueTexts[9].text = iTLevel2PreReq1[9];
                itValueTexts[10].text = iTLevel2PreReq1[10];
                itValueTexts[11].text = iTLevel2PreReq1[11];
                itValueTexts[12].text = iTLevel2PreReq1[12];
                itValueTexts[13].text = iTLevel2PreReq1[13];
                break;
            case 22:
                itValueTexts[0].text = iTLevel2PreReq2[0];
                itValueTexts[1].text = iTLevel2PreReq2[1];
                itValueTexts[2].text = iTLevel2PreReq2[2];
                itValueTexts[3].text = iTLevel2PreReq2[3];
                itValueTexts[4].text = iTLevel2PreReq2[4];
                itValueTexts[5].text = iTLevel2PreReq2[5];
                itValueTexts[6].text = iTLevel2PreReq2[6];
                itValueTexts[7].text = iTLevel2PreReq2[7];
                itValueTexts[8].text = iTLevel2PreReq2[8];
                itValueTexts[9].text = iTLevel2PreReq2[9];
                itValueTexts[10].text = iTLevel2PreReq2[10];
                itValueTexts[11].text = iTLevel2PreReq2[11];
                itValueTexts[12].text = iTLevel2PreReq2[12];
                itValueTexts[13].text = iTLevel2PreReq2[13];
                break;

            case 31:
                itValueTexts[0].text = iTLevel3PreReq1[0];
                itValueTexts[1].text = iTLevel3PreReq1[1];
                itValueTexts[2].text = iTLevel3PreReq1[2];
                itValueTexts[3].text = iTLevel3PreReq1[3];
                itValueTexts[4].text = iTLevel3PreReq1[4];
                itValueTexts[5].text = iTLevel3PreReq1[5];
                itValueTexts[6].text = iTLevel3PreReq1[6];
                itValueTexts[7].text = iTLevel3PreReq1[7];
                itValueTexts[8].text = iTLevel3PreReq1[8];
                itValueTexts[9].text = iTLevel3PreReq1[9];
                itValueTexts[10].text = iTLevel3PreReq1[10];
                itValueTexts[11].text = iTLevel3PreReq1[11];
                itValueTexts[12].text = iTLevel3PreReq1[12];
                itValueTexts[13].text = iTLevel3PreReq1[13];
                break;
            case 32:
                itValueTexts[0].text = iTLevel3PreReq2[0];
                itValueTexts[1].text = iTLevel3PreReq2[1];
                itValueTexts[2].text = iTLevel3PreReq2[2];
                itValueTexts[3].text = iTLevel3PreReq2[3];
                itValueTexts[4].text = iTLevel3PreReq2[4];
                itValueTexts[5].text = iTLevel3PreReq2[5];
                itValueTexts[6].text = iTLevel3PreReq2[6];
                itValueTexts[7].text = iTLevel3PreReq2[7];
                itValueTexts[8].text = iTLevel3PreReq2[8];
                itValueTexts[9].text = iTLevel3PreReq2[9];
                itValueTexts[10].text = iTLevel3PreReq2[10];
                itValueTexts[11].text = iTLevel3PreReq2[11];
                itValueTexts[12].text = iTLevel3PreReq2[12];
                itValueTexts[13].text = iTLevel3PreReq2[13];
                break;

            case 41:
                itValueTexts[0].text = iTLevel4PreReq1[0];
                itValueTexts[1].text = iTLevel4PreReq1[1];
                itValueTexts[2].text = iTLevel4PreReq1[2];
                itValueTexts[3].text = iTLevel4PreReq1[3];
                itValueTexts[4].text = iTLevel4PreReq1[4];
                itValueTexts[5].text = iTLevel4PreReq1[5];
                itValueTexts[6].text = iTLevel4PreReq1[6];
                itValueTexts[7].text = iTLevel4PreReq1[7];
                itValueTexts[8].text = iTLevel4PreReq1[8];
                itValueTexts[9].text = iTLevel4PreReq1[9];
                itValueTexts[10].text = iTLevel4PreReq1[10];
                itValueTexts[11].text = iTLevel4PreReq1[11];
                itValueTexts[12].text = iTLevel4PreReq1[12];
                itValueTexts[13].text = iTLevel4PreReq1[13];
                break;
            case 42:
                itValueTexts[0].text = iTLevel4PreReq2[0];
                itValueTexts[1].text = iTLevel4PreReq2[1];
                itValueTexts[2].text = iTLevel4PreReq2[2];
                itValueTexts[3].text = iTLevel4PreReq2[3];
                itValueTexts[4].text = iTLevel4PreReq2[4];
                itValueTexts[5].text = iTLevel4PreReq2[5];
                itValueTexts[6].text = iTLevel4PreReq2[6];
                itValueTexts[7].text = iTLevel4PreReq2[7];
                itValueTexts[8].text = iTLevel4PreReq2[8];
                itValueTexts[9].text = iTLevel4PreReq2[9];
                itValueTexts[10].text = iTLevel4PreReq2[10];
                itValueTexts[11].text = iTLevel4PreReq2[11];
                itValueTexts[12].text = iTLevel4PreReq2[12];
                itValueTexts[13].text = iTLevel4PreReq2[13];
                break;
            default:
                break;
        }


        preReqItPanel.SetActive(true);
    }


    public void onMediaIotaButtonClick(int levelnumber)
    {
        switch (levelnumber) {
            case 11:
                mediaValueTexts[0].text = mediaLevel1PreReq1[0];
                mediaValueTexts[1].text = mediaLevel1PreReq1[1];
                mediaValueTexts[2].text = mediaLevel1PreReq1[2];
                mediaValueTexts[3].text = mediaLevel1PreReq1[3];
                mediaValueTexts[4].text = mediaLevel1PreReq1[4];
                mediaValueTexts[5].text = mediaLevel1PreReq1[5];
                mediaValueTexts[6].text = mediaLevel1PreReq1[6];
                mediaValueTexts[7].text = mediaLevel1PreReq1[7];
                mediaValueTexts[8].text = mediaLevel1PreReq1[8];
                mediaValueTexts[9].text = mediaLevel1PreReq1[9];
                mediaValueTexts[10].text = mediaLevel1PreReq1[10];
                mediaValueTexts[11].text = mediaLevel1PreReq1[11];
                mediaValueTexts[12].text = mediaLevel1PreReq1[12];
                mediaValueTexts[13].text = mediaLevel1PreReq1[13];
                break;
            case 12:
                mediaValueTexts[0].text = mediaLevel1PreReq2[0];
                mediaValueTexts[1].text = mediaLevel1PreReq2[1];
                mediaValueTexts[2].text = mediaLevel1PreReq2[2];
                mediaValueTexts[3].text = mediaLevel1PreReq2[3];
                mediaValueTexts[4].text = mediaLevel1PreReq2[4];
                mediaValueTexts[5].text = mediaLevel1PreReq2[5];
                mediaValueTexts[6].text = mediaLevel1PreReq2[6];
                mediaValueTexts[7].text = mediaLevel1PreReq2[7];
                mediaValueTexts[8].text = mediaLevel1PreReq2[8];
                mediaValueTexts[9].text = mediaLevel1PreReq2[9];
                mediaValueTexts[10].text = mediaLevel1PreReq2[10];
                mediaValueTexts[11].text = mediaLevel1PreReq2[11];
                mediaValueTexts[12].text = mediaLevel1PreReq2[12];
                mediaValueTexts[13].text = mediaLevel1PreReq2[13];
                break;


            case 21:
                mediaValueTexts[0].text = mediaLevel2PreReq1[0];
                mediaValueTexts[1].text = mediaLevel2PreReq1[1];
                mediaValueTexts[2].text = mediaLevel2PreReq1[2];
                mediaValueTexts[3].text = mediaLevel2PreReq1[3];
                mediaValueTexts[4].text = mediaLevel2PreReq1[4];
                mediaValueTexts[5].text = mediaLevel2PreReq1[5];
                mediaValueTexts[6].text = mediaLevel2PreReq1[6];
                mediaValueTexts[7].text = mediaLevel2PreReq1[7];
                mediaValueTexts[8].text = mediaLevel2PreReq1[8];
                mediaValueTexts[9].text = mediaLevel2PreReq1[9];
                mediaValueTexts[10].text = mediaLevel2PreReq1[10];
                mediaValueTexts[11].text = mediaLevel2PreReq1[11];
                mediaValueTexts[12].text = mediaLevel2PreReq1[12];
                mediaValueTexts[13].text = mediaLevel2PreReq1[13];
                break;
            case 22:
                mediaValueTexts[0].text = mediaLevel2PreReq2[0];
                mediaValueTexts[1].text = mediaLevel2PreReq2[1];
                mediaValueTexts[2].text = mediaLevel2PreReq2[2];
                mediaValueTexts[3].text = mediaLevel2PreReq2[3];
                mediaValueTexts[4].text = mediaLevel2PreReq2[4];
                mediaValueTexts[5].text = mediaLevel2PreReq2[5];
                mediaValueTexts[6].text = mediaLevel2PreReq2[6];
                mediaValueTexts[7].text = mediaLevel2PreReq2[7];
                mediaValueTexts[8].text = mediaLevel2PreReq2[8];
                mediaValueTexts[9].text = mediaLevel2PreReq2[9];
                mediaValueTexts[10].text = mediaLevel2PreReq2[10];
                mediaValueTexts[11].text = mediaLevel2PreReq2[11];
                mediaValueTexts[12].text = mediaLevel2PreReq2[12];
                mediaValueTexts[13].text = mediaLevel2PreReq2[13];
                break;

            case 31:
                mediaValueTexts[0].text = mediaLevel3PreReq1[0];
                mediaValueTexts[1].text = mediaLevel3PreReq1[1];
                mediaValueTexts[2].text = mediaLevel3PreReq1[2];
                mediaValueTexts[3].text = mediaLevel3PreReq1[3];
                mediaValueTexts[4].text = mediaLevel3PreReq1[4];
                mediaValueTexts[5].text = mediaLevel3PreReq1[5];
                mediaValueTexts[6].text = mediaLevel3PreReq1[6];
                mediaValueTexts[7].text = mediaLevel3PreReq1[7];
                mediaValueTexts[8].text = mediaLevel3PreReq1[8];
                mediaValueTexts[9].text = mediaLevel3PreReq1[9];
                mediaValueTexts[10].text = mediaLevel3PreReq1[10];
                mediaValueTexts[11].text = mediaLevel3PreReq1[11];
                mediaValueTexts[12].text = mediaLevel3PreReq1[12];
                mediaValueTexts[13].text = mediaLevel3PreReq1[13];
                break;
            case 32:
                mediaValueTexts[0].text = mediaLevel3PreReq2[0];
                mediaValueTexts[1].text = mediaLevel3PreReq2[1];
                mediaValueTexts[2].text = mediaLevel3PreReq2[2];
                mediaValueTexts[3].text = mediaLevel3PreReq2[3];
                mediaValueTexts[4].text = mediaLevel3PreReq2[4];
                mediaValueTexts[5].text = mediaLevel3PreReq2[5];
                mediaValueTexts[6].text = mediaLevel3PreReq2[6];
                mediaValueTexts[7].text = mediaLevel3PreReq2[7];
                mediaValueTexts[8].text = mediaLevel3PreReq2[8];
                mediaValueTexts[9].text = mediaLevel3PreReq2[9];
                mediaValueTexts[10].text = mediaLevel3PreReq2[10];
                mediaValueTexts[11].text = mediaLevel3PreReq2[11];
                mediaValueTexts[12].text = mediaLevel3PreReq2[12];
                mediaValueTexts[13].text = mediaLevel3PreReq2[13];
                break;

            case 41:
                mediaValueTexts[0].text = mediaLevel4PreReq1[0];
                mediaValueTexts[1].text = mediaLevel4PreReq1[1];
                mediaValueTexts[2].text = mediaLevel4PreReq1[2];
                mediaValueTexts[3].text = mediaLevel4PreReq1[3];
                mediaValueTexts[4].text = mediaLevel4PreReq1[4];
                mediaValueTexts[5].text = mediaLevel4PreReq1[5];
                mediaValueTexts[6].text = mediaLevel4PreReq1[6];
                mediaValueTexts[7].text = mediaLevel4PreReq1[7];
                mediaValueTexts[8].text = mediaLevel4PreReq1[8];
                mediaValueTexts[9].text = mediaLevel4PreReq1[9];
                mediaValueTexts[10].text = mediaLevel4PreReq1[10];
                mediaValueTexts[11].text = mediaLevel4PreReq1[11];
                mediaValueTexts[12].text = mediaLevel4PreReq1[12];
                mediaValueTexts[13].text = mediaLevel4PreReq1[13];
                break;
            case 42:
                mediaValueTexts[0].text = mediaLevel4PreReq2[0];
                mediaValueTexts[1].text = mediaLevel4PreReq2[1];
                mediaValueTexts[2].text = mediaLevel4PreReq2[2];
                mediaValueTexts[3].text = mediaLevel4PreReq2[3];
                mediaValueTexts[4].text = mediaLevel4PreReq2[4];
                mediaValueTexts[5].text = mediaLevel4PreReq2[5];
                mediaValueTexts[6].text = mediaLevel4PreReq2[6];
                mediaValueTexts[7].text = mediaLevel4PreReq2[7];
                mediaValueTexts[8].text = mediaLevel4PreReq2[8];
                mediaValueTexts[9].text = mediaLevel4PreReq2[9];
                mediaValueTexts[10].text = mediaLevel4PreReq2[10];
                mediaValueTexts[11].text = mediaLevel4PreReq2[11];
                mediaValueTexts[12].text = mediaLevel4PreReq2[12];
                mediaValueTexts[13].text = mediaLevel4PreReq2[13];
                break;
            default:
                break;
        }


        preReqMediaPanel.SetActive(true);
    }


    public void onRetailMediaIotaButtonClick(int levelnumber)
    {
        switch (levelnumber)
        {
            case 11:
                retailValueTexts[0].text = retailLevel1PreReq1[0];
                retailValueTexts[1].text = retailLevel1PreReq1[1];
                retailValueTexts[2].text = retailLevel1PreReq1[2];
                retailValueTexts[3].text = retailLevel1PreReq1[3];
                retailValueTexts[4].text = retailLevel1PreReq1[4];
                retailValueTexts[5].text = retailLevel1PreReq1[5];
                retailValueTexts[6].text = retailLevel1PreReq1[6];
                retailValueTexts[7].text = retailLevel1PreReq1[7];
                retailValueTexts[8].text = retailLevel1PreReq1[8];
                retailValueTexts[9].text = retailLevel1PreReq1[9];
                retailValueTexts[10].text = retailLevel1PreReq1[10];
                retailValueTexts[11].text = retailLevel1PreReq1[11];
                retailValueTexts[12].text = retailLevel1PreReq1[12];
                retailValueTexts[13].text = retailLevel1PreReq1[13];
                break;
            case 12:
                retailValueTexts[0].text = retailLevel1PreReq2[0];
                retailValueTexts[1].text = retailLevel1PreReq2[1];
                retailValueTexts[2].text = retailLevel1PreReq2[2];
                retailValueTexts[3].text = retailLevel1PreReq2[3];
                retailValueTexts[4].text = retailLevel1PreReq2[4];
                retailValueTexts[5].text = retailLevel1PreReq2[5];
                retailValueTexts[6].text = retailLevel1PreReq2[6];
                retailValueTexts[7].text = retailLevel1PreReq2[7];
                retailValueTexts[8].text = retailLevel1PreReq2[8];
                retailValueTexts[9].text = retailLevel1PreReq2[9];
                retailValueTexts[10].text = retailLevel1PreReq2[10];
                retailValueTexts[11].text = retailLevel1PreReq2[11];
                retailValueTexts[12].text = retailLevel1PreReq2[12];
                retailValueTexts[13].text = retailLevel1PreReq2[13];
                break;


            case 21:
                retailValueTexts[0].text = retailLevel2PreReq1[0];
                retailValueTexts[1].text = retailLevel2PreReq1[1];
                retailValueTexts[2].text = retailLevel2PreReq1[2];
                retailValueTexts[3].text = retailLevel2PreReq1[3];
                retailValueTexts[4].text = retailLevel2PreReq1[4];
                retailValueTexts[5].text = retailLevel2PreReq1[5];
                retailValueTexts[6].text = retailLevel2PreReq1[6];
                retailValueTexts[7].text = retailLevel2PreReq1[7];
                retailValueTexts[8].text = retailLevel2PreReq1[8];
                retailValueTexts[9].text = retailLevel2PreReq1[9];
                retailValueTexts[10].text = retailLevel2PreReq1[10];
                retailValueTexts[11].text = retailLevel2PreReq1[11];
                retailValueTexts[12].text = retailLevel2PreReq1[12];
                retailValueTexts[13].text = retailLevel2PreReq1[13];
                break;
            case 22:
                retailValueTexts[0].text = retailLevel2PreReq2[0];
                retailValueTexts[1].text = retailLevel2PreReq2[1];
                retailValueTexts[2].text = retailLevel2PreReq2[2];
                retailValueTexts[3].text = retailLevel2PreReq2[3];
                retailValueTexts[4].text = retailLevel2PreReq2[4];
                retailValueTexts[5].text = retailLevel2PreReq2[5];
                retailValueTexts[6].text = retailLevel2PreReq2[6];
                retailValueTexts[7].text = retailLevel2PreReq2[7];
                retailValueTexts[8].text = retailLevel2PreReq2[8];
                retailValueTexts[9].text = retailLevel2PreReq2[9];
                retailValueTexts[10].text = retailLevel2PreReq2[10];
                retailValueTexts[11].text = retailLevel2PreReq2[11];
                retailValueTexts[12].text = retailLevel2PreReq2[12];
                retailValueTexts[13].text = retailLevel2PreReq2[13];
                break;

            case 31:
                retailValueTexts[0].text = retailLevel3PreReq1[0];
                retailValueTexts[1].text = retailLevel3PreReq1[1];
                retailValueTexts[2].text = retailLevel3PreReq1[2];
                retailValueTexts[3].text = retailLevel3PreReq1[3];
                retailValueTexts[4].text = retailLevel3PreReq1[4];
                retailValueTexts[5].text = retailLevel3PreReq1[5];
                retailValueTexts[6].text = retailLevel3PreReq1[6];
                retailValueTexts[7].text = retailLevel3PreReq1[7];
                retailValueTexts[8].text = retailLevel3PreReq1[8];
                retailValueTexts[9].text = retailLevel3PreReq1[9];
                retailValueTexts[10].text = retailLevel3PreReq1[10];
                retailValueTexts[11].text = retailLevel3PreReq1[11];
                retailValueTexts[12].text = retailLevel3PreReq1[12];
                retailValueTexts[13].text = retailLevel3PreReq1[13];
                break;
            case 32:
                retailValueTexts[0].text = retailLevel3PreReq2[0];
                retailValueTexts[1].text = retailLevel3PreReq2[1];
                retailValueTexts[2].text = retailLevel3PreReq2[2];
                retailValueTexts[3].text = retailLevel3PreReq2[3];
                retailValueTexts[4].text = retailLevel3PreReq2[4];
                retailValueTexts[5].text = retailLevel3PreReq2[5];
                retailValueTexts[6].text = retailLevel3PreReq2[6];
                retailValueTexts[7].text = retailLevel3PreReq2[7];
                retailValueTexts[8].text = retailLevel3PreReq2[8];
                retailValueTexts[9].text = retailLevel3PreReq2[9];
                retailValueTexts[10].text = retailLevel3PreReq2[10];
                retailValueTexts[11].text = retailLevel3PreReq2[11];
                retailValueTexts[12].text = retailLevel3PreReq2[12];
                retailValueTexts[13].text = retailLevel3PreReq2[13];
                break;

            case 4:
                retailValueTexts[0].text = retailLevel4PreReq[0];
                retailValueTexts[1].text = retailLevel4PreReq[1];
                retailValueTexts[2].text = retailLevel4PreReq[2];
                retailValueTexts[3].text = retailLevel4PreReq[3];
                retailValueTexts[4].text = retailLevel4PreReq[4];
                retailValueTexts[5].text = retailLevel4PreReq[5];
                retailValueTexts[6].text = retailLevel4PreReq[6];
                retailValueTexts[7].text = retailLevel4PreReq[7];
                retailValueTexts[8].text = retailLevel4PreReq[8];
                retailValueTexts[9].text = retailLevel4PreReq[9];
                retailValueTexts[10].text = retailLevel4PreReq[10];
                retailValueTexts[11].text = retailLevel4PreReq[11];
                retailValueTexts[12].text = retailLevel4PreReq[12];
                retailValueTexts[13].text = retailLevel4PreReq[13];
                break;
            default:
                break;
        }


        preReqRetailPanel.SetActive(true);
    }




    public void newAccountancyFlow()
    {
        //int counter = 0;
        //instance.CurrentPlayer.Skills.Accountacy[0].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[1].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[2].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[3].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[4].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[5].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[6].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[7].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[8].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[9].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[10].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[11].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[12].Cost = 6;
        //instance.CurrentPlayer.Skills.Accountacy[13].Cost = 6;

        Debug.Log(instance.CurrentPlayer.Skills.Accountacy[0].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Accountacy[2].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Accountacy[3].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Accountacy[4].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Accountacy[5].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Accountacy[6].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Accountacy[7].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Accountacy[10].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Accountacy[11].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Accountacy[12].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Accountacy[13].Cost);


        //////////////////// To Copy /////////////////////
        //if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[1].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[2].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.Retail[3].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[4].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.Retail[5].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[6].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[7].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.Retail[8].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[9].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.Retail[10].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[11].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[12].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[13].Cost >= 3
        //    )


        //if (instance.CurrentPlayer.Skills.Accountacy[0].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[1].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[2].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[3].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[4].Cost - 4 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[5].Cost - 1 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[6].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[7].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[8].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[9].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[10].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[11].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[12].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Accountacy[13].Cost - 2 >= 1) counter++;

        //if (counter == 12)
        //{
        //    // 15% //
        //    Debug.Log("15% increment");

        //}
        //else if (counter > 0)
        //{
        //    Debug.Log("5% Increment");
        //}
        //else
        //{
        //    Debug.Log("Basic");
        //}


        //////////////////////// Copy Phase Ended ///////////////////

        Debug.Log("Accountancy Function Running");
        if (instance.CurrentPlayer.Skills.Accountacy[0].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Accountacy[2].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Accountacy[3].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Accountacy[4].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Accountacy[5].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Accountacy[6].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Accountacy[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Accountacy[10].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Accountacy[11].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Accountacy[12].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Accountacy[13].Cost >= 3
            )
        {
            int counter = 0;
            
            if (instance.CurrentPlayer.Skills.Accountacy[0].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[2].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[3].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[4].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[5].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[6].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[10].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[11].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[12].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[13].Cost - 3 >= 1) counter++;


            accountancySalary0 = 3000;
            if (counter == 11)
            {
                accountancySalary0 += accountancySalary0 * 0.15f;
                Debug.Log("15% increment");

            }
            else if (counter > 0)
            {
                accountancySalary0 += accountancySalary0 * 0.05f;
                Debug.Log("5% Increment");
            }
            else
            {
                accountancySalary0 = 3000;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 1 Management Accounting job");
            level1Man = true;
        }

        if (instance.CurrentPlayer.Skills.Accountacy[0].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.Accountacy[1].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[2].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[4].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[5].Cost >= 3 &&
                 instance.CurrentPlayer.Skills.Accountacy[6].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.Accountacy[7].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[8].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.Accountacy[9].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[10].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[11].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.Accountacy[12].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[13].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Accountacy[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[2].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[4].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[5].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[6].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[7].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[10].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[13].Cost - 5 >= 1) counter++;

            accountancySalary1 = 9000;
            if (counter == 13) {
                accountancySalary1 += accountancySalary1 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                accountancySalary1 += accountancySalary1 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                accountancySalary1 = 9000;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 2 Management Accounting job");
            level2Man = true;
        }

        if (instance.CurrentPlayer.Skills.Accountacy[0].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[1].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[2].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[5].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.Accountacy[7].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[8].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[10].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[11].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Accountacy[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[2].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[10].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[13].Cost - 6 >= 1) counter++;

            accountancySalary2 = 14000;
            if (counter == 9) {
                accountancySalary2 += accountancySalary2 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                accountancySalary2 += accountancySalary2 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                accountancySalary2 = 14000;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 3 Management Accounting job");
            level3Man = true;
        }

        if (instance.CurrentPlayer.Skills.Accountacy[2].Cost >= 3 &&
                 instance.CurrentPlayer.Skills.Accountacy[3].Cost >= 2 &&
                 instance.CurrentPlayer.Skills.Accountacy[4].Cost >= 3 &&
                 instance.CurrentPlayer.Skills.Accountacy[5].Cost >= 3 &&
                 instance.CurrentPlayer.Skills.Accountacy[7].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.Accountacy[8].Cost >= 2 &&
                 instance.CurrentPlayer.Skills.Accountacy[9].Cost >= 2 &&
                 instance.CurrentPlayer.Skills.Accountacy[10].Cost >= 3 &&
                 instance.CurrentPlayer.Skills.Accountacy[11].Cost >= 2 &&
                 instance.CurrentPlayer.Skills.Accountacy[12].Cost >= 3 &&
                 instance.CurrentPlayer.Skills.Accountacy[13].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Accountacy[2].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[3].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[4].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[5].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[8].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[9].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[10].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[11].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[12].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[13].Cost - 3 >= 1) counter++;

            accountancySalary3 = 4500;
            if (counter == 11) {
                accountancySalary3 += accountancySalary3 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                accountancySalary3 += accountancySalary3 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                accountancySalary3 = 4500;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 1 Financial Accounting job");
            level1Fin = true;
        }

        if (instance.CurrentPlayer.Skills.Accountacy[0].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.Accountacy[1].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[2].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[4].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[5].Cost >= 3 &&
                 instance.CurrentPlayer.Skills.Accountacy[7].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[8].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.Accountacy[9].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[10].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[11].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.Accountacy[12].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[13].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Accountacy[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[2].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[4].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[5].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[7].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[10].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[13].Cost - 5 >= 1) counter++;

            accountancySalary4 = 8000;
            if (counter == 12) {
                accountancySalary4 += accountancySalary4 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                accountancySalary4 += accountancySalary4 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                accountancySalary4 = 8000;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 2 Financial Accounting job");
            level2Fin = true;
        }

        if (instance.CurrentPlayer.Skills.Accountacy[0].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[1].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[2].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[3].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[4].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[5].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.Accountacy[6].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[7].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[8].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[9].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[10].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[11].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.Accountacy[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Accountacy[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[3].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[6].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[9].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[10].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[13].Cost - 6 >= 1) counter++;

            accountancySalary5 = 12500;
            if (counter == 13) {
                accountancySalary5 += accountancySalary5 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                accountancySalary5 += accountancySalary5 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                accountancySalary5 = 12500;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 3 Financial Accounting job");
            level3Fin = true;
        }

        if (instance.CurrentPlayer.Skills.Accountacy[0].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[1].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[2].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[3].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[4].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[5].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.Accountacy[6].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[7].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[8].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[9].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[10].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[11].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.Accountacy[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Accountacy[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[3].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[6].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[8].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[9].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[10].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[11].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Accountacy[13].Cost - 6 >= 1) counter++;

            accountancySalary6 = 18000;
            if (counter == 13) {
                accountancySalary6 += accountancySalary6 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                accountancySalary6 += accountancySalary6 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                accountancySalary6 = 18000;
                Debug.Log("Basic");
            }
            chiefFin = true;
            Debug.Log("You are eligible for Chief Financial Accounting job");
        }

        foreach (var item in allAccountancyJobsButtons)
        {
            item.GetComponent<Button>().interactable = false;
        }

        if (level1Man)
        {
            allAccountancyJobsButtons[0].GetComponent<Button>().interactable = true;
            allAccountancyJobsButtons[0].transform.GetChild(0).GetComponent<Text>().text = accountancySalary0.ToString();
            Debug.Log("1st button on");
        }
        if (level2Man)
        {
            allAccountancyJobsButtons[1].GetComponent<Button>().interactable = true;
            allAccountancyJobsButtons[1].transform.GetChild(0).GetComponent<Text>().text = accountancySalary1.ToString();
            Debug.Log("2nd button on");
        }
        if (level3Man)
        {
            allAccountancyJobsButtons[2].GetComponent<Button>().interactable = true;
            allAccountancyJobsButtons[2].transform.GetChild(0).GetComponent<Text>().text = accountancySalary2.ToString();
        }
        if (level1Fin)
        {
            allAccountancyJobsButtons[3].GetComponent<Button>().interactable = true;
            allAccountancyJobsButtons[3].transform.GetChild(0).GetComponent<Text>().text = accountancySalary3.ToString();
        }
        if (level2Fin)
        {
            allAccountancyJobsButtons[4].GetComponent<Button>().interactable = true;
            allAccountancyJobsButtons[4].transform.GetChild(0).GetComponent<Text>().text = accountancySalary4.ToString();

        }
        if (level3Fin)
        {
            allAccountancyJobsButtons[5].GetComponent<Button>().interactable = true;
            allAccountancyJobsButtons[5].transform.GetChild(0).GetComponent<Text>().text = accountancySalary5.ToString();

        }
        if (chiefFin)
        {
            allAccountancyJobsButtons[6].GetComponent<Button>().interactable = true;
            allAccountancyJobsButtons[6].transform.GetChild(0).GetComponent<Text>().text = accountancySalary6.ToString();

        }
    }

    public void healthCareJobEligibilityCheckFlow()
    {
        //int counter = 0;
        //instance.CurrentPlayer.Skills.HealtCare[0].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[1].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[2].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[3].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[4].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[5].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[6].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[7].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[8].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[9].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[10].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[11].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[12].Cost = 6;
        //instance.CurrentPlayer.Skills.HealtCare[13].Cost = 6;

        Debug.Log(instance.CurrentPlayer.Skills.HealtCare[0].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HealtCare[2].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HealtCare[3].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HealtCare[4].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HealtCare[5].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HealtCare[6].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HealtCare[7].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HealtCare[10].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HealtCare[11].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HealtCare[12].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HealtCare[13].Cost);


        //////////////////// To Copy /////////////////////
        //if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[1].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[2].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.Retail[3].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[4].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.Retail[5].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[6].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[7].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.Retail[8].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[9].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.Retail[10].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[11].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[12].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[13].Cost >= 3
        //    )


        //if (instance.CurrentPlayer.Skills.HealtCare[0].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[1].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[2].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[3].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[4].Cost - 4 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[5].Cost - 1 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[6].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[7].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[8].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[9].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[10].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[11].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[12].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HealtCare[13].Cost - 2 >= 1) counter++;

        //if (counter == 12)
        //{
        //    // 15% //
        //    Debug.Log("15% increment");

        //}
        //else if (counter > 0)
        //{
        //    Debug.Log("5% Increment");
        //}
        //else
        //{
        //    Debug.Log("Basic");
        //}


        //////////////////////// Copy Phase Ended ///////////////////


        Debug.Log("Health Care Function Running");
        if (instance.CurrentPlayer.Skills.HealtCare[0].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HealtCare[1].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HealtCare[2].Cost >= 2 &&
            instance.CurrentPlayer.Skills.HealtCare[3].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HealtCare[4].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HealtCare[5].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HealtCare[7].Cost >= 2 &&
            instance.CurrentPlayer.Skills.HealtCare[8].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HealtCare[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HealtCare[10].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HealtCare[11].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HealtCare[12].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HealtCare[13].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HealtCare[0].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[1].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[2].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[3].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[4].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[5].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[7].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[8].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[10].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[11].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[12].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[13].Cost - 3 >= 1) counter++;

            heathCareSalary0 = 3670;
            if (counter == 13) {
                heathCareSalary0 += heathCareSalary0 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                heathCareSalary0 += heathCareSalary0 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                heathCareSalary0 = 3670;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 1 Physiotherapist job");
            healthCareLevel1PhysiotherapistJob = true;
        }

        if (instance.CurrentPlayer.Skills.HealtCare[0].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[1].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[2].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[3].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[4].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[5].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[6].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[7].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[8].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[9].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[10].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[11].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[12].Cost >= 4 &&
                 instance.CurrentPlayer.Skills.HealtCare[13].Cost >= 4
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HealtCare[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[1].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[2].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[3].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[4].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[6].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[12].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[13].Cost - 4 >= 1) counter++;

            heathCareSalary1 = 4930;
            if (counter == 14) {
                heathCareSalary1 += heathCareSalary1 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                heathCareSalary1 += heathCareSalary1 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                heathCareSalary1 = 4930;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 2 Senior Physiotherapist job");
            healthCareLevel2SeniorPhysiotherapistJob = true;
        }

        if (instance.CurrentPlayer.Skills.HealtCare[0].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[1].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[2].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[3].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[5].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[6].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[7].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[8].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[9].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[10].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[11].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[12].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HealtCare[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[3].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[5].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[10].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[12].Cost - 5 >= 1) counter++;

            heathCareSalary2 = 7105;
            if (counter == 12) {
                heathCareSalary2 += heathCareSalary2 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                heathCareSalary2 += heathCareSalary2 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                heathCareSalary2 = 7105;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 3 Principal Physiotherapist Clinical job");
            healthCareLevel3PrincipalPhysiotherapistClinicalJob = true;
        }

        if (instance.CurrentPlayer.Skills.HealtCare[0].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[1].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[2].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[3].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[4].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[5].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[6].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[8].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[9].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[10].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[11].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[12].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HealtCare[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[3].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[5].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[6].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[8].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[10].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[11].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[12].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[13].Cost - 6 >= 1) counter++;

            heathCareSalary3 = 9530;
            if (counter == 13) {
                heathCareSalary3 += heathCareSalary3 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                heathCareSalary3 += heathCareSalary3 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                heathCareSalary3 = 9530;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 4 Senior Principal Physiotherapist Clinical job");
            healthCareLevel4SeniorPrincipalPhysiotherapistClinicaljob = true;
        }

        if (instance.CurrentPlayer.Skills.HealtCare[0].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[1].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[2].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[3].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[4].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[5].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[6].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[7].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[8].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[9].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[10].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[11].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[12].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[13].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HealtCare[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[3].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[4].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[5].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[10].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[13].Cost - 5 >= 1) counter++;

            heathCareSalary4 = 7105;
            if (counter == 14) {
                heathCareSalary4 += heathCareSalary4 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                heathCareSalary4 += heathCareSalary4 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                heathCareSalary4 = 7105;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 3 Principal Physiotherapy Educator job");
            healthCareLevel3PrincipalPhysiotherapyEducator = true;
        }

        if (instance.CurrentPlayer.Skills.HealtCare[0].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[1].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[2].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[3].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[4].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[5].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[6].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[8].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[9].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[10].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[11].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[12].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HealtCare[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[3].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[5].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[6].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[8].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[10].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[11].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[12].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[13].Cost - 6 >= 1) counter++;

            heathCareSalary5 = 9530;
            if (counter == 13) {
                heathCareSalary5 += heathCareSalary5 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                heathCareSalary5 += heathCareSalary5 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                heathCareSalary5 = 9530;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 4 Senior Principal Physiotherapy Educator job");
            healthCareLevel4SeniorPrincipalPhysiotherapyEducatorjob = true;
        }

        if (instance.CurrentPlayer.Skills.HealtCare[0].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[1].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[2].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[3].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[4].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[5].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[6].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[7].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[8].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[9].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[10].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[11].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[12].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[13].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HealtCare[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[3].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[4].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[5].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[10].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[13].Cost - 5 >= 1) counter++;

            heathCareSalary6 = 7105;
            if (counter == 14) {
                heathCareSalary6 += heathCareSalary6 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                heathCareSalary6 += heathCareSalary6 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                heathCareSalary6 = 7105;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 3 Principal Physiotherapy Researcher job");
            healthCareLevel3PrincipalPhysiotherapyResearcherJob = true;
        }

        if (instance.CurrentPlayer.Skills.HealtCare[0].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[1].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[2].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[3].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[4].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[5].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[6].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[8].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[9].Cost >= 5 &&
                 instance.CurrentPlayer.Skills.HealtCare[10].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[11].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[12].Cost >= 6 &&
                 instance.CurrentPlayer.Skills.HealtCare[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HealtCare[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[3].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[5].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[6].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[8].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[10].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[11].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[12].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HealtCare[13].Cost - 6 >= 1) counter++;

            heathCareSalary7 = 9530;
            if (counter == 13) {
                heathCareSalary7 += heathCareSalary7 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                heathCareSalary7 += heathCareSalary7 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                heathCareSalary7 = 9530;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 4 Senior Principal Physiotherapy Researcher job");
            healthCareLevel4SeniorPrincipalPhysiotherapyResearcherJob = true;
        }

        

        foreach (var item in allHealthCareJobsButtons)
        {
            item.GetComponent<Button>().interactable = false;
        }

        if (healthCareLevel1PhysiotherapistJob)
        {
            allHealthCareJobsButtons[0].GetComponent<Button>().interactable = true;
            allHealthCareJobsButtons[0].transform.GetChild(0).GetComponent<Text>().text = heathCareSalary0.ToString();
            Debug.Log("1st button on");
        }
        if (healthCareLevel2SeniorPhysiotherapistJob)
        {
            allHealthCareJobsButtons[1].GetComponent<Button>().interactable = true;
            allHealthCareJobsButtons[1].transform.GetChild(0).GetComponent<Text>().text = heathCareSalary1.ToString();
            Debug.Log("2nd button on");
        }
        if (healthCareLevel3PrincipalPhysiotherapistClinicalJob)
        {
            allHealthCareJobsButtons[2].GetComponent<Button>().interactable = true;
            allHealthCareJobsButtons[2].transform.GetChild(0).GetComponent<Text>().text = heathCareSalary2.ToString();
        }
        if (healthCareLevel4SeniorPrincipalPhysiotherapistClinicaljob)
        {
            allHealthCareJobsButtons[3].GetComponent<Button>().interactable = true;
            allHealthCareJobsButtons[3].transform.GetChild(0).GetComponent<Text>().text = heathCareSalary3.ToString();
        }
        if (healthCareLevel3PrincipalPhysiotherapyEducator)
        {
            allHealthCareJobsButtons[4].GetComponent<Button>().interactable = true;
            allHealthCareJobsButtons[4].transform.GetChild(0).GetComponent<Text>().text = heathCareSalary4.ToString();
        }
        if (healthCareLevel4SeniorPrincipalPhysiotherapyEducatorjob)
        {
            allHealthCareJobsButtons[5].GetComponent<Button>().interactable = true;
            allHealthCareJobsButtons[5].transform.GetChild(0).GetComponent<Text>().text = heathCareSalary5.ToString();
        }
        if (healthCareLevel3PrincipalPhysiotherapyResearcherJob)
        {
            allHealthCareJobsButtons[6].GetComponent<Button>().interactable = true;
            allHealthCareJobsButtons[6].transform.GetChild(0).GetComponent<Text>().text = heathCareSalary6.ToString();
        }
        if (healthCareLevel4SeniorPrincipalPhysiotherapyResearcherJob)
        {
            allHealthCareJobsButtons[7].GetComponent<Button>().interactable = true;
            allHealthCareJobsButtons[7].transform.GetChild(0).GetComponent<Text>().text = heathCareSalary7.ToString();
        }
    }

    public void hRJobEligibilityCheckFlow()
    {
        //int counter = 0;
        //instance.CurrentPlayer.Skills.HR[0].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[1].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[2].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[3].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[4].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[5].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[6].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[7].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[8].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[9].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[10].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[11].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[12].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[13].Cost = 6;
        //instance.CurrentPlayer.Skills.HR[14].Cost = 6;

        Debug.Log(instance.CurrentPlayer.Skills.HR[0].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HR[2].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HR[3].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HR[4].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HR[5].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HR[6].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HR[7].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HR[10].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HR[11].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HR[12].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HR[13].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.HR[14].Cost);


        //////////////////// To Copy /////////////////////
        //if (instance.CurrentPlayer.Skills.HR[0].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.HR[1].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.HR[2].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.HR[3].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.HR[4].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.HR[5].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.HR[6].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.HR[7].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.HR[8].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.HR[9].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.HR[10].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.HR[11].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.HR[12].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.HR[13].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.HR[14].Cost >= 3



        //if (instance.CurrentPlayer.Skills.HR[0].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[1].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[2].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[3].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[4].Cost - 4 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[5].Cost - 1 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[6].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[7].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[8].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[9].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[10].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[11].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[12].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[13].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.HR[14].Cost - 2 >= 1) counter++;

        //if (counter == 12)
        //{
        //    // 15% //
        //    Debug.Log("15% increment");

        //}
        //else if (counter > 0)
        //{
        //    Debug.Log("5% Increment");
        //}
        //else
        //{
        //    Debug.Log("Basic");
        //}

        //////////////////////// Copy Phase Ended ///////////////////

        Debug.Log("HR Function Running");
        if (instance.CurrentPlayer.Skills.HR[0].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[1].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[3].Cost >= 2 &&
            instance.CurrentPlayer.Skills.HR[4].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[5].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[6].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[7].Cost >= 2 &&
            instance.CurrentPlayer.Skills.HR[8].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[9].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[11].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[12].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[13].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[14].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HR[0].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[1].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[3].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[4].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[5].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[6].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[7].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[8].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[9].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[11].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[12].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[13].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[14].Cost - 3 >= 1) counter++;

            hrSalary0 = 5033;
            if (counter == 14) {
                hrSalary0 += hrSalary0 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                hrSalary0 += hrSalary0 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                hrSalary0 = 5033;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 1 Executive Performance and Rewards job");
            hRlevel1ExecutivePerformanceandRewardsjob = true;
        }

        if (instance.CurrentPlayer.Skills.HR[0].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[1].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[2].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[3].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[4].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[5].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[6].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[7].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[8].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[10].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[11].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[12].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[13].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[14].Cost >= 4
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HR[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[2].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[3].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[4].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[6].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[7].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[10].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[12].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[13].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[14].Cost - 4 >= 1) counter++;

            hrSalary1 = 9507;
            if (counter == 15) {
                hrSalary1 += hrSalary1 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                hrSalary1 += hrSalary1 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                hrSalary1 = 9507;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 2 Manager Performance and Rewards job");
            hRlevel2ManagerPerformanceandRewardsjob = true;
        }

        if (instance.CurrentPlayer.Skills.HR[0].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[1].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[2].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[3].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[4].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[5].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[8].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[9].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[10].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[11].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[12].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[13].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[14].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HR[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[2].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[3].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[4].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[5].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[10].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[13].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[14].Cost - 5 >= 1) counter++;

            hrSalary2 = 19514;
            if (counter == 14) {
                hrSalary2 += hrSalary2 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                hrSalary2 += hrSalary2 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                hrSalary2 = 19514;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 3 Head Performance and Rewards job");
            hRlevel3HeadPerformanceandRewardsjob = true;
        }

        if (instance.CurrentPlayer.Skills.HR[0].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[1].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[2].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[3].Cost >= 2 &&
            instance.CurrentPlayer.Skills.HR[5].Cost >= 2 &&
            instance.CurrentPlayer.Skills.HR[6].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[7].Cost >= 2 &&
            instance.CurrentPlayer.Skills.HR[8].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[9].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[11].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[12].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[13].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[14].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HR[0].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[1].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[2].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[3].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[5].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[6].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[7].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[8].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[9].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[11].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[12].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[13].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[14].Cost - 3 >= 1) counter++;

            hrSalary3 = 5192;
            if (counter == 14) {
                hrSalary3 += hrSalary3 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                hrSalary3 += hrSalary3 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                hrSalary3 = 5192;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 1 Executive Talent And Attraction job");
            hRLevel1ExecutiveTalentAndAttractionjob = true;
        }

        if (instance.CurrentPlayer.Skills.HR[0].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[1].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[2].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[3].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[4].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[5].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[6].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[7].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[8].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[11].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[12].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[13].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[14].Cost >= 4
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HR[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[2].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[3].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[4].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[5].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[6].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[7].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[12].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[13].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[14].Cost - 4 >= 1) counter++;

            hrSalary4 = 9701;
            if (counter == 14) {
                hrSalary4 += hrSalary4 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                hrSalary4 += hrSalary4 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                hrSalary4 = 9701;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for level 2 Manager Talent And Attraction job");
            hRlevel2ManagerTalentAndAttractionjob = true;
        }

        if (instance.CurrentPlayer.Skills.HR[0].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[1].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[2].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[3].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[4].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[5].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[6].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[8].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[9].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[11].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[12].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[13].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[14].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HR[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[2].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[3].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[4].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[13].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[14].Cost - 5 >= 1) counter++;

             hrSalary5 = 16114;
            if (counter == 14) {
                hrSalary5 += hrSalary5 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                hrSalary5 += hrSalary5 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                hrSalary5 = 16114;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 3 Head Talent And Attraction job");
            hRLevel3HeadTalentAndAttractionjob = true;
        }

        if (instance.CurrentPlayer.Skills.HR[0].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[1].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[2].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[3].Cost >= 2 &&
            instance.CurrentPlayer.Skills.HR[5].Cost >= 2 &&
            instance.CurrentPlayer.Skills.HR[6].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[7].Cost >= 2 &&
            instance.CurrentPlayer.Skills.HR[8].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[9].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[11].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[12].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[13].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[14].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HR[0].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[1].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[2].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[3].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[5].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[6].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[7].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[8].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[9].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[11].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[12].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[13].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[14].Cost - 3 >= 1) counter++;

             hrSalary6 = 5192;
            if (counter == 14) {
                hrSalary6 += hrSalary6 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                hrSalary6 += hrSalary6 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                hrSalary6 = 5192;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 1 Executive Employee Experience And Reactions job");
            hRLevel1ExecutiveEmployeeExperienceAndReactionsjob = true;
        }

        if (instance.CurrentPlayer.Skills.HR[0].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[1].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[2].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[3].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[4].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[5].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[6].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[7].Cost >= 3 &&
            instance.CurrentPlayer.Skills.HR[8].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[11].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[13].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[14].Cost >= 4
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HR[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[2].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[3].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[4].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[5].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[6].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[7].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[13].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[14].Cost - 4 >= 1) counter++;

             hrSalary7 = 8677;
            if (counter == 14) {
                hrSalary7 += hrSalary7 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                hrSalary7 += hrSalary7 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                hrSalary7 = 8677;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 2 Manager Employee Experience And Relations job");
            hRLevel2ManagerEmployeeExperienceAndRelationsjob = true;
        }

        if (instance.CurrentPlayer.Skills.HR[0].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[2].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[3].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[4].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[5].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[6].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[8].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[9].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[10].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[11].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[13].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[14].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HR[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[2].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[3].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[4].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[10].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[13].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[14].Cost - 5 >= 1) counter++;

             hrSalary8 = 17555;
            if (counter == 13) {
                hrSalary8 += hrSalary8 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                hrSalary8 += hrSalary8 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                hrSalary8 = 17555;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 3 Head Employee Experience And Relations job");
            hRLevel3HeadEmployeeExperienceAndRelationsjob = true;
        }

        if (instance.CurrentPlayer.Skills.HR[0].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[1].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[2].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[3].Cost >= 4 &&
            instance.CurrentPlayer.Skills.HR[4].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[5].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[6].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[7].Cost >= 5 &&
            instance.CurrentPlayer.Skills.HR[9].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[11].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[12].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[13].Cost >= 6 &&
            instance.CurrentPlayer.Skills.HR[14].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.HR[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[2].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[3].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[4].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[5].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[7].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[9].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[11].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[12].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[13].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.HR[14].Cost - 6 >= 1) counter++;

             hrSalary9 = 23044;
            if (counter == 13) {
                hrSalary9 += hrSalary9 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                hrSalary9 += hrSalary9 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                hrSalary9 = 23044;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 4 Chief Human Resource Officer job");
            hRLevel4ChiefHumanResourceOfficerjob = true;
        }



        foreach (var item in allHrJobsButtons)
        {
            item.GetComponent<Button>().interactable = false;
        }

        if (hRlevel1ExecutivePerformanceandRewardsjob)
        {
            allHrJobsButtons[0].GetComponent<Button>().interactable = true;
            allHrJobsButtons[0].transform.GetChild(0).GetComponent<Text>().text = hrSalary0.ToString();
            Debug.Log("1st button on");
        }
        if (hRlevel2ManagerPerformanceandRewardsjob)
        {
            allHrJobsButtons[1].GetComponent<Button>().interactable = true;
            allHrJobsButtons[1].transform.GetChild(0).GetComponent<Text>().text = hrSalary1.ToString();
            Debug.Log("2nd button on");
        }
        if (hRlevel3HeadPerformanceandRewardsjob)
        {
            allHrJobsButtons[2].GetComponent<Button>().interactable = true;
            allHrJobsButtons[2].transform.GetChild(0).GetComponent<Text>().text = hrSalary2.ToString();
        }
        if (hRLevel1ExecutiveTalentAndAttractionjob)
        {
            allHrJobsButtons[3].GetComponent<Button>().interactable = true;
            allHrJobsButtons[0].transform.GetChild(0).GetComponent<Text>().text = hrSalary3.ToString();
        }
        if (hRlevel2ManagerTalentAndAttractionjob)
        {
            allHrJobsButtons[4].GetComponent<Button>().interactable = true;
            allHrJobsButtons[4].transform.GetChild(0).GetComponent<Text>().text = hrSalary4.ToString();
        }
        if (hRLevel3HeadTalentAndAttractionjob)
        {
            allHrJobsButtons[5].GetComponent<Button>().interactable = true;
            allHrJobsButtons[5].transform.GetChild(0).GetComponent<Text>().text = hrSalary5.ToString();
        }
        if (hRLevel1ExecutiveEmployeeExperienceAndReactionsjob)
        {
            allHrJobsButtons[6].GetComponent<Button>().interactable = true;
            allHrJobsButtons[6].transform.GetChild(0).GetComponent<Text>().text = hrSalary6.ToString();
        }
        if (hRLevel2ManagerEmployeeExperienceAndRelationsjob)
        {
            allHrJobsButtons[7].GetComponent<Button>().interactable = true;
            allHrJobsButtons[7].transform.GetChild(0).GetComponent<Text>().text = hrSalary7.ToString();
        }
        if (hRLevel3HeadEmployeeExperienceAndRelationsjob)
        {
            allHrJobsButtons[8].GetComponent<Button>().interactable = true;
            allHrJobsButtons[8].transform.GetChild(0).GetComponent<Text>().text = hrSalary8.ToString();
        }
        if (hRLevel4ChiefHumanResourceOfficerjob)
        {
            allHrJobsButtons[9].GetComponent<Button>().interactable = true;
            allHrJobsButtons[9].transform.GetChild(0).GetComponent<Text>().text = hrSalary9.ToString();
        }
    }

    public void ItJobEligibilityCheckFlow()
    {
        //int counter = 0;
        //instance.CurrentPlayer.Skills.IT[0].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[1].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[2].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[3].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[4].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[5].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[6].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[7].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[8].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[9].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[10].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[11].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[12].Cost = 6;
        //instance.CurrentPlayer.Skills.IT[13].Cost = 6;

        Debug.Log(instance.CurrentPlayer.Skills.IT[0].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.IT[2].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.IT[3].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.IT[4].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.IT[5].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.IT[6].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.IT[7].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.IT[10].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.IT[11].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.IT[12].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.IT[13].Cost);


        //////////////////// To Copy /////////////////////
        //if (instance.CurrentPlayer.Skills.IT[0].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.IT[1].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.IT[2].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.IT[3].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.IT[4].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.IT[5].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.IT[6].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.IT[7].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.IT[8].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.IT[9].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.IT[10].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.IT[11].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.IT[12].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.IT[13].Cost >= 3
        //    )

        //if (instance.CurrentPlayer.Skills.IT[0].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[1].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[2].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[3].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[4].Cost - 4 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[5].Cost - 1 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[6].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[7].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[8].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[9].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[10].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[11].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[12].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.IT[13].Cost - 2 >= 1) counter++;

        //if (counter == 12)
        //{
        //    // 15% //
        //    Debug.Log("15% increment");

        //}
        //else if (counter > 0)
        //{
        //    Debug.Log("5% Increment");
        //}
        //else
        //{
        //    Debug.Log("Basic");
        //}
        //////////////////////// Copy Phase Ended ///////////////////

        Debug.Log("IT Function Running");

        if (instance.CurrentPlayer.Skills.IT[1].Cost >= 2 &&
            instance.CurrentPlayer.Skills.IT[2].Cost >= 2 &&
            instance.CurrentPlayer.Skills.IT[5].Cost >= 3 &&
            instance.CurrentPlayer.Skills.IT[6].Cost >= 3 &&
            instance.CurrentPlayer.Skills.IT[8].Cost >= 3 &&
            instance.CurrentPlayer.Skills.IT[11].Cost >= 2 &&
            instance.CurrentPlayer.Skills.IT[13].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.IT[1].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[2].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[5].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[6].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[8].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[11].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[13].Cost - 3 >= 1) counter++;

             itSalary0 = 4000;
            if (counter == 7) {
                itSalary0 += itSalary0 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                itSalary0 += itSalary0 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                itSalary0 = 4000;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 1 Application Developer job");
            ItLevel1ApplicationDeveloperjob = true;
        }

        if (instance.CurrentPlayer.Skills.IT[0].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[1].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[2].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[5].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[6].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[8].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[11].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[13].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.IT[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[1].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[13].Cost - 3 >= 1) counter++;

             itSalary1 = 5500;
            if (counter == 10) {
                itSalary1 += itSalary1 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                itSalary1 += itSalary1 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                itSalary1 = 5500;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 2 Application Development Manager job");
            ItLevel2ApplicationDevelopmentManager = true;
        }

        if (instance.CurrentPlayer.Skills.IT[0].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[1].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[5].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[6].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[7].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[8].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[9].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[11].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[13].Cost >= 4
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.IT[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[5].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[8].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[13].Cost - 4 >= 1) counter++;

             itSalary2 = 9000;
            if (counter == 11) {
                itSalary2 += itSalary2 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                itSalary2 += itSalary2 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                itSalary2 = 9000;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 3 Application Architect job");
            iTLevel3ApplicationArchitectjob = true;
        }

        if (instance.CurrentPlayer.Skills.IT[0].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[1].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[2].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[5].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[9].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[10].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.IT[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[5].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[9].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[10].Cost - 6 >= 1) counter++;

             itSalary3 = 10000;
            if (counter == 6) {
                itSalary3 += itSalary3 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                itSalary3 += itSalary3 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                itSalary3 = 10000;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 4 Chief Technology Officer job");
            iTLevel4ChiefTechnologyOfficerjob = true;
        }

        if (instance.CurrentPlayer.Skills.IT[1].Cost >= 3 &&
            instance.CurrentPlayer.Skills.IT[2].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[3].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[10].Cost >= 2 &&
            instance.CurrentPlayer.Skills.IT[11].Cost >= 2 &&
            instance.CurrentPlayer.Skills.IT[12].Cost >= 3 &&
            instance.CurrentPlayer.Skills.IT[13].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.IT[1].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[3].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[10].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[11].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[12].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[13].Cost - 3 >= 1) counter++;

             itSalary4 = 4000;
            if (counter == 9) {
                itSalary4 += itSalary4 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                itSalary4 += itSalary4 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                itSalary4 = 4000;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 1 UX Designer job");
            iTLevel1UXDesignerjob = true;
        }

        if (instance.CurrentPlayer.Skills.IT[0].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[1].Cost >= 3 &&
            instance.CurrentPlayer.Skills.IT[2].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[3].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[7].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[10].Cost >= 3 &&
            instance.CurrentPlayer.Skills.IT[11].Cost >= 3 &&
            instance.CurrentPlayer.Skills.IT[12].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[13].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.IT[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[1].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[3].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[10].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[11].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[12].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[13].Cost - 3 >= 1) counter++;

             itSalary5 = 5500;
            if (counter == 10) {
                itSalary5 += itSalary5 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                itSalary5 += itSalary5 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                itSalary5 = 5500;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 2 Senior UX Designer job");
            ItLevel2SeniorUXDesignerjob = true;
        }

        if (instance.CurrentPlayer.Skills.IT[0].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[1].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[2].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[3].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[7].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[8].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[11].Cost >= 4 &&
            instance.CurrentPlayer.Skills.IT[12].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[13].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.IT[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[1].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[3].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[13].Cost - 3 >= 1) counter++;

             itSalary6 = 9000;
            if (counter == 12) {
                itSalary6 += itSalary6 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                itSalary6 += itSalary6 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                itSalary6 = 9000;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 3 Lead UX Desginer job");
            iTLevel3LeadUXDesginerjob = true;
        }

        if (instance.CurrentPlayer.Skills.IT[0].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[1].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[3].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[5].Cost >= 5 &&
            instance.CurrentPlayer.Skills.IT[6].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[9].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[10].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[12].Cost >= 6 &&
            instance.CurrentPlayer.Skills.IT[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.IT[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[3].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[5].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[6].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[9].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[10].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[12].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.IT[13].Cost - 6 >= 1) counter++;

             itSalary7 = 10000;
            if (counter == 10) {
                itSalary7 += itSalary7 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                itSalary7 += itSalary7 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                itSalary7 = 10000;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for Level 4 Head Of Product job");
            ItLevel4HeadOfProductjob = true;
        }



        foreach (var item in allItJobsButton)
        {
            item.GetComponent<Button>().interactable = false;
        }

        if (ItLevel1ApplicationDeveloperjob)
        {
            allItJobsButton[0].GetComponent<Button>().interactable = true;
            allItJobsButton[0].transform.GetChild(0).GetComponent<Text>().text = itSalary0.ToString();
            Debug.Log("1st button on");
        }
        if (ItLevel2ApplicationDevelopmentManager)
        {
            allItJobsButton[1].GetComponent<Button>().interactable = true;
            allItJobsButton[1].transform.GetChild(0).GetComponent<Text>().text = itSalary1.ToString();
            Debug.Log("2nd button on");
        }
        if (iTLevel3ApplicationArchitectjob)
        {
            allItJobsButton[2].GetComponent<Button>().interactable = true;
            allItJobsButton[2].transform.GetChild(0).GetComponent<Text>().text = itSalary2.ToString();
        }
        if (iTLevel4ChiefTechnologyOfficerjob)
        {
            allItJobsButton[3].GetComponent<Button>().interactable = true;
            allItJobsButton[3].transform.GetChild(0).GetComponent<Text>().text = itSalary3.ToString();
        }
        if (iTLevel1UXDesignerjob)
        {
            allItJobsButton[4].GetComponent<Button>().interactable = true;
            allItJobsButton[4].transform.GetChild(0).GetComponent<Text>().text = itSalary4.ToString();
        }
        if (ItLevel2SeniorUXDesignerjob)
        {
            allItJobsButton[5].GetComponent<Button>().interactable = true;
            allItJobsButton[5].transform.GetChild(0).GetComponent<Text>().text = itSalary5.ToString();
        }
        if (iTLevel3LeadUXDesginerjob)
        {
            allItJobsButton[6].GetComponent<Button>().interactable = true;
            allItJobsButton[6].transform.GetChild(0).GetComponent<Text>().text = itSalary6.ToString();
        }
        if (ItLevel4HeadOfProductjob)
        {
            allItJobsButton[7].GetComponent<Button>().interactable = true;
            allItJobsButton[7].transform.GetChild(0).GetComponent<Text>().text = itSalary7.ToString();
        }        
    }

    public void mediaJobEligibilityCheckFlow()
    {
        //int counter = 0;

        //instance.CurrentPlayer.Skills.Media[0].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[1].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[2].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[3].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[4].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[5].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[6].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[7].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[8].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[9].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[10].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[11].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[12].Cost = 6;
        //instance.CurrentPlayer.Skills.Media[13].Cost = 6;

        Debug.Log(instance.CurrentPlayer.Skills.Media[0].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Media[2].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Media[3].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Media[4].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Media[5].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Media[6].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Media[7].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Media[10].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Media[11].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Media[12].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Media[13].Cost);


        //////////////////// To Copy /////////////////////
        //if (instance.CurrentPlayer.Skills.Media[0].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Media[1].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Media[2].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.Media[3].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Media[4].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.Media[5].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Media[6].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Media[7].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.Media[8].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Media[9].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.Media[10].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Media[11].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Media[12].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Media[13].Cost >= 3
        //    )

        //if (instance.CurrentPlayer.Skills.Media[0].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[1].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[2].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[3].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[4].Cost - 4 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[5].Cost - 1 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[6].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[7].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[8].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[9].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[10].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[11].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[12].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Media[13].Cost - 2 >= 1) counter++;

        //if (counter == 12)
        //{
        //    // 15% //
        //    Debug.Log("15% increment");

        //}
        //else if (counter > 0)
        //{
        //    Debug.Log("5% Increment");
        //}
        //else
        //{
        //    Debug.Log("Basic");
        //}
        //////////////////////// Copy Phase Ended ///////////////////

        Debug.Log("Media Function Running");

        if (instance.CurrentPlayer.Skills.Media[0].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Media[1].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Media[3].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Media[5].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Media[10].Cost >= 1 &&
            instance.CurrentPlayer.Skills.Media[11].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Media[12].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Media[13].Cost >= 2
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Media[0].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[1].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[3].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[5].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[10].Cost - 1 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[11].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[12].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[13].Cost - 2 >= 1) counter++;

             mediaSalary0 = 3120;
            if (counter == 8) {
                mediaSalary0 += mediaSalary0 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                mediaSalary0 += mediaSalary0 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                mediaSalary0 = 3120;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for media Level 1 Production Assistant job");
            mediaLevel1ProductionAssistantjob = true;
        }

        if (instance.CurrentPlayer.Skills.Media[0].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[1].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Media[2].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[3].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Media[5].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[6].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Media[9].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Media[10].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Media[11].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Media[12].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Media[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[1].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[2].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[3].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[6].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[9].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[10].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[11].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[12].Cost - 3 >= 1) counter++;

             mediaSalary1 = 5158;
            if (counter == 10) {
                mediaSalary1 += mediaSalary1 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                mediaSalary1 += mediaSalary1 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                mediaSalary1 = 5158;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for media Level 2 Assistant Producer Broadcast job");
            mediaLevel2AssistantProducerBroadcastjob = true;
        }

        if (instance.CurrentPlayer.Skills.Media[1].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Media[2].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[3].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[4].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Media[6].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[11].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[12].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Media[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[3].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[4].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[6].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[12].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[13].Cost - 6 >= 1) counter++;

             mediaSalary2 = 5739;
            if (counter == 10) {
                mediaSalary2 += mediaSalary2 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                mediaSalary2 += mediaSalary2 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                mediaSalary2 = 5739;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for media Level 3 Producer Broadcast job");
            mediaLevel3ProducerBroadcastjob = true;
        }

        if (instance.CurrentPlayer.Skills.Media[0].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[1].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[2].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[3].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Media[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[6].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Media[9].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[12].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Media[13].Cost >= 4
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Media[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[3].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[9].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[13].Cost - 4 >= 1) counter++;

             mediaSalary3 = 10711;
            if (counter == 9) {
                mediaSalary3 += mediaSalary3 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                mediaSalary3 += mediaSalary3 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                mediaSalary3 = 10711;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for media Level 4 Executive Producer Broadcast job");
            mediaLevel4ExecutiveProducerBroadcastjob = true;
        }

        if (instance.CurrentPlayer.Skills.Media[0].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[2].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[5].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[6].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Media[7].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Media[8].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Media[11].Cost >= 2
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Media[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[2].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[6].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[7].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[8].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[11].Cost - 2 >= 1) counter++;

             mediaSalary4 = 3530;
            if (counter == 7) {
                mediaSalary4 += mediaSalary4 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                mediaSalary4 += mediaSalary4 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                mediaSalary4 = 3530;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for media Level 1 Reporter Correspondent job");
            mediaLevel1ReporterCorrespondentjob = true;
        }

        if (instance.CurrentPlayer.Skills.Media[0].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[5].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[6].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Media[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[8].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[9].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Media[11].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Media[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Media[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[5].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[6].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[9].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[11].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[13].Cost - 6 >= 1) counter++;

             mediaSalary5 = 6715;
            if (counter == 8) {
                mediaSalary5 += mediaSalary5 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                mediaSalary5 += mediaSalary5 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                mediaSalary5 = 6715;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for media Level 2 Senior Reporter Senior Correspondent job");
            mediaLevel2SeniorReporterSeniorCorrespondentjob = true;
        }

        if (instance.CurrentPlayer.Skills.Media[0].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[4].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Media[6].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[7].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Media[8].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Media[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[11].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Media[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Media[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[4].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[6].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[7].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[13].Cost - 6 >= 1) counter++;

             mediaSalary6 = 10227;
            if (counter == 9) {
                mediaSalary6 += mediaSalary6 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                mediaSalary6 += mediaSalary6 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                mediaSalary6 = 10227;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for media Level 3 Executive Editor job");
            mediaLevel3ExecutiveEditorjob = true;
        }

        if (instance.CurrentPlayer.Skills.Media[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[6].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Media[7].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[8].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Media[9].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Media[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[8].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Media[9].Cost - 5 >= 1) counter++;

             mediaSalary7 = 11000;
            if (counter == 5) {
                mediaSalary7 += mediaSalary7 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                mediaSalary7 += mediaSalary7 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                mediaSalary7 = 11000;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for media Level 4 Chief Editor job");
            mediaLevel4ChiefEditorjob = true;
        }



        foreach (var item in allMediaJobsButton)
        {
            item.GetComponent<Button>().interactable = false;
        }

        if (mediaLevel1ProductionAssistantjob)
        {
            allMediaJobsButton[0].GetComponent<Button>().interactable = true;
            allMediaJobsButton[0].transform.GetChild(0).GetComponent<Text>().text = mediaSalary0.ToString();
            Debug.Log("1st button on");
        }
        if (mediaLevel2AssistantProducerBroadcastjob)
        {
            allMediaJobsButton[1].GetComponent<Button>().interactable = true;
            allMediaJobsButton[1].transform.GetChild(0).GetComponent<Text>().text = mediaSalary1.ToString();
            Debug.Log("2nd button on");
        }
        if (mediaLevel3ProducerBroadcastjob)
        {
            allMediaJobsButton[2].GetComponent<Button>().interactable = true;
            allMediaJobsButton[2].transform.GetChild(0).GetComponent<Text>().text = mediaSalary2.ToString();
        }
        if (mediaLevel4ExecutiveProducerBroadcastjob)
        {
            allMediaJobsButton[3].GetComponent<Button>().interactable = true;
            allMediaJobsButton[3].transform.GetChild(0).GetComponent<Text>().text = mediaSalary3.ToString();
        }
        if (mediaLevel1ReporterCorrespondentjob)
        {
            allMediaJobsButton[4].GetComponent<Button>().interactable = true;
            allMediaJobsButton[4].transform.GetChild(0).GetComponent<Text>().text = mediaSalary4.ToString();
        }
        if (mediaLevel2SeniorReporterSeniorCorrespondentjob)
        {
            allMediaJobsButton[5].GetComponent<Button>().interactable = true;
            allMediaJobsButton[5].transform.GetChild(0).GetComponent<Text>().text = mediaSalary5.ToString();
        }
        if (mediaLevel3ExecutiveEditorjob)
        {
            allMediaJobsButton[6].GetComponent<Button>().interactable = true;
            allMediaJobsButton[6].transform.GetChild(0).GetComponent<Text>().text = mediaSalary6.ToString();
        }
        if (mediaLevel4ChiefEditorjob)
        {
            allMediaJobsButton[7].GetComponent<Button>().interactable = true;
            allMediaJobsButton[7].transform.GetChild(0).GetComponent<Text>().text = mediaSalary7.ToString();
        }        
    }

    public void retailJobEligibilityCheckFlow()
    {
        //instance.CurrentPlayer.Skills.Retail[0].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[1].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[2].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[3].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[4].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[5].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[6].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[7].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[8].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[9].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[10].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[11].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[12].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[13].Cost = 6;

        Debug.Log(instance.CurrentPlayer.Skills.Retail[0].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[2].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[3].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[4].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[5].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[6].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[7].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[10].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[11].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[12].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[13].Cost);

        //////////////////// To Copy /////////////////////
        //if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[1].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[2].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.Retail[3].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[4].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.Retail[5].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[6].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[7].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.Retail[8].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[9].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.Retail[10].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[11].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[12].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[13].Cost >= 3
        //    )


        //if (instance.CurrentPlayer.Skills.Retail[0].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[1].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[2].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[3].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[4].Cost - 4 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[5].Cost - 1 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[6].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[7].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[8].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[9].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[10].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[11].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[12].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[13].Cost - 2 >= 1) counter++;

        //if (counter == 12)
        //{
        //    // 15% //
        //    Debug.Log("15% increment");

        //}
        //else if (counter > 0)
        //{
        //    Debug.Log("5% Increment");
        //}
        //else
        //{
        //    Debug.Log("Basic");
        //}


        //////////////////////// Copy Phase Ended ///////////////////

        Debug.Log("Retail Function Running");

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 1 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 2
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 1 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 2 >= 1) counter++;

             retailSalary0 = 2400;
            if (counter == 14) {
                retailSalary0 += retailSalary0 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                retailSalary0 += retailSalary0 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                retailSalary0 = 2400;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retail Level 1 Brand Associate job");
            retailLevel1BrandAssociatejob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 4
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 4 >= 1) counter++;

             retailSalary1 = 6950;
            if (counter == 14) {
                retailSalary1 += retailSalary1 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                retailSalary1 += retailSalary1 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                retailSalary1 = 6950;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retail Level 2 Brand Manager job");
            retailLevel2BrandManagerjob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 5 >= 1) counter++;

             retailSalary2 = 17450;
            if (counter == 13) {
                retailSalary2 += retailSalary2 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                retailSalary2 += retailSalary2 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                retailSalary2 = 17450;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retail Level 3 Brand Director job");
            retailLevel3BrandDirectorjob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 3 >= 1) counter++;

             retailSalary3 = 3200;
            if (counter == 12) {
                retailSalary3 += retailSalary3 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                retailSalary3 += retailSalary3 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                retailSalary3 = 3200;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retail Level 1 Visual Merchandiser job");
            retailLevel1VisualMerchandiserjob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 4
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 4 >= 1) counter++;

             retailSalary4 = 6550;
            if (counter == 14) {
                retailSalary4 += retailSalary4 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                retailSalary4 += retailSalary4 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                retailSalary4 = 6550;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retial Level 2 Merchandising Manager job");
            retialLevel2MerchandisingManagerjob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 5 >= 1) counter++;

             retailSalary5 = 14100;
            if (counter == 14) {
                retailSalary5 += retailSalary5 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                retailSalary5 += retailSalary5 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                retailSalary5 = 14100;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retail Level 3 Merchandising Director job");
            retailLevel3MerchandisingDirectorjob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 6 >= 1) counter++;

             retailSalary6 = 32400;
            if (counter == 9) {
                retailSalary6 += retailSalary6 * 0.15f;
                Debug.Log("15% increment");

            } else if (counter > 0) {
                retailSalary6 += retailSalary6 * 0.05f;
                Debug.Log("5% Increment");
            } else {
                retailSalary6 = 32400;
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retail Level 4 Chief Executive Officer Managing Director job");
            retailLevel4ChiefExecutiveOfficerManagingDirectorjob = true;
        }

        

        foreach (var item in allRetailJobsButton)
        {
            item.GetComponent<Button>().interactable = false;
        }

        if (retailLevel1BrandAssociatejob)
        {
            allRetailJobsButton[0].GetComponent<Button>().interactable = true;
            allRetailJobsButton[0].transform.GetChild(0).GetComponent<Text>().text = retailSalary0.ToString();
            Debug.Log("1st button on");
        }
        if (retailLevel2BrandManagerjob)
        {
            allRetailJobsButton[1].GetComponent<Button>().interactable = true;
            allRetailJobsButton[1].transform.GetChild(0).GetComponent<Text>().text = retailSalary1.ToString();
            Debug.Log("2nd button on");
        }
        if (retailLevel3BrandDirectorjob)
        {
            allRetailJobsButton[2].GetComponent<Button>().interactable = true;
            allRetailJobsButton[2].transform.GetChild(0).GetComponent<Text>().text = retailSalary2.ToString();
        }
        if (retailLevel1VisualMerchandiserjob)
        {
            allRetailJobsButton[3].GetComponent<Button>().interactable = true;
            allRetailJobsButton[3].transform.GetChild(0).GetComponent<Text>().text = retailSalary3.ToString();
        }
        if (retialLevel2MerchandisingManagerjob)
        {
            allRetailJobsButton[4].GetComponent<Button>().interactable = true;
            allRetailJobsButton[4].transform.GetChild(0).GetComponent<Text>().text = retailSalary4.ToString();
        }
        if (retailLevel3MerchandisingDirectorjob)
        {
            allRetailJobsButton[5].GetComponent<Button>().interactable = true;
            allRetailJobsButton[5].transform.GetChild(0).GetComponent<Text>().text = retailSalary5.ToString();
        }
        if (retailLevel4ChiefExecutiveOfficerManagingDirectorjob)
        {
            allRetailJobsButton[6].GetComponent<Button>().interactable = true;
            allRetailJobsButton[6].transform.GetChild(0).GetComponent<Text>().text = retailSalary6.ToString();
        }       
    }

    public void retailJobEligibilityCheckFlowForTesting()
    {
        //instance.CurrentPlayer.Skills.Retail[0].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[1].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[2].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[3].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[4].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[5].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[6].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[7].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[8].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[9].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[10].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[11].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[12].Cost = 6;
        //instance.CurrentPlayer.Skills.Retail[13].Cost = 6;

        Debug.Log(instance.CurrentPlayer.Skills.Retail[0].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[2].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[3].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[4].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[5].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[6].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[7].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[10].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[11].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[12].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[13].Cost);
        Debug.Log(instance.CurrentPlayer.Skills.Retail[14].Cost);

        //////////////////// To Copy /////////////////////
        //if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[1].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[2].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.Retail[3].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[4].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.Retail[5].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[6].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[7].Cost >= 2 &&
        //    instance.CurrentPlayer.Skills.Retail[8].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[9].Cost >= 4 &&
        //    instance.CurrentPlayer.Skills.Retail[10].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[11].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[12].Cost >= 3 &&
        //    instance.CurrentPlayer.Skills.Retail[13].Cost >= 3
        //    )


        //if (instance.CurrentPlayer.Skills.Retail[0].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[1].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[2].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[3].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[4].Cost - 4 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[5].Cost - 1 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[6].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[7].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[8].Cost - 3 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[9].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[10].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[11].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[12].Cost - 2 >= 1) counter++;
        //if (instance.CurrentPlayer.Skills.Retail[13].Cost - 2 >= 1) counter++;

        //if (counter == 12)
        //{
        //    // 15% //
        //    Debug.Log("15% increment");

        //}
        //else if (counter > 0)
        //{
        //    Debug.Log("5% Increment");
        //}
        //else
        //{
        //    Debug.Log("Basic");
        //}


        //////////////////////// Copy Phase Ended ///////////////////

        Debug.Log("Retail Function Running");

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 1 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 2 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 2
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 1 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 2 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 2 >= 1) counter++;

            if (counter == 14)
            {
                // 15% //
                Debug.Log("15% increment");                

            }
            else if(counter > 0)
            {
                Debug.Log("100% increment");
            }
            else if (counter > 0)
            {
                Debug.Log("5% Increment");
            }
            else
            {
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retail Level 1 Brand Associate job");
            retailLevel1BrandAssociatejob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 4
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 4 >= 1) counter++;

            if (counter == 14)
            {
                // 15% //
                Debug.Log("15% increment");

            }
            else if (counter > 0)
            {
                Debug.Log("5% Increment");
            }
            else
            {
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retail Level 2 Brand Manager job");
            retailLevel2BrandManagerjob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 5 >= 1) counter++;

            if (counter == 13)
            {
                // 15% //
                Debug.Log("15% increment");

            }
            else if (counter > 0)
            {
                Debug.Log("5% Increment");
            }
            else
            {
                Debug.Log("Basic");
                Debug.Log("You will be given no increment");
            }
            Debug.Log("You are eligible for retail Level 3 Brand Director job");
            retailLevel3BrandDirectorjob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 3 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 3
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 3 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 3 >= 1) counter++;

            if (counter == 12)
            {
                // 15% //
                Debug.Log("15% increment");

            }
            else if (counter > 0)
            {
                Debug.Log("5% Increment");
            }
            else
            {
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retail Level 1 Visual Merchandiser job");
            retailLevel1VisualMerchandiserjob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 4 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 4
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 4 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 4 >= 1) counter++;

            if (counter == 14)
            {
                // 15% //
                Debug.Log("15% increment");

            }
            else if (counter > 0)
            {
                Debug.Log("5% Increment");
            }
            else
            {
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retial Level 2 Merchandising Manager job");
            retialLevel2MerchandisingManagerjob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[6].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[8].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[10].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[11].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[12].Cost >= 5 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 5
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[6].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[8].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[10].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[11].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[12].Cost - 5 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 5 >= 1) counter++;

            if (counter == 14)
            {
                // 15% //
                Debug.Log("15% increment");

            }
            else if (counter > 0)
            {
                Debug.Log("5% Increment");
            }
            else
            {
                Debug.Log("Basic");
            }
            Debug.Log("You are eligible for retail Level 3 Merchandising Director job");
            retailLevel3MerchandisingDirectorjob = true;
        }

        if (instance.CurrentPlayer.Skills.Retail[0].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[1].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[2].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[3].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[4].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[5].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[7].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[9].Cost >= 6 &&
            instance.CurrentPlayer.Skills.Retail[13].Cost >= 6
            )
        {
            int counter = 0;
            if (instance.CurrentPlayer.Skills.Retail[0].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[1].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[2].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[3].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[4].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[5].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[7].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[9].Cost - 6 >= 1) counter++;
            if (instance.CurrentPlayer.Skills.Retail[13].Cost - 6 >= 1) counter++;

            if (counter == 9)
            {
                // 15% //
                Debug.Log("15% increment");

            }
            else if (counter > 0)
            {
                Debug.Log("5% Increment");
            }
            else
            {
                Debug.Log("Basic");
                Debug.Log("No increment given on salary");
            }

            Debug.Log("You are eligible for retail Level 4 Chief Executive Officer Managing Director job");
            retailLevel4ChiefExecutiveOfficerManagingDirectorjob = true;
        }

        

        foreach (var item in allRetailJobsButton)
        {
            item.GetComponent<Button>().interactable = false;
        }

        if (retailLevel1BrandAssociatejob)
        {
            allRetailJobsButton[0].GetComponent<Button>().interactable = true;
            Debug.Log("1st button on");
        }
        if (retailLevel2BrandManagerjob)
        {
            allRetailJobsButton[1].GetComponent<Button>().interactable = true;
            Debug.Log("2nd button on");
        }
        if (retailLevel3BrandDirectorjob)
        {
            allRetailJobsButton[2].GetComponent<Button>().interactable = true;
        }
        if (retailLevel1VisualMerchandiserjob)
        {
            allRetailJobsButton[3].GetComponent<Button>().interactable = true;
        }
        if (retialLevel2MerchandisingManagerjob)
        {
            allRetailJobsButton[4].GetComponent<Button>().interactable = true;
        }
        if (retailLevel3MerchandisingDirectorjob)
        {
            allRetailJobsButton[5].GetComponent<Button>().interactable = true;
        }
        if (retailLevel4ChiefExecutiveOfficerManagingDirectorjob)
        {
            allRetailJobsButton[6].GetComponent<Button>().interactable = true;
            
        }       
    }

    

}
