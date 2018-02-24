using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Interface;
using SimpleBot.OM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository
{
    public sealed class MessageMongoRepository : IMessageRepository
    {
        private static readonly Lazy<MessageMongoRepository> lazy =
    new Lazy<MessageMongoRepository>(() => new MessageMongoRepository());

        public static MessageMongoRepository Instance { get { return lazy.Value; } }

        IMongoCollection<MessageEntity> col;
        IMongoDatabase db;
        MongoClient cliente;

        private MessageMongoRepository()
        {
            cliente = new MongoClient();
            db = cliente.GetDatabase("Chatbot");
            col = db.GetCollection<MessageEntity>("Message");
        }

        public void InsertMessage(MessageEntity message)
        {
            col.InsertOne(message);
        }
    }
}