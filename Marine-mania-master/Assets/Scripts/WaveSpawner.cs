using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float delay;
    }
    public Wave[] waves;
    private int nextWave = 0;

    float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //check enemy are still alive
            if (!EnemyIsAlive())
            {
                // Begin a new round
                WaveCompleted();

            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        } else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;
        //spawn
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(_wave.delay);

        }
        state = SpawnState.WAITING;
        yield break;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //spawn enemy
        Debug.Log("Spawning enemy" + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);

    }

    void WaveCompleted()
    {
        Debug.Log("Wave completed"); 
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVES CLEARED, now looping");
        }
        else
        {
            nextWave++;
        }   
    }


}
