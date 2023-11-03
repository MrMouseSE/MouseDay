using System.Collections.Generic;
using UnityEngine;

namespace GameSceneScripts
{
    [CreateAssetMenu(fileName = "GameFieldData", menuName = "ScriptableObjects/GameFieldData", order = 1)]
    public class GameFieldDescription : ScriptableObject
    {
        public List<GameFieldDifficultyContainer> GameDifficultySettings;

        public GameFieldDifficultyContainer GetCurrentDifficultyContainer(int difficulty)
        {
            if (GameDifficultySettings.Exists(x=>x.Difficulty == difficulty))
            {
                return GameDifficultySettings.Find(x => x.Difficulty == difficulty);
            }

            return GameDifficultySettings[0];
        }
    }
}


