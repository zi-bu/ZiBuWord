using System.Text.RegularExpressions;

namespace BLL.Security
{
    public class PasswordValidator
    {
        public (bool IsValid, string Message) ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return (false, "密码不能为空");
            }

            if (password.Length < SecurityConfig.PasswordPolicy.MinLength)
            {
                return (false, $"密码长度不能小于{SecurityConfig.PasswordPolicy.MinLength}个字符");
            }

            if (password.Length > SecurityConfig.PasswordPolicy.MaxLength)
            {
                return (false, $"密码长度不能超过{SecurityConfig.PasswordPolicy.MaxLength}个字符");
            }

            if (SecurityConfig.PasswordPolicy.RequireUppercase && !password.Any(char.IsUpper))
            {
                return (false, "密码必须包含大写字母");
            }

            if (SecurityConfig.PasswordPolicy.RequireLowercase && !password.Any(char.IsLower))
            {
                return (false, "密码必须包含小写字母");
            }

            if (SecurityConfig.PasswordPolicy.RequireDigit && !password.Any(char.IsDigit))
            {
                return (false, "密码必须包含数字");
            }

            if (SecurityConfig.PasswordPolicy.RequireSpecialChar && !Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]"))
            {
                return (false, "密码必须包含特殊字符");
            }

            // 检查常见密码模式
            if (IsCommonPassword(password))
            {
                return (false, "密码过于简单，请使用更复杂的密码");
            }

            return (true, "密码符合要求");
        }

        private bool IsCommonPassword(string password)
        {
            // 这里可以添加一个常见密码列表进行检查
            var commonPasswords = new[]
            {
                "password", "123456", "qwerty", "admin", "welcome",
                "password123", "12345678", "abc123", "111111"
            };

            return commonPasswords.Contains(password.ToLower());
        }
    }
} 