using IBLLBridgeDAL.WordOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLLBridgeDAL;
namespace DAL.ReturnFunction
{
    internal class ReviewListManagement: IReviewListManagement
    {
        public IWord GetRandomWordForReview()
        {
            Random random = new Random();
            return new Word(random.Next(0,7)) as IWord;
        }
        public void RemoveWordFromReview(IWord word) 
        {
            //先挂着
        }
    }
}
