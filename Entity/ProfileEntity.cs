using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.OM
{
    [BsonIgnoreExtraElements]
    public class ProfileEntity
    {
        public BsonDocument GetVisit()
        {
            return new BsonDocument()
            {
                { "IdUser", IdProfile },
                { "User" , VisitNumber }
            };
        }

        public string IdProfile { get; set; }

        public long VisitNumber { get; set; }
    }
}