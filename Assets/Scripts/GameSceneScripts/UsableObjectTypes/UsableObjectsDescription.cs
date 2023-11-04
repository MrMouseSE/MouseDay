using UnityEngine;

namespace GameSceneScripts.UsableObjectTypes
{
    [CreateAssetMenu(fileName = "UsableObjectsData", menuName = "ScriptableObjects/UsableObjectsData", order = 1)]
    public class UsableObjectsDescription : ScriptableObject
    {
        public UsableObjectValues[] UsableObjects;
    }
}
