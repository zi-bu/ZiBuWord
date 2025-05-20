using IBLLBridgeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using DAL;
    using IBLLBridgeDAL;
    using IBLLBridgeDAL.WordOperation;
namespace BLL
{


    public class SearchWordEnglish
    {
        /// <summary>
        /// 查询指定表，先精确查找，找不到再模糊查找
        /// </summary>
        /// <summary>
        /// 在所有表中查找，优先精确匹配，否则合并所有表的模糊匹配
        /// </summary>
        public List<string> FuzzySearch(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<string>();

            // 先遍历所有表做精确查找
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var exact = WordMover.FindExactWord(input, formid);
                if (!string.IsNullOrEmpty(exact))
                    return new List<string> { exact };
            }

            // 没有精确匹配，合并所有表的模糊查找结果
            var result = new List<string>();
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var fuzzy = WordMover.FindFuzzyWords(input, formid);
                result.AddRange(fuzzy);
            }

            // 去重
            return result.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }
    }
    }
