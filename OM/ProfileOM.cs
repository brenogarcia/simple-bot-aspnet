using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.OM
{
    public class ProfileOM
    {
        public BsonDocument GetVisit()
        {
            return new BsonDocument()
            {
                { "IdUser", Id },
                { "User" , VisitNumber }
            };
        }

        public string Id { get; set; }

        public long VisitNumber { get; set; }
    }
}