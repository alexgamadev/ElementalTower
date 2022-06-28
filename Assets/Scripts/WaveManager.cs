using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveManager : MonoBehaviour
{
    private List<SpawnPoint> _spawnPoints;
    [SerializeField] private GameObject normalEnemy;
    [SerializeField] private GameObject bossEnemy;
    private List<GameObject> _waveEntities = new List<GameObject>();
    [SerializeField] private bool _waveFinished = false;
    public int maxSpawnCount = 3;
    private int currentSpawnCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        _spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint").Select(gameObject => gameObject.GetComponent<SpawnPoint>()).ToList();

        StartCoroutine(StartWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartWaves()
    {
        yield return new WaitForSeconds(1f);
        while (currentSpawnCount < maxSpawnCount)
        {
            yield return StartCoroutine(StartWave());
        }
        _spawnPoints[0].Spawn(bossEnemy);
    }

    IEnumerator StartWave()
    {
        currentSpawnCount++;
        _spawnPoints.ForEach(spawnPoint =>
        {
            var entity = spawnPoint.Spawn(normalEnemy);
            entity.GetComponent<Health>().OnDeath += OnEntityDeath;
            _waveEntities.Add(entity);
        });

        _waveFinished = false;
        float waitTime = 10;
        while (!_waveFinished)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0 || _waveEntities.Count <= 0)
            {
                _waveFinished = true;
                yield break;
            }
            yield return null;
        }
        _waveFinished = true;
    }

    void OnEntityDeath(GameObject gameObject)
    {
        _waveEntities.Remove(gameObject);
    }
}
