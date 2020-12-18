using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AEligibilityScreen : MonoBehaviour
{
    [SerializeField] private IndusturiesJobLimit JobLimits;
    public AppData AD;
    public GameObject CheckEligi;
    public GameObject Back;
    public GameObject GamePlay;
    public GameObject stats;
    public Button btn1;
    public Text bodytxt;
    public Button FindJobBtn;
    public GameObject JobNotAvailableScreen;

    private void OnEnable() {
        if (FindJobBtn != null)
            FindJobBtn.interactable = false;
        clicked = false;
        bodytxt.text = "You have " + AD.CurrentPlayer.RemainingActionPoints + " action points.\nWhich job are you applying for?";
        //ColorBlock colors = btn1.colors;
        //colors.normalColor = new Color32(81, 169, 171, 255);
        //btn1.colors = colors;
        JobLimits.GetJobLimitsData();
    }

    // Start is called before the first frame update
    void Start()
    {
        JobLimits = FindObjectOfType<IndusturiesJobLimit>();
        //ColorBlock colors = btn1.colors;
        //colors.normalColor = new Color32(255, 255, 255, 255);
        //btn1.colors = colors;
    }


    public bool clicked = false;
    // Update is called once per frame
    void Update()
    {
        if(AD.CurrentPlayer.RemainingActionPoints < 2 && !clicked) {
            FindJobBtn.interactable = false;
        } else if (clicked) {
            FindJobBtn.interactable = true;
        }
    }
    // ahsan's editing...
    public void OnClickEligiBtn() {
        this.gameObject.SetActive(false);
        CheckEligi.SetActive(true);
    }

    public void OnClickBackBtn() {
        this.gameObject.SetActive(false);
        Back.SetActive(true);
    }

    public void onClickStatsBtn() {
        this.gameObject.SetActive(false);
        stats.SetActive(true);
    }
    public void onClickGameWorldBtn() {
        this.gameObject.SetActive(false);
        GamePlay.SetActive(true);
    }

    public void onClickFindJobBtn() {
        AD.CurrentPlayer.RemainingActionPoints -= 2;
        this.gameObject.SetActive(false);
        CheckEligi.SetActive(true);
    }

    public void onClick_Accountancy_CFOBtn()
    {
        if (JobLimits.accounting.CFO_ < JobLimits.accounting.CFO) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Accountancy_ChiefFinancialOfficeer;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.accountancySalary6;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Accountancy_MABCBtn() {
        if (JobLimits.accounting.managementAccounting.MABC_ < JobLimits.accounting.managementAccounting.MABC) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Accountancy_ManagementAccountingBusinessController;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.accountancySalary2;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Accountancy_FAFCBtn() {
        if (JobLimits.accounting.financialAccounting.FC_ < JobLimits.accounting.financialAccounting.FC) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Accountancy_FinancialAccountingFinancialControl;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.accountancySalary5;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Accountancy_MAFPAMBtn() {
        if (JobLimits.accounting.managementAccounting.FPAM_ < JobLimits.accounting.managementAccounting.FPAM) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Accountancy_ManagementAccountingFinancialPlaningAndAnalysisManager;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.accountancySalary1;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Accountancy_FAFMBtn() {
        if (JobLimits.accounting.financialAccounting.FM_ < JobLimits.accounting.financialAccounting.FM) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Accountancy_FinancialAccountingFinanceManager;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.accountancySalary4;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Accountancy_MAAEBtn() {
        if (JobLimits.accounting.managementAccounting.AE_ < JobLimits.accounting.managementAccounting.AE) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Accountancy_ManagementAccountingAccountingExecutive;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.accountancySalary0;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Accountancy_FAAEBtn() {
        if (JobLimits.accounting.financialAccounting.AE_ < JobLimits.accounting.financialAccounting.AE) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Accountancy_FinancialAccountingAccountsExecutive;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.accountancySalary3;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HealthCare_SPPR() {
        if (JobLimits.healthcare.researcher.serniorphysiotherapist_ < JobLimits.healthcare.researcher.serniorphysiotherapist) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HealthCare_SeniorPrincipalPhysiotherapyResearcher;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.heathCareSalary7;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HealthCare_SP() {
        if (JobLimits.healthcare.seniorphysiotherapist_ < JobLimits.healthcare.seniorphysiotherapist) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HealthCare_SeniorPhysiotherapist;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.heathCareSalary1;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HealthCare_SPPC() {
        if (JobLimits.healthcare.clinical.serniorphysiotherapist_ < JobLimits.healthcare.seniorphysiotherapist) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HealthCare_SeniorPrincipalPhysiotherapistClinical;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.heathCareSalary3;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HealthCare_SPPE() {
        if (JobLimits.healthcare.educator.serniorphysiotherapist_ < JobLimits.healthcare.educator.serniorphysiotherapist) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HealthCare_SeniorPrincipalPhysiotherapyEducator;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.heathCareSalary5;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HealthCare_PPR() {
        if (JobLimits.healthcare.researcher.principalphysiotherapist_ < JobLimits.healthcare.researcher.principalphysiotherapist) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HealthCare_PrincipalPhysiotherapyResearcher;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.heathCareSalary6;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HealthCare_P() {
        if (JobLimits.healthcare.physiotherapist_ < JobLimits.healthcare.physiotherapist) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HealthCare_Physiotherapist;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.heathCareSalary0;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HealthCare_PPC() {
        if (JobLimits.healthcare.clinical.principalphysiotherapist_ < JobLimits.healthcare.clinical.principalphysiotherapist) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HealthCare_PrincipalPhysiotherapistClinical;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.heathCareSalary2;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HealthCare_PPE() {
        if (JobLimits.healthcare.educator.principalphysiotherapist_ < JobLimits.healthcare.educator.principalphysiotherapist) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HealthCare_PrincipalPhysiotherapyEducator;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.heathCareSalary4;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HumanResource_CHRO() {
        if (JobLimits.humanResources.CHRO_ < JobLimits.humanResources.CHRO) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HumanResource_ChiefHumanResourceOfficer;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.hrSalary9;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HumanResource_HPR() {
        if (JobLimits.humanResources.PR.head_ < JobLimits.humanResources.PR.head) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HumanResource_HeadPerformanceRewards;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.hrSalary2;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HumanResource_MPR() {
        if (JobLimits.humanResources.PR.manager_ < JobLimits.humanResources.PR.manager) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HumanResource_ManagerPerformanceRewards;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.hrSalary1;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HumanResource_EPR() {
        if (JobLimits.humanResources.PR.executive_ < JobLimits.humanResources.PR.executive) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HumanResource_ExecutivePerformanceRewards;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.hrSalary0;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HumanResource_HTA() {
        if (JobLimits.humanResources.TA.head_ < JobLimits.humanResources.TA.head) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HumanResource_HeadTalentAttraction;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.hrSalary5;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HumanResource_MTA() {
        if (JobLimits.humanResources.TA.manager_ < JobLimits.humanResources.TA.manager) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HumanResource_ManagerTalentAttraction;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.hrSalary4;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HumanResource_ETA() {
        if (JobLimits.humanResources.TA.executive_ < JobLimits.humanResources.TA.executive) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HumanResource_ExecutiveTalentAttraction;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.hrSalary3;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HumanResource_HEER() {
        if (JobLimits.humanResources.EER.head_ < JobLimits.humanResources.EER.head) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HumanResource_HeadEmployeeExperienceReleations;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.hrSalary8;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HumanResource_MEER() {
        if (JobLimits.humanResources.EER.manager_ < JobLimits.humanResources.EER.manager) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HumanResource_ManagerEmployeeExperienceReleations;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.hrSalary7;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_HumanResource_EEER() {
        if (JobLimits.humanResources.EER.executive_ < JobLimits.humanResources.EER.executive) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.HumanResource_ExecutiveExployeeExperienceRelations;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.hrSalary6;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_InformationTechnology_CTO() {
        if (JobLimits.informationTechnology.CTO_ < JobLimits.informationTechnology.CTO) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.InformationTechnology_ChiefTechnologyOfficer;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.itSalary3;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_InformationTechnology_AA() {
        if (JobLimits.informationTechnology.Applications.architect_ < JobLimits.informationTechnology.Applications.architect) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.InformationTechnology_ApplicationsArchitecture;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.itSalary2;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_InformationTechnology_ADM() {
        if (JobLimits.informationTechnology.Applications.manager_ < JobLimits.informationTechnology.Applications.manager) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.InformationTechnology_ApplicationsDevelopmentManager;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.itSalary1;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_InformationTechnology_AD() {
        if (JobLimits.informationTechnology.Applications.developer_ < JobLimits.informationTechnology.Applications.developer) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.InformationTechnology_ApplicationsDeveloper;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.itSalary0;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_InformationTechnology_HOP() {
        if (JobLimits.informationTechnology.HOP_ < JobLimits.informationTechnology.HOP) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.InformationTechnology_HeadOfProduct;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.itSalary7;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_InformationTechnology_LUXD() {
        if (JobLimits.informationTechnology.Designer.leadUX_ < JobLimits.informationTechnology.Designer.leadUX) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.InformationTechnology_LeadUXDesigner;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.itSalary6;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_InformationTechnology_SUXD() {
        if (JobLimits.informationTechnology.Designer.serniorUX_ < JobLimits.informationTechnology.Designer.serniorUX) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.InformationTechnology_SeniorUXDesigner;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.itSalary5;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_InformationTechnology_UXD() {
        if (JobLimits.informationTechnology.Designer.UX_ < JobLimits.informationTechnology.Designer.UX) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.InformationTechnology_UXDesigner;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.itSalary4;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Media_EPB() {
        if (JobLimits.media.Broadcast.Ep_ < JobLimits.media.Broadcast.Ep) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Media_ExecutiveProductBroadcast;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.mediaSalary3;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Media_PB() {
        if (JobLimits.media.Broadcast.producer_ < JobLimits.media.Broadcast.producer) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Media_ProducerBroadcast;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.mediaSalary2;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Media_APB() {
        if (JobLimits.media.Broadcast.AP_ < JobLimits.media.Broadcast.AP) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Media_AssistantProducerBroadcast;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.mediaSalary1;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Media_PA() {
        if (JobLimits.media.PA_ < JobLimits.media.PA) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Media_ProductionAssistant;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.mediaSalary0;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Media_CE() {
        if (JobLimits.media.CE_ < JobLimits.media.CE) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Media_ChiefEditor;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.mediaSalary7;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Media_EE() {
        if (JobLimits.media.EE_ < JobLimits.media.EE) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Media_ExecutiveEditor;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.mediaSalary6;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Media_SRSC() {
        if (JobLimits.media.SRSC_ < JobLimits.media.SRSC) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Media_SeniorReporterSeniorCorrespondent;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.mediaSalary5;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Media_RC() {
        if (JobLimits.media.RC_ < JobLimits.media.RC) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Media_ReporterCorrespondent;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.mediaSalary4;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Retail_CEOM() {
        if (JobLimits.retail.CEOMD_ < JobLimits.retail.CEOMD) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Retail_ChiefExecutiveOfficerManaging;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.retailSalary6;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Retail_BD() {
        if (JobLimits.retail.brand.Director_ < JobLimits.retail.brand.Director) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Retail_BrandDirector;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.retailSalary2;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Retail_BM() {
        if (JobLimits.retail.brand.Manager_ < JobLimits.retail.brand.Manager) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Retail_BrandManager;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.retailSalary1;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }

    public void onClick_Retail_BA() {
        if (JobLimits.retail.brand.Associate_ < JobLimits.retail.brand.Associate) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Retail_BrandAssociate;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.retailSalary0;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Retail_MD() {
        if (JobLimits.retail.merchandise.MD_ < JobLimits.retail.merchandise.MD) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Retail_MarchandisingDirector;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.retailSalary5;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Retail_MM() {
        if (JobLimits.retail.merchandise.MM_ < JobLimits.retail.merchandise.MM) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Retail_MarchandisingManager;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.retailSalary4;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
    public void onClick_Retail_VM() {
        if (JobLimits.retail.merchandise.VM_ < JobLimits.retail.merchandise.VM) {
            clicked = true;
            FindJobBtn.interactable = true;
            AD.CurrentPlayer.MyJob.JobTitle = AppData.JobTitles.Retail_VisualMarchandising;
            AD.CurrentPlayer.MyJob.Salary = (int)GameManager.instanceg.retailSalary3;
        } else {
            this.gameObject.SetActive(false);
            JobNotAvailableScreen.SetActive(true);
            JobNotAvailableScreen.GetComponent<JobNotAvailable>().BodyText.text = "Sorry, this job is unavailable.";
        }
    }
}
