﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OsuSharp.BeatmapsEndpoint;
using OsuSharp.Entities;
using OsuSharp.ScoreEndpoint;
using OsuSharp.UserEndpoint;

namespace OsuSharp.Example
{
    internal class Program
    {
        private static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        public static async Task MainAsync()
        {
            try
            {
                OsuApi.Init(File.ReadAllText("token.txt"), ", ");

                Users user = await OsuApi.GetUserByNameAsync("Evolia");
                Console.WriteLine($"User {user.Username} with id {user.Userid}\n" +
                                  $" > Current accuracy : {user.Accuracy}\n" +
                                  $" > Total Score : {user.TotalScore}\n" +
                                  $" > Ranked Score : {user.RankedScore}\n" +
                                  $" > Level : {user.Level}\n" +
                                  $" > Performance Points : {user.Pp}\n" +
                                  $" > Play count : {user.PlayCount}");

                Beatmaps beatmap = await OsuApi.GetBeatmapAsync(75);
                Console.WriteLine($"\n\nBeatmap {beatmap.Title} with id {beatmap.BeatmapId} mapped by {beatmap.Creator}\n" +
                                  $" > Difficulty : {beatmap.Difficulty}\n" +
                                  $" > State : {beatmap.Approved}\n" +
                                  $" > BPM : {beatmap.Bpm}\n" +
                                  $" > AR : {beatmap.ApproachRate}\n" +
                                  $" > OD : {beatmap.OverallDifficulty}\n" +
                                  $" > CS : {beatmap.CircleSize}\n" +
                                  $" > HP : {beatmap.HpDrain}\n" +
                                  $" > Star difficulty : {beatmap.DifficultyRating}\n");

                List<UserBestBeatmap> userBestsBeatmaps = await OsuApi.GetUserBestAndBeatmapByUsernameAsync("Evolia");
                foreach (UserBestBeatmap userBestBeatmap in userBestsBeatmaps)
                {
                    Console.WriteLine($"\nScore {userBestBeatmap.UserBest.Score} with {userBestBeatmap.UserBest.Accuracy} accuracy\nOn map {userBestBeatmap.Beatmap.Title} made by {userBestBeatmap.Beatmap.Creator} with difficulty {userBestBeatmap.Beatmap.Difficulty}");
                }

                BeatmapScores beatmapScores = await OsuApi.GetScoresAndBeatmapAsync(75);
                Console.WriteLine($"\n\nBeatmap {beatmapScores.Beatmap.Title} with id {beatmapScores.Beatmap.BeatmapId} mapped by {beatmapScores.Beatmap.Creator}\n" +
                                  $" > Difficulty : {beatmapScores.Beatmap.Difficulty}\n" +
                                  $" > State : {beatmapScores.Beatmap.Approved}\n" +
                                  $" > BPM : {beatmapScores.Beatmap.Bpm}\n" +
                                  $" > AR : {beatmapScores.Beatmap.ApproachRate}\n" +
                                  $" > OD : {beatmapScores.Beatmap.OverallDifficulty}\n" +
                                  $" > CS : {beatmapScores.Beatmap.CircleSize}\n" +
                                  $" > HP : {beatmapScores.Beatmap.HpDrain}\n" +
                                  $" > Star difficulty : {beatmapScores.Beatmap.DifficultyRating}");
                foreach (Scores score in beatmapScores.Score)
                {
                    Console.WriteLine($"\nScore {score.Score} with {score.Accuracy} accuracy made by {score.Username}");
                }

                BeatmapScoresUsers beatmapScoresUsers = await OsuApi.GetScoresWithUsersAndBeatmapAsync(75);
                Console.WriteLine($"\n\nBeatmap {beatmapScores.Beatmap.Title} with id {beatmapScores.Beatmap.BeatmapId} mapped by {beatmapScores.Beatmap.Creator}\n" +
                                  $" > Difficulty : {beatmapScores.Beatmap.Difficulty}\n" +
                                  $" > State : {beatmapScores.Beatmap.Approved}\n" +
                                  $" > BPM : {beatmapScores.Beatmap.Bpm}\n" +
                                  $" > AR : {beatmapScores.Beatmap.ApproachRate}\n" +
                                  $" > OD : {beatmapScores.Beatmap.OverallDifficulty}\n" +
                                  $" > CS : {beatmapScores.Beatmap.CircleSize}\n" +
                                  $" > HP : {beatmapScores.Beatmap.HpDrain}\n" +
                                  $" > Star difficulty : {beatmapScores.Beatmap.DifficultyRating}");
                foreach (Scores score in beatmapScores.Score)
                {
                    Users currentUser = beatmapScoresUsers.Users.SingleOrDefault(x => x.Username == score.Username);
                    Console.WriteLine(currentUser != null
                        ? $"\nScore {score.Score} with {score.Accuracy} accuracy made by {currentUser.Username} that has {currentUser.Pp} performance points."
                        : $"\nScore {score.Score} with {score.Accuracy} accuracy made by {score.Username}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            await Task.Delay(Timeout.Infinite);
        }
    }
}
