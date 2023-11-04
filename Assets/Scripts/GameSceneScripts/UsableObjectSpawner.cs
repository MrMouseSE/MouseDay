using System.Collections;
using System.Collections.Generic;
using GameSceneScripts.HalthSystem;
using GameSceneScripts.UsableObjectTypes;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameSceneScripts
{
    public class UsableObjectSpawner : MonoBehaviour
    {
        public UsableObjectController MyUsableObject;
        public UsableObjectsDescription UsableObjectsDescription;

        private TextMeshProUGUI _scoreText;
        private UsableObjectController _currentUsableObject;
        private GameFieldDifficultyContainer _gameSettings;
        private List<BlockerController> _positionsToSpawn;
        private float _timeToNextSpawn;
        private UsableObjectTypeResolver _usableObjectTypeResolver;
        private UsableObjectValues _currentObjectValues;
        private GameScoreController _gameScoreController;
        private HealthController _healthController;

        public void InitUsableObjectSpawner(GameFieldDifficultyContainer settings, List<BlockerController> blockers,
            TextMeshProUGUI scoreText, HealthController healthController)
        {
            _scoreText = scoreText;
            _healthController = healthController;
            _gameScoreController = new GameScoreController(Time.time);
            _usableObjectTypeResolver = new UsableObjectTypeResolver(UsableObjectsDescription);
            _gameSettings = settings;
            _positionsToSpawn = blockers;
            _timeToNextSpawn = _gameSettings.DefaultTimeToNextSpawn;
            InitSpawnUsableObject();
        }

        private void InitSpawnUsableObject()
        {
            _currentUsableObject = Instantiate(MyUsableObject, transform);
            _currentUsableObject.ObjectUsed.AddListener(ObjectUsed);
            NextObjectSpawn();
        }

        private Vector3 GetSpawnPosition()
        {
            return _positionsToSpawn[Random.Range(0, _positionsToSpawn.Count)].MyTransform.position;
        }

        private void ObjectUsed()
        {
            _gameScoreController.UpdateCurrentScore(_currentObjectValues.ScoreValue);
            _scoreText.text = _gameScoreController.GetPlayerData().CurrentScore.ToString();
            _healthController.UpdateHealth(_currentObjectValues.HealthChangeValue);
            _timeToNextSpawn += _currentObjectValues.TimeToNextSpawnBoost;
            NextObjectSpawn();
        }

        private void NextObjectSpawn()
        {
            _currentObjectValues = _usableObjectTypeResolver.GetObjectType(Random.value);
            _currentUsableObject.SetUsabaleObjectMesh(_currentObjectValues.UsageObjectMesh,_currentObjectValues.UsageObjectMaterial);
            _currentUsableObject.SetObjectNewPosition(GetSpawnPosition());
            StopAllCoroutines();
            StartCoroutine(DelayForNextSpawn(_timeToNextSpawn));
        }

        private IEnumerator DelayForNextSpawn(float time)
        {
            yield return new WaitForSeconds(time);
            if (_timeToNextSpawn > _gameSettings.MinimumNextSpawnTimeValue)
            {
                _timeToNextSpawn -= _gameSettings.ReduceNextSpawnTimeValue;
            }
            _healthController.SetSuddenMode(_timeToNextSpawn < _gameSettings.MinimumNextSpawnTimeValue);

            if (!_currentUsableObject.IsInUsableAnimation)
            {
                _currentUsableObject.MyDisappearParticles.Play();
                yield return new WaitForEndOfFrame();
                NextObjectSpawn();
            }
        }

        private void OnDestroy()
        {
            _currentUsableObject.ObjectUsed.RemoveListener(ObjectUsed);
        }
    }
}
