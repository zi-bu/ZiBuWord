using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 数据库上下文类，用于配置和操作数据库。<br/>
    /// 这个类使用 Entity Framework Core 进行数据库操作。<br/>
    /// 这个类是由```子布```书写完成的，不要感谢他的贡献。<br/>
    /// mouse:我来改改
    /// </summary>
    public class SqlDataContext : DbContext
    {
        //mouse：数据库模板dictionary创建的DbSet集合<br/>
        public DbSet<CET4> CET4 { get; set; } // 对应数据库中的 CET4 表。
        public DbSet<CET6> CET6 { get; set; } // 对应数据库中的 CET6 表。
        public DbSet<初中> 初中 { get; set; } // 对应数据库中的 初中 表。
        public DbSet<高中> 高中 { get; set; } // 对应数据库中的 高中 表。
        public DbSet<考研> 考研 { get; set; } // 对应数据库中的 四级 表。
        public DbSet<托福> 托福 { get; set; } // 对应数据库中的 托福 表。

        /// <summary>
        /// 配置数据库连接。<br/>
        /// 此处不安全地暴露了数据库连接字符串，实际使用中应使用安全的配置方式。<br/>
        /// 在改了喵~在改了喵~<br/>
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=26.184.142.179,1433;Database=背单词;User Id=sa;Password=114514;Encrypt=False;");
            //10.151.196.28在校园网中用有线网时数据库的IP地址，使用时取消注释。
            //optionsBuilder.UseSqlServer("Server=localhost\\GOODSQL;Database=wordforms;User Id=sa;Password=114514;Encrypt=False;");
            //小鼠的测试服务器。(因为是本地连接)10.162.21.248
        }

        /// <summary>
        /// 配置模型映射。<br/>
        /// 将数据库表映射到模型类。
        /// 虽然某些简单的映射可以通过默认约定完成，但复杂的场景（如自定义表名或关系）需要在 OnModelCreating 中显式配置。
        /// mouse:每个实体类只能映射一个数据库表
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CET4>().HasKey(c => c.number); // 配置主键。
            modelBuilder.Entity<CET4>().ToTable("CET4"); // 映射到 CET4 表。

            modelBuilder.Entity<CET6>().HasKey(c => c.number); 
            modelBuilder.Entity<CET6>().ToTable("CET6");

            modelBuilder.Entity<初中>().HasKey(c => c.number);
            modelBuilder.Entity<初中>().ToTable("初中");

            modelBuilder.Entity<高中>().HasKey(c => c.number);
            modelBuilder.Entity<高中>().ToTable("高中");

            modelBuilder.Entity<考研>().HasKey(c => c.number);
            modelBuilder.Entity<考研>().ToTable("考研");

            modelBuilder.Entity<托福>().HasKey(c => c.number);
            modelBuilder.Entity<托福>().ToTable("托福");
        }
    }
}
