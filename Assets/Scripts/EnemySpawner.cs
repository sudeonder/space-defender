using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private bool isLooping;
    [SerializeField] private List<WaveConfigSO> waveConfigs;
    private WaveConfigSO currentWave;
    private float timeBetweenWaves = 3f;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
        
    }

    // coroutine to spawn enemies
    private IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO waveConfig in waveConfigs)
            {
                currentWave = waveConfig;
                for (int i = 0; i < currentWave.GetNumberOfEnemies(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.Euler(0, 0, 180), transform);
                    yield return new WaitForSeconds(1f);
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while(isLooping);
        
        
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

}
