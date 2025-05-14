using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class WordManagement: IWordManagement
    {
        public IWord GetRandomWordForReciter()
        {
            Random rd = new Random();
            return new Word(rd.Next(0,7)) as IWord;
        }

        public void RemoveWordFromeLearningList(string word)
        {
            return;
        }

        public void AddWordToReview(IWord word)
        {
            //未实现
        }
    }
}
