using BLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BLL.Security
{
    public class AuthService
    {
        private readonly SqlDataContext _context;
        private readonly PasswordHasher _passwordHasher;
        private readonly PasswordValidator _passwordValidator;

        public AuthService(SqlDataContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher();
            _passwordValidator = new PasswordValidator();
        }

        public async Task<(bool Success, string Message)> RegisterUserAsync(string username, string password, string email)
        {
            // 验证用户名是否已存在
            if (await _context.Users.AnyAsync(u => u.Username == username))
            {
                return (false, "用户名已存在");
            }

            // 验证邮箱是否已存在
            if (await _context.Users.AnyAsync(u => u.Email == email))
            {
                return (false, "邮箱已被注册");
            }

            // 验证密码强度
            var (isValid, message) = _passwordValidator.ValidatePassword(password);
            if (!isValid)
            {
                return (false, message);
            }

            // 创建新用户
            var user = new User
            {
                Username = username,
                PasswordHash = _passwordHasher.HashPassword(password),
                Email = email,
                IsActive = true,
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return (true, "注册成功");
        }

        public async Task<(bool Success, string Message, User User)> ValidateUserAsync(string username, string password, string ipAddress, string userAgent)
        {
            var user = await _context.Users
                .Include(u => u.LoginAttempts)
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return (false, "用户名或密码错误", null);
            }

            // 检查账户是否被锁定
            var recentFailedAttempts = user.LoginAttempts
                .Where(a => !a.IsSuccessful && a.AttemptTime > DateTime.UtcNow.AddMinutes(-SecurityConfig.LoginAttempts.LockoutMinutes))
                .Count();

            if (recentFailedAttempts >= SecurityConfig.LoginAttempts.MaxAttempts)
            {
                return (false, $"账户已被锁定，请{SecurityConfig.LoginAttempts.LockoutMinutes}分钟后再试", null);
            }

            // 验证密码
            if (!_passwordHasher.VerifyPassword(password, user.PasswordHash))
            {
                // 记录失败的登录尝试
                var failedAttempt = new LoginAttempt
                {
                    UserId = user.Id,
                    AttemptTime = DateTime.UtcNow,
                    IsSuccessful = false,
                    IpAddress = ipAddress,
                    UserAgent = userAgent
                };

                _context.LoginAttempts.Add(failedAttempt);
                await _context.SaveChangesAsync();

                return (false, "用户名或密码错误", null);
            }

            // 记录成功的登录尝试
            var successfulAttempt = new LoginAttempt
            {
                UserId = user.Id,
                AttemptTime = DateTime.UtcNow,
                IsSuccessful = true,
                IpAddress = ipAddress,
                UserAgent = userAgent
            };

            _context.LoginAttempts.Add(successfulAttempt);

            // 更新最后登录时间
            user.LastLoginTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return (true, "登录成功", user);
        }

        public async Task<(bool Success, string Message)> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return (false, "用户不存在");
            }

            // 验证当前密码
            if (!_passwordHasher.VerifyPassword(currentPassword, user.PasswordHash))
            {
                return (false, "当前密码错误");
            }

            // 验证新密码强度
            var (isValid, message) = _passwordValidator.ValidatePassword(newPassword);
            if (!isValid)
            {
                return (false, message);
            }

            // 更新密码
            user.PasswordHash = _passwordHasher.HashPassword(newPassword);
            await _context.SaveChangesAsync();

            return (true, "密码修改成功");
        }
    }
} 