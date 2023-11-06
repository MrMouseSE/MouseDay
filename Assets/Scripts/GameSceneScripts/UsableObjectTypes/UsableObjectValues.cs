using System;
using UnityEngine;

namespace GameSceneScripts.UsableObjectTypes
{
    [Serializable]
    public class UsableObjectValues
    {
        public string UsableObjectName;
        [Range(0,100)]
        public int SpawnChance;
        public int ScoreValue;
        public float TimeToNextSpawnBoost;
        public float HealthChangeValue;
        public Mesh UsageObjectMesh;
        public Material UsageObjectMaterial;
        public Sprite UsableObjectPopupSprite;
    }
}