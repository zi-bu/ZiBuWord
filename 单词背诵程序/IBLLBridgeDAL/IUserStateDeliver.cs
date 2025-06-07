using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLLBridgeDAL
{
    public interface IUserStateDeliver
    {
        void SelectDictionary(string word);
         void RememberUser(string? user);
         void ProgressSync();
         void UpdateProgress(int upprogress);

        int GetReviewListCount(); //获取需要复习的单词数量
        public string GetCurrentDictType();
        public string? GetNowUser();
     }
}
