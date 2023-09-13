using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private bool _isWork = true;
    private int _timeSpawn = 2;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int _randomTargetSpawn;

        while (_isWork)
        {
            _randomTargetSpawn = Random.Range(0, _spawnPoints.Length);

            Enemy enemy = Instantiate(_enemyPrefab,
                _spawnPoints[_randomTargetSpawn].transform.position,
                Quaternion.identity);

            enemy.SetDirection(Vector2.right);

            yield return new WaitForSeconds(_timeSpawn);
        }
    }
}