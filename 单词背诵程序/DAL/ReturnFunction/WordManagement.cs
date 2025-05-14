using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    /// <summary>
    /// 实现IWordManagement接口<br/>
    /// 本类用于管理单词
    /// </summary>
    public class WordManagement: IWordManagement
    {
        /// <summary>
        /// 获取随机单词的IWord实例
        /// </summary>
        /// <returns></returns>
        public IWord GetRandomWordForReciter()
        {
            Random rd = new Random();
            return new Word(rd.Next(1,6)) as IWord;
        }
        /// <summary>
        /// 移除学习列表中的单词（事实上不需要）
        /// </summary>
        /// <param name="word"></param>
        public void RemoveWordFromeLearningList(string word)
        {
            return;
        }
        /// <summary>
        /// 把单词添加到复习列表中<br/>
        /// </summary>
        /// <param name="word"></param>
        public void AddWordToReview(IWord word)
        {
            //未实现
        }
    }
}
