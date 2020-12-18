using UnityEngine;
//using MongoDB.Driver;
//using MongoDB.Driver.Builders;
using UnityEngine.Networking;
using System.Collections;
using Newtonsoft.Json;

public class Connection : MonoBehaviour {
    public static Connection instance;
    
    public AppData LocalDB;

    private const string MONGO_URI = "mongodb://ec2-3-133-146-88.us-east-2.compute.amazonaws.com:27017";
    public const string DATABASE_NAME = "hello";

    //private MongoClient client;
    //private MongoServer server;
    //public MongoDatabase db;

    //public MongoCollection<QuizModel> Quiz;
    //public MongoCollection<TokenModel> Token;

    public bool isConnected = false;

    void Start()
    {
        if (instance == null)
            instance = this;

        //client = new MongoClient(MONGO_URI);
        //server = client.GetServer();

        //db = server.GetDatabase(DATABASE_NAME);

        isConnected = true;

        //Quiz = db.GetCollection<QuizModel>("quizzes");
        //Token = db.GetCollection<TokenModel>("gametokens");

        //StartCoroutine(Upload());

    }

    private string quizData = "";

    private void Update() {
        //if (Input.GetKeyDown(KeyCode.C)) {  // pload
        //    StartCoroutine(Upload());
        //}
        if (Input.GetKeyDown(KeyCode.C)) {
            
            StartCoroutine(GetText());
            QuizModel[] q = JsonUtility.FromJson<QuizModel[]>(quizData);
            
            

        }
    }


    IEnumerator GetText() {
        UnityWebRequest www = UnityWebRequest.Get("http://18.223.239.177:4000/hello/allmodules");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            //
            //Debug.Log("Quizzez: ");
            //Debug.Log(www.downloadHandler.text);
            quizData = www.downloadHandler.text;

            string str = "{\"quizzes\":";

            for (int i = 0; i < quizData.Length; i++) {
                str += quizData[i];
            }
            str += "}";

            //Debug.Log(str);

            QuizModel[] q = JsonUtility.FromJson<QuizModel[]>(str);

            if (q == null) {
                Debug.Log("nulled");
            }
            if (JsonUtility.FromJson<QuizModel2>(str) == null) {
                Debug.Log("yes null");
            }
            //Debug.Log(q.Length);

            Parser.Parse(quizData);
        }
    }


    IEnumerator Upload() {
        WWWForm form = new WWWForm();
        //form.AddField("myField", "myData");

        //string a = "{" + "token" + ": " + "123" + "," + "multiIntelligence" + ": [ { " + "name" + ":" + "Word-smart" + ", " + "value" + ": 10 }, { " + "name" + ":" + "Logic-smart" + ", " + "value" + ": 10 }, { " + "name" + ":" + "Self-smart" + ", " + "value" + ": 10 },{ " + "name" + ":" + "People-smart" + ", " + "value" + ": 10 },{ " + "name" + ":" + "Music-smart" + ", " + "value" + ": 5 },{ " + "name" + ":" + "Body-smart" + ", " + "value" + ": 3 },{ " + "name" + ":" + "Picture-smart" + ", " + "value" + ": 1 },{ " + "name" + ":" + "Nature-smart" + ", " + "value" + ": 1 }]," + "performanceCharacter" + ": " + "Curiosity" + "," + "careerAnchors" + ":[ " + "Technical/funcional competence" + ", " + "Lifestyle" + "]," + "values" + ":[ " + "Spirtuality" + ", " + "Teaching, mentoring" + ", " + "Faith" + ", " + "Fame, success" + ", " + "Independence" + "]}";
        string a = "{" + "token" + ": " + LocalDB.CurrentPlayer.token + 
            "," + "multiIntelligence" + ": [ { " + 
                "name" + ":" + "Word-smart" + ", " + LocalDB.CurrentPlayer.MultipleIntelligence[0].cost + ": 10 }, " +
                "{ " + "name" + ":" + "Logic-smart" + ", " + LocalDB.CurrentPlayer.MultipleIntelligence[1].cost + ": 10 }, " +
                "{ " + "name" + ":" + "Self-smart" + ", " + LocalDB.CurrentPlayer.MultipleIntelligence[2].cost + ": 10 }, " +
                "{ " + "name" + ":" + "People-smart" + ", " + LocalDB.CurrentPlayer.MultipleIntelligence[3].cost + ": 10 }, " +
                "{ " + "name" + ":" + "Music-smart" + ", " + LocalDB.CurrentPlayer.MultipleIntelligence[4].cost + ": 5 }, " +
                "{ " + "name" + ":" + "Body-smart" + ", " + LocalDB.CurrentPlayer.MultipleIntelligence[5].cost + ": 3 }, " +
                "{ " + "name" + ":" + "Picture-smart" + ", " + LocalDB.CurrentPlayer.MultipleIntelligence[6].cost + ": 1 }, " +
                "{ " + "name" + ":" + "Nature-smart" + ", " + LocalDB.CurrentPlayer.MultipleIntelligence[7].cost + ": 1 }]," + 
                
                "performanceCharacter" + ": " + LocalDB.CurrentPlayer.PerformanceCharacter[0].Title + "," + 
                
                "careerAnchors" + ":[ " + LocalDB.CurrentPlayer.CareerAnchor[0] + ", " + LocalDB.CurrentPlayer.CareerAnchor[1] + "], " + 
                "values" + ":[ " + LocalDB.CurrentPlayer.Values[0] + ", " + LocalDB.CurrentPlayer.Values[1] + ", " + LocalDB.CurrentPlayer.Values[2] + ", " + LocalDB.CurrentPlayer.Values[3] + ", " + LocalDB.CurrentPlayer.Values[4] + "]}";
        
        print(a);

        //form.AddField("token", "123");
        //form.AddField("multiIntelligence",  );

        UnityWebRequest www = UnityWebRequest.Post("http://ec2-3-133-146-88.us-east-2.compute.amazonaws.com:4000/hello/addplayer", a);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        } else {
            Debug.Log("Form upload complete!");
        }
    }

}
