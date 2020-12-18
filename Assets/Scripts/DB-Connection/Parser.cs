using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser {

    public static List<QuizModel> Parse(string data) {

        List<QuizModel> quizzes = new List<QuizModel>();

        //char[] delimeters = new char[7] { '[', '{', '"', ':', ',', '}', ']' };

        ////Debug.Log(data);

        //string[] subSrings = data.Split(delimeters, System.StringSplitOptions.RemoveEmptyEntries);
        //string str1 = "";
        ////for (int i = 0; i < subSrings.Length; i++) {
        ////    str1 += subSrings[i];
        ////}
        ////Debug.Log(str1);

        ////Debug.Log(" "+subSrings);

        //foreach (string str in subSrings) {
        //    str1 += (" , " + str);
        //    Debug.Log(str);
        //}

        //Debug.Log(str1);
        

        //for (int i = 0; i < subSrings.Length; i++) {

        //    QuizModel quiz = new QuizModel();
        //    //i=0   ==> _id
        //    i++;    // _id: value
            
        //    quiz._id = subSrings[i];
        //    Debug.Log("id: " + i + " => " + subSrings[i]);
            
        //    i++;    //name:
        //    i++;    //name:value
            
        //    quiz.name = subSrings[i];
        //    Debug.Log("name: " + i + " => " + subSrings[i]);

        //    i++;    //description
        //    i++;    //description:value
            
        //    quiz.description = subSrings[i];
        //    Debug.Log("description: " + i + " => " + subSrings[i]);

        //    i++;    //threshold
        //    i++;    //threshold:value

        //    quiz.threshold = int.Parse(subSrings[i]);
        //    Debug.Log("threshold " + i + " => " + subSrings[i]);

        //    i++;    //questions
            
        //    quiz.questions = new Question[quiz.threshold];

        //    for (int j = 0; j < quiz.threshold; j++) {
        //        i++;    //options
        //        Question question = new Question();

        //        List<Options> options = new List<Options>();
        //        for (int k = 0; k < 4; k++) {
        //            i++;    //_id
        //            i++;    //_id:value
        //            Options op = new Options();
        //            op._id = subSrings[i];
        //            Debug.Log("option " + k + " => " + subSrings[i]);

        //            i++;    //name
        //            i++;    //name:value
        //            op.name = subSrings[i];
        //            Debug.Log("option " + k + " => " + subSrings[i]);

        //            i++;    //isAnswer
        //            i++;    //isAnswer:value

        //            if(subSrings[i] == "false") {
        //                op.isAnswer = false;
        //                Debug.Log("option " + k + " => " + subSrings[i]);
        //            } else {
        //                op.isAnswer = true;
        //                Debug.Log("option " + k + " => " + subSrings[i]);
        //            }
        //            options.Add(op);
        //            if (k + 1 == 2) {   // if we have only two options then break the loop...
        //                if (subSrings[i + 6] != "false" && subSrings[i + 6] != "true") {
        //                    Debug.Log("inside ................... ");
        //                    break;
        //                }
        //            }
        //        }
        //        question.options = new Options[options.Count];
        //        for (int k = 0; k < options.Count; k++) {
        //            question.options[k] = options[k];
        //        }
        //        i++;
        //        i++;
        //        question._id = subSrings[i];
        //        Debug.Log("question id => " + subSrings[i]);
        //        i++;
        //        i++;
                
        //        question.name = subSrings[i];
        //        Debug.Log("question statement => " + subSrings[i]);

        //        quiz.questions[j] = question;
        //    }
        //    i++;
        //    i++;
        //    quizzes.Add(quiz);
        //}
        return (quizzes);
    }
}
