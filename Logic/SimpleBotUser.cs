using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        public static string Reply(Message message)
        {
            var visitNumber = Repository.PerfilMongoRepository.Instance.InsertVisit(message.Id);
            return $"{message.User} enviou {visitNumber} mensagens!";
        }
    }
}