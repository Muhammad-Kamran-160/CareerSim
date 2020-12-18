//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
//using MongoDB.Driver;
//using MongoDB.Driver.Builders;

[Serializable]
public class QuizModel {

    //public ObjectId _id; // add object id attribute here if necessary....
    public string _id;
    public string name;
    public string description;
    public int threshold;
    public Question[] questions;

    public int myScore;

    public QuizModel() { }
    public QuizModel(string name, string description, int threshold, /*Config config,*/ Question[] questions) {
        this.name = name;
        this.description = description;
        this.threshold = threshold;
       // this.config = config;
        this.questions = questions;
    }
    public QuizModel Fetch(string oid) {



        return (null);
    }

    public void Print() {
        Debug.Log(name);
        Debug.Log(description);
        Debug.Log(threshold);
        foreach(Question question in questions) {
            question.Print();
        }
    }
}
[Serializable]
public class Question {
    public Options[] options;
    public string _id;
    public string name;

    public void Print() {
        Debug.Log(name);
        foreach(Options option in options) {
            option.Print();
        }
    }
}
[Serializable]
public class Options {
    public string _id;
    public string name;
    public bool isAnswer;
    public void Print() {
        Debug.Log(name + " - " + isAnswer);
    }
}