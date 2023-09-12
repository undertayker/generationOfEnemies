using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoint;

    private bool _isWork = true;
    private int _randomSpawn;
    private int _timeSpawn = 2;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (_isWork)
        {
            _randomSpawn = Random.Range(0, _spawnPoint.Length);

            Enemy enemy = Instantiate(_enemyPrefab, 
                _spawnPoint[_randomSpawn].transform.position,
                Quaternion.identity);

            yield return new WaitForSeconds(_timeSpawn);
        }
    }
}