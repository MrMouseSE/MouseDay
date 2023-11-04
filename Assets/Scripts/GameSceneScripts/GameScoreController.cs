namespace GameSceneScripts
{
    public class GameScoreController
    {
        private CurrentPlayerData _currentPlayerData;

        public GameScoreController(float time)
        {
            _currentPlayerData = new CurrentPlayerData
            {
                InitGameTime = time
            };
        }

        public CurrentPlayerData GetPlayerData()
        {
            return _currentPlayerData;
        }

        public void UpdateCurrentScore(int value)
        {
            _currentPlayerData.CurrentScore += value;
        }
    }
}

public class CurrentPlayerData
{
    public int CurrentScore;
    public float InitGameTime;
}
