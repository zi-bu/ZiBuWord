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

var reviewer = new ReviewClass(ReviewOrder.WordList[ReviewOrder.Index]);
var app = builder.Build();
app.UseCors("AllowAll");
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


app.Run();