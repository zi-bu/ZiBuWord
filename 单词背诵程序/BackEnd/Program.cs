using BLL;

var builder = WebApplication.CreateBuilder(args);

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
var app = builder.Build();
app.UseCors("AllowAll");
/// <summary>
/// 复习列表的交互
/// </summary>
/// <returns></returns>
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
var Selection = new SelectionClass(RiciterOrder.WordList[RiciterOrder.Index]);
//提供显示内容的api
app.MapGet("/api/RiciterWord/selection",
    () =>
    {
        var accurateWord = Selection.AccurateWord.word; //正确的单词
        var selection = Selection.Selection.Select(word => word.pos[0] + word.translations[0]).ToList(); //选项
        var result =
            new
            {
                accurateWord,
                selection
            };
        Console.WriteLine(accurateWord + "的信息已经成功送达至前端");
        return Results.Ok(result);
    }
);
//提供按钮的事件
app.MapPost("/api/RiciterWord/EventYes",//选择认识时发生的事件
    () =>
    {

        RiciterOrder.RemoveWordFromRiciterList(); //从单词列表中删除单词
        RiciterOrder.CheckBoundary(); //下标回拨检验
        if (RiciterOrder.CheckEmpty()) //检查是否为空
        {
            RiciterOrder.CreateOrRefreshNewWordList(); //创建新的单词列表
        }
        RiciterOrder.Index++; //下标前进
        return Results.Ok("操作成功,按钮Yes逻辑被执行");
    }
);
app.MapPost("/api/RiciterWord/EventNo",//选择认识时发生的事件
    () =>
    {
        RiciterOrder.CheckBoundary(); //下标回拨检验
        RiciterOrder.Index++; //下标前进
        return Results.Ok("操作成功,按钮No逻辑被执行");
    }
);

/// <summary>
/// 保持后端持续开放
/// </summary>
app.Run();