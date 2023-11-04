using System.Collections;
using System.Collections.Generic;
using GameSceneScripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class UsableObjectSpawner : MonoBehaviour
{
    public UsableObjectController MyUsableObject;

    private UsableObjectController _currentUsableObject;
    private GameFieldDifficultyContainer _gameSettings;
    private List<BlockerController> _positionsToSpawn;
    private float _timeToNextSpawn;

    public void InitUsableObjectSpawner(GameFieldDifficultyContainer settings, List<BlockerController> blockers)
    {
        _gameSettings = settings;
        _positionsToSpawn = blockers;
        _timeToNextSpawn = _gameSettings.DefaultTimeToNextSpawn;
        InitSpawnUsableObject();
    }

    private void InitSpawnUsableObject()
    {
        _currentUsableObject = Instantiate(MyUsableObject, transform);
        _currentUsableObject.ObjectUsed.AddListener(NextObjectSpawn);
        _currentUsableObject.SetObjectNewPosition(GetSpawnPosition());
        StartCoroutine(DelayForNextSpawn(_timeToNextSpawn));
    }

    private Vector3 GetSpawnPosition()
    {
        return _positionsToSpawn[Random.Range(0, _positionsToSpawn.Count)].MyTransform.position;
    }

    private void NextObjectSpawn()
    {
        _currentUsableObject.SetObjectNewPosition(GetSpawnPosition());
    }

    private IEnumerator DelayForNextSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        if (_timeToNextSpawn>_gameSettings.MinimumNextSpawnTimeValue)
        {
            _timeToNextSpawn -= _gameSettings.ReduceNextSpawnTimeValue;
        }
        NextObjectSpawn();
    }

    private void OnDestroy()
    {
        _currentUsableObject.ObjectUsed.RemoveListener(NextObjectSpawn);
    }
}
