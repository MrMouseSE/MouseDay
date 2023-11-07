using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LeaderBoardScripts
{
    public static class LeaderBoardHandler
    {
        public static void SaveCurrentProgressToPrefs(int score, float time)
        {
            time = Mathf.Floor(time);
            PlayerPrefs.SetString("currentSessionData", $"{score}_{time}");
            PlayerPrefs.Save();
        }

        public static void SetToLeaderBoard(LeaderBoardData data)
        {
            var currentLeadersData = GetAllLeadersData();
            currentLeadersData.Add(data);
            currentLeadersData = currentLeadersData.OrderBy(x => x.Score).ToList();
            if (currentLeadersData.Count>10) currentLeadersData.RemoveAt(0);
            currentLeadersData.Reverse();
            SaveSortedBoardToPrefs(currentLeadersData);
        }

        public static List<LeaderBoardData> GetAllLeadersData()
        {
            var bothData = PlayerPrefs.GetString("LeadersData");
            if (bothData == "") return new List<LeaderBoardData>();
            var leaders = bothData.Split("~");
            List<LeaderBoardData> leadersData = new List<LeaderBoardData>();
            foreach (var leader in leaders)
            {
                var leaderUnformatedData = leader.Split("`");
                LeaderBoardData leaderData = new LeaderBoardData();
                leaderData.Name = leaderUnformatedData[0];
                leaderData.Score = Convert.ToInt16(leaderUnformatedData[1]);
                leaderData.Time = float.Parse(leaderUnformatedData[2]);
                leadersData.Add(leaderData);
            }
            return leadersData;
        }

        private static void SaveSortedBoardToPrefs(List<LeaderBoardData> data)
        {
            string saveLeaderData = "";
            foreach (var currentStepData in data)
            {
                saveLeaderData +=  "~" + currentStepData.Name + "`" + currentStepData.Score + "`" + currentStepData.Time;
            }
            saveLeaderData = saveLeaderData.Remove(0, 1);
            PlayerPrefs.SetString("LeadersData", saveLeaderData);
            PlayerPrefs.Save();
        }
    }
}
