using IBLLBridgeDAL.WordOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLLBridgeDAL;
namespace DAL.ReturnFunction
{
    /// <summary>
    /// 实现IReviewListManagement接口<br/>
    /// 本类用于管理复习单词<br/>
    /// </summary>
    internal class ReviewListManagement: IReviewListManagement
    {
        /// <summary>
        /// 获取随机单词进行复习<br/>
        /// </summary>
        /// <returns></returns>
        public IWord GetRandomWordForReview()
        {
            Random random = new Random();
            return new Word(random.Next(0,7)) as IWord;
        }
        /// <summary>
        /// 添加单词到复习列表<br/>
        /// </summary>
        /// <param name="word"></param>
        public void RemoveWordFromReview(IWord word) 
        {
            //先挂着
        }
    }
}
