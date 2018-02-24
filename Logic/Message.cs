using MongoDB.Bson;
using SimpleBot.OM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class Message
    {
        public string Id { get; }
        public string User { get; }
        public string Text { get; }

        public Message(string id, string username, string text)
        {
            this.Id = id;
            this.User = username;
            this.Text = text;

            var message = new MessageOM();
            message.Id = id;
            message.User = username;
            message.Message = text;

            Repository.MessageRepository.Instance.InsertMessage(message);
        }
    }
}