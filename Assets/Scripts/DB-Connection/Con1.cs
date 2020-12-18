using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Con1 : MonoBehaviour {

    public string Data = "";

    void Start()
    {
        StartCoroutine(GetQuizzes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GetQuizzes()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177/hello/allmodules");
        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError) {
            Debug.LogError(www.error);
        } else {
            Data = www.downloadHandler.text;
           string str = "{\"Q\":[" + Data + "]}";
           Debug.Log(str);
            QuizModel[] q = JsonHelper.getJsonArray<QuizModel>(Data);
           //Quiz q = JsonUtility.FromJson<Quiz>(str);
           Debug.Log("Data received." + q.Length);
           foreach (QuizModel quiz in q) {
               Debug.Log(quiz.name);
           }

        }
    }

}
