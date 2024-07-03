using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;

    private float spawnPeriod = 5f;   // кожні 5 сек
    private float timeLeft;

    void Start()
    {
        timeLeft = 0f;  // = spawnPeriod
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = spawnPeriod;
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        var pipe = GameObject.Instantiate(pipePrefab);
        pipe.transform.position = this.transform.position + 
            Vector3.up * Random.Range(-1f, 1f);
    }
}
