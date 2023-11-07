using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeaderBoardScripts
{
    public class LeadersListController : MonoBehaviour
    {
        public LeaderHolderContainer LeaderContainer;
        public float DelayBetweenLinesAppear;

        private List<LeaderHolderContainer> _leaderContainers = new List<LeaderHolderContainer>();
        private RectTransform _myRectTransform;
        private void Awake()
        {
            _myRectTransform = GetComponent<RectTransform>();
            FillList();
        }

        private void FillList()
        {
            var leaders = LeaderBoardHandler.GetAllLeadersData();
            StartCoroutine(FillLeadersList(leaders));
        }

        public void RefillLeadersList()
        {
            foreach (var leaderContainer in _leaderContainers)
            {
                Destroy(leaderContainer.gameObject);
            }
            _leaderContainers.Clear();
            FillList();
        }

        private IEnumerator FillLeadersList(List<LeaderBoardData> leaders)
        {
            yield return new WaitForSeconds(DelayBetweenLinesAppear);
            for (int i = 0; i < leaders.Count; i++)
            {
                InstantiateLeaderString(leaders[i], i);
                yield return new WaitForSeconds(DelayBetweenLinesAppear);
            }
        }

        private void InstantiateLeaderString(LeaderBoardData leader, int index)
        {
            var leaderString = Instantiate(LeaderContainer, _myRectTransform);
            leaderString.MyRectTransform.Translate(Vector3.down*leaderString.StringHeight*index);
            leaderString.NameField.text = leader.Name;
            leaderString.ScoreField.text = leader.Score.ToString();
            leaderString.SetTime(leader.Time);
            _leaderContainers.Add(leaderString);
        }
    }
}
