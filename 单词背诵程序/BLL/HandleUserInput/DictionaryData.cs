using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLLBridgeDAL;
using DAL;
namespace BLL.HandleUserInput
{
    public static class DictionaryData
    {
        static IDictionarySelect dictionary = new DictionarySelect();

        public static bool DeliverDictionarySelect(string word)
        {
            if(word == null || word == "") { throw new ArgumentException("空的！！！"); }
            return dictionary.SelectDictionary(word);
        }
    }
}
