using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    public static SpawnBalls Instance;

    [SerializeField]
    private GameObject _objSpawn;
    [SerializeField]
    private Transform[] _spawnPoints;
    private Dictionary<Transform, bool> _spawnDictionary = new Dictionary<Transform, bool>();

    [SerializeField]
    private float _timeBetweenSpawn;
    [SerializeField]
    private int _quantitySpawnObj;
    private int _namberPointSpawn;


    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }
    private IEnumerator SpawnSpher()
    {
        int namberSpawn = 0;
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnDictionary[_spawnPoints[i]] = true;
        }

        while (namberSpawn < _quantitySpawnObj)
        {
            Vector3 PosSpawn = GetRandomPosSpawn();
            Instantiate(_objSpawn, PosSpawn, Quaternion.identity);
            namberSpawn++;

            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }

    private Vector3 GetRandomPosSpawn()
    {
        Transform spawnPoint;
        while (true)
        {
            spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            if (_spawnDictionary[spawnPoint])
            {
                _spawnDictionary[spawnPoint] = false;
                _namberPointSpawn++;
                break;
            }
        }
        if (_namberPointSpawn >= _spawnPoints.Length)
        {
            
            _namberPointSpawn = 0;
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                _spawnDictionary[_spawnPoints[i]] = true;
            }
        }
        return spawnPoint.position;
    }
    public void StartSpawn()
    {
        StartCoroutine(SpawnSpher());
    }
}
