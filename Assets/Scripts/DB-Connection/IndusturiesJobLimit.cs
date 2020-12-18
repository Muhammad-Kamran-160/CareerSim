using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class IndusturiesJobLimit : MonoBehaviour {
    private DataBase DB;

    public Accounting accounting;
    public Healthcare healthcare;
    public HumanResources humanResources;
    public InformationTechnology informationTechnology;
    public Retail retail;
    public Media media;

    private string JsonData;

    private void Start() {
        DB = GetComponent<DataBase>();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftAlt)) {
            GetJobLimitsData();
        }
    }
    public void GetJobLimitsData() {
        StartCoroutine(LoadAccountanceyJobLimits());
        StartCoroutine(LoadHealtCareJobsLimits());
        StartCoroutine(LoadHumanResourceJobLimits());
        StartCoroutine(LoadInformationTechnologyJobLimits());
        StartCoroutine(LoadMediaJoLimits());
        StartCoroutine(LoadRetailJobLimits());
    }
    public void SendJobLimitsData() {
        StartCoroutine(SendAccountanceyJobLimits());
        StartCoroutine(SendHealtCareJobsLimits());
        StartCoroutine(SendHumanResourceJobLimits());
        StartCoroutine(SendInformationTechnologyJobLimits());
        StartCoroutine(SendMediaJoLimits());
        StartCoroutine(SendRetailJobLimits());
    }

    private IEnumerator LoadAccountanceyJobLimits() {
        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/getaccountancy/" + DB.GameCode);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            JsonData = www.downloadHandler.text;
            accounting = JsonUtility.FromJson<Accounting>(JsonData);
            {
                int max = -1;
                if (accounting.CFO > max) max = accounting.CFO;
                if (accounting.financialAccounting.AE > max) max = accounting.financialAccounting.AE;
                if (accounting.financialAccounting.FC > max) max = accounting.financialAccounting.FC;
                if (accounting.financialAccounting.FM > max) max = accounting.financialAccounting.FM;
                if (accounting.managementAccounting.AE > max) max = accounting.managementAccounting.AE;
                if (accounting.managementAccounting.FPAM > max) max = accounting.managementAccounting.FPAM;
                if (accounting.managementAccounting.MABC > max) max = accounting.managementAccounting.MABC;
                accounting.total_upper = max;
                // sending data here...
                StartCoroutine(SendAccountanceyJobLimits());
            }
        }
    }
    private IEnumerator SendAccountanceyJobLimits() {
        var request = new UnityWebRequest("http://18.223.239.177/hello/update/accountancy", "POST");
        string jsonData = JsonUtility.ToJson(accounting);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) {
            Debug.Log("Error sending data of Accountancy");
        } else {
            //Debug.Log("Accountancy data sent successfully: " + request.downloadHandler.text);
        }
    }
    private IEnumerator LoadHealtCareJobsLimits() {
        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/gethealthcare/" + DB.GameCode);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            JsonData = www.downloadHandler.text;
            healthcare = JsonUtility.FromJson<Healthcare>(JsonData);
            {
                int max = -1;
                if (healthcare.physiotherapist > max) max = healthcare.physiotherapist;
                if (healthcare.seniorphysiotherapist > max) max = healthcare.seniorphysiotherapist;
                if (healthcare.clinical.principalphysiotherapist > max) max = healthcare.clinical.principalphysiotherapist;
                if (healthcare.clinical.serniorphysiotherapist > max) max = healthcare.clinical.serniorphysiotherapist;
                if (healthcare.educator.principalphysiotherapist > max) max = healthcare.educator.principalphysiotherapist;
                if (healthcare.educator.serniorphysiotherapist > max) max = healthcare.educator.serniorphysiotherapist;
                if (healthcare.researcher.principalphysiotherapist > max) max = healthcare.researcher.principalphysiotherapist;
                if (healthcare.researcher.serniorphysiotherapist > max) max = healthcare.researcher.serniorphysiotherapist;
                healthcare.total_upper = max;
                // sending data here...
                StartCoroutine(SendHealtCareJobsLimits());
            }
        }
    }
    private IEnumerator SendHealtCareJobsLimits() {
        var request = new UnityWebRequest("http://18.223.239.177/hello/update/healthcare", "POST");
        string jsonData = JsonUtility.ToJson(healthcare);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) {
            Debug.Log("Error sending data of HC");
        } else {
            //Debug.Log("HC data sent successfully: " + request.downloadHandler.text);
        }
    }
    private IEnumerator LoadHumanResourceJobLimits() {
        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/gethr/" + DB.GameCode);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            JsonData = www.downloadHandler.text;
            humanResources = JsonUtility.FromJson<HumanResources>(JsonData);
            {
                int max = -1;
                if (humanResources.CHRO > max) max = humanResources.CHRO;
                if (humanResources.PR.executive > max) max = humanResources.PR.executive;
                if (humanResources.PR.manager > max) max = humanResources.PR.manager;
                if (humanResources.PR.head > max) max = humanResources.PR.head;
                if (humanResources.TA.executive > max) max = humanResources.TA.executive;
                if (humanResources.TA.manager > max) max = humanResources.TA.manager;
                if (humanResources.TA.head > max) max = humanResources.TA.head;
                if (humanResources.EER.executive > max) max = humanResources.EER.executive;
                if (humanResources.EER.manager > max) max = humanResources.EER.manager;
                if (humanResources.EER.head > max) max = humanResources.EER.head;
                humanResources.total_upper = max;
                // sending data here...
                StartCoroutine(SendHumanResourceJobLimits());
            }
        }
    }
    private IEnumerator SendHumanResourceJobLimits() {
        var request = new UnityWebRequest("http://18.223.239.177/hello/update/HR", "POST");
        string jsonData = JsonUtility.ToJson(humanResources);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) {
            Debug.Log("Error sending data of HR");
        } else {
            //Debug.Log("HR data sent successfully" + request.downloadHandler.text);
        }
    }
    private IEnumerator LoadInformationTechnologyJobLimits() {
        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/getIt/" + DB.GameCode);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            JsonData = www.downloadHandler.text;
            informationTechnology = JsonUtility.FromJson<InformationTechnology>(JsonData);
            {
                int max = -1;
                if (informationTechnology.CTO > max) max = informationTechnology.CTO;
                if (informationTechnology.HOP > max) max = informationTechnology.HOP;
                if (informationTechnology.Applications.architect > max) max = informationTechnology.Applications.architect;
                if (informationTechnology.Applications.developer > max) max = informationTechnology.Applications.developer;
                if (informationTechnology.Applications.manager > max) max = informationTechnology.Applications.manager;
                if (informationTechnology.Designer.leadUX > max) max = informationTechnology.Designer.leadUX;
                if (informationTechnology.Designer.serniorUX > max) max = informationTechnology.Designer.serniorUX;
                if (informationTechnology.Designer.UX > max) max = informationTechnology.Designer.UX;
                informationTechnology.total_upper = max;
                // sending data here...
                StartCoroutine(SendInformationTechnologyJobLimits());
            }
        }
    }
    private IEnumerator SendInformationTechnologyJobLimits() {
        var request = new UnityWebRequest("http://18.223.239.177/hello/update/IT", "POST");
        string jsonData = JsonUtility.ToJson(informationTechnology);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) {
            Debug.Log("Error sending data of IT");
        } else {
            //Debug.Log("IT data sent successfully" + request.downloadHandler.text);
        }
    }
    private IEnumerator LoadRetailJobLimits() {
        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/getretail/" + DB.GameCode);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            JsonData = www.downloadHandler.text;
            retail = JsonUtility.FromJson<Retail>(JsonData);
            {
                int max = -1;
                if (retail.CEOMD > max) max = retail.CEOMD;
                if (retail.brand.Associate > max) max = retail.brand.Associate;
                if (retail.brand.Director > max) max = retail.brand.Director;
                if (retail.brand.Manager > max) max = retail.brand.Manager;
                if (retail.merchandise.MD > max) max = retail.merchandise.MD;
                if (retail.merchandise.MM > max) max = retail.merchandise.MM;
                if (retail.merchandise.VM > max) max = retail.merchandise.VM;
                retail.total_upper = max;
                // sending data here...
                StartCoroutine(SendRetailJobLimits());
            }
        }
    }
    private IEnumerator SendRetailJobLimits() {
        var request = new UnityWebRequest("http://18.223.239.177/hello/update/retail", "POST");
        string jsonData = JsonUtility.ToJson(retail);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) {
            Debug.Log("Error sending data of Retail");
        } else {
            //Debug.Log("Retail data sent successfully" + request.downloadHandler.text);
        }
    }
    private IEnumerator LoadMediaJoLimits() {
        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/getmedia/" + DB.GameCode);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            JsonData = www.downloadHandler.text;
            media = JsonUtility.FromJson<Media>(JsonData);
            {
                int max = -1;
                if (media.CE > max) max = media.CE;
                if (media.EE > max) max = media.EE;
                if (media.PA > max) max = media.PA;
                if (media.RC > max) max = media.RC;
                if (media.SRSC > max) max = media.SRSC;
                if (media.Broadcast.AP > max) max = media.Broadcast.AP;
                if (media.Broadcast.Ep > max) max = media.Broadcast.Ep;
                if (media.Broadcast.producer > max) max = media.Broadcast.producer;
                media.total_upper = max;
                // sending data here...
                StartCoroutine(SendMediaJoLimits());
            }
        }
    }
    private IEnumerator SendMediaJoLimits() {
        var request = new UnityWebRequest("http://18.223.239.177/hello/update/media", "POST");
        string jsonData = JsonUtility.ToJson(media);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) {
            Debug.Log("Error sending data of Media");
        } else {
            //Debug.Log("Media data sent successfully" + request.downloadHandler.text);
        }
    }
}