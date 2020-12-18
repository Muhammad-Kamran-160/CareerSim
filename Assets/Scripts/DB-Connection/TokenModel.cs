//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
using UnityEngine;
//using MongoDB.Driver.Builders;
//using MongoDB.Driver;

public class TokenModel {
    
    //public ObjectId _id;  // add object id here if necessary...
    
    public string token { get; set; }
    public int __v { get; set; }
    public TokenModel Fetch(string oid) {
        //var query = new QueryDocument("_id", ObjectId.Parse(oid));
        //TokenModel token = Connection.instance.Token.FindOne(query);
        return (null);  // return fetced toke here
    }
    public void Print() {
        Debug.Log(token + " - " + __v);
    }
}
