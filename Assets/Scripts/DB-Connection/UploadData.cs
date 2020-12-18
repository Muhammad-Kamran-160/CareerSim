using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Text;

public class UploadData : MonoBehaviour {
    
     [HideInInspector] public string PlayerDataJson;
    public DataBase DB;
    private void Start()
    {
        DB = GameObject.FindObjectOfType<DataBase>();
    }
    /*
    public void UploadAllData2(AppData AD, DataBase DB) {
        string name = "Sample name";                         // Player's name
        string industry = "Sample industry";          // Current industry in which player is working/job
        int bankaccount = 999;                     // Player's bank amount
        float satisfaction = 9.9f;     // Player's Satisfaction level
        int actionpoints = 9;   // Player's Remaining Action Points


        // Need checks...
        bool jobstatus = true;                      // Is working or not / Is fire
        string currentjob = "Sample job";         // Current Job title
        int salary = 9999;                          // Player's Salary// Need Checks...
        // Need further checks....
        int joblevel = 9;                        // Current Job level

        //if (!string.IsNullOrEmpty(AD.CurrentPlayer.MyJob.FieldName) && !string.IsNullOrEmpty(AD.CurrentPlayer.MyJob.JobTitle)) {
        //    jobstatus = true;
        //    currentjob = AD.CurrentPlayer.MyJob.JobTitle;
        //    salary = AD.CurrentPlayer.MyJob.Salary;
        //    // need further checks...
        //    joblevel = GetJobLevel(AD.CurrentPlayer.MyJob.JobTitle);
        //}
        string educationlevel = "PHD-9";               // Latest Education
        //if (AD.CurrentPlayer.Phd.Count > 0) {
        //    educationlevel = AD.CurrentPlayer.Phd[AD.CurrentPlayer.Phd.Count - 1].edu;
        //} else if (AD.CurrentPlayer.Mast.Count > 0) {
        //    educationlevel = AD.CurrentPlayer.Mast[AD.CurrentPlayer.Mast.Count - 1].edu;
        //} else if (AD.CurrentPlayer.Bach.Count > 0) {
        //    educationlevel = AD.CurrentPlayer.Bach[AD.CurrentPlayer.Bach.Count - 1].edu;
        //} else if (AD.CurrentPlayer.Poly.Count > 0) {
        //    educationlevel = AD.CurrentPlayer.Poly[AD.CurrentPlayer.Poly.Count - 1].edu;
        //} else if (AD.CurrentPlayer.Educations.Count > 0) {
        //    educationlevel = AD.CurrentPlayer.Educations[AD.CurrentPlayer.Educations.Count - 1].edu;
        //} else {
        //    educationlevel = null;
        //}
        string[] skills = new string[1] { "skill-999" };                     // Skills of player
        //if (AD.CurrentPlayer.MyValues.Count > 0) {
        //    skills = new string[AD.CurrentPlayer.MyValues.Count];
        //    for (int i = 0; i < skills.Length; i++) {
        //        skills[i] = AD.CurrentPlayer.MyValues[i].title;
        //    }
        //}
        MyPlayerPossession p = new MyPlayerPossession("sample possession 9", "sample category - 9");
       /////////////// p._id = "";
        MyPlayerPossession[] possessions = new MyPlayerPossession[1] { p };    // Player's Possessions
        //if (AD.CurrentPlayer.ShopPossessions.Count > 0) {
        //    possessions = new MyPlayerPossession[AD.CurrentPlayer.ShopPossessions.Count];
        //    for (int i = 0; i < possessions.Length; i++) {
        //        possessions[i] = new MyPlayerPossession(AD.CurrentPlayer.ShopPossessions[i].Name, AD.CurrentPlayer.ShopPossessions[i].Category);
        //    }
        //}
        MyPlayerData MPD = new MyPlayerData(name, industry, joblevel, currentjob, educationlevel, bankaccount, jobstatus, satisfaction, salary, actionpoints, skills, possessions);

        // Upload: MPD Object here...
        PlayerDataJson = JsonUtility.ToJson(MPD);
        //UnityWebRequest www = UnityWebRequest.Post("http://18.223.239.177/hello/player/update/123", PlayerDataJson);
        //www.SendWebRequest();
        
    }
    */
    public void UploadAllData(AppData AD, DataBase DB, int rn) {
        string name = AD.CurrentPlayer.Name;                         // Player's name
        string gameID = AD.game_id_data;

        string industry = "null";          // Current industry in which player is working/job
        if (!string.IsNullOrEmpty(AD.MyFinalJob.FieldName))
        {
            industry = AD.MyFinalJob.FieldName;
        }
        int bankaccount = AD.CurrentPlayer.Bank;                     // Player's bank amount
        float satisfaction = AD.CurrentPlayer.SatisfactionLevel;     // Player's Satisfaction level
        int actionpoints = AD.CurrentPlayer.RemainingActionPoints;   // Player's Remaining Action Points


        // Need checks...
        bool jobstatus = false;                      // Is working or not / Is fire
        string currentjob = "null";         // Current Job title
        int salary = 0;                          // Player's Salary// Need Checks...
        // Need further checks....
        int joblevel = 0;                        // Current Job level

        if (!string.IsNullOrEmpty(AD.MyFinalJob.FieldName) && !string.IsNullOrEmpty(AD.MyFinalJob.JobTitle)) {
            jobstatus = true;
            currentjob = AD.MyFinalJob.JobTitle;
            salary = AD.MyFinalJob.Salary;
            // need further checks...
            joblevel = GetJobLevel(AD.MyFinalJob.JobTitle);
        }
        string educationlevel = null;               // Latest Education
        if (AD.CurrentPlayer.Phd.Count > 0) {
            educationlevel = AD.CurrentPlayer.Phd[AD.CurrentPlayer.Phd.Count - 1].edu;
        } else if (AD.CurrentPlayer.Mast.Count > 0) {
            educationlevel = AD.CurrentPlayer.Mast[AD.CurrentPlayer.Mast.Count - 1].edu;
        } else if (AD.CurrentPlayer.Bach.Count > 0) {
            educationlevel = AD.CurrentPlayer.Bach[AD.CurrentPlayer.Bach.Count - 1].edu;
        } else if (AD.CurrentPlayer.Poly.Count > 0) {
            educationlevel = AD.CurrentPlayer.Poly[AD.CurrentPlayer.Poly.Count - 1].edu;
        } else if (AD.CurrentPlayer.Educations.Count > 0) {
            educationlevel = AD.CurrentPlayer.Educations[AD.CurrentPlayer.Educations.Count - 1].edu;
        } else {
            educationlevel = "null";
        }
        string[] skills = null;                     // Skills of player
        if (AD.CurrentPlayer.MyValues.Count > 0) {
            skills = new string[AD.CurrentPlayer.MyValues.Count];
            for (int i = 0; i < skills.Length; i++) {
                if (AD.CurrentPlayer.MyValues[i].Cost > 0)
                {
                    skills[i] = AD.CurrentPlayer.MyValues[i].title;
                }
                else
                {
                    skills[i] = "null";
                }
            }
        }
        MyPlayerPossession[] possessions = null;    // Player's Possessions
        if (AD.CurrentPlayer.ShopPossessions.Count > 0) {
            possessions = new MyPlayerPossession[AD.CurrentPlayer.ShopPossessions.Count];
            for (int i = 0; i < possessions.Length; i++) {
                possessions[i] = new MyPlayerPossession(AD.CurrentPlayer.ShopPossessions[i].Name, AD.CurrentPlayer.ShopPossessions[i].Category);
            }
        }
        MyPlayerData MPD = new MyPlayerData(name, gameID, industry, joblevel, currentjob, educationlevel, bankaccount, jobstatus, 
            satisfaction, salary, actionpoints, skills, possessions);
        MPD.roundno = rn;
        // Upload: MPD Object here...
        //Debug.Log("Sending...");
        PlayerDataJson = JsonUtility.ToJson(MPD);
        //UnityWebRequest www = UnityWebRequest.Post("http://18.223.239.177/hello/addplayer/", PlayerDataJson);

        StartCoroutine(SendInitialData());

        //var request = new UnityWebRequest("http://18.223.239.177/hello/addplayer/", "POST");
        //byte[] bodyRaw = Encoding.UTF8.GetBytes(PlayerDataJson);
        //request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        //request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        //request.SetRequestHeader("Content-Type", "application/json");
        //request.SendWebRequest();


        //var request = new UnityWebRequest("http://18.223.239.177/hello/addplayer/", "POST");
        //byte[] bodyRaw = Encoding.UTF8.GetBytes(PlayerDataJson);
        //request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        //request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        //request.SetRequestHeader("Content-Type", "application/json");
        //yield return request.SendWebRequest();
        //Debug.Log("Status Code: " + request.responseCode);
        //www.SendWebRequest();

        //Debug.Log("Send...");
    }
    public IEnumerator SendInitialData()
    {
        var request = new UnityWebRequest("http://18.223.239.177/hello/addplayer/", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(PlayerDataJson);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string data = request.downloadHandler.text;
            MyPlayerData MPD = JsonUtility.FromJson<MyPlayerData>(data);
            //Debug.Log("_ID received: " + MPD._id);
            DB._id_Player = MPD._id;
        }
    }
    public void UploadAllData_Last(AppData AD, DataBase DB, int a)
    {
        string name = AD.CurrentPlayer.Name;                         // Player's name
        string gameID = AD.game_id_data;

        string industry = "null";          // Current industry in which player is working/job
        if (!string.IsNullOrEmpty(AD.MyFinalJob.FieldName))
        {
            industry = AD.MyFinalJob.FieldName;
        }
        int bankaccount = AD.CurrentPlayer.Bank;                     // Player's bank amount
        float satisfaction = AD.CurrentPlayer.SatisfactionLevel;     // Player's Satisfaction level
        int actionpoints = AD.CurrentPlayer.RemainingActionPoints;   // Player's Remaining Action Points


        // Need checks...
        bool jobstatus = false;                      // Is working or not / Is fire
        string currentjob = "null";         // Current Job title
        int salary = 0;                          // Player's Salary// Need Checks...
        // Need further checks....
        int joblevel = 0;                        // Current Job level

        if (!string.IsNullOrEmpty(AD.MyFinalJob.FieldName) && !string.IsNullOrEmpty(AD.MyFinalJob.JobTitle))
        {
            jobstatus = true;
            currentjob = AD.MyFinalJob.JobTitle;
            salary = AD.MyFinalJob.Salary;
            // need further checks...
            joblevel = GetJobLevel(AD.MyFinalJob.JobTitle);
        }
        string educationlevel = null;               // Latest Education
        if (AD.CurrentPlayer.Phd.Count > 0)
        {
            educationlevel = AD.CurrentPlayer.Phd[AD.CurrentPlayer.Phd.Count - 1].edu;
        }
        else if (AD.CurrentPlayer.Mast.Count > 0)
        {
            educationlevel = AD.CurrentPlayer.Mast[AD.CurrentPlayer.Mast.Count - 1].edu;
        }
        else if (AD.CurrentPlayer.Bach.Count > 0)
        {
            educationlevel = AD.CurrentPlayer.Bach[AD.CurrentPlayer.Bach.Count - 1].edu;
        }
        else if (AD.CurrentPlayer.Poly.Count > 0)
        {
            educationlevel = AD.CurrentPlayer.Poly[AD.CurrentPlayer.Poly.Count - 1].edu;
        }
        else if (AD.CurrentPlayer.Educations.Count > 0)
        {
            educationlevel = AD.CurrentPlayer.Educations[AD.CurrentPlayer.Educations.Count - 1].edu;
        }
        else
        {
            educationlevel = "null";
        }
        string[] skills = null;                     // Skills of player
        if (AD.CurrentPlayer.MyValues.Count > 0)
        {
            skills = new string[AD.CurrentPlayer.MyValues.Count];
            for (int i = 0; i < skills.Length; i++)
            {
                if (AD.CurrentPlayer.MyValues[i].Cost > 0)
                {
                    skills[i] = AD.CurrentPlayer.MyValues[i].title;
                }
                else
                {
                    skills[i] = "null";
                }
            }
        }
        MyPlayerPossession[] possessions = null;    // Player's Possessions
        if (AD.CurrentPlayer.ShopPossessions.Count > 0)
        {
            possessions = new MyPlayerPossession[AD.CurrentPlayer.ShopPossessions.Count];
            for (int i = 0; i < possessions.Length; i++)
            {
                possessions[i] = new MyPlayerPossession(AD.CurrentPlayer.ShopPossessions[i].Name, AD.CurrentPlayer.ShopPossessions[i].Category);
            }
        }
        MyPlayerData MPD = new MyPlayerData(name, gameID, industry, joblevel, currentjob, educationlevel, bankaccount, jobstatus,
            satisfaction, salary, actionpoints, skills, possessions);
        MPD._id = DB._id_Player;
        MPD.roundno = a;
        // Upload: MPD Object here...
        Debug.Log("Sending Last...");
        PlayerDataJson = JsonUtility.ToJson(MPD);
        //UnityWebRequest www = UnityWebRequest.Post("http://18.223.239.177/hello/addplayer/", PlayerDataJson);

        StartCoroutine(SendLastData());

        //var request = new UnityWebRequest("http://18.223.239.177/hello/addplayer/", "POST");
        //byte[] bodyRaw = Encoding.UTF8.GetBytes(PlayerDataJson);
        //request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        //request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        //request.SetRequestHeader("Content-Type", "application/json");
        //request.SendWebRequest();


        //var request = new UnityWebRequest("http://18.223.239.177/hello/addplayer/", "POST");
        //byte[] bodyRaw = Encoding.UTF8.GetBytes(PlayerDataJson);
        //request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        //request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        //request.SetRequestHeader("Content-Type", "application/json");
        //yield return request.SendWebRequest();
        //Debug.Log("Status Code: " + request.responseCode);
        //www.SendWebRequest();

        Debug.Log("Send Last...");
    }
    public IEnumerator SendLastData()
    {
        DataBase DB = GameObject.FindObjectOfType<DataBase>();
        var request = new UnityWebRequest("http://18.223.239.177/hello/player/update/" + DB._id_Player, "POST");
        
        Debug.Log("Sending Json: " + PlayerDataJson);

        byte[] bodyRaw = Encoding.UTF8.GetBytes(PlayerDataJson);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            string data = request.downloadHandler.text;
            Debug.Log("Response returned: " + data);
        }
        else
        {
            string data = request.downloadHandler.text;
            Debug.Log("Response returned: " + data);
            //MyPlayerData MPD = JsonUtility.FromJson<MyPlayerData>(data);
            //Debug.Log("_ID received: " + MPD._id);
            //DB._id_Player = MPD._id;
        }
    }
    public int GetJobLevel(string jobTitle) {
        switch (jobTitle) {
            case "Chief Financial Officer":                                             return 4;
            case "Management Accounting - Accounting Executive":                        return 1;
            case "Management Accounting - Financial Planning and Analysis Manager":     return 2;
            case "Management Accounting - Business Controller":                         return 3;
            case "Financial Accounting - Accounts Executive":                           return 1;
            case "Financial Accounting - Finance Manager":                              return 2;
            case "Financial Accounting - Financial Controller":                         return 3;

            case "Senior Principal Physiotherapy Researcher":                           return 4;
            case "Senior Principal Physiotherapist (Clinical)":                         return 4;
            case "Senior Principal Physiotherapy Educator":                             return 4;
            case "Principal Physiotherapy Educator":                                    return 3;
            case "Principal Physiotherapist (Clinical)":                                return 3;
            case "Principal Physiotherapy Researcher":                                  return 3;
            case "Senior Physiotherapist":                                              return 2;
            case "Physiotherapist":                                                     return 1;

            case "Chief Human Resource Officer":                                        return 4;
            case "Head, Performance & Rewards":                                         return 3;
            case "Manager, Performance & Rewards":                                      return 2;
            case "Executive, Performance & Rewards":                                    return 1;
            case "Head, Employee Experience & Relations":                               return 3;
            case "Manager, Employee Experience & Relations":                            return 2;
            case "Executive, Employee Experience & Relations":                          return 1;
            case "Head, Talent & Attraction":                                           return 3;
            case "Manager, Talent & Attraction":                                        return 2;
            case "Executive, Talent & Attraction":                                      return 1;

            case "Head of Product":                                                     return 4;
            case "Lead UX Designer":                                                    return 3;
            case "Senior UX Designer":                                                  return 2;
            case "UX Designer":                                                         return 1;
            case "Chief Technology Officer":                                            return 4;
            case "Applications Architect":                                              return 3;
            case "Applications Development Manager":                                    return 2;
            case "Applications Developer":                                              return 1;

            case "Executive Producer - Broadcast":                                      return 4;
            case "Producer - Broadcast":                                                return 3;
            case "Assistant Producer Broadcast":                                        return 2;
            case "Production Assistant":                                                return 1;
            case "Chief Editor":                                                        return 4;
            case "Executive Editor":                                                    return 3;
            case "Senior Reporter / Senior Correspondent":                              return 2;
            case "Reporter / Correspondent":                                            return 1;

            case "Chief Executive Officer / Managing Director":                         return 4;
            case "Brand Director":                                                      return 3;
            case "Brand Manager":                                                       return 2;
            case "Brand Associate":                                                     return 1;
            case "Merchandising Director":                                              return 3;
            case "Merchandising Manager":                                               return 2;
            case "Visual Merchandiser":                                                 return 1;
            
            default:
                return 0;
        }
    }
}
[System.Serializable]
public class MyPlayerData {
    public string _id;
    public string name;                         // Player's name
    public string gameid;                       // Gameid of player, get it from the provided url.
    public int roundno;
    public string industry;                     // Current industry in which player is working/job
    public int joblevel;                        // Current Job level
    public string currentjob;                   // Current Job title
    public string educationlevel;               // Latest Education
    public int bankaccount;                     // Player's bank amount
    public bool jobstatus;                      // Is working or not / Is fire
    public float satisfaction;                  // Player's Satisfaction level
    public int salary;                          // Player's Salary
    public int actionpoints;                    // Player's Remaining Action Points
    public MyPlayerPossession[] possessions;    // Player's Possessions
    public string[] skills;                     // Skills of player

    public MyPlayerData(string playerName) {
        this.name = playerName;
        this.industry = null;
        this.joblevel = 0;
        this.currentjob = null;
        this.educationlevel = null;
        this.bankaccount = 0;
        this.jobstatus = false;
        this.satisfaction = 5.0f;
        this.salary = 0;
        this.actionpoints = 0;
        this.skills = null;
        this.possessions = null;
    }
    public MyPlayerData(string playerName, string gameID, string industry, int joblevel, string currentjob, string educationlevel, int bankaccount, bool jobstatus, 
        float satisfaction, int salary, int actionpoints, string[] skill, MyPlayerPossession[] possessions) {

        this.name = playerName;
        this.gameid = gameID;
        this.industry = industry;
        this.joblevel = joblevel;
        this.currentjob = currentjob;
        this.educationlevel = educationlevel;
        this.bankaccount = bankaccount;
        this.jobstatus = jobstatus;
        this.satisfaction = satisfaction;
        this.salary = salary;
        this.actionpoints = actionpoints;
        this.skills = skill;
        this.possessions = possessions;
    }

}
[System.Serializable]
public class MyPlayerPossession {
    //public string _id;
    public string name;             // Name/Title of possession
    public string value;            // Caregory of possession
    public MyPlayerPossession(string name, string value) {
        this.name = name;
        this.value = value;
    }
}
[System.Serializable]
public class GameIdData {
    public string _id;
    public int gameno;
    public int totalrounds;
    public int roundno;
    public int duration;
    public string token;
    public int actionpoints;
    public int money;
    public bool start;
}
public class IdClassStructure {
    public string industry;
    public int joblevel;
    public string currentjob;
    public string educationlevel;
    public int bankaccount;
    public bool jobstatus;
    public float satisfaction;
    public int salary;
    public int actionpoints;
    public string[] skills;
    public string _id;
    public string name;
}

[Serializable]
public class Accounting {
    public int total_upper;
    public ManagementAccounting managementAccounting;
    public FinancialAccounting financialAccounting;
    public string token;
    public int CFO;
    public int CFO_;
    public string _id;
    public int total_lower;
}
[Serializable]
public class ManagementAccounting {
    public int AE;
    public int AE_;
    public int FPAM;
    public int FPAM_;
    public int MABC;
    public int MABC_;
}
[Serializable]
public class FinancialAccounting {
    public int AE;
    public int AE_;
    public int FM;
    public int FM_;
    public int FC;
    public int FC_;
}
[Serializable]
public class Media {
    public string _id;
    public int total_upper;
    public string token;
    public int PA;
    public int PA_;
    public BroadCast Broadcast;
    public int RC;
    public int RC_;
    public int SRSC;
    public int SRSC_;
    public int EE;
    public int EE_;
    public int CE;
    public int CE_;
    public int total_lower;
}
[Serializable]
public class BroadCast {
    public int AP;
    public int AP_;
    public int producer;
    public int producer_;
    public int Ep;
    public int Ep_;
}
[Serializable]
public class Retail {
    public string _id;
    public int total_upper;
    public int token;
    public Brand brand;
    public Merchandise merchandise;
    public int CEOMD;
    public int CEOMD_;
    public int total_lower;
}
[Serializable]
public class Brand {
    public int Associate;
    public int Associate_;
    public int Manager;
    public int Manager_;
    public int Director;
    public int Director_;
}
[Serializable]
public class Merchandise {
    public int VM;
    public int VM_;
    public int MM;
    public int MM_;
    public int MD;
    public int MD_;
}
[Serializable]
public class InformationTechnology {
    public string _id;
    public int total_upper;
    public string token;
    public Application Applications;
    public int CTO;
    public int CTO_;
    public Designeer Designer;
    public int HOP;
    public int HOP_;
    public int total_lower;
}
[Serializable]
public class Application {
    public int developer;
    public int developer_;
    public int manager;
    public int manager_;
    public int architect;
    public int architect_;
}
[Serializable]
public class Designeer {
    public int UX;
    public int UX_;
    public int serniorUX;
    public int serniorUX_;
    public int leadUX;
    public int leadUX_;
}
[Serializable]
public class HumanResources {
    public string _id;
    public int total_upper;
    public string token;
    public Pr PR;
    public Ta TA;
    public Eer EER;
    public int CHRO;
    public int CHRO_;
    public int total_lower;
}
[Serializable]
public class Pr {
    public int executive;
    public int executive_;
    public int manager;
    public int manager_;
    public int head;
    public int head_;
}
[Serializable]
public class Ta {
    public int executive;
    public int executive_;
    public int manager;
    public int manager_;
    public int head;
    public int head_;
}
[Serializable]
public class Eer {
    public int executive;
    public int executive_;
    public int manager;
    public int manager_;
    public int head;
    public int head_;
}
[Serializable]
public class Healthcare {
    public string _id;
    public int total_upper;
    public string token;
    public int physiotherapist;
    public int physiotherapist_;
    public int seniorphysiotherapist;
    public int seniorphysiotherapist_;
    public Clinical clinical;
    public Educator educator;
    public Researcher researcher;
    public int total_lower;
}
[Serializable]
public class Clinical {
    public int principalphysiotherapist;
    public int principalphysiotherapist_;
    public int serniorphysiotherapist;
    public int serniorphysiotherapist_;
}
[Serializable]
public class Educator {
    public int principalphysiotherapist;
    public int principalphysiotherapist_;
    public int serniorphysiotherapist;
    public int serniorphysiotherapist_;
}
[Serializable]
public class Researcher {
    public int principalphysiotherapist;
    public int principalphysiotherapist_;
    public int serniorphysiotherapist;
    public int serniorphysiotherapist_;
}

[Serializable]
public class MyLifeCardData
{
    public string _id;
    public int choice;
    public string description;
    public int actionpoints;
    public string possession;
    public string[] skills;
    public int money;
}