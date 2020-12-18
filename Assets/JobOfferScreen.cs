using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobOfferScreen : MonoBehaviour
{
    public IndusturiesJobLimit JobLimits;

    public Text PopUp1JobTxt, PopUp2JobTxt;

    // ahsan's editing...
    public DataBase DB;
    public AppData LocalDB;
    public Text CompanyName;
    public Text Jobtitle;
    public Text Salary;
    public Text Pros1;
    public Text Pros2;
    public Text Cons1;

    ///////////////////////
    public GameObject AcceptOfferScreen;
    public GameObject RejectOffer;
    public GameObject GamePlay;
    public GameObject stats;
    // Start is called before the first frame update
    void Start()
    {


    }
    private void OnEnable()
    {
        JobLimits.GetJobLimitsData();
        LoadCompanyAndJobData();
    }
    int rnd = 0;
    // Update is called once per frame
    void Update()
    {

    }
    private void FillDetails(Company c)
    {
        CompanyName.text = c.CompanyName;
        Jobtitle.text = LocalDB.CurrentPlayer.MyJob.JobTitle;
        Salary.text = "$" + LocalDB.CurrentPlayer.MyJob.Salary;

        Pros1.text = c.pos1;
        Pros2.text = c.pos2;
        Cons1.text = c.neg;
    }
    
    // ahsan's editing...
    private void LoadCompanyAndJobData()
    {
        rnd = Random.Range(0, this.DB.industries.Accountancy.Count);
        string FieldName = LocalDB.CurrentPlayer.MyJob.FieldName;
        switch (FieldName)
        {
            case AppData.Fields.Accountancy:
                Company c = this.DB.industries.Accountancy[rnd];
                FillDetails(c);
                break;
            case AppData.Fields.HealthCare:
                FillDetails(this.DB.industries.Healthcare[rnd]);
                break;
            case AppData.Fields.HumanResource:
                FillDetails(this.DB.industries.HR[rnd]);
                break;
            case AppData.Fields.InformationTechnology:
                FillDetails(this.DB.industries.IT[rnd]);
                break;
            case AppData.Fields.Media:
                FillDetails(this.DB.industries.Media[rnd]);
                break;
            case AppData.Fields.Retail:
                FillDetails(this.DB.industries.Retail[rnd]);
                break;
        }
    }
    public void onClickStatsBtn() {
        this.gameObject.SetActive(false);
        stats.SetActive(true);
    }
    public void onClickGameWorldBtn() {
        // verify it first...
        LocalDB.CurrentPlayer.MyJob.Clear();
        /////////////////////
        this.gameObject.SetActive(false);
        GamePlay.SetActive(true);
    }
    public void onClickAcceptBtn() {
        // getting old job data

        LocalDB.MyFinalJob.FieldName = LocalDB.CurrentPlayer.MyJob.FieldName;
        LocalDB.MyFinalJob.JobTitle = LocalDB.CurrentPlayer.MyJob.JobTitle;

        Debug.Log("My JOB TITLE ON STARTING JOB ==>" + LocalDB.MyFinalJob.JobTitle);
        Debug.Log("My JOB FINAL TITLE ON STARTING JOB => " + LocalDB.CurrentPlayer.MyJob.JobTitle);

        Debug.Log("My JOB FIELD ON STARTING JOB ==>" + LocalDB.MyFinalJob.FieldName);
        Debug.Log("My JOB FINAL FIELD ON STARTING JOB => " + LocalDB.CurrentPlayer.MyJob.FieldName);

       
        if (!string.IsNullOrEmpty(LocalDB.MyFinalJob.FieldName) && !string.IsNullOrEmpty(LocalDB.MyFinalJob.JobTitle)) {
            switch (LocalDB.MyFinalJob.FieldName) {
                case AppData.Fields.Accountancy:
                    JobLimits.accounting.total_lower--;
                    break;
                case AppData.Fields.HumanResource:
                    JobLimits.humanResources.total_lower--;
                    break;
                case AppData.Fields.HealthCare:
                    JobLimits.healthcare.total_lower--;
                    break;
                case AppData.Fields.InformationTechnology:
                    JobLimits.informationTechnology.total_lower--;
                    break;
                case AppData.Fields.Retail:
                    JobLimits.retail.total_lower--;
                    break;
                case AppData.Fields.Media:
                    JobLimits.media.total_lower--;
                    break;
            }
            switch (LocalDB.MyFinalJob.JobTitle) {
                case "Chief Financial Officer":
                    JobLimits.accounting.CFO_--;
                    break;
                case "Management Accounting - Accounting Executive":
                    JobLimits.accounting.managementAccounting.AE_--;
                    break;
                case "Management Accounting - Financial Planning and Analysis Manager":
                    JobLimits.accounting.managementAccounting.FPAM_--;
                    break;
                case "Management Accounting - Business Controller":
                    JobLimits.accounting.managementAccounting.MABC_--;
                    break;
                case "Financial Accounting - Accounts Executive":
                    JobLimits.accounting.financialAccounting.AE_--;
                    break;
                case "Financial Accounting - Finance Manager":
                    JobLimits.accounting.financialAccounting.FM_--;
                    break;
                case "Financial Accounting - Financial Controller":
                    JobLimits.accounting.financialAccounting.FC_--;
                    break;

                case "Senior Principal Physiotherapy Researcher":
                    JobLimits.healthcare.researcher.serniorphysiotherapist_--;
                    break;
                case "Senior Principal Physiotherapist (Clinical)":
                    JobLimits.healthcare.clinical.serniorphysiotherapist_--;
                    break;
                case "Senior Principal Physiotherapy Educator":
                    JobLimits.healthcare.educator.serniorphysiotherapist_--;
                    break;
                case "Principal Physiotherapy Educator":
                    JobLimits.healthcare.educator.principalphysiotherapist_--;
                    break;
                case "Principal Physiotherapist (Clinical)":
                    JobLimits.healthcare.clinical.principalphysiotherapist_--;
                    break;
                case "Principal Physiotherapy Researcher":
                    JobLimits.healthcare.researcher.principalphysiotherapist_--;
                    break;
                case "Senior Physiotherapist":
                    JobLimits.healthcare.seniorphysiotherapist_--;
                    break;
                case "Physiotherapist":
                    JobLimits.healthcare.physiotherapist_--;
                    break;

                case "Chief Human Resource Officer":
                    JobLimits.humanResources.CHRO_--;
                    break;
                case "Head, Performance & Rewards":
                    JobLimits.humanResources.PR.head_--;
                    break;
                case "Manager, Performance & Rewards":
                    JobLimits.humanResources.PR.manager_--;
                    break;
                case "Executive, Performance & Rewards":
                    JobLimits.humanResources.PR.executive_--;
                    break;
                case "Head, Employee Experience & Relations":
                    JobLimits.humanResources.EER.head_--;
                    break;
                case "Manager, Employee Experience & Relations":
                    JobLimits.humanResources.EER.manager_--;
                    break;
                case "Executive, Employee Experience & Relations":
                    JobLimits.humanResources.EER.executive_--;
                    break;
                case "Head, Talent & Attraction":
                    JobLimits.humanResources.TA.head_--;
                    break;
                case "Manager, Talent & Attraction":
                    JobLimits.humanResources.TA.manager_--;
                    break;
                case "Executive, Talent & Attraction":
                    JobLimits.humanResources.TA.executive_--;
                    break;

                case "Head of Product":
                    JobLimits.informationTechnology.HOP_--;
                    break;
                case "Lead UX Designer":
                    JobLimits.informationTechnology.Designer.leadUX_--;
                    break;
                case "Senior UX Designer":
                    JobLimits.informationTechnology.Designer.serniorUX_--;
                    break;
                case "UX Designer":
                    JobLimits.informationTechnology.Designer.UX_--;
                    break;
                case "Chief Technology Officer":
                    JobLimits.informationTechnology.CTO_--;
                    break;
                case "Applications Architect":
                    JobLimits.informationTechnology.Applications.architect_--;
                    break;
                case "Applications Development Manager":
                    JobLimits.informationTechnology.Applications.manager_--;
                    break;
                case "Applications Developer":
                    JobLimits.informationTechnology.Applications.developer_--;
                    break;

                case "Executive Producer - Broadcast":
                    JobLimits.media.Broadcast.Ep_--;
                    break;
                case "Producer - Broadcast":
                    JobLimits.media.Broadcast.producer_--;
                    break;
                case "Assistant Producer Broadcast":
                    JobLimits.media.Broadcast.AP_--;
                    break;
                case "Production Assistant":
                    JobLimits.media.PA_--;
                    break;
                case "Chief Editor":
                    JobLimits.media.CE_--;
                    break;
                case "Executive Editor":
                    JobLimits.media.EE_--;
                    break;
                case "Senior Reporter / Senior Correspondent":
                    JobLimits.media.SRSC_--;
                    break;
                case "Reporter / Correspondent":
                    JobLimits.media.RC_--;
                    break;

                case "Chief Executive Officer / Managing Director":
                    JobLimits.retail.CEOMD_--;
                    break;
                case "Brand Director":
                    JobLimits.retail.brand.Director_--;
                    break;
                case "Brand Manager":
                    JobLimits.retail.brand.Manager_--;
                    break;
                case "Brand Associate":
                    JobLimits.retail.brand.Associate_--;
                    break;
                case "Merchandising Director":
                    JobLimits.retail.merchandise.MD_--;
                    break;
                case "Merchandising Manager":
                    JobLimits.retail.merchandise.MM_--;
                    break;
                case "Visual Merchandiser":
                    JobLimits.retail.merchandise.VM_--;
                    break;
            }
        }

        Debug.Log("My JOB TITLE ON STARTING JOB ==>" + LocalDB.MyFinalJob.JobTitle);
        Debug.Log("My JOB FINAL TITLE ON STARTING JOB => " + LocalDB.CurrentPlayer.MyJob.JobTitle);

        Debug.Log("My JOB FIELD ON STARTING JOB ==>" + LocalDB.MyFinalJob.FieldName);
        Debug.Log("My JOB FINAL FIELD ON STARTING JOB => " + LocalDB.CurrentPlayer.MyJob.FieldName);

        switch (LocalDB.CurrentPlayer.MyJob.FieldName) {
            case AppData.Fields.Accountancy:
                DB.industries.AccountancyJobs++;
                break;
            case AppData.Fields.HumanResource:
                DB.industries.HRJobs++;
                break;
            case AppData.Fields.HealthCare:
                DB.industries.HCJobs++;
                break;
            case AppData.Fields.InformationTechnology:
                DB.industries.ITJobs++;
                break;
            case AppData.Fields.Retail:
                DB.industries.RetailJobs++;
                break;
            case AppData.Fields.Media:
                DB.industries.MediaJobs++;
                break;
        }
        PopUp1JobTxt.text = PopUp2JobTxt.text = LocalDB.CurrentPlayer.MyJob.JobTitle;
        LocalDB.CurrentPlayer.MyJob.pro1 = Pros1.text;
        LocalDB.CurrentPlayer.MyJob.pro2 = Pros2.text;
        LocalDB.CurrentPlayer.MyJob.con = Cons1.text;

        LocalDB.CurrentPlayer.UpdateSatisfaction();

        this.gameObject.SetActive(false);
        AcceptOfferScreen.SetActive(true);

        LocalDB.MyFinalJob.FieldName = LocalDB.CurrentPlayer.MyJob.FieldName;
        LocalDB.MyFinalJob.JobTitle = LocalDB.CurrentPlayer.MyJob.JobTitle;
        LocalDB.MyFinalJob.pro1 = Pros1.text;
        LocalDB.MyFinalJob.pro2 = Pros2.text;
        LocalDB.MyFinalJob.con = Cons1.text;
        LocalDB.MyFinalJob.Salary = LocalDB.CurrentPlayer.MyJob.Salary;
        PopUp1JobTxt.text = PopUp2JobTxt.text = LocalDB.MyFinalJob.JobTitle;

        switch (LocalDB.MyFinalJob.FieldName) {
            case AppData.Fields.Accountancy:
                JobLimits.accounting.total_lower++;
                break;
            case AppData.Fields.HumanResource:
                JobLimits.humanResources.total_lower++;
                break;
            case AppData.Fields.HealthCare:
                JobLimits.healthcare.total_lower++;
                break;
            case AppData.Fields.InformationTechnology:
                JobLimits.informationTechnology.total_lower++;
                break;
            case AppData.Fields.Retail:
                JobLimits.retail.total_lower++;
                break;
            case AppData.Fields.Media:
                JobLimits.media.total_lower++;
                break;
        }
        switch (LocalDB.MyFinalJob.JobTitle) {
            case "Chief Financial Officer":
                JobLimits.accounting.CFO_++;
                break;
            case "Management Accounting - Accounting Executive":
                JobLimits.accounting.managementAccounting.AE_++;
                break;
            case "Management Accounting - Financial Planning and Analysis Manager":
                JobLimits.accounting.managementAccounting.FPAM_++;
                break;
            case "Management Accounting - Business Controller":
                JobLimits.accounting.managementAccounting.MABC_++;
                break;
            case "Financial Accounting - Accounts Executive":
                JobLimits.accounting.financialAccounting.AE_++;
                break;
            case "Financial Accounting - Finance Manager":
                JobLimits.accounting.financialAccounting.FM_++;
                break;
            case "Financial Accounting - Financial Controller":
                JobLimits.accounting.financialAccounting.FC_++;
                break;

            case "Senior Principal Physiotherapy Researcher":
                JobLimits.healthcare.researcher.serniorphysiotherapist_++;
                break;
            case "Senior Principal Physiotherapist (Clinical)":
                JobLimits.healthcare.clinical.serniorphysiotherapist_++;
                break;
            case "Senior Principal Physiotherapy Educator":
                JobLimits.healthcare.educator.serniorphysiotherapist_++;
                break;
            case "Principal Physiotherapy Educator":
                JobLimits.healthcare.educator.principalphysiotherapist_++;
                break;
            case "Principal Physiotherapist (Clinical)":
                JobLimits.healthcare.clinical.principalphysiotherapist_++;
                break;
            case "Principal Physiotherapy Researcher":
                JobLimits.healthcare.researcher.principalphysiotherapist_++;
                break;
            case "Senior Physiotherapist":
                JobLimits.healthcare.seniorphysiotherapist_++;
                break;
            case "Physiotherapist":
                JobLimits.healthcare.physiotherapist_++;
                break;

            case "Chief Human Resource Officer":
                JobLimits.humanResources.CHRO_++;
                break;
            case "Head, Performance & Rewards":
                JobLimits.humanResources.PR.head_++;
                break;
            case "Manager, Performance & Rewards":
                JobLimits.humanResources.PR.manager_++;
                break;
            case "Executive, Performance & Rewards":
                JobLimits.humanResources.PR.executive_++;
                break;
            case "Head, Employee Experience & Relations":
                JobLimits.humanResources.EER.head_++;
                break;
            case "Manager, Employee Experience & Relations":
                JobLimits.humanResources.EER.manager_++;
                break;
            case "Executive, Employee Experience & Relations":
                JobLimits.humanResources.EER.executive_++;
                break;
            case "Head, Talent & Attraction":
                JobLimits.humanResources.TA.head_++;
                break;
            case "Manager, Talent & Attraction":
                JobLimits.humanResources.TA.manager_++;
                break;
            case "Executive, Talent & Attraction":
                JobLimits.humanResources.TA.executive_++;
                break;

            case "Head of Product":
                JobLimits.informationTechnology.HOP_++;
                break;
            case "Lead UX Designer":
                JobLimits.informationTechnology.Designer.leadUX_++;
                break;
            case "Senior UX Designer":
                JobLimits.informationTechnology.Designer.serniorUX_++;
                break;
            case "UX Designer":
                JobLimits.informationTechnology.Designer.UX_++;
                break;
            case "Chief Technology Officer":
                JobLimits.informationTechnology.CTO_++;
                break;
            case "Applications Architect":
                JobLimits.informationTechnology.Applications.architect_++;
                break;
            case "Applications Development Manager":
                JobLimits.informationTechnology.Applications.manager_++;
                break;
            case "Applications Developer":
                JobLimits.informationTechnology.Applications.developer_++;
                break;

            case "Executive Producer - Broadcast":
                JobLimits.media.Broadcast.Ep_++;
                break;
            case "Producer - Broadcast":
                JobLimits.media.Broadcast.producer_++;
                break;
            case "Assistant Producer Broadcast":
                JobLimits.media.Broadcast.AP_++;
                break;
            case "Production Assistant":
                JobLimits.media.PA_++;
                break;
            case "Chief Editor":
                JobLimits.media.CE_++;
                break;
            case "Executive Editor":
                JobLimits.media.EE_++;
                break;
            case "Senior Reporter / Senior Correspondent":
                JobLimits.media.SRSC_++;
                break;
            case "Reporter / Correspondent":
                JobLimits.media.RC_++;
                break;

            case "Chief Executive Officer / Managing Director":
                JobLimits.retail.CEOMD_++;
                break;
            case "Brand Director":
                JobLimits.retail.brand.Director_++;
                break;
            case "Brand Manager":
                JobLimits.retail.brand.Manager_++;
                break;
            case "Brand Associate":
                JobLimits.retail.brand.Associate_++;
                break;
            case "Merchandising Director":
                JobLimits.retail.merchandise.MD_++;
                break;
            case "Merchandising Manager":
                JobLimits.retail.merchandise.MM_++;
                break;
            case "Visual Merchandiser":
                JobLimits.retail.merchandise.VM_++;
                break;
        }
        JobLimits.SendJobLimitsData();
    }

    public void onClickRejectBtn() {
        this.gameObject.SetActive(false);
        RejectOffer.SetActive(true);
    }
}
