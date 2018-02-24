using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot.Interface
{
    public interface IProfileRepository
    {
        long InsertVisit(string idProfile);
    }
}
