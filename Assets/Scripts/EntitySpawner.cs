using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject entity;
    [SerializeField] private float spawnDelay = 0f;
    [SerializeField] private float spawnsPerSeconds = 1f;
    [Header("Stopping the spawner")]
    [SerializeField] private int stopCount = 0;
    private int spawnCount = 0;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(spawnDelay);

        coroutine = Spawn();
        StartCoroutine(coroutine);
    }

    IEnumerator Spawn()
    {
        while (spawnCount < stopCount)
        {
            spawnCount++;

            Instantiate(entity, transform.position, transform.rotation);

            float rate = 1 / spawnsPerSeconds;
            yield return new WaitForSeconds(rate);
        }
    }
}
