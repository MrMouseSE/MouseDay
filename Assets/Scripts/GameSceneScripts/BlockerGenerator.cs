using System.Collections.Generic;
using UnityEngine;

namespace GameSceneScripts
{
    public class BlockerGenerator : MonoBehaviour
    {
        public BlockerController BlockerObject;
        public Transform MyTransform;

        public List<BlockerController> GenerateGameGrid(Vector2 gridSize)
        {
            var myGeneratedBlockers = new List<BlockerController>();
            Vector3 initPosition = new Vector3(-gridSize.x / 2, 0, -gridSize.y / 2);
            for (int i = 0; i < gridSize.x; i++)
            {
                for (int j = 0; j < gridSize.y; j++)
                {
                    var blocker = Instantiate(BlockerObject, MyTransform);
                    var currentPosition = initPosition + new Vector3(i, 0, j);
                    blocker.SetPosition(currentPosition);
                    blocker.PlayInitAnimation();
                    myGeneratedBlockers.Add(blocker);
                }
            }

            return myGeneratedBlockers;
        }
    }
}