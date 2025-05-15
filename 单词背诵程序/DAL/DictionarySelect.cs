using IBLLBridgeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DictionarySelect:IDictionarySelect
    {
        public static Formid userDictionarySelect = Formid.CET4;
        public bool SelectDictionary(string word)
        {
           return Enum.TryParse(word, out userDictionarySelect);
        }
    }
}
