using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    /// <summary>
    /// 数据库上下文类，用于配置和操作数据库。<br/>
    /// 这个类使用 Entity Framework Core 进行数据库操作。<br/>
    /// </summary>
    public class SqlDataContext : DbContext
    {
        
        public DbSet<CET4> CET4 { get; set; } // 对应数据库中的 CET4 表。
        public DbSet<CET6> CET6 { get; set; } // 对应数据库中的 CET6 表。
        public DbSet<MiddleSchool> MiddleSchool { get; set; } // 对应数据库中的 初中 表。
        public DbSet<HighSchool> Highschool { get; set; } // 对应数据库中的 高中 表。
        public DbSet<KY> KY { get; set; } // 对应数据库中的 四级 表。
        public DbSet<TF> TF { get; set; } // 对应数据库中的 托福 表。

        /// <summary>
        /// 配置数据库连接。<br/>
        /// 此处不安全地暴露了数据库连接字符串，实际使用中应使用安全的配置方式。<br/>
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=26.184.142.179,1433;Database=Word;User Id=sa;Password=114514;Encrypt=False;");
            //zibu数据库的IP地址，使用时取消注释。
            //optionsBuilder.UseSqlServer("Server=26.99.236.84;Database=wordforms;User Id=sa;Password=114514;Encrypt=False;");
            //小鼠数据库的IP地址，使用时取消注释。
        }

        /// <summary>
        /// 配置模型映射。<br/>
        /// 将数据库表映射到模型类。
        /// 虽然某些简单的映射可以通过默认约定完成，但复杂的场景（如自定义表名或关系）需要在 OnModelCreating 中显式配置。
        /// 每个实体类只能映射一个数据库表
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordForm>(c =>
            {
                c.HasKey(f => f.Id);// 配置主键。
            });
            modelBuilder.Entity<TranslationForm>(c =>
            {
                c.HasKey(f => f.Id);// 配置主键。
                c.HasOne(f => f.WordForm)
                 .WithMany(f => f.Translations)// 定义关系。
                 .HasForeignKey(f => f.WordId) // 配置外键。
                 .OnDelete(DeleteBehavior.Cascade); // 级联删除，或许有用？
            });
            modelBuilder.Entity<PhraseForm>(c =>
            {
                c.HasKey(f => f.Id);
                c.HasOne(f => f.WordForm)
                 .WithMany(f =>f.Phrases)
                 .HasForeignKey(f => f.WordId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<CET4>().ToTable("CET4Words");
            modelBuilder.Entity<CET4T>().ToTable("CET4Translations");
            modelBuilder.Entity<CET4P>().ToTable("CET4Phrases");
            modelBuilder.Entity<CET6>().ToTable("CET6Words");
            modelBuilder.Entity<CET6T>().ToTable("CET6Translations");
            modelBuilder.Entity<CET6P>().ToTable("CET6Phrases");
            modelBuilder.Entity<MiddleSchool>().ToTable("MiddleSchoolWords");
            modelBuilder.Entity<MiddleSchoolT>().ToTable("MiddleSchoolTranslations");
            modelBuilder.Entity<MiddleSchoolP>().ToTable("MiddleSchoolPhrases");
            modelBuilder.Entity<HighSchool>().ToTable("HighSchoolWords");
            modelBuilder.Entity<HighSchoolT>().ToTable("HighSchoolTranslations");
            modelBuilder.Entity<HighSchoolP>().ToTable("HighSchoolPhrases");
            modelBuilder.Entity<KY>().ToTable("KYWords");
            modelBuilder.Entity<KYT>().ToTable("KYTranslations");
            modelBuilder.Entity<KYP>().ToTable("KYPhrases");
            modelBuilder.Entity<TF>().ToTable("TFWords");
            modelBuilder.Entity<TFT>().ToTable("TFTranslations");
            modelBuilder.Entity<TFP>().ToTable("TFPhrases");
        }
        /// <summary>
        ///这是一个一键映射实体类的方法<br/>
        ///需要传入表的名称，如CET4,CET6等<br/>
        ///本类与实体类和数据库表的关联较大，若实体类基类和表名改变需要在这里修改。<br/>
        ///由于EF有轮椅机制，所以该方法废弃了<br/>
        ///没废弃，EF轮椅机制不行事
        /// </summary>
        /// <typeparam name="MainF"></typeparam>
        /// <typeparam name="TranslationForm"></typeparam>
        /// <typeparam name="PhraseForm"></typeparam>
        /// <param name="modelBuilder"></param>
        private static void FastCreateModel<MainF,TlForm,PForm>(ModelBuilder modelBuilder,string FormName)
            where MainF : WordForm
            where TlForm : TranslationForm//限制泛型类必须继承了实体类的基类,
            where PForm : PhraseForm
        {
            modelBuilder.Entity<MainF>(c =>
            {
                c.ToTable($"{FormName}Words");// 映射到数据库表。
            });

            modelBuilder.Entity<TlForm>(c =>
            {
                c.ToTable($"{FormName}Translations");// 映射到数据库表。
                c.HasKey(f => f.Id);// 配置主键。

                c.HasOne(f => f.WordForm)
                 .WithMany(f => (IEnumerable<TlForm>?)f.Translations)// 定义关系。
                 .HasForeignKey(f => f.WordId) // 配置外键。
                 .OnDelete(DeleteBehavior.Cascade); // 级联删除，或许有用？
            });

            modelBuilder.Entity<PForm>(c =>
            {
                c.ToTable($"{FormName}Phrases");
                c.HasKey(f => f.Id);

                c.HasOne(f => f.WordForm)
                 .WithMany(f => (IEnumerable<PForm>?)f.Phrases)
                 .HasForeignKey(f => f.WordId)
                 .OnDelete(DeleteBehavior.Cascade); 
            });
        }
    }
}
