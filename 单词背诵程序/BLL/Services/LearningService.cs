using BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LearningService
    {
        private readonly SqlDataContext _context;

        public LearningService(SqlDataContext context)
        {
            _context = context;
        }

        public async Task<List<Word>> GetWordsForReviewAsync(int userId, int count = 20)
        {
            var now = DateTime.UtcNow;
            var userProgress = await _context.UserWordProgresses
                .Where(p => p.UserId == userId && p.NextReviewTime <= now)
                .OrderBy(p => p.NextReviewTime)
                .Take(count)
                .Select(p => p.Word)
                .ToListAsync();

            if (userProgress.Count < count)
            {
                var newWords = await _context.Words
                    .Where(w => !w.UserProgresses.Any(p => p.UserId == userId))
                    .Take(count - userProgress.Count)
                    .ToListAsync();

                userProgress.AddRange(newWords);
            }

            return userProgress;
        }

        public async Task UpdateProgressAsync(int userId, int wordId, bool isCorrect)
        {
            var progress = await _context.UserWordProgresses
                .FirstOrDefaultAsync(p => p.UserId == userId && p.WordId == wordId);

            if (progress == null)
            {
                progress = new UserWordProgress
                {
                    UserId = userId,
                    WordId = wordId,
                    ReviewCount = 0,
                    CorrectCount = 0,
                    MasteryLevel = 0
                };
                _context.UserWordProgresses.Add(progress);
            }

            progress.ReviewCount++;
            if (isCorrect)
            {
                progress.CorrectCount++;
                progress.MasteryLevel = Math.Min(5, progress.MasteryLevel + 1);
            }
            else
            {
                progress.MasteryLevel = Math.Max(0, progress.MasteryLevel - 1);
            }

            progress.LastReviewTime = DateTime.UtcNow;
            progress.NextReviewTime = CalculateNextReviewTime(progress.MasteryLevel);
            progress.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        private DateTime CalculateNextReviewTime(int masteryLevel)
        {
            var now = DateTime.UtcNow;
            return masteryLevel switch
            {
                0 => now.AddHours(1),    // 1小时后
                1 => now.AddHours(4),    // 4小时后
                2 => now.AddDays(1),     // 1天后
                3 => now.AddDays(3),     // 3天后
                4 => now.AddDays(7),     // 1周后
                5 => now.AddDays(30),    // 1月后
                _ => now.AddDays(1)
            };
        }

        public async Task<Dictionary<string, int>> GetUserStatisticsAsync(int userId)
        {
            var progress = await _context.UserWordProgresses
                .Where(p => p.UserId == userId)
                .ToListAsync();

            return new Dictionary<string, int>
            {
                ["TotalWords"] = progress.Count,
                ["MasteredWords"] = progress.Count(p => p.MasteryLevel >= 4),
                ["LearningWords"] = progress.Count(p => p.MasteryLevel > 0 && p.MasteryLevel < 4),
                ["NewWords"] = progress.Count(p => p.MasteryLevel == 0),
                ["TotalReviews"] = progress.Sum(p => p.ReviewCount),
                ["CorrectReviews"] = progress.Sum(p => p.CorrectCount)
            };
        }
    }
} 