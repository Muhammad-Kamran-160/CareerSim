using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkTestPass : MonoBehaviour
{
    [SerializeField] private IndusturiesJobLimit JobLimits;
    public AppData LocalDB;
    public Text WorkExperienceText;
    public GameObject ContinueWork;
    public GameObject stats;
    public Text CertificateText;
    public GameObject GamePlay;
    public GameObject ContinueEduBtn;
    public GameObject PromotionScreen;
    private void OnDisable()
    {
        LocalDB.feildskills = "";
        LocalDB.IsContinueEdu = false;
    }
    private void OnEnable() {
        JobLimits.GetJobLimitsData();
        CertificateText.text = "";
        if (LocalDB.IsContinueEdu) {
            CertificateText.text = "";
            //CertificateText.text = "You earned:\n          +$2000\n          ";
        } else {
            CertificateText.text = "You earned:\n          +$" + LocalDB.CurrentPlayer.GetCommaSeparatedAmount(LocalDB.MyFinalJob.Salary) + "\n          ";
        }
        UpdateSkillsValues();
        for (int i = 0; i < LocalDB.SelectThree.Count; i++) {
            //CertificateText.text += "+" + GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex) + ": " + GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.Accountacy[LocalDB.SelectThree[i].Listindex].MI].cost).ToString("0.00") + "\n          ";
            //LocalDB.CurrentPlayer.LifeCardSkills.Add(GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex));

            switch (LocalDB.SelectThree[i].ListName) {
                case AppData.Fields.Accountancy:
                    CertificateText.text += "+" + GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex) + ": " + GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.Accountacy[LocalDB.SelectThree[i].Listindex].MI].cost).ToString("0.00") + "\n          ";
                    //LocalDB.CurrentPlayer.Skills.Accountacy[LocalDB.SelectThree[i].Listindex].Cost += 1;
                    EduRec er = new EduRec();
                    er.edu = GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex);
                    er.per = (float)LocalDB.CurrentPlayer.Skills.Accountacy[LocalDB.SelectThree[i].Listindex].Cost;
                    LocalDB.CurrentPlayer.LifeCardSkills.Add(er);
                    break;
                case AppData.Fields.HumanResource:
                    CertificateText.text += "+" + GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex) + ": " + GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.HR[LocalDB.SelectThree[i].Listindex].MI].cost).ToString("0.00") + "\n          ";
                    //LocalDB.CurrentPlayer.Skills.HR[LocalDB.SelectThree[i].Listindex].Cost += 1;
                    er = new EduRec();
                    er.edu = GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex);
                    er.per = (float)LocalDB.CurrentPlayer.Skills.HR[LocalDB.SelectThree[i].Listindex].Cost;
                    LocalDB.CurrentPlayer.LifeCardSkills.Add(er);
                    break;
                case AppData.Fields.HealthCare:
                    CertificateText.text += "+" + GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex) + ": " + GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.HealtCare[LocalDB.SelectThree[i].Listindex].MI].cost).ToString("0.00") + "\n          ";
                    //LocalDB.CurrentPlayer.Skills.HealtCare[LocalDB.SelectThree[i].Listindex].Cost += 1;
                    er = new EduRec();
                    er.edu = GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex);
                    er.per = (float)LocalDB.CurrentPlayer.Skills.HealtCare[LocalDB.SelectThree[i].Listindex].Cost;
                    LocalDB.CurrentPlayer.LifeCardSkills.Add(er);
                    break;
                case AppData.Fields.InformationTechnology:
                    CertificateText.text += "+" + GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex) + ": " + GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.IT[LocalDB.SelectThree[i].Listindex].MI].cost).ToString("0.00") + "\n          ";
                    //LocalDB.CurrentPlayer.Skills.IT[LocalDB.SelectThree[i].Listindex].Cost += 1;
                    er = new EduRec();
                    er.edu = GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex);
                    er.per = (float)LocalDB.CurrentPlayer.Skills.IT[LocalDB.SelectThree[i].Listindex].Cost;
                    LocalDB.CurrentPlayer.LifeCardSkills.Add(er);
                    break;
                case AppData.Fields.Media:
                    CertificateText.text += "+" + GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex) + ": " + GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.Media[LocalDB.SelectThree[i].Listindex].MI].cost).ToString("0.00") + "\n          ";
                    //LocalDB.CurrentPlayer.Skills.Media[LocalDB.SelectThree[i].Listindex].Cost += 1;
                    er = new EduRec();
                    er.edu = GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex);
                    er.per = (float)LocalDB.CurrentPlayer.Skills.Media[LocalDB.SelectThree[i].Listindex].Cost;
                    LocalDB.CurrentPlayer.LifeCardSkills.Add(er);
                    break;
                case AppData.Fields.Retail:
                    CertificateText.text += "+" + GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex) + ": " + GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.Retail[LocalDB.SelectThree[i].Listindex].MI].cost).ToString("0.00") + "\n          ";
                    //LocalDB.CurrentPlayer.Skills.Retail[LocalDB.SelectThree[i].Listindex].Cost += 1;
                    er = new EduRec();
                    er.edu = GetTitle(LocalDB.SelectThree[i].ListName, LocalDB.SelectThree[i].Listindex);
                    er.per = (float)LocalDB.CurrentPlayer.Skills.Retail[LocalDB.SelectThree[i].Listindex].Cost;
                    LocalDB.CurrentPlayer.LifeCardSkills.Add(er);
                    break;
            }
        }
        //CertificateText.text += "+" + GetTitle(LocalDB.SelectThree[0].ListName, LocalDB.SelectThree[0].Listindex) + "\n          ";
        //CertificateText.text += "+" + GetTitle(LocalDB.SelectThree[1].ListName, LocalDB.SelectThree[1].Listindex) + "\n          ";
        //CertificateText.text += "+" + GetTitle(LocalDB.SelectThree[2].ListName, LocalDB.SelectThree[2].Listindex);

        

        if (!LocalDB.IsContinueEdu) {
            LocalDB.CurrentPlayer.UpdateSatisfaction();
            LocalDB.CurrentPlayer.Bank += LocalDB.MyFinalJob.Salary;

            LocalDB.AvgCount++;
            LocalDB.MyFinalJob.WorkExperience++;
            LocalDB.CurrentPlayer.MyJob.WorkExperience++;
            LocalDB.AvgSum += LocalDB.MyFinalJob.Salary;

            WorkExperienceText.text = "Done with work!\nWork experience: " + LocalDB.MyFinalJob.WorkExperience;

            //switch (LocalDB.CurrentPlayer.MyJob.FieldName) {
            //    case AppData.Fields.Accountancy:
            //        PromoteAccountanceyJob();
            //        break;
            //    case AppData.Fields.HealthCare:
            //        PromoteHealthCareJob();
            //        break;
            //    case AppData.Fields.HumanResource:
            //        PromoteHRJob();
            //        break;
            //    case AppData.Fields.InformationTechnology:
            //        PromoteITJob();
            //        break;
            //    case AppData.Fields.Media:
            //        PromoteMediaJob();
            //        break;
            //    case AppData.Fields.Retail:
            //        PromoteRetailJob();
            //        break;
            //}

            StartCoroutine(JobPromotionCoroutine());

            //LocalDB.CurrentPlayer.LifeCardSkills.Add(GetTitle(LocalDB.SelectThree[0].ListName, LocalDB.SelectThree[0].Listindex));
            //LocalDB.CurrentPlayer.LifeCardSkills.Add(GetTitle(LocalDB.SelectThree[1].ListName, LocalDB.SelectThree[1].Listindex));
            //LocalDB.CurrentPlayer.LifeCardSkills.Add(GetTitle(LocalDB.SelectThree[2].ListName, LocalDB.SelectThree[2].Listindex));
        } else {
            //LocalDB.CurrentPlayer.Bank += 2000;
            LocalDB.IsContinueEdu = false;
        }
    }

    private IEnumerator JobPromotionCoroutine() {
        
        yield return new WaitForSeconds(2.0f);
        string oldJob = LocalDB.MyFinalJob.JobTitle;
        bool isPromoted = false;
        // Promote job here
        switch (LocalDB.MyFinalJob.FieldName) {
            case AppData.Fields.Accountancy:
                isPromoted = PromoteAccountanceyJob();
                break;
            case AppData.Fields.HealthCare:
                isPromoted = PromoteHealthCareJob();
                break;
            case AppData.Fields.HumanResource:
                isPromoted = PromoteHRJob();
                break;
            case AppData.Fields.InformationTechnology:
                isPromoted = PromoteITJob();
                break;
            case AppData.Fields.Media:
                isPromoted = PromoteMediaJob();
                break;
            case AppData.Fields.Retail:
                isPromoted = PromoteRetailJob();
                break;
        }
        if (isPromoted) {
            // subtract 1 from old job.
            switch (oldJob) {
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
        // Send updated job limits data here
        JobLimits.SendJobLimitsData();
    }

    private bool PromoteAccountanceyJob() {
        GameManager gm = GameObject.FindObjectOfType<GameManager>();
        gm.newAccountancyFlow();
        if (gm.chiefFin) {
            // Chief Financial Officer
            if (JobLimits.accounting.CFO_ < JobLimits.accounting.CFO) {
                if (LocalDB.MyFinalJob.JobTitle != "Chief Financial Officer") {
                    LocalDB.MyFinalJob.JobTitle = "Chief Financial Officer";
                    LocalDB.MyFinalJob.Salary = (int)gm.accountancySalary6;
                    PromotionScreen.SetActive(true);
                    JobLimits.accounting.CFO_++;
                    return true;
                }
            }
        }
        if (LocalDB.MyFinalJob.JobTitle.Split(' ')[0][0] == 'M') {
            if (gm.level3Man) {
                if (JobLimits.accounting.managementAccounting.MABC_ < JobLimits.accounting.managementAccounting.MABC) {
                    if (LocalDB.MyFinalJob.JobTitle != "Management Accounting - Business Controller") {
                        LocalDB.MyFinalJob.JobTitle = "Management Accounting - Business Controller";
                        LocalDB.MyFinalJob.Salary = (int)gm.accountancySalary2;
                        PromotionScreen.SetActive(true);
                        JobLimits.accounting.managementAccounting.MABC_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the jobLimit Reached for Management Accounting - Business Controller.");
                }
            } else if (gm.level2Man) {
                if (JobLimits.accounting.managementAccounting.FPAM_ < JobLimits.accounting.managementAccounting.FPAM) {
                    if (LocalDB.MyFinalJob.JobTitle != "Management Accounting - Financial Planning and Analysis Manager") {
                        LocalDB.MyFinalJob.JobTitle = "Management Accounting - Financial Planning and Analysis Manager";
                        LocalDB.MyFinalJob.Salary = (int)gm.accountancySalary1;
                        PromotionScreen.SetActive(true);
                        JobLimits.accounting.managementAccounting.FPAM_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Management Accounting - Financial Planning and Analysis Manager");
                }
            } else if (gm.level1Man) {
                if (JobLimits.accounting.managementAccounting.AE_ < JobLimits.accounting.managementAccounting.AE) {
                    if (LocalDB.MyFinalJob.JobTitle != "Management Accounting - Accounting Executive") {
                        LocalDB.MyFinalJob.JobTitle = "Management Accounting - Accounting Executive";
                        LocalDB.MyFinalJob.Salary = (int)gm.accountancySalary0;
                        PromotionScreen.SetActive(true);
                        JobLimits.accounting.managementAccounting.AE_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Management Accounting - Accounting Executive");
                }
            }
        } else if (LocalDB.MyFinalJob.JobTitle.Split(' ')[0][0] == 'F') {
            if (gm.level3Fin) {
                if (JobLimits.accounting.financialAccounting.FC_ < JobLimits.accounting.financialAccounting.FC) {
                    if (LocalDB.MyFinalJob.JobTitle != "Financial Accounting - Financial Controller") {
                        LocalDB.MyFinalJob.JobTitle = "Financial Accounting - Financial Controller";
                        LocalDB.MyFinalJob.Salary = (int)gm.accountancySalary5;
                        PromotionScreen.SetActive(true);
                        JobLimits.accounting.financialAccounting.FC_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Financial Accounting - Financial Controller");
                }
            } else if (gm.level2Fin) {
                if (JobLimits.accounting.financialAccounting.FM_ < JobLimits.accounting.financialAccounting.FM) {
                    if (LocalDB.MyFinalJob.JobTitle != "Financial Accounting - Finance Manager") {
                        LocalDB.MyFinalJob.JobTitle = "Financial Accounting - Finance Manager";
                        LocalDB.MyFinalJob.Salary = (int)gm.accountancySalary4;
                        PromotionScreen.SetActive(true);
                        JobLimits.accounting.financialAccounting.FM_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limite reached for Financial Accounting - Finance Manager");
                }
            } else if (gm.level1Fin) {
                if (JobLimits.accounting.financialAccounting.AE_ < JobLimits.accounting.financialAccounting.AE) {
                    if (LocalDB.MyFinalJob.JobTitle != "Financial Accounting - Accounts Executive") {
                        LocalDB.MyFinalJob.JobTitle = "Financial Accounting - Accounts Executive";
                        LocalDB.MyFinalJob.Salary = (int)gm.accountancySalary3;
                        PromotionScreen.SetActive(true);
                        JobLimits.accounting.financialAccounting.AE_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Financial Accounting - Accounts Executive");
                }
            }
        }
        return false;
    }

    private bool PromoteHealthCareJob() {
        GameManager gm = GameObject.FindObjectOfType<GameManager>();
        gm.healthCareJobEligibilityCheckFlow();
        if (gm.healthCareLevel4SeniorPrincipalPhysiotherapyResearcherJob && LocalDB.MyFinalJob.JobTitle == "Principal Physiotherapy Researcher") {
            if (JobLimits.healthcare.researcher.serniorphysiotherapist_ < JobLimits.healthcare.researcher.serniorphysiotherapist) {
                if (LocalDB.MyFinalJob.JobTitle != "Senior Principal Physiotherapy Researcher") {
                    LocalDB.MyFinalJob.JobTitle = "Senior Principal Physiotherapy Researcher";
                    LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary7;
                    PromotionScreen.SetActive(true);
                    JobLimits.healthcare.researcher.serniorphysiotherapist_++;
                    return true;
                }
            } else {
                Debug.Log("Can't promote as the job limit reached for Senior Principal Physiotherapy Researcher");
            }
        } else if (gm.healthCareLevel4SeniorPrincipalPhysiotherapistClinicaljob && LocalDB.MyFinalJob.JobTitle == "Principal Physiotherapist (Clinical)") {
            if (JobLimits.healthcare.clinical.serniorphysiotherapist_ < JobLimits.healthcare.clinical.serniorphysiotherapist) {
                if (LocalDB.MyFinalJob.JobTitle != "Senior Principal Physiotherapist (Clinical)") {
                    LocalDB.MyFinalJob.JobTitle = "Senior Principal Physiotherapist (Clinical)";
                    LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary3;
                    PromotionScreen.SetActive(true);
                    JobLimits.healthcare.clinical.serniorphysiotherapist_++;
                    return true;
                }
            } else {
                Debug.Log("Can't promote as the job limit reaced for Senior Principal Physiotherapist (Clinical)");
            }
        } else if (gm.healthCareLevel4SeniorPrincipalPhysiotherapyEducatorjob && LocalDB.MyFinalJob.JobTitle == "Principal Physiotherapy Educator") {
            if (JobLimits.healthcare.educator.serniorphysiotherapist_ < JobLimits.healthcare.educator.serniorphysiotherapist) {
                if (LocalDB.MyFinalJob.JobTitle != "Senior Principal Physiotherapy Educator") {
                    LocalDB.MyFinalJob.JobTitle = "Senior Principal Physiotherapy Educator";
                    LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary5;
                    PromotionScreen.SetActive(true);
                    JobLimits.healthcare.educator.serniorphysiotherapist_++;
                    return true;
                }
            } else {
                Debug.Log("Can't promote as the job limit reaced for Senior Principal Physiotherapy Educator");
            }
        } else if (gm.healthCareLevel3PrincipalPhysiotherapyEducator && gm.healthCareLevel3PrincipalPhysiotherapistClinicalJob && gm.healthCareLevel3PrincipalPhysiotherapyResearcherJob) {
            int rnd = Random.Range(0, 3);
            switch (rnd) {
                case 0:
                    if (JobLimits.healthcare.educator.principalphysiotherapist_ < JobLimits.healthcare.educator.principalphysiotherapist) {
                        if (LocalDB.MyFinalJob.JobTitle != "Principal Physiotherapy Educator") {
                            LocalDB.MyFinalJob.JobTitle = "Principal Physiotherapy Educator";
                            LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary4;
                            PromotionScreen.SetActive(true);
                            JobLimits.healthcare.educator.principalphysiotherapist_++;
                            return true;
                        }
                    } else {
                        Debug.Log("Can't promote as the job limit reached for Principal Physiotherapy Educator");
                    }
                    break;
                case 1:
                    if (JobLimits.healthcare.clinical.principalphysiotherapist_ < JobLimits.healthcare.clinical.principalphysiotherapist) {
                        if (LocalDB.MyFinalJob.JobTitle != "Principal Physiotherapist (Clinical)") {
                            LocalDB.MyFinalJob.JobTitle = "Principal Physiotherapist (Clinical)";
                            LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary2;
                            PromotionScreen.SetActive(true);
                            JobLimits.healthcare.clinical.principalphysiotherapist_++;
                            return true;
                        }
                    } else {
                        Debug.Log("Can't promote as the job limit reached for Principal Physiotherapist (Clinical)");
                    }
                    break;
                case 2:
                    if (JobLimits.healthcare.researcher.principalphysiotherapist_ < JobLimits.healthcare.researcher.principalphysiotherapist) {
                        if (LocalDB.MyFinalJob.JobTitle != "Principal Physiotherapy Researcher") {
                            LocalDB.MyFinalJob.JobTitle = "Principal Physiotherapy Researcher";
                            LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary6;
                            PromotionScreen.SetActive(true);
                            JobLimits.healthcare.researcher.principalphysiotherapist_++;
                            return true;
                        }
                    } else {
                        Debug.Log("Can't promote as the job limit reaced for Principal Physiotherapy Researcher");
                    }
                    break;
            }
        } else if (gm.healthCareLevel3PrincipalPhysiotherapyEducator && gm.healthCareLevel3PrincipalPhysiotherapistClinicalJob) {
            int rnd = Random.Range(0, 2);
            switch (rnd) {
                case 0:
                    if (JobLimits.healthcare.educator.principalphysiotherapist_ < JobLimits.healthcare.educator.principalphysiotherapist) {
                        if (LocalDB.MyFinalJob.JobTitle != "Principal Physiotherapy Educator") {
                            LocalDB.MyFinalJob.JobTitle = "Principal Physiotherapy Educator";
                            LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary4;
                            PromotionScreen.SetActive(true);
                            JobLimits.healthcare.educator.principalphysiotherapist_++;
                            return true;
                        }
                    } else {
                        Debug.Log("Can't promote as the job limit reached for Principal Physiotherapy Educator");
                    }
                    break;
                case 1:
                    if (JobLimits.healthcare.clinical.principalphysiotherapist_ < JobLimits.healthcare.clinical.principalphysiotherapist) {
                        if (LocalDB.MyFinalJob.JobTitle != "Principal Physiotherapist (Clinical)") {
                            LocalDB.MyFinalJob.JobTitle = "Principal Physiotherapist (Clinical)";
                            LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary2;
                            PromotionScreen.SetActive(true);
                            JobLimits.healthcare.clinical.principalphysiotherapist_++;
                            return true;
                        }
                    } else {
                        Debug.Log("Can't promote as the job limit reached for Principal Physiotherapist (Clinical)");
                    }
                    break;
            }
        } else if (gm.healthCareLevel3PrincipalPhysiotherapyEducator && gm.healthCareLevel3PrincipalPhysiotherapyResearcherJob) {
            int rnd = Random.Range(0, 2);
            switch (rnd) {
                case 0:
                    if (JobLimits.healthcare.educator.principalphysiotherapist_ < JobLimits.healthcare.educator.principalphysiotherapist) {
                        if (LocalDB.MyFinalJob.JobTitle != "Principal Physiotherapy Educator") {
                            LocalDB.MyFinalJob.JobTitle = "Principal Physiotherapy Educator";
                            LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary4;
                            PromotionScreen.SetActive(true);
                            JobLimits.healthcare.educator.principalphysiotherapist_++;
                            return true;
                        }
                    } else {
                        Debug.Log("Can't promote as the job limit reached for Principal Physiotherapy Educator");
                    }
                    break;
                case 1:
                    if (JobLimits.healthcare.researcher.principalphysiotherapist_ < JobLimits.healthcare.researcher.principalphysiotherapist) {
                        if (LocalDB.MyFinalJob.JobTitle != "Principal Physiotherapy Researcher") {
                            LocalDB.MyFinalJob.JobTitle = "Principal Physiotherapy Researcher";
                            LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary6;
                            PromotionScreen.SetActive(true);
                            JobLimits.healthcare.researcher.principalphysiotherapist_++;
                            return true;
                        }
                    } else {
                        Debug.Log("Can't promote as the job limit reached for Principal Physiotherapy Researcher");
                    }
                    break;
            }
        } else if (gm.healthCareLevel3PrincipalPhysiotherapistClinicalJob && gm.healthCareLevel3PrincipalPhysiotherapyResearcherJob) {
            int rnd = Random.Range(0, 2);
            switch (rnd) {
                case 0:
                    if (JobLimits.healthcare.clinical.principalphysiotherapist_ < JobLimits.healthcare.clinical.principalphysiotherapist) {
                        if (LocalDB.MyFinalJob.JobTitle != "Principal Physiotherapist (Clinical)") {
                            LocalDB.MyFinalJob.JobTitle = "Principal Physiotherapist (Clinical)";
                            LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary2;
                            PromotionScreen.SetActive(true);
                            JobLimits.healthcare.clinical.principalphysiotherapist_++;
                            return true;
                        }
                    } else {
                        Debug.Log("Can't promote as the job limit reached for Principal Physiotherapist (Clinical)");
                    }
                    break;
                case 1:
                    if (JobLimits.healthcare.researcher.principalphysiotherapist_ < JobLimits.healthcare.researcher.principalphysiotherapist) {
                        if (LocalDB.MyFinalJob.JobTitle != "Principal Physiotherapy Researcher") {
                            LocalDB.MyFinalJob.JobTitle = "Principal Physiotherapy Researcher";
                            LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary6;
                            PromotionScreen.SetActive(true);
                            JobLimits.healthcare.researcher.principalphysiotherapist_++;
                            return true;
                        }
                    } else {
                        Debug.Log("Can't promote as the job limit reached for Principal Physiotherapy Researcher");
                    }
                    break;
            }
        } else if (gm.healthCareLevel2SeniorPhysiotherapistJob) {
            if (JobLimits.healthcare.seniorphysiotherapist_ < JobLimits.healthcare.seniorphysiotherapist) {
                if (LocalDB.MyFinalJob.JobTitle != "Senior Physiotherapist") {
                    LocalDB.MyFinalJob.JobTitle = "Senior Physiotherapist";
                    LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary1;
                    PromotionScreen.SetActive(true);
                    JobLimits.healthcare.seniorphysiotherapist_++;
                    return true;
                }
            } else {
                Debug.Log("Can't promote as the job limit reached for Senior Physiotherapist");
            }
        } else if (gm.healthCareLevel1PhysiotherapistJob) {
            if (JobLimits.healthcare.physiotherapist_ < JobLimits.healthcare.physiotherapist) {
                if (LocalDB.MyFinalJob.JobTitle != "Physiotherapist") {
                    LocalDB.MyFinalJob.JobTitle = "Physiotherapist";
                    LocalDB.MyFinalJob.Salary = (int)gm.heathCareSalary0;
                    PromotionScreen.SetActive(true);
                    JobLimits.healthcare.physiotherapist_++;
                    return true;
                }
            } else {
                Debug.Log("Can't promote as the job limit reached for Physiotherapist");
            }
        }
        return false;
    }

    private bool PromoteHRJob() {
        GameManager gm = GameObject.FindObjectOfType<GameManager>();
        gm.hRJobEligibilityCheckFlow();
        if (gm.hRLevel4ChiefHumanResourceOfficerjob) {
            if (JobLimits.humanResources.CHRO_ < JobLimits.humanResources.CHRO) {
                if (LocalDB.MyFinalJob.JobTitle != "Chief Human Resource Officer") {
                    LocalDB.MyFinalJob.JobTitle = "Chief Human Resource Officer";
                    LocalDB.MyFinalJob.Salary = (int)gm.hrSalary9;
                    PromotionScreen.SetActive(true);
                    JobLimits.humanResources.CHRO_++;
                    return true;
                }
            } else {
                Debug.Log("Can't promote as the job limit reached for Chief Human Resource Officer");
            }
        }
        string[] str = LocalDB.MyFinalJob.JobTitle.Split(' ');
        if (str[str.Length - 1] == "Rewards") {
            if (gm.hRlevel3HeadPerformanceandRewardsjob) {
                if (JobLimits.humanResources.PR.head_ < JobLimits.humanResources.PR.head) {
                    if (LocalDB.MyFinalJob.JobTitle != "Head, Performance & Rewards") {
                        LocalDB.MyFinalJob.JobTitle = "Head, Performance & Rewards";
                        LocalDB.MyFinalJob.Salary = (int)gm.hrSalary2;
                        PromotionScreen.SetActive(true);
                        JobLimits.humanResources.PR.head_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Head, Performance & Rewards");
                }
            } else if (gm.hRlevel2ManagerPerformanceandRewardsjob) {
                if (JobLimits.humanResources.PR.manager_ < JobLimits.humanResources.PR.manager) {
                    if (LocalDB.MyFinalJob.JobTitle != "Manager, Performance & Rewards") {
                        LocalDB.MyFinalJob.JobTitle = "Manager, Performance & Rewards";
                        LocalDB.MyFinalJob.Salary = (int)gm.hrSalary1;
                        PromotionScreen.SetActive(true);
                        JobLimits.humanResources.PR.manager_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Manager, Performance & Rewards");
                }
            } else if (gm.hRlevel1ExecutivePerformanceandRewardsjob) {
                if (JobLimits.humanResources.PR.executive_ < JobLimits.humanResources.PR.executive) {
                    if (LocalDB.MyFinalJob.JobTitle != "Executive, Performance & Rewards") {
                        LocalDB.MyFinalJob.JobTitle = "Executive, Performance & Rewards";
                        LocalDB.MyFinalJob.Salary = (int)gm.hrSalary0;
                        PromotionScreen.SetActive(true);
                        JobLimits.humanResources.PR.executive_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Executive, Performance & Rewards");
                }
            }
        } else if (str[str.Length - 1] == "Relations") {
            Debug.Log(gm.hRLevel3HeadEmployeeExperienceAndRelationsjob + " == " + gm.hRLevel2ManagerEmployeeExperienceAndRelationsjob + " == " + gm.hRLevel1ExecutiveEmployeeExperienceAndReactionsjob);
            if (gm.hRLevel3HeadEmployeeExperienceAndRelationsjob) {
                if (JobLimits.humanResources.EER.head_ < JobLimits.humanResources.EER.head) {
                    if (LocalDB.MyFinalJob.JobTitle != "Head, Employee Experience & Relations") {
                        LocalDB.MyFinalJob.JobTitle = "Head, Employee Experience & Relations";
                        LocalDB.MyFinalJob.Salary = (int)gm.hrSalary8;
                        PromotionScreen.SetActive(true);
                        JobLimits.humanResources.EER.head_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Head, Employee Experience & Relations");
                }
            } else if (gm.hRLevel2ManagerEmployeeExperienceAndRelationsjob) {
                if (JobLimits.humanResources.EER.manager_ < JobLimits.humanResources.EER.manager) {
                    if (LocalDB.MyFinalJob.JobTitle != "Manager, Employee Experience & Relations") {
                        LocalDB.MyFinalJob.JobTitle = "Manager, Employee Experience & Relations";
                        LocalDB.MyFinalJob.Salary = (int)gm.hrSalary7;
                        PromotionScreen.SetActive(true);
                        JobLimits.humanResources.EER.manager_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Manager, Employee Experience & Relations");
                }
            } else if (gm.hRLevel1ExecutiveEmployeeExperienceAndReactionsjob) {
                if (JobLimits.humanResources.EER.executive_ < JobLimits.humanResources.EER.executive) {
                    if (LocalDB.MyFinalJob.JobTitle != "Executive, Employee Experience & Relations") {
                        LocalDB.MyFinalJob.JobTitle = "Executive, Employee Experience & Relations";
                        LocalDB.MyFinalJob.Salary = (int)gm.hrSalary6;
                        PromotionScreen.SetActive(true);
                        JobLimits.humanResources.EER.executive_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Executive, Employee Experience & Relations");
                }
            }
        } else if (str[str.Length - 1] == "Attraction") {
            if (gm.hRLevel3HeadTalentAndAttractionjob) {
                if (JobLimits.humanResources.TA.head_ < JobLimits.humanResources.TA.head) {
                    if (LocalDB.MyFinalJob.JobTitle != "Head, Talent & Attraction") {
                        LocalDB.MyFinalJob.JobTitle = "Head, Talent & Attraction";
                        LocalDB.MyFinalJob.Salary = (int)gm.hrSalary5;
                        PromotionScreen.SetActive(true);
                        JobLimits.humanResources.TA.head_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Head, Talent & Attraction");
                }
            } else if (gm.hRlevel2ManagerTalentAndAttractionjob) {
                if (JobLimits.humanResources.TA.manager_ < JobLimits.humanResources.TA.manager) {
                    if (LocalDB.MyFinalJob.JobTitle != "Manager, Talent & Attraction") {
                        LocalDB.MyFinalJob.JobTitle = "Manager, Talent & Attraction";
                        LocalDB.MyFinalJob.Salary = (int)gm.hrSalary4;
                        PromotionScreen.SetActive(true);
                        JobLimits.humanResources.TA.manager_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Manager, Talent & Attraction");
                }
            } else if (gm.hRLevel1ExecutiveTalentAndAttractionjob) {
                if (JobLimits.humanResources.TA.executive_ < JobLimits.humanResources.TA.executive) {
                    if (LocalDB.MyFinalJob.JobTitle != "Executive, Talent & Attraction") {
                        LocalDB.MyFinalJob.JobTitle = "Executive, Talent & Attraction";
                        LocalDB.MyFinalJob.Salary = (int)gm.hrSalary3;
                        PromotionScreen.SetActive(true);
                        JobLimits.humanResources.TA.executive_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Executive, Talent & Attraction");
                }
            }
        }
        return false;
    }

    private bool PromoteITJob() {
        GameManager gm = GameObject.FindObjectOfType<GameManager>();
        gm.ItJobEligibilityCheckFlow();
        string[] str = LocalDB.MyFinalJob.JobTitle.Split(' ');
        if (str[str.Length - 1] == "Designer") {
            if (gm.ItLevel4HeadOfProductjob) {
                if (JobLimits.informationTechnology.HOP_ < JobLimits.informationTechnology.HOP) {
                    if (LocalDB.MyFinalJob.JobTitle != "Head of Product") {
                        LocalDB.MyFinalJob.JobTitle = "Head of Product";
                        LocalDB.MyFinalJob.Salary = (int)gm.itSalary7;
                        PromotionScreen.SetActive(true);
                        JobLimits.informationTechnology.HOP_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Head of Product");
                }
            } else if (gm.iTLevel3LeadUXDesginerjob) {
                if (JobLimits.informationTechnology.Designer.leadUX_ < JobLimits.informationTechnology.Designer.leadUX) {
                    if (LocalDB.MyFinalJob.JobTitle != "Lead UX Designer") {
                        LocalDB.MyFinalJob.JobTitle = "Lead UX Designer";
                        LocalDB.MyFinalJob.Salary = (int)gm.itSalary6;
                        PromotionScreen.SetActive(true);
                        JobLimits.informationTechnology.Designer.leadUX_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Lead UX Designer");
                }
            } else if (gm.ItLevel2SeniorUXDesignerjob) {
                if (JobLimits.informationTechnology.Designer.serniorUX_ < JobLimits.informationTechnology.Designer.serniorUX) {
                    if (LocalDB.MyFinalJob.JobTitle != "Senior UX Designer") {
                        LocalDB.MyFinalJob.JobTitle = "Senior UX Designer";
                        LocalDB.MyFinalJob.Salary = (int)gm.itSalary5;
                        PromotionScreen.SetActive(true);
                        JobLimits.informationTechnology.Designer.serniorUX_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Senior UX Designer");
                }
            } else if (gm.iTLevel1UXDesignerjob) {
                if (JobLimits.informationTechnology.Designer.UX_ < JobLimits.informationTechnology.Designer.UX) {
                    if (LocalDB.MyFinalJob.JobTitle != "UX Designer") {
                        LocalDB.MyFinalJob.JobTitle = "UX Designer";
                        LocalDB.MyFinalJob.Salary = (int)gm.itSalary4;
                        PromotionScreen.SetActive(true);
                        JobLimits.informationTechnology.Designer.UX_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for UX Designer");
                }
            }
        } else {
            if (gm.iTLevel4ChiefTechnologyOfficerjob) {
                if (JobLimits.informationTechnology.CTO_ < JobLimits.informationTechnology.CTO) {
                    if (LocalDB.MyFinalJob.JobTitle != "Chief Technology Officer") {
                        LocalDB.MyFinalJob.JobTitle = "Chief Technology Officer";
                        LocalDB.MyFinalJob.Salary = (int)gm.itSalary3;
                        PromotionScreen.SetActive(true);
                        JobLimits.informationTechnology.CTO_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Chief Technology Officer");
                }
            } else if (gm.iTLevel3ApplicationArchitectjob) {
                if (JobLimits.informationTechnology.Applications.architect_ < JobLimits.informationTechnology.Applications.architect) {
                    if (LocalDB.MyFinalJob.JobTitle != "Applications Architect") {
                        LocalDB.MyFinalJob.JobTitle = "Applications Architect";
                        LocalDB.MyFinalJob.Salary = (int)gm.itSalary2;
                        PromotionScreen.SetActive(true);
                        JobLimits.informationTechnology.Applications.architect_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Applications Architect");
                }
            } else if (gm.ItLevel2ApplicationDevelopmentManager) {
                if (JobLimits.informationTechnology.Applications.manager_ < JobLimits.informationTechnology.Applications.manager) {
                    if (LocalDB.MyFinalJob.JobTitle != "Applications Development Manager") {
                        LocalDB.MyFinalJob.JobTitle = "Applications Development Manager";
                        LocalDB.MyFinalJob.Salary = (int)gm.itSalary1;
                        PromotionScreen.SetActive(true);
                        JobLimits.informationTechnology.Applications.manager_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reaced for Applications Development Manager");
                }
            } else if (gm.ItLevel1ApplicationDeveloperjob) {
                if (JobLimits.informationTechnology.Applications.developer_ < JobLimits.informationTechnology.Applications.developer) {
                    if (LocalDB.MyFinalJob.JobTitle != "Applications Developer") {
                        LocalDB.MyFinalJob.JobTitle = "Applications Developer";
                        LocalDB.MyFinalJob.Salary = (int)gm.itSalary0;
                        PromotionScreen.SetActive(true);
                        JobLimits.informationTechnology.Applications.developer_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Applications Developer");
                }
            }
        }
        return false;
    }

    private bool PromoteMediaJob() {
        GameManager gm = GameObject.FindObjectOfType<GameManager>();
        gm.mediaJobEligibilityCheckFlow();
        string[] str = LocalDB.MyFinalJob.JobTitle.Split(' ');
        if (str[str.Length-1] == "Assistant" || str[str.Length - 1] == "Broadcast") {
            if (gm.mediaLevel4ExecutiveProducerBroadcastjob) {
                if (JobLimits.media.Broadcast.Ep_ < JobLimits.media.Broadcast.Ep) {
                    if (LocalDB.MyFinalJob.JobTitle != "Executive Producer - Broadcast") {
                        LocalDB.MyFinalJob.JobTitle = "Executive Producer - Broadcast";
                        LocalDB.MyFinalJob.Salary = (int)gm.mediaSalary3;
                        PromotionScreen.SetActive(true);
                        JobLimits.media.Broadcast.Ep_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promot as the job limit reached for Executive Producer - Broadcast");
                }
            } else if (gm.mediaLevel3ProducerBroadcastjob) {
                if (JobLimits.media.Broadcast.producer_ < JobLimits.media.Broadcast.producer) {
                    if (LocalDB.MyFinalJob.JobTitle != "Producer - Broadcast") {
                        LocalDB.MyFinalJob.JobTitle = "Producer - Broadcast";
                        LocalDB.MyFinalJob.Salary = (int)gm.mediaSalary2;
                        PromotionScreen.SetActive(true);
                        JobLimits.media.Broadcast.producer_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Producer - Broadcast");
                }
            } else if (gm.mediaLevel2AssistantProducerBroadcastjob) {
                if (JobLimits.media.Broadcast.AP_ < JobLimits.media.Broadcast.AP) {
                    if (LocalDB.MyFinalJob.JobTitle != "Assistant Producer - Broadcast") {
                        LocalDB.MyFinalJob.JobTitle = "Assistant Producer - Broadcast";
                        LocalDB.MyFinalJob.Salary = (int)gm.mediaSalary1;
                        PromotionScreen.SetActive(true);
                        JobLimits.media.Broadcast.AP_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Assistant Producer - Broadcast");
                }
            } else if (gm.mediaLevel1ProductionAssistantjob) {
                if (JobLimits.media.PA_ < JobLimits.media.PA) {
                    if (LocalDB.MyFinalJob.JobTitle != "Production Assistant") {
                        LocalDB.MyFinalJob.JobTitle = "Production Assistant";
                        LocalDB.MyFinalJob.Salary = (int)gm.mediaSalary0;
                        PromotionScreen.SetActive(true);
                        JobLimits.media.PA_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Production Assistant");
                }
            }
        } else {
            if (gm.mediaLevel4ChiefEditorjob) {
                if (JobLimits.media.CE_ < JobLimits.media.CE) {
                    if (LocalDB.MyFinalJob.JobTitle != "Chief Editor") {
                        LocalDB.MyFinalJob.JobTitle = "Chief Editor";
                        LocalDB.MyFinalJob.Salary = (int)gm.mediaSalary7;
                        PromotionScreen.SetActive(true);
                        JobLimits.media.CE_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Chief Editor");
                }
            } else if (gm.mediaLevel3ExecutiveEditorjob) {
                if (JobLimits.media.EE_ < JobLimits.media.EE) {
                    if (LocalDB.MyFinalJob.JobTitle != "Executive Editor") {
                        LocalDB.MyFinalJob.JobTitle = "Executive Editor";
                        LocalDB.MyFinalJob.Salary = (int)gm.mediaSalary6;
                        PromotionScreen.SetActive(true);
                        JobLimits.media.EE_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reaced for Executive Editor");
                }
            } else if (gm.mediaLevel2SeniorReporterSeniorCorrespondentjob) {
                if (JobLimits.media.SRSC_ < JobLimits.media.SRSC) {
                    if (LocalDB.MyFinalJob.JobTitle != "Senior Reporter / Senior Correspondent") {
                        LocalDB.MyFinalJob.JobTitle = "Senior Reporter / Senior Correspondent";
                        LocalDB.MyFinalJob.Salary = (int)gm.mediaSalary5;
                        PromotionScreen.SetActive(true);
                        JobLimits.media.SRSC_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Senior Reporter / Senior Correspondent");
                }
            } else if (gm.mediaLevel1ReporterCorrespondentjob) {
                if (JobLimits.media.RC_ < JobLimits.media.RC) {
                    if (LocalDB.MyFinalJob.JobTitle != "Reporter / Correspondent") {
                        LocalDB.MyFinalJob.JobTitle = "Reporter / Correspondent";
                        LocalDB.MyFinalJob.Salary = (int)gm.mediaSalary4;
                        PromotionScreen.SetActive(true);
                        JobLimits.media.RC_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Reporter / Correspondent");
                }
            }
        }
        return false;
    }

    private bool PromoteRetailJob() {
        GameManager gm = GameObject.FindObjectOfType<GameManager>();
        gm.retailJobEligibilityCheckFlow();
        string[] str = LocalDB.MyFinalJob.JobTitle.Split(' ');
        if (gm.retailLevel4ChiefExecutiveOfficerManagingDirectorjob) {
            if (JobLimits.retail.CEOMD_ < JobLimits.retail.CEOMD) {
                if (LocalDB.MyFinalJob.JobTitle != "Chief Executive Officer / Managing Director") {
                    LocalDB.MyFinalJob.JobTitle = "Chief Executive Officer / Managing Director";
                    LocalDB.MyFinalJob.Salary = (int)gm.retailSalary6;
                    PromotionScreen.SetActive(true);
                    JobLimits.retail.CEOMD_++;
                    return true;
                }
            } else {
                Debug.Log("Can't promote as the job limit reached for Chief Executive Officer / Managing Director");
            }
        }
        if (str[0] == "Brand") {
            if (gm.retailLevel3BrandDirectorjob) {
                if (JobLimits.retail.brand.Director_ < JobLimits.retail.brand.Director) {
                    if (LocalDB.MyFinalJob.JobTitle != "Brand Director") {
                        LocalDB.MyFinalJob.JobTitle = "Brand Director";
                        LocalDB.MyFinalJob.Salary = (int)gm.retailSalary2;
                        PromotionScreen.SetActive(true);
                        JobLimits.retail.brand.Director_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Brand Director");
                }
            } else if (gm.retailLevel2BrandManagerjob) {
                if (JobLimits.retail.brand.Manager_ < JobLimits.retail.brand.Manager) {
                    if (LocalDB.MyFinalJob.JobTitle != "Brand Manager") {
                        LocalDB.MyFinalJob.JobTitle = "Brand Manager";
                        LocalDB.MyFinalJob.Salary = (int)gm.retailSalary1;
                        PromotionScreen.SetActive(true);
                        JobLimits.retail.brand.Manager_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reaced for Brand Manager");
                }
            } else if (gm.retailLevel1BrandAssociatejob) {
                if (JobLimits.retail.brand.Associate_ < JobLimits.retail.brand.Associate) {
                    if (LocalDB.MyFinalJob.JobTitle != "Brand Associate") {
                        LocalDB.MyFinalJob.JobTitle = "Brand Associate";
                        LocalDB.MyFinalJob.Salary = (int)gm.retailSalary0;
                        PromotionScreen.SetActive(true);
                        JobLimits.retail.brand.Associate_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Brand Associate");
                }
            }
        } else {
            if (gm.retailLevel3MerchandisingDirectorjob) {
                if (JobLimits.retail.merchandise.MD_ < JobLimits.retail.merchandise.MD) {
                    if (LocalDB.MyFinalJob.JobTitle != "Merchandising Director") {
                        LocalDB.MyFinalJob.JobTitle = "Merchandising Director";
                        LocalDB.MyFinalJob.Salary = (int)gm.retailSalary5;
                        PromotionScreen.SetActive(true);
                        JobLimits.retail.merchandise.MD_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Merchandising Director");
                }
            } else if (gm.retialLevel2MerchandisingManagerjob) {
                if (JobLimits.retail.merchandise.MM_ < JobLimits.retail.merchandise.MM) {
                    if (LocalDB.MyFinalJob.JobTitle != "Merchandising Manager") {
                        LocalDB.MyFinalJob.JobTitle = "Merchandising Manager";
                        LocalDB.MyFinalJob.Salary = (int)gm.retailSalary4;
                        PromotionScreen.SetActive(true);
                        JobLimits.retail.merchandise.MM_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Merchandising Manager");
                }
            } else if (gm.retailLevel1VisualMerchandiserjob) {
                if (JobLimits.retail.merchandise.VM_ < JobLimits.retail.merchandise.VM) {
                    if (LocalDB.MyFinalJob.JobTitle != "Visual Merchandiser") {
                        LocalDB.MyFinalJob.JobTitle = "Visual Merchandiser";
                        LocalDB.MyFinalJob.Salary = (int)gm.retailSalary3;
                        PromotionScreen.SetActive(true);
                        JobLimits.retail.merchandise.VM_++;
                        return true;
                    }
                } else {
                    Debug.Log("Can't promote as the job limit reached for Visual Merchandiser");
                }
            }
        }
        return false;
    }

    private float GetMultiplier(double mivalue) {
        Debug.Log("Getting Value: " + mivalue);
        switch (mivalue) {
            case 1:
                return 0.50f;
            case 2:
                return 0.60f;
            case 3:
                return 0.70f;
            case 4:
                return 0.80f;
            case 5:
                return 1.00f;
            case 6:
                return 1.10f;
            case 7:
                return 1.20f;
            case 8:
                return 1.30f;
            case 9:
                return 1.40f;
            case 10:
                return 1.50f;
            default:
                return -1f;
        }
    }

    private void UpdateSkillsValues() {
        for (int i = 0; i < LocalDB.SelectThree.Count; i++) {
            switch (LocalDB.SelectThree[i].ListName) {
                case AppData.Fields.Accountancy:
                    LocalDB.CurrentPlayer.Skills.Accountacy[LocalDB.SelectThree[i].Listindex].Cost += GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.Accountacy[LocalDB.SelectThree[i].Listindex].MI].cost);
                    break;
                case AppData.Fields.HumanResource:
                    LocalDB.CurrentPlayer.Skills.HR[LocalDB.SelectThree[i].Listindex].Cost += GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.HR[LocalDB.SelectThree[i].Listindex].MI].cost);
                    break;
                case AppData.Fields.HealthCare:
                    LocalDB.CurrentPlayer.Skills.HealtCare[LocalDB.SelectThree[i].Listindex].Cost += GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.HealtCare[LocalDB.SelectThree[i].Listindex].MI].cost);
                    break;
                case AppData.Fields.InformationTechnology:
                    LocalDB.CurrentPlayer.Skills.IT[LocalDB.SelectThree[i].Listindex].Cost += GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.IT[LocalDB.SelectThree[i].Listindex].MI].cost);
                    break;
                case AppData.Fields.Media:
                    LocalDB.CurrentPlayer.Skills.Media[LocalDB.SelectThree[i].Listindex].Cost += GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.Media[LocalDB.SelectThree[i].Listindex].MI].cost);
                    break;
                case AppData.Fields.Retail:
                    LocalDB.CurrentPlayer.Skills.Retail[LocalDB.SelectThree[i].Listindex].Cost += GetMultiplier(LocalDB.CurrentPlayer.MultipleIntelligence[LocalDB.CurrentPlayer.Skills.Retail[LocalDB.SelectThree[i].Listindex].MI].cost);
                    break;
            }
        }
        LocalDB.CurrentPlayer.UpdateSkillsValueEqually();
        LocalDB.CurrentPlayer.UpdateMyValues();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private string GetTitle(string ListName, int ListIndex)
    {
        switch (ListName)
        {
            case AppData.Fields.Accountancy:
                return LocalDB.CurrentPlayer.Skills.Accountacy[ListIndex].title;
            case AppData.Fields.HealthCare:
                return LocalDB.CurrentPlayer.Skills.HealtCare[ListIndex].title;
            case AppData.Fields.HumanResource:
                return LocalDB.CurrentPlayer.Skills.HR[ListIndex].title;
            case AppData.Fields.InformationTechnology:
                return LocalDB.CurrentPlayer.Skills.IT[ListIndex].title;
            case AppData.Fields.Media:
                return LocalDB.CurrentPlayer.Skills.Media[ListIndex].title;
            case AppData.Fields.Retail:
                return LocalDB.CurrentPlayer.Skills.Retail[ListIndex].title;
            default:
                return "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickContinueBtn() {
        if (ContinueEduBtn != null) {
            LocalDB.IsContinueEdu = true;
        }
        this.gameObject.SetActive(false);
        ContinueWork.SetActive(true);
    }
    public void onClickStatsBtn() {
        this.gameObject.SetActive(false);
        stats.SetActive(true);
    }
    public void onClickGameWorldBtn() {
        this.gameObject.SetActive(false);
        GamePlay.SetActive(true);
    }
}
