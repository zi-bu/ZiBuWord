# 单词背诵程序DAL层设计与实现

## DAL层设计与实现概述

本项目的数据访问层（DAL）主要负责与数据库的交互，包括单词、用户、收藏等数据的增删查改。设计过程中采用了分层架构、面向对象思想和Entity Framework Core（EFCore）等，力求提升代码的可维护性和扩展性。实现过程中尝试了泛型、接口、EFCore关系映射等新知识，积累了实际开发经验。

## 技术选型与设计思路

- **分层架构**：将数据访问、业务逻辑、界面分离，DAL层专注于数据库操作，降低各层耦合。
- **面向对象设计**：
  - 封装：数据库操作细节隐藏在类和方法内部，外部只需调用接口。
  - 继承与多态：抽象基类和接口减少重复代码，便于扩展不同词库和功能。
- **EFCore**：
  - 支持LINQ查询，代码更直观易懂。
  - 支持复杂关系映射（如一对多、多对多），便于维护数据结构。
  - 自动迁移和数据库同步，方便团队协作和版本管理。

## 关键类与代码示例



### Dictionary.cs —— 单词实体与继承体系
```csharp

public abstract class WordForm<T, P>
{
    public int Id { get; set; } // 单词编号
    public string Word { get; set; } = null!; // 单词
    public required List<T> Translations { get; set; } // 释义列表
    public List<P>? Phrases { get; set; } // 短语列表
}

public abstract class TranslationForm<M>
{
    public int Id { get; set; }
    public string Translation { get; set; } = null!;
    public string TyPe { get; set; } = null!;
    public int WordId { get; set; }
    public required M WordForm { get; set; }
}

public abstract class PhraseForm<M>
{
    public int Id { get; set; }
    public string Phrase { get; set; } = null!;
    public string Translation { get; set; } = null!;
    public int WordId { get; set; }
    public required M WordForm { get; set; }
}

public class CET4 : WordForm<CET4T, CET4P> { }
public class CET4T : TranslationForm<CET4> { }
public class CET4P : PhraseForm<CET4> { }
public class CET6 : WordForm<CET6T, CET6P> { }
public class CET6T : TranslationForm<CET6> { }
public class CET6P : PhraseForm<CET6> { }
public class HighSchool : WordForm<HighSchoolT, HighSchoolP> { }
public class HighSchoolT : TranslationForm<HighSchool> { }
public class HighSchoolP : PhraseForm<HighSchool> { }
public class MiddleSchool : WordForm<MiddleSchoolT, MiddleSchoolP> { }
public class MiddleSchoolT : TranslationForm<MiddleSchool> { }
public class MiddleSchoolP : PhraseForm<MiddleSchool> { }
public class KY : WordForm<KYT, KYP> { }
// ... 其他词库同理
```
- **说明**：
  - 以`WordForm<T, P>`为抽象基类，派生出CET4、CET6等不同词库实体，体现继承和泛型多态。
  - 释义和短语也用泛型和继承实现，支持一对多关系。
  - 结构清晰，便于扩展和维护。

### SqlDataContext.cs —— 数据库上下文
```csharp
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class SqlDataContext : DbContext
{
    public DbSet<CET4> CET4 { get; set; } // 对应数据库中的 CET4 表。
    public DbSet<CET6> CET6 { get; set; } // 对应数据库中的 CET6 表。
    public DbSet<MiddleSchool> MiddleSchool { get; set; } // 对应数据库中的 初中 表。
    public DbSet<HighSchool> HighSchool { get; set; } // 对应数据库中的 高中 表。
    public DbSet<KY> KY { get; set; } // 对应数据库中的 四级 表。
    public DbSet<TF> TF { get; set; } // 对应数据库中的 托福 表。
    public DbSet<SAT> SAT { get; set; } // 对应数据库中的 SAT 表。

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=26.184.142.179,1433;Database=Randomword;User Id=User1;Password=A@114514;Encrypt=False;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        FastCreateModel<CET4, CET4T, CET4P>(modelBuilder, "CET4");
        FastCreateModel<CET6, CET6T, CET6P>(modelBuilder, "CET6");
        FastCreateModel<MiddleSchool, MiddleSchoolT, MiddleSchoolP>(modelBuilder, "MiddleSchool");
        FastCreateModel<HighSchool, HighSchoolT, HighSchoolP>(modelBuilder, "HighSchool");
        FastCreateModel<KY, KYT, KYP>(modelBuilder, "KY");
        FastCreateModel<TF, TFT, TFP>(modelBuilder, "TF");
        FastCreateModel<SAT, SATT, SATP>(modelBuilder, "SAT");
    }

    private static void FastCreateModel<MainF, TlForm, PForm>(ModelBuilder modelBuilder, string FormName)
        where MainF : WordForm<TlForm, PForm>
        where TlForm : TranslationForm<MainF>
        where PForm : PhraseForm<MainF>
    {
        modelBuilder.Entity<MainF>(c =>
        {
            c.ToTable($"{FormName}Words");
            c.HasKey(f => f.Id);
        });
        modelBuilder.Entity<TlForm>(c =>
        {
            c.ToTable($"{FormName}Translations");
            c.HasKey(f => f.Id);
            c.HasOne(f => f.WordForm)
                .WithMany(f => f.Translations)
                .HasForeignKey(f => f.WordId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<PForm>(c =>
        {
            c.ToTable($"{FormName}Phrases");
            c.HasKey(f => f.Id);
            c.HasOne(f => f.WordForm)
                .WithMany(f => f.Phrases)
                .HasForeignKey(f => f.WordId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
```
- **说明**：
  - 该类负责数据库连接和实体映射。
  - 通过`DbSet<T>`声明多个词库表用于代码操作。
  - `OnModelCreating`方法结合泛型和约束，批量配置不同词库的实体映射，减少重复代码，方便扩张单词表。
  - 采用EFCore的泛型和映射机制，使DAL层结构更清晰。
  
### Word.cs —— 单词对象的封装
```csharp
using IBLLBridgeDAL;

namespace DAL;

public class Word : IWord
{
    private List<string>? Phrases = new();
    private List<string>? PhraseTranslations = new();
    private List<string> Pos = new();
    private readonly Formid tableid; // 单词来源的枚举编号。
    private readonly List<string> Translations = new();

    public string word { get; }
    public List<string> pos { get => Pos; private set => Pos = value; }
    public List<string> translations { get => Translations; private set => translations = Translations; }
    public List<string>? phrases { get => Phrases; private set => Phrases = value; }
    public List<string>? phraseTranslations { get => PhraseTranslations; private set => PhraseTranslations = value; }

    public Word(int id)
    {
        tableid = (Formid)id;
        word = WordMover.GetWord(tableid);
        WordMover.FindTranslations(word, tableid, ref Translations, ref Pos);
        WordMover.FindPhrases(word, tableid, ref Phrases, ref PhraseTranslations);
    }
    public Word(Formid id)
    {
        tableid = id;
        word = WordMover.GetWord(tableid);
        WordMover.FindTranslations(word, tableid, ref Translations, ref Pos);
        WordMover.FindPhrases(word, tableid, ref Phrases, ref PhraseTranslations);
    }
    public Word(string word, Formid formid)
    {
        this.word = word;
        tableid = formid;
        WordMover.FindTranslations(word, formid, ref Translations, ref Pos);
        WordMover.FindPhrases(word, formid, ref Phrases, ref PhraseTranslations);
    }
    public Word(int wordid, Formid formid)
    {
        tableid = formid;
        word = WordMover.GetWord(formid,wordid);
        WordMover.FindTranslations(word, formid, ref Translations, ref Pos);
        WordMover.FindPhrases(word, formid, ref Phrases, ref PhraseTranslations);
    }
}
```
- **说明**：
  - 实现了`IWord`接口，封装了单词的详细信息。
  - 提供多种构造函数，支持不同场景（如随机、精确、ID查找）。
  - 通过调用`WordMover`静态类实现数据查询，职责单一，便于维护。

### UserDataNow.cs —— 临时存储与同步机制

```csharp
using IBLLBridgeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    /// <summary>
    /// 暂存用户的状态信息。
    /// </summary>
    public class UserDataNow:IUserStateDeliver

    {
        internal static Formid userDictionarySelect = Formid.CET4;

        internal static string? NowUser;

        internal static int Progress = 0;//索引

        /// <summary>
        /// 使程序单词进度与对应用户的数据库里的进度同步<br/>
        /// 传递到DAL层更新指示<br/>
        /// 使用地点：选择表时触发一下；中断背诵触发。
        /// </summary>
        public void ProgressSync()
        {
            if (NowUser == null) return;
            Progress = UserDataMover.GetFormProgress(NowUser, userDictionarySelect);
        }
        //以下方法逻辑大同小异，不再赘述。
        public void SelectDictionary(string word){}//让程序定位到用户指定的词典
        public void RememberUser(string? user){}//让程序记住现在是哪个用户
        public void UpdateProgress(int upprogress){}//更新用户的进度

    }
}
```

- **说明**：
  - UserDataNow 作为“临时存储与同步”机制，负责在 DAL 与业务层之间桥接用户当前状态（如当前词库、用户名、背诵进度等）。
  - 通过静态字段和同步方法，保证用户状态在多处调用时的一致性。
  - 典型场景如切换词库、登录/退出、进度同步等，均通过本类实现跨层数据传递。

### Wordmover.cs & UserDataMover.cs —— 单词与用户数据操作的封装

`WordMover` 和 `UserDataMover` 都是静态工具类，分别负责单词相关的数据查询与操作、用户进度等数据的查询与更新。
- `WordMover` 主要用于：
  - 随机获取单词、根据id或字符串查找单词。
  - 查找单词的释义、短语。
  - 管理用户的复习单词（如添加、更新、获取复习单词等）。
  - 缺点是switch操作判断词库，不够灵活，也不便于扩展(原计划学习用反射来解决)。
  - 典型方法如：
```csharp
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL;

/// <summary>
///     枚举类型，用于表示单词表的编号。
///     例如：CET4 表示四级单词表，CET6 表示六级单词表。
/// </summary>
public enum Formid
{
    CET4 = 1,
    CET6 = 2,
    MiddleSchool = 3,
    HighSchool = 4,
    KY = 5,
    TF = 6
}

/// <summary>
/// 单词搬运工类，封装查询单词和获取单词的方法。
/// </summary>
public static class WordMover
{
    private static readonly Random rd = new(); // 随机数生成器实例。


    public static string GetWord(Formid formid, int id) //获得精确id的单词
    {
        using (var db = new SqlDataContext())
        {
            switch (formid)
            {
                case Formid.CET4:
                    return db.CET4.FirstOrDefault(w => w.Id == id)?.Word ?? string.Empty;
                case Formid.CET6:
                    return db.CET6.FirstOrDefault(w => w.Id == id)?.Word ?? string.Empty;
                case Formid.MiddleSchool:
                    return db.MiddleSchool.FirstOrDefault(w => w.Id == id)?.Word ?? string.Empty;
                case Formid.HighSchool:
                    return db.HighSchool.FirstOrDefault(w => w.Id == id)?.Word ?? string.Empty;
                case Formid.KY:
                    return db.KY.FirstOrDefault(w => w.Id == id)?.Word ?? string.Empty;
                case Formid.TF:
                    return db.TF.FirstOrDefault(w => w.Id == id)?.Word ?? string.Empty;
                default:
                    throw new ArgumentException("未知单词来源表");
            }
        }
    }

  
    public static void FindTranslations(string word, Formid formid, ref List<string> translations, ref List<string> pos)//查找单词释义
    {
        using (var db = new SqlDataContext())
        {
            switch (formid)
            {
                case Formid.CET4:
                    {
                        var TureForm = db.CET4.Include(f => f.Translations).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else
                        {
                            translations = TureForm.Translations.Select(t => t.Translation).ToList();
                            pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                        }
                        break;
                    }
                // ... 其他case同理 ...
                default:
                    throw new ArgumentException("未知单词来源表");
            }
        }
    }


 
    public static void FindPhrases(string word, Formid formid, ref List<string>? phrases, ref List<string>? phraseTranslations)//查找单词短语。
    {
        using (var db = new SqlDataContext())
        {
            switch (formid)
            {
                case Formid.CET4:
                    {
                        var TureForm = db.CET4.Include(f => f.Phrases).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else if (TureForm?.Phrases == null)
                        {
                        } //数据库表存在没有短语的情况。
                        else
                        {
                            phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                            phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                        }
                        break;
                    }
                // ... 其他case同理 ...
                default:
                    throw new ArgumentException("未知单词来源表");
            }
        }
    }

    static int Reviewcount = 0;
    /// <summary>
    /// 获取指定日期的复习单词的ID和来源表
    /// </summary>
    /// <param name="user"></param>
    /// <param name="Form"></param>
    /// <param name="wordid"></param>
    public static void GetReviewWord(string user,DateTime time, ref string Form,ref int wordid)
    {
        using (var db = new UserContext())
        {
            var User = db.UserData.Include(u => u.UserReview).FirstOrDefault(u => u.UserName == user);//获取用户
            if (User!.UserReview == null||User.UserReview.Count() == 0) { throw new ArgumentException("已复习完当日所有单词"); }
            var ReviewWord = User.UserReview.Where(f => f.DueDate.Date <= time.Date);
            if (Reviewcount >= ReviewWord.Count() - 1) { Reviewcount = 0; }
            var word = ReviewWord.ElementAt(Reviewcount++);
            Form = word.Form;
            wordid = word.WordID;
        }
    }
    // 其他方法仅列出签名及注释，具体实现见源码：
    public static string GetWord(Formid formid){} //随机获取一个单词
    public static object? GetWord(string word, Formid formid){} // 根据单词字符串和词库类型返回单词对象。
    public static void UpdateReviewWord(int userId, string word){} // 更新用户复习单词的状态。
    public static void AddReviewWord(int userId, string word, int wordId, Formid formid){} // 将单词添加到用户的复习列表。
    public static int GetWordId(string word, Formid formid){} // 获取单词在词库中的id。
    //...更多方法省略...
}
```

### UserDataMover.cs —— 用户数据操作工具类



```csharp



    public static class UserDataMover// 封装了对用户数据的获取方法和更新方法
    {

        public static int GetFormProgress(string user,Formid id)// 获取某用户对应某表的背诵进度
        {
            using (var db = new UserContext())
            {
                var userData = db.UserData.Include(f => f.UserWord)
                               .Where(f => f.UserName == user)
                               .Select(f => EF.Property<int>(f.UserWord!, id.ToString()))
                               .First();
                return userData;
            }
        }

        public static void UpdateFormProgress(string user, Formid id, int upprogress)// 更新某用户对应某表的背诵进度
        {
            using (var db = new UserContext())
            {
                var userData = db.UserData.Include(f => f.UserWord)
                               .Where(f => f.UserName == user)
                               .Select(f => f.UserWord)
                               .First();
                if (userData == null) { throw new ArgumentException("用户不存在"); }
                switch (id)
                {
                    case Formid.CET4:
                        userData.CET4 += upprogress;
                        break;
                    // ... 其他case同理 ...
                }
                db.SaveChanges();
            }
        }

        public static int GetUserId(string user)// 获取某用户的ID
        {
            using (var db = new UserContext())
            {
                var userId = db.UserData.First(f => f.UserName == user).UserID;
                return userId;
            }
        }

    }

```

  
### ReviewListManagement.cs & WordManagement.cs —— 上层获取复习与背诵单词
```csharp


public class ReviewListManagement : IReviewListManagement
{
    public IWord GetRandomWordForReview()
    {
        if (UserDataNow.NowUser == null) { return new Word(UserDataNow.userDictionarySelect); }
        int userId = 0;
        string Form = null!;
        WordMover.GetReviewWord(UserDataNow.NowUser, DateTime.Now.Date, ref Form, ref userId);
        Formid wordform = (Formid)Enum.Parse(typeof(Formid), Form);
        return (new Word(userId,wordform)  as IWord);
    }
    public void RemoveWordFromReview(IWord word)
    {
        if(UserDataNow.NowUser == null) { return; }
        WordMover.UpdateReviewWord(UserDataMover.GetUserId(UserDataNow.NowUser),word.word);
    }
}

public class WordManagement : IWordManagement
{
    public IWord GetRandomWordForReciter()
    {
        if (UserDataNow.NowUser == null) return new Word(1);//游客模式
        return new Word(UserDataNow.Progress++,UserDataNow.userDictionarySelect);//创建单词，将临时进度加一
    }
    public void AddWordToReview(IWord word)
    {
        if(UserDataNow.NowUser == null) return;
        WordMover.AddReviewWord(UserDataMover.GetUserId(UserDataNow.NowUser),
                                word.word,
                                WordMover.GetWordId(word.word,UserDataNow.userDictionarySelect),
                                UserDataNow.userDictionarySelect);
    }
}
```
- **说明**：
  - 分别实现复习和学习流程的管理接口。
  - 通过工具类，Word实例化和UserDatanow的即时用户数据，逻辑整合实现接口。
  - 将各个类的方法字段按逻辑整合到一起，减少其他类之间的直接依赖。


#### DAL层运作方式总结

- **面向对象**：单词、释义、短语等采用泛型和继承体系，便于扩展和维护。
- **静态工具类**：WordMover、UserDataMover等静态类集中封装数据查询、进度同步、复习管理等操作，业务层通过这些接口与数据库交互。
- **临时状态桥接**：UserDataNow作为全局临时状态存储，负责用户、词库、进度等信息的同步，保证多层间数据一致性。
- **EFCore特性**：利用导航属性、Include、LINQ等EFCore特性实现高效的数据查询和关系映射。
- **接口多态**：上层业务通过接口（如IWordManagement、IReviewListManagement）调用DAL层，便于测试和扩展。

整体上，DAL层实现了“实体-上下文-操作工具-全局状态-业务接口”五级分工，既保证了数据访问的高效与安全，也为业务逻辑扩展和维护提供了良好基础。

#### 简略关系图

```
+---------------------+                            +---------------------+
|   SqlDataContext    |                            |    UserContext      |
+---------------------+                            +---------------------+
| - DbSet<CET4>       |                            | - DbSet<UserData>   |
| - DbSet<CET6>       |                            | - DbSet<UserWord>   |
| - ...（各词库）      |                            | - DbSet<UserReview> |
+---------------------+                            +---------------------+
        |                                                    |
        v                                                    v
+---------------------+                           +---------------------+
|   词库实体类         |                           |   用户相关实体类     |
|  CET4, CET4T, CET4P |                           |   UserData,         |
|  CET6, ...等        |                           |  UserWord,          |
|                     |                           |   UserReview        |
+---------------------+                           +---------------------+
        ^                                                    ^
        |                                                    |
+---------------------+   +---------------------+   +---------------------+
|   WordMover         |-->|      Word           |   |   UserDataMover     |
+---------------------+   +---------------------+   +---------------------+
        |   \                |   /      \              |   /
        |    \_______________|__/        \_____________|__/
        |             |                        |
        v             v                        v
+-----------------------------------------------+
|      ReviewListManagement / WordManagement    |
+-----------------------------------------------+
                ^
                |
                |
        +-----------------+
        |  UserDataNow    |
        +-----------------+
```

- Word类与WordMover、UserDataMover同级，位于中间，和WordMover有直接依赖关系（Word内部大量调用WordMover方法）。
- ReviewListManagement 和 WordManagement 两个接口实现类都依赖 Word、WordMover、UserDataMover 和 UserDataMover。
- UserDataNow 仅作为全局用户状态的临时存储，向工具类和接口实现提供当前用户、词库、进度等信息，用于数据库查询和方法参数。
- WordMover 负责操作单词相关数据，UserDataMover 负责操作用户相关数据，分别依赖各自的实体和Context。
- SqlDataContext 和 UserContext 是平级的，分别管理单词词库和用户相关数据。
- 补充DAL还有登录注册的部分和半成品的收藏功能，由于不是我写的不做展示。