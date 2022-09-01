using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapspawner : MonoBehaviour
{
    public GameObject TrapToSpawn;
    //timer every 5 seconds
    public static float nextActionTime { get; set; } = 0f;
    public float period = 5f;
    private void Update()
    {
        if (Timer.TimePassed > nextActionTime)
        {
            nextActionTime += period;
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-24, 24), 0.37f, Random.Range(-30, 13));//randomly moving spawner


            GameObject justSpawned = Instantiate(TrapToSpawn, randomSpawnPosition, Quaternion.identity);
            justSpawned.tag = "copy";
            justSpawned.gameObject.SetActive(true);
        }
    }
}
