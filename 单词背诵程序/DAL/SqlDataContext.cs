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
        public DbSet<dictionary> 考研 { get; set; } // 对应数据库中的 考研 表。
        public DbSet<dictionary> CET6 { get; set; } // 对应数据库中的 CET6 表。
        public DbSet<dictionary> 初中 { get; set; } // 对应数据库中的 初中 表。
        public DbSet<dictionary> 高中 { get; set; } // 对应数据库中的 高中 表。
        public DbSet<dictionary> 托福 { get; set; } // 对应数据库中的 托福 表。
        public DbSet<dictionary> CET4 { get; set; } //对应数据库中的 CET4 表。  

        /// <summary>
        /// 配置数据库连接。<br/>
        /// 此处不安全地暴露了数据库连接字符串，实际使用中应使用安全的配置方式。<br/>
        /// 在改了喵~在改了喵~<br/>
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=172.22.178.195,1433;Database=背单词;User Id=sa;Password=114514;Encrypt=False;");
        }

        /// <summary>
        /// 配置模型映射。<br/>
        /// 将数据库表映射到模型类。
        /// 虽然某些简单的映射可以通过默认约定完成，但复杂的场景（如自定义表名或关系）需要在 OnModelCreating 中显式配置。
        /// (貌似不写也能跑)？
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dictionary>().HasKey(c => c.number); // 配置主键。
        }
    }
}
