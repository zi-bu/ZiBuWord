using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLLBridgeDAL
{
    public interface IUserInputDeliver
    {
         void SelectDictionary(string word);
         void RememberUser(string? user);
    }
}
