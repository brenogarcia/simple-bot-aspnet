using SimpleBot.OM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Interface
{
    public interface IMessageRepository
    {
        void InsertMessage(MessageEntity message);
    }
}