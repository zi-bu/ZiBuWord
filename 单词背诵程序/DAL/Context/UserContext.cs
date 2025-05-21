using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class UserContext : DbContext
{
    public DbSet<User> UserData { get; set; }
    // 对应数据库中的 UserData 表。
    public DbSet<UserWord> ReciteUserWord { get; set; }
    // 对应数据库中的 ReciteUserWord 表。
    public DbSet<FavoriteWord> FavoriteWords { get; set; }
    // 对应数据库中的 FavoriteWords 表。

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=26.184.142.179,1433;Database=UserData;User Id=sa;Password=114514;Encrypt=False;");
        //zibu数据库的IP地址，使用时取消注释。
        //optionsBuilder.UseSqlServer("Server=26.99.236.84;Database=wordforms;User Id=sa;Password=114514;Encrypt=False;");
        //小鼠数据库的IP地址，使用时取消注释。
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.UserID); // 配置主键。
        modelBuilder.Entity<User>().ToTable("UserData"); // 映射到 Users 表。
        modelBuilder.Entity<UserWord>().ToTable("ReciteUserWord"); // 映射到 UserWord 表。
        modelBuilder.Entity<UserWord>().HasKey(w => w.ID); // 配置主键。
        modelBuilder.Entity<User>()
            .HasOne(u => u.UserWord)
            .WithOne(w => w.User)
            .HasForeignKey<UserWord>(w => w.UserID);

        modelBuilder.Entity<FavoriteWord>().HasKey(f => f.Id); // 配置主键。
        modelBuilder.Entity<FavoriteWord>().ToTable("FavoriteWords"); // 映射到 FavoriteWords 表。
        modelBuilder.Entity<FavoriteWord>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(f => f.UserId);
    }
}