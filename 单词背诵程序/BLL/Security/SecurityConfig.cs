namespace BLL.Security
{
    public static class SecurityConfig
    {
        // 密码策略
        public static class PasswordPolicy
        {
            public const int MinLength = 8;
            public const int MaxLength = 32;
            public const bool RequireUppercase = true;
            public const bool RequireLowercase = true;
            public const bool RequireDigit = true;
            public const bool RequireSpecialChar = true;
        }

        // 登录尝试限制
        public static class LoginAttempts
        {
            public const int MaxAttempts = 5;
            public const int LockoutMinutes = 30;
        }

        // 会话配置
        public static class Session
        {
            public const int TimeoutMinutes = 30;
            public const bool SlidingExpiration = true;
        }

        // 密码重置
        public static class PasswordReset
        {
            public const int TokenExpirationHours = 24;
            public const int MinTimeBetweenResets = 24; // 小时
        }
    }
} 