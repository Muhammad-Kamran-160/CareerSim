using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser2 : MonoBehaviour {

    //void Update() {
    //    if (Input.GetKeyDown(KeyCode.I)) {
    //        data = con.Data;
    //        List<QuizModel> Q = ParseData();
    //        //foreach(QuizModel q in Q)
    //        //{
    //        //    q.Print();
    //        //}
    //    }
    //}
    public static List<QuizModel> ParseData(string data) {

        List<QuizModel> quizzes = new List<QuizModel>();

        char[] delimeters = new char[6] { '[', '{', '"', ',', '}', ']' };
        string[] subSrings = data.Split(delimeters, System.StringSplitOptions.RemoveEmptyEntries);
        foreach(string str in subSrings) {
            Debug.Log(str);
        }
        Debug.Log("------------------------------------------------------------\n\n");
        for (int i = -1; i < subSrings.Length; i++) {
            QuizModel quiz = new QuizModel();
            i++;    // id
            i++;    // :
            i++;    // value
            if (i >= subSrings.Length) break;
            quiz._id = subSrings[i];
            Debug.Log("quiz ID: " + subSrings[i]);

            i++;    // name
            i++;    // :
            i++;    // value
            quiz.name = subSrings[i];
            Debug.Log("quiz statement: " + subSrings[i]);

            i++;    // description
            i++;    // :
            i++;    // value
            quiz.description = subSrings[i];
            Debug.Log("quiz description: " + subSrings[i]);

            i++;    // threshold
            i++;    // :value
            quiz.threshold = int.Parse(subSrings[i].Split(':')[1]); // value
            Debug.Log("quiz threshold: " + int.Parse(subSrings[i].Split(':')[1]));

            i++;    // question
            i++;    // :

            quiz.questions = new Question[quiz.threshold];

            i++;    // options
            i++;    // :

            for (int j = 0; j < quiz.questions.Length; j++) {
                Question question = new Question();
                List<Options> options = new List<Options>();
                for (int k = 0; k < 4; k++) {
                    Options option = new Options();
                    i++;    // _id
                    i++;    // :
                    i++;    // value
                    option._id = subSrings[i];
                    Debug.Log("id option " + j + ":" + subSrings[i]);

                    i++;    // name
                    i++;    // :
                    i++;    // value
                    option.name = subSrings[i];
                    Debug.Log("value option " + j + ":" + subSrings[i]);

                    i++;    // isAnswer
                    i++;    // : or some text
                    if (subSrings[i].Length == 1) {
                        i++;    // it was only colon now get value
                        option.name = subSrings[i];
                    } else {
                        string s = subSrings[i].Split(':')[1];
                        if (s == "false") {
                            option.isAnswer = false;
                            Debug.Log("isAnswer option " + j + ":" + (subSrings[i].Split(':')[1]));
                        } else if (s == "true") {
                            option.isAnswer = true;
                            Debug.Log("isAnswer option " + j + ":" + (subSrings[i].Split(':')[1]));
                        }
                    }
                    if (k + 1 == 2) {   // if we have only two options then break the loop...
                        if (subSrings[i + 8].Split(':').Length > 1) {
                            if (subSrings[i + 8].Split(':')[1] != "false" && subSrings[i + 8].Split(':')[1] != "true") {
                                Debug.Log("inside ................... ");
                                break;
                            }
                        }
                    }
                    options.Add(option);
                }
                question.options = new Options[options.Count];
                for (int k = 0; k < options.Count; k++) {
                    question.options[k] = options[k];
                }
                i++;    // _id
                i++;    // :
                i++;    // value
                question._id = subSrings[i];
                Debug.Log("Question id: " + subSrings[i]);

                i++;    // name
                i++;    // :
                i++;    // value
                question.name = subSrings[i];
                Debug.Log("Question statement: " + subSrings[i]);
                quiz.questions[j] = question;
                if(j != quiz.questions.Length - 1)
                {
                    i++;
                    i++;
                }
                else
                {
                    i++;
                }
            }
            quizzes.Add(quiz);
        }
        return quizzes;
    }
}
