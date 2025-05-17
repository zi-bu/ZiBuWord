using IBLLBridgeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDataNow:IDictionarySelect
    {
        internal static Formid userDictionarySelect;

        internal static string NowUser;
        public bool SelectDictionary(string word)
        {
           return Enum.TryParse(word, out userDictionarySelect);
        }
    }
}
