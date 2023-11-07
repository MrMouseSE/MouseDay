using System.Collections.Generic;
using System.Linq;
using GameSceneScripts.UsableObjectTypes;

namespace GameSceneScripts
{
    public class UsableObjectTypeResolver
    {
        private List<UsableObjectValues> _objectsValues;

        public UsableObjectTypeResolver(UsableObjectsDescription description)
        {
            _objectsValues = description.UsableObjects.ToList();
            _objectsValues = _objectsValues.OrderBy(x=>x.SpawnChance).ToList();
        }

        public UsableObjectValues GetObjectType(float percent)
        {
            for (var index = 0; index < _objectsValues.Count; index++)
            {
                var objectSpawnPercent = (float)_objectsValues[index].SpawnChance/100;
                if (objectSpawnPercent> percent) return _objectsValues[index];
            }

            return _objectsValues.Last();
        }
    }
}
