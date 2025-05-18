using IBLLBridgeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    using DAL;
    using IBLLBridgeDAL;
    using IBLLBridgeDAL.WordOperation;


    public class SearchWordEnglish
    {
        /// <summary>
        /// 查询指定表，先精确查找，找不到再模糊查找
        /// </summary>
        public List<string> FuzzySearch(string input, Formid formid)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<string>();

            var exact = WordMover.FindExactWord(input, formid);
            if (!string.IsNullOrEmpty(exact))
                return new List<string> { exact };

            return WordMover.FindFuzzyWords(input, formid);
        }
    }

    }
