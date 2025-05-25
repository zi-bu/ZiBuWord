using BLL;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddScoped<IBLLBridgeDAL.IWordQuery, DAL.WordQueryDAL>();
var app = builder.Build();
app.UseCors("AllowAll");
var reviewer = new ReviewClass(ReviewOrder.WordList[ReviewOrder.Index]);
//显示用单词内容的提供
app.MapGet("/api/ReviewWord/wordListCount",
    () =>
    {
        var wordListCount = ReviewOrder.WordList.Count;
        var result =
            new
            {
                wordListCount
            };
        return Results.Ok(result);
    });
//按钮事件的提供
app.MapGet("/api/ReviewWord",
    () =>
    {
        var wordOfReview = reviewer.Word.word;
        var infoOfReview = reviewer.OutPutWordInfo();
        var result =
            new
            {
                wordOfReview,
                infoOfReview
            };
        return Results.Ok(result);
    });
app.MapPost("/api/ReviewWord/EventYes",//选择认识时发生的事件
    () =>
    {
        reviewer.RemoveWordReviewList();
        ReviewOrder.ResetIndex(); //对于选择认识时的下标回拨检验
        Console.WriteLine("选择是");
        ReviewOrder.CheckOutWordList();
        reviewer = new ReviewClass(ReviewOrder.WordList[ReviewOrder.Index]);
        return Results.Ok("操作成功,按钮Yes逻辑被执行");
    });
app.MapPost("/api/ReviewWord/EventNo",//选择不认识时发生的事件
    () =>
    {
        ReviewOrder.ResetIndex(); //下标回拨检验，如果不认识则提前返回
        ReviewOrder.CheckOutWordList();
        reviewer = new ReviewClass(ReviewOrder.WordList[ReviewOrder.Index]);
        return Results.Ok("操作成功,按钮No逻辑被执行");
    });

//实例化背诵选项

//提供显示内容的api
app.MapGet("/api/RiciterWord/selection",
    () =>
    {
        bool finished = RiciterOrder.WordList.Count == 0;
        if (finished)
        {
            var result = new
            {
                finished = true
            };
            return Results.Ok(result);
        }
        else
        {
            var selectionClass = new SelectionClass(RiciterOrder.WordList[RiciterOrder.Index]);
            var accurateWord = selectionClass.AccurateWord.word;
            var selection = selectionClass.Selection;
            var result = new
            {
                accurateWord,
                selection,
                finished = false
            };
            Console.WriteLine(accurateWord + "的信息已经成功送达至前端");
            return Results.Ok(result);
        }
    }
);

//提供按钮的事件
app.MapPost("/api/RiciterWord/Event",
    ([FromBody] AnswerRequest request) =>
    {
        Console.WriteLine($"接收到结果: {request.Result}");
        if (request.Result)
        {
            RiciterOrder.RemoveWordFromRiciterList();
            if (RiciterOrder.CheckEmpty())
            {
                // 不要立刻生成新列表！
                RiciterOrder.Index = 0;
            }
            else if (RiciterOrder.Index >= RiciterOrder.WordList.Count)
            {
                RiciterOrder.Index = 0;
            }
            return Results.Ok("操作成功,按钮Yes逻辑被执行");
        }
        else
        {
            RiciterOrder.Index++;
            Console.WriteLine("现在的索引是" + RiciterOrder.Index);
            if (RiciterOrder.Index >= RiciterOrder.WordList.Count)
            {
                RiciterOrder.Index = 0;
            }
            return Results.Ok("操作成功,按钮No逻辑被执行");
        }
    }
);
app.MapPost("/api/RiciterWord/NewList", () =>
{
    RiciterOrder.CreateOrRefreshNewWordList();
    RiciterOrder.Index = 0;
    return Results.Ok("新队列已生成");
});

//提供搜索查询的方法
app.MapGet("/api/search", ([FromQuery] string kw, IBLLBridgeDAL.IWordQuery wordQuery) =>
{
    var searcher = new SearchWordEnglish(wordQuery);
    var result = searcher.FuzzySearch(kw);
    return Results.Ok(result);
});


app.Run();

public class AnswerRequest(bool result)
{
    public bool Result { get;} = result;
}

