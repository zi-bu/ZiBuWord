using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Threading;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using BLL.Models;

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
        private readonly IConfiguration _configuration;
        
        public SqlDataContext()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true);
            
            _configuration = builder.Build();
        }
        
        // 用户相关
        public DbSet<User> Users { get; set; }
        public DbSet<LoginAttempt> LoginAttempts { get; set; }
        
        // 单词相关
        public DbSet<DataDictionary> CET4 { get; set; } // 对应数据库中的 CET4 表。
        public DbSet<DataDictionary> CET6 { get; set; } // 对应数据库中的 CET6 表。
        public DbSet<DataDictionary> 初中 { get; set; } // 对应数据库中的 初中 表。
        public DbSet<DataDictionary> 高中 { get; set; } // 对应数据库中的 高中 表。
        public DbSet<DataDictionary> 托福 { get; set; } // 对应数据库中的 托福 表。

        /// <summary>
        /// 配置数据库连接。<br/>
        /// 此处不安全地暴露了数据库连接字符串，实际使用中应使用安全的配置方式。<br/>
        /// 在改了喵~在改了喵~<br/>
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("数据库连接字符串未配置");
                }
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        /// <summary>
        /// 配置模型映射。<br/>
        /// 将数据库表映射到模型类。
        /// 虽然某些简单的映射可以通过默认约定完成，但复杂的场景（如自定义表名或关系）需要在 OnModelCreating 中显式配置。
        /// (貌似不写也能跑)？
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置用户表
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
            });

            // 配置登录尝试表
            modelBuilder.Entity<LoginAttempt>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(u => u.LoginAttempts)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // 配置单词表
            modelBuilder.Entity<DataDictionary>().HasKey(c => c.number);
            modelBuilder.Entity<DataDictionary>().ToTable("CET4");
            modelBuilder.Entity<DataDictionary>().ToTable("CET6");
        }

        // 添加审计字段
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && 
                           (e.State == EntityState.Added || e.State == EntityState.Modified));
                           
            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;
                
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                
                entity.UpdatedAt = DateTime.UtcNow;
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }

    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetPagedAsync(int page, int pageSize);
    }

    public interface IUnitOfWork : IDisposable
    {
        IRepository<DataDictionary> WordRepository { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }

    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<CacheService> _logger;
        
        public CacheService(IMemoryCache cache, ILogger<CacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }
        
        public async Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration = null)
        {
            if (_cache.TryGetValue(key, out T value))
            {
                return value;
            }
            
            value = await factory();
            
            var cacheOptions = new MemoryCacheEntryOptions();
            if (expiration.HasValue)
            {
                cacheOptions.AbsoluteExpirationRelativeToNow = expiration;
            }
            
            _cache.Set(key, value, cacheOptions);
            
            return value;
        }
    }
}
