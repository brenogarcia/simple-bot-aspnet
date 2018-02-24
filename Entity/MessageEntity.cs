using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.OM
{
    [BsonIgnoreExtraElements]
    public class MessageEntity
    {
        public BsonDocument GetDocument() {
            return new BsonDocument()
            {
                { "IdUser", IdUser },
                { "UserName" , UserName },
                { "Message", Message }
            };}

        public string IdUser { get; set; }
        public string UserName { get; set; }

        public string Message { get; set; }
    }
}