using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.OM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository
{
    public sealed class MessageRepository
    {
        private static readonly Lazy<MessageRepository> lazy =
    new Lazy<MessageRepository>(() => new MessageRepository());

        public static MessageRepository Instance { get { return lazy.Value; } }

        IMongoCollection<MessageOM> col;
        IMongoDatabase db;
        MongoClient cliente;

        private MessageRepository()
        {
            cliente = new MongoClient();
            db = cliente.GetDatabase("Chatbot");
            col = db.GetCollection<MessageOM>("Message");
        }

        public void InsertMessage(MessageOM message)
        {
            col.InsertOne(message);
        }
    }
}