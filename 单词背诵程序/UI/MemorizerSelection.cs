using DAL;

namespace UI;
using BLL;
using static BLL.ListClass;
public partial class MemorizerSelection : Form
{
    public MemorizerSelection()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void button5_Click(object sender, EventArgs e)
    {
        List<Word> wordList = new List<Word>();
        wordList = (SelectionList.GenerateTestList()).ToList();
        SelectionList selectionList = new SelectionList(wordList);
        label1.Text = selectionList.WordList[0][0];
        button1.Text = selectionList.LSelectionList[0];
        button2.Text = selectionList.LSelectionList[1];
        button3.Text = selectionList.LSelectionList[2];
        button4.Text = selectionList.LSelectionList[3];
        throw new System.NotImplementedException();
        
        

    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        
        throw new System.NotImplementedException();
    }
}