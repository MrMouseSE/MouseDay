using UnityEngine;

namespace LeaderBoardScripts
{
    public class CurrentResultController : MonoBehaviour
    {
        public LeaderHolderContainer LeaderContainer;
        private void Awake()
        {
            var unformatedData = PlayerPrefs.GetString("currentSessionData").Split("_");
            LeaderContainer.ScoreField.text = unformatedData[0];
            LeaderContainer.SetTime(unformatedData[1]);
        }
    }
}
