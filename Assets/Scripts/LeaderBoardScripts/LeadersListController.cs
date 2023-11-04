using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeaderBoardScripts
{
    public class LeadersListController : MonoBehaviour
    {
        public LeaderHolderContainer LeaderContainer;

        private List<LeaderHolderContainer> _leaderContainers;
        private RectTransform _myRectTransform;
        private void Awake()
        {
            _myRectTransform = GetComponent<RectTransform>();
            var leaders = LeaderBoardHandler.GetAllLeadersData();
        }

        private IEnumerator FillLeadersList(List<LeaderBoardData> leaders)
        {
            for (int i = 0; i < leaders.Count; i++)
            {
                InstantiateLeaderString(leaders[i], i);
                yield return new WaitForSeconds(0.2f);
            }
        }

        private void InstantiateLeaderString(LeaderBoardData leader, int index)
        {
            var leaderString = Instantiate(LeaderContainer, _myRectTransform);
            leaderString.MyRectTransform.Translate(Vector3.down*leaderString.StringHeight*index);
            leaderString.NameField.text = leader.Name;
            leaderString.ScoreField.text = leader.Score.ToString();
            leaderString.SetTime(leader.Time);
        }
    }
}
