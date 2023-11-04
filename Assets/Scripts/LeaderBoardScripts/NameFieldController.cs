using System;
using TMPro;
using UnityEngine;

namespace LeaderBoardScripts
{
    public class NameFieldController : MonoBehaviour
    {
        public TextMeshProUGUI NameField;
        public LeadersListController ListController;

        public void SaveCurrentScoreWithName()
        {
            string name = NameField.text;
            name = name.Replace("~", "");
            name = name.Replace("`", "");
            if (name == " ") name = "John Daw";
            var currentValues = PlayerPrefs.GetString("currentSessionData").Split("_");
            int score = Convert.ToInt16(currentValues[0]);
            float time = float.Parse(currentValues[1]);
            var playerData = new LeaderBoardData();
            playerData.Name = name;
            playerData.Score = score;
            playerData.Time = time;
            LeaderBoardHandler.SetToLeaderBoard(playerData);
            ListController.RefillLeadersList();
            gameObject.SetActive(false);
        }
    }
}
