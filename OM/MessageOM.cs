using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.OM
{
    public class MessageOM
    {
        public BsonDocument GetDocument() {
            return new BsonDocument()
            {
                { "IdUser", Id },
                { "User" , User },
                { "Mensagem", Message }
            };}

        public string Id { get; set; }
        public string User { get; set; }

        public string Message { get; set; }
    }
}