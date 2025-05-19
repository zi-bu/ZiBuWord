using IBLLBridgeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
        public class UserDataNow : IDictionarySelect
        {

                public static Formid userDictionarySelect = Formid.CET4;


                internal static string NowUser;

                public bool SelectDictionary(string word)
                {
                        return Enum.TryParse(word, out userDictionarySelect);
                }
        }
}
